namespace LuthierWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerMessages",
                c => new
                    {
                        CustomerMessageId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 50),
                        CustomerSurname = c.String(nullable: false, maxLength: 50),
                        CustomerEmail = c.String(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 50),
                        Message = c.String(nullable: false, maxLength: 300),
                        SentAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerMessageId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false, maxLength: 18),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 50),
                        Value = c.String(nullable: false, maxLength: 300),
                        SentAt = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Guitars",
                c => new
                    {
                        GuitarId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 40),
                        NrOfStrings = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GuitarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Messages", new[] { "CustomerId" });
            DropTable("dbo.Guitars");
            DropTable("dbo.Messages");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerMessages");
        }
    }
}
