using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Dominio.Entidades
{
    public class Modelos
    {
        [Key] public int IdModelo { get; set; }
        public int MarcaId { get; set; }
        public string? Nombre { get; set; }
        public int Cilindraje { get; set; }
        public int Año { get; set; }

        [ForeignKey("MarcaId")] public Marcas? Marcas { get; set; }

        [NotMapped] public ICollection<Motos>? Motos { get; set; }
    }
}
