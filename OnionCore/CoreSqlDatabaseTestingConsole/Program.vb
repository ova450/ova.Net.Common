Imports System
Imports System.Reflection

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        'For Each asm In AppDomain.CurrentDomain.GetAssemblies
        '    Console.WriteLine(asm.FullName)
        'Next
        'Console.WriteLine("---------------------------------")
        'Console.WriteLine(Assembly.GetExecutingAssembly.GetName)
        'Console.WriteLine("---------------------------------")
        'For Each typ In Assembly.GetExecutingAssembly.DefinedTypes
        '    Console.WriteLine(typ.FullName)
        'Next


        Using db = New TestContext()

        End Using

    End Sub
End Module
