using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Informacion
{
        public class Departamento
        {
        [Required]
        public int Id_Depatamento { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "el numero maximo de caracteres es de 50")]
        public string Nombre_Departamento { get; set; }

        //realcion con la tabla direcciones  
        public Direccion Direcciones { get; set; }

    }
    }

