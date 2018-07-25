using BoVoyageProjetFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoVoyageProjetFinal.Data
{
    public class BoVoyageDbContext : DbContext
    {
        public BoVoyageDbContext() : base("BoVoyageDb")
        {
        }
        
        public DbSet<Civility> Civilities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ReservationDossier> ReservationDossiers { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<TravelAgency> TravelAgencies { get; set; }
        public DbSet<TravelFile> TravelFiles { get; set; }




    }
}