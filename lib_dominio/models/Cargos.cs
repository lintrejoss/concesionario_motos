using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Cargos
{
    public int IdCargo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Empleados> Empleados { get; set; } = new List<Empleados>();
}
