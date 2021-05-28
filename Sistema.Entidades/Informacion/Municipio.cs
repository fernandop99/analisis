using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Informacion
{
    public class Municipio
    {
        public int Id_Municipio { get; set; }
        [Required]
        [StringLength(70, ErrorMessage = "el numero maximo de caracteres es de 50")]
        public string Nombre_Municipio { get; set; }
        [Required]
        public int Id_Departamento { get; set; }

        //realcion con la tabla departamento  
        public Departamento Departamentos { get; set; }
    }

}
