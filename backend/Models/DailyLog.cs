using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class DailyLog
    {
        [Key]
        public int LogId { get; set; }

        public bool IsCompleted { get; set; } = false;

        // Menyimpan tanggal log (Otomatis mengambil tanggal hari ini saat dibuat)
        public DateTime LogDate { get; set; } = DateTime.UtcNow.Date;

        // Boleh kosong (nullable pakai tanda '?'), akan terisi jam saat user klik centang
        public DateTime? CompletedAt { get; set; } 

        // --- RELASI (FOREIGN KEY) KE TABEL HABIT ---
        // Ini memastikan log centang ini tahu milik tugas yang mana
        public int HabitId { get; set; }

        [ForeignKey("HabitId")]
        public Habit? Habit { get; set; }
    }
}