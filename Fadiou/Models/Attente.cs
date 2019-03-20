using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fadiou.Models
{
    public class Attente

    {
        int idAttente { get; set; }

        int idPatient { get; set; }

        [ForeignKey("idPatient")]

        Patient patient { get; set; }

        int idMed { get; set; }

        [ForeignKey("idMed")]
        Medecin medecin { get; set; }

    }
}