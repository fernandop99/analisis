using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Ventas
{
    class IngresoMap : IEntityTypeConfiguration<ingreso>
    {
        public void Configure(EntityTypeBuilder<ingreso> builder)
        {
            builder.ToTable("ingreso")
                .HasKey(c => c.idingreso);
            builder.Property(c => c.tipo_comprobante_ingreso)
                .HasMaxLength(7);
            builder.Property(c => c.serie_comprobante_ingreso)
                .HasMaxLength(20);
            builder.Property(c => c.num_comprobante_ingreso)
                .HasMaxLength(20);
            builder.Property(c => c.impuesto_ingreso)
                .HasMaxLength(50);
        }
    }
}
