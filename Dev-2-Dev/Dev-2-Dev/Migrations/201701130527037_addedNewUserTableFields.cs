namespace Dev_2_Dev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNewUserTableFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Twitter", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "Linkedin", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "Facebook", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "AboutMe", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AboutMe");
            DropColumn("dbo.Users", "Facebook");
            DropColumn("dbo.Users", "Linkedin");
            DropColumn("dbo.Users", "Twitter");
        }
    }
}
