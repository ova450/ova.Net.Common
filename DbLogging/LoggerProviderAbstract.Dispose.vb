Namespace Abstract
    Partial Public MustInherit Class LoggerProvider : Implements IDisposable

        Protected SettingsChangeToken As IDisposable
        Private disposedValue As Boolean

        Protected Overrides Sub Finalize()
            If Not Me.IsDisposed Then Dispose(False)
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: освободить управляемое состояние (управляемые объекты)
                    If SettingsChangeToken IsNot Nothing Then
                        SettingsChangeToken.Dispose()
                        SettingsChangeToken = Nothing
                    End If
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
            Me.IsDisposed = True
            GC.SuppressFinalize(Me)
        End Sub

        Public Property IsDisposed As Boolean

    End Class

End Namespace