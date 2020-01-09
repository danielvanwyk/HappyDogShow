namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HandlerChallengeResults : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HandlerChallengeResults",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntryNumber = c.String(),
                        Placing = c.String(),
                        DogShow_ID = c.Int(),
                        HandlerClass_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DogShows", t => t.DogShow_ID)
                .ForeignKey("dbo.HandlerClasses", t => t.HandlerClass_ID)
                .Index(t => t.DogShow_ID)
                .Index(t => t.HandlerClass_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HandlerChallengeResults", "HandlerClass_ID", "dbo.HandlerClasses");
            DropForeignKey("dbo.HandlerChallengeResults", "DogShow_ID", "dbo.DogShows");
            DropIndex("dbo.HandlerChallengeResults", new[] { "HandlerClass_ID" });
            DropIndex("dbo.HandlerChallengeResults", new[] { "DogShow_ID" });
            DropTable("dbo.HandlerChallengeResults");
        }
    }
}
