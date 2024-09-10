namespace RFID_Device_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RfidDevices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceName = c.String(),
                        DeviceType = c.String(),
                        UniqueIdentifier = c.String(),
                        Location = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RfidTagReads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        ReadTimestamp = c.DateTime(nullable: false),
                        Location = c.String(),
                        ReaderId = c.String(),
                        RfidDevice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RfidDevices", t => t.RfidDevice_Id)
                .Index(t => t.RfidDevice_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        PasswordHash = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RfidTagReads", "RfidDevice_Id", "dbo.RfidDevices");
            DropIndex("dbo.RfidTagReads", new[] { "RfidDevice_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.RfidTagReads");
            DropTable("dbo.RfidDevices");
        }
    }
}
