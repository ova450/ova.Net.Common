Public Class LogEvents
    Public Enum Application
        StartCall = 1010
        Starting = 1020
        Started = 1030
        Initialized = 1040
        PauseCall = 1110
        Paused = 1120
        Restart = 1130
        StopCall = 1210
        Stoping = 1220
        Stopped = 1230
        Finalized = 1240
    End Enum

    Public Enum Component
        CreateCall = 1000
        CreateCalled = 1010
        Creating = 1020
        Created = 1030

        StartCalled = 1010
        Starting = 1020
        Started = 1030

        Initialized = 1040
        Initialized = 1040
        Initialized = 1040

        PauseCall = 1110
        Paused = 1120

        Restart = 1130

        StopCall = 1210
        Stoping = 1220
        Stopped = 1230
        Finalized = 1240


        StartCall = 1000
        Starting = 1010
        Started = 1020
        Initialized = 1030
        PauseCall = 1100
        Paused = 1110
        Restart = 1120
        StopCall = 1200
        Stoping = 1210
        Stopped = 1220
        Finalized = 1230
        Cleaned = 1240
        Disposed = 1250
    End Enum

    Public Enum [Object]
        Created = 2000
        Configured = 2100
        Destroyed = 2020
        Cleaned = 2030
        Di
    End Enum

    Public Enum [Numerable]
        Add = 
    End Enum

End Class

