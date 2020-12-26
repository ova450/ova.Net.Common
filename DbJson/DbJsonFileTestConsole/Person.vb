Imports JsonFileDB

Public Class Person : Implements ITable

    Public Property Id As Object Implements ITable.Id
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Age As Integer
    Public Property Address As Address

End Class
