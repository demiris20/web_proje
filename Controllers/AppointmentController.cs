using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using web_proje.Models;

namespace web_proje.Controllers
{
    /*
      public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Randevu listesi
        public IActionResult Index()
        {
            /* var appointments = _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Service)
                .OrderByDescending(a => a.AppointmentDate)
                .ToList();
            return View(appointments);

}

// Yeni randevu oluşturma sayfası
public IActionResult Create()
{
    ViewBag.Services = new SelectList(_context.Services, "Id", "Name");
    return View();
}

// Randevu kaydetme
[HttpPost]
public IActionResult Create(Appointment appointment)
{
    if (ModelState.IsValid)
    {
        // Müşteri kaydı
        if (appointment.Customer.Id == 0)
        {
            _context.Customers.Add(appointment.Customer);
            _context.SaveChanges();
            appointment.CustomerId = appointment.Customer.Id;
        }

        appointment.CreatedAt = DateTime.Now;
        appointment.Status = "Beklemede";

        _context.Appointments.Add(appointment);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    ViewBag.Services = new SelectList(_context.Services, "Id", "Name");
    return View(appointment);
}

// Müsait saatleri kontrol etme
[HttpGet]
public IActionResult CheckAvailability(DateTime date)
{
    var workingHours = _context.WorkingHours
        .FirstOrDefault(w => w.DayOfWeek == date.DayOfWeek && w.IsWorkingDay);

    if (workingHours == null)
        return Json(new { available = false, message = "Bu gün çalışma günü değil." });

    var existingAppointments = _context.Appointments
        .Where(a => a.AppointmentDate.Date == date.Date)
        .Include(a => a.Service)
        .ToList();

    var availableSlots = GetAvailableTimeSlots(workingHours, existingAppointments);

    return Json(new { available = true, slots = availableSlots });
}

private List<TimeSpan> GetAvailableTimeSlots(WorkingHours workingHours, List<Appointment> existingAppointments)
{
    var slots = new List<TimeSpan>();
    var currentTime = workingHours.StartTime;

    while (currentTime.Add(TimeSpan.FromMinutes(30)) <= workingHours.EndTime)
    {
        if (!existingAppointments.Any(a =>
            a.AppointmentTime <= currentTime &&
            a.AppointmentTime.Add(TimeSpan.FromMinutes(a.Service.Duration)) > currentTime))
        {
            slots.Add(currentTime);
        }
        currentTime = currentTime.Add(TimeSpan.FromMinutes(30));
    }

    return slots;
}
    } 



     */
  
}
