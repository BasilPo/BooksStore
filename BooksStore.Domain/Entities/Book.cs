using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BooksStore.Domain.Entities
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Please enter a book title")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Display(Name = "Number of pages")]
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int PagesNumber { get; set; }
        [Display(Name = "Year of publication")]
        [Required]
        [Range(1900, 2020, ErrorMessage = "Please enter a valid year")]
        public int PublicationYear { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}