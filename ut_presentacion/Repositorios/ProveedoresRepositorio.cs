﻿using Dominio.Entidades;
using Repositorio.Implementaciones;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ProveedoresPrueba
    {
        private readonly IConexion? iConexion;
        private List<Proveedores>? lista;
        private Proveedores? entidad;
        public ProveedoresPrueba()
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
            this.lista = this.iConexion!.Proveedores!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Proveedores()!;
            this.iConexion!.Proveedores!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Nombre = "malanta";
            var entry = this.iConexion!.Entry<Proveedores>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Proveedores!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}