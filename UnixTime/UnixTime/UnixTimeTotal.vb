Imports System.Runtime.CompilerServices

'<HideModuleName>
Public Module UnixTimeTotal

    ''' <summary>
    ''' Converts Coordinated Universal Time (UTC) as DateTime structure to UnixTime, expressed in whole number of ticks as long.
    ''' </summary>
    ''' <param name="datetime">the datetime parameter is an instance of DateTime (UTC) or DateTimeOffset</param>
    ''' <returns>Number of ticks since the beginning of the UnixEpoch</returns>
    <Extension>
    Public Function Ticks(datetime As DateTime) As Long
        Return datetime.UnixTimespan.Ticks : End Function

    ''' <summary>
    ''' Converts Coordinated Universal Time (UTC) as DateTime structure to UnixTime, expressed in whole and fractional number of milliseconds.
    ''' </summary>
    ''' <param name="datetime">the datetime parameter is an instance of DateTime (UTC) or DateTimeOffset</param>
    ''' <returns>Number of milliseconds since the beginning of the UnixEpoch</returns>
    <Extension>
    Public Function TotalMilliseconds(datetime As DateTime) As Double
        Return datetime.UnixTimespan.TotalMilliseconds : End Function

    ''' <summary>
    ''' Converts Coordinated Universal Time (UTC) as DateTime structure to UnixTime, expressed in whole and fractional number of seconds.
    ''' </summary> 
    ''' <param name="datetime">the datetime parameter is an instance of DateTime (UTC) or DateTimeOffset</param>
    ''' <returns>Number of seconds since the beginning of the UnixEpoch</returns>
    <Extension>
    Public Function TotalSeconds(datetime As DateTime) As Double
        Return datetime.UnixTimespan.TotalSeconds : End Function

    ''' <summary>
    ''' Converts Coordinated Universal Time (UTC) as DateTime structure to UnixTime, expressed in whole and fractional number of minutes.
    ''' </summary>
    ''' <param name="datetime">the datetime parameter is an instance of DateTime (UTC) or DateTimeOffset</param>
    ''' <returns>Number of minutes since the beginning of the UnixEpoch</returns>
    <Extension>
    Public Function TotalMinutes(datetime As DateTime) As Double
        Return datetime.UnixTimespan.TotalMinutes : End Function

    ''' <summary>
    ''' Converts Coordinated Universal Time (UTC) as DateTime structure to UnixTime, expressed in whole and fractional number of hours.
    ''' </summary>
    ''' <param name="datetime">the datetime parameter is an instance of DateTime (UTC) or DateTimeOffset</param>
    ''' <returns>Number of hours since the beginning of the UnixEpoch</returns>
    <Extension>
    Public Function TotalHours(datetime As DateTime) As Double
        Return datetime.UnixTimespan.TotalHours : End Function

    ''' <summary>
    ''' Converts Coordinated Universal Time (UTC) as DateTime structure to UnixTime, expressed in whole and fractional number of days.
    ''' </summary>
    ''' <param name="datetime">the datetime parameter is an instance of DateTime (UTC) or DateTimeOffset</param>
    ''' <returns>Number of days since the beginning of the UnixEpoch</returns>
    <Extension>
    Public Function TotalDays(datetime As DateTime) As Double
        Return datetime.UnixTimespan.TotalDays : End Function

End Module

