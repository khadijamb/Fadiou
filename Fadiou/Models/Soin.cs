using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fadiou.Models
{
    public class Soin 
    {
        [Key]
        public int IdSoin { get; set; }

        public DateTime DateSoin { get; set; }

        public String Description { get; set; }

        [Display(Name ="Description")]
        public int IdMedoc { get; set; }
       
        public int IdConsult { get; set; }
        [ForeignKey("IdConsult")]
        public virtual Consultation Consultation { get; set; }
        
    }
}