namespace ToDo_App.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class emptymigration : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (CategoryName,Description,IsActive) VALUES('.NET', '.NET .NET Core MVC and RestAPIs', 'True')");
            Sql("INSERT INTO Categories (CategoryName,Description,IsActive) VALUES('JavaScript/jQuery', 'JavaScript and jQuery', 'True')");
            Sql("INSERT INTO Categories (CategoryName,Description,IsActive) VALUES('University Lectures', 'All the classes I am attending and home tasks', 'True')");
            Sql("INSERT INTO Categories (CategoryName,Description,IsActive) VALUES('Daily Tasks', 'Personal Tasks' , 'True')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN (1,2,3,4)");
        }
    }
}
