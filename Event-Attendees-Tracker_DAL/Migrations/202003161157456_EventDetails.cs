namespace Event_Attendees_Tracker_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserMappedRoles", "Master_DBRoles_ID", "dbo.Master_DBRoles");
            DropForeignKey("dbo.UserMappedRoles", "UserDetails_ID", "dbo.tbl_UserDetails");
            DropIndex("dbo.UserMappedRoles", new[] { "Master_DBRoles_ID" });
            DropIndex("dbo.UserMappedRoles", new[] { "UserDetails_ID" });
            AlterColumn("dbo.EventDetails", "EventDate", c => c.DateTime(nullable: false));
            DropTable("dbo.UserMappedRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserMappedRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Master_DBRoles_ID = c.Int(),
                        UserDetails_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.EventDetails", "EventDate", c => c.String(nullable: false));
            CreateIndex("dbo.UserMappedRoles", "UserDetails_ID");
            CreateIndex("dbo.UserMappedRoles", "Master_DBRoles_ID");
            AddForeignKey("dbo.UserMappedRoles", "UserDetails_ID", "dbo.tbl_UserDetails", "ID");
            AddForeignKey("dbo.UserMappedRoles", "Master_DBRoles_ID", "dbo.Master_DBRoles", "ID");
        }
    }
}
