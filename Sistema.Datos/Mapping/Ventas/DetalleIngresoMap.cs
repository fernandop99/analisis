using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Ventas
{
    public class DetalleIngresoMap : IEntityTypeConfiguration<detalle_ingreso>
    {
        public void Configure(EntityTypeBuilder<detalle_ingreso> builder)
        {
            builder.ToTable("detalle_ingreso")
                .HasKey(c => c.id_detalle_ingreso);
            builder.Property(c => c.cantidad_detalle_ingreso)
                .HasMaxLength(256);
            builder.Property(c => c.precio_detalle_ingreso)
                .HasMaxLength(100);
            builder.Property(c => c.ingreso_detalle_ingreso)
                .HasMaxLength(256);
        }
    }
}
