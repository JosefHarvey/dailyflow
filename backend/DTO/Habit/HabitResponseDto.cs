namespace backend.DTO
{
    public class ResponseHabitDto
    {
        public int HabitId { get; set; }
        public string HabitName { get; set; } = string.Empty;

        public TimeSpan? ReminderTime { get; set; } 

       public int GroupId { get; set; }

        public string GroupName { get; set; } = string.Empty;
    }
}