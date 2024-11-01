using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sistema_ArgenMotos.DTOs;
using Sistema_ArgenMotos.Entidades;

namespace Sistema_ArgenMotos.Services

{
    public class OtroComprobanteService : IOtroComprobanteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OtroComprobanteService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OtroComprobanteDTO> CreateAsync(OtroComprobanteCreateDTO comprobanteDTO)
        {
            var comprobante = _mapper.Map<OtroComprobante>(comprobanteDTO);

            // Verificar si la factura relacionada existe
            try
            {
                var factura = await _context.Facturas.FindAsync(comprobanteDTO.FacturaId);
                if (factura == null)
                {
                    throw new Exception($"Factura con ID {comprobanteDTO.FacturaId} no encontrada");

                }


                var newComprobante = _context.OtroComprobante.Add(comprobante);
                await _context.SaveChangesAsync();

                return _mapper.Map<OtroComprobanteDTO>(newComprobante.Entity);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }

        public async Task<IEnumerable<OtroComprobanteDTO>> GetAllAsync()
        {
            var comprobantes = await _context.OtroComprobante.ToListAsync();
            return _mapper.Map<IEnumerable<OtroComprobanteDTO>>(comprobantes);
        }

        public async Task<OtroComprobanteDTO> GetByIdAsync(int id)
        {
            var comprobante = await _context.Cobranzas
                .FirstOrDefaultAsync(c => c.Id == id);
            try
            {
                if (comprobante == null)
                {
                    throw new Exception("Cobranza no encontrada");
                }
                return _mapper.Map<OtroComprobanteDTO>(comprobante);

            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }



            }
        }
    }
}
