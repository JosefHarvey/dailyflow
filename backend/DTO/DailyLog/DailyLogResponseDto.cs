namespace backend.DTOs
{
    public class DailyLogResponseDto
    {
        public int LogId { get; set; }
        
        public bool IsCompleted { get; set; }
        
        public DateTime LogDate { get; set; }
        
        public DateTime? CompletedAt { get; set; }

        public int HabitId { get; set; }
        
        public string HabitName { get; set; } = string.Empty;
        public TimeSpan? ReminderTime { get; set; }
    }
}