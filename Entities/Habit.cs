namespace ProgressFlow.Entities
{
    public class Habit
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required Frequency Frequency { get; set; }
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastUpdatedAtUtc { get; set; }
        public bool IsActive { get; set; }
        public List<Streak> Streaks { get; set; } = new();
        public List<HabitLog> HabitLogs { get; set; } = new();
    }
}
