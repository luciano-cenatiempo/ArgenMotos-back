using Sistema_ArgenMotos.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sistema_ArgenMotos.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string DNI { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [Required]
        public TipoCliente Tipo { get; set; }

        [Phone]
        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Domicilio { get; set; }

        [Required]
        public EstadoCliente Estado { get; set; } = EstadoCliente.Activo;
    }
}
