Imports ova.Common.Core.Domain.Model
Imports ova.Common.Core.Domain.Navigation

Public Class Class22 : Implements IEntity, INavigationParent(Of Class21)

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

    Public Property ParentId As Integer Implements INavigationParent(Of Class21).ParentId
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property Parent As Class21 Implements INavigationParent(Of Class21).Parent
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Class21)
            Throw New NotImplementedException()
        End Set
    End Property
End Class
