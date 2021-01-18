Imports System.Reflection
Imports ova.Common.Core.DomainService.SqlService
Imports ova.Common.Logging.Events.Model

Namespace Data

    Public Class Context : Inherits ContextAbstract
        Sub New()
            MyBase.New(Assembly.GetAssembly(GetType(EventObject)), "EventsLogging")
        End Sub
    End Class

End Namespace