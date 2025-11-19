using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IDetalle_ComprasAplicacion
    {
        void Configurar(string StringConexion);
        List<Detalle_Compras> PorTipo(Detalle_Compras? entidad);
        List<Detalle_Compras> Listar();
        Detalle_Compras? Guardar(Detalle_Compras? entidad);
        Detalle_Compras? Modificar(Detalle_Compras? entidad);
        Detalle_Compras? Borrar(Detalle_Compras? entidad);
    }
}
