Imports System.Diagnostics.CodeAnalysis
Imports System.IO
'Imports System.IO
Imports System.Linq.Expressions
Imports System.Reflection
Imports System.Threading
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Imports Microsoft.EntityFrameworkCore.ChangeTracking.Internal
Imports Microsoft.EntityFrameworkCore.Diagnostics
Imports Microsoft.EntityFrameworkCore.Infrastructure
Imports Microsoft.EntityFrameworkCore.Internal
Imports Microsoft.EntityFrameworkCore.Metadata
Imports Microsoft.EntityFrameworkCore.Query
'Imports Newtonsoft.Json
Imports ova.Common.Core.Domain

Public Class JsonDbContext : Implements IJsonDbContext, IDisposable, IAsyncDisposable, IInfrastructure(Of IServiceProvider)

    Private disposedValue As Boolean
    Private disposedValue1 As Boolean
    'initialize the database => fetch
    Dim _jsonFilePath =
    Dim _Database = Fetch(jsonFilePath).GetAwaiter().GetResult()

    Sub New(jsonFilePath As String)

    End Sub

    Public ReadOnly Property ContextId As DbContextId Implements IJsonDbContext.ContextId
    Public ReadOnly Property Model As IModel Implements IJsonDbContext.Model
    Public ReadOnly Property Database As DatabaseFacade Implements IJsonDbContext.Database
    Public ReadOnly Property Instance As IServiceProvider Implements IInfrastructure(Of IServiceProvider).Instance

    Public Event SavingChanges As EventHandler(Of SavingChangesEventArgs) Implements IJsonDbContext.SavingChanges
    Public Event SavedChanges As EventHandler(Of SavedChangesEventArgs) Implements IJsonDbContext.SavedChanges
    Public Event SaveChangesFailed As EventHandler(Of SaveChangesFailedEventArgs) Implements IJsonDbContext.SaveChangesFailed
    Public Sub OnModelCreating(modelBuilder As ModelBuilder) Implements IJsonDbContext.OnModelCreating
        Throw New NotImplementedException()
    End Sub
    Public Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder) Implements IJsonDbContext.OnConfiguring
        Throw New NotImplementedException()
    End Sub
    Private Function InheritedIEntity() As List(Of Type)
        Dim lst As New List(Of Type)
        For Each ass In AppDomain.CurrentDomain.GetAssemblies
            For Each typ In ass.GetTypes()
                If Not typ.GetInterface("IEntity") Is Nothing Then lst.Add(typ)
            Next
        Next
    End Function
    Public Function SaveChanges() As Integer Implements IJsonDbContext.SaveChanges
        'save changes to json file on disk
        Dim serializer As JsonSerializer = New JsonSerializer()
        serializer.NullValueHandling = NullValueHandling.Ignore
        Using sw As StreamWriter = New StreamWriter(_jsonFilePath)
            Using writer As JsonWriter = New JsonTextWriter(sw)
                serializer.Serialize(writer, _Database)
            End Using
        End Using


    End Function
    Public Function SaveChanges(acceptAllChangesOnSuccess As Boolean) As Integer Implements IJsonDbContext.SaveChanges
        Throw New NotImplementedException()
    End Function
    Public Function SaveChangesAsync(acceptAllChangesOnSuccess As Boolean, Optional cancellationToken As CancellationToken = Nothing) As Task(Of Integer) Implements IJsonDbContext.SaveChangesAsync
        Throw New NotImplementedException()
    End Function
    Public Function SaveChangesAsync(Optional cancellationToken As CancellationToken = Nothing) As Task(Of Integer) Implements IJsonDbContext.SaveChangesAsync
        Throw New NotImplementedException()
    End Function
    Public Function Find(<NotNull> entityType As Type, ParamArray keyValues() As Object) As Object Implements IJsonDbContext.Find
        'Dim asses() As Reflection.Assembly
        'Dim method As Reflection.MethodInfo = ass.GetTypes
        Dim arrayMemberInfo() As MemberInfo

    End Function




    Public Function Find(Of TEntity As Class)(ParamArray keyValues() As Object) As TEntity Implements IJsonDbContext.Find
        Throw New NotImplementedException()
    End Function
    Public Function FindAsync(Of TEntity As Class)(keyValues() As Object, cancellationToken As CancellationToken) As ValueTask(Of TEntity) Implements IJsonDbContext.FindAsync
        Throw New NotImplementedException()
    End Function
    Public Function FindAsync(Of TEntity As Class)(ParamArray keyValues() As Object) As ValueTask(Of TEntity) Implements IJsonDbContext.FindAsync
        Throw New NotImplementedException()
    End Function
    Public Function FindAsync(<NotNull> entityType As Type, keyValues() As Object, cancellationToken As CancellationToken) As ValueTask(Of Object) Implements IJsonDbContext.FindAsync
        Throw New NotImplementedException()
    End Function
    Public Function FindAsync(<NotNull> entityType As Type, ParamArray keyValues() As Object) As ValueTask(Of Object) Implements IJsonDbContext.FindAsync
        Throw New NotImplementedException()
    End Function
    Public Function Add(Of TEntity As Class)(<NotNull> entity As TEntity) As EntityEntry(Of TEntity) Implements IJsonDbContext.Add
        Throw New NotImplementedException()
    End Function
    Public Function Add(<NotNull> entity As Object) As EntityEntry Implements IJsonDbContext.Add
        Throw New NotImplementedException()
    End Function
    Public Function AddAsync(Of TEntity As Class)(<NotNull> entity As TEntity, Optional cancellationToken As CancellationToken = Nothing) As ValueTask(Of EntityEntry(Of TEntity)) Implements IJsonDbContext.AddAsync
        Throw New NotImplementedException()
    End Function
    Public Function AddAsync(<NotNull> entity As Object, Optional cancellationToken As CancellationToken = Nothing) As ValueTask(Of EntityEntry) Implements IJsonDbContext.AddAsync
        Throw New NotImplementedException()
    End Function
    Public Function [Set](Of TEntity As Class)(<NotNull> name As String) As DbSet(Of TEntity) Implements IJsonDbContext.Set
        Throw New NotImplementedException()
    End Function
    Public Function [Set](Of TEntity As Class)() As DbSet(Of TEntity) Implements IJsonDbContext.Set
        Throw New NotImplementedException()
    End Function
    Public Function Update(Of TEntity As Class)(<NotNull> entity As TEntity) As EntityEntry(Of TEntity) Implements IJsonDbContext.Update
        Throw New NotImplementedException()
    End Function
    Public Function Update(<NotNull> entity As Object) As EntityEntry Implements IJsonDbContext.Update
        Throw New NotImplementedException()
    End Function
    Public Function Remove(<NotNull> entity As Object) As EntityEntry Implements IJsonDbContext.Remove
        Throw New NotImplementedException()
    End Function
    Public Function Remove(Of TEntity As Class)(<NotNull> entity As TEntity) As EntityEntry(Of TEntity) Implements IJsonDbContext.Remove
        Throw New NotImplementedException()
    End Function
    Public Function Attach(Of TEntity As Class)(<NotNull> entity As TEntity) As EntityEntry(Of TEntity) Implements IJsonDbContext.Attach
        Throw New NotImplementedException()
    End Function
    Public Function Attach(<NotNull> entity As Object) As EntityEntry Implements IJsonDbContext.Attach
        Throw New NotImplementedException()
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue1 Then
            If disposing Then
                ' TODO: освободить управляемое состояние (управляемые объекты)
            End If

            ' TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
            ' TODO: установить значение NULL для больших полей
            disposedValue1 = True
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

    Public Function DisposeAsync() As ValueTask Implements IAsyncDisposable.DisposeAsync
        Throw New NotImplementedException()
    End Function

End Class

'Private disposedValue As Boolean

'Public ReadOnly Property ContextId As DbContextId Implements IJsonDbContext.ContextId
'Public ReadOnly Property Model As IModel Implements IJsonDbContext.Model
'Public ReadOnly Property Database As DatabaseFacade Implements IJsonDbContext.Database
'Public ReadOnly Property Instance As IServiceProvider Implements IInfrastructure(Of IServiceProvider).Instance
'Public ReadOnly Property SetSource As IDbSetSource Implements IDbContextDependencies.SetSource
'Public ReadOnly Property EntityFinderFactory As IEntityFinderFactory Implements IDbContextDependencies.EntityFinderFactory
'Public ReadOnly Property QueryProvider As IAsyncQueryProvider Implements IDbContextDependencies.QueryProvider
'Public ReadOnly Property StateManager As IStateManager Implements IDbContextDependencies.StateManager
'Public ReadOnly Property ChangeDetector As IChangeDetector Implements IDbContextDependencies.ChangeDetector
'Public ReadOnly Property EntityGraphAttacher As IEntityGraphAttacher Implements IDbContextDependencies.EntityGraphAttacher
'Public ReadOnly Property UpdateLogger As IDiagnosticsLogger(Of DbLoggerCategory.Update) Implements IDbContextDependencies.UpdateLogger
'Public ReadOnly Property InfrastructureLogger As IDiagnosticsLogger(Of DbLoggerCategory.Infrastructure) Implements IDbContextDependencies.InfrastructureLogger
'Private ReadOnly Property IDbContextDependencies_Model As IModel Implements IDbContextDependencies.Model
'Public Event SavingChanges As EventHandler(Of SavingChangesEventArgs) Implements IJsonDbContext.SavingChanges
'Public Event SavedChanges As EventHandler(Of SavedChangesEventArgs) Implements IJsonDbContext.SavedChanges
'Public Event SaveChangesFailed As EventHandler(Of SaveChangesFailedEventArgs) Implements IJsonDbContext.SaveChangesFailed

'Public Sub AddRange(<NotNull> entities As IEnumerable(Of Object)) Implements IJsonDbContext.AddRange
'    Throw New NotImplementedException()
'End Sub

'Public Sub AddRange(<NotNull> ParamArray entities() As Object) Implements IJsonDbContext.AddRange
'    Throw New NotImplementedException()
'End Sub

'Public Sub RemoveRange(<NotNull> entities As IEnumerable(Of Object)) Implements IJsonDbContext.RemoveRange
'    Throw New NotImplementedException()
'End Sub

'Public Sub RemoveRange(<NotNull> ParamArray entities() As Object) Implements IJsonDbContext.RemoveRange
'    Throw New NotImplementedException()
'End Sub

'Public Sub UpdateRange(<NotNull> ParamArray entities() As Object) Implements IJsonDbContext.UpdateRange
'    Throw New NotImplementedException()
'End Sub

'Public Sub UpdateRange(<NotNull> entities As IEnumerable(Of Object)) Implements IJsonDbContext.UpdateRange
'    Throw New NotImplementedException()
'End Sub

'Public Sub AttachRange(<NotNull> ParamArray entities() As Object) Implements IJsonDbContext.AttachRange
'    Throw New NotImplementedException()
'End Sub

'Public Sub AttachRange(<NotNull> entities As IEnumerable(Of Object)) Implements IJsonDbContext.AttachRange
'    Throw New NotImplementedException()
'End Sub

'Public Sub OnModelCreating(modelBuilder As ModelBuilder) Implements IJsonDbContext.OnModelCreating
'    Throw New NotImplementedException()
'End Sub

'Public Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder) Implements IJsonDbContext.OnConfiguring
'    Throw New NotImplementedException()
'End Sub

'Public Sub SetLease(lease As DbContextLease) Implements IDbContextPoolable.SetLease
'    Throw New NotImplementedException()
'End Sub

'Public Sub ClearLease() Implements IDbContextPoolable.ClearLease
'    Throw New NotImplementedException()
'End Sub

'Public Sub SnapshotConfiguration() Implements IDbContextPoolable.SnapshotConfiguration
'    Throw New NotImplementedException()
'End Sub

'Public Sub ResetState() Implements IResettableService.ResetState
'    Throw New NotImplementedException()
'End Sub

'Public Function AddRangeAsync(<NotNull> ParamArray entities() As Object) As Task Implements IJsonDbContext.AddRangeAsync
'    Throw New NotImplementedException()
'End Function

'Public Function AddRangeAsync(<NotNull> entities As IEnumerable(Of Object), Optional cancellationToken As CancellationToken = Nothing) As Task Implements IJsonDbContext.AddRangeAsync
'    Throw New NotImplementedException()
'End Function

'Public Function FromExpression(Of TResult)(<NotNull> expression As Expression(Of Func(Of IQueryable(Of TResult)))) As IQueryable(Of TResult) Implements IJsonDbContext.FromExpression
'    Throw New NotImplementedException()
'End Function

'Public Function SaveChanges() As Integer Implements IJsonDbContext.SaveChanges
'    Throw New NotImplementedException()
'End Function

'Public Function SaveChanges(acceptAllChangesOnSuccess As Boolean) As Integer Implements IJsonDbContext.SaveChanges
'    Throw New NotImplementedException()
'End Function

'Public Function FindAsync(Of TEntity As Class)( ParamArray keyValues() As Object) As ValueTask(Of TEntity) Implements IJsonDbContext.FindAsync
'    Throw New NotImplementedException()
'End Function

'Public Function FindAsync(<NotNull> entityType As Type,  keyValues() As Object, cancellationToken As CancellationToken) As ValueTask(Of Object) Implements IJsonDbContext.FindAsync
'    Throw New NotImplementedException()
'End Function

'Public Function FindAsync(<NotNull> entityType As Type,  ParamArray keyValues() As Object) As ValueTask(Of Object) Implements IJsonDbContext.FindAsync
'    Throw New NotImplementedException()
'End Function

'Public Function FindAsync(Of TEntity As Class)( keyValues() As Object, cancellationToken As CancellationToken) As ValueTask(Of TEntity) Implements IJsonDbContext.FindAsync
'    Throw New NotImplementedException()
'End Function

'Public Function Find(Of TEntity As Class)( ParamArray keyValues() As Object) As TEntity Implements IJsonDbContext.Find
'    Throw New NotImplementedException()
'End Function

'Public Function Find(<NotNull> entityType As Type,  ParamArray keyValues() As Object) As Object Implements IJsonDbContext.Find
'    Throw New NotImplementedException()
'End Function

'Public Function [Set](Of TEntity As Class)(<NotNull> name As String) As DbSet(Of TEntity) Implements IJsonDbContext.Set
'    Throw New NotImplementedException()
'End Function

'Public Function [Set](Of TEntity As Class)() As DbSet(Of TEntity) Implements IJsonDbContext.Set
'    Throw New NotImplementedException()
'End Function

'Public Function SaveChangesAsync(acceptAllChangesOnSuccess As Boolean, Optional cancellationToken As CancellationToken = Nothing) As Task(Of Integer) Implements IJsonDbContext.SaveChangesAsync
'    Throw New NotImplementedException()
'End Function

'Public Function SaveChangesAsync(Optional cancellationToken As CancellationToken = Nothing) As Task(Of Integer) Implements IJsonDbContext.SaveChangesAsync
'    Throw New NotImplementedException()
'End Function

'Public Function DisposeAsync() As ValueTask Implements IJsonDbContext.DisposeAsync
'    Throw New NotImplementedException()
'End Function

'Public Function Entry(Of TEntity As Class)(<NotNull> entity As TEntity) As EntityEntry(Of TEntity) Implements IJsonDbContext.Entry
'    Throw New NotImplementedException()
'End Function

'Public Function Entry(<NotNull> entity As Object) As EntityEntry Implements IJsonDbContext.Entry
'    Throw New NotImplementedException()
'End Function

'Public Function Add(Of TEntity As Class)(<NotNull> entity As TEntity) As EntityEntry(Of TEntity) Implements IJsonDbContext.Add
'    Throw New NotImplementedException()
'End Function

'Public Function Add(<NotNull> entity As Object) As EntityEntry Implements IJsonDbContext.Add
'    Throw New NotImplementedException()
'End Function

'Public Function AddAsync(Of TEntity As Class)(<NotNull> entity As TEntity, Optional cancellationToken As CancellationToken = Nothing) As ValueTask(Of EntityEntry(Of TEntity)) Implements IJsonDbContext.AddAsync
'    Throw New NotImplementedException()
'End Function

'Public Function AddAsync(<NotNull> entity As Object, Optional cancellationToken As CancellationToken = Nothing) As ValueTask(Of EntityEntry) Implements IJsonDbContext.AddAsync
'    Throw New NotImplementedException()
'End Function

'Public Function Attach(Of TEntity As Class)(<NotNull> entity As TEntity) As EntityEntry(Of TEntity) Implements IJsonDbContext.Attach
'    Throw New NotImplementedException()
'End Function

'Public Function Attach(<NotNull> entity As Object) As EntityEntry Implements IJsonDbContext.Attach
'    Throw New NotImplementedException()
'End Function

'Public Function Update(Of TEntity As Class)(<NotNull> entity As TEntity) As EntityEntry(Of TEntity) Implements IJsonDbContext.Update
'    Throw New NotImplementedException()
'End Function

'Public Function Update(<NotNull> entity As Object) As EntityEntry Implements IJsonDbContext.Update
'    Throw New NotImplementedException()
'End Function

'Public Function Remove(<NotNull> entity As Object) As EntityEntry Implements IJsonDbContext.Remove
'    Throw New NotImplementedException()
'End Function

'Public Function Remove(Of TEntity As Class)(<NotNull> entity As TEntity) As EntityEntry(Of TEntity) Implements IJsonDbContext.Remove
'    Throw New NotImplementedException()
'End Function

'Public Function GetOrAddSet(source As IDbSetSource, type As Type) As Object Implements IDbSetCache.GetOrAddSet
'    Throw New NotImplementedException()
'End Function

'Public Function GetOrAddSet(source As IDbSetSource, entityTypeName As String, type As Type) As Object Implements IDbSetCache.GetOrAddSet
'    Throw New NotImplementedException()
'End Function

'Public Function ResetStateAsync(Optional cancellationToken As CancellationToken = Nothing) As Task Implements IResettableService.ResetStateAsync
'    Throw New NotImplementedException()
'End Function

'Private Function IJsonDbContext_Equals(obj As Object) As Boolean Implements IJsonDbContext.Equals
'    Throw New NotImplementedException()
'End Function

'Private Function IJsonDbContext_ToString() As String Implements IJsonDbContext.ToString
'    Throw New NotImplementedException()
'End Function

'Private Function IAsyncDisposable_DisposeAsync() As ValueTask Implements IAsyncDisposable.DisposeAsync
'    Throw New NotImplementedException()
'End Function

'Protected Overridable Sub Dispose(disposing As Boolean)
'    If Not disposedValue Then
'        If disposing Then
'            ' TODO: освободить управляемое состояние (управляемые объекты)
'        End If

'        ' TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
'        ' TODO: установить значение NULL для больших полей
'        disposedValue = True
'    End If
'End Sub

'' ' TODO: переопределить метод завершения, только если "Dispose(disposing As Boolean)" содержит код для освобождения неуправляемых ресурсов
'' Protected Overrides Sub Finalize()
''     ' Не изменяйте этот код. Разместите код очистки в методе "Dispose(disposing As Boolean)".
''     Dispose(disposing:=False)
''     MyBase.Finalize()
'' End Sub

'Public Sub Dispose() Implements IDisposable.Dispose
'    ' Не изменяйте этот код. Разместите код очистки в методе "Dispose(disposing As Boolean)".
'    Dispose(disposing:=True)
'    GC.SuppressFinalize(Me)
'End Sub

'Private Sub IJsonDbContext_Dispose() Implements IJsonDbContext.Dispose
'    Throw New NotImplementedException()
'End Sub


