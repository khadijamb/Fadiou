using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fadiou.Models
{
    public class Ordonnance
    {
        [Key]
        public int IdOrd { get; set; }

       
        public DateTime DateOrd { get; set; }

       public int IdDetailOrd { get; set; }
        [ForeignKey("IdDetailOrd")]
        public virtual DetailsOrdonnance  DetailsOrdonnance {get;set;}

    }
}