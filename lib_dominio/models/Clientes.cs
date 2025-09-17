using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Clientes
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Documento { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<OrdenServicios> OrdenServicios { get; set; } = new List<OrdenServicios>();

    public virtual ICollection<Ventas> Venta { get; set; } = new List<Ventas>();
}
