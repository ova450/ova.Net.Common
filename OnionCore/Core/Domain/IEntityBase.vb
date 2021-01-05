
Namespace Domain.Model

    Public Interface IEntityBase
        Property Id As Integer
    End Interface

    Public Interface IEntityBase(Of T)
        Overloads Property Id As T
    End Interface

End Namespace