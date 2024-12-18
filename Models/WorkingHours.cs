using System.ComponentModel.DataAnnotations;

namespace web_proje.Models
{
    public class WorkingHours
    {
        public int Id { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public bool IsWorkingDay { get; set; } = true;
    }
}
