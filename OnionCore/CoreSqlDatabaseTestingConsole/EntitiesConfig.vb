Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports ova.Common.Core.DomainService.SqlService

Public Class BookConfig : Inherits EntityConfigAbstract(Of Book)
    'Sub New()
    '    MyBase.New : End Sub

    Public Overrides Sub Relations(builder As EntityTypeBuilder(Of Book))

        builder.
            HasOne(Function(a) a.Author).
            WithMany(Function(b) b.Books).
            HasForeignKey(Function(f) f.AuthorId).
            OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade)
    End Sub

End Class
