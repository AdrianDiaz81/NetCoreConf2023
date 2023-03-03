using Microsoft.AspNetCore.Mvc;

namespace Avengers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestController : ControllerBase
    {

        private readonly ILogger<RestController> _logger;

        public RestController(ILogger<RestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            using var client = new HttpClient();
            var result = await client.GetFromJsonAsync<dynamic>("https://localhost:7225/api/avenger");
            return Ok(result);

        }

        [HttpGet("{id}", Name = "GetByIDAvengerGRPC")]
        public async Task<IActionResult> Get(int id)
        {
            using var client = new HttpClient();

            var result = await client.GetFromJsonAsync<dynamic>($"https://localhost:7225/api/avenger/{id}");

            return Ok(result);

        }
    }
}