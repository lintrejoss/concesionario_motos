using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Motos
    {
        [Key] public int IdMoto { get; set; }
        public int ModeloId { get; set; }
        public string? NumeroChasis { get; set; }
        public string? Color { get; set; }
        public decimal Precio { get; set; }
        public string? Estado { get; set; }

        [ForeignKey("ModeloId")] public Modelos? Modelos { get; set; }

        [NotMapped] public ICollection<Ventas>? Ventas { get; set; }
        [NotMapped] public ICollection<Orden_Servicios>? Ordenes_Servicios { get; set; }
    }
}
