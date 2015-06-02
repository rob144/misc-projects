namespace UniversityLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Course", "CourseIDExternal", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Course", "CourseIDExternal", c => c.Int(nullable: false));
        }
    }
}
