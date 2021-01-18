

Imports System.Reflection
Imports Microsoft.EntityFrameworkCore

Namespace DomainService.SqlService

    Partial Public MustInherit Class ContextAbstract : Inherits DbContext

        Private cnn As New ConnectionString
        Private asm As Assembly = Nothing

        Sub New()
            MyBase.New()
            asm = Assembly.GetExecutingAssembly
            Database.EnsureCreated()
        End Sub
        Sub New(connectionstring As ConnectionString)
            MyBase.New()
            cnn = connectionstring
            asm = If(asm, Assembly.GetEntryAssembly)
            Database.EnsureCreated()
        End Sub
        Sub New(databasename As String)
            MyBase.New()
            cnn.dbname = databasename
            asm = If(asm, Assembly.GetEntryAssembly)
            Database.EnsureCreated()
        End Sub
        Sub New(modelassembly As Assembly, connectionstring As ConnectionString)
            MyBase.New()
            cnn = connectionstring
            asm = modelassembly
            Database.EnsureCreated()
        End Sub
        Sub New(modelassembly As Assembly, databasename As String)
            MyBase.New()
            cnn.dbname = databasename
            asm = modelassembly
            Database.EnsureCreated()
        End Sub
        Sub New(anyentytytype As Type, connectionstring As ConnectionString)
            MyBase.New()
            cnn = connectionstring
            asm = Assembly.GetAssembly(anyentytytype)
            Database.EnsureCreated()
        End Sub
        Sub New(anyentytytype As Type, databasename As String)
            MyBase.New()
            cnn.dbname = databasename
            asm = Assembly.GetAssembly(anyentytytype)
            Database.EnsureCreated()
        End Sub

    End Class

End Namespace