Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class Init
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Project",
                Function(c) New With
                    {
                        .ProjectID = c.Int(nullable := False, identity := True),
                        .Title = c.String(maxLength := 100),
                        .Description = c.String(maxLength := 500),
                        .Status = c.Int(nullable := False),
                        .DateCreated = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ProjectID)
            
            CreateTable(
                "dbo.Worker",
                Function(c) New With
                    {
                        .WorkerID = c.Int(nullable := False, identity := True),
                        .FirstName = c.String(nullable := False, maxLength := 50),
                        .LastName = c.String(nullable := False, maxLength := 50),
                        .EmailAddress = c.String(nullable := False, maxLength := 100)
                    }) _
                .PrimaryKey(Function(t) t.WorkerID)
            
            CreateTable(
                "dbo.User",
                Function(c) New With
                    {
                        .UserID = c.Int(nullable := False, identity := True),
                        .UserName = c.String(nullable := False, maxLength := 20),
                        .EmailAddress = c.String(nullable := False, maxLength := 100),
                        .Password = c.String(nullable := False, maxLength := 20)
                    }) _
                .PrimaryKey(Function(t) t.UserID)
            
            CreateTable(
                "dbo.WorkerProject",
                Function(c) New With
                    {
                        .WorkerID = c.Int(nullable := False),
                        .ProjectID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.WorkerID, t.ProjectID }) _
                .ForeignKey("dbo.Worker", Function(t) t.WorkerID, cascadeDelete := True) _
                .ForeignKey("dbo.Project", Function(t) t.ProjectID, cascadeDelete := True) _
                .Index(Function(t) t.WorkerID) _
                .Index(Function(t) t.ProjectID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.WorkerProject", New String() { "ProjectID" })
            DropIndex("dbo.WorkerProject", New String() { "WorkerID" })
            DropForeignKey("dbo.WorkerProject", "ProjectID", "dbo.Project")
            DropForeignKey("dbo.WorkerProject", "WorkerID", "dbo.Worker")
            DropTable("dbo.WorkerProject")
            DropTable("dbo.User")
            DropTable("dbo.Worker")
            DropTable("dbo.Project")
        End Sub
    End Class
End Namespace
