using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BooksStore.Domain.Entities
{
    public class Genre
    {
        [HiddenInput(DisplayValue = false)]
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Please enter a genre name")]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}