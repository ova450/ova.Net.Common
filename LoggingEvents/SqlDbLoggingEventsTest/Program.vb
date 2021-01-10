Imports ova.Common.SqlDbLoggingEvents
Imports ova.Common.SqlDbLoggingEvents.Model

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        Using dbEventsLogging = New EventsContext()
            Dim evobj As New EventRepositoryAbstract(Of EventObject)(dbEventsLogging)
            Dim evproc As New EventRepositoryAbstract(Of EventProcess)(dbEventsLogging)
            Dim evstage As New EventRepositoryAbstract(Of EventStage)(dbEventsLogging)

            evobj.Add(New EventObject With {.Code = 3333, .Name = "test1", .Id = 1})
            evobj.Add(New EventObject With {.Code = 4444, .Name = "test2", .Id = 2})
            evobj.Add(New EventObject With {.Code = 5555, .Name = "test3", .Id = 3})
            dbEventsLogging.SaveChanges()
            Console.WriteLine(evobj.Count.ToString)

        End Using

    End Sub
End Module
