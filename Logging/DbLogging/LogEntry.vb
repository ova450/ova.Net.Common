Imports Microsoft.Extensions.Logging


Friend Class LogEntry
    Public Sub New()
        TimeStamp = TimeStamp()
        UserName = Environment.UserName
    End Sub

    Public Shared ReadOnly StaticHostName As String = Net.Dns.GetHostName()
    Public ReadOnly Property HostName As String
    Public ReadOnly Property UserName As String
    Public Property TimeStamp As Long
    Public Property Category As String
    Public Property Level As LogLevel
    Public Property Message As String
    Public Property Exception As Exception
    Public Property EventId As LogEvents
    Public Property State As Object
    Public Property StateText As String
    Public Property StateProperties As Dictionary(Of String, Object)
    Public Property Scopes As List(Of LogScopeInfo)

End Class

Friend Class LogScopeInfo
    Public Property Text As String
    Public Property Properties As Dictionary(Of String, Object)
End Class

