﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sistema_ArgenMotos.DTOs;
using Sistema_ArgenMotos.Entidades;
using Sistema_ArgenMotos.Enums;

namespace Sistema_ArgenMotos.Services
{
    public class CobranzaService : ICobranzaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CobranzaService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Obtener todas las cobranzas
        public async Task<IEnumerable<CobranzaDTO>> GetAllAsync()
        {
            var cobranzas = await _context.Cobranzas
                .Include(c => c.Factura) // Si quieres incluir información de la factura relacionada
                .ToListAsync();

            return _mapper.Map<IEnumerable<CobranzaDTO>>(cobranzas);
        }

        public async Task<IEnumerable<CobranzaDTO>> GetFilteredAsync(
            MetodoPago? metodoPago,
            decimal? montoMinimo,
            decimal? montoMaximo,
            DateTime? fechaCobranzaMinima,
            DateTime? fechaCobranzaMaxima,
            int pageNumber,
            int pageSize)
        {
            var query = _context.Cobranzas.AsQueryable();

            // Aplicar filtros
            if (metodoPago.HasValue)
                query = query.Where(c => c.MetodoPago == metodoPago.Value);

            if (montoMinimo.HasValue)
                query = query.Where(c => c.MontoTotal >= montoMinimo.Value);

            if (montoMaximo.HasValue)
                query = query.Where(c => c.MontoTotal <= montoMaximo.Value);

            if (fechaCobranzaMinima.HasValue)
                query = query.Where(c => c.FechaCobranza >= fechaCobranzaMinima.Value);

            if (fechaCobranzaMaxima.HasValue)
                query = query.Where(c => c.FechaCobranza <= fechaCobranzaMaxima.Value);

            // Aplicar paginación
            var cobranzas = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CobranzaDTO>>(cobranzas);
        }

        // Obtener una cobranza por ID
        public async Task<CobranzaDTO> GetByIdAsync(int id)
        {
            var cobranza = await _context.Cobranzas
                .Include(c => c.Factura) // Si necesitas la factura
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cobranza == null)
            {
                throw new Exception("Cobranza no encontrada");
            }

            return _mapper.Map<CobranzaDTO>(cobranza);
        }

        // Crear una nueva cobranza
        public async Task<CobranzaDTO> CreateAsync(CobranzaCreateUpdateDTO cobranzaDTO)
        {
            var cobranza = _mapper.Map<Cobranza>(cobranzaDTO);

            // Verificar si la factura relacionada existe
            var factura = await _context.Facturas.FindAsync(cobranzaDTO.FacturaId);
            if (factura == null)
            {
                throw new Exception($"Factura con ID {cobranzaDTO.FacturaId} no encontrada");
            }
            cobranza.MontoTotal = factura.PrecioFinal;

            var newCobranza = _context.Cobranzas.Add(cobranza);
            await _context.SaveChangesAsync();

            return _mapper.Map<CobranzaDTO>(newCobranza.Entity);
        }

        // Actualizar una cobranza existente
        public async Task<CobranzaDTO> UpdateAsync(int id, CobranzaCreateUpdateDTO cobranzaDTO)
        {
            var cobranza = await _context.Cobranzas
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cobranza == null)
            {
                throw new Exception("Cobranza no encontrada");
            }

            // Mapear los cambios del DTO a la entidad existente
            _mapper.Map(cobranzaDTO, cobranza);

            // Verificar si la factura relacionada existe
            var factura = await _context.Facturas.FindAsync(cobranzaDTO.FacturaId);
            if (factura == null)
            {
                throw new Exception($"Factura con ID {cobranzaDTO.FacturaId} no encontrada");
            }

            var updatedCobranza = _context.Cobranzas.Update(cobranza);
            await _context.SaveChangesAsync();

            return _mapper.Map<CobranzaDTO>(updatedCobranza.Entity);
        }

        // Eliminar una cobranza por ID
        public async Task DeleteAsync(int id)
        {
            var cobranza = await _context.Cobranzas
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cobranza == null)
            {
                throw new Exception("Cobranza no encontrada");
            }

            _context.Cobranzas.Remove(cobranza);
            await _context.SaveChangesAsync();
        }
    }
}
