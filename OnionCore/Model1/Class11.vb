
Imports ova.Common.Core.Domain.Model
Imports ova.Common.Core.Domain.Navigation

Public Class Class11 : Implements IEntity, INavigationChild(Of Class12)

    Public Property Name As String Implements IEntity.Name

    Public Property Id As Integer Implements IEntityBase.Id

    Public Property testcolumn As String


    Public Property Childs As HashSet(Of Class12) Implements INavigationChild(Of Class12).Childs

End Class
