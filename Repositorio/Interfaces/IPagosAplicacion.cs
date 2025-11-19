using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IPagosAplicacion
    {
        void Configurar(string StringConexion);
        List<Pagos> PorTipo(Pagos? entidad);
        List<Pagos> Listar();
        Pagos? Guardar(Pagos? entidad);
        Pagos? Modificar(Pagos? entidad);
        Pagos? Borrar(Pagos? entidad);
    }
}
