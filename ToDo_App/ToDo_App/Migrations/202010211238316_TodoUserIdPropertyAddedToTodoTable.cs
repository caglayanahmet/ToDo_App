namespace ToDo_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoUserIdPropertyAddedToTodoTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Todoes", name: "TodoUser_Id", newName: "TodoUserId");
            RenameIndex(table: "dbo.Todoes", name: "IX_TodoUser_Id", newName: "IX_TodoUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Todoes", name: "IX_TodoUserId", newName: "IX_TodoUser_Id");
            RenameColumn(table: "dbo.Todoes", name: "TodoUserId", newName: "TodoUser_Id");
        }
    }
}
