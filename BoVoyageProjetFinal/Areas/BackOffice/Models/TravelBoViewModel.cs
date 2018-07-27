using BoVoyageProjetFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Areas.BackOffice.Models
{
    public class TravelBOViewModel
    {
        [Display(Name = "Date de départ")]
        [DataType(DataType.Date)]
        public DateTime? DepartureDate { get; set; }

        [Display(Name = "Date de retour")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "Tarif tout compris")]
        [DataType(DataType.Currency)]
        public decimal? AllInclusivePrice { get; set; }

        public IEnumerable<Travel> TravelsBO { get; set; }
    }
}