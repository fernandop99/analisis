using Sistema.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Usuarios
{
    public class persona
    {
        public int idpersona { get; set; }
       

        public int tipo_persona { get; set; }
        [Requiered]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe de tener maximo de 30 caracteres, y no menos de 3 caracteres.")]
        public String nombre { get; set; }

        public String tipo_documento { get; set; }

        public String num_documento { get; set; }

        public String direccion { get; set; }

        public String telefono { get; set; } // este debe de cambiar

        public String email { get; set; }

        public ICollection<ingreso> ingresos { get; set; }

        public ICollection<venta> ventas { get; set; }

        public usuario Usuarios
        {
            get => default;
            set
            {
            }
        }

        public usuario Usuarios1
        {
            get => default;
            set
            {
            }
        }

        public usuario Usuarios2
        {
            get => default;
            set
            {
            }
        }
    }
}
