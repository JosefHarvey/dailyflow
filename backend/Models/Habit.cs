using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Habit
    {
        [Key]
        public int HabitId { get; set; }

        [Required]
        public string HabitName { get; set; } = string.Empty;

        // Menggunakan TimeSpan untuk menyimpan jam (misal: 06:00)
        public TimeSpan? ReminderTime { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // --- RELASI (FOREIGN KEY) KE TABEL TASKGROUP ---
        // Ini memastikan tugas "Baca Buku" tahu bahwa dia ada di folder "Daily Study"
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public TaskGroup? TaskGroup { get; set; }
    }
}