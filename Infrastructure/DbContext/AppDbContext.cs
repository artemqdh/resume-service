using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        // Конструктор принимает настройки (включая строку подключения) из DI
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

       DbSet<Vacancy> Vacancies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
