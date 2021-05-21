using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Informacion;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Informacion
{
   public class TelefonoMap : IEntityTypeConfiguration<Telefono>
    {
        public void Configure(EntityTypeBuilder<Telefono> builder)
        {
            builder.ToTable("Telefono")
                .HasKey(c => c.Id_Telefono);
            builder.Property(c => c.Tel_Personal)
                .HasMaxLength(11);
            builder.Property(c => c.Tel_Casa)
                .HasMaxLength(11);
        }
    }
}
