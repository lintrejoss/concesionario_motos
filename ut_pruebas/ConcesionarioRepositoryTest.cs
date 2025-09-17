using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class consecionariosRepositoryTests
    {
        private ConcesionariosContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionariosContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_consecionarios")
                .Options;

            _context = new ConcesionariosContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Guardarconsecionarios_DeberiaAgregarconsecionarios()
        {
            var consecionarios = new consecionarios { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.consecionarioss.Add(consecionarios);
            _context.SaveChanges();

            var consecionariosDB = _context.consecionarioss.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(consecionariosDB);
            Assert.AreEqual("Juan Pérez", consecionariosDB.Nombre);
        }

        [TestMethod]
        public void Obtenerconsecionarios_DeberiaRetornarconsecionarios()
        {
            _context.consecionarioss.Add(new consecionarios { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var consecionariosDB = _context.consecionarioss.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(consecionariosDB);
            Assert.AreEqual("Ana López", consecionariosDB.Nombre);
        }

        [TestMethod]
        public void Modificarconsecionarios_DeberiaActualizarNombre()
        {
            var consecionarios = new consecionarios { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.consecionarioss.Add(consecionarios);
            _context.SaveChanges();

            consecionarios.Nombre = "Carlos R.";
            _context.consecionarioss.Update(consecionarios);
            _context.SaveChanges();

            var consecionariosDB = _context.consecionarioss.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", consecionariosDB.Nombre);
        }

        [TestMethod]
        public void Borrarconsecionarios_DeberiaEliminarconsecionarios()
        {
            var consecionarios = new consecionarios { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.consecionarioss.Add(consecionarios);
            _context.SaveChanges();

            _context.consecionarioss.Remove(consecionarios);
            _context.SaveChanges();

            var consecionariosDB = _context.consecionarioss.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(consecionariosDB);
        }
    }
}