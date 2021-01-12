Imports System.Threading
Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Logging

Public Class AppLifetimeHostedService
    Implements IHostedService

    Shared _logger As ILogger

    Sub New(ByVal logger As ILogger(Of AppLifetimeHostedService), ByVal appLifetime As IHostApplicationLifetime)
        _logger = logger
        With appLifetime
            .ApplicationStarted.Register(AddressOf OnStarted)
            .ApplicationStopping.Register(AddressOf OnStopping)
            .ApplicationStopped.Register(AddressOf OnStopped)
        End With
    End Sub

    Function StartAsync(ByVal cancellationToken As CancellationToken) As Task Implements IHostedService.StartAsync
        _logger.LogInformation("1. StartAsync has been started.")
        Return Task.CompletedTask
    End Function

    Function StopAsync(ByVal cancellationToken As CancellationToken) As Task Implements IHostedService.StopAsync
        _logger.LogInformation("4. StopAsync has been stopped.")
        Return Task.CompletedTask
    End Function

    Private Sub OnStarted()
        _logger.LogDebug("2. OnStarted has been called.") : End Sub

    Private Sub OnStopping()
        _logger.LogDebug("3. OnStopping has been called.") : End Sub
    Private Sub OnStopped()
        _logger.LogDebug("5. OnStopped has been called.") : End Sub

End Class

