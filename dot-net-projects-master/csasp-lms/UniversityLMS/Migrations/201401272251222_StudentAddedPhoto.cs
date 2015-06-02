namespace UniversityLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentAddedPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Photo");
        }
    }
}
