using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryStore.Models;

namespace LibraryStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly LibraryStoreContext _context;
        public AdminController(LibraryStoreContext context) { _context = context; }

        public IActionResult Dashboard()
        {
            var data = new
            {
                Users = _context.Users.Count(),
                Books = _context.Books.Count(),
                Borrowed = _context.BorrowRecords.Count(r => !r.IsReturned)
            };
            ViewBag.Stats = data;
            return View();
        }

        public IActionResult Users()
        {
            return View(_context.Users.ToList());
        }

        public IActionResult Records()
        {
            var rec = _context.BorrowRecords.Include(r => r.Book).Include(r => r.User).ToList();
            return View(rec);
        }
    }
}
