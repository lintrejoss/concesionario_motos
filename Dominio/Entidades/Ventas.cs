using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Azure;

namespace Dominio.Entidades
{
    public class Ventas
    {
        [Key] public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int MotoId { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("ClienteId")] public Clientes Clientes { get; set; }
        [ForeignKey("EmpleadoId")] public Empleados Empleados { get; set; }
        [ForeignKey("MotoId")] public Motos Motos { get; set; }

        [NotMapped] public ICollection<Detalle_Ventas> Detalles_Ventas { get; set; }
        [NotMapped] public ICollection<Pagos> Pagos { get; set; }
    }
}
