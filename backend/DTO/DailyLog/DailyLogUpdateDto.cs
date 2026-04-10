using System.ComponentModel.DataAnnotations;

namespace backend.DTO
{
    public class UpdateDailyLogDto
    {
        [Required]
        public bool IsCompleted { get; set; } = false;
        public int HabitId { get; set; }
        
    }
}