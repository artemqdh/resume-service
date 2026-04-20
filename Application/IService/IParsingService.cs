using Application.DTO;
using Domain.Entity;

namespace Application.IService
{
    public interface IParsingService
    {
        Task<VacancyDTO?> ParsingUrl(string url);
    }
}
