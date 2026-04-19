using Domain.Entity;

namespace Application.InterfaceRepository
{
    public interface IVacancyRepository
    {
        Task AddAsync(Vacancy vacancy, CancellationToken ct);

        Task<Vacancy?> GetByIdAsync(int id);

        Task<IEnumerable<Vacancy>> GetAllAsync(CancellationToken ct);
    }
}
