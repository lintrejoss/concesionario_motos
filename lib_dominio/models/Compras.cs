using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Compras
{
    public int IdCompra { get; set; }

    public int Proveedor { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleCompras> DetalleCompras { get; set; } = new List<DetalleCompras>();

    public virtual Proveedore ProveedorNavigation { get; set; } = null!;
}
