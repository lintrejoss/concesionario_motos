using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Clientes
    {
        [Key] public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        [NotMapped] public ICollection<Ventas> Ventas { get; set; }
        [NotMapped] public ICollection<Orden_Servicios> Ordenes_Servicios { get; set; }
    }
}
