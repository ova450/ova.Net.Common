Imports System.IO
Imports System.Text.Json
Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports ova.Common.Core.DomainService.SqlService

Namespace Model

    'Public Class EventFullElementConfig : Inherits EntityConfigAbstract(Of EventFullElement)

    'End Class

    Public Class EventObjectConfig : Inherits EntityConfigAbstract(Of EventObject)

        Private Sub EventObjectConfig_FileNotFound(sender As Object, filename As String, innerexception As FileNotFoundException) Handles Me.FileNotFound
            Console.WriteLine($"Initial file not found, filename: {filename}")
        End Sub

        Private Sub EventObjectConfig_FileIsIncorrect(sender As Object, filename As String, innerexception As JsonException) Handles Me.FileIsIncorrect
            Console.WriteLine($"Initial file is incorrect, filename: {filename}")
            Throw innerexception
        End Sub

    End Class


    Public Class EventProcessConfig : Inherits EntityConfigAbstract(Of EventProcess)

        Private Sub EventProcessConfig_FileNotFound(sender As Object, filename As String, innerexception As FileNotFoundException) Handles Me.FileNotFound
            Console.WriteLine($"Initial file not found, filename: {filename}")
        End Sub

        Private Sub EventProcessConfig_FileIsIncorrect(sender As Object, filename As String, innerexception As JsonException) Handles Me.FileIsIncorrect
            Console.WriteLine($"Initial file is incorrect, filename: {filename}")
            'Throw innerexception
        End Sub

    End Class

    Public Class EventStageConfig : Inherits EntityConfigAbstract(Of EventStage)

        Private Sub EventStageConfig_FileIsIncorrect(sender As Object, filename As String, innerexception As JsonException) Handles Me.FileIsIncorrect
            Console.WriteLine($"Initial file is incorrect, filename: {filename}")
        End Sub

        Private Sub EventStageConfig_FileNotFound(sender As Object, filename As String, innerexception As FileNotFoundException) Handles Me.FileNotFound
            Console.WriteLine($"Initial file not found, filename: {filename}")
        End Sub
    End Class

End Namespace
