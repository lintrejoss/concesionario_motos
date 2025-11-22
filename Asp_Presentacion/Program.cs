using asp_presentacion;
using lib_presentaciones.Interfaces;
using lib_presentaciones.Implementaciones;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICargosPresentacion, CargosPresentacion>();

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);
app.Run();


