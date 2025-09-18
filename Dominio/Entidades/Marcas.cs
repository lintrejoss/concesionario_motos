using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Marcas
    {
        [Key] public int IdMarca { get; set; }
        public string Nombre { get; set; }

        [NotMapped] public ICollection<Modelos> Modelos { get; set; }
    }
}
