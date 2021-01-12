Imports Model1

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        Using db1 = New ModelContext1
            Dim class11 As New Class11Repository(db1)
            class11.Add(New Class11 With {.Name = "testadd2222"})
            db1.SaveChanges()

            Using db2 = New ModelContext2
            End Using
        End Using

        Using db = New ModelContext
            Using db0 = New ModelContext0
            End Using
        End Using

    End Sub
End Module
