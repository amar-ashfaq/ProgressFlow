using ProgressFlow.Entities;
using ProgressFlow.Repositories.Interfaces;
using ProgressFlow.Services.Interfaces;

namespace ProgressFlow.Services
{
    public class HabitService : IHabitService
    {
        private readonly IHabitRepository _habitRepository;

        public HabitService(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        public async Task<List<Habit>> GetAllHabitsByUserIdAsync(int userId)
        {
            return await _habitRepository.GetAllHabitsByUserIdAsync(userId);
        }

        public async Task<Habit> GetHabitByIdAsync(int id)
        {
            var habit = await _habitRepository.GetHabitByIdAsync(id);

            if (habit == null)
                throw new KeyNotFoundException($"Habit with id {id} could not be found");

            return habit;
        }

        public async Task<Habit> CreateHabitAsync(Habit _habit)
        {
            ArgumentNullException.ThrowIfNull(_habit);

            _habit.CreatedAtUtc = DateTime.UtcNow;
            _habit.LastUpdatedAtUtc = DateTime.UtcNow;
            _habit.IsActive = true;

            return await _habitRepository.CreateHabitAsync(_habit);
        }

        public async Task UpdateHabitAsync(Habit habit)
        {
            ArgumentNullException.ThrowIfNull(habit);

            habit.LastUpdatedAtUtc = DateTime.UtcNow;

            await _habitRepository.UpdateHabitAsync(habit);
        }

        public async Task DeleteHabitByIdAsync(int id)
        {
            var habit = await _habitRepository.GetHabitByIdAsync(id);

            if (habit == null)
                throw new KeyNotFoundException($"Habit with id {id} could not be found");

            await _habitRepository.DeleteHabitByIdAsync(id);
        }        
    }
}
