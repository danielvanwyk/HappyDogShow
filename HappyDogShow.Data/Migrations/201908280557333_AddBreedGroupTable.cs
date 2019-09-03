namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBreedGroupTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BreedGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Breeds", "BreedGroup_ID", c => c.Int());
            CreateIndex("dbo.Breeds", "BreedGroup_ID");
            AddForeignKey("dbo.Breeds", "BreedGroup_ID", "dbo.BreedGroups", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Breeds", "BreedGroup_ID", "dbo.BreedGroups");
            DropIndex("dbo.Breeds", new[] { "BreedGroup_ID" });
            DropColumn("dbo.Breeds", "BreedGroup_ID");
            DropTable("dbo.BreedGroups");
        }
    }
}
