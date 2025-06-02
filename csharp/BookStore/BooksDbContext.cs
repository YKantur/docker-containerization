using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    { }
    
    public DbSet<Book> Books { get; set; }
}