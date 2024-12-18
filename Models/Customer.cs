using System.ComponentModel.DataAnnotations;

namespace web_proje.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [StringLength(50)]
        public required string Surname { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public required string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public required string Email { get; set; }

        // İlişkisel özellik
        public required List<Appointment> Appointments { get; set; }
    }

}
