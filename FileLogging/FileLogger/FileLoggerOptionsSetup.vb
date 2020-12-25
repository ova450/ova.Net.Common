Imports Microsoft.Extensions.Logging.Configuration
Imports Microsoft.Extensions.Options

Namespace FileLogger
    Friend Class FileLoggerOptionsSetup
        Inherits ConfigureFromConfigurationOptions(Of FileLoggerOptions)

        Public Sub New(ByVal providerConfiguration As ILoggerProviderConfiguration(Of FileLoggerProvider))
            MyBase.New(providerConfiguration.Configuration)
        End Sub
    End Class
End Namespace
