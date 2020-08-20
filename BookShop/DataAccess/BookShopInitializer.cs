using DataAccess.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace BusinessLayer
{
    public class BookShopInitializer : DropCreateDatabaseAlways<BookShopContext>
    {
        protected override void Seed(BookShopContext context)
        {
            var fantasy = new Category() { CategoryName = "Fantasy" };
            var fairyTale = new Category() { CategoryName = "Fairy tale" };
            var novel = new Category() { CategoryName = "Novel" };
            var memoirs = new Category() { CategoryName = "Memoirs" };
            
            var listOfCategories = new List<Category>();
            listOfCategories.Add(fantasy);
            listOfCategories.Add(fairyTale);
            listOfCategories.Add(novel);
            listOfCategories.Add(memoirs);

            var rowling = new Writer() { FirstName = "Joanne", LastName = "Rowling" };
            var barrie = new Writer() { FirstName = "James", LastName = "Barrie" };
            var harris = new Writer() { FirstName = "Joanne", LastName = "Harris" };
            var gilbert = new Writer() { FirstName = "Elizabeth", LastName = "Gilbert" };
            var collins = new Writer() { FirstName = "Suzanne", LastName = "Collins" };

            var listOfWriters = new List<Writer>();
            listOfWriters.Add(rowling);
            listOfWriters.Add(barrie);
            listOfWriters.Add(harris);
            listOfWriters.Add(gilbert);
            listOfWriters.Add(collins);

            var harryPotter = new Book() { Name = "Harry Potter", Category = fantasy };
            harryPotter.Writers.Add(rowling);

            var peterPan = new Book() { Name = "Piter Pan", Category = fairyTale };
            peterPan.Writers.Add(barrie);

            var chocolate = new Book() { Name = "Chocolate", Category = novel };
            chocolate.Writers.Add(harris);

            var eatPrayLove = new Book() { Name = "Eat, pray, love", Category = memoirs };
            eatPrayLove.Writers.Add(gilbert);

            var hungerGames = new Book() { Name = "The hunger games", Category = fantasy };
            hungerGames.Writers.Add(collins);

            var listOfBooks = new List<Book>();
            listOfBooks.Add(harryPotter);
            listOfBooks.Add(peterPan);
            listOfBooks.Add(chocolate);
            listOfBooks.Add(eatPrayLove);
            listOfBooks.Add(hungerGames);

            context.Categories.AddRange(listOfCategories);
            context.Books.AddRange(listOfBooks);
            context.Writers.AddRange(listOfWriters);

            context.SaveChanges();
        }
    }
}
