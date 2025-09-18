using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades;

namespace Dominio.Entidades
{
    public class Pagos
    {
        [Key] public int IdPago { get; set; }
        public int VentaId { get; set; }
        public string MetodoPago { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("VentaId")] public Ventas Ventas { get; set; }
    }
}
