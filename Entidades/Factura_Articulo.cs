using System.ComponentModel.DataAnnotations;

namespace Sistema_ArgenMotos.Entidades
{
    public class Factura_Articulo
    {
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }

        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PrecioUnitario { get; set; }
    }
}
