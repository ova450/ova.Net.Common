Imports JsonFileDB

Public Class AppDbContext : Inherits DBContext : Implements IDBContext

    Public Sub New()
        MyBase.New("f:\_develop\_repo_new\.net\common\DbJson\DbJsonFileTestConsole\database.json")
        Persons = New Dataset(Of Person)(_database)
    End Sub

    Public Property Persons As Dataset(Of Person)

End Class


