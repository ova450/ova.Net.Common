Imports ova.Common.Core.DomainService
Imports ova.Common.DbLogging.Events
Imports ova.Common.DbLogging.Events.Model

Public Class EventObjectRepository : Inherits RepositoryAbstract(Of EventObject)
    Sub New(databasecontext As EventDbContext)
        MyBase.New(databasecontext)
    End Sub

End Class
