using Asp_Servicios.Controllers;
using Repositorio.Implementaciones;
using Repositorio.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Asp_Servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => {
                x.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();

            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            services.AddScoped<IRepuestosAplicacion, RepuestosAplicacion>();
            services.AddScoped<IMotosAplicacion, MotosAplicacion>();
            services.AddScoped<IComprasAplicacion, ComprasAplicacion>();
            services.AddScoped<IDetalle_ComprasAplicacion, Detalle_ComprasAplicacion>();
            services.AddScoped<IDetalle_VentasAplicacion, Detalle_VentasAplicacion>();
            services.AddScoped<IRepuestosAplicacion, RepuestosAplicacion>();
            services.AddScoped<IMarcasAplicacion, MarcasAplicacion>();
            services.AddScoped<IModelosAplicacion, ModelosAplicacion>();
            services.AddScoped<IMotosAplicacion, MotosAplicacion>();
            services.AddScoped<IOrden_ServiciosAplicacion, Orden_ServiciosAplicacion>();
            services.AddScoped<IPagosAplicacion,PagosAplicacion>();
            services.AddScoped<IProveedoresAplicacion,ProveedoresAplicacion>();
            services.AddScoped<IRepuestosAplicacion, RepuestosAplicacion>();
            services.AddScoped<IServiciosAplicacion, ServiciosAplicacion>();
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
            services.AddScoped<IVentasAplicacion, VentasAplicacion>();
            services.AddScoped<TokenAplicacion, TokenAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}