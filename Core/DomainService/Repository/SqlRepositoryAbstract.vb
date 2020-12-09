Imports ova.Common.Core.Domain

Namespace DomainService.Sql

    Public MustInherit Class SqlRepositoryAbstract(Of TEntity As {IEntityBase, Class}) : Implements IRepository(Of TEntity)

        Protected ReadOnly SqlContext As SqlDbContextAbstract

        Sub New(context As SqlDbContextAbstract)
            SqlContext = context
        End Sub

        Public Function GetAll() As IQueryable(Of TEntity) Implements IRepository(Of TEntity).GetAll
            Try
                Return SqlContext.Set(Of TEntity)
            Catch ex As Exception : Throw New Exception($"Couldn't retrieve entities: {ex.Message}")
            End Try
        End Function

        Public Function Count() As Long Implements IRepository(Of TEntity).Count
            Return GetAll.Count
        End Function

        Public Function [Get](id As Integer) As TEntity Implements IRepository(Of TEntity).Get
            Try
                Return GetAll.First(Function(x) x.Id = id)
            Catch ex As Exception : Throw New Exception($"Couldn't retrieve entity by id={id}: {ex.Message}")
            End Try
        End Function

        Public Async Function GetAsync(id As Integer) As Task(Of TEntity) Implements IRepository(Of TEntity).GetAsync
            Try
                Return Await SqlContext.FindAsync(Of TEntity)(Function(x) x.id = id)
            Catch ex As Exception : Throw New Exception($"Couldn't retrieve entity by id={id}: {ex.Message}")
            End Try
        End Function

        Public Function Add(entity As TEntity) As TEntity Implements IRepository(Of TEntity).Add
            Try
                With SqlContext
                    .Add(entity)
                    .SaveChanges()
                End With
                Return entity
            Catch ex As Exception : Throw New Exception($"Failed to add object: {ex.Message}")
            End Try
        End Function

        Public Async Function AddAsync(entity As TEntity) As Task(Of TEntity) Implements IRepository(Of TEntity).AddAsync
            Try
                With SqlContext
                    Await .AddAsync(entity)
                    Await .SaveChangesAsync()
                End With
                Return entity
            Catch ex As Exception : Throw New Exception($"Failed to add object: {ex.Message}")
            End Try
        End Function

        Public Function Remove(id As Integer) As TEntity Implements IRepository(Of TEntity).Remove
            Try
                Return Remove([Get](id))
            Catch ex As Exception : Throw New Exception($"Failed to remove object: {ex.Message}")
            End Try
        End Function

        Public Function Remove(entity As TEntity) As TEntity Implements IRepository(Of TEntity).Remove
            Try
                With SqlContext
                    .Remove(entity)
                    .SaveChanges()
                End With
                Return entity
            Catch ex As Exception : Throw New Exception($"Failed to remove object: {ex.Message}")
            End Try
        End Function

        Public Async Function RemoveAsync(id As Integer) As Task(Of TEntity) Implements IRepository(Of TEntity).RemoveAsync
            Try
                Return Await RemoveAsync([Get](id))
            Catch ex As Exception : Throw New Exception($"Failed to remove object: {ex.Message}")
            End Try
        End Function

        Public Async Function RemoveAsync(entity As TEntity) As Task(Of TEntity) Implements IRepository(Of TEntity).RemoveAsync
            Try
                With SqlContext
                    .Remove(entity)
                    Await .SaveChangesAsync()
                End With
                Return entity
            Catch ex As Exception : Throw New Exception($"Failed to remove object: {ex.Message}")
            End Try
        End Function

        Public Function Update(entity As TEntity) As TEntity Implements IRepository(Of TEntity).Update
            Try
                With SqlContext
                    .Update(entity)
                    .SaveChanges()
                End With
                Return entity
            Catch ex As Exception : Throw New Exception($"Failed to update object: {ex.Message}")
            End Try
        End Function

        Public Async Function UpdateAsync(entity As TEntity) As Task(Of TEntity) Implements IRepository(Of TEntity).UpdateAsync
            Try
                With SqlContext
                    .Update(entity)
                    Await .SaveChangesAsync
                End With
                Return entity
            Catch ex As Exception : Throw New Exception($"Failed to update object: {ex.Message}")
            End Try
        End Function

    End Class
End Namespace
