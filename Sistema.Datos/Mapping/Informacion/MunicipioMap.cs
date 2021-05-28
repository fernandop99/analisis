using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Informacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Informacion
{
   public class MunicipioMap : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municipio")
                .HasKey(c => c.Id_Municipio);

            builder.Property(c => c.Nombre_Municipio)
            .HasMaxLength(70);
            builder.Property(c => c.Id_Departamento);
 
        }
    }
}
