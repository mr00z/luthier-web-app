namespace LuthierWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "UserName", c => c.String());
        }
    }
}
