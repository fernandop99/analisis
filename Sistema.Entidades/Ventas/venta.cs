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

        public String serie_comprobante { get; set; }

        public String num_comprobante_venta { get; set; }

        public DateTime fecha_hora_venta { get; set; }

        public decimal impuesto { get; set; }

        public decimal total { get; set; }

        public int condicion_venta { get; set; }
    }
}
