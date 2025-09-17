using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using lib_dominio.Entidades;
using System.Linq;

namespace ut_pruebas
{
    [TestClass]
    public class ClienteRepositoryTests
    {
        private ConcesionarioContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ConcesionarioContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Clientes")
                .Options;

            _context = new ConcesionarioContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GuardarCliente_DeberiaAgregarCliente()
        {
            var cliente = new Clientes { Id = 1, Nombre = "Juan Pérez", Correo = "juan@mail.com" };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            var clienteDB = _context.Clientes.FirstOrDefault(c => c.Id == 1);

            Assert.IsNotNull(clienteDB);
            Assert.AreEqual("Juan Pérez", clienteDB.Nombre);
        }

        [TestMethod]
        public void ObtenerCliente_DeberiaRetornarCliente()
        {
            _context.Clientes.Add(new Clientes { Id = 2, Nombre = "Ana López", Correo = "ana@mail.com" });
            _context.SaveChanges();

            var clienteDB = _context.Clientes.FirstOrDefault(c => c.Id == 2);

            Assert.IsNotNull(clienteDB);
            Assert.AreEqual("Ana López", clienteDB.Nombre);
        }

        [TestMethod]
        public void ModificarCliente_DeberiaActualizarNombre()
        {
            var cliente = new Clientes { Id = 3, Nombre = "Carlos Ruiz", Correo = "carlos@mail.com" };
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            cliente.Nombre = "Carlos R.";
            _context.Clientes.Update(cliente);
            _context.SaveChanges();

            var clienteDB = _context.Clientes.FirstOrDefault(c => c.Id == 3);

            Assert.AreEqual("Carlos R.", clienteDB.Nombre);
        }

        [TestMethod]
        public void BorrarCliente_DeberiaEliminarCliente()
        {
            var cliente = new Clientes { Id = 4, Nombre = "Laura Torres", Correo = "laura@mail.com" };
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            var clienteDB = _context.Clientes.FirstOrDefault(c => c.Id == 4);

            Assert.IsNull(clienteDB);
        }
    }
}
