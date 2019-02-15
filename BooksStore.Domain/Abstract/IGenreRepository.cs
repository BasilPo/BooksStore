using BooksStore.Domain.Entities;
using System.Collections.Generic;

namespace BooksStore.Domain.Abstract
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> Genres { get; }
        void SaveGenre(Genre genre);
        Genre DeleteGenre(int genreId);
        void Dispose();
    }
}