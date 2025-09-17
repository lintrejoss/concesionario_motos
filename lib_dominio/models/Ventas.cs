using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Ventas
{
    public int IdVenta { get; set; }

    public DateOnly Fecha { get; set; }

    public int Cliente { get; set; }

    public int Empleado { get; set; }

    public int Moto { get; set; }

    public decimal Total { get; set; }

    public virtual Clientes ClienteNavigation { get; set; } = null!;

    public virtual ICollection<DetalleVentas> DetalleVenta { get; set; } = new List<DetalleVentas>();

    public virtual Empleados EmpleadoNavigation { get; set; } = null!;

    public virtual Motos MotoNavigation { get; set; } = null!;

    public virtual ICollection<Pagos> Pagos { get; set; } = new List<Pagos>();
}
