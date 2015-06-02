Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports System.Linq.Expressions

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of ProjectLogContext)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As ProjectLogContext)
            '  This method will be called after migrating to the latest version.
            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.

            context.Users.AddOrUpdate(
                Function(u) u.EmailAddress,
                New User() With {.UserName = "Rob",
                                   .Password = "123",
                                   .EmailAddress = "rob@fakeemail.com"},
                New User() With {.UserName = "TestUser2",
                                   .Password = "asd",
                                   .EmailAddress = "testuser2@fakeemail.com"},
                New User() With {.UserName = "TestUser3",
                                   .Password = "asd",
                                   .EmailAddress = "testuser3@fakeemail.com"}
            )

            'If there is a Worker entity with the email address already do 
            'not add a new one.
            context.Workers.AddOrUpdate(
                Function(w) w.EmailAddress,
                New Worker() With {.FirstName = "Andrew",
                                   .LastName = "Smith",
                                   .EmailAddress = "apeters@fakeemail.com"},
                New Worker() With {.FirstName = "Brice",
                                   .LastName = "Bloggs",
                                   .EmailAddress = "blambson@fakeemail.com"},
                New Worker() With {.FirstName = "Rowan",
                                   .LastName = "Jones",
                                   .EmailAddress = "rmiller@fakeemail.com"}
            )

            context.Projects.AddOrUpdate(
                Function(p) p.Title,
                New Project() With {.Title = "Project 1",
                                     .Description = "Test project 1",
                                     .Status = ProjectStatus.Started,
                                     .DateCreated = Date.Now()},
                New Project() With {.Title = "Project 2",
                                     .Description = "Test project 2",
                                     .Status = ProjectStatus.Started,
                                     .DateCreated = Date.Now()},
                New Project() With {.Title = "Project 3",
                                     .Description = "Test project 3",
                                     .Status = ProjectStatus.Started,
                                     .DateCreated = Date.Now()}
            )

            context.SaveChanges()

        End Sub

    End Class

End Namespace
