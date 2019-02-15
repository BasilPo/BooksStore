using BooksStore.Domain.Abstract;
using BooksStore.WebUI.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace BooksStore.WebUI.Controllers
{
    public class BookController : Controller
    {
        IBookRepository bookRepository;
        int pageSize = 4;

        public BookController(IBookRepository bookRepository) => this.bookRepository = bookRepository;

        public ViewResult List(string genre, int page = 1)
        {
            BooksListViewModel viewModel = new BooksListViewModel
            {
                Books = bookRepository.Books.ToList()
                .Where(b => b.Genres.Any(g => g.Name == genre) || genre == null)
                .OrderBy(b => b.BookId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = genre == null ? bookRepository.Books.Count() 
                    : bookRepository.Books.ToList().Where(b => b.Genres.Any(g => g.Name == genre)).Count()
                },
                CurrentGenre = genre
            };
            return View(viewModel);
        }

        public ViewResult Details(int id, string returnUrl)//EDIT
        {
            ViewBag.ReturnUrl = returnUrl;//edit
            var book = bookRepository.Books.SingleOrDefault(b => b.BookId == id);
            return View(book);
        }

        public FileContentResult GetImage(int bookId)
        {
            var book = bookRepository.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
                return File(book.ImageData, book.ImageMimeType);
            else
                return null;
        }

        protected override void Dispose(bool disposing)
        {
            bookRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}