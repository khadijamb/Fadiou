using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Fadiou.Models
{
    public class PatientViewModel
    {
           [Key]
            public int idPers { get; set; }

            [MaxLength(80, ErrorMessage = "taille maximale 80"),
                Required(ErrorMessage = "*")]
            [Display(Name = "Nom")]
            public string nomPers { get; set; }

            [MaxLength(80, ErrorMessage = "taille maximale 80"),
                Required(ErrorMessage = "*")]
            [Display(Name = "Prenom")]
            public string prenomPers { get; set; }

            [MaxLength(150, ErrorMessage = "taille maximale 150"),
                Required(ErrorMessage = "*")]
            [Display(Name = "Addresse")]
            public string adressePers { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Date de Naissances")]
            public DateTime dateNaissancePers { get; set; }

            [MaxLength(10, ErrorMessage = "taille maximale 10"),
                Required(ErrorMessage = "*")]
            [Display(Name = "Sexe")]
            public string sexePers { get; set; }

            [MaxLength(30, ErrorMessage = "taille maximale 30"),
                Required(ErrorMessage = "*")]
            [Display(Name = "CNI")]
            public string cniPers { get; set; }

            [MaxLength(40, ErrorMessage = "taille maximale 40"),
                Required(ErrorMessage = "*")]
            [Display(Name = "Situation Matrimoniale")]
            public string situationMatPers { get; set; }

            [MaxLength(80, ErrorMessage = "taille maximale 80"),
                Required(ErrorMessage = "*")]
            [Display(Name = "Email"), DataType(DataType.EmailAddress)]
            public string emailPers { get; set; }

            [MaxLength(15, ErrorMessage = "taille maximale 15"),
                Required(ErrorMessage = "*")]
            [Display(Name = "Telephone"), DataType(DataType.PhoneNumber)]
            public string telPers { get; set; }
            [Display(Name = "Poids")]
            public double? poidsPatient { get; set; }

            [Display(Name = "Taille")]
            public double? taillePatient { get; set; }

            [Display(Name = "Groupe sanguin")]
            [MinLength(1, ErrorMessage = ("Taille minimale 1")), MaxLength(3, ErrorMessage = ("Taille maximale 3")), Required(ErrorMessage = "*")]
            public string groupeSanguinPatient { get; set; }

            [Display(Name = "Profession")]
            [MaxLength(50, ErrorMessage = ("Taille maximale 50"))]
            public string ProfessionPatient { get; set; }
    }
}