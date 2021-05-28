using Sistema.Entidades.Almacen;
using Sistema.Entidades.Usuarios;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Ventas
{
    public class detalle_ingreso
    {
        public int id_detalle_ingreso { get; set; }

        [Required]
        public int cantidad_detalle_ingreso { get; set; }

        public decimal precio_detalle_ingreso { get; set; }

        public int ingreso_detalle_ingreso { get; set; }

        //realcion con la tabla articulos
        public articulo Articulos { get; set; }
        //realcion con la tabla ingreso
        public ingreso Ingresos { get; set; }

    }
}
