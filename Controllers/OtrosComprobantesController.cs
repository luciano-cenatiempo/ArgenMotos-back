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
    public class OtrosComprobantesController : ControllerBase
    {
        private readonly IOtroComprobanteService _comprobanteService;

        public OtrosComprobantesController(IOtroComprobanteService comprobanteService)
        {
            _comprobanteService = comprobanteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtroComprobanteDTO>>> Get()
        {
            var comprobantes = await _comprobanteService.GetAllAsync();
            return Ok(comprobantes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OtroComprobanteDTO>> GetById(int id)
        {
            var comprobante = _comprobanteService.GetByIdAsync(id);
            return Ok(comprobante);
        }

        [HttpPost]
        public async Task<ActionResult<ArticuloDTO>> Create([FromBody] OtroComprobanteCreateDTO comprobanteCreateDTO)
        {
            var comprobante = await _comprobanteService.CreateAsync(comprobanteCreateDTO);
            return CreatedAtAction(nameof(Get), new { id = comprobante.Id }, comprobante);
        }
    }
}
