using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Ventas
{
    public class ingreso
    {
        public int idingreso { get; set; }
        [Required]


        public String tipo_comprobante_ingreso { get; set; }

        public String serie_comprobante_ingreso { get; set; }

        public String num_comprobante_ingreso { get; set; }

        public DateTime fecha_hora_ingreso { get; set; }

        public decimal impuesto_ingreso { get; set; }

        public decimal total_ingreso { get; set; }

        public venta venta
        {
            get => default;
            set
            {
            }
        }

        public detalle_ingreso detalle_ingreso
        {
            get => default;
            set
            {
            }
        }

        public detalle_ingreso detalle_ingreso1
        {
            get => default;
            set
            {
            }
        }
    }
}
