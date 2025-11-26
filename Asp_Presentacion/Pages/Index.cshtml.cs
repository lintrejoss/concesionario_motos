using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Propiedad pública para enviar la lista a la vista
        public List<Cargos> Cargos { get; set; } = new List<Cargos>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // Handler que se ejecuta al hacer GET para cargar la lista
        public async Task OnGetAsync()
        {
            try
            {
                ICargosPresentacion iPresentacion = new CargosPresentacion();
                Cargos = await iPresentacion.Listar();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cargando cargos");
            }
        }
    }
}
