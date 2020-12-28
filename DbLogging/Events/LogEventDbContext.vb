Imports JsonFileDB
Imports ova.Common.DbLogging.Events.Model

Namespace Events

    Public Class EventDbContext : Inherits DBContext : Implements IDBContext

        Public Sub New()
            MyBase.New("eventdatabase.json")
        End Sub

        Public Property EventObjects As Dataset(Of EventObject) = New Dataset(Of EventObject)(_database)
        Public Property EventProcess As Dataset(Of EventProcess) = New Dataset(Of EventProcess)(_database)
        Public Property EventStages As Dataset(Of EventStage) = New Dataset(Of EventStage)(_database)
        Public Property EventFullElement As Dataset(Of EventFullElement) = New Dataset(Of EventFullElement)(_database)

    End Class

End Namespace