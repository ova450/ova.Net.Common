﻿Imports ova.Common.Core.DomainService
Imports ova.Common.DbLogging.Events
Imports ova.Common.DbLogging.Events.Model
Imports ova.Common.SqlDbLoggingEvents.Model

Namespace Data

    'Public Sub Add(entity As E)
    '    Public Sub Remove(id As Object)
    '    Public Sub Update(entity As E)

    '    Public Function GetAll() As IEnumerable(Of E)
    '    <AsyncStateMachineAttribute(GetType(Dataset(Of Object).<GetAllAsync>d__6))> <DebuggerStepThrough>
    '    Public Function GetAllAsync() As Task(Of IEnumerable(Of E))
    '    Public Function Find(id As Object) As E
    '    <AsyncStateMachineAttribute(GetType(Dataset(Of Object).<FindAsync>d__9))> <DebuggerStepThrough>
    '    Public Function FindAsync(id As Object) As Task(Of E)

    Public Class EventObjectRepository : Inherits RepositoryAbstract(Of EventObject, IQueryable(Of EventObject))

        Private dbcontext As EventDbContext = New EventDbContext
        Private dbset As Dataset(Of EventObject)
        Sub New(databasecontext As EventDbContext)
            dbcontext = databasecontext
        End Sub

        Public Function GetAll() As IQueryable(Of EventObject) Implements IRepository(Of EventObject).GetAll
            Throw New NotImplementedException()
        End Function

        Public Function Count() As Long Implements IRepository(Of EventObject).Count
            Throw New NotImplementedException()
        End Function

        Public Function [Get](id As Integer) As EventObject Implements IRepository(Of EventObject).Get
            Throw New NotImplementedException()
        End Function

        Public Function GetAsync(id As Integer) As Task(Of EventObject) Implements IRepository(Of EventObject).GetAsync
            Throw New NotImplementedException()
        End Function

        Public Function Add(entity As EventObject) As EventObject Implements IRepository(Of EventObject).Add
            Throw New NotImplementedException()
        End Function

        Public Function AddAsync(entity As EventObject) As Task(Of EventObject) Implements IRepository(Of EventObject).AddAsync
            Throw New NotImplementedException()
        End Function

        Public Function Remove(id As Integer) As EventObject Implements IRepository(Of EventObject).Remove
            Throw New NotImplementedException()
        End Function

        Public Function Remove(entity As EventObject) As EventObject Implements IRepository(Of EventObject).Remove
            Throw New NotImplementedException()
        End Function

        Public Function RemoveAsync(id As Integer) As Task(Of EventObject) Implements IRepository(Of EventObject).RemoveAsync
            Throw New NotImplementedException()
        End Function

        Public Function RemoveAsync(entity As EventObject) As Task(Of EventObject) Implements IRepository(Of EventObject).RemoveAsync
            Throw New NotImplementedException()
        End Function

        Public Function Update(entity As EventObject) As EventObject Implements IRepository(Of EventObject).Update
            Throw New NotImplementedException()
        End Function

        Public Function UpdateAsync(entity As EventObject) As Task(Of EventObject) Implements IRepository(Of EventObject).UpdateAsync
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace