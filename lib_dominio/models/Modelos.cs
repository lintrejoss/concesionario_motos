using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Modelos
{
    public int IdModelo { get; set; }

    public int Marca { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Cilindraje { get; set; }

    public int? Anio { get; set; }

    public virtual Marcas MarcaNavigation { get; set; } = null!;

    public virtual ICollection<Motos> Motos { get; set; } = new List<Motos>();
}
