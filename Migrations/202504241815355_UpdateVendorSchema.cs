namespace MVCPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVendorSchema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "Email", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Vendors", "Phone", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Vendors", "DocumentPath", c => c.String());
            AddColumn("dbo.Vendors", "BillingCity", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Vendors", "BillingState", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Vendors", "BillingCountry", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Vendors", "BillingPostalCode", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Vendors", "ShippingCity", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Vendors", "ShippingState", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Vendors", "ShippingCountry", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Vendors", "ShippingPostalCode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Vendors", "VendorType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vendors", "Salutation", c => c.String(maxLength: 10));
            AlterColumn("dbo.Vendors", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vendors", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vendors", "CompanyName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Vendors", "CompanyId", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendors", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vendors", "CompanyName", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Vendors", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Vendors", "Salutation", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "VendorType", c => c.String(nullable: false));
            DropColumn("dbo.Vendors", "ShippingPostalCode");
            DropColumn("dbo.Vendors", "ShippingCountry");
            DropColumn("dbo.Vendors", "ShippingState");
            DropColumn("dbo.Vendors", "ShippingCity");
            DropColumn("dbo.Vendors", "BillingPostalCode");
            DropColumn("dbo.Vendors", "BillingCountry");
            DropColumn("dbo.Vendors", "BillingState");
            DropColumn("dbo.Vendors", "BillingCity");
            DropColumn("dbo.Vendors", "DocumentPath");
            DropColumn("dbo.Vendors", "Phone");
            DropColumn("dbo.Vendors", "Email");
        }
    }
}
