Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Runtime.CompilerServices

Namespace ova.Common.HostAsWindowsService
    Module ServiceBaseLifetimeHostExtensions
        <Extension()>
        Function UseServiceBaseLifetime(ByVal hostBuilder As IHostBuilder) As IHostBuilder
            Return hostBuilder.ConfigureServices(Function(hostContext, services) services.AddSingleton(Of IHostLifetime, ServiceBaseLifetime)())
        End Function

        <Extension()>
        Function RunAsServiceAsync(ByVal hostBuilder As IHostBuilder, ByVal Optional cancellationToken As CancellationToken = Nothing) As Task
            If cancellationToken = Nothing Then cancellationToken = CancellationToken.None
            Return hostBuilder.UseServiceBaseLifetime().Build().RunAsync(cancellationToken)
        End Function
    End Module
End Namespace
