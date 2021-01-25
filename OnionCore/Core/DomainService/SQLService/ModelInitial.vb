Imports System.IO
Imports System.Text.Json
Imports Microsoft.EntityFrameworkCore.Metadata.Builders


Namespace DomainService.SqlService

    Public Module ModelInitial

        Public Async Function InitialFromJsonAsync(builder As EntityTypeBuilder, entityarray As Array, filestream As FileStream) As Task(Of Boolean)
            Dim result As Boolean = False
            If filestream IsNot Nothing Then
                Try
                    Using fs As FileStream = filestream
                        Dim Items As Object() = Await JsonSerializer.DeserializeAsync(fs, entityarray.GetType)
                        Console.WriteLine($"{Items.GetType.FullName }")
                        If Items IsNot Nothing Then
                            builder.HasData(Items)
                            ConsoleWriteline(Items)
                            result = True
                        End If
                    End Using
                Catch ex As JsonException : FileIsIncorrect(builder, entityarray.ToString, ex)
                Catch ex As Exception : Console.WriteLine(ex.Message)
                End Try
            End If
            Return result
        End Function

        Private Sub ConsoleWriteline(items As Object)
            For Each item In items
                Console.WriteLine($"type={item.GetType.Name}, name={item.id}.{item.Name}")
            Next
        End Sub

        Private Sub FileIsIncorrect(sender As Object, filename As String, innerexception As JsonException)
            Console.Write($"Initial file is incorrect, filename: {filename}")
            Console.WriteLine($", message: {innerexception.Message}")
        End Sub

    End Module

End Namespace