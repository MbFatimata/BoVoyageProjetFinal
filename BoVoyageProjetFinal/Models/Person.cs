using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Models
{
    public class Person : BaseModel
    {
        public abstract class Personne : BaseModel
        {
            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Nom")]
            [StringLength(50, MinimumLength = 2,
                ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
            public string LastName { get; set; }

            [Display(Name = "Prénom")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Adresse")]
            [StringLength(100, MinimumLength = 2,
                ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
            public string Addresse { get; set; }

            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Numéro de téléphone")]
            public string Telephone { get; set; }

            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Date de naissance")]
            [DataType(DataType.Date)]
            public DateTime Birthdate { get; set; }

            [NotMapped]
            public int Age { get { return DateTime.Today.Year - DateNaissance.Year; } }

            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Civilité")]
            public int CivilityID { get; set; }

            [ForeignKey("CivilityID")]
            public Civility Civility { get; set; }
        }
    }
}