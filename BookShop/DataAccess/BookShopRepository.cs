using BusinessLayer;
using DataAccess.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccess
{
   public class BookShopRepository
    {
        public IList<Book> GetAllBooks()
        {
            using(var context = new BookShopContext())
            {
                return context.Books.
                    Include(book => book.Writers).
                    Include(book=>book.Category).
                    ToList();
            }
        }

        public void AddBook (Book book, Writer writer, Category category)
        {
            using(var context = new BookShopContext())
            {
                book.Writers.Add(writer);
                book.Category = category;
                context.Books.Add(book);
                context.Writers.Add(writer);

                context.SaveChanges();
            }
        }

        public void RemoveBookById(int id)
        {
            using(var context=new BookShopContext())
            {
                context.Books.Remove(context.Books.First(book => book.Id == id));

                context.SaveChanges();
            }
        }

        public void UpdateBook(Book book)
        {
            using(var context=new BookShopContext())
            {
                var newBook = context.Books.Include(b => b.Writers).Include(b => b.Category).FirstOrDefault(b => b.Id == book.Id);

                newBook.Name = book.Name;
                newBook.Writers.Clear();
                newBook.Writers = book.Writers;
                newBook.Category = book.Category;

                //context.Entry(newBook).State = EntityState.Added;
                context.Entry(newBook).State = EntityState.Modified;

                context.Books.AddOrUpdate(book);

                context.SaveChanges();
            }
        }

        public Book GetBookById(int id)
        {
            using(var context=new BookShopContext())
            {
                return context.Books.
                    Include(book => book.Writers).
                    Include(book => book.Category).
                    First(book => book.Id == id);
            }
        }

        public IList<Category>CreateListCategories()
        {
            using (var context = new BookShopContext())
            {
                return context.Categories.ToList();
            }
        }
    }
}
