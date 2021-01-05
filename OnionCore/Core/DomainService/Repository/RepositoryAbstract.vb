Imports Microsoft.EntityFrameworkCore
Imports ova.Common.Core.Domain.Model

Namespace DomainService.Repository
    Public Class RepositoryAbstract(Of TEntity As {IEntityBase, Class})
        Implements IRepository(Of TEntity)

        Public Context As DbContext
        Private _dbSet As ISet(Of TEntity)

        Sub New(databasecontext As DbContext)
            Context = databasecontext
            _dbSet = Context.Set(Of TEntity)
        End Sub

        Public Event SequenceIsEmpty As IRepository(Of TEntity).SequenceIsemptyMessage Implements IRepository(Of TEntity).SequenceIsEmpty
        Public Event ElementNotFound As IRepository(Of TEntity).ElementNotFoundMessage Implements IRepository(Of TEntity).ElementNotFound
        Public Event EntityOpertionFailed As IRepository(Of TEntity).EntityOperationFailedException Implements IRepository(Of TEntity).EntityOpertionFailed
        'Public Event AddingFailed As IRepository(Of TEntity).EntityOperationFailedException Implements IRepository(Of TEntity).AddingFailed
        'Public Event RemovingFailed As IRepository(Of TEntity).EntityOperationFailedException Implements IRepository(Of TEntity).RemovingFailed

        Public Function GetAll() As HashSet(Of TEntity) Implements IRepository(Of TEntity).GetAll
            If _dbSet.Count = 0 Then RaiseEvent SequenceIsEmpty($"Sequence id empty")
            Return _dbSet
        End Function

        Public Function GetItem(id As Integer) As TEntity Implements IRepository(Of TEntity).GetItem
            Dim result = Nothing
            Try
                result = GetAll.First(Function(p) p.Id = id)
            Catch ex As ArgumentNullException
                RaiseEvent ElementNotFound(id, $"Id is null, ArgumentNullException is called for id = {id}: {ex.Message }")
            Catch ex As InvalidOperationException
                If GetAll.Count = 0 Then
                    RaiseEvent SequenceIsEmpty($"Sequence id empty, InvalidOperationException is called for id = {id}: {ex.Message}")
                Else
                    RaiseEvent ElementNotFound(id, $"Item with id={id} not found, InvalidOperationException is called for id = {id}: {ex.Message}")
                End If
            End Try
            Return result
        End Function

        Public Async Function GetItemAsync(id As Integer) As Task(Of TEntity) Implements IRepository(Of TEntity).GetItemAsync
            Dim result = Nothing
            Try
                result = Await GetAll.AsQueryable.FirstAsync(Function(p) p.Id = id)
            Catch ex As ArgumentNullException
                RaiseEvent ElementNotFound(id, $"Id is null, ArgumentNullException is called for id = {id}: {ex.Message }")
            Catch ex As InvalidOperationException
                If GetAll.Count = 0 Then
                    RaiseEvent SequenceIsEmpty($"Sequence id empty, InvalidOperationException is called for id = {id}: {ex.Message}")
                Else
                    RaiseEvent ElementNotFound(id, $"Item with id={id} not found, InvalidOperationException is called for id = {id}: {ex.Message}")
                End If
            End Try
            Return result
        End Function

        Public Function Count() As Long Implements IRepository(Of TEntity).Count
            Return _dbSet.Count
        End Function

        Public Function Add(entity As TEntity) As HashSet(Of TEntity) Implements IRepository(Of TEntity).Add
            Return GetAll.Append(entity)
        End Function

        'Public Function AddAsync(entity As TEntity) As Task(Of TSequense) Implements IRepository(Of TEntity).AddAsync
        '    If GetAll.Addasync(entity) Then Return DbSet Else RaiseEvent AddingFailed(entity, $"Adding failed, id = {entity.Id}")
        'End Function

        Public Function Remove(entity As TEntity) As Boolean Implements IRepository(Of TEntity).Remove
            Return GetAll.Remove(entity)
        End Function

        Public Function Remove(id As Integer) As Boolean Implements IRepository(Of TEntity).Remove
            Return GetAll.RemoveWhere(Function(p) p.Id = id)
        End Function
        'Public Function RemoveAsync(id As Integer) As Task(Of TSequense) Implements IRepository(Of TEntity).RemoveAsync
        '    Throw New NotImplementedException()
        'End Function

        'Public Function RemoveAsync(entity As TEntity) As Task(Of TSequense) Implements IRepository(Of TEntity).RemoveAsync
        '    Throw New NotImplementedException()
        'End Function

        Public Function Update(entity As TEntity) As HashSet(Of TEntity) Implements IRepository(Of TEntity).Update
            Remove(entity.Id)
            Return Add(entity)
        End Function

        'Public Function UpdateAsync(entity As TEntity) As Task(Of TSequense) Implements IRepository(Of TEntity).UpdateAsync
        '    Throw New NotImplementedException()
        'End Function
    End Class
End Namespace