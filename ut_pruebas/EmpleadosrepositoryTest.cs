using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class EmpleadosRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Empleados")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarEmpleados_DeberiaAgregarEmpleados()
        {
            var Empleados = new Empleados { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.Empleados.Add(Empleados);
            _context.SaveChanges();

            var EmpleadosDB = _context.Empleados.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(EmpleadosDB);
            Assert.AreEqual("Juan Pérez", EmpleadosDB.Nombre);
        }

        [TestMethod]
        public void ObtenerEmpleados_DeberiaRetornarEmpleados()
        {
            _context.Empleados.Add(new Empleados { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var EmpleadosDB = _context.Empleados.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(EmpleadosDB);
            Assert.AreEqual("Ana López", EmpleadosDB.Nombre);
        }

        [TestMethod]
        public void ModificarEmpleados_DeberiaActualizarNombre()
        {
            var Empleados = new Empleados { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.Empleados.Add(Empleados);
            _context.SaveChanges();

            Empleados.Nombre = "Carlos R.";
            _context.Empleados.Update(Empleados);
            _context.SaveChanges();

            var EmpleadosDB = _context.Empleados.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", EmpleadosDB.Nombre);
        }

        [TestMethod]
        public void BorrarEmpleados_DeberiaEliminarEmpleados()
        {
            var Empleados = new Empleados { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.Empleados.Add(Empleados);
            _context.SaveChanges();

            _context.Empleados.Remove(Empleados);
            _context.SaveChanges();

            var EmpleadosDB = _context.Empleados.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(EmpleadosDB);
        }
    }
}
