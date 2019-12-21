namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BreedClasses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Owners", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.Owners", "Title_ID", "dbo.Titles");
            DropIndex("dbo.Owners", new[] { "Address_ID" });
            DropIndex("dbo.Owners", new[] { "Title_ID" });
            CreateTable(
                "dbo.BreedClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MinAgeInMonths = c.Int(nullable: false),
                        MaxAgeInMonths = c.Int(nullable: false),
                        BreedEntry_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BreedEntries", t => t.BreedEntry_ID)
                .Index(t => t.BreedEntry_ID);
            
            CreateTable(
                "dbo.BreedEntries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Dog_ID = c.Int(),
                        Show_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DogRegistrations", t => t.Dog_ID)
                .ForeignKey("dbo.DogShows", t => t.Show_ID)
                .Index(t => t.Dog_ID)
                .Index(t => t.Show_ID);
            
            DropTable("dbo.Addresses");
            DropTable("dbo.Owners");
            DropTable("dbo.Titles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Initials = c.String(),
                        KUSARegistrationNumber = c.String(),
                        Address_ID = c.Int(),
                        Title_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AddressDetail = c.String(),
                        PostalCode = c.String(),
                        TelNumber = c.String(),
                        CellNumber = c.String(),
                        FaxNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.BreedEntries", "Show_ID", "dbo.DogShows");
            DropForeignKey("dbo.BreedEntries", "Dog_ID", "dbo.DogRegistrations");
            DropForeignKey("dbo.BreedClasses", "BreedEntry_ID", "dbo.BreedEntries");
            DropIndex("dbo.BreedEntries", new[] { "Show_ID" });
            DropIndex("dbo.BreedEntries", new[] { "Dog_ID" });
            DropIndex("dbo.BreedClasses", new[] { "BreedEntry_ID" });
            DropTable("dbo.BreedEntries");
            DropTable("dbo.BreedClasses");
            CreateIndex("dbo.Owners", "Title_ID");
            CreateIndex("dbo.Owners", "Address_ID");
            AddForeignKey("dbo.Owners", "Title_ID", "dbo.Titles", "ID");
            AddForeignKey("dbo.Owners", "Address_ID", "dbo.Addresses", "ID");
        }
    }
}
