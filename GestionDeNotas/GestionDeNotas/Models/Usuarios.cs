using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models
{
    public class Usuarios
    {
        [Key]
        [Display(Name = "Carnet")]
        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "El carnet debe tener 12 dígitos")]
        public string Carnet { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La contraseña debe tener entre 5 y 50 caracteres")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El rol debe tener entre 5 y 20 caracteres")]
        public string Rol { get; set; }

    }
}