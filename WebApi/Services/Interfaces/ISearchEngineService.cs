using System.Threading.Tasks;

namespace WebApi.Services.Interfaces
{
    public interface ISearchEngineService
    {
        Task<int> GetNumberOfCharactersFromSearchQuery(string toSearchFor);
    }
}
