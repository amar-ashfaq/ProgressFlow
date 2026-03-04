using ProgressFlow.Entities;

namespace ProgressFlow.Repositories.Interfaces
{
    public interface IHabitRepository
    {
        Task<Habit?> GetHabitByIdAsync(int id);
        Task<List<Habit>> GetAllHabitsByUserIdAsync(int userId);
        Task<Habit> CreateHabitAsync(Habit habit);
        Task UpdateHabitAsync(Habit habit);
        Task DeleteHabitByIdAsync(int id);
    }
}
