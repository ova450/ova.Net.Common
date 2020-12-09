Imports Common.EntityFramework.Model

Namespace Json

    Public Class JsonRepositoryAbstract(Of TEntity As {IEntityBase, Class}) : Implements IRepository(Of IEntityBase)

        Protected ReadOnly SqlContext As JsonDbContextAbstract

        Sub New(context As JsonDbContextAbstract)
            SqlContext = context
        End Sub

        Public Function GetAll() As IQueryable(Of IEntityBase) Implements IRepository(Of IEntityBase).GetAll
            Try
                Return SqlContext.Set(Of TEntity)
            Catch ex As Exception : Throw New Exception($"Couldn't retrieve entities: {ex.Message}")
            End Try
        End Function

        Public Function Count() As Long Implements IRepository(Of IEntityBase).Count
            Return GetAll.Count
        End Function

        Public Function [Get](id As Integer) As IEntityBase Implements IRepository(Of IEntityBase).Get
            Try
                Return GetAll.First(Function(x) x.Id = id)
            Catch ex As Exception : Throw New Exception($"Couldn't retrieve entity by id={id}: {ex.Message}")
            End Try
        End Function

        Public Async Function GetAsync(id As Integer) As Task(Of IEntityBase) Implements IRepository(Of IEntityBase).GetAsync
            Try
                Return Await SqlContext.FindAsync(Of TEntity)(Function(x) x.id = id)
            Catch ex As Exception : Throw New Exception($"Couldn't retrieve entity by id={id}: {ex.Message}")
            End Try
        End Function

        Public Function Add(entity As IEntityBase) As IEntityBase Implements IRepository(Of IEntityBase).Add
            Try
                With SqlContext
                    .Add(entity)
                    .SaveChanges()
                End With
                Return entity
            Catch ex As Exception : Throw New Exception($"Failed to add object: {ex.Message}")
            End Try
        End Function

        Public Async Function AddAsync(entity As IEntityBase) As Task(Of IEntityBase) Implements IRepository(Of IEntityBase).AddAsync
            Try
                With SqlContext
                    Await .AddAsync(entity)
                    Await .SaveChangesAsync()
                End With
                Return entity
            Catch ex As Exception : Throw New Exception($"Failed to add object: {ex.Message}")
            End Try
        End Function

        Public Function Remove(id As Integer) As IEntityBase Implements IRepository(Of IEntityBase).Remove
            Try
                Return Remove([Get](id))
            Catch ex As Exception : Throw New Exception($"Failed to remove object: {ex.Message}")
            End Try
        End Function

        Public Function Remove(entity As IEntityBase) As IEntityBase Implements IRepository(Of IEntityBase).Remove
            Try
                With SqlContext
                    .Remove(entity)
                    .SaveChanges()
                End With
                Return entity
            Catch ex As Exception : Throw New Exception($"Failed to remove object: {ex.Message}")
            End Try
        End Function

        Public Async Function RemoveAsync(id As Integer) As Task(Of IEntityBase) Implements IRepository(Of IEntityBase).RemoveAsync
            Try
                Return Await RemoveAsync([Get](id))
            Catch ex As Exception : Throw New Exception($"Failed to remove object: {ex.Message}")
            End Try
        End Function

        Public Async Function RemoveAsync(entity As IEntityBase) As Task(Of IEntityBase) Implements IRepository(Of IEntityBase).RemoveAsync
            Try
                With SqlContext
                    .Remove(entity)
                    Await .SaveChangesAsync()
                End With
                Return entity
            Catch ex As Exception : Throw New Exception($"Failed to remove object: {ex.Message}")
            End Try
        End Function

        Public Function Update(entity As IEntityBase) As IEntityBase Implements IRepository(Of IEntityBase).Update
            Try
                With SqlContext
                    .Update(entity)
                    .SaveChanges()
                End With
                Return entity
            Catch ex As Exception : Throw New Exception($"Failed to update object: {ex.Message}")
            End Try
        End Function

        Public Async Function UpdateAsync(entity As IEntityBase) As Task(Of IEntityBase) Implements IRepository(Of IEntityBase).UpdateAsync
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
