namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BreedClassOrderOfJudging : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BreedClasses", "JudgingOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BreedClasses", "JudgingOrder");
        }
    }
}
