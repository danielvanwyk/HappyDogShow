namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowHandlerJudges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShowHandlerClassJudges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DogShow_ID = c.Int(),
                        HandlerClass_ID = c.Int(),
                        Judge_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DogShows", t => t.DogShow_ID)
                .ForeignKey("dbo.HandlerClasses", t => t.HandlerClass_ID)
                .ForeignKey("dbo.Judges", t => t.Judge_ID)
                .Index(t => t.DogShow_ID)
                .Index(t => t.HandlerClass_ID)
                .Index(t => t.Judge_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShowHandlerClassJudges", "Judge_ID", "dbo.Judges");
            DropForeignKey("dbo.ShowHandlerClassJudges", "HandlerClass_ID", "dbo.HandlerClasses");
            DropForeignKey("dbo.ShowHandlerClassJudges", "DogShow_ID", "dbo.DogShows");
            DropIndex("dbo.ShowHandlerClassJudges", new[] { "Judge_ID" });
            DropIndex("dbo.ShowHandlerClassJudges", new[] { "HandlerClass_ID" });
            DropIndex("dbo.ShowHandlerClassJudges", new[] { "DogShow_ID" });
            DropTable("dbo.ShowHandlerClassJudges");
        }
    }
}
