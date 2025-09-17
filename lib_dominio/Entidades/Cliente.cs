using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Documento { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<OrdenServicio> OrdenServicios { get; set; } = new List<OrdenServicio>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
