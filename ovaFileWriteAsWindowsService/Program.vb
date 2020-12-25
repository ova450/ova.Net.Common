Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports ovaFileWriteAsWindowsService.ova.Common.HostAsWindowsService

Module Program

    Sub Main(ByVal args As String()) 'As Task
        InitAsync(args)
    End Sub

    Private Async Sub InitAsync(ByVal args As String())
        Dim isService = Not (Debugger.IsAttached OrElse args.Contains("--console"))
        Dim builder = New HostBuilder().ConfigureServices(Sub(hostContext, services)
                                                              services.AddHostedService(Of FileWriterService)()
                                                          End Sub)

        If isService Then Await builder.RunAsServiceAsync() Else Await builder.RunConsoleAsync()
    End Sub

End Module

