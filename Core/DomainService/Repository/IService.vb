

Namespace DomainService

    Public Interface IService(Of TEntity) '  where TEntity : Class //, New(Of)

        ' GetAll
        Function GetList() As IEnumerable(Of TEntity)                      ' быстрый запрос всей таблицы
        Function GetAll() As IQueryable(Of TEntity)                        ' запрос с последующей выборкой


        ' Count
        Function Count() As Long
        Function CountAsync() As Task(Of Long)

        ' Get
        Function [Get](id As Integer) As TEntity
        Function GetAsync(id As Integer) As Task(Of TEntity)


        ' Add
        Function Add(entity As TEntity) As TEntity
        Function Add() As TEntity
        Function AddAsync(entity As TEntity) As Task(Of TEntity)
        Function AddAsync() As Task(Of TEntity)

        ' Remove
        Function Remove(id As Integer) As TEntity
        Function RemoveAsync(id As Integer) As Task(Of TEntity)
        Function Remove(entity As TEntity) As TEntity
        Function RemoveAsync(entity As TEntity) As Task(Of TEntity)

        ' Update
        Function Update(entity As TEntity) As TEntity
        Function UpdateAsync(entity As TEntity) As Task(Of TEntity)

    End Interface
End Namespace