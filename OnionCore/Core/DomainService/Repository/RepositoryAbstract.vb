Imports System.Reflection
Imports Microsoft.EntityFrameworkCore
Imports ova.Common.Core.Domain.Model
Imports ova.Common.Core.DomainService.SqlService

Namespace DomainService.Repository
    Public Class RepositoryAbstract(Of TEntity As {IEntityBase, Class})
        Implements IRepository(Of TEntity)

        Private _context As DbContextAbstract
        Private _dbSet As DbSet(Of TEntity)

        Sub New(databasecontext As DbContextAbstract)
            _context = databasecontext
            _dbSet = _context.Set(Of TEntity)
        End Sub

        Public Function GetAll() As IQueryable(Of TEntity) Implements IRepository(Of TEntity).GetAll
            Return _dbSet
        End Function

        Public Function GetItem(id As Integer) As TEntity Implements IRepository(Of TEntity).GetItem
            Return _dbSet.FirstOrDefault(Function(p) p.Id = id)
        End Function

        Public Async Function GetItemAsync(id As Integer) As Task(Of TEntity) Implements IRepository(Of TEntity).GetItemAsync
            Return Await _dbSet.FirstOrDefaultAsync(Function(p) p.Id = id)
        End Function

        Public Function Count() As Long Implements IRepository(Of TEntity).Count
            Return _dbSet.Count
        End Function

        Public Async Function CountAsync() As Task(Of Long)
            Return Await _dbSet.CountAsync
        End Function

        Public Function Add(entity As TEntity) As IQueryable(Of TEntity) Implements IRepository(Of TEntity).Add
            _dbSet.Add(entity)
            Return _dbSet
        End Function

        Public Async Function AddAsync(entity As TEntity) As Task(Of IQueryable(Of TEntity)) Implements IRepository(Of TEntity).AddAsync
            Await _dbSet.AddAsync(entity, Nothing)
            Return _dbSet
        End Function

        Public Function Remove(entity As TEntity) As IQueryable(Of TEntity) Implements IRepository(Of TEntity).Remove
            _dbSet.Remove(entity)
            Return _dbSet
        End Function

        Public Function Remove(id As Integer) As IQueryable(Of TEntity) Implements IRepository(Of TEntity).Remove
            _dbSet.Remove(GetItem(id))
            Return _dbSet
        End Function

        Public Async Function RemoveAsync(id As Integer) As Task(Of IQueryable(Of TEntity)) Implements IRepository(Of TEntity).RemoveAsync
            Await Task.Run(Function() Remove(id))
            Return _dbSet
        End Function

        Public Async Function RemoveAsync(entity As TEntity) As Task(Of IQueryable(Of TEntity)) Implements IRepository(Of TEntity).RemoveAsync
            Await Task.Run(Function() Remove(entity))
            Return _dbSet
        End Function

        Public Function Update(entity As TEntity) As IQueryable(Of TEntity) Implements IRepository(Of TEntity).Update
            _dbSet.Update(entity)
            Return _dbSet
        End Function

        Public Async Function UpdateAsync(entity As TEntity) As Task(Of IQueryable(Of TEntity)) Implements IRepository(Of TEntity).UpdateAsync
            Await Task.Run(Function() Update(entity))
            Return _dbSet
        End Function

#Region "Save"
        Public Sub Save() 'As IQueryable(Of TEntity)
            _context.SaveChanges(True)
        End Sub

        Public Async Sub SaveAsync() 'As Task(Of IQueryable(Of TEntity))
            Await _context.SaveChangesAsync(True)
        End Sub
#End Region

    End Class
End Namespace