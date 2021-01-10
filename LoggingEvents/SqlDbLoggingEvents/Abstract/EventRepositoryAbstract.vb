Imports Microsoft.EntityFrameworkCore
Imports ova.Common.Core.Domain.Model
Imports ova.Common.Core.DomainService.Repository



Public Class EventRepositoryAbstract(Of T As {Class, IEntity}) : Implements IRepository(Of T)

    Private dbcontext As EventsContext
    Protected Friend Property dbset As DbSet(Of T)
    Private Event SequenceIsEmpty As IRepository(Of T).SequenceIsemptyMessage Implements IRepository(Of T).SequenceIsEmpty
    Private Event ElementNotFound As IRepository(Of T).ElementNotFoundMessage Implements IRepository(Of T).ElementNotFound
    Private Event EntityOpertionFailed As IRepository(Of T).EntityOperationFailedException Implements IRepository(Of T).EntityOpertionFailed

    Sub New(databasecontext As EventsContext)
        dbcontext = databasecontext
        dbset = dbcontext.Set(Of T)
    End Sub


    Public Function GetAll() As HashSet(Of T) Implements IRepository(Of T).GetAll
        Return dbset.Select(Of T)(Function(t) t).ToHashSet
    End Function

    Public Function GetItem(id As Integer) As T Implements IRepository(Of T).GetItem
        Return GetAll.FirstOrDefault(Function(t) t.Id = id)
    End Function

    'Public Function GetItem(id As Integer) As T Implements IRepository(Of T).GetItem
    '    Try
    '        Return GetAll.First(Function(t) t.Id = id)
    '    Catch ex As InvalidOperationException
    '        RaiseEvent ElementNotFound(id, $"Elment with id={id} not found, message: {ex.Message}")
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function

    Public Async Function GetItemAsync(id As Integer) As Task(Of T) Implements IRepository(Of T).GetItemAsync
        Return Await GetAll.AsQueryable.FirstOrDefaultAsync(Function(t) t.Id = id)
    End Function

    Public Function Count() As Long Implements IRepository(Of T).Count
        Return GetAll.Count
    End Function

    Public Function Add(entity As T) As HashSet(Of T) Implements IRepository(Of T).Add
        Dim all = GetAll.Append(entity)
        dbcontext.SaveChanges()
        Console.WriteLine(dbset.Count.ToString)
        Return GetAll()
    End Function

    Public Function Remove(id As Integer) As Boolean Implements IRepository(Of T).Remove
        Return Remove(GetItem(id))
    End Function

    Public Function Remove(entity As T) As Boolean Implements IRepository(Of T).Remove
        Return GetAll.Remove(entity)
    End Function

    Public Function Update(entity As T) As HashSet(Of T) Implements IRepository(Of T).Update
        Remove(entity.Id)
        Return Add(entity)
    End Function

End Class
