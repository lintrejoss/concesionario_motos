using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class CargoRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Cargo")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarCargo_DeberiaAgregarCargo()
        {
            var Cargo = new Cargos { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.Cargos.Add(Cargo);
            _context.SaveChanges();

            var CargoDB = _context.Cargos.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(CargoDB);
            Assert.AreEqual("Juan Pérez", CargoDB.Nombre);
        }

        [TestMethod]
        public void ObtenerCargo_DeberiaRetornarCargo()
        {
            _context.Cargos.Add(new Cargos { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var CargoDB = _context.Cargos.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(CargoDB);
            Assert.AreEqual("Ana López", CargoDB.Nombre);
        }

        [TestMethod]
        public void ModificarCargo_DeberiaActualizarNombre()
        {
            var Cargo = new Cargos { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.Cargos.Add(Cargo);
            _context.SaveChanges();

            Cargo.Nombre = "Carlos R.";
            _context.Cargos.Update(Cargo);
            _context.SaveChanges();

            var CargoDB = _context.Cargos.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", CargoDB.Nombre);
        }

        [TestMethod]
        public void BorrarCargo_DeberiaEliminarCargo()
        {
            var Cargo = new Cargos { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.Cargos.Add(Cargo);
            _context.SaveChanges();

            _context.Cargos.Remove(Cargo);
            _context.SaveChanges();

            var CargoDB = _context.Cargos.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(CargoDB);
        }
    }
}