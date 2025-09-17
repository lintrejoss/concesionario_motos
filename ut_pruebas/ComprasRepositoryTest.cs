using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class ComprasRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Compra")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarCompra_DeberiaAgregarCompra()
        {
            var Compra = new Compra { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.Compras.Add(Compra);
            _context.SaveChanges();

            var CompraDB = _context.Compras.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(CompraDB);
            Assert.AreEqual("Juan Pérez", CompraDB.Nombre);
        }

        [TestMethod]
        public void ObtenerCompra_DeberiaRetornarCompra()
        {
            _context.Compras.Add(new Compra { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var CompraDB = _context.Compras.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(CompraDB);
            Assert.AreEqual("Ana López", CompraDB.Nombre);
        }

        [TestMethod]
        public void ModificarCompra_DeberiaActualizarNombre()
        {
            var Compra = new Compra { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.Compras.Add(Compra);
            _context.SaveChanges();

            Compra.Nombre = "Carlos R.";
            _context.Compras.Update(Compra);
            _context.SaveChanges();

            var CompraDB = _context.Compras.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", CompraDB.Nombre);
        }

        [TestMethod]
        public void BorrarCompra_DeberiaEliminarCompra()
        {
            var Compra = new Compra { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.Compras.Add(Compra);
            _context.SaveChanges();

            _context.Compras.Remove(Compra);
            _context.SaveChanges();

            var CompraDB = _context.Compras.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(CompraDB);
        }
    }
}