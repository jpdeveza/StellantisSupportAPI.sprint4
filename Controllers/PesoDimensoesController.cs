using StellantisSupportAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellantisSupportAPI.repository;

namespace StellantisSupportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PesoDimensoesController : ControllerBase
    {
        private readonly PesoDimensoesRepository _repository;

        public PesoDimensoesController(PesoDimensoesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<PesoDimensoes>> CreatePesoDimensoes(PesoDimensoes pesoDimensoes)
        {
            var createdPesoDimensoes = await _repository.CreatePesoDimensoes(pesoDimensoes);
            return CreatedAtAction(nameof(GetPesoDimensoesById), new { id = createdPesoDimensoes.Id }, createdPesoDimensoes);
        }

        [HttpGet]
        public async Task<IEnumerable<PesoDimensoes>> GetPesoDimensoes()
        {
            return await _repository.GetPesoDimensoes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PesoDimensoes>> GetPesoDimensoesById(int id)
        {
            var pesoDimensoes = await _repository.GetPesoDimensoesById(id);
            if (pesoDimensoes == null)
            {
                return NotFound();
            }

            return pesoDimensoes;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePesoDimensoes(int id, PesoDimensoes pesoDimensoes)
        {
            if (id != pesoDimensoes.Id)
            {
                return BadRequest();
            }

            await _repository.UpdatePesoDimensoes(pesoDimensoes);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePesoDimensoes(int id)
        {
            var deleted = await _repository.DeletePesoDimensoes(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
