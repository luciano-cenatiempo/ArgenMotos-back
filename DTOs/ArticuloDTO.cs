namespace Sistema_ArgenMotos.DTOs
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioCompra { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Anno { get; set; }
    }
}
