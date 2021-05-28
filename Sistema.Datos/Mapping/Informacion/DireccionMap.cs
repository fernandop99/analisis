using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Informacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Informacion
{
   public class DireccionMap : IEntityTypeConfiguration<Direccion>
    {
    
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.ToTable("Direccion")
                .HasKey(c => c.Id_Direccion);
            builder.Property(c => c.Id_Municipio);

            builder.Property(c => c.Num_Casa);

            builder.Property(c => c.Avenida)
                .HasMaxLength(50);
            builder.Property(c => c.Zona);

            builder.Property(c => c.Num_Casa);
 
            builder.Property(c => c.Otros)
                .HasMaxLength(256);
        }
    }
}
