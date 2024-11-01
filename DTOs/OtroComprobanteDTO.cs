using Sistema_ArgenMotos.Enums;

namespace Sistema_ArgenMotos.DTOs
{
    public class OtroComprobanteDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public int FacturaId { get; set; }

        public string descripcion { get; set; }
        public ComprobanteTipo tipo { get; set; }


    }
}
