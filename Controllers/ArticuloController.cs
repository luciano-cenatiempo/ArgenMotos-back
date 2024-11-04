using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_ArgenMotos.DTOs;
using Sistema_ArgenMotos.Services;

namespace Sistema_ArgenMotos.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloDTO>>> Get()
        {
            var articulos = await _articuloService.GetAllAsync();
            return Ok(articulos);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ArticuloDTO>>> Get(
        //   [FromQuery] string? nombre,
        //   [FromQuery] string? marca,
        //   [FromQuery] string? anno,
        //   [FromQuery] string? descripcion,
        //   [FromQuery] int pageNumber = 1,
        //   [FromQuery] int pageSize = 10)
        //{
        //    var articulos = await _articuloService.GetFilteredAsync(nombre, marca, anno, descripcion, pageNumber, pageSize);
        //    return Ok(articulos);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloDTO>> Get(int id)
        {
            var articulo = await _articuloService.GetByIdAsync(id);
            return Ok(articulo);
        }

        [HttpPost]
        public async Task<ActionResult<ArticuloDTO>> Create([FromBody] ArticuloCreateUpdateDTO articuloCreateDto)
        {
            var articulo = await _articuloService.AddAsync(articuloCreateDto);
            return CreatedAtAction(nameof(Get), new { id = articulo.Id }, articulo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArticuloDTO>> Update(int id, [FromBody] ArticuloCreateUpdateDTO articuloUpdateDto)
        {
            Console.WriteLine(articuloUpdateDto.ToString());
            Console.WriteLine(id);
            var articulo = await _articuloService.UpdateAsync(id, articuloUpdateDto);
            return Ok(articulo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await _articuloService.DeleteAsync(id);
            return Ok(resp);
        }
    }
}