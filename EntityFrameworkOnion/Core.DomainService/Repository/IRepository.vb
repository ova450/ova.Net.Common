Imports ova.Common.EFOnion.Core.Domain

Public Interface IRepository(Of TEntity As {IEntityBase, Class}) '  where TEntity : Class //, New(Of)

    Function GetAll() As IQueryable(Of TEntity)                        ' запрос с последующей выборкой
    Function Count() As Long

    Function [Get](id As Integer) As TEntity
    Function GetAsync(id As Integer) As Task(Of TEntity)


    ' Add
    Function Add(entity As TEntity) As TEntity
    Function AddAsync(entity As TEntity) As Task(Of TEntity)

    ' Remove
    Function Remove(id As Integer) As TEntity
    Function RemoveAsync(id As Integer) As Task(Of TEntity)
    Function Remove(entity As TEntity) As TEntity
    Function RemoveAsync(entity As TEntity) As Task(Of TEntity)

    ' Update
    Function Update(entity As TEntity) As TEntity
    Function UpdateAsync(entity As TEntity) As Task(Of TEntity)

End Interface
