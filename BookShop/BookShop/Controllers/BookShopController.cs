using BusinessLayer;
using BusinessLayer.ModelsDTO;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    public class BookShopController : Controller
    {
        // GET: BookShop

        public readonly BookShopManager _bookshopmanager;

        public BookShopController()
        {
            _bookshopmanager = new BookShopManager();
        }
        public ActionResult Index()
        {
            var books = _bookshopmanager.GetAllBooks();

            return View(books);
        }

        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(BookDTO bookDto, WriterDTO writerDto, CategoryDTO categoryDto)
        {
            _bookshopmanager.AddBook(bookDto, writerDto, categoryDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RemoveBook(int id)
        {
            _bookshopmanager.RemoveBookById(id);

            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult EditBook(int id)
        {
            var book = _bookshopmanager.GetBookById(id);
            SelectList categories = new SelectList(_bookshopmanager.CreateListCategories(), "Id", "CategoryName", book.Id);

            ViewBag.Categories = categories;

            return View(book);
        }
       
        [HttpPost]

        public ActionResult EditBook(BookDTO book)
        {
            _bookshopmanager.UpdateBook(book);

            return RedirectToAction("Index");
        }

        public ActionResult BookDetails(int id)
        {
            var book = _bookshopmanager.GetBookById(id);

            return View(book);
        }
    }
}

