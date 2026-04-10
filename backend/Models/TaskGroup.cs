using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class TaskGroup
    {
        [Key]
        public int GroupId { get; set; }
        
        [Required]
        public string GroupName { get; set; } = string.Empty;
        
        public string GroupColor { get; set; } = string.Empty;

        // --- RELASI (FOREIGN KEY) KE TABEL USER ---
        // Ini memastikan grup "Office Project" milikmu tidak akan tercampur dengan milik user lain
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User? User { get; set; } 
    }
}