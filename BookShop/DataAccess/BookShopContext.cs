using DataAccess.Models;
using System.Data.Entity;
namespace BusinessLayer
{
    public class BookShopContext:DbContext
    {
        public BookShopContext():base("DefaultConnection")
        {
            Database.SetInitializer(new BookShopInitializer());
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
