using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Ventas
{
    public class venta
    {
        public int idventa { get; set; }
        [Required]
        public String tipo_comprobante_venta { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "el numero maximo de caracteres es de 10 digitos")]
        public String serie_comprobante { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "el numero maximo de caracteres es de 10 digitos")]
        public String num_comprobante_venta { get; set; }
        [Requiered]
        public DateTime fecha_hora_venta { get; set; }

        public decimal impuesto { get; set; }

        public decimal total { get; set; }

        public int condicion_venta { get; set; }

        //realcion con la tabla usuario
        public usuario Usuarios { get; set; }

        //realcion con la tabla persona
        public persona personas { get; set; }
    }
}
