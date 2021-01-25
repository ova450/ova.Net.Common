Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports ova.Common.Core.Domain.Model

Namespace DomainService.SqlService

    Public Class EntityConfig(Of T As {Class, IEntityBase}) : Implements IEntityTypeConfiguration(Of T)

        Private ReadOnly PrimaryKeys() As String = {"Id"}

        Public Sub New(ParamArray primarykeys() As String)
            Me.PrimaryKeys.Union(primarykeys)
        End Sub

        Public Sub Configure(builder As EntityTypeBuilder(Of T)) Implements IEntityTypeConfiguration(Of T).Configure
            Relations(builder)
            'InitialFromJson(builder)
        End Sub

        Public Overridable Sub Relations(builder As EntityTypeBuilder(Of T))
        End Sub

        'Public Overridable Async Sub InitialFromJson(builder As EntityTypeBuilder(Of T), Optional subdirectory As String = "initial", Optional suffix As String = "Initial", Optional filenameextension As String = "json")
        '    Dim fn As String = $"{AppDomain.CurrentDomain.BaseDirectory}{subdirectory}\{GetType(T).Name}{suffix }.{filenameextension}"
        '    fn = fn.Replace("/", "\")
        '    If Not File.Exists(fn) Then
        '        RaiseEvent FileNotFound(Me, fn, Nothing)
        '        Exit Sub
        '    End If

        '    If LevelInitialValidation(Of T)() = 0 Then
        '        Using fs As FileStream = New FileStream(fn, FileMode.OpenOrCreate)
        '            Dim Items As T()
        '            Try
        '                Items = Await JsonSerializer.DeserializeAsync(Of T())(fs)
        '                builder.HasData(Items)
        '            Catch ex As Exception
        '                RaiseEvent FileIsIncorrect(Me, fn, ex)
        '            End Try
        '            Console.WriteLine($"{builder.GetType.Name}")
        '        End Using
        '    End If

        'End Sub

        'Private Function LevelInitialValidation(Of TT)() As Integer
        '    Dim check As New EntityLevelInitialAttribute
        '    Return If(GetType(TT).GetCustomAttributes(False).FirstOrDefault(Function(e) e.GetType.Equals(check.GetType)), New EntityLevelInitialAttribute(0))
        'End Function

        'Private Sub EventObjectConfig_FileNotFound(sender As Object, filename As String, innerexception As FileNotFoundException) Handles Me.FileNotFound
        '    Console.WriteLine($"Initial file not found, filename: {filename}")
        'End Sub

        'Private Sub EventObjectConfig_FileIsIncorrect(sender As Object, filename As String, innerexception As JsonException) Handles Me.FileIsIncorrect
        '    Console.WriteLine($"Initial file is incorrect, filename: {filename}")
        '    Throw innerexception
        'End Sub



        ''Delegate Sub FileIsIncorrectEventHandler(sender As Object, filename As String, innerexception As JsonException)
        ''Delegate Sub FileNotFoundEventHandler(sender As Object, filename As String, innerexception As FileNotFoundException)
        'Public Event FileNotFound As FileNotFoundEventHandler
        'Public Event FileIsIncorrect As FileIsIncorrectEventHandler

    End Class

End Namespace