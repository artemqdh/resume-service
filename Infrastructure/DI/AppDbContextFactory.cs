using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.DI
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // Эта строка используется только ПРИ СОЗДАНИИ миграции (дизайн-тайм)
            optionsBuilder.UseNpgsql("Host=localhost;Database=temp");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
