namespace Dev_2_Dev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTutorTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Mentee", newName: "Mentees");
            RenameTable(name: "dbo.Mentor", newName: "Mentors");
            CreateTable(
                "dbo.Tutors",
                c => new
                    {
                        TutorId = c.Int(nullable: false, identity: true),
                        MentorId = c.Int(),
                        MenteeId = c.Int(),
                    })
                .PrimaryKey(t => t.TutorId)
                .ForeignKey("dbo.Mentees", t => t.MenteeId)
                .ForeignKey("dbo.Mentors", t => t.MentorId)
                .Index(t => new { t.MentorId, t.MenteeId }, unique: true, name: "IX_MentorMentee");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutors", "MentorId", "dbo.Mentors");
            DropForeignKey("dbo.Tutors", "MenteeId", "dbo.Mentees");
            DropIndex("dbo.Tutors", "IX_MentorMentee");
            DropTable("dbo.Tutors");
            RenameTable(name: "dbo.Mentors", newName: "Mentor");
            RenameTable(name: "dbo.Mentees", newName: "Mentee");
        }
    }
}
