using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Empleados
    {
        [Key] public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public int CargoId { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        [ForeignKey("CargoId")] public Cargos Cargos { get; set; }

        [NotMapped] public ICollection<Ventas> Ventas { get; set; }
        [NotMapped] public ICollection<Orden_Servicios> Ordenes_Servicios { get; set; }
    }
}
