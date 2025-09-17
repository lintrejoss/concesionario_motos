using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class RepuestosRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Repuestoss")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarRepuestos_DeberiaAgregarRepuestos()
        {
            var Repuestos = new Repuestos { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.Repuestos.Add(Repuestos);
            _context.SaveChanges();

            var RepuestosDB = _context.Repuestos.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(RepuestosDB);
            Assert.AreEqual("Juan Pérez", RepuestosDB.Nombre);
        }

        [TestMethod]
        public void ObtenerRepuestos_DeberiaRetornarRepuestos()
        {
            _context.Repuestos.Add(new Repuestos { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var RepuestosDB = _context.Repuestos.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(RepuestosDB);
            Assert.AreEqual("Ana López", RepuestosDB.Nombre);
        }

        [TestMethod]
        public void ModificarRepuestos_DeberiaActualizarNombre()
        {
            var Repuestos = new Repuestos { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.Repuestos.Add(Repuestos);
            _context.SaveChanges();

            Repuestos.Nombre = "Carlos R.";
            _context.Repuestos.Update(Repuestos);
            _context.SaveChanges();

            var RepuestosDB = _context.Repuestos.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", RepuestosDB.Nombre);
        }

        [TestMethod]
        public void BorrarRepuestos_DeberiaEliminarRepuestos()
        {
            var Repuestos = new Repuestos { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.Repuestos.Add(Repuestos);
            _context.SaveChanges();

            _context.Repuestos.Remove(Repuestos);
            _context.SaveChanges();

            var RepuestosDB = _context.Repuestos.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(RepuestosDB);
        }
    }
}