﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sistema_ArgenMotos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241103202607_agregaLogin")]
    partial class agregaLogin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Articulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Anno")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PrecioCompra")
                        .HasColumnType("numeric");

                    b.Property<int>("StockActual")
                        .HasColumnType("integer");

                    b.Property<int>("StockMaximo")
                        .HasColumnType("integer");

                    b.Property<int>("StockMinimo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Cobranza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FacturaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaCobranza")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MetodoPago")
                        .HasColumnType("integer");

                    b.Property<decimal>("MontoTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.ToTable("Cobranzas");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("PrecioFinal")
                        .HasColumnType("numeric");

                    b.Property<int>("VendedorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Factura_Articulo", b =>
                {
                    b.Property<int>("FacturaId")
                        .HasColumnType("integer");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("integer");

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("numeric");

                    b.HasKey("FacturaId", "ArticuloId");

                    b.HasIndex("ArticuloId");

                    b.ToTable("Factura_Articulos");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.OrdenDeCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("PrecioTotal")
                        .HasColumnType("numeric");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.ToTable("OrdenesDeCompra");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.OrdenDeCompra_Articulo", b =>
                {
                    b.Property<int>("OrdenDeCompraId")
                        .HasColumnType("integer");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("integer");

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("numeric");

                    b.HasKey("OrdenDeCompraId", "ArticuloId");

                    b.HasIndex("ArticuloId");

                    b.ToTable("OrdenDeCompra_Articulos");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.OtroComprobante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<int>("FacturaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Monto")
                        .HasColumnType("numeric");

                    b.Property<int>("VendedorId")
                        .HasColumnType("integer");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("tipo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FacturaId");

                    b.HasIndex("VendedorId");

                    b.ToTable("OtroComprobante");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CUIL")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UsuarioId"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("VendedorId")
                        .HasColumnType("integer");

                    b.HasKey("UsuarioId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Estado")
                        .HasMaxLength(20)
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Cobranza", b =>
                {
                    b.HasOne("Sistema_ArgenMotos.Entidades.Factura", "Factura")
                        .WithMany()
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Factura", b =>
                {
                    b.HasOne("Sistema_ArgenMotos.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_ArgenMotos.Entidades.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Factura_Articulo", b =>
                {
                    b.HasOne("Sistema_ArgenMotos.Entidades.Articulo", "Articulo")
                        .WithMany("Factura_Articulos")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_ArgenMotos.Entidades.Factura", "Factura")
                        .WithMany("Articulos")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Factura");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.OrdenDeCompra", b =>
                {
                    b.HasOne("Sistema_ArgenMotos.Entidades.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.OrdenDeCompra_Articulo", b =>
                {
                    b.HasOne("Sistema_ArgenMotos.Entidades.Articulo", "Articulo")
                        .WithMany("OrdenDeCompra_Articulos")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_ArgenMotos.Entidades.OrdenDeCompra", "OrdenDeCompra")
                        .WithMany("Articulos")
                        .HasForeignKey("OrdenDeCompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("OrdenDeCompra");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.OtroComprobante", b =>
                {
                    b.HasOne("Sistema_ArgenMotos.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_ArgenMotos.Entidades.Factura", "Factura")
                        .WithMany()
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_ArgenMotos.Entidades.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Factura");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Usuario", b =>
                {
                    b.HasOne("Sistema_ArgenMotos.Entidades.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Articulo", b =>
                {
                    b.Navigation("Factura_Articulos");

                    b.Navigation("OrdenDeCompra_Articulos");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.Factura", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("Sistema_ArgenMotos.Entidades.OrdenDeCompra", b =>
                {
                    b.Navigation("Articulos");
                });
#pragma warning restore 612, 618
        }
    }
}
