
Namespace Domain.Model

    Public Interface IEntity : Inherits IEntityBase
        Property Name As String
    End Interface

    Public Interface IEntity(Of T) : Inherits IEntityBase(Of T)
        Property Name As String
    End Interface

End Namespace
