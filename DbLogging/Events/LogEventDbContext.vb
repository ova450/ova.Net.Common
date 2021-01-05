Imports System.Diagnostics.CodeAnalysis
Imports Microsoft.EntityFrameworkCore
Imports ova.Common.DbLogging.Events.Model

Namespace LogEvents

    Public Class LogEventsDbContextOptions : Inherits DbContextOptions

        Sub New()
            MyBase.New()
        End Sub

        Public Overrides ReadOnly Property ContextType As Type
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public Overrides Function WithExtension(Of TExtension As {Class, Infrastructure.IDbContextOptionsExtension})(<NotNullAttribute> extension As TExtension) As DbContextOptions
            Throw New NotImplementedException()
        End Function

        Public Class LogEventDbContext : Inherits DbContext

            Shared Sub New()

            End Sub

            Dim options As DbContextOptions = New DbContextOptions


            Public Sub New(conn)
                MyBase.New("DbEeventsConnection")
            End Sub

            Public Property EventObjects As ISet(Of EventObject) = New HashSet(Of EventObject)(_database)
            Public Property EventProcess As ISet(Of EventProcess) = New HashSet(Of EventProcess)(_database)
            Public Property EventStages As ISet(Of EventStage) = New HashSet(Of EventStage)(_database)
            Public Property EventFullElement As ISet(Of EventFullElement) = New HashSet(Of EventFullElement)(_database)

        End Class
    End Class
End Namespace