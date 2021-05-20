using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{

        public class PersonaMap : IEntityTypeConfiguration<persona>
    {
            public void Configure(EntityTypeBuilder<persona> builder)
            {
                builder.ToTable("persona")
                    .HasKey(c => c.idpersona);
                builder.Property(c => c.tipo_persona)
                    .HasMaxLength(50);
                builder.Property(c => c.nombre)
                    .HasMaxLength(100);
                builder.Property(c => c.tipo_documento)
                    .HasMaxLength(20);
                builder.Property(c => c.num_documento)
                    .HasMaxLength(20);
                builder.Property(c => c.direccion)
                    .HasMaxLength(70);
                builder.Property(c => c.telefono)
                    .HasMaxLength(20);
                builder.Property(c => c.email)
                    .HasMaxLength(50);
            }
        }
    }
