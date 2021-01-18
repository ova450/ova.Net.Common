Namespace DomainService

    Public NotInheritable Class EntityLevelInitialAttribute : Inherits Attribute

        Public Property Level As UInteger = 0

        Sub New()

        End Sub

        Sub New(level As UInteger)
            Me.Level = level
        End Sub

    End Class

End Namespace