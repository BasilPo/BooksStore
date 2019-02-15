using BooksStore.Domain.Entities;
using System.Collections.Generic;

namespace BooksStore.Domain.Abstract
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
        void SaveBook(Book book, int[] selectedGenres, int[] selectedauthors);
        Book DeleteBook(int bookId);
        void Dispose();
    }
}