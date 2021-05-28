using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Ventas
{
    public class ingreso
    {

        public int Id_Usuario { get; set; }
        public int idingreso { get; set; }
        [Required]
        public String tipo_comprobante_ingreso { get; set; }
        [Required]
        [StringLength(7, ErrorMessage = "el maximo de caracteres es de 7 digitos")]
        public String serie_comprobante_ingreso { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "el maximo de caracteres es de 10 digitos")]
        public String num_comprobante_ingreso { get; set; }
        [Required]
        public DateTime fecha_hora_ingreso { get; set; }

        public decimal impuesto_ingreso { get; set; }

        public decimal total_ingreso { get; set; }

        //realcion con la tabla persona
        public persona Personas { get; set; }

        //realcion con la tabla usuario
        public usuario Usuarios { get; set; }

        //realcion con la tabla telefono
        public detalle_ingreso Detalles_Ingresos { get; set; }

    }
}
