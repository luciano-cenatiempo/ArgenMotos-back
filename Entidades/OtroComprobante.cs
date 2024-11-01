using System.ComponentModel.DataAnnotations;
using Sistema_ArgenMotos.Enums;

namespace Sistema_ArgenMotos.Entidades
{
    public class OtroComprobante
    {
    
            [Key]
            public int Id { get; set; }

            [Required]
            public DateTime Fecha { get; set; }

            [Required]
            [Range(0, double.MaxValue, ErrorMessage = "El precio final debe ser un valor positivo")]
            public decimal Monto { get; set; }

            [Required]
            public int ClienteId { get; set; }
            public Cliente Cliente { get; set; }

            [Required]
            public int VendedorId { get; set; }
            public Vendedor Vendedor { get; set; }

            [Required]
            public int FacturaId { get; set; }
            public Factura Factura { get; set; }

            [Required]
            public string descripcion { get; set; }

            public ComprobanteTipo tipo { get; set; }

            
       
    }
}
