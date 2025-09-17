using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int Proveedor { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedore ProveedorNavigation { get; set; } = null!;
}
