using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class ModelosRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Modeloss")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarModelos_DeberiaAgregarModelos()
        {
            var Modelos = new Modelos { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.Modelos.Add(Modelos);
            _context.SaveChanges();

            var ModelosDB = _context.Modelos.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(ModelosDB);
            Assert.AreEqual("Juan Pérez", ModelosDB.Nombre);
        }

        [TestMethod]
        public void ObtenerModelos_DeberiaRetornarModelos()
        {
            _context.Modelos.Add(new Modelos { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var ModelosDB = _context.Modelos.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(ModelosDB);
            Assert.AreEqual("Ana López", ModelosDB.Nombre);
        }

        [TestMethod]
        public void ModificarModelos_DeberiaActualizarNombre()
        {
            var Modelos = new Modelos { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.Modelos.Add(Modelos);
            _context.SaveChanges();

            Modelos.Nombre = "Carlos R.";
            _context.Modelos.Update(Modelos);
            _context.SaveChanges();

            var ModelosDB = _context.Modelos.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", ModelosDB.Nombre);
        }

        [TestMethod]
        public void BorrarModelos_DeberiaEliminarModelos()
        {
            var Modelos = new Modelos { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.Modelos.Add(Modelos);
            _context.SaveChanges();

            _context.Modelos.Remove(Modelos);
            _context.SaveChanges();

            var ModelosDB = _context.Modelos.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(ModelosDB);
        }
    }
}