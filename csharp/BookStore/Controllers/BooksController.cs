using BookStore.DTOs;
using BookStore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BooksDbContext _context;

    public BooksController(BooksDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetBooks()
    {
        var books = _context.Books.ToList();
        return Ok(books);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetBook(int id)
    {
        var book = _context.Books.Find(id);
        
        if (book == null)
        {
            return NotFound();
        }
        
        return Ok(book);
    }
    
    [HttpPost]
    public IActionResult CreateBook([FromBody] BookDto bookDto)
    {
        var book = new Book{
            Title = bookDto.Title,
            Author = bookDto.Author,
            Price = bookDto.Price
        };
        
        _context.Books.Add(book);
        _context.SaveChanges();
        
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }
}