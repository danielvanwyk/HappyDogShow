namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DogRegistrations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegisrationNumber = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        RegisteredName = c.String(),
                        Qualifications = c.String(),
                        ChipOrTattooNumber = c.String(),
                        Sire = c.String(),
                        Dam = c.String(),
                        BredBy = c.String(),
                        Colour = c.String(),
                        Breed_ID = c.Int(),
                        Gender_ID = c.Int(),
                        RegisteredOwner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Breeds", t => t.Breed_ID)
                .ForeignKey("dbo.Genders", t => t.Gender_ID)
                .ForeignKey("dbo.Owners", t => t.RegisteredOwner_ID)
                .Index(t => t.Breed_ID)
                .Index(t => t.Gender_ID)
                .Index(t => t.RegisteredOwner_ID);
            
            CreateTable(
                "dbo.Genders",
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Titles", t => t.Title_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.Title_ID);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DogRegistrations", "RegisteredOwner_ID", "dbo.Owners");
            DropForeignKey("dbo.Owners", "Title_ID", "dbo.Titles");
            DropForeignKey("dbo.Owners", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.DogRegistrations", "Gender_ID", "dbo.Genders");
            DropForeignKey("dbo.DogRegistrations", "Breed_ID", "dbo.Breeds");
            DropIndex("dbo.Owners", new[] { "Title_ID" });
            DropIndex("dbo.Owners", new[] { "Address_ID" });
            DropIndex("dbo.DogRegistrations", new[] { "RegisteredOwner_ID" });
            DropIndex("dbo.DogRegistrations", new[] { "Gender_ID" });
            DropIndex("dbo.DogRegistrations", new[] { "Breed_ID" });
            DropTable("dbo.Titles");
            DropTable("dbo.Owners");
            DropTable("dbo.Genders");
            DropTable("dbo.DogRegistrations");
            DropTable("dbo.Breeds");
            DropTable("dbo.Addresses");
        }
    }
}
