using System.ComponentModel.DataAnnotations;

namespace web_proje.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Randevu tarihi zorunludur.")]
        [DataType(DataType.Date)]

        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Randevu saati zorunludur.")]
        public TimeSpan AppointmentTime { get; set; }

        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }

        public int ServiceId { get; set; }
        public required Service Service { get; set; }

        [Required]
        public string Status { get; set; } = "Beklemede";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
