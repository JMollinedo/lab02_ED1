using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab02_ED1.Models
{
    public class Country 
    {
        /*[Key]
        public int Id { get; set; }*/

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Requerido")]
        [Display(Name = "Grupo")]
        public char Group { get; set; }



        
    }
}