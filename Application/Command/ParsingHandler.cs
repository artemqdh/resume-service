using Application.InterfaceRepository;
using Application.IService;
using Domain.Entity;
using MediatR;

namespace Application.Command
{
    public record ParsingHandler(string url) : IRequest<Vacancy?>;

    public class ParsingAppHandler : IRequestHandler<ParsingHandler, Vacancy?>
    {
        private readonly IVacancyRepository _Repository;
        private readonly IParsingService _Service;

        public ParsingAppHandler(IVacancyRepository repository, IParsingService service)
        {
            _Repository = repository;
            _Service = service;
        }

        public async Task<Vacancy?> Handle(ParsingHandler request, CancellationToken cancellationToken)
        {
            Vacancy? vacancy = await _Service.ParsingUrl(request.url);

            if (vacancy != null)
            {
                await _Repository.AddAsync(vacancy, cancellationToken);
            }
                return vacancy;
         }
    }
}
