Imports System.Reflection
Imports System.Threading
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Imports ova.Common.Core.Domain.Model

Namespace DomainService.Repository

    Public Interface IRepository(Of TEntity As {IEntityBase, Class})  ' where TEntity : Class //, New(Of)

        'Delegate Sub EntitySearchDelegate(id As Integer, message As String)
        'Event EntityNotFound As EntitySearchDelegate
        'Event EntityFounded As EntitySearchDelegate


        'Delegate Sub SequenceIsEmptyDelegate()

        'Delegate Sub EntityOperationDelegate(typeinfo As TypeInfo, methodinfo As MethodInfo, entity As TEntity, message As String)
        'Delegate Sub EntityOperationFailedDelegate(entity As TEntity, message As String)
        'Delegate Sub EntityOperationFailedExceptionDelegate(entity As TEntity, message As String, exception As Exception)

        'Event SequenceIsEmpty As SequenceIsEmptyDelegate

        'Event EntityOperationDone As EntityOperationDelegate
        'Event EntityOperationFailed As EntityOperationFailedDelegate
        'Event EntityOperationFailedException As EntityOperationFailedExceptionDelegate

        'Event AddingDone As EntityOperationDelegate
        'Event AddingFailed As EntityOperationFailedDelegate
        'Event AddingFailedException As EntityOperationFailedExceptionDelegate

        'Event RemovingDone As EntityOperationDelegate
        'Event RemovingFailed As EntityOperationFailedDelegate
        'Event RemovingFailedException As EntityOperationFailedExceptionDelegate

        'Event UpdatingDone As EntityOperationDelegate
        'Event UpdatingFailed As EntityOperationFailedDelegate
        'Event UpdatingFailedException As EntityOperationFailedExceptionDelegate

        Function GetAll() As IQueryable(Of TEntity)

        Function GetItem(id As Integer) As TEntity
        Function GetItemAsync(id As Integer) As Task(Of TEntity)
        Function GetItemAsync(id As Integer, Optional token As CancellationToken = Nothing) As Task(Of TEntity)

        Function Count() As Integer
        Function CountAsync() As Task(Of Integer)
        Function CountAsync(Optional token As CancellationToken = Nothing) As Task(Of Integer)
        Function CountLong() As Long
        Function CountLongAsync() As Task(Of Long)
        Function CountLongAsync(Optional token As CancellationToken = Nothing) As Task(Of Long)


        ' Add
        Function Add(entity As TEntity) As EntityEntry(Of TEntity)
        Function AddAsync(entity As TEntity) As Task(Of EntityEntry(Of TEntity))
        Function AddAsync(entity As TEntity, Optional token As CancellationToken = Nothing) As Task(Of EntityEntry(Of TEntity))

        ' Remove
        Function Remove(id As Integer) As EntityEntry(Of TEntity)
        Function Remove(entity As TEntity) As EntityEntry(Of TEntity)
        Function RemoveAsync(id As Integer) As Task(Of EntityEntry(Of TEntity))
        Function RemoveAsync(id As Integer, Optional token As CancellationToken = Nothing) As Task(Of EntityEntry(Of TEntity))
        Function RemoveAsync(entity As TEntity) As Task(Of EntityEntry(Of TEntity))
        Function RemoveAsync(entity As TEntity, Optional token As CancellationToken = Nothing) As Task(Of EntityEntry(Of TEntity))

        ' Update
        Function Update(entity As TEntity) As EntityEntry(Of TEntity)
        Function UpdateAsync(entity As TEntity) As Task(Of EntityEntry(Of TEntity))
        Function UpdateAsync(entity As TEntity, Optional token As CancellationToken = Nothing) As Task(Of EntityEntry(Of TEntity))

    End Interface
End Namespace