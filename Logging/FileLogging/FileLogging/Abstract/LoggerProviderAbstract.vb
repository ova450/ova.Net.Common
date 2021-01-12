Imports Microsoft.Extensions.Logging
Imports ova.Common.Logging.Entry
Imports System.Collections.Concurrent

Namespace Abstract
    Public MustInherit Class LoggerProvider : Implements ILoggerProvider, ISupportExternalScope

        Private loggers As ConcurrentDictionary(Of String, Logger) = New ConcurrentDictionary(Of String, Logger)()
        Private fScopeProvider As IExternalScopeProvider

        Private Sub SetScopeProvider(ByVal scopeProvider As IExternalScopeProvider) Implements ISupportExternalScope.SetScopeProvider
            fScopeProvider = scopeProvider
        End Sub

        Private Function CreateLogger(ByVal Category As String) As ILogger Implements ILoggerProvider.CreateLogger
            Return loggers.GetOrAdd(Category, Function(categ) New Logger(Me, categ))
        End Function



        Public Sub New()
        End Sub

        Public MustOverride Function IsEnabled(ByVal logLevel As LogLevel) As Boolean
        Public MustOverride Sub WriteLog(ByVal Info As LogEntry)

        Friend ReadOnly Property ScopeProvider As IExternalScopeProvider
            Get
                Return If(fScopeProvider, New LoggerExternalScopeProvider())
            End Get
        End Property

    End Class

End Namespace
