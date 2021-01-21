Imports System.IO
Imports System.Reflection
Imports System.Text.Json
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports ova.Common.Core.Domain.Model
Imports ova.Common.Core.Model

Namespace DomainService.SqlService

    'Public Class EntityType

    '    Private etb As EntityTypeBuilder

    '    Sub New(entityeypebuilder As EntityTypeBuilder)
    '        etb = entityeypebuilder
    '    End Sub

    '    Public Function ArrayTypes()
    '        Return GetType(tp).MakeArrayType()
    '    End Function

    'End Class

    Public Module EntityInstall ' (Of T As {Class, IEntityBase}) ': Implements IEntityTypeConfiguration(Of T)

        'Private ReadOnly PrimaryKeys() As String = {"Id"}


        'Public Sub New(ParamArray primarykeys() As String)
        '    Me.PrimaryKeys.Union(primarykeys)
        'End Sub

        'Public Sub Configure(builder As EntityTypeBuilder(Of T)) Implements IEntityTypeConfiguration(Of T).Configure
        '    Relations(builder)
        '    InitialFromJson(builder)
        'End Sub

        'Public Async Sub InitialFromJson(builder As EntityTypeBuilder, et As IEntityBase, Optional subdirectory As String = "initial", Optional suffix As String = "Initial", Optional filenameextension As String = "json")
        Public Async Sub InitialFromJson(builder As EntityTypeBuilder, typeinfo As TypeInfo, Optional subdirectory As String = "initial", Optional suffix As String = "Initial", Optional filenameextension As String = "json")
            Dim fn As String = $"{AppDomain.CurrentDomain.BaseDirectory}{subdirectory}\{builder.Metadata.ShortName}{suffix }.{filenameextension}"
            fn = fn.Replace("/", "\")
            If Not File.Exists(fn) Then
                FileNotFound(builder, fn, Nothing)
                Exit Sub
            End If

            'Dim et As EventObject ' = typeinfo

            Using fs As FileStream = New FileStream(fn, FileMode.OpenOrCreate)
                Dim Items As EventObject() '= GetType(et).MakeArrayType()
                Try
                    Items = Await JsonSerializer.DeserializeAsync(fs, GetType(EventObject))
                    builder.HasData(Items)
                Catch ex As JsonException
                    FileIsIncorrect(builder, GetType(EventObject).Name, ex)
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            End Using

        End Sub


        Private Sub FileIsIncorrect(sender As Object, filename As String, innerexception As JsonException)
            Console.Write($"Initial file is incorrect, filename: {filename}")
            Console.WriteLine($", message: {innerexception.Message}")
        End Sub
        Private Sub FileNotFound(sender As Object, filename As String, innerexception As FileNotFoundException)
            Console.WriteLine($"Initial file not found, filename: {filename}")
        End Sub

    End Module

End Namespace