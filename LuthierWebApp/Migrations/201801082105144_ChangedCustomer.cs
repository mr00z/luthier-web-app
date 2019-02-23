namespace LuthierWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ConfirmPassword", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "UserName");
            DropColumn("dbo.Customers", "ConfirmPassword");
        }
    }
}
