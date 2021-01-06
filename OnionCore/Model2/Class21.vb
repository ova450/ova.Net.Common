
Imports ova.Common.Core.Domain.Model
Imports ova.Common.Core.Domain.Navigation

Public Class Class21 : Implements IEntity, INavigationChild(Of Class22)

    Public Property Name As String Implements IEntity.Name
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property Id As Integer Implements IEntityBase.Id
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property Childs As HashSet(Of Class22) Implements INavigationChild(Of Class22).Childs
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As HashSet(Of Class22))
            Throw New NotImplementedException()
        End Set
    End Property
End Class
