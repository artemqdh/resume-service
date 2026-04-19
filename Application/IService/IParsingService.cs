using Domain.Entity;

namespace Application.IService
{
    public interface IParsingService
    {
        Task<Vacancy?> ParsingUrl(string url);
    }
}
