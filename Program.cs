using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sistema_ArgenMotos.Services;
using Sistema_ArgenMotos.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Añadir Controllers
builder.Services.AddControllers();

// Añadir Services
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IArticuloService, ArticuloService>();
builder.Services.AddScoped<IOrdenDeCompraService, OrdenDeCompraService>();
builder.Services.AddScoped<IVendedorService, VendedorService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<ICobranzaService, CobranzaService>();
builder.Services.AddScoped<IOtroComprobanteService, OtroComprobanteService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
// Agrega los servicios de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("angularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Cambia esto por el origen permitido
               .SetIsOriginAllowedToAllowWildcardSubdomains()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// cors
app.UseCors("angularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

