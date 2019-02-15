using BooksStore.Domain.Abstract;
using BooksStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BooksStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IBookRepository bookRepository;

        public HomeController(IBookRepository bookRepository) => this.bookRepository = bookRepository;

        public ViewResult Index()
        {
            var books = GetTopSellingBooks(3);
            return View(books);
        }

        private IEnumerable<Book> GetTopSellingBooks(int count)
        {
            var topBooks = bookRepository.Books
                .OrderByDescending(b => b.PagesNumber)
                .Take(count)
                .ToList();
            return topBooks;
        }

        public FilePathResult ImageForCarousel(int index)
        {
            List<string> filesName = new List<string>
            {
                Server.MapPath("~/Content/Images/Carousel/first.png"),
                Server.MapPath("~/Content/Images/Carousel/second.png"),
                Server.MapPath("~/Content/Images/Carousel/third.png")
            };
            string contentType = "image/png";
            int i = (index < 0) ? -index : index;
            return File(filesName[i % 3], contentType);
        }

        protected override void Dispose(bool disposing)
        {
            bookRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}