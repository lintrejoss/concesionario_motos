using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades;

namespace Dominio.Entidades
{
    public class Detalle_Compras
    {
        [Key] public int IdDetalle { get; set; }
        public int CompraId { get; set; }
        public int RepuestoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        [ForeignKey("CompraId")] public Compras Compras { get; set; }
        [ForeignKey("RepuestoId")] public Repuestos Repuestos { get; set; }
    }
}
