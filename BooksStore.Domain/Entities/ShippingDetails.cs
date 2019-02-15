using System.ComponentModel.DataAnnotations;

namespace BooksStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter a address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }
        public bool GiftWrap { get; set; }
    }
}