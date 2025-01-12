using BookCRUD.Service.DTOs;

namespace BookCRUD.Service.Service;
public interface IBookService
{
    Guid AddBook(BookCreatDto book);
    BookDto GetBookById(Guid id);
    void DeleteBook(Guid id);
    void UpdateBook(BookDto book);
    List<BookDto> GetAllBooks();
    List<BookDto> GetAllBooksByAuthor(string author);
    BookDto GetTopRatedBook();
    List<BookDto> GetBooksPublishedAfterYear(int year);
    BookDto GetMostPopularBook();
    List<BookDto> SearchBooksByTitle(string keyword);
    List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages);
    int GetTotalCopiesSoldByAuthor(string author);
    List<BookDto> GetBooksSortedByRating();
    List<BookDto> GetRecentBooks(int years);
}