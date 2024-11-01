using Microsoft.EntityFrameworkCore;
using Sistema_ArgenMotos.Entidades;
using Sistema_ArgenMotos.Enums;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Articulo> Articulos { get; set; }
    public DbSet<OrdenDeCompra> OrdenesDeCompra { get; set; }
    public DbSet<OrdenDeCompra_Articulo> OrdenDeCompra_Articulos { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<Factura_Articulo> Factura_Articulos { get; set; }
    public DbSet<Cobranza> Cobranzas { get; set; }
    public DbSet<OtroComprobante> OtroComprobante { get; set; }


    // Método para configurar el modelo
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrdenDeCompra_Articulo>()
            .HasKey(oc => new { oc.OrdenDeCompraId, oc.ArticuloId });

        modelBuilder.Entity<OrdenDeCompra_Articulo>()
            .HasOne(oc => oc.OrdenDeCompra)
            .WithMany(o => o.Articulos)
            .HasForeignKey(oc => oc.OrdenDeCompraId);

        modelBuilder.Entity<OrdenDeCompra_Articulo>()
            .HasOne(oc => oc.Articulo)
            .WithMany(a => a.OrdenDeCompra_Articulos)
            .HasForeignKey(oc => oc.ArticuloId);

        modelBuilder.Entity<Factura_Articulo>()
            .HasKey(fa => new { fa.FacturaId, fa.ArticuloId });

        modelBuilder.Entity<Factura_Articulo>()
            .HasOne(fa => fa.Factura)
            .WithMany(f => f.Articulos)
            .HasForeignKey(fa => fa.FacturaId);

        modelBuilder.Entity<Factura_Articulo>()
            .HasOne(fa => fa.Articulo)
            .WithMany(a => a.Factura_Articulos)
            .HasForeignKey(fa => fa.ArticuloId);
    }
}
