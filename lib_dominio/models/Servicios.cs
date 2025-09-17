using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Servicios
{
    public int IdServicio { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? CostoBase { get; set; }

    public virtual ICollection<OrdenServicios> OrdenServicios { get; set; } = new List<OrdenServicios>();
}
