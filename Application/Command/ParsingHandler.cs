using Application.DTO;
using Application.InterfaceRepository;
using Application.IService;
using Domain.Entity;
using MediatR;

namespace Application
{
    internal static class VacancyMappingExtensions
    {
        internal static Vacancy MapToVacancy(this VacancyDTO vacancy)
        {
            return new Vacancy
            {
                Title = vacancy.Title,
                Description = vacancy.Description
            };
        }
    }
}

namespace Application.Command
{
    public record ParsingHandler(string url) : IRequest<VacancyDTO?>;

    public class ParsingAppHandler : IRequestHandler<ParsingHandler, VacancyDTO?>
    {
        private readonly IVacancyRepository _Repository;
        private readonly IParsingService _Service;

        public ParsingAppHandler(IVacancyRepository repository, IParsingService service)
        {
            _Repository = repository;
            _Service = service;
        }

        public async Task<VacancyDTO?> Handle(ParsingHandler request, CancellationToken cancellationToken)
        {
            VacancyDTO? vacancy = await _Service.ParsingUrl(request.url);

            if (vacancy != null)
            {
                await _Repository.AddAsync(vacancy.MapToVacancy(), cancellationToken);
            }
                return vacancy;
         }
    }
}
