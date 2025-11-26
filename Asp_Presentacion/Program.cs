using asp_presentacion;
using lib_presentaciones.Interfaces;
using lib_presentaciones.Implementaciones;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICargosPresentacion, CargosPresentacion>();
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IRepuestosPresentacion, RepuestosPresentacion>();
builder.Services.AddScoped<IMotosPresentacion, MotosPresentacion>();
builder.Services.AddScoped<IComprasPresentacion, ComprasPresentacion>();
builder.Services.AddScoped<IDetalle_ComprasPresentacion, Detalle_ComprasPresentacion>();
builder.Services.AddScoped<IDetalle_VentasPresentacion, Detalle_VentasPresentacion>();
builder.Services.AddScoped<IMarcasPresentacion, MarcasPresentacion>();
builder.Services.AddScoped<IModelosPresentacion, ModelosPresentacion>();
builder.Services.AddScoped<IOrden_ServiciosPresentacion, Orden_ServiciosPresentacion>();
builder.Services.AddScoped<IPagosPresentacion, PagosPresentacion>();
builder.Services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
builder.Services.AddScoped<IServiciosPresentacion, ServiciosPresentacion>();
builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
builder.Services.AddScoped<IVentasPresentacion, VentasPresentacion>();
builder.Services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
builder.Services.AddScoped<IDetalle_ComprasPresentacion, Detalle_ComprasPresentacion>();
builder.Services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);
app.Run();


