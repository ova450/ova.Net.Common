Imports Microsoft.Extensions.Logging
Imports ova.Common.Core.Domain.Navigation
Imports ova.Common.Logging.Events.Model.Abstract

Namespace Model

    Public Class EventFullElement : Inherits EventElementAbstract : Implements INavigationParent(Of EventObject) ', EventProcess, EventStage)

        Public Property EventObjectId As Integer Implements INavigationParent(Of EventObject).ParentId
        Public Property EventObject As EventObject Implements INavigationParent(Of EventObject).Parent

        Private Shadows Code As Integer

        Public Overloads Function EventId() As EventId
            Return New EventId(EventObject.Code, EventObject.Name)
        End Function

    End Class

    Public Class EventObject : Inherits EventElementAbstract : Implements INavigationChild(Of EventFullElement)
        Public Property EventFullElements As HashSet(Of EventFullElement) Implements INavigationChild(Of EventFullElement).Childs
    End Class

    Public Class EventProcess : Inherits EventElementAbstract : Implements INavigationChild(Of EventFullElement)
        Public Property EventFullElements As HashSet(Of EventFullElement) Implements INavigationChild(Of EventFullElement).Childs
    End Class

    Public Class EventStage : Inherits EventElementAbstract : Implements INavigationChild(Of EventFullElement)
        Public Property EventFullElements As HashSet(Of EventFullElement) Implements INavigationChild(Of EventFullElement).Childs
    End Class


End Namespace
