using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models
{
    public class Matricula
    {
        [Key]
        [Display(Name = "ID matrícula")]
        public int Id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "El carnet debe tener 12 dígitos")]
        public string Alumno { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "El código del curso debe tener 5 caracteres")]
        public string CodigoCurso { get; set; }

        

    }
}