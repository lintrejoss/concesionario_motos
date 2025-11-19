using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IProveedoresAplicacion
    {
        void Configurar(string StringConexion);
        List<Proveedores> PorTipo(Proveedores? entidad);
        List<Proveedores> Listar();
        Proveedores? Guardar(Proveedores? entidad);
        Proveedores? Modificar(Proveedores? entidad);
        Proveedores? Borrar(Proveedores? entidad);
    }
}

