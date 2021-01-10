Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Text.Json
Imports System.Xml
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports ova.Common.Core.Domain.Model

Namespace DomainService.SqlService

    Public MustInherit Class EntityConfigAbstract(Of T As {Class, IEntityBase}) : Implements IEntityTypeConfiguration(Of T)

        Private ReadOnly PrimaryKeys() As String = {"Id"}

        Public Sub New() : End Sub

        Public Sub New(ParamArray primarykeys() As String)
            Me.PrimaryKeys.Union(primarykeys)
        End Sub

        Public Sub Configure(builder As EntityTypeBuilder(Of T)) Implements IEntityTypeConfiguration(Of T).Configure
            Relations(builder)
            InitialFromJson(builder)
        End Sub

        Public MustOverride Sub Relations(builder As EntityTypeBuilder(Of T))

        Public Overridable Async Sub InitialFromJson(builder As EntityTypeBuilder(Of T), Optional subdirectory As String = "initial", Optional suffix As String = "Initial", Optional filenameextension As String = "json")
            Dim fn As String = $"{AppDomain.CurrentDomain.BaseDirectory}{subdirectory}\{GetType(T).Name}{suffix }.{filenameextension}"
            fn = fn.Replace("/", "\")
            If Not File.Exists(fn) Then Exit Sub
            Using fs As FileStream = New FileStream(fn, FileMode.OpenOrCreate)
                Dim Items As T() = Await JsonSerializer.DeserializeAsync(Of T())(fs)
                builder.HasData(Items)
            End Using
        End Sub

    End Class
End Namespace