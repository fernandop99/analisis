using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Ventas
{
   public class detalle_venta
    {
        public int id_detalle_venta { get; set; }

        [Required]
        public int cantidad_detalle_venta { get; set; }

        public decimal precio_detalle_venta { get; set; }

        public decimal descuento_detalle_venta { get; set; }

        //realcion con la tabla venta
        public venta ventas { get; set; }

        //realcion con la tabla articulo
        public articulo Articulo { get; set; }
    }
}
