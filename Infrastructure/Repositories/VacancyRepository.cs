using System.Data;
using Dapper;
using Domain.Entity;

namespace Infrastructure.Repositories
{
    public class VacancyRepository : BaseRepository<Vacancy>
    {
        //
        //
        //
        public VacancyRepository(AppDbContext db, IDbConnection connection)
            : base(db, connection)
        {
        }

        //получаем все
        public override async Task<IEnumerable<Vacancy>> GetAllAsync(CancellationToken ct)
        {
            const string sql = "SELECT \"Id\", \"Title\", \"Description\", \"Location\", \"WorkSchedule\" FROM \"Vacancies\"";

            CommandDefinition query = new CommandDefinition(sql, cancellationToken: ct); //Token позволяет остановить выполнение запроса, если он больше не нужен

            return await _connection.QueryAsync<Vacancy>(query);
        }

        //получаем по id
        public override async Task<Vacancy?> GetByIdAsync(int id, CancellationToken ct)
        {
            const string sql = "SELECT \"Id\", \"Title\", \"Description\", \"Location\", \"WorkSchedule\" FROM \"Vacancies\" WHERE Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<Vacancy>(new CommandDefinition(sql, new { Id = id }, cancellationToken: ct));
        }
    }
}
