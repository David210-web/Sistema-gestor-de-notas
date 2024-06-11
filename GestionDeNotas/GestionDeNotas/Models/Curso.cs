using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models
{
    public class Curso
    {
        [Key]
        [Display(Name = "Código de curso")]
        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "El código del curso debe tener 5 caracteres")]
        public string CodigoCurso { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "El carnet debe tener 12 dígitos")]
        public string CarnetDocente { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "El código de materia debe tener 5 caracteres")]
        public string CodigoMateria { get; set; }

        public string NombrDocente {  get; set; }

        [Required]
        public int Seccion { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "La hora debe tener entre 3 y 20 caracteres")]
        public string Hora { get; set; }

        public int CantidadPersonas {  get; set; }

        public string Materia {  get; set; }

      
    }
}