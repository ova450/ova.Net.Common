
Namespace Domain

    Public Interface IEntityTimingBase : Inherits IEntityBase
        ReadOnly Property Timestamp As Long
    End Interface

    Public Interface IEntityTimingBase(Of T) : Inherits IEntityBase(Of T)
        ReadOnly Property Timestamp As Long
    End Interface

End Namespace