Imports System.Threading
Imports Microsoft.EntityFrameworkCore
Imports ova.Common.Core.Domain.Model
Imports ova.Common.Core.DomainService.SqlService

Namespace DomainService.Repository
    Public Class RepositoryAbstract(Of TEntity As {IEntityBase, Class})
        Implements IRepository(Of TEntity), IDisposable

        Private _context As ContextAbstract
        Private _dbSet As DbSet(Of TEntity)
        Private disposedValue As Boolean

        Sub New(databasecontext As ContextAbstract)
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

        Public Async Function GetItemAsync(id As Integer, Optional token As CancellationToken = Nothing) As Task(Of TEntity) Implements IRepository(Of TEntity).GetItemAsync
            Return Await _dbSet.FirstOrDefaultAsync(Function(p) p.Id = id, token)
        End Function


        Public Function Count() As Integer Implements IRepository(Of TEntity).Count
            Return _dbSet.LongCount()
        End Function
        Public Async Function CountAsync() As Task(Of Integer) Implements IRepository(Of TEntity).CountAsync
            Return Await _dbSet.LongCountAsync()
        End Function
        Public Async Function CountAsync(Optional token As CancellationToken = Nothing) As Task(Of Integer) Implements IRepository(Of TEntity).CountAsync
            Return Await _dbSet.CountAsync(token)
        End Function
        Public Function CountLong() As Long Implements IRepository(Of TEntity).CountLong
            Return _dbSet.LongCount()
        End Function
        Public Async Function CountLongAsync() As Task(Of Long) Implements IRepository(Of TEntity).CountLongAsync
            Return Await _dbSet.LongCountAsync()
        End Function
        Public Async Function CountLongAsync(Optional token As CancellationToken = Nothing) As Task(Of Long) Implements IRepository(Of TEntity).CountLongAsync
            Return Await _dbSet.CountAsync(token)
        End Function

        Public Function Add(entity As TEntity) As IQueryable(Of TEntity) Implements IRepository(Of TEntity).Add
            _dbSet.Add(entity)
            Return _dbSet
        End Function
        Public Async Function AddAsync(entity As TEntity) As Task(Of IQueryable(Of TEntity)) Implements IRepository(Of TEntity).AddAsync
            Return Await _dbSet.AddAsync(entity)
        End Function
        Public Async Function AddAsync(entity As TEntity, Optional token As CancellationToken = Nothing) As Task(Of IQueryable(Of TEntity)) Implements IRepository(Of TEntity).AddAsync
            Return Await _dbSet.AddAsync(entity, token)
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
        Public Async Function RemoveAsync(id As Integer, Optional token As CancellationToken = Nothing) As Task(Of IQueryable(Of TEntity)) Implements IRepository(Of TEntity).RemoveAsync
            Await Task.Run(Function() Remove(id), token)
            Return _dbSet
        End Function
        Public Async Function RemoveAsync(entity As TEntity) As Task(Of IQueryable(Of TEntity)) Implements IRepository(Of TEntity).RemoveAsync
            Await Task.Run(Function() Remove(entity))
            Return _dbSet
        End Function
        Public Async Function RemoveAsync(entity As TEntity, Optional token As CancellationToken = Nothing) As Task(Of IQueryable(Of TEntity)) Implements IRepository(Of TEntity).RemoveAsync
            Await Task.Run(Function() Remove(entity), token)
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
        Public Async Function UpdateAsync(entity As TEntity, Optional token As CancellationToken = Nothing) As Task(Of IQueryable(Of TEntity)) Implements IRepository(Of TEntity).UpdateAsync
            Await Task.Run(Function() Update(entity), token)
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

#Region "Dispose"
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: освободить управляемое состояние (управляемые объекты)
                    _dbSet = Nothing
                End If

                ' TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                ' TODO: установить значение NULL для больших полей
                _context.Dispose
                disposedValue = True
            End If
        End Sub

        ' ' TODO: переопределить метод завершения, только если "Dispose(disposing As Boolean)" содержит код для освобождения неуправляемых ресурсов
        Protected Overrides Sub Finalize()
            ' Не изменяйте этот код. Разместите код очистки в методе "Dispose(disposing As Boolean)".
            Dispose(disposing:=False)
            MyBase.Finalize()
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            ' Не изменяйте этот код. Разместите код очистки в методе "Dispose(disposing As Boolean)".
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace