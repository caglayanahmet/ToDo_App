namespace ToDo_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCancelledAddedToTodoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todoes", "IsCanceled");
        }
    }
}
