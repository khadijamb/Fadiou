using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fadiou.Models
{
    public class Medicament
    {
        [Key]
        public int IdMedoc { get; set; }

        [Display(Name = "Médicament")]
        public String NomMedoc { get; set; }
    }
}