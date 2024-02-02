using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sebrae.Persistence;
using Sebrae.Services.Service;

namespace Sebrae.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContasController : Controller
    {
        private readonly IContasService _contasService;
        public ContasController(IContasService contasService) 
        {
            _contasService = contasService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContas()
        {
            var result = await _contasService.GetContas();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConta(int id)
        {
            var conta = await _contasService.GetContaById(id);

            if (conta == null)
            {
                return NotFound();
            }

            return Ok(conta);
        }

        [HttpPost]
        public async Task<IActionResult> PostConta(Conta conta)
        {
            await _contasService.CreateConta(conta);

            return CreatedAtAction(nameof(GetConta), new { id = conta.Id }, conta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConta(int id, Conta conta)
        {
            await _contasService.UpdateConta(conta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConta(int id)
        {
            await _contasService.DeleteConta(id);
            return NoContent();
        }
    }
}
