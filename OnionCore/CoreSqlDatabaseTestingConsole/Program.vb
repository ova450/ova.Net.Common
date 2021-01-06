Imports System
Imports System.Reflection
Imports Microsoft.EntityFrameworkCore
Imports Model1
Imports Model2
Imports ova.Common.Core.DomainService.SqlService

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        Using db1 = New ModelContext1
            Using db2 = New ModelContext2
            End Using
        End Using

        Using db = New ModelContext
            Using db0 = New ModelContext0
            End Using
        End Using

    End Sub
End Module
