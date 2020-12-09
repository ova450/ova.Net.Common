
Imports System.IO
Imports Microsoft.Extensions.Logging


Public Class FileLogger : Implements ILogger

        Private filePath As String
        Private _lock As Object = New Object()

        Public Sub New(path As String)
            filePath = path
        End Sub

        Public Sub Log(Of TState)(logLevel As LogLevel, eventId As EventId, state As TState, exception As Exception, formatter As Func(Of TState, Exception, String)) Implements ILogger.Log
            If formatter IsNot Nothing Then
                SyncLock _lock
                    File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine)
                End SyncLock
            End If

        End Sub

        Public Function IsEnabled(logLevel As LogLevel) As Boolean Implements ILogger.IsEnabled
            Return True : End Function

        Public Function BeginScope(Of TState)(state As TState) As IDisposable Implements ILogger.BeginScope
            Return Nothing : End Function

    End Class


