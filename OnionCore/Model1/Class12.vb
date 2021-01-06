Imports ova.Common.Core.Domain.Model
Imports ova.Common.Core.Domain.Navigation

Public Class Class12 : Implements IEntity, INavigationParent(Of Class11)

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

    Public Property ParentId As Integer Implements INavigationParent(Of Class11).ParentId
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property Parent As Class11 Implements INavigationParent(Of Class11).Parent
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Class11)
            Throw New NotImplementedException()
        End Set
    End Property
End Class
