using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sistema_ArgenMotos.DTOs;
using Sistema_ArgenMotos.Entidades;
using Sistema_ArgenMotos.Enums;

namespace Sistema_ArgenMotos.Services
{
    public class VendedorService : IVendedorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VendedorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VendedorDTO>> GetAllAsync()
        {
            var vendedores = await _context.Vendedores.ToListAsync();
            return _mapper.Map<IEnumerable<VendedorDTO>>(vendedores);
        }

        public async Task<IEnumerable<VendedorDTO>> GetFilteredAsync(
            string dni,
            string nombre,
            string apellido,
            EstadoVendedor? estado,
            int pageNumber,
            int pageSize)
        {
            var query = _context.Vendedores.AsQueryable();

            // Aplicar filtros
            if (!string.IsNullOrEmpty(dni))
                query = query.Where(v => v.DNI.Contains(dni));

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(v => v.Nombre.Contains(nombre));

            if (!string.IsNullOrEmpty(apellido))
                query = query.Where(v => v.Apellido.Contains(apellido));

            if (estado.HasValue)
            {
                query = query.Where(v => v.Estado == estado);
            }

            // Aplicar paginación
            var vendedores = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return _mapper.Map<IEnumerable<VendedorDTO>>(vendedores);
        }


        public async Task<VendedorDTO> GetByIdAsync(int id)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);

            if (vendedor == null)
            {
                throw new Exception("Vendedor not found");
            }

            return _mapper.Map<VendedorDTO>(vendedor);
        }

        public async Task<VendedorDTO> AddAsync(VendedorCreateUpdateDTO vendedorDTO)
        {
            var vendedor = _mapper.Map<Vendedor>(vendedorDTO);
            var newVendedor = _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();

            return _mapper.Map<VendedorDTO>(newVendedor.Entity);
        }

        public async Task<VendedorDTO> UpdateAsync(int id, VendedorCreateUpdateDTO vendedorDTO)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);

            if (vendedor == null)
            {
                throw new Exception("Vendedor not found");
            }

            _mapper.Map(vendedorDTO, vendedor);
            var updatedVendedor = _context.Vendedores.Update(vendedor);
            await _context.SaveChangesAsync();

            return _mapper.Map<VendedorDTO>(updatedVendedor.Entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var vendedor = await _context.Vendedores.FindAsync(id);

                if (vendedor == null)
                {
                    throw new Exception("Vendedor con id "+id +" no encontrado");
                }

                _context.Vendedores.Remove(vendedor);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception exc)
            {
                Console.WriteLine(exc.ToString());
                return false;
            }
        }
    }
}
