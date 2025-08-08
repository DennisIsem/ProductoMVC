using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EjercicioMVC.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Precio Q")]
        public decimal Precio { get; set; }
        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Display(Name = "Fecha de alta")]
        public DateTime FechaDeAlta { get; set; }
    }
}