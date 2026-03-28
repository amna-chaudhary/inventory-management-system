namespace MVCPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorType = c.String(nullable: false, maxLength: 50),
                        Salutation = c.String(maxLength: 10),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        CompanyId = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 15),
                        DocumentPath = c.String(),
                        BillingCity = c.String(nullable: false, maxLength: 50),
                        BillingState = c.String(nullable: false, maxLength: 50),
                        BillingCountry = c.String(nullable: false, maxLength: 50),
                        BillingPostalCode = c.String(nullable: false, maxLength: 20),
                        ShippingCity = c.String(nullable: false, maxLength: 50),
                        ShippingState = c.String(nullable: false, maxLength: 50),
                        ShippingCountry = c.String(nullable: false, maxLength: 50),
                        ShippingPostalCode = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendors");
        }
    }
}
