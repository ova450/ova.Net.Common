Imports System

Public Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
        Dim db As AppDbContext = New AppDbContext
        Dim Persons As List(Of Person) = db.Persons.GetAll
        Console.WriteLine($"Count: {db.Persons.GetAll.Count}")
        Dim Person As Person = Persons.First
        Console.WriteLine($"{Person.Id} {Person.FirstName} {Person.LastName} {Person.Age}")
        Person = Persons.FindLast(Function(e) e.Id > 0)
        Console.WriteLine($"{Person.Id} {Person.FirstName} {Person.LastName} {Person.Age}")
        Person = Persons(0)
        Console.WriteLine($"{Person.Id} {Person.FirstName} {Person.LastName} {Person.Age} {Person.Address.Country} {Person.Address.City}")

        Console.WriteLine($"Press any key...")
        Console.ReadKey()
    End Sub
End Module
