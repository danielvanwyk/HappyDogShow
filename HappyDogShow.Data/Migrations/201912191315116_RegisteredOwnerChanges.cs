namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisteredOwnerChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DogRegistrations", "RegisteredOwner_ID", "dbo.Owners");
            DropIndex("dbo.DogRegistrations", new[] { "RegisteredOwner_ID" });
            AddColumn("dbo.DogRegistrations", "RegisteredOwnerSurname", c => c.String());
            AddColumn("dbo.DogRegistrations", "RegisteredOwnerTitle", c => c.String());
            AddColumn("dbo.DogRegistrations", "RegisteredOwnerInitials", c => c.String());
            AddColumn("dbo.DogRegistrations", "RegisteredOwnerAddress", c => c.String());
            AddColumn("dbo.DogRegistrations", "RegisteredOwnerPostalCode", c => c.String());
            AddColumn("dbo.DogRegistrations", "RegisteredOwnerKUSANo", c => c.String());
            AddColumn("dbo.DogRegistrations", "RegisteredOwnerTel", c => c.String());
            AddColumn("dbo.DogRegistrations", "RegisteredOwnerCell", c => c.String());
            AddColumn("dbo.DogRegistrations", "RegisteredOwnerFax", c => c.String());
            AddColumn("dbo.DogRegistrations", "RegisteredOwnerEmail", c => c.String());
            DropColumn("dbo.DogRegistrations", "RegisteredOwner_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DogRegistrations", "RegisteredOwner_ID", c => c.Int());
            DropColumn("dbo.DogRegistrations", "RegisteredOwnerEmail");
            DropColumn("dbo.DogRegistrations", "RegisteredOwnerFax");
            DropColumn("dbo.DogRegistrations", "RegisteredOwnerCell");
            DropColumn("dbo.DogRegistrations", "RegisteredOwnerTel");
            DropColumn("dbo.DogRegistrations", "RegisteredOwnerKUSANo");
            DropColumn("dbo.DogRegistrations", "RegisteredOwnerPostalCode");
            DropColumn("dbo.DogRegistrations", "RegisteredOwnerAddress");
            DropColumn("dbo.DogRegistrations", "RegisteredOwnerInitials");
            DropColumn("dbo.DogRegistrations", "RegisteredOwnerTitle");
            DropColumn("dbo.DogRegistrations", "RegisteredOwnerSurname");
            CreateIndex("dbo.DogRegistrations", "RegisteredOwner_ID");
            AddForeignKey("dbo.DogRegistrations", "RegisteredOwner_ID", "dbo.Owners", "ID");
        }
    }
}
