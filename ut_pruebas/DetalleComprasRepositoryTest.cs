using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class DetalleComprasRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_DetalleCompras")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarDetalleCompras_DeberiaAgregarDetalleCompras()
        {
            var DetalleCompras = new DetalleCompras { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.DetalleCompras.Add(DetalleCompras);
            _context.SaveChanges();

            var DetalleComprasDB = _context.DetalleCompras.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(DetalleComprasDB);
            Assert.AreEqual("Juan Pérez", DetalleComprasDB.Nombre);
        }

        [TestMethod]
        public void ObtenerDetalleCompras_DeberiaRetornarDetalleCompras()
        {
            _context.DetalleCompras.Add(new DetalleCompras { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var DetalleComprasDB = _context.DetalleCompras.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(DetalleComprasDB);
            Assert.AreEqual("Ana López", DetalleComprasDB.Nombre);
        }

        [TestMethod]
        public void ModificarDetalleCompras_DeberiaActualizarNombre()
        {
            var DetalleCompras = new DetalleCompras { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.DetalleCompras.Add(DetalleCompras);
            _context.SaveChanges();

            DetalleCompras.Nombre = "Carlos R.";
            _context.DetalleCompras.Update(DetalleCompras);
            _context.SaveChanges();

            var DetalleComprasDB = _context.DetalleCompras.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", DetalleComprasDB.Nombre);
        }

        [TestMethod]
        public void BorrarDetalleCompras_DeberiaEliminarDetalleCompras()
        {
            var DetalleCompras = new DetalleCompras { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.DetalleCompras.Add(DetalleCompras);
            _context.SaveChanges();

            _context.DetalleCompras.Remove(DetalleCompras);
            _context.SaveChanges();

            var DetalleComprasDB = _context.DetalleCompras.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(DetalleComprasDB);
        }
    }
}