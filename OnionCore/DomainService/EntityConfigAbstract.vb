Imports System.IO
Imports System.Reflection
Imports System.Runtime.Serialization.Json
Imports Microsoft.EntityFrameworkCore

Namespace Domain.Config

    Public MustInherit Class EntityConfigAbstract(Of T As Class)
        Implements IEntityTypeConfiguration(Of T)

        Private ReadOnly PrimaryKeys() As String = {"Id"}
        'Public Property AppConfig As IConfigurationRoot

        Public Sub New(ParamArray primarykeys() As String)
            Me.PrimaryKeys.Union(primarykeys)
        End Sub

        Public Sub Configure(builder As Metadata.Builders.EntityTypeBuilder(Of T)) Implements IEntityTypeConfiguration(Of T).Configure
            builder.HasKey(PrimaryKeys)
            Relations(builder)
            EntityInitial(builder)
        End Sub

        Public Overridable Sub Relations(builder As Metadata.Builders.EntityTypeBuilder(Of T)) : End Sub

        Public Sub EntityInitial(builder As Metadata.Builders.EntityTypeBuilder(Of T))
            Dim fn As String = $"{AppDomain.CurrentDomain.BaseDirectory}entityinitial/{GetType(T).Name}.json"
            Dim Items As T() = {}
            Dim JsonFormatter As DataContractJsonSerializer = New DataContractJsonSerializer(Items.GetType)
            If File.Exists(fn) Then
                Dim fs As FileStream = New FileStream(fn, FileMode.OpenOrCreate)
                Using (fs)
                    Dim json = JsonFormatter.ReadObject(fs)
                    Items = json
                    builder.HasData(Items)
                End Using
            End If
        End Sub

    End Class

End Namespace