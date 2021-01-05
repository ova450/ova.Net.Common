Imports System.IO
Imports System.Runtime.Serialization.Json
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports ova.Common.Core.Domain

Public MustInherit Class EntityConfigAbstract(Of T As {Class, IEntityBase}) : Implements IEntityTypeConfiguration(Of T)

    Private ReadOnly PrimaryKeys() As String = {"Id"}

    Public Sub New() : End Sub

    Public Sub New(ParamArray primarykeys() As String)
        Me.PrimaryKeys.Union(primarykeys)
    End Sub

    Public Sub Configure(builder As EntityTypeBuilder(Of T)) Implements IEntityTypeConfiguration(Of T).Configure
        'With builder
        '    Me.entity(T)
        '    .HasKey(PrimaryKeys)
        'End With
        Relations(builder)
        InitialFromJson(builder)
    End Sub

    Public MustOverride Sub Relations(builder As EntityTypeBuilder(Of T))
    'With builder
    '        '.entity(T)
    '        .HasKey(PrimaryKeys)
    '    End With

    'End Sub

    Public Overridable Sub InitialFromJson(builder As EntityTypeBuilder(Of T), Optional subdirectory As String = "entities", Optional suffix As String = "Initial", Optional filenameextension As String = "json")
        Dim fn As String = $"{AppDomain.CurrentDomain.BaseDirectory}{subdirectory}/{GetType(T).Name}{suffix }.{filenameextension}"
        Dim Items As T() = Array.Empty(Of T)()
        Dim JsonFormatter As DataContractJsonSerializer = New DataContractJsonSerializer(Items.GetType)
        If File.Exists(fn) Then
            Dim fs As FileStream = New FileStream(fn, FileMode.OpenOrCreate)
            Using (fs)
                Dim json = JsonFormatter.ReadObject(fs)
                Items = json
                builder.HasData(Items)
            End Using
        End If
    End Sub

End Class
