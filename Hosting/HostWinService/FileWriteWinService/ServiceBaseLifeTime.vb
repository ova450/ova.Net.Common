Imports Microsoft.Extensions.Hosting
Imports System
Imports System.ServiceProcess
Imports System.Threading
Imports System.Threading.Tasks

Namespace ova.Common.HostAsWindowsService
    Public Class ServiceBaseLifetime : Inherits ServiceBase : Implements IHostLifetime

        Private ReadOnly _delayStart As TaskCompletionSource(Of Object) = New TaskCompletionSource(Of Object)()

        Public Sub New(ByVal applicationLifetime As IHostApplicationLifetime)

            applicationLifetime = If(applicationLifetime, Sub() Throw New ArgumentNullException(NameOf(applicationLifetime)))
        End Sub

        Private ReadOnly Property ApplicationLifetime As IHostApplicationLifetime

        Public Function WaitForStartAsync(ByVal cancellationToken As CancellationToken) As Task Implements IHostLifetime.WaitForStartAsync
            cancellationToken.Register(Sub() _delayStart.TrySetCanceled())
            ApplicationLifetime.ApplicationStopping.Register(AddressOf [Stop])
            Dim newthread = New Thread(AddressOf Run)
            newthread.Start()
            Return _delayStart.Task
        End Function

        Private Overloads Sub Run()
            Try
                Run(Me)
                _delayStart.TrySetException(New InvalidOperationException("Stopped without starting"))
            Catch ex As Exception : _delayStart.TrySetException(ex)
            End Try
        End Sub

        Public Function StopAsync(cancellationToken As CancellationToken) As Task Implements IHostLifetime.StopAsync
            [Stop]()
            Return Task.CompletedTask
        End Function

        Protected Overrides Sub OnStart(ByVal args As String())
            _delayStart.TrySetResult(Nothing)
            MyBase.OnStart(args)
        End Sub

        Protected Overrides Sub OnStop()
            ApplicationLifetime.StopApplication()
            MyBase.OnStop()
        End Sub

    End Class
End Namespace
