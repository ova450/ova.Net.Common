'<HideModuleName>
Imports System.Runtime.CompilerServices

Public Module Base

    ''' <summary>
    ''' Interval from the beginning of the UnixEpoch to the specified date and time
    ''' </summary>
    ''' <param name="datetime"> as DateTime (local or utc) or DateTimeOffset</param>
    ''' <returns>Interval as TimeSpan</returns>
    <Extension>
    Public Function UnixTimespan(utcdatetime As DateTime) As TimeSpan
        Return (utcdatetime - DateTime.UnixEpoch)
    End Function

    ''' <summary>
    ''' Interval from the beginning of the UnixEpoch to the current date and time
    ''' </summary>
    ''' <returns>Interval as TimeSpan</returns>
    Public Function UnixTimespan() As TimeSpan
        Return UnixTimespan(Now)
    End Function

    ''' <summary>
    ''' Returns the current UnixTime, expressed as an integer number of milliseconds since the start of the UnixEpoch
    ''' </summary>
    Public Function Timestamp() As Long
        Return CLng(UnixTimespan.Ticks)
    End Function

End Module
