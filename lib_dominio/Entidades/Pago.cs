using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Pago
{
    public int IdPago { get; set; }

    public int Venta { get; set; }

    public string MetodoPago { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateOnly Fecha { get; set; }

    public virtual Venta VentaNavigation { get; set; } = null!;
}
