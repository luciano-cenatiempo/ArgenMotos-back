using Sistema_ArgenMotos.DTOs;

namespace Sistema_ArgenMotos.Services
{
    public interface IOtroComprobanteService
    {
        Task<IEnumerable<OtroComprobanteDTO>> GetAllAsync();
        Task<OtroComprobanteDTO> GetByIdAsync(int id);
        Task<OtroComprobanteDTO> CreateAsync(OtroComprobanteCreateDTO comprobanteDTO);
    }
}
