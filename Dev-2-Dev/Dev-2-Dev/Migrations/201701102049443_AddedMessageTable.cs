namespace Dev_2_Dev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMessageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        ToUserId = c.Int(nullable: false),
                        FromUserId = c.Int(),
                        Message = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Users", t => t.FromUserId)
                .ForeignKey("dbo.Users", t => t.ToUserId, cascadeDelete: true)
                .Index(t => t.ToUserId)
                .Index(t => t.FromUserId);
            
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ToUserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "FromUserId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "FromUserId" });
            DropIndex("dbo.Messages", new[] { "ToUserId" });
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            DropTable("dbo.Messages");
        }
    }
}
