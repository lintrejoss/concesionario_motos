using Dominio.Entidades;
namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Marcas? Marcas()
        {
            var entidad = new Marcas();
            entidad.Nombre = "toyota";
            return entidad;
        }

        public static Modelos? Modelos()
        {
            var entidad = new Modelos();
            entidad.MarcaId = 1;
            entidad.Nombre = "Corolla";
            entidad.Cilindraje = 1800;
            entidad.Año = 2022;
            return entidad;
        }

        public static Repuestos? Repuestos()
        {
            var entidad = new Repuestos();
            entidad.Nombre = "Bujía";
            entidad.Referencia = "BUJ124";
            entidad.Stock = 100;
            entidad.Precio = 15.50m;
            return entidad;
        }

        public static Cargos? Cargos()
        {
            var entidad = new Cargos();
            entidad.Nombre = "Gerente";
            return entidad;
        }

        public static Motos? Motos()
        {
            var entidad = new Motos();
            entidad.ModeloId = 1;
            entidad.NumeroChasis = "ABC123457";
            entidad.Color = "Rojo";
            entidad.Precio = 15000.00m;
            entidad.Estado = "Disponible";
            return entidad;
        }

        public static Clientes? Clientes()
        {
            var entidad = new Clientes();
            entidad.Nombre = "Juan Pérez";
            entidad.Documento = "12345673";
            entidad.Telefono = "555-1234";
            entidad.Email = "juanperez@email.com";
            entidad.Direccion = "Calle Falsa 123";
            return entidad;
        }

        public static Empleados? Empleados()
        {
            var entidad = new Empleados();
            entidad.Nombre = "Pedro Sánchez";
            entidad.Documento = "20123455";
            entidad.CargoId = 1;
            entidad.Telefono = "555-1234";
            entidad.Email = "pedrosanchez@email.com";
            return entidad;
        }

        public static Ventas? Ventas()
        {
            var entidad = new Ventas();
            entidad.Fecha = new DateTime(2023, 9, 1);
            entidad.ClienteId = 1;
            entidad.EmpleadoId = 1;
            entidad.MotoId = 1;
            entidad.Total = 15000.00m;
            return entidad;
        }

        public static Detalle_Ventas? Detalle_Ventas()
        {
            var entidad = new Detalle_Ventas();
            entidad.VentaId = 1;
            entidad.RepuestoId = 1;
            entidad.Cantidad = 2;
            entidad.PrecioUnitario = 15.50m;
            return entidad;
        }

        public static Pagos? Pagos()
        {
            var entidad = new Pagos();
            entidad.VentaId = 1;
            entidad.MetodoPago = "Efectivo";
            entidad.Monto = 15000.00m;
            entidad.Fecha = new DateTime(2023, 9, 1);
            return entidad;
        }

        public static Proveedores? Proveedores()
        {
            var entidad = new Proveedores();
            entidad.Nombre = "Proveedor A";
            entidad.Telefono = "555-0001";
            entidad.Email = "proveedora@email.com";
            return entidad;
        }

        public static Compras? Compras()
        {
            var entidad = new Compras();
            entidad.ProveedorId = 1;
            entidad.Fecha = new DateTime(2023, 9, 1);
            entidad.Total = 5000.00m;
            return entidad;
        }

        public static Detalle_Compras? Detalle_Compras()
        {
            var entidad = new Detalle_Compras();
            entidad.CompraId = 1;
            entidad.RepuestoId = 1;
            entidad.Cantidad = 10;
            entidad.PrecioUnitario = 15.50m;
            return entidad;
        }

        public static Servicios? Servicios()
        {
            var entidad = new Servicios();
            entidad.Nombre = "Cambio de aceite";
            entidad.CostoBase = 50.00m;
            return entidad;
        }

        public static Orden_Servicios? Orden_Servicios()
        {
            var entidad = new Orden_Servicios();
            entidad.ClienteId = 1;
            entidad.MotoId = 1;
            entidad.EmpleadoId = 1;
            entidad.ServicioId = 1;
            entidad.Fecha = new DateTime(2023, 9, 1);
            entidad.CostoTotal = 50.00m;
            return entidad;
        }
    }
}

