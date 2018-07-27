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
        [Display(Name = "Date de départ max")]
        [DataType(DataType.Date)]
        public DateTime? DepartureDateMax { get; set; }

        [Display(Name = "Date de départ min")]
        [DataType(DataType.Date)]
        public DateTime? DepartureDateMin { get; set; }

        [Display(Name = "Date de retour max")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDateMax { get; set; }

        [Display(Name = "Date de retour min")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDateMin { get; set; }

        [Display(Name = "Tarif tout compris max")]
        [DataType(DataType.Currency)]
        public decimal? AllInclusivePriceMax { get; set; }

        [Display(Name = "Tarif tout compris min")]
        [DataType(DataType.Currency)]
        public decimal? AllInclusivePriceMin { get; set; }

        [Display(Name = "Continent")]
        public string Continent { get; set; }

        [Display(Name = "Pays")]
        public string Country { get; set; }

        [Display(Name = "Region")]
        public string Region { get; set; }

        public IEnumerable<Travel> TravelsBO { get; set; }
    }
}