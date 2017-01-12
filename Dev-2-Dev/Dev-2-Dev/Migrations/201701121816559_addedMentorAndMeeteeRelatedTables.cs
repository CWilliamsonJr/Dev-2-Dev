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
                "dbo.Mentee",
                c => new
                    {
                        MenteeId = c.Int(nullable: false, identity: true),
                        MenteeUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenteeId)
                .ForeignKey("dbo.Users", t => t.MenteeUserId, cascadeDelete: true)
                .Index(t => t.MenteeUserId);
            
            CreateTable(
                "dbo.MenteeSkills",
                c => new
                    {
                        MenteeId = c.Int(nullable: false, identity: true),
                        MenteeSkillId = c.Int(nullable: false),
                        MenteeUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenteeId)
                .ForeignKey("dbo.Mentee", t => t.MenteeUserId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.MenteeSkillId, cascadeDelete: true)
                .Index(t => t.MenteeSkillId)
                .Index(t => t.MenteeUserId);
            
            CreateTable(
                "dbo.MentorSkills",
                c => new
                    {
                        MentorId = c.Int(nullable: false, identity: true),
                        MentorSkillId = c.Int(nullable: false),
                        MentorUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MentorId)
                .ForeignKey("dbo.Mentor", t => t.MentorUserId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.MentorSkillId, cascadeDelete: true)
                .Index(t => t.MentorSkillId)
                .Index(t => t.MentorUserId);
            
            CreateTable(
                "dbo.Mentor",
                c => new
                    {
                        MentorId = c.Int(nullable: false, identity: true),
                        MentorUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MentorId)
                .ForeignKey("dbo.Users", t => t.MentorUserId, cascadeDelete: true)
                .Index(t => t.MentorUserId);
            
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ToUserId", "dbo.Users");
            DropForeignKey("dbo.Mentee", "MenteeUserId", "dbo.Users");
            DropForeignKey("dbo.MentorSkills", "MentorSkillId", "dbo.Skills");
            DropForeignKey("dbo.Mentor", "MentorUserId", "dbo.Users");
            DropForeignKey("dbo.MentorSkills", "MentorUserId", "dbo.Mentor");
            DropForeignKey("dbo.MenteeSkills", "MenteeSkillId", "dbo.Skills");
            DropForeignKey("dbo.MenteeSkills", "MenteeUserId", "dbo.Mentee");
            DropForeignKey("dbo.Messages", "FromUserId", "dbo.Users");
            DropIndex("dbo.Mentor", new[] { "MentorUserId" });
            DropIndex("dbo.MentorSkills", new[] { "MentorUserId" });
            DropIndex("dbo.MentorSkills", new[] { "MentorSkillId" });
            DropIndex("dbo.MenteeSkills", new[] { "MenteeUserId" });
            DropIndex("dbo.MenteeSkills", new[] { "MenteeSkillId" });
            DropIndex("dbo.Mentee", new[] { "MenteeUserId" });
            DropIndex("dbo.Messages", new[] { "FromUserId" });
            DropIndex("dbo.Messages", new[] { "ToUserId" });
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            DropTable("dbo.Mentor");
            DropTable("dbo.MentorSkills");
            DropTable("dbo.MenteeSkills");
            DropTable("dbo.Mentee");
            DropTable("dbo.Messages");
        }
    }
}
