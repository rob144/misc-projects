Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions

Public Class ProjectLogContext

    Inherits DbContext

    Public Property Projects As DbSet(Of Project)
    Public Property Workers As DbSet(Of Worker)

    Public Sub New()
        Me.Configuration.ProxyCreationEnabled = True
        Me.Configuration.AutoDetectChangesEnabled = True
        Me.Configuration.LazyLoadingEnabled = True
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)

        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()

        modelBuilder.Entity(Of Worker)().HasMany(Function(w) w.Projects) _
            .WithMany(Function(p) p.Workers) _
            .Map(Function(x) x.MapLeftKey("WorkerID").MapRightKey("ProjectID") _
                     .ToTable("WorkerProject"))

        'modelBuilder.Entity(Of Project)().[Property](Function(p) p.DateFinished).IsOptional()

        MyBase.OnModelCreating(modelBuilder)

    End Sub

    Public Property Users As DbSet(Of User)
End Class
