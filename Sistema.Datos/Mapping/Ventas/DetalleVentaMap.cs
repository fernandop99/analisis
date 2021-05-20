using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Ventas
{
   public class DetalleVentaMap : IEntityTypeConfiguration<detalle_venta>
    {
        public void Configure(EntityTypeBuilder<detalle_venta> builder)
        {
            builder.ToTable("detalle_venta")
                .HasKey(c => c.id_detalle_venta);
            builder.Property(c => c.cantidad_detalle_venta)
                .HasMaxLength(256);
            builder.Property(c => c.precio_detalle_venta)
                .HasMaxLength(100);
            builder.Property(c => c.descuento_detalle_venta)
                .HasMaxLength(256);
        }
    }
}
