using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using web_proje.Models;
using web_proje.Data;
using System.Linq;
using System;
using System.Collections.Generic;

namespace web_proje.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly BarberDBContext _context;

        public AppointmentController(BarberDBContext context)
        {
            _context = context;
        }

        // Randevu listesi
        public IActionResult Index()
        {
            var appointments = _context.Appointments
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
            var existingAppointments = _context.Appointments
                .Where(a => a.AppointmentDate.Date == date.Date)
                .Include(a => a.Service)
                .ToList();

            var availableSlots = GetAvailableTimeSlots(existingAppointments);

            return Json(new { available = true, slots = availableSlots });
        }

        private static List<TimeSpan> GetAvailableTimeSlots(List<Appointment> existingAppointments)
        {
            var slots = new List<TimeSpan>();
            TimeSpan startTime = new(8, 0, 0); // 08:00
            TimeSpan endTime = new(20, 0, 0); // 20:00
            TimeSpan currentTime = startTime;

            while (currentTime.Add(TimeSpan.FromMinutes(30)) <= endTime)
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
}
