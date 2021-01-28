Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders

Public Class BookConfig : Implements IEntityTypeConfiguration(Of Book)

    Public Sub Configure(builder As EntityTypeBuilder(Of Book)) Implements IEntityTypeConfiguration(Of Book).Configure
        builder.
            HasOne(Function(a) a.Author).
            WithMany(Function(b) b.Books).
            HasForeignKey(Function(f) f.AuthorId).
            OnDelete(DeleteBehavior.Cascade)
    End Sub
End Class
