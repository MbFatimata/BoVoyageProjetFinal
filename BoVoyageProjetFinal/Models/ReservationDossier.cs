using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Models
{
    [Table(name: "ReservationDossiers")]
    public class ReservationDossier : BaseModel
    {
        [Display(Name = "Assurance")]
        public bool Insurance { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Numéro carte bancaire")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Prix total")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Voyage")]
        public int TravelID { get; set; }

        [ForeignKey("TravelID")]
        public Travel Travel { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Client")]
        public int ClientID { get; set; }

        [ForeignKey("ClientID")]
        public Client Client { get; set; }

        public ICollection<Participant> Participants { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Etat du dossier de réservation")]
        public int ReservationDossierStatus { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Raison de l'annulation du dossier")]
        public int ReasonCancellationDossier { get; set; }
    }
}