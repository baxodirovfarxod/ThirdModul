using BookCRUD.DataAccess.Entity;
using BookCRUD.Repository.Repository;
using BookCRUD.Service.DTOs;

namespace BookCRUD.Service.Service;
public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService()
    {
        _bookRepository = new BookRepository();
    }
    public Guid AddBook(BookCreatDto book)
    {
        var _book = ConvertToEntity(book);
        return _bookRepository.AddBook(_book);
    }
    public void DeleteBook(Guid id)
    {
        _bookRepository.DeleteBook(id);
    }
    public List<BookDto> GetAllBooks()
    {
        var books = _bookRepository.GetAllBooks().Select(book => ConvertToDto(book)).ToList();
        return books;
    }
    public BookDto GetBookById(Guid id)
    {
        return ConvertToDto(_bookRepository.GetBookById(id));
    }
    public void UpdateBook(BookDto book)
    {
        _bookRepository.UpdateBook(ConvertToEntity(book));
    }
    public List<BookDto> GetAllBooksByAuthor(string author)
    {
        var books = GetAllBooks();
        return books.Where(book => book.Author.ToLower() == author.ToLower()).ToList();
    }
    public BookDto GetTopRatedBook()
    {
        var books = GetAllBooks();
        var maxRating = books.Max(book => book.Rating);
        var res = books.FirstOrDefault(book => book.Rating == maxRating);
        if (res == null)
        {
            throw new Exception("Storage is empty");
        }
        return res;
    }
    public List<BookDto> GetBooksPublishedAfterYear(int year)
    {
        var booksList = GetAllBooks();
        var books = booksList.Where(book => book.PublishedDate > year).ToList();
        return books;
    }
    public BookDto GetMostPopularBook()
    {
        var booksList = GetAllBooks();
        var numberOfCopiesSold = booksList.Max(book => book.NumberOfCopiesSold);
        var book = booksList.FirstOrDefault(book => book.NumberOfCopiesSold == numberOfCopiesSold);
        if (book is null)
        {
            throw new Exception("Storage is empty!");
        }

        return book;
    }
    public List<BookDto> SearchBooksByTitle(string keyword)
    {
        var bookList = GetAllBooks();
        var book = bookList.Where(book => book.Title.ToLower().Contains(keyword.ToLower())).ToList();
        return book;
    }
    public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
    {
        var bookList = GetAllBooks();
        return bookList.Where(book => book.Pages > minPages && book.Pages < maxPages).ToList();
    }
    public int GetTotalCopiesSoldByAuthor(string author)
    {
        var books = GetAllBooksByAuthor(author);
        return books.Sum(book => book.NumberOfCopiesSold);
    }
    public List<BookDto> GetBooksSortedByRating()
    {
        var booksList = GetAllBooks();
        return booksList.OrderByDescending(book => book.Rating).ToList();
    }
    public List<BookDto> GetRecentBooks(int years)
    {
        var books = GetAllBooks();
        return books.Where(book => book.PublishedDate == years).ToList();
    }
    private Book ConvertToEntity(BookDto book)
    {
        return new Book 
        { 
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Pages = book.Pages,
            Rating = book.Rating,
            NumberOfCopiesSold = book.NumberOfCopiesSold,
            PublishedDate = book.PublishedDate,
        };
    }
    private Book ConvertToEntity(BookCreatDto book)
    {
        return new Book
        {
            Id = Guid.NewGuid(),
            Title = book.Title,
            Author = book.Author,
            Pages = book.Pages,
            Rating = book.Rating,
            NumberOfCopiesSold = book.NumberOfCopiesSold,
            PublishedDate = book.PublishedDate,
        };
    }
    private BookDto ConvertToDto(Book book)
    {
        return new BookDto
        { 
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Pages = book.Pages,
            Rating = book.Rating,
            NumberOfCopiesSold= book.NumberOfCopiesSold,
            PublishedDate = book.PublishedDate,
        };

    }
}
