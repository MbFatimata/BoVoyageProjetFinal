using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageProjetFinal.Models
{
    [Table(name: "ContactMessages")]
    public class ContactMessage : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Nom")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Le champ {0} obligatoire")]
        [Display(Name = "Prénom")]
        [StringLength(15, ErrorMessage = "Le champ est trop long")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "L'adresse mail n'est pas au bon format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Message { get; set; }
    }
}