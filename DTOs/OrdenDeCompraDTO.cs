using Sistema_ArgenMotos.Entidades;

namespace Sistema_ArgenMotos.DTOs
{
    public class OrdenDeCompraDTO
    {
        public int OrdenDeCompraId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioTotal { get; set; }
        public EstadoOrdenDeCompra Estado { get; set; }
        public int ProveedorId { get; set; }
        public List<OrdenDeCompraArticuloDTO> Articulos { get; set; }
    }

    public class OrdenDeCompraArticuloDTO
    {
        public int ArticuloId { get; set; }
        public ArticuloDTO Articulo { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }    }
}
