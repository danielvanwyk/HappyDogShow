namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowBreedJudges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShowBreedJudges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Breed_ID = c.Int(),
                        DogShow_ID = c.Int(),
                        Judge_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Breeds", t => t.Breed_ID)
                .ForeignKey("dbo.DogShows", t => t.DogShow_ID)
                .ForeignKey("dbo.Judges", t => t.Judge_ID)
                .Index(t => t.Breed_ID)
                .Index(t => t.DogShow_ID)
                .Index(t => t.Judge_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShowBreedJudges", "Judge_ID", "dbo.Judges");
            DropForeignKey("dbo.ShowBreedJudges", "DogShow_ID", "dbo.DogShows");
            DropForeignKey("dbo.ShowBreedJudges", "Breed_ID", "dbo.Breeds");
            DropIndex("dbo.ShowBreedJudges", new[] { "Judge_ID" });
            DropIndex("dbo.ShowBreedJudges", new[] { "DogShow_ID" });
            DropIndex("dbo.ShowBreedJudges", new[] { "Breed_ID" });
            DropTable("dbo.ShowBreedJudges");
        }
    }
}
