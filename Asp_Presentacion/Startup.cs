using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
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
            // Presentaciones
            services.AddScoped<IConexion, Conexion>();
            services.AddScoped<IRepuestosPresentacion, RepuestosPresentacion>();
            services.AddScoped<IMotosPresentacion, MotosPresentacion>();
            services.AddScoped<IComprasPresentacion, ComprasPresentacion>();
            services.AddScoped<IDetalle_ComprasPresentacion, Detalle_ComprasPresentacion>();
            services.AddScoped<IDetalle_VentasPresentacion, Detalle_VentasPresentacion>();
            services.AddScoped<IRepuestosPresentacion, RepuestosPresentacion>();
            services.AddScoped<IMarcasPresentacion, MarcasPresentacion>();
            services.AddScoped<IModelosPresentacion, ModelosPresentacion>();
            services.AddScoped<IMotosPresentacion, MotosPresentacion>();
            services.AddScoped<IOrden_ServiciosPresentacion, Orden_ServiciosPresentacion>();
            services.AddScoped<IPagosPresentacion, PagosPresentacion>();
            services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
            services.AddScoped<IRepuestosPresentacion, RepuestosPresentacion>();
            services.AddScoped<IServiciosPresentacion, ServiciosPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
            services.AddScoped<IVentasPresentacion, VentasPresentacion>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}