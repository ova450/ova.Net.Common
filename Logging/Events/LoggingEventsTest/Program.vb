Imports System.Reflection
Imports ova.Common.Core.DomainService.Repository
Imports ova.Common.Logging.Events.Data
Imports ova.Common.Logging.Events.Model

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        Using dbEventsLogging = New Context
            dbEventsLogging.SaveChanges()
        End Using

    End Sub
End Module
