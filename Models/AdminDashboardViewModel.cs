using System.Collections.Generic; // List<T> kullanmak için gerekli
using System.ComponentModel.DataAnnotations;

namespace web_proje.Models
{
    public class AdminDashboardViewModel
    {
        public List<Personnel> Personnel { get; set; } = new List<Personnel>(); // Liste initialize edildi
        public List<Appointment> Appointments { get; set; } = new List<Appointment>(); // Liste initialize edildi
    }
}
