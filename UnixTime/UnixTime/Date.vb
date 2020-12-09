

Imports System.Runtime.CompilerServices

'<HideModuleName>
Public Module [Date]

    ''' <summary>
    ''' Converts standard UnixTime, expressed in whole and fractional number of seconds, to Coordinated Universal Time (UTC) and returns as DateTime structure
    ''' </summary>
    ''' <param name="unixtime"></param>
    ''' <returns>UTC as DateTime structure</returns>
    <Extension>
    Public Function FromUnixTime(unixtimeseconds As Double) As Date
        Return DateTime.UnixEpoch.AddSeconds(unixtimeseconds) : End Function

    ''' <summary>
    ''' Converts UnixTime, expressed in whole number of ticks, to Coordinated Universal Time (UTC) and returns as DateTime structure
    ''' </summary>
    ''' <param name="unixtime_ticks"></param>
    ''' <returns>UTC as DateTime structure</returns>
    <Extension>
    Public Function FromTimestamp(unixtimeticks As Long) As System.DateTime
        Return FromUnixTime(unixtimeticks / 1000 / 10000) : End Function

End Module



