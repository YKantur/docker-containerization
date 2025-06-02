using BookStore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<BooksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreContext"));
});

var app = builder.Build();

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<BooksDbContext>();
await dbContext.Database.MigrateAsync();
var books = BooksSeeder.GetBooks();
if (!dbContext.Books.Any())
{
    dbContext.Books.AddRange(books);
    await dbContext.SaveChangesAsync();
}

app.MapControllers();
app.Run();