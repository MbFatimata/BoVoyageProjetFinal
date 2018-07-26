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

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Agence de voyage")]
        public int TravelAgencyID { get; set; }

        [ForeignKey("TravelAgencyID")]
        public TravelAgency TravelAgency { get; set; }


        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Destination")]
        public int DestinationID { get; set; }

        [ForeignKey("DestinationID")]
        public Destination Destination { get; set; }

        public ICollection<TravelFile> Files { get; set; }
    }
}