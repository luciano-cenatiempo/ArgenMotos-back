using Sistema_ArgenMotos.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sistema_ArgenMotos.DTOs
{
    public class OtroComprobanteCreateDTO
    { 
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El monto es obligatorio")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "El ID del cliente es obligatorio")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El ID del vendedor es obligatorio")]
        public int VendedorId { get; set; }
        [Required(ErrorMessage = "El ID de la factura es obligatorio")]
        public int FacturaId { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string descripcion { get; set; }
        [Required(ErrorMessage = "El tipo de comprobante es obligatorio")]
        public ComprobanteTipo tipo { get; set; }

    }
}
