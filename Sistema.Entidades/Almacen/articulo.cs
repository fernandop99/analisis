using Sistema.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Almacen
{
   public class articulo
    {
        public int idarticulo { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public String codigo_articilo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "maximo 50 caracteres")]
        public String nombre_articulo { get; set; }

        public decimal venta_articulo { get; set; }

        public float stock_articulo { get; set; }

        [StringLength(50, ErrorMessage = "maximo 50 caracteres")]
        public String descripcion_articulo { get; set; }

        public int condicion_articulo { get; set; }

        public int idmarca { get; set; }
        //realcion con la tabla categorias  
        public Categoria Categoria { get; set; }
    }
}
