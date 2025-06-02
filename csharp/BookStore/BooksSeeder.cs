using BookStore.Entities;

namespace BookStore;

public static class BooksSeeder
{
    public static List<Book> GetBooks()
    {
        return
        [
            new Book {  Title = "1984", Author = "George Orwell", Price = 9.99m },
            new Book {  Title = "To Kill a Mocking", Author = "Harper Lee", Price = 7.99m }
        ];
    }
}