using System.ComponentModel.DataAnnotations;

namespace Sistema_ArgenMotos.Entidades
{
    public class OrdenDeCompra_Articulo
    {
        [Key]
        public int OrdenDeCompraId { get; set; }
        public OrdenDeCompra OrdenDeCompra { get; set; }

        [Key]
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal PrecioUnitario { get; set; }
    }
}
