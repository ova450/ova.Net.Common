
Imports Microsoft.Extensions.Logging

Public Class FileLoggerProvider : Implements ILoggerProvider

    Private _path As String

    Private disposedValue As Boolean

    Public Sub New(path As String)
        _path = path
    End Sub

    Public Function CreateLogger(categoryName As String) As ILogger Implements ILoggerProvider.CreateLogger
        Return New FileLogger(_path)
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: освободить управляемое состояние (управляемые объекты)
            End If

            ' TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
            ' TODO: установить значение NULL для больших полей
            disposedValue = True
        End If
    End Sub

    ' ' TODO: переопределить метод завершения, только если "Dispose(disposing As Boolean)" содержит код для освобождения неуправляемых ресурсов
    ' Protected Overrides Sub Finalize()
    '     ' Не изменяйте этот код. Разместите код очистки в методе "Dispose(disposing As Boolean)".
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Не изменяйте этот код. Разместите код очистки в методе "Dispose(disposing As Boolean)".
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub

End Class