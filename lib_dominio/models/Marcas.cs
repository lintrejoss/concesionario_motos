using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Marcas
{
    public int IdMarca { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Modelos> Modelos { get; set; } = new List<Modelos>();
}
