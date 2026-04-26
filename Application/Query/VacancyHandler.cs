using Application.InterfaceRepository;
using Domain.Entity;
using MediatR;

namespace Application.Query
{
    public record GetVacanciesQuery() : IRequest<IEnumerable<Vacancy>>;

    public class VacancyHandler : IRequestHandler<GetVacanciesQuery, IEnumerable<Vacancy>>
    {
        private readonly IRepository<Vacancy> _repository;

        public VacancyHandler(IRepository<Vacancy> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Vacancy>> Handle(GetVacanciesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
