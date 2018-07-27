using BoVoyageProjetFinal.Controllers;
using BoVoyageProjetFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Areas.BackOffice.Models
{
    public class ClientBOViewModel : BaseController
    {
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Display(Name = "Né avant le")]
        [DataType(DataType.Date)]
        public DateTime? BirthdateBefore { get; set; }

        [Display(Name = "Né après le")]
        [DataType(DataType.Date)]
        public DateTime? BirthdateAfter { get; set; }

        [Display(Name = "Email")]
        public string Mail { get; set; }

        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }

        public IEnumerable<Client> ClientsBO { get; set; }
    }
}