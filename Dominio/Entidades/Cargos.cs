using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Cargos
    {
        [Key] public int IdCargo { get; set; }
        public string Nombre { get; set; }

        [NotMapped] public ICollection<Empleados> Empleados { get; set; }
    }
}
