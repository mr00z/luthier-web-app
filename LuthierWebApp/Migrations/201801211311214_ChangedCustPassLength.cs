namespace LuthierWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCustPassLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 18));
        }
    }
}
