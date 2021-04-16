﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Usuarios
{
    public class Rol
    {
        public int idrol { get; set; }
        [Requiered]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe de tener maximo de 30 caracteres, y no menos de 3 caracteres.")]

        public String nombre { get; set; }
        [StringLength(100, ErrorMessage = "La direccion  su tamaño maximo es de 100 caracteres.")]

        public String direccion { get; set; }

        public bool condicion { get; set; }
    }
}
