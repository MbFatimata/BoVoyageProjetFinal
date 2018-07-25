using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Models
{
    public class AuthenticationClientLoginViewModel
    {
        [Display(Name = "Adresse Email")]
        [Required(ErrorMessage = "le champ {0} est obligatoire")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                   ErrorMessage = "L'adresse mail n'est pas au bon format")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}