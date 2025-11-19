using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IRepuestosAplicacion
    {
        void Configurar(string StringConexion);
        List<Repuestos> PorTipo(Repuestos? entidad);
        List<Repuestos> Listar();
        Repuestos? Guardar(Repuestos? entidad);
        Repuestos? Modificar(Repuestos? entidad);
        Repuestos? Borrar(Repuestos? entidad);
    }
}
