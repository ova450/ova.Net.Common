Imports System.Reflection
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration

Namespace DomainService.Sql
    Public MustInherit Class SqlDbContextAbstract : Inherits DbContext

        Private ReadOnly Property AppConfig As IConfiguration
        Private ReadOnly Property ConnectionStringName As String


        Sub New(appconfig As IConfigurationRoot, connectionstringname As String)
            MyBase.New
            _AppConfig = appconfig
            _ConnectionStringName = connectionstringname

            Database.EnsureCreated()

        End Sub

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            optionsBuilder.UseSqlServer(AppConfig.GetConnectionString(ConnectionStringName))
        End Sub

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)

            For Each assm As Assembly In AppDomain.CurrentDomain.GetAssemblies
                modelBuilder.ApplyConfigurationsFromAssembly(assm)
            Next

            MyBase.OnModelCreating(modelBuilder)

        End Sub

    End Class
End Namespace