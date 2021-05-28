using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class UsuariosMap : IEntityTypeConfiguration<usuario>
    {
        public void Configure(EntityTypeBuilder<usuario> builder)
        {
            builder.ToTable("usuario")
                .HasKey(c => c.id_usuario);
            builder.Property(c => c.nombre)
                .HasMaxLength(100);
            builder.Property(c => c.tipo_descuento)
                .HasMaxLength(20);
            builder.Property(c => c.num_descuento)
                .HasMaxLength(20);
            builder.Property(c => c.direccion)
                .HasMaxLength(50);
            builder.Property(c => c.telefono)
                .HasMaxLength(11);
            builder.Property(c => c.Email)
                .HasMaxLength(16);
            builder.Property(c => c.password_hash)
            .HasMaxLength(255);
            builder.Property(c => c.Email)
            .HasMaxLength(255);
            builder.Property(c => c.condicion)
            .HasMaxLength(10);
            builder.Property(c => c.Id_Direccion);

            builder.Property(c => c.Id_Telefono);

            builder.Property(c => c.Id_Email);

        }
    }
}
