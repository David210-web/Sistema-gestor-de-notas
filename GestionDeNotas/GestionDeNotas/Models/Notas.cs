using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDeNotas.Models
{
    public class Notas
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "El carnet debe tener 12 dígitos")]
        public string CarnetAlumno { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "El código de materia debe tener 5 caracteres")]
        public string CodigoMateria { get; set; }

        [Required]
        public decimal Nota1 { get; set; }

        [Required]
        public decimal Nota2 { get; set; }

        [Required]
        public decimal Nota3 { get; set; }

        public decimal NotaPromedio { get; set; }

  
    }
}