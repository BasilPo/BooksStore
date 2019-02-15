using BooksStore.Domain.Entities;
using System.Collections.Generic;

namespace BooksStore.Domain.Abstract
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> Authors { get; }
        void SaveAuthor(Author author);
        Author DeleteAuthor(int authorId);
        void Dispose();
    }
}