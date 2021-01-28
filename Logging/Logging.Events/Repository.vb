Imports ova.Common.Core.DomainService.Repository
Imports ova.Common.Logging.Events.Model

Namespace Data.Repository

    Public Class EventObjectRepository : Inherits RepositoryAbstract(Of EventObject)
        Sub New(databasecontext As Context)
            MyBase.New(databasecontext)
        End Sub
    End Class

    Public Class EventProcessRepository : Inherits RepositoryAbstract(Of EventProcess)
        Sub New(databasecontext As Context)
            MyBase.New(databasecontext)
        End Sub
    End Class

    Public Class EventStageRepository : Inherits RepositoryAbstract(Of EventStage)
        Sub New(databasecontext As Context)
            MyBase.New(databasecontext)
        End Sub
    End Class

    Public Class EventFullElementRepository : Inherits RepositoryAbstract(Of EventFullElement)
        Sub New(databasecontext As Context)
            MyBase.New(databasecontext)
        End Sub

        Public Function GetItems(ObjectId As Integer, ProcessId As Integer, StageId As Integer) As IQueryable(Of EventFullElement)
            Return GetAll.Where(Function(p) p.EventObjectId = ObjectId AndAlso p.EventProcessId = ProcessId AndAlso p.EventStageId = StageId)
        End Function

        Public Overloads Function GetItemFirst(ObjectId As Integer, ProcessId As Integer, StageId As Integer) As EventFullElement
            Return GetAll.FirstOrDefault(Function(p) p.EventObjectId = ObjectId AndAlso p.EventProcessId = ProcessId AndAlso p.EventStageId = StageId)
        End Function

    End Class

End Namespace