using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryStore.Models;

namespace LibraryStore.Controllers
{
    public class BorrowController : Controller
    {
        private readonly LibraryStoreContext _context;
        public BorrowController(LibraryStoreContext context) { _context = context; }

        public IActionResult MyBooks()
        {
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var records = _context.BorrowRecords
                .Include(r => r.Book)
                .Where(r => r.UserId == userId)
                .ToList();
            return View(records);
        }

public IActionResult Borrow(int id)
{
    var userIdString = HttpContext.Session.GetString("UserId");

    if (string.IsNullOrEmpty(userIdString))
    {
        TempData["Error"] = "You must be logged in to borrow a book.";
        return RedirectToAction("Login", "Account");
    }

    int userId = int.Parse(userIdString);

    // Continue with your borrowing logic here...
    var book = _context.Books.Find(id);
    if (book == null)
    {
        TempData["Error"] = "Book not found.";
        return RedirectToAction("Index", "Book");
    }

    // Borrow record creation logic
    BorrowRecord record = new BorrowRecord
    {
        BookId = id,
        UserId = userId,
        BorrowDate = DateTime.Now,
        ReturnDate = null
    };

    _context.BorrowRecords.Add(record);
    book.IsAvailable = false;
    _context.SaveChanges();

    TempData["Success"] = $"You have successfully borrowed '{book.Title}'.";
    return RedirectToAction("Index", "Books");
}


        public IActionResult Return(int id)
        {
            var record = _context.BorrowRecords.Include(r => r.Book).FirstOrDefault(r => r.Id == id);
            if (record == null)
            {
                TempData["Error"] = "Record not found!";
                return RedirectToAction("MyBooks");
            }

            record.IsReturned = true;
            record.ReturnDate = DateTime.Now;
            record.Book.IsAvailable = true;
            _context.SaveChanges();

            TempData["Success"] = $"You returned '{record.Book.Title}'.";
            return RedirectToAction("MyBooks");
        }
    }
}
