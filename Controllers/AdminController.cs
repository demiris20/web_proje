using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_proje.Models;

namespace web_proje.Controllers
{
    public class AdminController : Controller
    {
        private readonly BarberDBContext _context;

        // Inject DbContext through constructor
        public AdminController(BarberDBContext context)
        {
            _context = context;
        }

        private const string AdminUsername = "admin";
        private const string AdminPassword = "123456";

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == AdminUsername && password == AdminPassword)
            {
                HttpContext.Session.SetString("AdminUser", AdminUsername);
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            // Fetch personnel from database
            var viewModel = new AdminDashboardViewModel
            {
                Personnel = _context.Personnel.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddPersonnel(string Name, string Email)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            {
                TempData["ErrorMessage"] = "Ad ve E-posta boş bırakılamaz.";
                return RedirectToAction("Dashboard");
            }

            var newPersonnel = new Personnel
            {
                Name = Name,
                Email = Email
            };

            _context.Personnel.Add(newPersonnel);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Personel başarıyla eklendi.";
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult DeletePersonnel(int id)
        {
            var personnel = _context.Personnel.Find(id);
            if (personnel == null)
            {
                TempData["ErrorMessage"] = "Personel bulunamadı.";
                return RedirectToAction("Dashboard");
            }

            _context.Personnel.Remove(personnel);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Personel başarıyla silindi.";
            return RedirectToAction("Dashboard");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminUser");
            return RedirectToAction("Login");
        }
    }
}