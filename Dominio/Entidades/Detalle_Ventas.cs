using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Azure.Core;

namespace Dominio.Entidades
{
    public class Detalle_Ventas
    {
        [Key] public int IdDetalle { get; set; }
        public int VentaId { get; set; }
        public int RepuestoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string? Descripcion { get; set; }
        [ForeignKey("VentaId")] public Ventas? Ventas { get; set; }
        [ForeignKey("RepuestoId")] public Repuestos? Repuestos { get; set; }
    }
}
