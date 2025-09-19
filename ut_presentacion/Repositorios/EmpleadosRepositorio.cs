﻿using Dominio.Entidades;
using Repositorio.Implementaciones;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class EmpleadosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Empleados>? lista;
        private Empleados? entidad;
        public EmpleadosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }
        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        public bool Listar()
        {
            this.lista = this.iConexion!.Empleados!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Empleados()!;
            this.iConexion!.Empleados!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Nombre = "juan";
            var entry = this.iConexion!.Entry<Empleados>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Empleados!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
