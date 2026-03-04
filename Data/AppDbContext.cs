using Microsoft.EntityFrameworkCore;
using ProgressFlow.Entities;

namespace ProgressFlow.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitLog> HabitLogs { get; set; }
        public DbSet<Streak> Streaks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PasswordHash)
                    .IsRequired();

                entity.Property(e => e.PasswordSalt)
                    .IsRequired();

                entity.Property(e => e.Role)
                    .HasConversion<string>()
                    .HasDefaultValue(UserRole.User);

                entity.HasIndex(e => e.Username)
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.CreatedAtUtc)
                    .HasDefaultValueSql("GETUTCDATE()");  
            });

            modelBuilder.Entity<Habit>(entity => 
            { 
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);

                entity.Property(e => e.CreatedAtUtc)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.Frequency)
                    .IsRequired()
                    .HasDefaultValue(Frequency.Daily);
            });

            modelBuilder.Entity<HabitLog>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(h => h.Notes)
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedAtUtc)
                    .HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<Streak>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.StartDate)
                    .HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<Habit>()
                .HasOne(h => h.User)
                .WithMany(u => u.Habits)
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HabitLog>()
                .HasOne(h => h.Habit)
                .WithMany(h => h.HabitLogs)
                .HasForeignKey(h => h.HabitId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Streak>()
                .HasOne(h => h.Habit)
                .WithMany(h => h.Streaks)
                .HasForeignKey(h => h.HabitId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
