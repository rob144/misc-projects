namespace UniversityLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredFieldsInstructorStudent : DbMigration
    {
        public override void Up()
        {
            Sql("update Student set FirstMidName = 'temp' where FirstMidName = null");

            AlterColumn("dbo.Student", "FirstMidName", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "EmailAddress", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Instructor", "FirstMidName", c => c.String(nullable: false));
            AlterColumn("dbo.Instructor", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Instructor", "EmailAddress", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instructor", "EmailAddress", c => c.String(maxLength: 100));
            AlterColumn("dbo.Instructor", "LastName", c => c.String());
            AlterColumn("dbo.Instructor", "FirstMidName", c => c.String());
            AlterColumn("dbo.Student", "EmailAddress", c => c.String(maxLength: 100));
            AlterColumn("dbo.Student", "LastName", c => c.String());
            AlterColumn("dbo.Student", "FirstMidName", c => c.String());
        }
    }
}
