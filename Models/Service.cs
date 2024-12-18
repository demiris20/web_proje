using System.ComponentModel.DataAnnotations;

namespace web_proje.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hizmet adı zorunludur.")]
        [StringLength(100)]
         public  required string Name { get; set; }

        [Required(ErrorMessage = "Fiyat alanı zorunludur.")]
        [Range(0, 10000, ErrorMessage = "Fiyat 0-10000 TL arasında olmalıdır.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Süre alanı zorunludur.")]
        [Range(1, 240, ErrorMessage = "Süre 1-240 dakika arasında olmalıdır.")]
        public int Duration { get; set; }

        [StringLength(500)]
        public required string Description { get; set; }

        // İlişkisel özellik
        public required List<Appointment> Appointments { get; set; }
    }
}
