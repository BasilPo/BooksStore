using System.Collections.Generic;
using System.Linq;

namespace BooksStore.Domain.Entities
{
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();

        public IEnumerable<CartItem> Items => items;

        public void AddItem(Book book, int quantity)
        {
            var item = items.FirstOrDefault(i => i.Book.BookId == book.BookId);
            if (item == null)
                items.Add(new CartItem { Book = book, Quantity = quantity });
            else
                item.Quantity += quantity;
        }

        public void RemoveItem(Book book) => items.RemoveAll(i => i.Book.BookId == book.BookId);

        public decimal TotalValue() => items.Sum(i => i.Quantity * i.Book.Price);

        public void Clear() => items.Clear();
    }

    public class CartItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}