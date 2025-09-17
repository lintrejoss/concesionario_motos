using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Documento { get; set; } = null!;

    public int Cargo { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual Cargo CargoNavigation { get; set; } = null!;

    public virtual ICollection<OrdenServicio> OrdenServicios { get; set; } = new List<OrdenServicio>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
