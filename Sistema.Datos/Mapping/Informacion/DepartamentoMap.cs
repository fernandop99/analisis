using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Informacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Informacion
{
   public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento")
                .HasKey(c => c.Id_Depatamento);
            builder.Property(c => c.Nombre_Departamento)
                .HasMaxLength(50);
        }
    }
}
