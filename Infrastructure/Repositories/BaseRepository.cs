using System.Data;
using Application.InterfaceRepository;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _db; //EF
        protected readonly IDbConnection _connection; //Dupper

        //
        //
        //
        public BaseRepository(AppDbContext db, IDbConnection connection)
        {
            _db = db;
            _connection = connection;
        }

        public async Task AddAsync(TEntity entity, CancellationToken ct)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            var gym = await _db.Set<TEntity>().FindAsync(id);
            if (gym == null) return false;

            _db.Set<TEntity>().Remove(gym);
            await _db.SaveChangesAsync(ct);
            return true;
        }

        public abstract Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct);
        public abstract Task<TEntity?> GetByIdAsync(int id, CancellationToken ct);
    }
}
