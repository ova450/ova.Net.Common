Imports System.Runtime.CompilerServices
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.DependencyInjection.Extensions
Imports Microsoft.Extensions.Logging
Imports Microsoft.Extensions.Logging.Configuration
Imports Microsoft.Extensions.Options

Namespace FileLogger
    Public Module FileLoggerExtensions
        <Extension()>
        Public Function AddFileLogger(ByVal builder As ILoggingBuilder) As ILoggingBuilder
            builder.AddConfiguration()
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton(Of ILoggerProvider, FileLoggerProvider)())
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton(Of IConfigureOptions(Of FileLoggerOptions), FileLoggerOptionsSetup)())
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton(Of IOptionsChangeTokenSource(Of FileLoggerOptions), LoggerProviderOptionsChangeTokenSource(Of FileLoggerOptions, FileLoggerProvider))())
            Return builder
        End Function

        <Extension()>
        Public Function AddFileLogger(ByVal builder As ILoggingBuilder, ByVal configure As Action(Of FileLoggerOptions)) As ILoggingBuilder

            If configure Is Nothing Then Throw New ArgumentNullException(NameOf(configure))

            builder.AddFileLogger()
            builder.Services.Configure(configure)
            Return builder
        End Function
    End Module
End Namespace
