using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Models
{
    [Table(name: "Travels")]
    public class Travel : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Date de départ")]
        [DataType(DataType.Date)]
        //[Major(18, ErrorMessage = "Vous devez être majeur !!!")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Date de retour")]
        [DataType(DataType.Date)]
        //[Major(18, ErrorMessage = "Vous devez être majeur !!!")]
        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Places disponibles")]
        [Range(0, 999, ErrorMessage = "La valeur {0} doit être comprise entre {1} et {2}")]
        public int AvailablePlaces { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Tarif tout compris")]
        [DataType(DataType.Currency)]
        public decimal AllInclusivePrice{ get; set; }

        [ForeignKey("TravelAgencyId")]
        public TravelAgency TravelAgency { get; set; }
        public int TravelAgencyId { get; set; }

        [ForeignKey("DestinationId")]
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }


        public void Reserve(int places) { }
    }
}