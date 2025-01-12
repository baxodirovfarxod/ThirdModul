using BookCRUD.Service.Service;

namespace BookCRUD.Service.Extension;
public static class BookServiceExtension
{
    public static int BookPages(this IBookService bookService, Guid id)
    {
        return bookService.GetBookById(id).Pages;
    }
    public static int NumberOfCopiesSold(this IBookService bookService)
    {
        var books = bookService.GetAllBooks();
        return books.Sum(book => book.NumberOfCopiesSold);
    }
}
