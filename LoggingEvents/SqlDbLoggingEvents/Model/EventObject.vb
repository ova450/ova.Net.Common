Imports ova.Common.Core.Domain.Navigation
Imports ova.Common.SqlDbLoggingEvents.Model.Abstract

Namespace Model

    Public Class EventObject : Inherits EventElementAbstract : Implements INavigationChild(Of EventFullElement)

        Public Property EventFullElements As HashSet(Of EventFullElement) Implements INavigationChild(Of EventFullElement).Childs

    End Class

End Namespace
