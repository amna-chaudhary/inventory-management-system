namespace MVCPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerType = c.String(),
                        Salutation = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DisplayName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        BillingCity = c.String(),
                        BillingState = c.String(),
                        BillingCountry = c.String(),
                        BillingPostalCode = c.String(),
                        ShippingCity = c.String(),
                        ShippingState = c.String(),
                        ShippingCountry = c.String(),
                        ShippingPostalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        SalesOrderNumber = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        ExpectedShipmentDate = c.DateTime(),
                        PaymentTerms = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerTable_Id = c.Int(),
                        CustomerTable_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerTables", t => t.CustomerTable_Id1)
                .Index(t => t.CustomerTable_Id1);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false, maxLength: 50),
                        ItemCategory = c.String(nullable: false, maxLength: 100),
                        Weight = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VendorCompany = c.String(maxLength: 255),
                        PurchaseDescription = c.String(),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalesOrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SalesOrders", t => t.SalesOrderId, cascadeDelete: true)
                .Index(t => t.SalesOrderId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesOrderItems", "SalesOrderId", "dbo.SalesOrders");
            DropForeignKey("dbo.SalesOrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SalesOrders", "CustomerTable_Id1", "dbo.CustomerTables");
            DropIndex("dbo.SalesOrderItems", new[] { "ProductId" });
            DropIndex("dbo.SalesOrderItems", new[] { "SalesOrderId" });
            DropIndex("dbo.SalesOrders", new[] { "CustomerTable_Id1" });
            DropTable("dbo.SalesOrderItems");
            DropTable("dbo.Products");
            DropTable("dbo.SalesOrders");
            DropTable("dbo.CustomerTables");
        }
    }
}
