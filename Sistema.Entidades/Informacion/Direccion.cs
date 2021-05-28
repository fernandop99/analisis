using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Informacion
{
   public class Direccion
    {
        [Required]
        public int Id_Direccion { get; set; }
        [Required]
        public int Id_Municipio { get; set; }

        [StringLength(50, ErrorMessage = "el numero maximo de caracteres es de 50")]
        public string Avenida { get; set; }
 
        public int Zona { get; set; }


        public int Num_Casa { get; set; }

        [StringLength(256, ErrorMessage = "el numero maximo de caracteres es de 256")]
        public string Otros { get; set; }


        //realcion con la tabla municipio  
        public Municipio Municipios { get; set; }
    }
}

