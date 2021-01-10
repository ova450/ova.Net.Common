Imports ova.Common.Core.DomainService.SqlService
Imports ova.Common.SqlDbLoggingEvents.Model

Public Class EventsContext : Inherits DbContextAbstract
    Sub New()
        MyBase.New(GetType(EventObject), "EventsLogging")
    End Sub
End Class
