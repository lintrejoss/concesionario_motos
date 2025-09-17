using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class DetalleCompra
{
    public int IdDetalle { get; set; }

    public int Compra { get; set; }

    public int Repuesto { get; set; }

    public int Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual Compra CompraNavigation { get; set; } = null!;

    public virtual Repuesto RepuestoNavigation { get; set; } = null!;
}
