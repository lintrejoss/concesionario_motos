using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class ServiciosRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Servicioss")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarServicios_DeberiaAgregarServicios()
        {
            var Servicios = new Servicios { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.Servicioss.Add(Servicios);
            _context.SaveChanges();

            var ServiciosDB = _context.Servicioss.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(ServiciosDB);
            Assert.AreEqual("Juan Pérez", ServiciosDB.Nombre);
        }

        [TestMethod]
        public void ObtenerServicios_DeberiaRetornarServicios()
        {
            _context.Servicioss.Add(new Servicios { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var ServiciosDB = _context.Servicioss.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(ServiciosDB);
            Assert.AreEqual("Ana López", ServiciosDB.Nombre);
        }

        [TestMethod]
        public void ModificarServicios_DeberiaActualizarNombre()
        {
            var Servicios = new Servicios { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.Servicioss.Add(Servicios);
            _context.SaveChanges();

            Servicios.Nombre = "Carlos R.";
            _context.Servicioss.Update(Servicios);
            _context.SaveChanges();

            var ServiciosDB = _context.Servicioss.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", ServiciosDB.Nombre);
        }

        [TestMethod]
        public void BorrarServicios_DeberiaEliminarServicios()
        {
            var Servicios = new Servicios { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.Servicioss.Add(Servicios);
            _context.SaveChanges();

            _context.Servicioss.Remove(Servicios);
            _context.SaveChanges();

            var ServiciosDB = _context.Servicioss.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(ServiciosDB);
        }
    }
}