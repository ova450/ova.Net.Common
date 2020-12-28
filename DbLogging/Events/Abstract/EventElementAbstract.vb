
Imports JsonFileDB
Imports Microsoft.Extensions.Logging

Namespace Events.Model



    Public MustInherit Class EventElementAbstract : Implements ITable

        'Public Property Id As Integer Implements IEntityBase.Id
        Public Property Name As String
        Public Property Id As Object Implements ITable.Id

        Public Code As Integer

        Public Function EventId() As EventId
            Return New EventId(Code, Name)
        End Function

    End Class

End Namespace
