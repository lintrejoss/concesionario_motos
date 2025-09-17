using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class VentasRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Ventass")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarVentas_DeberiaAgregarVentas()
        {
            var Ventas = new Ventas { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.Ventas.Add(Ventas);
            _context.SaveChanges();

            var VentasDB = _context.Ventas.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(VentasDB);
            Assert.AreEqual("Juan Pérez", VentasDB.Nombre);
        }

        [TestMethod]
        public void ObtenerVentas_DeberiaRetornarVentas()
        {
            _context.Ventas.Add(new Ventas { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var VentasDB = _context.Ventas.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(VentasDB);
            Assert.AreEqual("Ana López", VentasDB.Nombre);
        }

        [TestMethod]
        public void ModificarVentas_DeberiaActualizarNombre()
        {
            var Ventas = new Ventas { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.Ventas.Add(Ventas);
            _context.SaveChanges();

            Ventas.Nombre = "Carlos R.";
            _context.Ventas.Update(Ventas);
            _context.SaveChanges();

            var VentasDB = _context.Ventas.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", VentasDB.Nombre);
        }

        [TestMethod]
        public void BorrarVentas_DeberiaEliminarVentas()
        {
            var Ventas = new Ventas { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.Ventas.Add(Ventas);
            _context.SaveChanges();

            _context.Ventas.Remove(Ventas);
            _context.SaveChanges();

            var VentasDB = _context.Ventas.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(VentasDB);
        }
    }
}
