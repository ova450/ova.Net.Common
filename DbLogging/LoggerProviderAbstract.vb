Imports System.Collections.Concurrent
Imports Microsoft.Extensions.Logging

Namespace Abstract
    Public MustInherit Class LoggerProvider : Implements ILoggerProvider, ISupportExternalScope

        Private loggers As ConcurrentDictionary(Of String, LoggerAbstract) = New ConcurrentDictionary(Of String, LoggerAbstract)()


        Private Function CreateLogger(ByVal Category As String) As ILogger Implements ILoggerProvider.CreateLogger
            Return loggers.GetOrAdd(Category, Function(categ) New LoggerAbstract(Me, categ))
        End Function

        Public MustOverride Function IsEnabled(ByVal logLevel As LogLevel) As Boolean
        Friend MustOverride Sub WriteLog(ByVal Info As LogEntry)


#Region "ExternalScopeProvider"

        Private Sub SetScopeProvider(ByVal scopeProvider As IExternalScopeProvider) Implements ISupportExternalScope.SetScopeProvider
            _ScopeProvider = scopeProvider
        End Sub

        Private _ScopeProvider As IExternalScopeProvider

        Friend Function GetScopeProvider() As IExternalScopeProvider
            Return If(_ScopeProvider, New LoggerExternalScopeProvider())
        End Function
#End Region

    End Class

End Namespace