''
'' Сводка:
''     A DbContext instance represents a session with the database and can be used to
''     query and save instances of your entities. DbContext is a combination of the
''     Unit Of Work and Repository patterns.
''
'' Примечания:
''     Typically you create a class that derives from DbContext and contains Microsoft.EntityFrameworkCore.DbSet`1
''     properties for each entity in the model. If the Microsoft.EntityFrameworkCore.DbSet`1
''     properties have a public setter, they are automatically initialized when the
''     instance of the derived context is created.
''     Override the Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)
''     method to configure the database (and other options) to be used for the context.
''     Alternatively, if you would rather perform configuration externally instead of
''     inline in your context, you can use Microsoft.EntityFrameworkCore.DbContextOptionsBuilder`1
''     (or Microsoft.EntityFrameworkCore.DbContextOptionsBuilder) to externally create
''     an instance of Microsoft.EntityFrameworkCore.DbContextOptions`1 (or Microsoft.EntityFrameworkCore.DbContextOptions)
''     and pass it to a base constructor of Microsoft.EntityFrameworkCore.DbContext.
''     The model is discovered by running a set of conventions over the entity classes
''     found in the Microsoft.EntityFrameworkCore.DbSet`1 properties on the derived
''     context. To further configure the model that is discovered by convention, you
''     can override the Microsoft.EntityFrameworkCore.DbContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)
''     method.
'Public Class DbContext
'    Implements IDisposable, IAsyncDisposable, IInfrastructure(Of IServiceProvider), IDbContextDependencies, IDbSetCache, IDbContextPoolable, IResettableService
'    '
'    ' Сводка:
'    '     Initializes a new instance of the Microsoft.EntityFrameworkCore.DbContext class
'    '     using the specified options. The Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)
'    '     method will still be called to allow further configuration of the options.
'    '
'    ' Параметры:
'    '   options:
'    '     The options for this context.
'    Public Sub New(<NotNullAttribute> options As DbContextOptions)
'        '
'    ' Сводка:
'    '     Initializes a new instance of the Microsoft.EntityFrameworkCore.DbContext class.
'    '     The Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)
'    '     method will be called to configure the database (and other options) to be used
'    '     for this context.
'    Protected Sub New()

'        '
'    ' Сводка:
'    '     A unique identifier for the context instance and pool lease, if any.
'    '     This identifier is primarily intended as a correlation ID for logging and debugging
'    '     such that it is easy to identify that multiple events are using the same or different
'    '     context instances.
'    Public Overridable ReadOnly Property ContextId As DbContextId
'    '
'    ' Сводка:
'    '     The metadata about the shape of entities, the relationships between them, and
'    '     how they map to the database.
'    Public Overridable ReadOnly Property Model As IModel
'    '
'    ' Сводка:
'    '     Provides access to information and operations for entity instances this context
'    '     is tracking.
'    Public Overridable ReadOnly Property ChangeTracker As ChangeTracker
'    '
'    ' Сводка:
'    '     Provides access to database related information and operations for this context.
'    Public Overridable ReadOnly Property Database As DatabaseFacade

'    '
'    ' Сводка:
'    '     An event fired at the beginning of a call to SaveChanges or SaveChangesAsync
'    Public Event SavingChanges As EventHandler(Of SavingChangesEventArgs)
'    '
'    ' Сводка:
'    '     An event fired at the end of a call to SaveChanges or SaveChangesAsync
'    Public Event SavedChanges As EventHandler(Of SavedChangesEventArgs)
'    '
'    ' Сводка:
'    '     An event fired if a call to SaveChanges or SaveChangesAsync fails with an exception.
'    Public Event SaveChangesFailed As EventHandler(Of SaveChangesFailedEventArgs)

'    '
'    ' Сводка:
'    '     Begins tracking the given entities, and any other reachable entities that are
'    '     not already being tracked, in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state such that they will be inserted into the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '
'    ' Параметры:
'    '   entities:
'    '     The entities to add.
'    Public Overridable Sub AddRange(<NotNullAttribute> entities As IEnumerable(Of Object))
'        '
'    ' Сводка:
'    '     Begins tracking the given entity in the Microsoft.EntityFrameworkCore.EntityState.Deleted
'    '     state such that it will be removed from the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '
'    ' Параметры:
'    '   entities:
'    '     The entities to remove.
'    '
'    ' Примечания:
'    '     If any of the entities are already tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state then the context will stop tracking those entities (rather than marking
'    '     them as Microsoft.EntityFrameworkCore.EntityState.Deleted) since those entities
'    '     were previously added to the context and do not exist in the database.
'    '     Any other reachable entities that are not already being tracked will be tracked
'    '     in the same way that they would be if Microsoft.EntityFrameworkCore.DbContext.AttachRange(System.Collections.Generic.IEnumerable{System.Object})
'    '     was called before calling this method. This allows any cascading actions to be
'    '     applied when Microsoft.EntityFrameworkCore.DbContext.SaveChanges is called.
'    Public Overridable Sub RemoveRange(<NotNullAttribute> entities As IEnumerable(Of Object))
'        '
'    ' Сводка:
'    '     Begins tracking the given entity in the Microsoft.EntityFrameworkCore.EntityState.Deleted
'    '     state such that it will be removed from the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '
'    ' Параметры:
'    '   entities:
'    '     The entities to remove.
'    '
'    ' Примечания:
'    '     If any of the entities are already tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state then the context will stop tracking those entities (rather than marking
'    '     them as Microsoft.EntityFrameworkCore.EntityState.Deleted) since those entities
'    '     were previously added to the context and do not exist in the database.
'    '     Any other reachable entities that are not already being tracked will be tracked
'    '     in the same way that they would be if Microsoft.EntityFrameworkCore.DbContext.AttachRange(System.Object[])
'    '     was called before calling this method. This allows any cascading actions to be
'    '     applied when Microsoft.EntityFrameworkCore.DbContext.SaveChanges is called.
'    Public Overridable Sub RemoveRange(<NotNullAttribute> ParamArray entities() As Object)
'        '
'    ' Сводка:
'    '     Begins tracking the given entities and entries reachable from the given entities
'    '     using the Microsoft.EntityFrameworkCore.EntityState.Modified state by default,
'    '     but see below for cases when a different state will be used.
'    '     Generally, no database interaction will be performed until Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '     A recursive search of the navigation properties will be performed to find reachable
'    '     entities that are not already being tracked by the context. All entities found
'    '     will be tracked by the context.
'    '     For entity types with generated keys if an entity has its primary key value set
'    '     then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Modified
'    '     state. If the primary key value is not set then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state. This helps ensure new entities will be inserted, while existing entities
'    '     will be updated. An entity is considered to have its primary key value set if
'    '     the primary key property is set to anything other than the CLR default for the
'    '     property type.
'    '     For entity types without generated keys, the state set is always Microsoft.EntityFrameworkCore.EntityState.Modified.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    '
'    ' Параметры:
'    '   entities:
'    '     The entities to update.
'    Public Overridable Sub UpdateRange(<NotNullAttribute> ParamArray entities() As Object)
'        '
'    ' Сводка:
'    '     Begins tracking the given entities and entries reachable from the given entities
'    '     using the Microsoft.EntityFrameworkCore.EntityState.Unchanged state by default,
'    '     but see below for cases when a different state will be used.
'    '     Generally, no database interaction will be performed until Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '     A recursive search of the navigation properties will be performed to find reachable
'    '     entities that are not already being tracked by the context. All entities found
'    '     will be tracked by the context.
'    '     For entity types with generated keys if an entity has its primary key value set
'    '     then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Unchanged
'    '     state. If the primary key value is not set then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state. This helps ensure only new entities will be inserted. An entity is considered
'    '     to have its primary key value set if the primary key property is set to anything
'    '     other than the CLR default for the property type.
'    '     For entity types without generated keys, the state set is always Microsoft.EntityFrameworkCore.EntityState.Unchanged.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    '
'    ' Параметры:
'    '   entities:
'    '     The entities to attach.
'    Public Overridable Sub AttachRange(<NotNullAttribute> ParamArray entities() As Object)
'        '
'    ' Сводка:
'    '     Begins tracking the given entities, and any other reachable entities that are
'    '     not already being tracked, in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state such that they will be inserted into the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '
'    ' Параметры:
'    '   entities:
'    '     The entities to add.
'    Public Overridable Sub AddRange(<NotNullAttribute> ParamArray entities() As Object)
'        '
'    ' Сводка:
'    '     Begins tracking the given entities and entries reachable from the given entities
'    '     using the Microsoft.EntityFrameworkCore.EntityState.Unchanged state by default,
'    '     but see below for cases when a different state will be used.
'    '     Generally, no database interaction will be performed until Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '     A recursive search of the navigation properties will be performed to find reachable
'    '     entities that are not already being tracked by the context. All entities found
'    '     will be tracked by the context.
'    '     For entity types with generated keys if an entity has its primary key value set
'    '     then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Unchanged
'    '     state. If the primary key value is not set then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state. This helps ensure only new entities will be inserted. An entity is considered
'    '     to have its primary key value set if the primary key property is set to anything
'    '     other than the CLR default for the property type.
'    '     For entity types without generated keys, the state set is always Microsoft.EntityFrameworkCore.EntityState.Unchanged.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    '
'    ' Параметры:
'    '   entities:
'    '     The entities to attach.
'    Public Overridable Sub AttachRange(<NotNullAttribute> entities As IEnumerable(Of Object))
'        '
'    ' Сводка:
'    '     Begins tracking the given entities and entries reachable from the given entities
'    '     using the Microsoft.EntityFrameworkCore.EntityState.Modified state by default,
'    '     but see below for cases when a different state will be used.
'    '     Generally, no database interaction will be performed until Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '     A recursive search of the navigation properties will be performed to find reachable
'    '     entities that are not already being tracked by the context. All entities found
'    '     will be tracked by the context.
'    '     For entity types with generated keys if an entity has its primary key value set
'    '     then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Modified
'    '     state. If the primary key value is not set then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state. This helps ensure new entities will be inserted, while existing entities
'    '     will be updated. An entity is considered to have its primary key value set if
'    '     the primary key property is set to anything other than the CLR default for the
'    '     property type.
'    '     For entity types without generated keys, the state set is always Microsoft.EntityFrameworkCore.EntityState.Modified.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    '
'    ' Параметры:
'    '   entities:
'    '     The entities to update.
'    Public Overridable Sub UpdateRange(<NotNullAttribute> entities As IEnumerable(Of Object))
'        '
'    ' Сводка:
'    '     Releases the allocated resources for this context.
'    Public Overridable Sub Dispose()
'        '
'    ' Сводка:
'    '     Override this method to further configure the model that was discovered by convention
'    '     from the entity types exposed in Microsoft.EntityFrameworkCore.DbSet`1 properties
'    '     on your derived context. The resulting model may be cached and re-used for subsequent
'    '     instances of your derived context.
'    '
'    ' Параметры:
'    '   modelBuilder:
'    '     The builder being used to construct the model for this context. Databases (and
'    '     other extensions) typically define extension methods on this object that allow
'    '     you to configure aspects of the model that are specific to a given database.
'    '
'    ' Примечания:
'    '     If a model is explicitly set on the options for this context (via Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel))
'    '     then this method will not be run.
'    Protected Friend Overridable Sub OnModelCreating(modelBuilder As ModelBuilder)
'        '
'    ' Сводка:
'    '     Override this method to configure the database (and other options) to be used
'    '     for this context. This method is called for each instance of the context that
'    '     is created. The base implementation does nothing.
'    '     In situations where an instance of Microsoft.EntityFrameworkCore.DbContextOptions
'    '     may or may not have been passed to the constructor, you can use Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured
'    '     to determine if the options have already been set, and skip some or all of the
'    '     logic in Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder).
'    '
'    ' Параметры:
'    '   optionsBuilder:
'    '     A builder used to create or modify options for this context. Databases (and other
'    '     extensions) typically define extension methods on this object that allow you
'    '     to configure the context.
'    Protected Friend Overridable Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)

