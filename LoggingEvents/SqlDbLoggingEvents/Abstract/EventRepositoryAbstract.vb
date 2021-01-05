Imports JsonFileDB
Imports Microsoft.EntityFrameworkCore
Imports ova.Common.Core.Domain
Imports ova.Common.Core.DomainService
Imports ova.Common.DbLogging.Events
Imports ova.Common.DbLogging.Events.Model



Public Class EventRepositoryAbstract(Of T As {Class, IEntity}) : Implements IRepository(Of T)

    Private Property dbs As ISet(Of T)

    Public Function GetAll() As IQueryable(Of T) Implements IRepository(Of T).GetAll
        Return dbs.Select(Of T)(Function(t) t)
    End Function

    'Public Function GetHashSet() As IEnumerable(Of T)
    '    Return dbs.Select(Of T)(Function(e) e).ToList
    'End Function

    Public Function Count() As Long Implements IRepository(Of T).Count
        Return GetAll.Count
    End Function

    Public Function [Get](id As Integer) As T Implements IRepository(Of T).Get
        GetAll.FirstOrDefault(Function(t) t.Id = id)
    End Function

    Public Async Function GetAsync(id As Integer) As Task(Of T) Implements IRepository(Of T).GetAsync
        Await GetAll.FirstOrDefaultAsync(Function(t) t.Id = id)
    End Function

    Public Function Add(entity As T) As T Implements IRepository(Of T).Add
        GetAll.Append(entity)
    End Function

    Public Function AddAsync(entity As T) As Task(Of T) Implements IRepository(Of T).AddAsync
        Throw New NotImplementedException()
    End Function

    Public Function Remove(id As Integer) As T Implements IRepository(Of T).Remove
        GetAll.re
    End Function

    Public Function Remove(entity As T) As T Implements IRepository(Of T).Remove
        Throw New NotImplementedException()
    End Function

    Public Function RemoveAsync(id As Integer) As Task(Of T) Implements IRepository(Of T).RemoveAsync
        Throw New NotImplementedException()
    End Function

    Public Function RemoveAsync(entity As T) As Task(Of T) Implements IRepository(Of T).RemoveAsync
        Throw New NotImplementedException()
    End Function

    Public Function Update(entity As T) As T Implements IRepository(Of T).Update
        Throw New NotImplementedException()
    End Function

    Public Function UpdateAsync(entity As T) As Task(Of T) Implements IRepository(Of T).UpdateAsync
        Throw New NotImplementedException()
    End Function

    'Private dbcontext As EventDbContext
    'Private dbset As Dataset(Of T)

    'Sub New(databasecontext As EventDbContext, databaseset As Dataset(Of T))
    '    dbcontext = databasecontext
    '    dbset = databaseset
    'End Sub

    'Public Function GetAll() As IQueryable(Of T) Implements IRepository(Of T).GetAll
    '    Return dbset.GetAll
    'End Function

    'Public Function Count() As Long Implements IRepository(Of T).Count
    '    Return GetAll.Count
    'End Function

    'Public Function [Get](id As Integer) As EventObject Implements IRepository(Of T).Get


    '    Return GetAll.FirstOrDefault(Function(e)
    '                                     Dim idd As Integer = CType(id, Integer)

    '                                     Return CType(e.Id, Integer) = id
    '                                 End Function)
    'End Function

    'Public Function GetAsync(id As Integer) As Task(Of EventObject) Implements IRepository(Of EventObject).GetAsync
    '    Throw New NotImplementedException()
    'End Function

    'Public Function Add(entity As EventObject) As EventObject Implements IRepository(Of EventObject).Add
    '    Throw New NotImplementedException()
    'End Function

    'Public Function AddAsync(entity As EventObject) As Task(Of EventObject) Implements IRepository(Of EventObject).AddAsync
    '    Throw New NotImplementedException()
    'End Function

    'Public Function Remove(id As Integer) As EventObject Implements IRepository(Of EventObject).Remove
    '    Throw New NotImplementedException()
    'End Function

    'Public Function Remove(entity As EventObject) As EventObject Implements IRepository(Of EventObject).Remove
    '    Throw New NotImplementedException()
    'End Function

    'Public Function RemoveAsync(id As Integer) As Task(Of EventObject) Implements IRepository(Of EventObject).RemoveAsync
    '    Throw New NotImplementedException()
    'End Function

    'Public Function RemoveAsync(entity As EventObject) As Task(Of EventObject) Implements IRepository(Of EventObject).RemoveAsync
    '    Throw New NotImplementedException()
    'End Function

    'Public Function Update(entity As EventObject) As EventObject Implements IRepository(Of EventObject).Update
    '    Throw New NotImplementedException()
    'End Function

    'Public Function UpdateAsync(entity As EventObject) As Task(Of EventObject) Implements IRepository(Of EventObject).UpdateAsync
    '    Throw New NotImplementedException()
    'End Function
End Class
