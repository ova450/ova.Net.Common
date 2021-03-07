Imports Microsoft.Extensions.Hosting
Imports System
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks

Namespace ova.Common.HostAsWindowsService
    Public Class FileWriterService : Implements IHostedService, IDisposable

        Private Const Path As String = "d:\TestApp_VB.txt"
        Private _timer As Timer

        Public Function StartAsync(ByVal cancellationToken As CancellationToken) As Task Implements IHostedService.StartAsync
            _timer = New Timer(Sub(e) WriteTimeToFile(), Nothing, TimeSpan.Zero, TimeSpan.FromMinutes(1))
            Return Task.CompletedTask
        End Function
        Public Function StopAsync(ByVal cancellationToken As CancellationToken) As Task Implements IHostedService.StopAsync
            _timer?.Change(Timeout.Infinite, 0)
            Return Task.CompletedTask
        End Function

        Public Shared Sub WriteTimeToFile()
            If Not File.Exists(Path) Then Using sw = File.CreateText(Path) : End Using

            Using sw = File.AppendText(Path)
                sw.WriteLine(DateTime.UtcNow.ToString("o"))
            End Using

        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            _timer?.Dispose()
        End Sub

    End Class
End Namespace