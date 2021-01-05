Imports ova.Common.Core.DomainService
Imports ova.Common.DbLogging.Events
Imports ova.Common.DbLogging.Events.Model

Public Class EventProcessRepository : Inherits RepositoryAbstract(Of EventProcess)

    Sub New(databasecontext As EventDbContext)
        DbContext = databasecontext
    End Sub

End Class