'        '
'    ' Сводка:
'    '     Determines whether the specified object is equal to the current object.
'    '
'    ' Параметры:
'    '   obj:
'    '     The object to compare with the current object.
'    '
'    ' Возврат:
'    '     true if the specified object is equal to the current object; otherwise, false.
'    <EditorBrowsable(EditorBrowsableState.Never)>
'    Public Overrides Function Equals(obj As Object) As Boolean
'        '
'    ' Сводка:
'    '     Returns a string that represents the current object.
'    '
'    ' Возврат:
'    '     A string that represents the current object.
'    <EditorBrowsable(EditorBrowsableState.Never)>
'    Public Overrides Function ToString() As String
'        '
'    ' Сводка:
'    '     Creates a queryable for given query expression.
'    '
'    ' Параметры:
'    '   expression:
'    '     The query expression to create.
'    '
'    ' Параметры типа:
'    '   TResult:
'    '     The result type of the query expression.
'    '
'    ' Возврат:
'    '     An System.Linq.IQueryable`1 representing the query.
'    Public Overridable Function FromExpression(Of TResult)(<NotNullAttribute> expression As Expressions.Expression(Of Func(Of IQueryable(Of TResult)))) As IQueryable(Of TResult)
'        '
'    ' Сводка:
'    '     Saves all changes made in this context to the database.
'    '     This method will automatically call Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges
'    '     to discover any changes to entity instances before saving to the underlying database.
'    '     This can be disabled via Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled.
'    '
'    ' Возврат:
'    '     The number of state entries written to the database.
'    '
'    ' Исключения:
'    '   T:Microsoft.EntityFrameworkCore.DbUpdateException:
'    '     An error is encountered while saving to the database.
'    '
'    '   T:Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException:
'    '     A concurrency violation is encountered while saving to the database. A concurrency
'    '     violation occurs when an unexpected number of rows are affected during save.
'    '     This is usually because the data in the database has been modified since it was
'    '     loaded into memory.
'    Public Overridable Function SaveChanges() As Integer
'        '
'    ' Сводка:
'    '     Finds an entity with the given primary key values. If an entity with the given
'    '     primary key values is being tracked by the context, then it is returned immediately
'    '     without making a request to the database. Otherwise, a query is made to the database
'    '     for an entity with the given primary key values and this entity, if found, is
'    '     attached to the context and returned. If no entity is found, then null is returned.
'    '
'    ' Параметры:
'    '   keyValues:
'    '     The values of the primary key for the entity to be found.
'    '
'    ' Параметры типа:
'    '   TEntity:
'    '     The type of entity to find.
'    '
'    ' Возврат:
'    '     The entity found, or null.
'    Public Overridable Function FindAsync(Of TEntity As Class)( ParamArray keyValues() As Object) As ValueTask(Of TEntity)
'        '
'    ' Сводка:
'    '     Finds an entity with the given primary key values. If an entity with the given
'    '     primary key values is being tracked by the context, then it is returned immediately
'    '     without making a request to the database. Otherwise, a query is made to the database
'    '     for an entity with the given primary key values and this entity, if found, is
'    '     attached to the context and returned. If no entity is found, then null is returned.
'    '
'    ' Параметры:
'    '   keyValues:
'    '     The values of the primary key for the entity to be found.
'    '
'    ' Параметры типа:
'    '   TEntity:
'    '     The type of entity to find.
'    '
'    ' Возврат:
'    '     The entity found, or null.
'    Public Overridable Function Find(Of TEntity As Class)( ParamArray keyValues() As Object) As TEntity
'        '
'    ' Сводка:
'    '     Finds an entity with the given primary key values. If an entity with the given
'    '     primary key values is being tracked by the context, then it is returned immediately
'    '     without making a request to the database. Otherwise, a query is made to the database
'    '     for an entity with the given primary key values and this entity, if found, is
'    '     attached to the context and returned. If no entity is found, then null is returned.
'    '
'    ' Параметры:
'    '   entityType:
'    '     The type of entity to find.
'    '
'    '   keyValues:
'    '     The values of the primary key for the entity to be found.
'    '
'    '   cancellationToken:
'    '     A System.Threading.CancellationToken to observe while waiting for the task to
'    '     complete.
'    '
'    ' Возврат:
'    '     The entity found, or null.
'    Public Overridable Function FindAsync(<NotNullAttribute> entityType As Type,  keyValues() As Object, cancellationToken As Threading.CancellationToken) As ValueTask(Of Object)
'        '
'    ' Сводка:
'    '     Finds an entity with the given primary key values. If an entity with the given
'    '     primary key values is being tracked by the context, then it is returned immediately
'    '     without making a request to the database. Otherwise, a query is made to the database
'    '     for an entity with the given primary key values and this entity, if found, is
'    '     attached to the context and returned. If no entity is found, then null is returned.
'    '
'    ' Параметры:
'    '   entityType:
'    '     The type of entity to find.
'    '
'    '   keyValues:
'    '     The values of the primary key for the entity to be found.
'    '
'    ' Возврат:
'    '     The entity found, or null.
'    Public Overridable Function FindAsync(<NotNullAttribute> entityType As Type,  ParamArray keyValues() As Object) As ValueTask(Of Object)
'        '
'    ' Сводка:
'    '     Creates a Microsoft.EntityFrameworkCore.DbSet`1 that can be used to query and
'    '     save instances of TEntity.
'    '
'    ' Параметры типа:
'    '   TEntity:
'    '     The type of entity for which a set should be returned.
'    '
'    ' Возврат:
'    '     A set for the given entity type.
'    Public Overridable Function [Set](Of TEntity As Class)(<NotNullAttribute> name As String) As DbSet(Of TEntity)
'        '
'    ' Сводка:
'    '     Creates a Microsoft.EntityFrameworkCore.DbSet`1 that can be used to query and
'    '     save instances of TEntity.
'    '
'    ' Параметры типа:
'    '   TEntity:
'    '     The type of entity for which a set should be returned.
'    '
'    ' Возврат:
'    '     A set for the given entity type.
'    Public Overridable Function [Set](Of TEntity As Class)() As DbSet(Of TEntity)
'        '
'    ' Сводка:
'    '     Finds an entity with the given primary key values. If an entity with the given
'    '     primary key values is being tracked by the context, then it is returned immediately
'    '     without making a request to the database. Otherwise, a query is made to the database
'    '     for an entity with the given primary key values and this entity, if found, is
'    '     attached to the context and returned. If no entity is found, then null is returned.
'    '
'    ' Параметры:
'    '   entityType:
'    '     The type of entity to find.
'    '
'    '   keyValues:
'    '     The values of the primary key for the entity to be found.
'    '
'    ' Возврат:
'    '     The entity found, or null.
'    Public Overridable Function Find(<NotNullAttribute> entityType As Type,  ParamArray keyValues() As Object) As Object
'        '
'    ' Сводка:
'    '     Serves as the default hash function.
'    '
'    ' Возврат:
'    '     A hash code for the current object.
'    <EditorBrowsable(EditorBrowsableState.Never)>
'    Public Overrides Function GetHashCode() As Integer
'        '
'    ' Сводка:
'    '     Finds an entity with the given primary key values. If an entity with the given
'    '     primary key values is being tracked by the context, then it is returned immediately
'    '     without making a request to the database. Otherwise, a query is made to the database
'    '     for an entity with the given primary key values and this entity, if found, is
'    '     attached to the context and returned. If no entity is found, then null is returned.
'    '
'    ' Параметры:
'    '   keyValues:
'    '     The values of the primary key for the entity to be found.
'    '
'    '   cancellationToken:
'    '     A System.Threading.CancellationToken to observe while waiting for the task to
'    '     complete.
'    '
'    ' Параметры типа:
'    '   TEntity:
'    '     The type of entity to find.
'    '
'    ' Возврат:
'    '     The entity found, or null.
'    Public Overridable Function FindAsync(Of TEntity As Class)( keyValues() As Object, cancellationToken As Threading.CancellationToken) As ValueTask(Of TEntity)
'        '
'        ' Сводка:
'        '     Saves all changes made in this context to the database.
'        '     This method will automatically call Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges
'        '     to discover any changes to entity instances before saving to the underlying database.
'        '     This can be disabled via Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled.
'        '     Multiple active operations on the same context instance are not supported. Use
'        '     'await' to ensure that any asynchronous operations have completed before calling
'        '     another method on this context.
'        '
'        ' Параметры:
'        '   acceptAllChangesOnSuccess:
'        '     Indicates whether Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AcceptAllChanges
'        '     is called after the changes have been sent successfully to the database.
'        '
'        '   cancellationToken:
'        '     A System.Threading.CancellationToken to observe while waiting for the task to
'        '     complete.
'        '
'        ' Возврат:
'        '     A task that represents the asynchronous save operation. The task result contains
'        '     the number of state entries written to the database.
'        '
'        ' Исключения:
'        '   T:Microsoft.EntityFrameworkCore.DbUpdateException:
'        '     An error is encountered while saving to the database.
'        '
'        '   T:Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException:
'        '     A concurrency violation is encountered while saving to the database. A concurrency
'        '     violation occurs when an unexpected number of rows are affected during save.
'        '     This is usually because the data in the database has been modified since it was
'        '     loaded into memory.
'        <AsyncStateMachineAttribute(GetType(<SaveChangesAsync>d__56))>
'        Public Overridable Function SaveChangesAsync(acceptAllChangesOnSuccess As Boolean, Optional cancellationToken As Threading.CancellationToken = Nothing) As Task(Of Integer)
'        '
'    ' Сводка:
'    '     Saves all changes made in this context to the database.
'    '     This method will automatically call Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges
'    '     to discover any changes to entity instances before saving to the underlying database.
'    '     This can be disabled via Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled.
'    '     Multiple active operations on the same context instance are not supported. Use
'    '     'await' to ensure that any asynchronous operations have completed before calling
'    '     another method on this context.
'    '
'    ' Параметры:
'    '   cancellationToken:
'    '     A System.Threading.CancellationToken to observe while waiting for the task to
'    '     complete.
'    '
'    ' Возврат:
'    '     A task that represents the asynchronous save operation. The task result contains
'    '     the number of state entries written to the database.
'    '
'    ' Исключения:
'    '   T:Microsoft.EntityFrameworkCore.DbUpdateException:
'    '     An error is encountered while saving to the database.
'    '
'    '   T:Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException:
'    '     A concurrency violation is encountered while saving to the database. A concurrency
'    '     violation occurs when an unexpected number of rows are affected during save.
'    '     This is usually because the data in the database has been modified since it was
'    '     loaded into memory.
'    Public Overridable Function SaveChangesAsync(Optional cancellationToken As Threading.CancellationToken = Nothing) As Task(Of Integer)
'        '
'    ' Сводка:
'    '     Releases the allocated resources for this context.
'    Public Overridable Function DisposeAsync() As ValueTask
'        '
'    ' Сводка:
'    '     Gets an Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry`1 for the given
'    '     entity. The entry provides access to change tracking information and operations
'    '     for the entity.
'    '
'    ' Параметры:
'    '   entity:
'    '     The entity to get the entry for.
'    '
'    ' Параметры типа:
'    '   TEntity:
'    '     The type of the entity.
'    '
'    ' Возврат:
'    '     The entry for the given entity.
'    Public Overridable Function Entry(Of TEntity As Class)(<NotNullAttribute> entity As TEntity) As EntityEntry(Of TEntity)
'        '
'    ' Сводка:
'    '     Gets an Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry for the given
'    '     entity. The entry provides access to change tracking information and operations
'    '     for the entity.
'    '     This method may be called on an entity that is not tracked. You can then set
'    '     the Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State property on
'    '     the returned entry to have the context begin tracking the entity in the specified
'    '     state.
'    '
'    ' Параметры:
'    '   entity:
'    '     The entity to get the entry for.
'    '
'    ' Возврат:
'    '     The entry for the given entity.
'    Public Overridable Function Entry(<NotNullAttribute> entity As Object) As EntityEntry
'        '
'    ' Сводка:
'    '     Begins tracking the given entity, and any other reachable entities that are not
'    '     already being tracked, in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state such that they will be inserted into the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    '
'    ' Параметры:
'    '   entity:
'    '     The entity to add.
'    '
'    ' Параметры типа:
'    '   TEntity:
'    '     The type of the entity.
'    '
'    ' Возврат:
'    '     The Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry`1 for the entity.
'    '     The entry provides access to change tracking information and operations for the
'    '     entity.
'    Public Overridable Function Add(Of TEntity As Class)(<NotNullAttribute> entity As TEntity) As EntityEntry(Of TEntity)
'        '
'        ' Сводка:
'        '     Begins tracking the given entity, and any other reachable entities that are not
'        '     already being tracked, in the Microsoft.EntityFrameworkCore.EntityState.Added
'        '     state such that they will be inserted into the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'        '     is called.
'        '     This method is async only to allow special value generators, such as the one
'        '     used by 'Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.SequenceHiLo',
'        '     to access the database asynchronously. For all other cases the non async method
'        '     should be used.
'        '
'        ' Параметры:
'        '   entity:
'        '     The entity to add.
'        '
'        '   cancellationToken:
'        '     A System.Threading.CancellationToken to observe while waiting for the task to
'        '     complete.
'        '
'        ' Параметры типа:
'        '   TEntity:
'        '     The type of the entity.
'        '
'        ' Возврат:
'        '     A task that represents the asynchronous Add operation. The task result contains
'        '     the Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry`1 for the entity.
'        '     The entry provides access to change tracking information and operations for the
'        '     entity.
'        <AsyncStateMachineAttribute(GetType(DbContext.<AddAsync>d__84(Of Object)))>
'        Public Overridable Function AddAsync(Of TEntity As Class)(<NotNullAttribute> entity As TEntity, Optional cancellationToken As Threading.CancellationToken = Nothing) As ValueTask(Of EntityEntry(Of TEntity))
'        '
'    ' Сводка:
'    '     Begins tracking the given entity and entries reachable from the given entity
'    '     using the Microsoft.EntityFrameworkCore.EntityState.Unchanged state by default,
'    '     but see below for cases when a different state will be used.
'    '     Generally, no database interaction will be performed until Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '     A recursive search of the navigation properties will be performed to find reachable
'    '     entities that are not already being tracked by the context. All entities found
'    '     will be tracked by the context.
'    '     For entity types with generated keys if an entity has its primary key value set
'    '     then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Unchanged
'    '     state. If the primary key value is not set then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state. This helps ensure only new entities will be inserted. An entity is considered
'    '     to have its primary key value set if the primary key property is set to anything
'    '     other than the CLR default for the property type.
'    '     For entity types without generated keys, the state set is always Microsoft.EntityFrameworkCore.EntityState.Unchanged.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    '
'    ' Параметры:
'    '   entity:
'    '     The entity to attach.
'    '
'    ' Параметры типа:
'    '   TEntity:
'    '     The type of the entity.
'    '
'    ' Возврат:
'    '     The Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry`1 for the entity.
'    '     The entry provides access to change tracking information and operations for the
'    '     entity.
'    Public Overridable Function Attach(Of TEntity As Class)(<NotNullAttribute> entity As TEntity) As EntityEntry(Of TEntity)
'        '
'        ' Сводка:
'        '     Begins tracking the given entity, and any other reachable entities that are not
'        '     already being tracked, in the Microsoft.EntityFrameworkCore.EntityState.Added
'        '     state such that they will be inserted into the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'        '     is called.
'        '     This method is async only to allow special value generators, such as the one
'        '     used by 'Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.SequenceHiLo',
'        '     to access the database asynchronously. For all other cases the non async method
'        '     should be used.
'        '
'        ' Параметры:
'        '   entities:
'        '     The entities to add.
'        '
'        '   cancellationToken:
'        '     A System.Threading.CancellationToken to observe while waiting for the task to
'        '     complete.
'        '
'        ' Возврат:
'        '     A task that represents the asynchronous operation.
'        <AsyncStateMachineAttribute(GetType(<AddRangeAsync>d__102))>
'        Public Overridable Function AddRangeAsync(<NotNullAttribute> entities As IEnumerable(Of Object), Optional cancellationToken As Threading.CancellationToken = Nothing) As Task
'        '
'    ' Сводка:
'    '     Begins tracking the given entity and entries reachable from the given entity
'    '     using the Microsoft.EntityFrameworkCore.EntityState.Modified state by default,
'    '     but see below for cases when a different state will be used.
'    '     Generally, no database interaction will be performed until Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '     A recursive search of the navigation properties will be performed to find reachable
'    '     entities that are not already being tracked by the context. All entities found
'    '     will be tracked by the context.
'    '     For entity types with generated keys if an entity has its primary key value set
'    '     then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Modified
'    '     state. If the primary key value is not set then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state. This helps ensure new entities will be inserted, while existing entities
'    '     will be updated. An entity is considered to have its primary key value set if
'    '     the primary key property is set to anything other than the CLR default for the
'    '     property type.
'    '     For entity types without generated keys, the state set is always Microsoft.EntityFrameworkCore.EntityState.Modified.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    '
'    ' Параметры:
'    '   entity:
'    '     The entity to update.
'    '
'    ' Параметры типа:
'    '   TEntity:
'    '     The type of the entity.
'    '
'    ' Возврат:
'    '     The Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry`1 for the entity.
'    '     The entry provides access to change tracking information and operations for the
'    '     entity.
'    Public Overridable Function Update(Of TEntity As Class)(<NotNullAttribute> entity As TEntity) As EntityEntry(Of TEntity)
'        '
'    ' Сводка:
'    '     Begins tracking the given entity, and any other reachable entities that are not
'    '     already being tracked, in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state such that they will be inserted into the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    '
'    ' Параметры:
'    '   entity:
'    '     The entity to add.
'    '
'    ' Возврат:
'    '     The Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry for the entity.
'    '     The entry provides access to change tracking information and operations for the
'    '     entity.
'    Public Overridable Function Add(<NotNullAttribute> entity As Object) As EntityEntry
'        '
'        ' Сводка:
'        '     Begins tracking the given entity, and any other reachable entities that are not
'        '     already being tracked, in the Microsoft.EntityFrameworkCore.EntityState.Added
'        '     state such that they will be inserted into the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'        '     is called.
'        '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'        '     state of only a single entity.
'        '     This method is async only to allow special value generators, such as the one
'        '     used by 'Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.SequenceHiLo',
'        '     to access the database asynchronously. For all other cases the non async method
'        '     should be used.
'        '
'        ' Параметры:
'        '   entity:
'        '     The entity to add.
'        '
'        '   cancellationToken:
'        '     A System.Threading.CancellationToken to observe while waiting for the task to
'        '     complete.
'        '
'        ' Возврат:
'        '     A task that represents the asynchronous Add operation. The task result contains
'        '     the Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry for the entity.
'        '     The entry provides access to change tracking information and operations for the
'        '     entity.
'        <AsyncStateMachineAttribute(GetType(<AddAsync>d__90))>
'        Public Overridable Function AddAsync(<NotNullAttribute> entity As Object, Optional cancellationToken As Threading.CancellationToken = Nothing) As ValueTask(Of EntityEntry)
'        '
'    ' Сводка:
'    '     Begins tracking the given entity and entries reachable from the given entity
'    '     using the Microsoft.EntityFrameworkCore.EntityState.Unchanged state by default,
'    '     but see below for cases when a different state will be used.
'    '     Generally, no database interaction will be performed until Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '     A recursive search of the navigation properties will be performed to find reachable
'    '     entities that are not already being tracked by the context. All entities found
'    '     will be tracked by the context.
'    '     For entity types with generated keys if an entity has its primary key value set
'    '     then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Unchanged
'    '     state. If the primary key value is not set then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state. This helps ensure only new entities will be inserted. An entity is considered
'    '     to have its primary key value set if the primary key property is set to anything
'    '     other than the CLR default for the property type.
'    '     For entity types without generated keys, the state set is always Microsoft.EntityFrameworkCore.EntityState.Unchanged.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    '
'    ' Параметры:
'    '   entity:
'    '     The entity to attach.
'    '
'    ' Возврат:
'    '     The Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry for the entity.
'    '     The entry provides access to change tracking information and operations for the
'    '     entity.
'    Public Overridable Function Attach(<NotNullAttribute> entity As Object) As EntityEntry
'        '
'    ' Сводка:
'    '     Begins tracking the given entity and entries reachable from the given entity
'    '     using the Microsoft.EntityFrameworkCore.EntityState.Modified state by default,
'    '     but see below for cases when a different state will be used.
'    '     Generally, no database interaction will be performed until Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '     A recursive search of the navigation properties will be performed to find reachable
'    '     entities that are not already being tracked by the context. All entities found
'    '     will be tracked by the context.
'    '     For entity types with generated keys if an entity has its primary key value set
'    '     then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Modified
'    '     state. If the primary key value is not set then it will be tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state. This helps ensure new entities will be inserted, while existing entities
'    '     will be updated. An entity is considered to have its primary key value set if
'    '     the primary key property is set to anything other than the CLR default for the
'    '     property type.
'    '     For entity types without generated keys, the state set is always Microsoft.EntityFrameworkCore.EntityState.Modified.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    '
'    ' Параметры:
'    '   entity:
'    '     The entity to update.
'    '
'    ' Возврат:
'    '     The Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry for the entity.
'    '     The entry provides access to change tracking information and operations for the
'    '     entity.
'    Public Overridable Function Update(<NotNullAttribute> entity As Object) As EntityEntry
'        '
'    ' Сводка:
'    '     Begins tracking the given entity in the Microsoft.EntityFrameworkCore.EntityState.Deleted
'    '     state such that it will be removed from the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '
'    ' Параметры:
'    '   entity:
'    '     The entity to remove.
'    '
'    ' Возврат:
'    '     The Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry for the entity.
'    '     The entry provides access to change tracking information and operations for the
'    '     entity.
'    '
'    ' Примечания:
'    '     If the entity is already tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state then the context will stop tracking the entity (rather than marking it
'    '     as Microsoft.EntityFrameworkCore.EntityState.Deleted) since the entity was previously
'    '     added to the context and does not exist in the database.
'    '     Any other reachable entities that are not already being tracked will be tracked
'    '     in the same way that they would be if Microsoft.EntityFrameworkCore.DbContext.Attach(System.Object)
'    '     was called before calling this method. This allows any cascading actions to be
'    '     applied when Microsoft.EntityFrameworkCore.DbContext.SaveChanges is called.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    Public Overridable Function Remove(<NotNullAttribute> entity As Object) As EntityEntry
'        '
'    ' Сводка:
'    '     Saves all changes made in this context to the database.
'    '     This method will automatically call Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges
'    '     to discover any changes to entity instances before saving to the underlying database.
'    '     This can be disabled via Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled.
'    '
'    ' Параметры:
'    '   acceptAllChangesOnSuccess:
'    '     Indicates whether Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AcceptAllChanges
'    '     is called after the changes have been sent successfully to the database.
'    '
'    ' Возврат:
'    '     The number of state entries written to the database.
'    '
'    ' Исключения:
'    '   T:Microsoft.EntityFrameworkCore.DbUpdateException:
'    '     An error is encountered while saving to the database.
'    '
'    '   T:Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException:
'    '     A concurrency violation is encountered while saving to the database. A concurrency
'    '     violation occurs when an unexpected number of rows are affected during save.
'    '     This is usually because the data in the database has been modified since it was
'    '     loaded into memory.
'    Public Overridable Function SaveChanges(acceptAllChangesOnSuccess As Boolean) As Integer
'        '
'    ' Сводка:
'    '     Begins tracking the given entity in the Microsoft.EntityFrameworkCore.EntityState.Deleted
'    '     state such that it will be removed from the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '
'    ' Параметры:
'    '   entity:
'    '     The entity to remove.
'    '
'    ' Параметры типа:
'    '   TEntity:
'    '     The type of the entity.
'    '
'    ' Возврат:
'    '     The Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry`1 for the entity.
'    '     The entry provides access to change tracking information and operations for the
'    '     entity.
'    '
'    ' Примечания:
'    '     If the entity is already tracked in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state then the context will stop tracking the entity (rather than marking it
'    '     as Microsoft.EntityFrameworkCore.EntityState.Deleted) since the entity was previously
'    '     added to the context and does not exist in the database.
'    '     Any other reachable entities that are not already being tracked will be tracked
'    '     in the same way that they would be if Microsoft.EntityFrameworkCore.DbContext.Attach``1(``0)
'    '     was called before calling this method. This allows any cascading actions to be
'    '     applied when Microsoft.EntityFrameworkCore.DbContext.SaveChanges is called.
'    '     Use Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry.State to set the
'    '     state of only a single entity.
'    Public Overridable Function Remove(Of TEntity As Class)(<NotNullAttribute> entity As TEntity) As EntityEntry(Of TEntity)
'        '
'    ' Сводка:
'    '     Begins tracking the given entity, and any other reachable entities that are not
'    '     already being tracked, in the Microsoft.EntityFrameworkCore.EntityState.Added
'    '     state such that they will be inserted into the database when Microsoft.EntityFrameworkCore.DbContext.SaveChanges
'    '     is called.
'    '     This method is async only to allow special value generators, such as the one
'    '     used by 'Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.SequenceHiLo',
'    '     to access the database asynchronously. For all other cases the non async method
'    '     should be used.
'    '
'    ' Параметры:
'    '   entities:
'    '     The entities to add.
'    '
'    ' Возврат:
'    '     A task that represents the asynchronous operation.
'    Public Overridable Function AddRangeAsync(<NotNullAttribute> ParamArray entities() As Object) As Task
'    End Class
'End Namespace














'Using Newtonsoft.Json;
'Using Newtonsoft.Json.Linq;
'Using System;
'Using System.Collections.Generic;
'Using System.IO;
'Using System.Text;
'Using System.Threading.Tasks;

'Namespace JsonFileDB
'{
'    /// <example>
'    /// <code>
'    /// public class AppDBContext: DBContext
'    /// {
'    ///     public AppDBContext() : base($".\\database.json")
'    /// {
'    ///     Persons = new Dataset<Person>(_database);
'    /// }
'    /// public Dataset<Person> Persons { get; set; }
'    ///}
'    /// </code>
'    /// </example>
'    public class DBContext : IDBContext
'    {
'        /// <value>Gets and Sets the Database instance.</value>
'        protected JObject _database{ get; set; }

'        private string _jsonFilePath;

'        /// <summary>
'        /// Initiaalizes the context of a Database from a given json file.
'        /// </summary>
'        public DBContext(string jsonFilePath)
'        {
'            //initialize the database => fetch
'            _jsonFilePath = jsonFilePath;
'            _database = Fetch(jsonFilePath).GetAwaiter().GetResult();
'        }

'        /// <summary>
'        /// Fetches data from json file to the database context in memory.
'        /// </summary>
'        private async Task<JObject> Fetch(string jsonFilePath)
'        {
'            JObject database;
'            try
'            {
'                if (!File.Exists(jsonFilePath))
'                {
'                    //TODO initialize a database file with all attributes of Dataset object
'                    File.WriteAllText(jsonFilePath, "{'system':{'rows':[],'index':0}}");
'                }
'                Using (StreamReader reader = File.OpenText(jsonFilePath))
'                {
'                    database = (JObject)await JToken.ReadFromAsync(New JsonTextReader(reader));
'                }
'            }
'            Catch (Exception)
'            {
'                database = JObject.Parse("{'system':{'rows':[],'index':0}}");
'            }
'            Return database;
'        }

'        /// <summary>
'        /// Persists the data of the DBcontaxt in memory to a json file on drive.
'        /// </summary>
'        Public void SaveChanges()
'        {
'            //save changes to json file on disk
'            JsonSerializer serializer = New JsonSerializer();

'            serializer.NullValueHandling = NullValueHandling.Ignore;

'            Using (StreamWriter sw = New StreamWriter(_jsonFilePath))

'            Using (JsonWriter writer = New JsonTextWriter(sw))
'            {
'                serializer.Serialize(writer, _database);
'            }
'        }
'    }
'}
