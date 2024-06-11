using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models
{
    public class Materia
    {
        [Key]
        [Display(Name = "Codigo de materia")]
        [Required]
        [StringLength(5,MinimumLength = 5, ErrorMessage = "El codigo de materia debe tener 5 caracteres")]
        public string CodigoMateria { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La materia debe tener entre 3 y 50 caracteres")]
        public string Nombre {  get; set; }

    }
}