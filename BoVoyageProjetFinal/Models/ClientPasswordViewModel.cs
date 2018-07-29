using BoVoyageProjetFinal.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Models
{
    public class ClientPasswordViewModel : BaseModel
    {
            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Mot de passe")]
            [DataType(DataType.Password)]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "{0} incorrect.")]
            public string Password { get; set; }

            [Display(Name = "Confirmation du mot de passe")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Erreur sur la {0}.")]
            public string ConfirmedPassword { get; set; }
    }
}