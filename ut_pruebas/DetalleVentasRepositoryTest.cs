using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class DetalleVentasRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_DetalleVentas")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarDetalleVentas_DeberiaAgregarDetalleVentas()
        {
            var DetalleVentas = new DetalleVentas { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.DetalleVentas.Add(DetalleVentas);
            _context.SaveChanges();

            var DetalleVentasDB = _context.DetalleVentas.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(DetalleVentasDB);
            Assert.AreEqual("Juan Pérez", DetalleVentasDB.Nombre);
        }

        [TestMethod]
        public void ObtenerDetalleVentas_DeberiaRetornarDetalleVentas()
        {
            _context.DetalleVentas.Add(new DetalleVentas { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var DetalleVentasDB = _context.DetalleVentas.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(DetalleVentasDB);
            Assert.AreEqual("Ana López", DetalleVentasDB.Nombre);
        }

        [TestMethod]
        public void ModificarDetalleVentas_DeberiaActualizarNombre()
        {
            var DetalleVentas = new DetalleVentas { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.DetalleVentas.Add(DetalleVentas);
            _context.SaveChanges();

            DetalleVentas.Nombre = "Carlos R.";
            _context.DetalleVentas.Update(DetalleVentas);
            _context.SaveChanges();

            var DetalleVentasDB = _context.DetalleVentas.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", DetalleVentasDB.Nombre);
        }

        [TestMethod]
        public void BorrarDetalleVentas_DeberiaEliminarDetalleVentas()
        {
            var DetalleVentas = new DetalleVentas { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.DetalleVentas.Add(DetalleVentas);
            _context.SaveChanges();

            _context.DetalleVentas.Remove(DetalleVentas);
            _context.SaveChanges();

            var DetalleVentasDB = _context.DetalleVentas.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(DetalleVentasDB);
        }
    }
}