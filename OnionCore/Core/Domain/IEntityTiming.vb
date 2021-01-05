
Namespace Domain.Model

    Public Interface IEntityTiming : Inherits IEntityTimingBase
        Property Name As String
    End Interface

    Public Interface IEntityTiming(Of T) : Inherits IEntityTimingBase(Of T)
        Property Name As String
    End Interface

End Namespace