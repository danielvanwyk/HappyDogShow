namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BreedClassesMoreChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BreedClasses", "BreedEntry_ID", "dbo.BreedEntries");
            DropIndex("dbo.BreedClasses", new[] { "BreedEntry_ID" });
            CreateTable(
                "dbo.BreedClassEntries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Result = c.String(),
                        Class_ID = c.Int(),
                        BreedEntry_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BreedClasses", t => t.Class_ID)
                .ForeignKey("dbo.BreedEntries", t => t.BreedEntry_ID)
                .Index(t => t.Class_ID)
                .Index(t => t.BreedEntry_ID);
            
            AddColumn("dbo.BreedEntries", "Number", c => c.String());
            DropColumn("dbo.BreedClasses", "BreedEntry_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BreedClasses", "BreedEntry_ID", c => c.Int());
            DropForeignKey("dbo.BreedClassEntries", "BreedEntry_ID", "dbo.BreedEntries");
            DropForeignKey("dbo.BreedClassEntries", "Class_ID", "dbo.BreedClasses");
            DropIndex("dbo.BreedClassEntries", new[] { "BreedEntry_ID" });
            DropIndex("dbo.BreedClassEntries", new[] { "Class_ID" });
            DropColumn("dbo.BreedEntries", "Number");
            DropTable("dbo.BreedClassEntries");
            CreateIndex("dbo.BreedClasses", "BreedEntry_ID");
            AddForeignKey("dbo.BreedClasses", "BreedEntry_ID", "dbo.BreedEntries", "ID");
        }
    }
}
