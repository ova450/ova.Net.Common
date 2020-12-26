Imports Microsoft.Extensions.Logging
Imports ova.Common.DbLogging.Abstract
Imports ova.Common.Logging.Abstract
Imports ova.Common.Logging.Entry

Friend Class LoggerAbstract : Implements ILogger
    Public Property Provider As LoggerProvider
    Public Property Category As String

    Public Sub New(ByVal Provider As LoggerProvider, ByVal Category As String)
        Me.Provider = Provider
        Me.Category = Category
    End Sub

    Private Function BeginScope(Of TState)(ByVal state As TState) As IDisposable Implements ILogger.BeginScope
        Return Provider.GetScopeProvider.Push(state)
    End Function

    Private Function IsEnabled(ByVal logLevel As LogLevel) As Boolean Implements ILogger.IsEnabled
        Return Provider.IsEnabled(logLevel)
    End Function

    Friend Sub Log(Of TState)(ByVal logLevel As LogLevel, ByVal eventId As EventId, ByVal exception As Exception, ByVal formatter As Func(Of TState, Exception, String))

        'Dim Properties As IEnumerable(Of KeyValuePair(Of String, Object)) = Nothing, props As IEnumerable(Of KeyValuePair(Of String, Object)) = Nothing

        If (TryCast(Me, ILogger)).IsEnabled(logLevel) Then
            Dim Info As LogEntry = New LogEntry()
            Info.Category = Me.Category
            Info.Level = logLevel
            Info.Message = Message     '  If(exception?.Message, state.ToString())
            Info.Exception = exception
            Info.EventId = eventId
            'Info.State = state

            'If TypeOf state Is String Then
            '    Info.StateText = state.ToString()
            'ElseIf TypeOf state Is IEnumerable(Of KeyValuePair(Of String, Object)) Then

            '    Info.StateProperties = If(Info.StateProperties, New Dictionary(Of String, Object))

            '    If Properties IsNot Nothing Then
            '        For Each item As KeyValuePair(Of String, Object) In Properties
            '            Info.StateProperties(item.Key) = item.Value
            '        Next
            '    End If
            'End If

            'If Provider.ScopeProvider IsNot Nothing Then
            '    Provider.ScopeProvider.ForEachScope(Sub(value, loggingProps)
            '                                            If Info.Scopes Is Nothing Then Info.Scopes = New List(Of LogScopeInfo)()
            '                                            Dim Scope As LogScopeInfo = New LogScopeInfo()
            '                                            Info.Scopes.Add(Scope)

            '                                            'Dim props1 As IEnumerable(Of KeyValuePair(Of String, Object)) = Nothing
            '                                            If TypeOf value Is String Then
            '                                                Scope.Text = value.ToString()
            '                                            ElseIf TypeOf value Is IEnumerable(Of KeyValuePair(Of String, Object)) Then
            '                                                Scope.Properties = If(Scope.Properties, New Dictionary(Of String, Object))
            '                                                For Each pair In props
            '                                                    Scope.Properties(pair.Key) = pair.Value
            '                                                Next
            '                                            End If
            '                                        End Sub, state)
            'End If

            Provider.WriteLog(Info)

        End If
    End Sub


End Class
