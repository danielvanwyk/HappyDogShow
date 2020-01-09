namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BreedChallengeResults : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BreedChallengeResults",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntryNumber = c.String(),
                        Placing = c.String(),
                        Breed_ID = c.Int(),
                        BreedChallenge_ID = c.Int(),
                        DogShow_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Breeds", t => t.Breed_ID)
                .ForeignKey("dbo.BreedChallenges", t => t.BreedChallenge_ID)
                .ForeignKey("dbo.DogShows", t => t.DogShow_ID)
                .Index(t => t.Breed_ID)
                .Index(t => t.BreedChallenge_ID)
                .Index(t => t.DogShow_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BreedChallengeResults", "DogShow_ID", "dbo.DogShows");
            DropForeignKey("dbo.BreedChallengeResults", "BreedChallenge_ID", "dbo.BreedChallenges");
            DropForeignKey("dbo.BreedChallengeResults", "Breed_ID", "dbo.Breeds");
            DropIndex("dbo.BreedChallengeResults", new[] { "DogShow_ID" });
            DropIndex("dbo.BreedChallengeResults", new[] { "BreedChallenge_ID" });
            DropIndex("dbo.BreedChallengeResults", new[] { "Breed_ID" });
            DropTable("dbo.BreedChallengeResults");
        }
    }
}
