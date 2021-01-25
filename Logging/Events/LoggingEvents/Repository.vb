Imports ova.Common.Core.DomainService.Repository
Imports ova.Common.Logging.Events.Model

Namespace Data.Repository

    Public Class EventObjectRepository : Inherits RepositoryAbstract(Of EventObject)

        Sub New(databasecontext As Context)
            MyBase.New(databasecontext)
        End Sub

    End Class

    'Public Class EventProcessRepository : Inherits RepositoryAbstract(Of EventProcess)

    '    Sub New(databasecontext As Context)
    '        MyBase.New(databasecontext)
    '    End Sub

    'End Class

    'Public Class EventStageRepository : Inherits RepositoryAbstract(Of EventStage)

    '    Sub New(databasecontext As Context)
    '        MyBase.New(databasecontext)
    '    End Sub

    'End Class

End Namespace