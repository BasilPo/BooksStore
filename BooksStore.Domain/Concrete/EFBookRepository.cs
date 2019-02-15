using BooksStore.Domain.Abstract;
using BooksStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksStore.Domain.Concrete
{
    public class EFBookRepository : IBookRepository, IDisposable 
    {
        EFDBContext context = new EFDBContext();
        public IEnumerable<Book> Books => context.Books/*.Include("Genres").Include("Authors")*/;

        public void SaveBook(Book book, int[] selectedGenres, int[] selectedAuthors)
        {
            if (book.BookId == 0)
            {
                if (selectedGenres != null)
                    foreach (var genre in context.Genres.Where(g => selectedGenres.Any(i => i == g.GenreId)))
                        book.Genres.Add(genre);
                if (selectedAuthors != null)
                    foreach (var author in context.Authors.Where(a => selectedAuthors.Any(i => i == a.AuthorId)))
                        book.Authors.Add(author);
                context.Books.Add(book);
            }
            else
            {
                Book entry = context.Books.Find(book.BookId);
                if (entry != null)
                {
                    entry.Title = book.Title;
                    entry.Description = book.Description;
                    entry.PagesNumber = book.PagesNumber;
                    entry.Price = book.Price;
                    entry.PublicationYear = book.PublicationYear;
                    entry.Genres.Clear();
                    if (selectedGenres != null)
                        foreach (var genre in context.Genres.Where(g => selectedGenres.Any(i => i == g.GenreId)))
                            entry.Genres.Add(genre);
                    entry.Authors.Clear();
                    if (selectedAuthors != null)
                        foreach (var author in context.Authors.Where(a => selectedAuthors.Any(i => i == a.AuthorId)))
                            entry.Authors.Add(author);
                    entry.ImageData = book.ImageData;
                    entry.ImageMimeType = book.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Book DeleteBook(int bookId)
        {
            Book entry = context.Books.Find(bookId);
            if (entry != null)
            {
                context.Books.Remove(entry);
                context.SaveChanges();
            }
            return entry;
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    context.Dispose();
                disposedValue = true;
            }
        }

        public void Dispose() => Dispose(true);
    }
}