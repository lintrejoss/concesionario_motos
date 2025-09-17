using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class MotoRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted(); // Reinicia la BD en cada prueba
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarMoto_DeberiaAgregarMoto()
        {
            var moto = new Motos { Id = 1, Nombre = "Yamaha" };

            _context.Motos.Add(moto);
            _context.SaveChanges();

            var motoDB = _context.Motos.FirstOrDefault(m => m.Id == 1);

            Assert.IsNotNull(motoDB);
            Assert.AreEqual("Yamaha", motoDB.Nombre);
        }

        [TestMethod]
        public void ObtenerMoto_DeberiaRetornarMoto()
        {
            _context.Motos.Add(new Motos { Id = 2, Nombre = "Honda" });
            _context.SaveChanges();

            var motoDB = _context.Motos.FirstOrDefault(m => m.Id == 2);

            Assert.IsNotNull(motoDB);
            Assert.AreEqual("Honda", motoDB.Nombre);
        }

        [TestMethod]
        public void ModificarMoto_DeberiaActualizarNombre()
        {
            var moto = new Motos { Id = 3, Nombre = "Suzuki" };
            _context.Motos.Add(moto);
            _context.SaveChanges();

            moto.Nombre = "Suzuki GSX";
            _context.Motos.Update(moto);
            _context.SaveChanges();

            var motoDB = _context.Motos.FirstOrDefault(m => m.Id == 3);

            Assert.AreEqual("Suzuki GSX", motoDB.Nombre);
        }

        [TestMethod]
        public void BorrarMoto_DeberiaEliminarMoto()
        {
            var moto = new Motos { Id = 4, Nombre = "Kawasaki" };
            _context.Motos.Add(moto);
            _context.SaveChanges();

            _context.Motos.Remove(moto);
            _context.SaveChanges();

            var motoDB = _context.Motos.FirstOrDefault(m => m.Id == 4);

            Assert.IsNull(motoDB);
        }
    }
}