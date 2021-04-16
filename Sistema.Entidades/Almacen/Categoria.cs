using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Almacen
{
   public class Categoria
    {
        public int idcategoria { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe de tener maximo de 50 caracteres, y no menos de 3 caracteres.")]

        public String nombre { get; set; }
        [StringLength(256, ErrorMessage = "La direccion  su tamaño maximo es de 256 caracteres.")]

        public String descricion { get; set; }


        public bool condicio { get; set; }
    }
}
