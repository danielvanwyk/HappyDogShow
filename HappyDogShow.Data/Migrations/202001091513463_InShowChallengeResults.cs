namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InShowChallengeResults : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InShowChallengeResults",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntryNumber = c.String(),
                        Placing = c.String(),
                        DogShow_ID = c.Int(),
                        ShowChallenge_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DogShows", t => t.DogShow_ID)
                .ForeignKey("dbo.ShowChallenges", t => t.ShowChallenge_ID)
                .Index(t => t.DogShow_ID)
                .Index(t => t.ShowChallenge_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InShowChallengeResults", "ShowChallenge_ID", "dbo.ShowChallenges");
            DropForeignKey("dbo.InShowChallengeResults", "DogShow_ID", "dbo.DogShows");
            DropIndex("dbo.InShowChallengeResults", new[] { "ShowChallenge_ID" });
            DropIndex("dbo.InShowChallengeResults", new[] { "DogShow_ID" });
            DropTable("dbo.InShowChallengeResults");
        }
    }
}
