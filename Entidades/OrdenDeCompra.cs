using System.ComponentModel.DataAnnotations;

namespace Sistema_ArgenMotos.Entidades
{
    public class OrdenDeCompra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PrecioTotal { get; set; }

        [Required]
        public EstadoOrdenDeCompra Estado { get; set; } = EstadoOrdenDeCompra.Pendiente;

        [Required]
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public ICollection<OrdenDeCompra_Articulo> Articulos { get; set; }
    }
}
