using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Moto
{
    public int IdMoto { get; set; }

    public int Modelo { get; set; }

    public string NumeroChasis { get; set; } = null!;

    public string? Color { get; set; }

    public decimal? Precio { get; set; }

    public string? Estado { get; set; }

    public virtual Modelo ModeloNavigation { get; set; } = null!;

    public virtual ICollection<OrdenServicio> OrdenServicios { get; set; } = new List<OrdenServicio>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
