
Imports Microsoft.Extensions.Logging
Imports Newtonsoft




Class LogEventBase : Inherits Database.JdbObject
    Property application As Integer = 1000
    Property [Module] As Integer = 2000
    Property Instance As Integer = 3000
    Property Service As Integer = 4000
    Property Method As Integer = 5000
    Property [Property] As Integer = 6000
    Property Block As Integer = 7000
    Property [Operator] As Integer = 8000
    Property Host As Integer = 9000
    Property Transaction As Integer = 10000
    Property Resourse As Integer = 11000
    Property OtherObjects As Integer = 12000

End Class

Class vvv : Implements Database.IJdbObject

    Public Property UID As String Implements IJdbObject.UID
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property
End Class

Friend Class LogEvent

    Dim logeventbase As LogEventBase    ' Database.JdbObject
    Dim db As Database.Jdb(Of LogEventBase)

    Public Function AddEventBase(id As Integer, name As String) As LogEventBase
        db.
    End Function

End Class

'Friend Enum LogEventsEnumList

'    Application = 1000

'    AppStart = 1200
'    AppStarting = 1210
'    AppStarted = 1220
'    AppNotStarted = 1225
'    AppStop = 1230
'    AppStopCall = 1240
'    AppStopCalled = 1245
'    AppStoping = 1250
'    AppStoped = 1260
'    AppNotStoped = 1265

'    AppInitial = 1300
'    AppInitialCall = 1310
'    AppInitialCalled = 1315
'    AppInitialising = 1320
'    AppInitialized = 1330
'    AppNotInitialized = 1335

'    AppPause = 1400
'    AppPauseCall = 1410
'    AppPauseCalled = 1415
'    AppPausing = 1420
'    AppPaused = 1430
'    AppNotPaused = 1435

'    AppRestart = 1440
'    AppRestartCall = 1450
'    AppRestartCalled = 1455
'    AppRestarting = 1460
'    AppRestarted = 1470
'    AppNotRestarted = 1475

'    AppClean = 1500
'    AppCleaningCall = 1510
'    AppCleaningCalled = 1515
'    AppCleaning = 1520
'    AppCleaned = 1530
'    AppNotCleaned = 1535

'    AppExit = 1540
'    AppExitCall = 1550
'    AppExitCalled = 1555
'    AppExiting = 1560
'    AppExited = 1570
'    AppNotExited = 1575

'    [Module] = 2000

'    ModuleInitial = 2300
'    ModuleInitialCall = 2310
'    ModuleInitialCalled = 2315
'    ModuleInitialising = 2320
'    ModuleInitialized = 2330
'    ModuleNotInitialized = 2335

'    Instance = 3000

'    InstanceCreate = 3100
'    InstanceCreateCall = 3110
'    InstanceCreateCalled = 3115
'    InstanceCreating = 3120
'    InstanceCreated = 3130
'    InstanceNotCreated = 3135

'    InstanceInitial = 3300
'    InstanceInitialCall = 3310
'    InstanceInitialCalled = 3315
'    InstanceInitialising = 3320
'    InstanceInitialized = 3330
'    InstanceNotInitialized = 3335

'    InstanceClean = 3500
'    InstanceCleaningCall = 3510
'    InstanceCleaningCalled = 3515
'    InstanceCleaning = 3520
'    InstanceCleaned = 3530
'    InstanceNotCleaned = 3535

'    InstanceExit = 3540
'    InstanceExitCall = 3550
'    InstanceExitCalled = 3555
'    InstanceExiting = 3560
'    InstanceExited = 3570
'    InstanceNotExited = 3575

'    Service = 4000

'    ServiceCreate = 4100
'    ServiceCreateCall = 4110
'    ServiceCreateCalled = 4115
'    ServiceCreating = 4120
'    ServiceCreated = 4130
'    ServiceNotCreated = 4135

'    ServiceStart = 4200
'    ServiceStarting = 4210
'    ServiceStarted = 4220
'    ServiceNotStarted = 4225
'    ServiceStop = 4230
'    ServiceStopCall = 4240
'    ServiceStopCalled = 4245
'    ServiceStoping = 4250
'    ServiceStoped = 4260
'    ServiceNotStoped = 4265

'    ServiceInitial = 4300
'    ServiceInitialCall = 4310
'    ServiceInitialCalled = 4315
'    ServiceInitialising = 4320
'    ServiceInitialized = 4330
'    ServiceNotInitialized = 4335

'    ServicePause = 4400
'    ServicePauseCall = 4410
'    ServicePauseCalled = 4415
'    ServicePausing = 4420
'    ServicePaused = 4430
'    ServiceNotPaused = 4435

'    ServiceRestart = 4440
'    ServiceRestartCall = 4450
'    ServiceRestartCalled = 4455
'    ServiceRestarting = 4460
'    ServiceRestarted = 4470
'    ServiceNotRestarted = 4475

'    ServiceClean = 4500
'    ServiceCleaningCall = 4510
'    ServiceCleaningCalled = 4515
'    ServiceCleaning = 4520
'    ServiceCleaned = 4530
'    ServiceNotCleaned = 4535

'    ServiceExit = 4540
'    ServiceExitCall = 4550
'    ServiceExitCalled = 4555
'    ServiceExiting = 4560
'    ServiceExited = 4570
'    ServiceNotExited = 4575


'    Method = 5000

'    MethodCalled = 5100             'MethodStart = 5200

'    MethodInitial = 5200
'    MethodInitialCall = 5210
'    MethodInitialCalled = 5215
'    MethodInitialising = 5220
'    MethodInitialized = 5230
'    MethodNotInitialized = 5235

'    MethodExit = 5300
'    MethodExitCall = 5310
'    MethodExitCalled = 5320
'    MethodExiting = 5330
'    MethodExited = 5340
'    MethodNotExited = 5345

'    [Property] = 5500

'    PropertyUpdate = 5600
'    PropertyUpdateCall = 5610
'    PropertyUpdateCalled = 5615
'    PropertyUpdating = 5620
'    PropertyUpdated = 5630
'    PropertyNotUpdated = 5635

'    PropertyCalled = 5200

'    PropertyInitial = 5300
'    PropertyInitialCall = 5310
'    PropertyInitialCalled = 5315
'    PropertyInitialising = 5320
'    PropertyInitialized = 5330
'    PropertyNotInitialized = 5335

'    PropertyExit = 5540
'    PropertyExitCall = 5550
'    PropertyExitCalled = 5555
'    PropertyExiting = 5560
'    PropertyExited = 5570
'    PropertyNotExited = 5575


'    'Block = 6000
'    '[Operator] = 7000
'    'Host
'    'Transaction = 8000
'    'Data = 9000
'    'Resourse = 10000

'    'Scope = 5000
'    'Item = 6000
'End Enum

