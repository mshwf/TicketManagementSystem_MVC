namespace TicketManagementSystem_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColNameChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketNumber = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        LaptopModelNumber = c.String(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        TicketDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TicketNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
        }
    }
}
