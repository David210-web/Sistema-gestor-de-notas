using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models
{
    public class Alumnos
    {
        [Key]
        [Display(Name = "Carnet")]
        [Required]
        [StringLength(12,MinimumLength = 12, ErrorMessage = "El carnet debe tener 12 digitos")]
        public string Carnet {  get; set; }
        [Required]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "El nombre debe de estar entre 3 y 50 caracteres")]
        public string Nombres { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El apellido debe de estar entre 3 y 50 caracteres")]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "El genero debe de estar entre 7 y 15 caracteres")]
        public string Genero { get; set; }
        
    }
}