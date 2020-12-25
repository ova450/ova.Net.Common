Imports System.Runtime.CompilerServices
Imports Microsoft.Extensions.Logging

Public Module FileLoggerExtensions

    <Extension()>
    Public Function AddFile(ByVal factory As ILoggerFactory, ByVal filePath As String) As ILoggerFactory
        factory.AddProvider(New FileLoggerProvider(filePath))
        Return factory
    End Function
End Module