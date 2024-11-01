﻿using System.ComponentModel.DataAnnotations;

namespace Sistema_ArgenMotos.Entidades
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Descripcion { get; set; }

        [Range(0, int.MaxValue)]
        public int StockActual { get; set; }

        [Range(0, int.MaxValue)]
        public int StockMinimo { get; set; }

        [Range(0, int.MaxValue)]
        public int StockMaximo { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Precio { get; set; }

        [MaxLength(100)]
        public string Marca { get; set; }

        [MaxLength(100)]
        public string Modelo { get; set; }

        [MaxLength(4), RegularExpression(@"\d{4}")]
        public string Anno { get; set; }

        public ICollection<OrdenDeCompra_Articulo> OrdenDeCompra_Articulos { get; set; }
        public ICollection<Factura_Articulo> Factura_Articulos { get; set; }
    }
}
