using Microsoft.EntityFrameworkCore;

namespace web_proje.Models
{
    public class BarberDBContext : DbContext
    {
        
        // DbSet ile veritabanı tablolarını temsil eden modelleri tanımlıyoruz.
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=BerberDB; Trusted_Connection=True;");
        }
        
    }
}
