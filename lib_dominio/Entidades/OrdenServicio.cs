using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class OrdenServicio
{
    public int IdOrden { get; set; }

    public int Cliente { get; set; }

    public int Moto { get; set; }

    public int Empleado { get; set; }

    public int Servicio { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal? CostoTotal { get; set; }

    public virtual Cliente ClienteNavigation { get; set; } = null!;

    public virtual Empleado EmpleadoNavigation { get; set; } = null!;

    public virtual Moto MotoNavigation { get; set; } = null!;

    public virtual Servicio ServicioNavigation { get; set; } = null!;
}
