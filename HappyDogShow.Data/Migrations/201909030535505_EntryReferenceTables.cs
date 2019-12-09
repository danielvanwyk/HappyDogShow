namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntryReferenceTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DisciplineClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discipline_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_ID)
                .Index(t => t.Discipline_ID);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DisciplineGrades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discipline_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_ID)
                .Index(t => t.Discipline_ID);
            
            CreateTable(
                "dbo.DisciplineSizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discipline_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_ID)
                .Index(t => t.Discipline_ID);
            
            CreateTable(
                "dbo.DogShows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShowDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DisciplineSizes", "Discipline_ID", "dbo.Disciplines");
            DropForeignKey("dbo.DisciplineGrades", "Discipline_ID", "dbo.Disciplines");
            DropForeignKey("dbo.DisciplineClasses", "Discipline_ID", "dbo.Disciplines");
            DropIndex("dbo.DisciplineSizes", new[] { "Discipline_ID" });
            DropIndex("dbo.DisciplineGrades", new[] { "Discipline_ID" });
            DropIndex("dbo.DisciplineClasses", new[] { "Discipline_ID" });
            DropTable("dbo.DogShows");
            DropTable("dbo.DisciplineSizes");
            DropTable("dbo.DisciplineGrades");
            DropTable("dbo.Disciplines");
            DropTable("dbo.DisciplineClasses");
            DropTable("dbo.Clubs");
        }
    }
}
