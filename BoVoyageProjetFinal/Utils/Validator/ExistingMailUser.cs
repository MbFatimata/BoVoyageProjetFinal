using BoVoyageProjetFinal.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Utils.Validator
{
    public class ExistingMailUser : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            using (BoVoyageDbContext db = new BoVoyageDbContext())
            {
                return !db.Clients.Any(x => x.Mail == value.ToString());
            }
        }
    }
}