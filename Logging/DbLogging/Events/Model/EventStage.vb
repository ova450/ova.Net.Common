Imports ova.Common.Core.Domain.Navigation

Namespace Events.Model

    Public Class EventStage : Inherits EventElementAbstract : Implements INavigationChild(Of EventFullElement)

        Public Property EventFullElements As HashSet(Of EventFullElement) Implements INavigationChild(Of EventFullElement).Childs

    End Class

End Namespace