using Microsoft.EntityFrameworkCore;
using web_proje.Models;

namespace web_proje.Data
{
    public class BarberDBContext : DbContext
    {
        public BarberDBContext(DbContextOptions<BarberDBContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
