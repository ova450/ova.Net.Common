Imports Microsoft.Extensions.Logging

Namespace FileLogger
    Public Class FileLoggerOptions
        Private fFolder As String
        Private fMaxFileSizeInMB As Integer
        Private fRetainPolicyFileCount As Integer

        Public Property LogLevel As LogLevel = LogLevel.Information

        Public Property Folder As String
            Get
                Return If(Not String.IsNullOrWhiteSpace(fFolder), fFolder, IO.Path.GetDirectoryName(Me.[GetType]().Assembly.Location))
            End Get
            Set(ByVal value As String)
                fFolder = value
            End Set
        End Property

        Public Property MaxFileSizeInMB As Integer
            Get
                Return If(fMaxFileSizeInMB > 0, fMaxFileSizeInMB, 2)
            End Get
            Set(ByVal value As Integer)
                fMaxFileSizeInMB = value
            End Set
        End Property

        Public Property RetainPolicyFileCount As Integer
            Get
                Return If(fRetainPolicyFileCount < 5, 5, fRetainPolicyFileCount)
            End Get
            Set(ByVal value As Integer)
                fRetainPolicyFileCount = value
            End Set
        End Property
    End Class
End Namespace
