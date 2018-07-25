using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Models
{
    [Table(name: "DossiersReservation")]
    public class ReservationDossier : BaseModel
    {
        [Display(Name = "Assurance")]
        public bool Assurance { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Numéro carte banquaire")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Prix total")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Voyage")]
        public int VoyageID { get; set; }

        [ForeignKey("TravelID")]
        public Travel Travel { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Client")]
        public int ClientID { get; set; }

        [ForeignKey("ClientID")]
        public Client Client { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Participant")]
        public int ParticipantID { get; set; }

        [ForeignKey("ParticipantID")]
        public Participant Participant { get; set; }
    }
}