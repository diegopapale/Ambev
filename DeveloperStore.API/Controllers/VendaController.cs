using DeveloperStore.Application.DTOs;
using DeveloperStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.API.Controllers
{
    [ApiController]
    [Route("api/v1/vendas")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendaById(Guid id)
        {
            var venda = await _vendaService.GetVendaByIdAsync(id);
            if (venda == null)
                return NotFound("Venda não encontrada.");

            return Ok(venda);
        }

        // POST: api/v1/vendas
        [HttpPost]
        public async Task<IActionResult> CreateVenda([FromBody] VendaDTO vendaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdVenda = await _vendaService.CreateVendaAsync(vendaDto);
            return CreatedAtAction(nameof(GetVendaById), new { id = createdVenda.NumeroVenda }, createdVenda);
        }

        // PUT: api/v1/vendas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenda(Guid id, [FromBody] VendaDTO vendaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedVenda = await _vendaService.UpdateVendaAsync(id, vendaDto);
            if (updatedVenda == null)
                return NotFound("Venda não encontrada para atualização.");

            return Ok(updatedVenda);
        }

        // DELETE: api/v1/vendas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(Guid id)
        {
            var deleted = await _vendaService.DeleteVendaAsync(id);
            if (!deleted)
                return NotFound("Venda não encontrada para exclusão.");

            return NoContent();
        }
    }
}