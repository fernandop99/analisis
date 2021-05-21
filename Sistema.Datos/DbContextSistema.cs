using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Mapping.Almacen;
using Sistema.Datos.Mapping.Informacion;
using Sistema.Datos.Mapping.Usuarios;
using Sistema.Datos.Mapping.Ventas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping
{
    public class DbContextSistema : DbContext
    {
        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ArticuloMap());
            modelBuilder.ApplyConfiguration(new PersonaMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new DetalleIngresoMap());
            modelBuilder.ApplyConfiguration(new DetalleVentaMap());
            modelBuilder.ApplyConfiguration(new IngresoMap());
            modelBuilder.ApplyConfiguration(new VentasMap());
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
            modelBuilder.ApplyConfiguration(new DireccionMap());
            modelBuilder.ApplyConfiguration(new EmailMap());
            modelBuilder.ApplyConfiguration(new MunicipioMap());
            modelBuilder.ApplyConfiguration(new TelefonoMap());




        }
    }
}