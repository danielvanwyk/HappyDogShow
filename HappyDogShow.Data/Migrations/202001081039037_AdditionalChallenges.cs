namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalChallenges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BreedChallenges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        JudgingOrder = c.Int(nullable: false),
                        BreedGroupChallenge_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BreedGroupChallenges", t => t.BreedGroupChallenge_ID)
                .Index(t => t.BreedGroupChallenge_ID);
            
            CreateTable(
                "dbo.BreedGroupChallenges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        JudgingOrder = c.Int(nullable: false),
                        ShowChallenge_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ShowChallenges", t => t.ShowChallenge_ID)
                .Index(t => t.ShowChallenge_ID);
            
            CreateTable(
                "dbo.ShowChallenges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        JudgingOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BreedGroupChallenges", "ShowChallenge_ID", "dbo.ShowChallenges");
            DropForeignKey("dbo.BreedChallenges", "BreedGroupChallenge_ID", "dbo.BreedGroupChallenges");
            DropIndex("dbo.BreedGroupChallenges", new[] { "ShowChallenge_ID" });
            DropIndex("dbo.BreedChallenges", new[] { "BreedGroupChallenge_ID" });
            DropTable("dbo.ShowChallenges");
            DropTable("dbo.BreedGroupChallenges");
            DropTable("dbo.BreedChallenges");
        }
    }
}
