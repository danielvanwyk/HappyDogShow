namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InShowChallengeJudges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShowInShowChallengeJudges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DogShow_ID = c.Int(),
                        Judge_ID = c.Int(),
                        ShowChallenge_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DogShows", t => t.DogShow_ID)
                .ForeignKey("dbo.Judges", t => t.Judge_ID)
                .ForeignKey("dbo.ShowChallenges", t => t.ShowChallenge_ID)
                .Index(t => t.DogShow_ID)
                .Index(t => t.Judge_ID)
                .Index(t => t.ShowChallenge_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShowInShowChallengeJudges", "ShowChallenge_ID", "dbo.ShowChallenges");
            DropForeignKey("dbo.ShowInShowChallengeJudges", "Judge_ID", "dbo.Judges");
            DropForeignKey("dbo.ShowInShowChallengeJudges", "DogShow_ID", "dbo.DogShows");
            DropIndex("dbo.ShowInShowChallengeJudges", new[] { "ShowChallenge_ID" });
            DropIndex("dbo.ShowInShowChallengeJudges", new[] { "Judge_ID" });
            DropIndex("dbo.ShowInShowChallengeJudges", new[] { "DogShow_ID" });
            DropTable("dbo.ShowInShowChallengeJudges");
        }
    }
}
