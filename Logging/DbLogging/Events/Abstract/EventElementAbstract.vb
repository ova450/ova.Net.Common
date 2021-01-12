Imports Microsoft.Extensions.Logging
Imports ova.Common.Core.Domain

Namespace Events.Model



    Public MustInherit Class EventElementAbstract : Implements IEntity


        Public Code As Integer

        Public Property Id As Integer Implements IEntityBase.Id
        Public Property Name As String Implements IEntity.Name

        Public Function EventId() As EventId
            Return New EventId(Code, Name)
        End Function

    End Class

End Namespace
