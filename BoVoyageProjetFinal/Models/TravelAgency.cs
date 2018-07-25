using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Models
{
    [Table(name: "TravelAgencies")]
    public class TravelAgency : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [StringLength(30)]
        [Display(Name = "Agence de voyage")]
        public string Name { get; set; }

        public ICollection<Travel> Travels { get; set; }
    }
}