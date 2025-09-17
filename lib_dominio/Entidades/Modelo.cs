using System;
using System.Collections.Generic;

namespace lib_dominio.Entidades;

public partial class Modelo
{
    public int IdModelo { get; set; }

    public int Marca { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Cilindraje { get; set; }

    public int? Anio { get; set; }

    public virtual Marca MarcaNavigation { get; set; } = null!;

    public virtual ICollection<Moto> Motos { get; set; } = new List<Moto>();
}
