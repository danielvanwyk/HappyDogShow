namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BreedGroupChallengeResults : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BreedGroupChallengeResults",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntryNumber = c.String(),
                        Placing = c.String(),
                        BreedGroup_ID = c.Int(),
                        BreedGroupChallenge_ID = c.Int(),
                        DogShow_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BreedGroups", t => t.BreedGroup_ID)
                .ForeignKey("dbo.BreedGroupChallenges", t => t.BreedGroupChallenge_ID)
                .ForeignKey("dbo.DogShows", t => t.DogShow_ID)
                .Index(t => t.BreedGroup_ID)
                .Index(t => t.BreedGroupChallenge_ID)
                .Index(t => t.DogShow_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BreedGroupChallengeResults", "DogShow_ID", "dbo.DogShows");
            DropForeignKey("dbo.BreedGroupChallengeResults", "BreedGroupChallenge_ID", "dbo.BreedGroupChallenges");
            DropForeignKey("dbo.BreedGroupChallengeResults", "BreedGroup_ID", "dbo.BreedGroups");
            DropIndex("dbo.BreedGroupChallengeResults", new[] { "DogShow_ID" });
            DropIndex("dbo.BreedGroupChallengeResults", new[] { "BreedGroupChallenge_ID" });
            DropIndex("dbo.BreedGroupChallengeResults", new[] { "BreedGroup_ID" });
            DropTable("dbo.BreedGroupChallengeResults");
        }
    }
}
