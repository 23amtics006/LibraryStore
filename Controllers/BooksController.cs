using Microsoft.AspNetCore.Mvc;
using LibraryStore.Models;
using System.Linq;

namespace LibraryStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryStoreContext _context;
        public BooksController(LibraryStoreContext context) { _context = context; }

        public IActionResult Index(string search)
        {
            var books = from b in _context.Books select b;
            if (!string.IsNullOrEmpty(search))
                books = books.Where(b => b.Title.Contains(search) || b.Author.Contains(search));

            return View(books.ToList());
        }

        // Admin Only
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                TempData["Success"] = "Book added successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            TempData["Success"] = "Book updated!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            TempData["Success"] = "Book deleted!";
            return RedirectToAction("Index");
        }
    }
}
