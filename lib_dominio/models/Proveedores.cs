using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Proveedores
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Compras> Compras { get; set; } = new List<Compras>();
}
