using BooksStore.Domain.Abstract;
using BooksStore.Domain.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IBookRepository bookRepository;
        IGenreRepository genreRepository;
        IAuthorRepository authorRepository;

        public AdminController(IBookRepository bookRepository, IGenreRepository genreRepository, IAuthorRepository authorRepository)
        {
            this.bookRepository = bookRepository;
            this.genreRepository = genreRepository;
            this.authorRepository = authorRepository;
        }

        public ViewResult Index() => View(bookRepository.Books);

        public ViewResult ListGenre() => View(genreRepository.Genres);

        public ViewResult ListAuthor() => View(authorRepository.Authors);

        public ViewResult Edit(int bookId)
        {
            var book = bookRepository.Books.FirstOrDefault(b => b.BookId == bookId);
            ViewBag.Genres = genreRepository.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Authors = authorRepository.Authors.OrderBy(a => a.Name).ToList();
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book, int[] selectedGenres, int[] selectedAuthors, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    book.ImageData = new byte[image.ContentLength];
                    book.ImageMimeType = image.ContentType;
                    image.InputStream.Read(book.ImageData, 0, image.ContentLength);
                }
                bookRepository.SaveBook(book, selectedGenres, selectedAuthors);
                TempData["message"] = $"{book.Title} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Genres = genreRepository.Genres.OrderBy(g => g.Name).ToList();
                ViewBag.Authors = authorRepository.Authors.OrderBy(a => a.Name).ToList();
                return View(book);
            }
        }

        public ViewResult EditGenre(int genreId)
        {
            var genre = genreRepository.Genres.FirstOrDefault(g => g.GenreId == genreId);
            return View(genre);
        }

        [HttpPost]
        public ActionResult EditGenre(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genreRepository.SaveGenre(genre);
                TempData["message"] = $"{genre.Name} has been saved";
                return RedirectToAction("ListGenre");
            }
            else
                return View(genre);
        }

        public ViewResult EditAuthor(int authorId)
        {
            var author = authorRepository.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            return View(author);
        }

        [HttpPost]
        public ActionResult EditAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                authorRepository.SaveAuthor(author);
                TempData["message"] = $"{author.Name} has been saved";
                return RedirectToAction("ListAuthor");
            }
            else
                return View(author);
        }

        public ViewResult Create()
        {
            ViewBag.Genres = genreRepository.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Authors = authorRepository.Authors.OrderBy(a => a.Name).ToList();
            return View("Edit", new Book());
        }

        public ViewResult CreateGenre() => View("EditGenre", new Genre());

        public ViewResult CreateAuthor() => View("EditAuthor", new Author());

        [HttpPost]
        public ActionResult Delete(int bookId)
        {
            Book deletedBook = bookRepository.DeleteBook(bookId);
            if (deletedBook != null)
                TempData["message"] = $"{deletedBook.Title} was deleted";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteGenre(int genreId)
        {
            Genre deletedGenre = genreRepository.DeleteGenre(genreId);
            if (deletedGenre != null)
                TempData["message"] = $"{deletedGenre.Name} was deleted";
            return RedirectToAction("ListGenre");
        }

        [HttpPost]
        public ActionResult DeleteAuthor(int authorId)
        {
            Author deletedAuthor = authorRepository.DeleteAuthor(authorId);
            if (deletedAuthor != null)
                TempData["message"] = $"{deletedAuthor.Name} was deleted";
            return RedirectToAction("ListAuthor");
        }

        protected override void Dispose(bool disposing)
        {
            bookRepository.Dispose();
            genreRepository.Dispose();
            authorRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}