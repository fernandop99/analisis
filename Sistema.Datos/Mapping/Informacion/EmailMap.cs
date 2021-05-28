using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Informacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Informacion
{
    public class EmailMap : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("Email")
                .HasKey(c => c.Id_Email);
            builder.Property(c => c.email)
                .HasMaxLength(50);

        }
    
    }
}
