using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IEmpleadosAplicacion
    {
        void Configurar(string StringConexion);
        List<Empleados> PorTipo(Empleados? entidad);
        List<Empleados> Listar();
        Empleados? Guardar(Empleados? entidad);
        Empleados? Modificar(Empleados? entidad);
        Empleados? Borrar(Empleados? entidad);
    }
}
