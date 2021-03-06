using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class SearchEngineService : ISearchEngineService
    {
        private readonly HttpClient _httpClient;

        public SearchEngineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetNumberOfCharactersFromSearchQuery(string toSearchFor)
        {
            var result = await _httpClient.GetAsync($"/search?q={toSearchFor}");
            var content = await result.Content.ReadAsStringAsync();
            return content.Length;
        }
    }
}
