Imports Model1
Imports ova.Common.Core.DomainService.Repository
Imports ova.Common.Core.DomainService.SqlService

Public Class Class11Repository : Inherits RepositoryAbstract(Of Class11)
    Sub New(dbcontext As ContextAbstract)
        MyBase.New(dbcontext)
    End Sub
End Class
