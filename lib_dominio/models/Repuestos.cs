using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Repuesto
{
    public int IdRepuesto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Referencia { get; set; }

    public int Stock { get; set; }

    public decimal Precio { get; set; }

    public virtual ICollection<DetalleCompras> DetalleCompras { get; set; } = new List<DetalleCompras>();

    public virtual ICollection<DetalleVentas> DetalleVenta { get; set; } = new List<DetalleVentas>();
}
