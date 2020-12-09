Imports System.Runtime.CompilerServices

Public Module UnixTimeComponents

    ''' <summary>
    ''' Converts Coordinated Universal Time (UTC) as DateTime structure to UnixTime, expressed in whole number of milliseconds.
    ''' </summary>
    ''' <param name="datetime">the datetime parameter is an instance of DateTime (UTC) or DateTimeOffset</param>
    ''' <returns>Number of milliseconds since the beginning of the UnixEpoch</returns>
    <Extension>
    Public Function Milliseconds(datetime As DateTime) As Integer
        Return datetime.UnixTimespan.Milliseconds : End Function

    ''' <summary>
    ''' Converts Coordinated Universal Time (UTC) as DateTime structure to UnixTime, expressed in whole number of seconds.
    ''' </summary>
    ''' <param name="datetime">the datetime parameter is an instance of DateTime (UTC) or DateTimeOffset</param>
    ''' <returns>Number of seconds since the beginning of the UnixEpoch</returns>
    <Extension>
    Public Function Seconds(datetime As DateTime) As Integer
        Return datetime.UnixTimespan.Seconds : End Function

    ''' <summary>
    ''' Converts Coordinated Universal Time (UTC) as DateTime structure to UnixTime, expressed in wholenumber of minutes.
    ''' </summary>
    ''' <param name="datetime">the datetime parameter is an instance of DateTime (UTC) or DateTimeOffset</param>
    ''' <returns>Number of minutes since the beginning of the UnixEpoch</returns>
    <Extension>
    Public Function Minutes(datetime As DateTime) As Integer
        Return datetime.UnixTimespan.Minutes : End Function

    ''' <summary>
    ''' Converts Coordinated Universal Time (UTC) as DateTime structure to UnixTime, expressed in whole number of hours.
    ''' </summary>
    ''' <param name="datetime">the datetime parameter is an instance of DateTime (UTC) or DateTimeOffset</param>
    ''' <returns>Number of hours since the beginning of the UnixEpoch</returns>
    <Extension>
    Public Function Hours(datetime As DateTime) As Integer
        Return datetime.UnixTimespan.Hours : End Function

    ''' <summary>
    ''' Converts Coordinated Universal Time (UTC) as DateTime structure to UnixTime, expressed in whole number of days.
    ''' </summary>
    ''' <param name="datetime">the datetime parameter is an instance of DateTime (UTC) or DateTimeOffset</param>
    ''' <returns>Number of days since the beginning of the UnixEpoch</returns>
    <Extension>
    Public Function Days(datetime As DateTime) As Integer
        Return datetime.UnixTimespan.Days : End Function

End Module
