Imports System.Reflection
Imports Microsoft.EntityFrameworkCore

Namespace DomainService.SqlService

    Public MustInherit Class ContextAbstract : Inherits DbContext

        Private ImplementedInterfacesPredicateAny As Func(Of Type, Boolean) = Function(t) (Not t.IsInterface AndAlso
            t.GetTypeInfo.ImplementedInterfaces.Any(Function(i) i.Name = "IEntityBase") AndAlso
            t.IsClass AndAlso
            Not t.IsAbstract AndAlso
            Not t.IsNested)

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            MyBase.OnModelCreating(modelBuilder)

            For Each definetype As TypeInfo In asm.DefinedTypes.Where(ImplementedInterfacesPredicateAny).AsQueryable
                modelBuilder.Entity(definetype)                                                 ' entity creating
            Next

            modelBuilder.ApplyConfigurationsFromAssembly(asm)     ' final configuration of the entity based on a separate configuration file

        End Sub

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            MyBase.OnConfiguring(optionsBuilder)
            optionsBuilder.UseSqlServer(cnn.ToString)
        End Sub

    End Class



End Namespace