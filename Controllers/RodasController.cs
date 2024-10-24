using StellantisSupportAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellantisSupportAPI.repository;

namespace StellantisSupportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RodasController : ControllerBase
    {
        private readonly RodasRepository _repository;

        public RodasController(RodasRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Rodas>> CreateRodas(Rodas rodas)
        {
            var createdRodas = await _repository.CreateRodas(rodas);
            return CreatedAtAction(nameof(GetRodasById), new { id = createdRodas.Id }, createdRodas);
        }

        [HttpGet]
        public async Task<IEnumerable<Rodas>> GetRodas()
        {
            return await _repository.GetRodas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rodas>> GetRodasById(int id)
        {
            var rodas = await _repository.GetRodasById(id);
            if (rodas == null)
            {
                return NotFound();
            }

            return rodas;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRodas(int id, Rodas rodas)
        {
            if (id != rodas.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateRodas(rodas);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRodas(int id)
        {
            var deleted = await _repository.DeleteRodas(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
