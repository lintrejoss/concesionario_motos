using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Motos
{
    public int IdMoto { get; set; }

    public int Modelo { get; set; }

    public string NumeroChasis { get; set; } = null!;

    public string? Color { get; set; }

    public decimal? Precio { get; set; }

    public string? Estado { get; set; }

    public virtual Modelos ModeloNavigation { get; set; } = null!;

    public virtual ICollection<OrdenServicios> OrdenServicios { get; set; } = new List<OrdenServicios>();

    public virtual ICollection<Ventas> Venta { get; set; } = new List<Ventas>();
}
