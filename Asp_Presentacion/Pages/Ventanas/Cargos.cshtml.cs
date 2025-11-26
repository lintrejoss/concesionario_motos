using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio.Entidades;
using System.Collections.Generic;

namespace asp_presentacion.Pages.Ventanas
{
    public class CargosModel : PageModel
    {
        public enum EstadoVentana { Listas, Editar }
        [BindProperty]
        public EstadoVentana Accion { get; set; } = EstadoVentana.Listas;

        [BindProperty]
        public string NombreNuevo { get; set; } = "";

        [BindProperty]
        public List<Cargos> Lista { get; set; } = new List<Cargos>();

        private static int _idContador = 1; // Para generar IdCargo localmente

        public void OnGet()
        {
            // Nada, la lista está en la propiedad y se mantiene en la sesión actual.
        }

        public void OnPostBtRefrescar()
        {
            Accion = EstadoVentana.Listas;
        }

        public void OnPostBtNuevo()
        {
            Accion = EstadoVentana.Editar;
            NombreNuevo = "";
        }

        public void OnPostBtGuardar()
        {
            if (!string.IsNullOrWhiteSpace(NombreNuevo))
            {
                Lista ??= new List<Cargos>();
                Lista.Add(new Cargos
                {
                    IdCargo = _idContador++, // Autoincrementado local
                    Nombre = NombreNuevo.Trim()
                });
                NombreNuevo = "";
            }
            Accion = EstadoVentana.Listas;
        }

        public void OnPostBtCancelar()
        {
            NombreNuevo = "";
            Accion = EstadoVentana.Listas;
        }
    }
}
