using Microsoft.AspNetCore.Mvc;
using LibraryStore.Models;
using System.Linq;

namespace LibraryStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly LibraryStoreContext _context;

        public AccountController(LibraryStoreContext context)
        {
            _context = context;
        }

        // Register
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    TempData["Error"] = "Email already registered!";
                    return View();
                }

                user.Role = "User";
                _context.Users.Add(user);
                _context.SaveChanges();

                TempData["Success"] = "Registration successful! You can now login.";
                return RedirectToAction("Login");
            }
            return View();
        }

        // Login
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                TempData["Error"] = "Invalid email or password!";
                return View();
            }

            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserRole", user.Role);
            HttpContext.Session.SetString("UserId", user.Id.ToString());

            TempData["Success"] = "Login successful!";
            if (user.Role == "Admin")
                return RedirectToAction("Dashboard", "Admin");

            return RedirectToAction("Index", "Home");
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Success"] = "You have been logged out.";
            return RedirectToAction("Login");
        }
    }
}
