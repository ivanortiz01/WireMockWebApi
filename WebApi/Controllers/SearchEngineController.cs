using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchEngineController : ControllerBase
    {
        private readonly ISearchEngineService _searchEngineService;
        private readonly ILogger<SearchEngineController> _logger;

        public SearchEngineController(ISearchEngineService searchEngineService, ILogger<SearchEngineController> logger)
        {
            _searchEngineService = searchEngineService;
            _logger = logger;
            _logger.LogCritical("Log Critical SearchEngineController");
        }

        [HttpGet("{queryEntry}", Name = "GetNumberOfCharacters")] // http://localhost:61712/api/searchengine/daan
        public async Task<ActionResult<int>> GetNumberOfCharacters(string queryEntry)
        {
            var numberOfCharacters = await _searchEngineService.GetNumberOfCharactersFromSearchQuery(queryEntry);
            return Ok(numberOfCharacters);
        }
    }
}
