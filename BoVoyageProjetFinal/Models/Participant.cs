using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Models
{
    [Table(name: "Participants")]

    public class Participant : Person
    {
        public double Reduction { get; set; }

        public int ReservationDossierID { get; set; }

        [ForeignKey("ReservationDossierID")]
        public ReservationDossier ReservationDossier { get; set; }
    }
}