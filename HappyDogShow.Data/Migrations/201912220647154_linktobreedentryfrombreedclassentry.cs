namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linktobreedentryfrombreedclassentry : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BreedClassEntries", name: "BreedEntry_ID", newName: "Entry_ID");
            RenameIndex(table: "dbo.BreedClassEntries", name: "IX_BreedEntry_ID", newName: "IX_Entry_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BreedClassEntries", name: "IX_Entry_ID", newName: "IX_BreedEntry_ID");
            RenameColumn(table: "dbo.BreedClassEntries", name: "Entry_ID", newName: "BreedEntry_ID");
        }
    }
}
