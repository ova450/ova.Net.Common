Imports Microsoft.Extensions.Logging
Imports ova.Common.Core.Domain.Navigation
Imports ova.Common.Logging.Events.Model.Abstract

Namespace Model

    Public Class EventObject : Inherits EventElementAbstract : Implements INavigationChild(Of EventFullElement)

        Public Overrides Function EventId() As EventId
            Return New EventId(Id * 10000, Name)
        End Function

        Public Property EventFullElements As HashSet(Of EventFullElement) Implements INavigationChild(Of EventFullElement).Childs
    End Class

    Public Class EventProcess : Inherits EventElementAbstract : Implements INavigationChild(Of EventFullElement)
        Public Overrides Function EventId() As EventId
            Return New EventId(Id * 100, Name)
        End Function
        Public Property EventFullElements As HashSet(Of EventFullElement) Implements INavigationChild(Of EventFullElement).Childs
    End Class

    Public Class EventStage : Inherits EventElementAbstract : Implements INavigationChild(Of EventFullElement)
        Public Property EventFullElements As HashSet(Of EventFullElement) Implements INavigationChild(Of EventFullElement).Childs
    End Class

    Public Class EventFullElement : Inherits EventElementAbstract : Implements INavigationParent(Of EventObject, EventProcess, EventStage)

        Public Property EventObjectId As Integer Implements INavigationParent(Of EventObject, EventProcess, EventStage).ParentId1
        Public Property EventObject As EventObject Implements INavigationParent(Of EventObject, EventProcess, EventStage).Parent1

        Public Property EventProcessId As Integer Implements INavigationParent(Of EventObject, EventProcess, EventStage).ParentId2
        Public Property EventProcess As EventProcess Implements INavigationParent(Of EventObject, EventProcess, EventStage).Parent2

        Public Property EventStageId As Integer Implements INavigationParent(Of EventObject, EventProcess, EventStage).ParentId3
        Public Property EventStage As EventStage Implements INavigationParent(Of EventObject, EventProcess, EventStage).Parent3

        Public Overrides Function EventId() As EventId
            Return New EventId(EventObjectId + EventProcessId + EventStageId, Name)
        End Function

    End Class

End Namespace
