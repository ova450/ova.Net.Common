Namespace DomainService.SqlService

    Public Class ConnectionString
        Public dbname As String = "dbTest"
        Public server As String = "(localdb)\mssqllocaldb"
        Public trustedconnection As Boolean = True

        Public Overrides Function ToString() As String
            Return $"Server={server};Database={dbname};Trusted_Connection={trustedconnection};"
        End Function
    End Class

End Namespace