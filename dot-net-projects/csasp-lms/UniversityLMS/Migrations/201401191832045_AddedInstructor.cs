namespace UniversityLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInstructor : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Course SET CourseIDExternal = 'XXX' WHERE CourseIDExternal IS NULL");
            Sql("UPDATE dbo.Course SET Title = 'TESTCOURSE' WHERE Title IS NULL"); 

            AlterColumn("dbo.Course", "CourseIDExternal", c => c.String(nullable: false));
            AlterColumn("dbo.Course", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Course", "Title", c => c.String());
            AlterColumn("dbo.Course", "CourseIDExternal", c => c.String());
        }
    }
}
