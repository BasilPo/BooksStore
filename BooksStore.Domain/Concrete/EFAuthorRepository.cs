using BooksStore.Domain.Abstract;
using BooksStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BooksStore.Domain.Concrete
{
    public class EFAuthorRepository : IAuthorRepository, IDisposable
    {
        EFDBContext context = new EFDBContext();

        public IEnumerable<Author> Authors => context.Authors;

        public void SaveAuthor(Author author)
        {
            if (author.AuthorId == 0)
                context.Authors.Add(author);
            else
            {
                Author entry = context.Authors.Find(author.AuthorId);
                if (entry != null)
                    entry.Name = author.Name;
            }
            context.SaveChanges();
        }

        public Author DeleteAuthor(int authorId)
        {
            Author entry = context.Authors.Find(authorId);
            if (entry != null)
            {
                context.Authors.Remove(entry);
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