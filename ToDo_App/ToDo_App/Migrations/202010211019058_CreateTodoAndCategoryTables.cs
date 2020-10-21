namespace ToDo_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTodoAndCategoryTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Todoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Duration = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        TodoUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TodoUser_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.TodoUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "TodoUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Todoes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Todoes", new[] { "TodoUser_Id" });
            DropIndex("dbo.Todoes", new[] { "CategoryId" });
            DropTable("dbo.Todoes");
            DropTable("dbo.Categories");
        }
    }
}
