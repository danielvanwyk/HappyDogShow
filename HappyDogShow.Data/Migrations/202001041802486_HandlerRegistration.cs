namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HandlerRegistration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HandlerRegistrations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Title = c.String(),
                        FirstName = c.String(),
                        Address = c.String(),
                        PostalCode = c.String(),
                        Tel = c.String(),
                        Cell = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Sex_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sexes", t => t.Sex_ID)
                .Index(t => t.Sex_ID);
            
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HandlerRegistrations", "Sex_ID", "dbo.Sexes");
            DropIndex("dbo.HandlerRegistrations", new[] { "Sex_ID" });
            DropTable("dbo.Sexes");
            DropTable("dbo.HandlerRegistrations");
        }
    }
}
