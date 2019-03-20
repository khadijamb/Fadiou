using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fadiou.Models
{
    public class Consultation
    {
        [Key]
        public int IdConsult { get; set; }
        public int NumConsult { get; set; }

        [MaxLength (500), Display(Name = "Diagnostique")]
        public string diagn { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Poids")]
        public double poidsPatient { get; set; }

        [ Required(ErrorMessage ="*")]
        [Display(Name = "Taille")]
        public double taillePatient { get; set; }

        public  int idPatient { get;  set; }
        [ForeignKey("idPatient")]
        public  virtual Patient patient { get; set; }

        public int idMed { get; set; }
        [ForeignKey("idMed")]
        public virtual Medecin medecin { get; set; }
    }
}