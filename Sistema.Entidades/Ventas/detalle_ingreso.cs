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
    }
}
