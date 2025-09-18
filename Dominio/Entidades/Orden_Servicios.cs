using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Dominio.Entidades
{
    public class Orden_Servicios
    {
        [Key] public int IdOrden { get; set; }
        public int ClienteId { get; set; }
        public int MotoId { get; set; }
        public int EmpleadoId { get; set; }
        public int ServicioId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? CostoTotal { get; set; }

        // Relacion con Cliente
        [ForeignKey("ClienteId")] public Clientes Clientes { get; set; }

        // Relacion con Moto
        [ForeignKey("MotoId")] public Motos Motos { get; set; }

        // Relacion con Empleado
        [ForeignKey("EmpleadoId")] public Empleados Empleados { get; set; }

        // Relacion con Servicio
        [ForeignKey("ServicioId")] public Servicios Servicios { get; set; }
    }
}
