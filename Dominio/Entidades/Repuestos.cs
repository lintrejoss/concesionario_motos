using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Repuestos
    {
        [Key] public int IdRepuesto { get; set; }
        public string Nombre { get; set; }
        public string Referencia { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }

        [NotMapped] public ICollection<Detalle_Ventas> Detalles_Ventas { get; set; }
        [NotMapped] public ICollection<Detalle_Compras> Detalles_Compras { get; set; }
    }
}
