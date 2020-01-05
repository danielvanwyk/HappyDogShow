namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HandlerEntries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HandlerClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MinAgeInYears = c.Int(nullable: false),
                        MaxAgeInYears = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HandlerEntries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Dog_ID = c.Int(),
                        EnteredClass_ID = c.Int(),
                        Handler_ID = c.Int(),
                        Show_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DogRegistrations", t => t.Dog_ID)
                .ForeignKey("dbo.HandlerClasses", t => t.EnteredClass_ID)
                .ForeignKey("dbo.HandlerRegistrations", t => t.Handler_ID)
                .ForeignKey("dbo.DogShows", t => t.Show_ID)
                .Index(t => t.Dog_ID)
                .Index(t => t.EnteredClass_ID)
                .Index(t => t.Handler_ID)
                .Index(t => t.Show_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HandlerEntries", "Show_ID", "dbo.DogShows");
            DropForeignKey("dbo.HandlerEntries", "Handler_ID", "dbo.HandlerRegistrations");
            DropForeignKey("dbo.HandlerEntries", "EnteredClass_ID", "dbo.HandlerClasses");
            DropForeignKey("dbo.HandlerEntries", "Dog_ID", "dbo.DogRegistrations");
            DropIndex("dbo.HandlerEntries", new[] { "Show_ID" });
            DropIndex("dbo.HandlerEntries", new[] { "Handler_ID" });
            DropIndex("dbo.HandlerEntries", new[] { "EnteredClass_ID" });
            DropIndex("dbo.HandlerEntries", new[] { "Dog_ID" });
            DropTable("dbo.HandlerEntries");
            DropTable("dbo.HandlerClasses");
        }
    }
}
