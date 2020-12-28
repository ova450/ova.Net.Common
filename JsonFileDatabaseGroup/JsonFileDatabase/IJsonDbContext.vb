Imports System.ComponentModel
Imports System.Diagnostics.CodeAnalysis
Imports System.Runtime.CompilerServices
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Imports Microsoft.EntityFrameworkCore.Infrastructure
Imports Microsoft.EntityFrameworkCore.Internal
Imports Microsoft.EntityFrameworkCore.Metadata

Interface IJsonDbContext
    Inherits IDisposable, IAsyncDisposable, IInfrastructure(Of IServiceProvider) ', IDbContextDependencies ', IDbSetCache, IDbContextPoolable, IResettableService
    'Inherits IDbSetCache ', IDbContextPoolable ', IResettableService
    'Inherits IResettableService

    '  Sub New(<NotNullAttribute> options As DbContextOptions)

    ' Protected Sub New()
#Region "Properties"
    ReadOnly Property ContextId As DbContextId
    ReadOnly Property Model As IModel
    ReadOnly Property Database As DatabaseFacade
#End Region
#Region "Save"
    Function SaveChanges() As Integer
    Function SaveChanges(acceptAllChangesOnSuccess As Boolean) As Integer
    Function SaveChangesAsync(acceptAllChangesOnSuccess As Boolean, Optional cancellationToken As Threading.CancellationToken = Nothing) As Task(Of Integer)
    Function SaveChangesAsync(Optional cancellationToken As Threading.CancellationToken = Nothing) As Task(Of Integer)
    Event SavingChanges As EventHandler(Of SavingChangesEventArgs)
    Event SavedChanges As EventHandler(Of SavedChangesEventArgs)
    Event SaveChangesFailed As EventHandler(Of SaveChangesFailedEventArgs)
#End Region
    '#Region "Range"
    '    Sub AddRange(<NotNullAttribute> entities As IEnumerable(Of Object))
    '    Sub AddRange(<NotNullAttribute> ParamArray entities() As Object)
    '    Sub RemoveRange(<NotNullAttribute> entities As IEnumerable(Of Object))
    '    Sub RemoveRange(<NotNullAttribute> ParamArray entities() As Object)
    '    Sub UpdateRange(<NotNullAttribute> ParamArray entities() As Object)
    '    Sub AttachRange(<NotNullAttribute> ParamArray entities() As Object)
    '    Sub AttachRange(<NotNullAttribute> entities As IEnumerable(Of Object))
    '    Sub UpdateRange(<NotNullAttribute> entities As IEnumerable(Of Object))
    '    Function AddRangeAsync(<NotNullAttribute> ParamArray entities() As Object) As Task
    '    Function AddRangeAsync(<NotNullAttribute> entities As IEnumerable(Of Object), Optional cancellationToken As Threading.CancellationToken = Nothing) As Task
    '#End Region
#Region "Config"
    Sub OnModelCreating(modelBuilder As ModelBuilder)
    Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
#End Region
#Region "Find"
    Function Find(<NotNullAttribute> entityType As Type, <CanBeNullAttribute> ParamArray keyValues() As Object) As Object
    Function Find(Of TEntity As Class)(<CanBeNullAttribute> ParamArray keyValues() As Object) As TEntity
    Function FindAsync(Of TEntity As Class)(<CanBeNullAttribute> keyValues() As Object, cancellationToken As Threading.CancellationToken) As ValueTask(Of TEntity)
    Function FindAsync(Of TEntity As Class)(<CanBeNullAttribute> ParamArray keyValues() As Object) As ValueTask(Of TEntity)
    Function FindAsync(<NotNullAttribute> entityType As Type, <CanBeNullAttribute> keyValues() As Object, cancellationToken As Threading.CancellationToken) As ValueTask(Of Object)
    Function FindAsync(<NotNullAttribute> entityType As Type, <CanBeNullAttribute> ParamArray keyValues() As Object) As ValueTask(Of Object)
#End Region
#Region "Add"
    Function Add(Of TEntity As Class)(<NotNullAttribute> entity As TEntity) As EntityEntry(Of TEntity)
    Function Add(<NotNullAttribute> entity As Object) As EntityEntry
    Function AddAsync(Of TEntity As Class)(<NotNullAttribute> entity As TEntity, Optional cancellationToken As Threading.CancellationToken = Nothing) As ValueTask(Of EntityEntry(Of TEntity))
    Function AddAsync(<NotNullAttribute> entity As Object, Optional cancellationToken As Threading.CancellationToken = Nothing) As ValueTask(Of EntityEntry)
#End Region
#Region "Set"
    Function [Set](Of TEntity As Class)(<NotNullAttribute> name As String) As DbSet(Of TEntity)
    Function [Set](Of TEntity As Class)() As DbSet(Of TEntity)
#End Region
#Region "Update Remove"
    Function Update(Of TEntity As Class)(<NotNullAttribute> entity As TEntity) As EntityEntry(Of TEntity)
    Function Update(<NotNullAttribute> entity As Object) As EntityEntry
    Function Remove(<NotNullAttribute> entity As Object) As EntityEntry
    Function Remove(Of TEntity As Class)(<NotNullAttribute> entity As TEntity) As EntityEntry(Of TEntity)
#End Region
    '#Region "Entry"
    '    Function Entry(Of TEntity As Class)(<NotNullAttribute> entity As TEntity) As EntityEntry(Of TEntity)
    '    Function Entry(<NotNullAttribute> entity As Object) As EntityEntry
    '#End Region
#Region "Attach"
    Function Attach(Of TEntity As Class)(<NotNullAttribute> entity As TEntity) As EntityEntry(Of TEntity)
    Function Attach(<NotNullAttribute> entity As Object) As EntityEntry
#End Region
    '#Region "Dispose"
    '    'Sub Dispose()
    '    Function DisposeAsync() As ValueTask
    '#End Region
    '#Region "Functions"
    '    <EditorBrowsable(EditorBrowsableState.Never)>
    '    Function Equals(obj As Object) As Boolean

    '    <EditorBrowsable(EditorBrowsableState.Never)>
    '    Function ToString() As String
    '#End Region


End Interface

