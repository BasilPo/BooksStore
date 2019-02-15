using BooksStore.Domain.Entities;
using System.Data.Entity;

namespace BooksStore.Domain.Concrete
{
    public class EFDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .Map(t =>
                {
                    t.MapLeftKey("AuthorId");
                    t.MapRightKey("BookId");
                    t.ToTable("AuthorBook");
                });

            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Books)
                .WithMany(b => b.Genres)
                .Map(t =>
                {
                    t.MapLeftKey("GenreId");
                    t.MapRightKey("BookId");
                    t.ToTable("GenreBook");
                });

            //modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}