using Microsoft.AspNetCore.Mvc;
using Sebrae.Services.Service;

namespace Sebrae.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViaCepController : Controller
    {
        private readonly ILogger<ViaCepController> _logger;
        private readonly IViaCepService _viaCepService;

        public ViaCepController(ILogger<ViaCepController> logger, IViaCepService viaCepService)
        {
            _logger = logger;
            _viaCepService = viaCepService;
        }

        [HttpGet("{zipCode}")]
        public async Task<IActionResult> GetZipCodeInformation(string zipCode)
        {
            var result = await _viaCepService.GetZipCodeInformation(zipCode);

            if(result.IsSuccessStatusCode) 
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest("Erro ao obter dados de CEP");
            }
        }
    }
}
