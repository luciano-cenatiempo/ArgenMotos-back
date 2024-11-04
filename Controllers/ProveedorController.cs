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
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService service)
        {
            _proveedorService = service;
        }

        [HttpGet]
        public async Task<ActionResult<ProveedorDTO>> Get()
        {
            var proveedores = await _proveedorService.GetAllAsync();
            return Ok(proveedores);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ProveedorDTO>>> Get(
        //    [FromQuery] string? nombre,
        //    [FromQuery] string? cuil,
        //    [FromQuery] EstadoProveedor? estado,
        //    [FromQuery] int? pageNumber = 1,
        //    [FromQuery] int? pageSize = 10)
        //{
        //    var proveedores = await _proveedorService.GetFilteredAsync(nombre, cuil, estado, pageNumber, pageSize);
        //    return Ok(proveedores);
    


        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorDTO>> Get(int id)
        {
            var proveedor = await _proveedorService.GetByIdAsync(id);
            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<ActionResult<ProveedorDTO>> Create([FromBody] ProveedorCreateUpdateDTO proveedorCreateDto)
        {
            var proveedor = await _proveedorService.CreateAsync(proveedorCreateDto);
            return CreatedAtAction(nameof(Get), new { id = proveedor.Id }, proveedor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProveedorDTO>> Update(int id, [FromBody] ProveedorCreateUpdateDTO proveedorUpdateDto)
        {
            var proveedor = await _proveedorService.UpdateAsync(id, proveedorUpdateDto);
            return Ok(proveedor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resp =await _proveedorService.DeleteAsync(id);
            return Ok(resp);
        }
    }
}