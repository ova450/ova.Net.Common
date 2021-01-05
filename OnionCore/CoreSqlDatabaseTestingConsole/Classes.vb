Imports System.ComponentModel.DataAnnotations.Schema
Imports ova.Common.Core.Domain.Model
Imports ova.Common.Core.Domain.Navigation


Public Class Author : Implements IAuthor, IEntity, INavigationChild(Of Book)

    Public Property Id As Integer Implements IEntityBase.Id
    Public Property Name As String Implements IEntity.Name

    <NotMapped> Public Property Books As HashSet(Of Book) Implements INavigationChild(Of Book).Childs

End Class

Public Class Book : Implements IBook, IEntity, INavigationParent(Of Author)

    Public Property Id As Integer Implements IEntityBase.Id
    Public Property Name As String Implements IEntity.Name

    <NotMapped> Public Property AuthorId As Integer Implements INavigationParent(Of Author).ParentId
    <NotMapped> <ForeignKey("AuthorId")> Public Property Author As Author Implements INavigationParent(Of Author).Parent

End Class
