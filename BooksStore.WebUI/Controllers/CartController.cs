using BooksStore.Domain.Abstract;
using BooksStore.Domain.Entities;
using BooksStore.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BooksStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        IBookRepository bookRepository;
        IOrderProcessor orderProcessor;

        public CartController(IBookRepository bookRepository, IOrderProcessor orderProcessor)
        {
            this.bookRepository = bookRepository;
            this.orderProcessor = orderProcessor;
        }

        public ViewResult Index(Cart cart, string returnUrl) => View(new CartIndexViewModel
        {
            Cart = cart,
            ReturnUrl = returnUrl
        });

        public RedirectToRouteResult AddToCart(Cart cart, int bookId, string returnUrl)
        {
            var book = bookRepository.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
                cart.AddItem(book, 1);
            return RedirectToAction("Index", "Cart", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int bookId, string returnUrl)
        {
            var book = bookRepository.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
                cart.RemoveItem(book);
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart) => PartialView(cart);

        public ViewResult Checkout() => View(new ShippingDetails());

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Items.Count() == 0)
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
                return View(shippingDetails);
        }

        protected override void Dispose(bool disposing)
        {
            bookRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}