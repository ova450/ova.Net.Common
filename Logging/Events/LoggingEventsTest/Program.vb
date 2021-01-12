Imports System.Reflection
Imports ova.Common.Core.DomainService.Repository
Imports ova.Common.Logging.Events.Data
Imports ova.Common.Logging.Events.Model

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        Using dbEventsLogging = New Context
            'Dim evobj As New RepositoryAbstract(Of EventObject)(dbEventsLogging)
            'Dim evproc As New RepositoryAbstract(Of EventProcess)(dbEventsLogging)
            'Dim evstage As New RepositoryAbstract(Of EventStage)(dbEventsLogging)

            'evobj.Add(New EventObject With {.Code = 3333, .Name = "test1"})
            'evobj.Add(New EventObject With {.Code = 4444, .Name = "test2"})
            'evobj.Add(New EventObject With {.Code = 5555, .Name = "test3"})
            dbEventsLogging.SaveChanges()
            'Console.WriteLine(evobj.Count.ToString)

        End Using

    End Sub
End Module
