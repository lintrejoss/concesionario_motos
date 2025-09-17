using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class OrdenServicios
{
    public int IdOrden { get; set; }

    public int Cliente { get; set; }

    public int Moto { get; set; }

    public int Empleado { get; set; }

    public int Servicio { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal? CostoTotal { get; set; }

    public virtual Clientes ClienteNavigation { get; set; } = null!;

    public virtual Empleados EmpleadoNavigation { get; set; } = null!;

    public virtual Motos MotoNavigation { get; set; } = null!;

    public virtual Servicios ServicioNavigation { get; set; } = null!;
}
