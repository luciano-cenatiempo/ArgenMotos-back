using System.ComponentModel.DataAnnotations;

namespace Sistema_ArgenMotos.Entidades
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio final debe ser un valor positivo")]
        public decimal PrecioFinal { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        public ICollection<Factura_Articulo> Articulos { get; set; }
    }
}
