using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Empleados
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Documento { get; set; } = null!;

    public int Cargo { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual Cargos CargoNavigation { get; set; } = null!;

    public virtual ICollection<OrdenServicios> OrdenServicios { get; set; } = new List<OrdenServicios>();

    public virtual ICollection<Ventas> Venta { get; set; } = new List<Ventas>();
}
