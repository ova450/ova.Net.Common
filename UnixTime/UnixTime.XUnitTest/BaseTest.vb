
Imports ova.Common.UnixTime
Imports Xunit


Public Class BaseTest

        <Fact>
        Sub UnixTimespanTest1()

            ' Arrange
            Dim Expect, Actual As TimeSpan

            ' Act
            Expect = New TimeSpan(CheckPointAsDateTime.Ticks - DateTime.UnixEpoch.Ticks)
            Actual = UnixTimespan(CheckPointAsDateTime)

            ' Assert
            Assert.NotSame(Expect, Actual)
            Assert.Equal(Expect, Actual)

        End Sub

        <Fact>
        Sub UnixTimespanTest2()

            ' Arrange
            Dim Expect, Actual As TimeSpan
            Dim DeltaMax As TimeSpan = New TimeSpan(0, 0, 0, 0, 1)
            ' Act
            Expect = New TimeSpan(Now.Ticks - DateTime.UnixEpoch.Ticks)
            Actual = UnixTimespan()

            ' Assert
            Assert.NotSame(Expect, Actual)
            Assert.True(Actual - Expect < DeltaMax)

        End Sub

        <Fact>
        Sub TimestampTest()

            ' Arrange
            Dim Expect, Actual As Long
            ' Act
            Expect = Timestamp()
            Actual = Timestamp()

            ' Assert
            Assert.NotSame(Expect, Actual)
            Assert.NotEqual(Expect, Actual)
            Assert.True(Actual - Expect < 10000)

        End Sub

    End Class
