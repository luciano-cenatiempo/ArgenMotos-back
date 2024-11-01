namespace Sistema_ArgenMotos.DTOs
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioFinal { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public List<FacturaArticuloDTO> Articulos { get; set; }
    }

    public class FacturaArticuloDTO
    {
        public int ArticuloId { get; set; }
        public ArticuloDTO Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
