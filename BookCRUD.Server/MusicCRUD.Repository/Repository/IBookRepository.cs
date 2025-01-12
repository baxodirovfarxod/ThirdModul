using BookCRUD.DataAccess.Entity;

namespace BookCRUD.Repository.Repository;
public interface IBookRepository
{
    Guid AddBook(Book book);
    Book GetBookById(Guid id);
    void DeleteBook(Guid id);
    void UpdateBook(Book book);
    List<Book> GetAllBooks();
}