namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowBreedGroupJudges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Judges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ShowGroupJudges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BreedGroup_ID = c.Int(),
                        DogShow_ID = c.Int(),
                        Judge_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BreedGroups", t => t.BreedGroup_ID)
                .ForeignKey("dbo.DogShows", t => t.DogShow_ID)
                .ForeignKey("dbo.Judges", t => t.Judge_ID)
                .Index(t => t.BreedGroup_ID)
                .Index(t => t.DogShow_ID)
                .Index(t => t.Judge_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShowGroupJudges", "Judge_ID", "dbo.Judges");
            DropForeignKey("dbo.ShowGroupJudges", "DogShow_ID", "dbo.DogShows");
            DropForeignKey("dbo.ShowGroupJudges", "BreedGroup_ID", "dbo.BreedGroups");
            DropIndex("dbo.ShowGroupJudges", new[] { "Judge_ID" });
            DropIndex("dbo.ShowGroupJudges", new[] { "DogShow_ID" });
            DropIndex("dbo.ShowGroupJudges", new[] { "BreedGroup_ID" });
            DropTable("dbo.ShowGroupJudges");
            DropTable("dbo.Judges");
        }
    }
}
