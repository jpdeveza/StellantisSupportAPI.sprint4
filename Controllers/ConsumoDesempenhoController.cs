using StellantisSupportAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellantisSupportAPI.repository;

namespace StellantisSupportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumoDesempenhoController : ControllerBase
    {
        private readonly ConsumoDesempenhoRepository _repository;

        public ConsumoDesempenhoController(ConsumoDesempenhoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<ConsumoDesempenho>> CreateConsumoDesempenho(ConsumoDesempenho consumoDesempenho)
        {
            var createdConsumoDesempenho = await _repository.CreateConsumoDesempenho(consumoDesempenho);
            return CreatedAtAction(nameof(GetConsumoDesempenho), new { id = createdConsumoDesempenho.Id }, createdConsumoDesempenho);
        }

        [HttpGet]
        public async Task<IEnumerable<ConsumoDesempenho>> GetConsumoDesempenhos()
        {
            return await _repository.GetConsumoDesempenhos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumoDesempenho>> GetConsumoDesempenho(int id)
        {
            var consumoDesempenho = await _repository.GetConsumoDesempenhoById(id);
            if (consumoDesempenho == null)
            {
                return NotFound();
            }

            return consumoDesempenho;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConsumoDesempenho(int id, ConsumoDesempenho consumoDesempenho)
        {
            if (id != consumoDesempenho.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateConsumoDesempenho(consumoDesempenho);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumoDesempenho(int id)
        {
            var deleted = await _repository.DeleteConsumoDesempenho(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
