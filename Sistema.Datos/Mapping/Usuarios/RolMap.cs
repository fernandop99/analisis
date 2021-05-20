using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    
        public class RolMap : IEntityTypeConfiguration<Rol>
    {
            public void Configure(EntityTypeBuilder<Rol> builder)
            {
                builder.ToTable("Rol")
                    .HasKey(c => c.idrol);
                builder.Property(c => c.nombre_Rol)
                    .HasMaxLength(30);
                builder.Property(c => c.descrpcion_Rol)
                    .HasMaxLength(100);
                builder.Property(c => c.condicion_Rol)
                    .HasMaxLength(10);
            }
        }
}
