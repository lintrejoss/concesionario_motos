using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class MarcasRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Marcass")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarMarcas_DeberiaAgregarMarcas()
        {
            var Marcas = new Marcas { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.Marcas.Add(Marcas);
            _context.SaveChanges();

            var MarcasDB = _context.Marcas.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(MarcasDB);
            Assert.AreEqual("Juan Pérez", MarcasDB.Nombre);
        }

        [TestMethod]
        public void ObtenerMarcas_DeberiaRetornarMarcas()
        {
            _context.Marcas.Add(new Marcas { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var MarcasDB = _context.Marcas.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(MarcasDB);
            Assert.AreEqual("Ana López", MarcasDB.Nombre);
        }

        [TestMethod]
        public void ModificarMarcas_DeberiaActualizarNombre()
        {
            var Marcas = new Marcas { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.Marcas.Add(Marcas);
            _context.SaveChanges();

            Marcas.Nombre = "Carlos R.";
            _context.Marcas.Update(Marcas);
            _context.SaveChanges();

            var MarcasDB = _context.Marcas.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", MarcasDB.Nombre);
        }

        [TestMethod]
        public void BorrarMarcas_DeberiaEliminarMarcas()
        {
            var Marcas = new Marcas { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.Marcas.Add(Marcas);
            _context.SaveChanges();

            _context.Marcas.Remove(Marcas);
            _context.SaveChanges();

            var MarcasDB = _context.Marcas.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(MarcasDB);
        }
    }
}