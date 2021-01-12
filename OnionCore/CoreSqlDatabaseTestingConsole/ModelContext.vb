Imports System.Reflection
Imports Model1
Imports Model2
Imports ova.Common.Core.DomainService.SqlService

Public Class ModelContext1 : Inherits ContextAbstract
    Sub New()
        MyBase.New(Assembly.GetAssembly(GetType(Class11)), New ConnectionString With {.dbname = "db1"})
    End Sub
End Class

Public Class ModelContext2 : Inherits ContextAbstract
    Sub New()
        MyBase.New(Assembly.GetAssembly(GetType(Class21)), New ConnectionString With {.dbname = "db2"})
    End Sub
End Class

Public Class ModelContext : Inherits ContextAbstract
    Sub New()
        MyBase.New(New ConnectionString With {.dbname = "db"})
    End Sub
End Class
Public Class ModelContext0 : Inherits ContextAbstract
    Sub New()
        MyBase.New("db0")
    End Sub
End Class
