namespace ProgressFlow.Entities
{
    public class Streak
    {
        public int Id { get; set; }
        public Habit? Habit { get; set; }
        public int HabitId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Length { get; set; }
    }
}
