using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Informacion
{
    public class Email
    {
        public int Id_Email { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "el numero maximo de caracteres es de 50")]
        public string email { get; set; }


    }
}
