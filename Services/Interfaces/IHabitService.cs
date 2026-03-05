using ProgressFlow.Entities;

namespace ProgressFlow.Services.Interfaces
{
    public interface IHabitService
    {
        Task<Habit> GetHabitByIdAsync(int id);
        Task<List<Habit>> GetAllHabitsByUserIdAsync(int userId);
        Task<Habit> CreateHabitAsync(Habit habit);
        Task UpdateHabitAsync(Habit habit);
        Task DeleteHabitByIdAsync(int id);
    }
}
