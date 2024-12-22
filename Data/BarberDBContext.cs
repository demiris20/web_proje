using Microsoft.EntityFrameworkCore;
using web_proje.Models;

namespace web_proje.Data
{
    public class BarberDBContext(DbContextOptions<BarberDBContext> options) : DbContext(options)
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<Customer> Customers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });
        }
    }
}

