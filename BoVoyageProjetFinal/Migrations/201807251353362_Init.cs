namespace BoVoyageProjetFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Civilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false, maxLength: 15),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(),
                        Address = c.String(nullable: false, maxLength: 100),
                        Telephone = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        CivilityID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Civilities", t => t.CivilityID, cascadeDelete: false)
                .Index(t => t.CivilityID);
            
            CreateTable(
                "dbo.ContactMessages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Lastname = c.String(nullable: false, maxLength: 50),
                        Firstname = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Continent = c.String(nullable: false, maxLength: 15),
                        Country = c.String(nullable: false, maxLength: 30),
                        Region = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Travels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartureDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        AvailablePlaces = c.Int(nullable: false),
                        AllInclusivePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TravelAgencyID = c.Int(nullable: false),
                        DestinationID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Destinations", t => t.DestinationID, cascadeDelete: false)
                .ForeignKey("dbo.TravelAgencies", t => t.TravelAgencyID, cascadeDelete: false)
                .Index(t => t.TravelAgencyID)
                .Index(t => t.DestinationID);
            
            CreateTable(
                "dbo.TravelAgencies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Reduction = c.Double(nullable: false),
                        ReservationDossierID = c.Int(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(),
                        Address = c.String(nullable: false, maxLength: 100),
                        Telephone = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        CivilityID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Civilities", t => t.CivilityID, cascadeDelete: false)
                .ForeignKey("dbo.ReservationDossiers", t => t.ReservationDossierID, cascadeDelete: false)
                .Index(t => t.ReservationDossierID)
                .Index(t => t.CivilityID);
            
            CreateTable(
                "dbo.ReservationDossiers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Insurance = c.Boolean(nullable: false),
                        CreditCardNumber = c.String(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TravelID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        ReservationDossierStatus = c.Int(nullable: false),
                        ReasonCancellationDossier = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: false)
                .ForeignKey("dbo.Travels", t => t.TravelID, cascadeDelete: false)
                .Index(t => t.TravelID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Salesmen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(),
                        Address = c.String(nullable: false, maxLength: 100),
                        Telephone = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        CivilityID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Civilities", t => t.CivilityID, cascadeDelete: false)
                .Index(t => t.CivilityID);
            
            CreateTable(
                "dbo.TravelFiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 254),
                        ContentType = c.String(nullable: false, maxLength: 100),
                        Content = c.Binary(nullable: false),
                        TravelID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Travels", t => t.TravelID, cascadeDelete: false)
                .Index(t => t.TravelID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TravelFiles", "TravelID", "dbo.Travels");
            DropForeignKey("dbo.Salesmen", "CivilityID", "dbo.Civilities");
            DropForeignKey("dbo.ReservationDossiers", "TravelID", "dbo.Travels");
            DropForeignKey("dbo.Participants", "ReservationDossierID", "dbo.ReservationDossiers");
            DropForeignKey("dbo.ReservationDossiers", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Participants", "CivilityID", "dbo.Civilities");
            DropForeignKey("dbo.Travels", "TravelAgencyID", "dbo.TravelAgencies");
            DropForeignKey("dbo.Travels", "DestinationID", "dbo.Destinations");
            DropForeignKey("dbo.Clients", "CivilityID", "dbo.Civilities");
            DropIndex("dbo.TravelFiles", new[] { "TravelID" });
            DropIndex("dbo.Salesmen", new[] { "CivilityID" });
            DropIndex("dbo.ReservationDossiers", new[] { "ClientID" });
            DropIndex("dbo.ReservationDossiers", new[] { "TravelID" });
            DropIndex("dbo.Participants", new[] { "CivilityID" });
            DropIndex("dbo.Participants", new[] { "ReservationDossierID" });
            DropIndex("dbo.Travels", new[] { "DestinationID" });
            DropIndex("dbo.Travels", new[] { "TravelAgencyID" });
            DropIndex("dbo.Clients", new[] { "CivilityID" });
            DropTable("dbo.TravelFiles");
            DropTable("dbo.Salesmen");
            DropTable("dbo.ReservationDossiers");
            DropTable("dbo.Participants");
            DropTable("dbo.TravelAgencies");
            DropTable("dbo.Travels");
            DropTable("dbo.Destinations");
            DropTable("dbo.ContactMessages");
            DropTable("dbo.Clients");
            DropTable("dbo.Civilities");
        }
    }
}
