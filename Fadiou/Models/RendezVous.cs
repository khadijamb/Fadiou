using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fadiou.Models
{
    public class RendezVous
    {
        [Key]
        public int IdRdv { get; set; }

        public int NumRdv { get; set; }
        public DateTime DateRdv { get; set; }

        [Display(Name = "Objet")]
        public string ObjetRdv { get; set; }
        
        public int IdPatient { get; set; }
        [ForeignKey("IdPatient")]
        public virtual Patient patient { get; set; }
    }
}