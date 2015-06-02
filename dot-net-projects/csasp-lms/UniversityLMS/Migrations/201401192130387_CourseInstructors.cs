namespace UniversityLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseInstructors : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Course", "Instructor_InstructorID", "dbo.Instructor");
            DropIndex("dbo.Course", new[] { "Instructor_InstructorID" });
            CreateTable(
                "dbo.InstructorCourse",
                c => new
                    {
                        Instructor_InstructorID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_InstructorID, t.Course_CourseID })
                .ForeignKey("dbo.Instructor", t => t.Instructor_InstructorID, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Instructor_InstructorID)
                .Index(t => t.Course_CourseID);
            
            DropColumn("dbo.Course", "Instructor_InstructorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course", "Instructor_InstructorID", c => c.Int());
            DropIndex("dbo.InstructorCourse", new[] { "Course_CourseID" });
            DropIndex("dbo.InstructorCourse", new[] { "Instructor_InstructorID" });
            DropForeignKey("dbo.InstructorCourse", "Course_CourseID", "dbo.Course");
            DropForeignKey("dbo.InstructorCourse", "Instructor_InstructorID", "dbo.Instructor");
            DropTable("dbo.InstructorCourse");
            CreateIndex("dbo.Course", "Instructor_InstructorID");
            AddForeignKey("dbo.Course", "Instructor_InstructorID", "dbo.Instructor", "InstructorID");
        }
    }
}
