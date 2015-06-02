namespace UniversityLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        InstructorID = c.Int(nullable: false, identity: true),
                        FirstMidName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(maxLength: 100),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InstructorID);
            
            AddColumn("dbo.Course", "Instructor_InstructorID", c => c.Int());
            AddForeignKey("dbo.Course", "Instructor_InstructorID", "dbo.Instructor", "InstructorID");
            CreateIndex("dbo.Course", "Instructor_InstructorID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Course", new[] { "Instructor_InstructorID" });
            DropForeignKey("dbo.Course", "Instructor_InstructorID", "dbo.Instructor");
            DropColumn("dbo.Course", "Instructor_InstructorID");
            DropTable("dbo.Instructor");
        }
    }
}
