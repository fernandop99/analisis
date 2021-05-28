using Sistema.Entidades.Informacion;
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
        [Required]
        [StringLength(20, ErrorMessage = "el numero maximo de caracteres es de 20 digitos")]
        public String num_documento { get; set; }

        public int Id_Direccion { get; set; }
        public int Id_Telefono { get; set; }
        public int Id_Email { get; set; }

        //realcion con la tabla direccion  
        public Direccion Direcciones { get; set; }

        //realcion con la tabla Email  
        public Email Emails { get; set; }

        //realcion con la tabla telefono
        public Telefono Telefonos { get; set; }




    }
}
