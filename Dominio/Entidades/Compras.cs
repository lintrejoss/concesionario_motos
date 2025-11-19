using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Dominio.Entidades;

namespace Dominio.Entidades
{
    public class Compras
    {
        [Key] public int IdCompra { get; set; }
        public int ProveedorId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string? Descrpcion { get; set; }

        [ForeignKey("ProveedorId")] public Proveedores? Proveedores { get; set; }

        [NotMapped] public ICollection<Detalle_Compras>? Detalles_Compras { get; set; }
    }
}
