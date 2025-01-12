using BookCRUD.DataAccess.Entity;
using System.Text.Json;

namespace BookCRUD.Repository.Repository;
public class BookRepository : IBookRepository
{
    private readonly List<Book> _books;
    private readonly string _path;
    public BookRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Book.json");
        if (File.Exists(_path) is false)
        {
            File.WriteAllText(_path, "[]");
        }
        _books = ReadBooks();
    }
    public Guid AddBook(Book book)
    {
        _books.Add(book);
        SaveData();
        return book.Id;
    }
    public Book GetBookById(Guid id)
    {
        var bookById = _books.FirstOrDefault(book => book.Id == id);
        if (bookById == null)
        {
            throw new Exception($"Bunday {id} lik kitob yo'q");
        }

        return bookById;
    }
    public void UpdateBook(Book book)
    {
        var bookFromDB = GetBookById(book.Id);
        var index = _books.IndexOf(bookFromDB);
        _books[index] = book;
        SaveData();
    }
    public void DeleteBook(Guid id)
    {
        var book = GetBookById(id);
        _books.Remove(book);
        SaveData();
    }
    public List<Book> GetAllBooks()
    {
        return _books;
    }
    private void SaveData()
    {
        var booksJson = JsonSerializer.Serialize(_books);
        File.WriteAllText(_path, booksJson);
    }
    private List<Book> ReadBooks()
    {
        var booksJson = File.ReadAllText(_path);
        var books = JsonSerializer.Deserialize<List<Book>>(booksJson);
        return books;
    }
}
