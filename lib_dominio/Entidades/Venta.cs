using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateOnly Fecha { get; set; }

    public int Cliente { get; set; }

    public int Empleado { get; set; }

    public int Moto { get; set; }

    public decimal Total { get; set; }

    public virtual Cliente ClienteNavigation { get; set; } = null!;

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Empleado EmpleadoNavigation { get; set; } = null!;

    public virtual Moto MotoNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
