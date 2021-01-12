Imports Microsoft.Extensions.Logging
Imports ova.Common.Logging.Abstract
Imports ova.Common.UnixTime.Base

Namespace Entry

    Public Class LogEntry ' : Inherits LogEntryAbstract
        'Public Sub New()
        '    MyBase.New
        'End Sub

        Public Sub New()
            TimeStampUnix = Timestamp()
            UserName = Environment.UserName
        End Sub

        Public Shared ReadOnly StaticHostName As String = Net.Dns.GetHostName()

        Public ReadOnly Property HostName As String
            Get
                Return StaticHostName
            End Get
        End Property

        Public Property UserName As String
        Public Property TimeStampUnix As Long
        Public Shadows Property Category As String
        Public Property Level As LogLevel
        Public Property Text As String
        Public Property Exception As Exception
        Public Property EventId As EventId
        Public Property State As Object
        Public Property StateText As String
        Public Property StateProperties As Dictionary(Of String, Object)
        Public Property Scopes As List(Of LogScopeInfo)
    End Class

    Public Class LogScopeInfo ' : Implements ILogScopeInfo
        Public Property Text As String ' Implements ILogScopeInfo.Text
        Public Property Properties As Dictionary(Of String, Object) ' Implements ILogScopeInfo.Properties
    End Class

End Namespace
