Imports System.IO
Imports System.Text.Json
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports Microsoft.EntityFrameworkCore.Metadata.Internal
Imports ova.Common.Core.Domain.Model
Imports ova.Common.Logging.Events.Data
Imports ova.Common.Logging.Events.Model

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        Using dbEventsLogging = New Context
            dbEventsLogging.SaveChanges()

            'Using obj = New Repository.EventObjectRepository(dbEventsLogging)
            '    With obj
            '        '.Add(New EventObject With {.Name = "object_1"})
            '        '.Add(New EventObject With {.Name = "object_2"})
            '        '.Add(New EventObject With {.Name = "object_3"})
            '        '.Add(New EventObject With {.Name = "object_4"})
            '        '.Add(New EventObject With {.Name = "object_5"})
            '        '.Add(New EventObject With {.Name = "object_6"})
            '        '.Add(New EventObject With {.Name = $"object_{ .Id}"})
            '    End With
            '    dbEventsLogging.SaveChanges()
            '    Dim type As Type = GetType(EventObject())
            '    Dim options As New JsonSerializerOptions With {.WriteIndented = True}
            '    Dim json As String = JsonSerializer.Serialize(Of IEntityBase())(obj.GetAll.ToArray, options)
            '    Console.WriteLine(json)

            '    Dim fn As String = $"{AppDomain.CurrentDomain.BaseDirectory}initial\EventObjectInitial.json"
            '    fn = fn.Replace("/", "\")
            '    If Not File.Exists(fn) Then
            '        Console.WriteLine($"File EventObjectInitial not found")
            '        Exit Sub
            '    End If
            '    'Dim entitytype As New EntityType()
            '    'Dim builder As New EntityTypeBuilder()
            '    'builder
            '    '(GetType(EventObject))
            '    'obj.

            '    Dim items = ReadAsync(fn).Result
            '    For Each item In items
            '        Console.WriteLine($"id={item.Id}, name={item.Name}")
            '    Next
            '    Console.WriteLine(items)
            '    'builder.HasData(ReadAsync(fn).Result)
            'End Using
        End Using
    End Sub

    Private Async Function ReadAsync(filename As String) As Task(Of EventObject())
        Using fs As FileStream = New FileStream(filename, FileMode.OpenOrCreate)
            Dim type As Type = GetType(EventObject())
            Try
                Return Await JsonSerializer.DeserializeAsync(fs, type)
            Catch ex As JsonException
                Console.WriteLine($"File EventObjectInitial incorrect")
                Console.WriteLine(ex.Message)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using
    End Function

End Module
