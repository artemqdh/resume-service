using Domain.Entity;

namespace Application.InterfaceRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity vacancy, CancellationToken ct);

        Task<TEntity?> GetByIdAsync(int id, CancellationToken ct);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
    }
}
