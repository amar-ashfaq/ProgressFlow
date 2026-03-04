namespace ProgressFlow.Entities
{
    public class HabitLog
    {
        public int Id { get; set; }
        public Habit? Habit { get; set; }
        public int HabitId { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public string? Notes { get; set; }
    }
}
