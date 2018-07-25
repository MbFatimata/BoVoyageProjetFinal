using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageProjetFinal.Models
{
    [Table(name: "Destinations")]
    public class Destination : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [StringLength(15)]
        [Display(Name = "Continent")]
        public string Continent { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [StringLength(30)]
        [Display(Name = "Pays")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [StringLength(30)]
        [Display(Name = "Région")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }

        public ICollection<Travel> Travels { get; set; }
    }
}