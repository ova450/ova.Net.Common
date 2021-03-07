Imports System.IO
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Logging
Imports ova.Common.Logging.FileLogger

Public Module ConfigurationByHost

    Public Function CreateHostBuilder(connectionname As String, ByVal args As String()) As IHostBuilder
        Try
            Return Host.CreateDefaultBuilder(args).
                ConfigureHostConfiguration(Sub(configHost)
                                               With configHost
                                                   .SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile("hostsettings.json", optional:=True)
                                                   .AddEnvironmentVariables(prefix:="PREFIX_")
                                                   .AddCommandLine(args)
                                               End With
                                           End Sub).
                ConfigureAppConfiguration(Sub(hostContext As HostBuilderContext, configApp As IConfigurationBuilder)
                                              With configApp
                                                  .AddJsonFile("appsettings.json", optional:=True)
                                                  .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional:=True)
                                                  .AddEnvironmentVariables(prefix:="ASPNETCORE_")
                                                  .AddCommandLine(args)
                                              End With
                                          End Sub).
                ConfigureLogging(Sub(hostContext, configLogging)
                                     With configLogging
                                         .ClearProviders()
                                         .AddFileLogger(Sub(options)
                                                            options.MaxFileSizeInMB = 5
                                                            options.LogLevel = LogLevel.Information
                                                        End Sub)
                                         .AddConsole()
                                         .AddDebug()
                                     End With
                                 End Sub).
                ConfigureServices(Sub(hostContext, services)
                                      With services
                                          .AddLogging()
                                          .AddHostedService(Of AppLifetimeHostedService)()
                                          '.AddDbContext(Of ApiDbContext)(Sub(options)
                                          '                                   options.UseSqlServer(hostContext.Configuration.GetConnectionString("DbSqlConnection"))
                                          '                               End Sub)
                                      End With
                                  End Sub)
        Catch ex As Exception
            System.Console.WriteLine($"Error: {ex.Message}")
            Return Nothing
        End Try

    End Function

End Module
