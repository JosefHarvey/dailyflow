using System.ComponentModel.DataAnnotations;


namespace backend.DTO
{
    public class CreateHabitDto
    {
        [Required]
        public string HabitName {get;set;} = string.Empty;
        public TimeSpan? ReminderTime {get;set;}
        public int GroupId { get; set; }
    }
}