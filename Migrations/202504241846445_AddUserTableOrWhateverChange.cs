namespace MVCPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTableOrWhateverChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
