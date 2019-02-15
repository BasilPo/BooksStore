using BooksStore.Domain.Abstract;
using BooksStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BooksStore.Domain.Concrete
{
    public class EFGenreRepository : IGenreRepository, IDisposable
    {
        EFDBContext context = new EFDBContext();
        public IEnumerable<Genre> Genres => context.Genres;

        public void SaveGenre(Genre genre)
        {
            if (genre.GenreId == 0)
                context.Genres.Add(genre);
            else
            {
                Genre entry = context.Genres.Find(genre.GenreId);
                if (entry != null)
                    entry.Name = genre.Name;
            }
            context.SaveChanges();
        }

        public Genre DeleteGenre(int genreId)
        {
            Genre entry = context.Genres.Find(genreId);
            if (entry != null)
            {
                context.Genres.Remove(entry);
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