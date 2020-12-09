
Imports ova.Common.UnixTime
Imports Xunit

Public Class UnixTimeTest

    <Fact>
    Sub DateToUnixTimeTest()
        ' Arrange
        Dim Expected, Actual As Integer

        ' Act
        Expected = CheckPointAsUnixTime
        Actual = CInt(UnixTimespan(CheckPointAsDateTime).TotalSeconds)

        ' Assert
        Assert.NotNull(Actual)
        Assert.NotNull(Expected)
        Assert.IsType(Of Integer)(Actual)
        Assert.IsType(Of Integer)(Expected)
        Assert.Equal(Expected, Actual)
    End Sub

    <Fact>
    Sub UnixTimeToDateTest()
        ' Arrange
        Dim Expected, Actual As Date

        ' Act
        Expected = CheckPointAsDateTime
        Actual = FromUnixTime(CheckPointAsUnixTime)

        ' Assert
        Assert.NotSame(Expected, Actual)
        Assert.NotNull(Actual)
        Assert.NotNull(Expected)
        Assert.IsType(Of Date)(Actual)
        Assert.IsType(Of Date)(Expected)
        Assert.Equal(Expected, Actual)
    End Sub


End Class
