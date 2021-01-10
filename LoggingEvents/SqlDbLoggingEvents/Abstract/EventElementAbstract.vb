Imports Microsoft.Extensions.Logging
Imports ova.Common.Core.Domain.Model

Namespace Model.Abstract

    Public MustInherit Class EventElementAbstract : Implements IEntity

        Public Property Id As Integer Implements IEntityBase.Id
        Public Property Name As String Implements IEntity.Name

        Public Property Code As Integer

        Public Function EventId() As EventId
            Return New EventId(Code, Name)
        End Function

    End Class

End Namespace
