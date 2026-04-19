using System.Data;
using Application.InterfaceRepository;
using Dapper;
using Domain.Entity;

namespace Infrastructure.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly AppDbContext _db; //EF
        private readonly IDbConnection _connection; //Dupper

        //
        //
        //
        public VacancyRepository(AppDbContext db, IDbConnection connection)
        {
            _db = db;
            _connection = connection;
        }

        //добавляем\сохраняем
        public async Task AddAsync(Vacancy vacancy, CancellationToken ct)
        {
            await _db.AddAsync(vacancy);
            await _db.SaveChangesAsync(ct);
        }

        //получаем все
        public async Task<IEnumerable<Vacancy>> GetAllAsync(CancellationToken ct)
        {
            const string sql = "SELECT \"Id\", \"Title\", \"Description\", \"Location\", \"WorkSchedule\" FROM \"Vacancies\"";

            CommandDefinition query = new CommandDefinition(sql, cancellationToken: ct); //Token позволяет остановить выполнение запроса, если он больше не нужен

            return await _connection.QueryAsync<Vacancy>(query);
        }

        //получаем по id
        public async Task<Vacancy?> GetByIdAsync(int id)
        {
            const string sql = "SELECT \"Id\", \"Title\", \"Description\", \"Location\", \"WorkSchedule\" FROM \"Vacancies\" WHERE Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<Vacancy>(sql, new { Id = id });
        }
    }
}
