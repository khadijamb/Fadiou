using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fadiou.Models
{
    public class Patient
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPatient { get; set; }

        [ForeignKey("idPatient")]
        public virtual Personne personne { get; set; }

       

        [Display(Name = "Groupe sanguin")]
        [MinLength(1, ErrorMessage = ("Taille minimale 1")), MaxLength(3, ErrorMessage = ("Taille maximale 3")), Required(ErrorMessage = "*")]
        public string groupeSanguinPatient { get; set; }

        [Display(Name = "Profession")]
        [MaxLength(50, ErrorMessage = ("Taille maximale 50"))]
        public string ProfessionPatient { get; set; }

 
    }
}