namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowHandlerJudges2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HandlerEntries", "ShowHandlerClassJudge_ID", c => c.Int());
            CreateIndex("dbo.HandlerEntries", "ShowHandlerClassJudge_ID");
            AddForeignKey("dbo.HandlerEntries", "ShowHandlerClassJudge_ID", "dbo.ShowHandlerClassJudges", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HandlerEntries", "ShowHandlerClassJudge_ID", "dbo.ShowHandlerClassJudges");
            DropIndex("dbo.HandlerEntries", new[] { "ShowHandlerClassJudge_ID" });
            DropColumn("dbo.HandlerEntries", "ShowHandlerClassJudge_ID");
        }
    }
}
