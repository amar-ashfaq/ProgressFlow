using Microsoft.EntityFrameworkCore;
using ProgressFlow.Data;
using ProgressFlow.Entities;
using ProgressFlow.Repositories.Interfaces;

namespace ProgressFlow.Repositories
{
    public class HabitRepository : IHabitRepository
    {
        private readonly AppDbContext _context;

        public HabitRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Habit>> GetAllHabitsByUserIdAsync(int userId)
        {
            var habits = await _context.Habits.Where(x => x.UserId == userId).ToListAsync();
            return habits;
        }

        public async Task<Habit?> GetHabitByIdAsync(int id)
        {
            var habit = await _context.Habits.FirstOrDefaultAsync(x => x.Id == id);
            return habit;
        }

        public async Task<Habit> CreateHabitAsync(Habit habit)
        {
            await _context.Habits.AddAsync(habit);
            await _context.SaveChangesAsync();
            return habit;
        }

        public async Task UpdateHabitAsync(Habit habit)
        {
            _context.Habits.Update(habit);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteHabitByIdAsync(int id)
        {
            var habit = await GetHabitByIdAsync(id);
            _context.Habits.Remove(habit);
            await _context.SaveChangesAsync();
        }
    }
}
