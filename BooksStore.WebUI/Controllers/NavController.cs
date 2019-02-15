using BooksStore.Domain.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BooksStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        IGenreRepository genreRepository;

        public NavController(IGenreRepository genreRepository) => this.genreRepository = genreRepository;
        // GET: Nav
        public PartialViewResult Menu(string genre = null)
        {
            ViewBag.SelectedGenre = genre;
            IEnumerable<string> genres = genreRepository.Genres
                .Select(g => g.Name)
                .OrderBy(n => n);
            return PartialView(genres);
        }

        protected override void Dispose(bool disposing)
        {
            genreRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}