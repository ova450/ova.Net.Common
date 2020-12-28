Imports Microsoft.Extensions.Logging
Imports ova.Common.Core.Domain.Navigation

Namespace Events.Model

    Public Class EventFullElement : Inherits EventElementAbstract : Implements INavigationParent(Of EventObject, EventProcess, EventStage)

        Public Property EventObjectId As Integer Implements INavigationParent(Of EventObject, EventProcess, EventStage).ParentId1

        Public Property EventObject As EventObject Implements INavigationParent(Of EventObject, EventProcess, EventStage).Parent1

        Public Property EventProcessId As Integer Implements INavigationParent(Of EventObject, EventProcess, EventStage).ParentId2

        Public Property EventProcess As EventProcess Implements INavigationParent(Of EventObject, EventProcess, EventStage).Parent2

        Public Property EventStageId As Integer Implements INavigationParent(Of EventObject, EventProcess, EventStage).ParentId3

        Public Property EventStage As EventStage Implements INavigationParent(Of EventObject, EventProcess, EventStage).Parent3

        Private Shadows Code As Integer

        Public Overloads Function EventId() As EventId
            Return New EventId(EventObject.Code + EventProcess.Code + EventStage.Code, EventObject.Name + EventProcess.Name + EventStage.Name)
        End Function

    End Class

End Namespace