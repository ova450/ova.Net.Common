Imports ova.Common.Core.Domain.Model

Namespace DomainService.Repository


    Public Interface IRepository(Of TEntity As {IEntityBase, Class})  ' where TEntity : Class //, New(Of)

        Delegate Sub SequenceIsemptyMessage(message As String)
        Delegate Sub ElementNotFoundMessage(id As Integer, message As String)
        Delegate Sub EntityOperationFailedException(entity As TEntity, message As String, exception As Exception)
        Delegate Sub AddingFailedMessage(entity As TEntity, message As String)
        Event SequenceIsEmpty As SequenceIsemptyMessage
        Event ElementNotFound As ElementNotFoundMessage
        Event EntityOpertionFailed As EntityOperationFailedException
        'Event AddingFailed As EntityOperationFailedException
        'Event RemovingFailed As EntityOperationFailedException

        Function GetAll() As HashSet(Of TEntity)

        Function GetItem(id As Integer) As TEntity
        Function GetItemAsync(id As Integer) As Task(Of TEntity)

        Function Count() As Long

        ' Add
        Function Add(entity As TEntity) As HashSet(Of TEntity)
        'Function AddAsync(entity As TEntity) As Task(Of TSequence)

        ' Remove
        Function Remove(id As Integer) As Boolean
        Function Remove(entity As TEntity) As Boolean
        'Function RemoveAsync(id As Integer) As Task(Of TSequence)
        'Function RemoveAsync(entity As TEntity) As Task(Of TSequence)

        ' Update
        Function Update(entity As TEntity) As HashSet(Of TEntity)
        'Function UpdateAsync(entity As TEntity) As Task(Of TSequence)

        'Event UpdatingFailed As EntityOpertionFailedMessage

    End Interface
End Namespace