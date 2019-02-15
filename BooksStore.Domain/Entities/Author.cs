using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BooksStore.Domain.Entities
{
    public class Author
    {
        [HiddenInput(DisplayValue = false)]
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Please enter a author name")]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}