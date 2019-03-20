using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fadiou.Models
{
    public class DetailsOrdonnance
    {
        [Key]
        public int IdDetailOrd { get; set; }

        public int IdMedoc { get; set; }
        [ForeignKey("IdMedoc")]
        public virtual ICollection<Medicament> ListMedocs {get;set;}

    }
}