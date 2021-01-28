Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports ova.Common.Core.Domain.Model

Namespace DomainService.SqlService

    Public Class EntityConfig(Of T As {Class, IEntityBase}) : Implements IEntityTypeConfiguration(Of T)

        Private ReadOnly PrimaryKeys() As String = {"Id"}

        Public Sub New(ParamArray primarykeys() As String)
            Me.PrimaryKeys.Union(primarykeys)
        End Sub

        Public Overridable Sub Configure(builder As EntityTypeBuilder(Of T)) Implements IEntityTypeConfiguration(Of T).Configure
        End Sub

    End Class

End Namespace