using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class DetalleVenta
{
    public int IdDetalle { get; set; }

    public int Venta { get; set; }

    public int? Repuesto { get; set; }

    public int Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual Repuesto? RepuestoNavigation { get; set; }

    public virtual Venta VentaNavigation { get; set; } = null!;
}
