namespace Dev_2_Dev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMentorSkills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mentors",
                c => new
                    {
                        MentorId = c.Int(nullable: false, identity: true),
                        MentorSkillId = c.Int(nullable: false),
                        MentorUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MentorId)
                .ForeignKey("dbo.Skills", t => t.MentorSkillId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.MentorUserId, cascadeDelete: true)
                .Index(t => t.MentorSkillId)
                .Index(t => t.MentorUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mentors", "MentorUserId", "dbo.Users");
            DropForeignKey("dbo.Mentors", "MentorSkillId", "dbo.Skills");
            DropIndex("dbo.Mentors", new[] { "MentorUserId" });
            DropIndex("dbo.Mentors", new[] { "MentorSkillId" });
            DropTable("dbo.Mentors");
        }
    }
}
