Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders

Namespace DomainService.SqlService

    <CodeAnalysis.SuppressMessage("Style", "IDE1006:Стили именования", Justification:="<Ожидание>")>
    Module fileinitial

        Private initialsubdirectory As String = "initial"
        Private suffix As String = "Initial"
        Private fileextension As String = "json"


        Private Function begin() As String
            Return $"{AppDomain.CurrentDomain.BaseDirectory}{initialsubdirectory}\" : End Function

        Private Function ending() As String
            Return $"{suffix}.{fileextension}" : End Function

        <Extension>
        Public Function name(typebuilder As EntityTypeBuilder) As String
            Return $"{begin()}{typebuilder.Metadata.ShortName}{ending()}".Replace("/", "\") : End Function

    End Module

    Public MustInherit Class ContextAbstract : Inherits DbContext

        Private typebuilder As EntityTypeBuilder

        Private ReadOnly ImplementedInterfacesPredicateAny As Func(Of Type, Boolean) = Function(t) (Not t.IsInterface AndAlso
            t.GetTypeInfo.ImplementedInterfaces.Any(Function(i) i.Name = "IEntityBase") AndAlso
            t.IsClass AndAlso
            Not t.IsAbstract AndAlso
            Not t.IsNested)

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            MyBase.OnModelCreating(modelBuilder)
            modelBuilder.ApplyConfigurationsFromAssembly(asm)
            For Each definetype As Type In asm.DefinedTypes.Where(ImplementedInterfacesPredicateAny).AsQueryable
                typebuilder = modelBuilder.Entity(definetype)     ' entity creating
                Console.WriteLine($"filename: {typebuilder.name}")
                InitialFromJsonAsync(typebuilder, Array.CreateInstance(definetype, 0), InitialFileStream())   ' entity initial
            Next
        End Sub

        Private Function InitialFileStream() As FileStream
            Dim fn As String = typebuilder.name
            Return If(File.Exists(fn), New FileStream(fn, FileMode.Open), FileNotFound())
        End Function

        Private Function FileNotFound()
            Dim fn As String = typebuilder.name
            Console.WriteLine($"Initial file not found: {fn}")
            Return Nothing
        End Function

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            MyBase.OnConfiguring(optionsBuilder)
            optionsBuilder.UseSqlServer(cnn.ToString)
        End Sub

    End Class

End Namespace