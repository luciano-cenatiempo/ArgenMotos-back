using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_ArgenMotos.DTOs;
using Sistema_ArgenMotos.Enums;
using Sistema_ArgenMotos.Services;

namespace Sistema_ArgenMotos.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorService _vendedorService;

        public VendedorController(IVendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendedorDTO>>> Get()
        {
            var vendedores = await _vendedorService.GetAllAsync();
            return Ok(vendedores);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<VendedorDTO>>> Get(
        //    [FromQuery] string dni,
        //    [FromQuery] string nombre,
        //    [FromQuery] string apellido,
        //    [FromQuery] EstadoVendedor? estado,
        //    [FromQuery] int pageNumber = 1,
        //    [FromQuery] int pageSize = 10)
        //{
        //    var vendedores = await _vendedorService.GetFilteredAsync(dni, nombre, apellido, estado, pageNumber, pageSize);
        //    return Ok(vendedores);
        //}


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var vendedor = await _vendedorService.GetByIdAsync(id);
            if (vendedor == null) return NotFound();
            return Ok(vendedor);
        }

        [HttpPost]
        public async Task<ActionResult<VendedorDTO>> Create(VendedorCreateUpdateDTO vendedorDTO)
        {
            var vendedor = await _vendedorService.AddAsync(vendedorDTO);
            return CreatedAtAction(nameof(GetById), new { id = vendedor.Id }, vendedor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VendedorDTO>> Update(int id, VendedorCreateUpdateDTO vendedorDTO)
        {
            var vendedor = await _vendedorService.UpdateAsync(id, vendedorDTO);
            return Ok(vendedor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await _vendedorService.DeleteAsync(id);
            return Ok(resp);
        }
    }
}
