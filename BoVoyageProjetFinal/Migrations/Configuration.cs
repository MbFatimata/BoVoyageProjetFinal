using BoVoyageProjetFinal.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Migrations
{
    public class Configuration : DbMigrationsConfiguration<BoVoyageDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(BoVoyageDbContext context)
        {
            /*
            context.Civilities.AddOrUpdate(
                new Models.Civility { Label = "Monsieur" },
                new Models.Civility { Label = "Madame" },
                new Models.Civility { Label = "Mademoiselle" });
                */
        }
    }
}