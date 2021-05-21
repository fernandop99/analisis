using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Informacion
{
    public class Telefono
    {
        public int Id_Telefono { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "el numero maximo de caracteres es de 11")]
        public string Tel_Personal { get; set; }


        [Required]
        [StringLength(11, ErrorMessage = "el numero maximo de caracteres es de 11")]
        public string Tel_Casa { get; set; }


    }
}
