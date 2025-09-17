using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class OrdenServiciosRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_OrdenServicioss")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarOrdenServicios_DeberiaAgregarOrdenServicios()
        {
            var OrdenServicios = new OrdenServicios { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.OrdenServicios.Add(OrdenServicios);
            _context.SaveChanges();

            var OrdenServiciosDB = _context.OrdenServicios.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(OrdenServiciosDB);
            Assert.AreEqual("Juan Pérez", OrdenServiciosDB.Nombre);
        }

        [TestMethod]
        public void ObtenerOrdenServicios_DeberiaRetornarOrdenServicios()
        {
            _context.OrdenServicios.Add(new OrdenServicios { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var OrdenServiciosDB = _context.OrdenServicios.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(OrdenServiciosDB);
            Assert.AreEqual("Ana López", OrdenServiciosDB.Nombre);
        }

        [TestMethod]
        public void ModificarOrdenServicios_DeberiaActualizarNombre()
        {
            var OrdenServicios = new OrdenServicios { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.OrdenServicios.Add(OrdenServicios);
            _context.SaveChanges();

            OrdenServicios.Nombre = "Carlos R.";
            _context.OrdenServicios.Update(OrdenServicios);
            _context.SaveChanges();

            var OrdenServiciosDB = _context.OrdenServicios.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", OrdenServiciosDB.Nombre);
        }

        [TestMethod]
        public void BorrarOrdenServicios_DeberiaEliminarOrdenServicios()
        {
            var OrdenServicios = new OrdenServicios { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.OrdenServicios.Add(OrdenServicios);
            _context.SaveChanges();

            _context.OrdenServicios.Remove(OrdenServicios);
            _context.SaveChanges();

            var OrdenServiciosDB = _context.OrdenServicios.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(OrdenServiciosDB);
        }
    }
}
