namespace Dev_2_Dev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMenteeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mentees",
                c => new
                    {
                        MenteeId = c.Int(nullable: false, identity: true),
                        MenteeSkillId = c.Int(nullable: false),
                        MenteeUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenteeId)
                .ForeignKey("dbo.Skills", t => t.MenteeSkillId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.MenteeUserId, cascadeDelete: true)
                .Index(t => t.MenteeSkillId)
                .Index(t => t.MenteeUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mentees", "MenteeUserId", "dbo.Users");
            DropForeignKey("dbo.Mentees", "MenteeSkillId", "dbo.Skills");
            DropIndex("dbo.Mentees", new[] { "MenteeUserId" });
            DropIndex("dbo.Mentees", new[] { "MenteeSkillId" });
            DropTable("dbo.Mentees");
        }
    }
}
