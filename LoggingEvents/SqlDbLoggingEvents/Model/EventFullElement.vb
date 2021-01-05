Imports Microsoft.Extensions.Logging
Imports ova.Common.Core.Domain.Navigation
Imports ova.Common.SqlDbLoggingEvents.Model.Abstract

Namespace Model

    Public Class EventFullElement : Inherits EventElementAbstract : Implements INavigationParent(Of EventObject) ', EventProcess, EventStage)

        'Public Property EventObjectId As Integer Implements INavigationParent(Of EventObject, EventProcess, EventStage).ParentId1

        'Public Property EventObject As EventObject Implements INavigationParent(Of EventObject, EventProcess, EventStage).Parent1

        Public Property EventObjectId As Integer Implements INavigationParent(Of EventObject).ParentId
        Public Property EventObject As EventObject Implements INavigationParent(Of EventObject).Parent

        Private Shadows Code As Integer

        Public Overloads Function EventId() As EventId
            'Return New EventId(EventObject.Code + EventProcess.Code + EventStage.Code, EventObject.Name + EventProcess.Name + EventStage.Name)
            Return New EventId(EventObject.Code, EventObject.Name)
        End Function

    End Class

End Namespace