using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Servicios
    {
        [Key] public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public decimal CostoBase { get; set; }

        [NotMapped]
        public ICollection<Orden_Servicios> Ordenes_Servicios { get; set;  }
    }
}