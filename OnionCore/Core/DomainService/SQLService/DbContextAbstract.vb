Imports System.Reflection
Imports Microsoft.EntityFrameworkCore

Namespace DomainService.SqlService

    Public MustInherit Class DbContextAbstract : Inherits DbContext

        Private ImplementedInterfacesPredicateAny As Func(Of Type, Boolean) = Function(t) (Not t.IsInterface AndAlso
            t.GetTypeInfo.ImplementedInterfaces.Any(Function(i) i.Name = "IEntityBase") AndAlso
            t.IsClass AndAlso
            Not t.IsAbstract AndAlso
            Not t.IsNested)

        Private Function Entities() As IQueryable(Of TypeInfo)

            Dim ents As IQueryable(Of TypeInfo) = asm.DefinedTypes.Where(ImplementedInterfacesPredicateAny).AsQueryable
            Console.WriteLine($"Assembly Fullname: {asm.FullName}")

            Dim assm As Assembly = Assembly.GetExecutingAssembly : Console.WriteLine($"GetExecutingAssembly: {assm.GetName}")
            assm = Assembly.GetCallingAssembly : Console.WriteLine($"GetCallingAssembly: {assm.GetName}")
            assm = Assembly.GetEntryAssembly : Console.WriteLine($"GetEntryAssembly: {assm.GetName}")

            For Each ent In ents
                Console.WriteLine($"{ent.Namespace}: {ent.Name}")
            Next

            Return ents

        End Function

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            MyBase.OnModelCreating(modelBuilder)

            For Each definetype As TypeInfo In Entities()
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