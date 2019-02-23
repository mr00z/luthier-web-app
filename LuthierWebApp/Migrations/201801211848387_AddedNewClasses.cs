namespace LuthierWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Luthiers",
                c => new
                    {
                        LuthierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Specialization = c.String(),
                        EmployedAt = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.LuthierId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        LuthierId = c.Int(nullable: false),
                        GuitarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Guitars", t => t.GuitarId, cascadeDelete: true)
                .ForeignKey("dbo.Luthiers", t => t.LuthierId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.LuthierId)
                .Index(t => t.GuitarId);
            
            DropTable("dbo.CustomerMessages");
        }
        
        public override void Down()
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
            
            DropForeignKey("dbo.Orders", "LuthierId", "dbo.Luthiers");
            DropForeignKey("dbo.Orders", "GuitarId", "dbo.Guitars");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "GuitarId" });
            DropIndex("dbo.Orders", new[] { "LuthierId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Luthiers");
        }
    }
}
