﻿Imports System.IO
Imports System.Text.Json
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports ova.Common.Core.Domain.Model

Namespace DomainService.SqlService

    Public MustInherit Class EntityConfigAbstract(Of T As {Class, IEntityBase}) : Implements IEntityTypeConfiguration(Of T)

        Private ReadOnly PrimaryKeys() As String = {"Id"}

        Public Sub New(ParamArray primarykeys() As String)
            Me.PrimaryKeys.Union(primarykeys)
        End Sub

        Public Sub Configure(builder As EntityTypeBuilder(Of T)) Implements IEntityTypeConfiguration(Of T).Configure
            Relations(builder)
            InitialFromJson(builder)
        End Sub

        Public Overridable Sub Relations(builder As EntityTypeBuilder(Of T))
        End Sub

        Public Overridable Async Sub InitialFromJson(builder As EntityTypeBuilder(Of T), Optional subdirectory As String = "initial", Optional suffix As String = "Initial", Optional filenameextension As String = "json")
            Dim fn As String = $"{AppDomain.CurrentDomain.BaseDirectory}{subdirectory}\{GetType(T).Name}{suffix }.{filenameextension}"
            fn = fn.Replace("/", "\")
            If Not File.Exists(fn) Then
                RaiseEvent FileNotFound(Me, fn, Nothing)
                Exit Sub
            End If
            Using fs As FileStream = New FileStream(fn, FileMode.OpenOrCreate)
                Dim Items As T()
                Try
                    Items = Await JsonSerializer.DeserializeAsync(Of T())(fs)
                    builder.HasData(Items)
                Catch ex As Exception
                    Items = Nothing
                    RaiseEvent FileIsIncorrect(Me, fn, ex)
                End Try
            End Using
        End Sub


        Delegate Sub FileIsIncorrectEventHandler(sender As Object, filename As String, innerexception As JsonException)
        Delegate Sub FileNotFoundEventHandler(sender As Object, filename As String, innerexception As FileNotFoundException)
        Public Event FileNotFound As FileNotFoundEventHandler
        Public Event FileIsIncorrect As FileIsIncorrectEventHandler

    End Class

End Namespace