namespace ToDo_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotationsAddedToToDosTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Todoes", "TodoUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Todoes", new[] { "TodoUser_Id" });
            AlterColumn("dbo.Todoes", "TodoUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Todoes", "TodoUser_Id");
            AddForeignKey("dbo.Todoes", "TodoUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "TodoUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Todoes", new[] { "TodoUser_Id" });
            AlterColumn("dbo.Todoes", "TodoUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Todoes", "TodoUser_Id");
            AddForeignKey("dbo.Todoes", "TodoUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
