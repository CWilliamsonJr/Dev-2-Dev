namespace Dev_2_Dev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMentorAndMeeteeRelatedTables : DbMigration
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
            
            CreateTable(
                "dbo.MenteeList",
                c => new
                    {
                        MenteeId = c.Int(nullable: false, identity: true),
                        MenteeUserId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MenteeId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.MenteeSkills",
                c => new
                    {
                        MentorId = c.Int(nullable: false, identity: true),
                        MentorSkillId = c.Int(nullable: false),
                        MentorUserId = c.Int(nullable: false),
                        Mentee_MenteeId = c.Int(),
                    })
                .PrimaryKey(t => t.MentorId)
                .ForeignKey("dbo.Skills", t => t.MentorSkillId, cascadeDelete: true)
                .ForeignKey("dbo.MentorList", t => t.MentorUserId, cascadeDelete: true)
                .ForeignKey("dbo.MenteeList", t => t.Mentee_MenteeId)
                .Index(t => t.MentorSkillId)
                .Index(t => t.MentorUserId)
                .Index(t => t.Mentee_MenteeId);
            
            CreateTable(
                "dbo.MentorList",
                c => new
                    {
                        MentorId = c.Int(nullable: false, identity: true),
                        MentorUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MentorId)
                .ForeignKey("dbo.Users", t => t.MentorUserId, cascadeDelete: true)
                .Index(t => t.MentorUserId);
            
            CreateTable(
                "dbo.MentorSkills",
                c => new
                    {
                        MenteeId = c.Int(nullable: false, identity: true),
                        MenteeSkillId = c.Int(nullable: false),
                        MenteeUserId = c.Int(nullable: false),
                        Mentor_MentorId = c.Int(),
                    })
                .PrimaryKey(t => t.MenteeId)
                .ForeignKey("dbo.MenteeList", t => t.MenteeUserId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.MenteeSkillId, cascadeDelete: true)
                .ForeignKey("dbo.MentorList", t => t.Mentor_MentorId)
                .Index(t => t.MenteeSkillId)
                .Index(t => t.MenteeUserId)
                .Index(t => t.Mentor_MentorId);
            
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ToUserId", "dbo.Users");
            DropForeignKey("dbo.MenteeList", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.MenteeSkills", "Mentee_MenteeId", "dbo.MenteeList");
            DropForeignKey("dbo.MenteeSkills", "MentorUserId", "dbo.MentorList");
            DropForeignKey("dbo.MentorList", "MentorUserId", "dbo.Users");
            DropForeignKey("dbo.MentorSkills", "Mentor_MentorId", "dbo.MentorList");
            DropForeignKey("dbo.MentorSkills", "MenteeSkillId", "dbo.Skills");
            DropForeignKey("dbo.MenteeSkills", "MentorSkillId", "dbo.Skills");
            DropForeignKey("dbo.MentorSkills", "MenteeUserId", "dbo.MenteeList");
            DropForeignKey("dbo.Messages", "FromUserId", "dbo.Users");
            DropIndex("dbo.MentorSkills", new[] { "Mentor_MentorId" });
            DropIndex("dbo.MentorSkills", new[] { "MenteeUserId" });
            DropIndex("dbo.MentorSkills", new[] { "MenteeSkillId" });
            DropIndex("dbo.MentorList", new[] { "MentorUserId" });
            DropIndex("dbo.MenteeSkills", new[] { "Mentee_MenteeId" });
            DropIndex("dbo.MenteeSkills", new[] { "MentorUserId" });
            DropIndex("dbo.MenteeSkills", new[] { "MentorSkillId" });
            DropIndex("dbo.MenteeList", new[] { "User_UserId" });
            DropIndex("dbo.Messages", new[] { "FromUserId" });
            DropIndex("dbo.Messages", new[] { "ToUserId" });
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            DropTable("dbo.MentorSkills");
            DropTable("dbo.MentorList");
            DropTable("dbo.MenteeSkills");
            DropTable("dbo.MenteeList");
            DropTable("dbo.Messages");
        }
    }
}
