using System.Data.Entity;
using BooksStore.WebUI.Models;

namespace BooksStore.WebUI.Infrastructure.Concrete
{
    public class EFAuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}