using BookCRUD.Service.DTOs;
using BookCRUD.Service.Extension;
using BookCRUD.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCRUD.Server.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        public BookController()
        {
            bookService = new BookService();
        }
        [HttpPost("addBook")]
        public Guid AddBook(BookCreatDto book)
        {
            return bookService.AddBook(book);
        }

        [HttpPut("updateBook")]
        public void UpdateBook(BookDto book)
        {
            bookService.UpdateBook(book);
        }

        [HttpDelete("deleteBook")]
        public void DeleteBook(Guid id)
        {
            bookService.DeleteBook(id);
        }

        [HttpGet("getAllBooks")]
        public List<BookDto> GetBooks()
        {
            return bookService.GetAllBooks();
        }

        [HttpGet("getAllBooksByAuthor")]
        public List<BookDto> GetAllBooksByAuthor(string author)
        {
            return bookService.GetAllBooksByAuthor(author);
        }

        [HttpGet("GetTopRatedBook")]
        public BookDto GetTopRatedBook()
        {
            return bookService.GetTopRatedBook();
        }

        [HttpGet("getBooksPublishedAfterYear")]
        public List<BookDto> GetBooksPublishedAfterYear(int year)
        {
            return bookService.GetBooksPublishedAfterYear(year);
        }

        [HttpGet("getMostPopularBook")]
        public BookDto GetMostPopularBook()
        {
            return bookService.GetMostPopularBook();
        }

        [HttpGet("searchBooksByTitle")]
        public List<BookDto> SearchBooksByTitle(string keyword)
        {
            return bookService.SearchBooksByTitle(keyword);
        }

        [HttpGet("getBooksWithinPageRange")]
        public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
        {
            return bookService.GetBooksWithinPageRange(minPages, maxPages);
        }

        [HttpGet("getTotalCopiesSoldByAuthor")]
        public int GetTotalCopiesSoldByAuthor(string author)
        {
            return bookService.GetTotalCopiesSoldByAuthor(author);
        }

        [HttpGet("getBooksSortedByRating")]
        public List<BookDto> GetBooksSortedByRating()
        {
            return bookService.GetBooksSortedByRating();
        }

        [HttpGet("getRecentBooks")]
        public List<BookDto> GetRecentBooks(int years)
        {
            return bookService.GetRecentBooks(years);
        }

        [HttpGet("bookPages")]
        public int BookPages(Guid id)
        {
            return bookService.BookPages(id);
        }

        [HttpGet("NumberOfCopiesSold")]
        public int NumberOfCopiesSold()
        {
            return bookService.NumberOfCopiesSold();
        }
    }
}
