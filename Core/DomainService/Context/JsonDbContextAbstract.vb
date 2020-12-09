Imports System.IO
Imports System.Reflection
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace DomainService.Json

    ''' <example>
    ''' <code>
    ''' public class AppDBContext: DBContext
    ''' {
    '''     public AppDBContext() : base($".\\database.json")
    ''' {
    '''     Persons = new Dataset<Person>(_database);
    ''' }
    ''' public Dataset<Person> Persons { get; set; }
    '''}`
    ''' </code>
    ''' </example>
    Public MustInherit Class JsonDbContextAbstract : Inherits DbContext

        ''' <value>Gets and Sets the Database instance.</value>
        Protected Property _database As JObject
        Private _jsonFilePath As String

        ''' <summary>
        ''' Initiaalizes the context of a Database from a given json file.
        ''' </summary>
        Public Sub New(jsonFilePath As String)
            ''initialize the database => fetch
            _jsonFilePath = jsonFilePath
            _database = Fetch(jsonFilePath).GetAwaiter().GetResult()
        End Sub

        ''' <summary>
        ''' Fetches data from json file to the database context in memory.
        ''' </summary>
        Private Async Function Fetch(jsonFilePath As String) As Task(Of JObject)
            Dim database As JObject
            Try
                ''TODO initialize a database file with all attributes of Dataset object
                If (Not File.Exists(jsonFilePath)) Then File.WriteAllText(jsonFilePath, "{'system':{'rows':[],'index':0}}")

                Using reader As StreamReader = File.OpenText(jsonFilePath)
                    database = Await JToken.ReadFromAsync(New JsonTextReader(reader)) ' (JObject)
                End Using
            Catch ex As Exception
            End Try
            database = JObject.Parse("{'system':{'rows':[],'index':0}}")
            Return database
        End Function

        Private ReadOnly Property AppConfig As IConfigurationRoot
        Private ReadOnly Property ConnectionStringName As String

        Sub New(appconfig As IConfigurationRoot, connectionstringname As String)
            MyBase.New
            _AppConfig = appconfig
            _ConnectionStringName = connectionstringname

            Database.EnsureCreated()

        End Sub

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            optionsBuilder.UseSqlServer(AppConfig.GetConnectionString(ConnectionStringName))
        End Sub

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)

            For Each assm As Assembly In AppDomain.CurrentDomain.GetAssemblies
                modelBuilder.ApplyConfigurationsFromAssembly(assm)
            Next

            MyBase.OnModelCreating(modelBuilder)

        End Sub

        ''' <summary>
        ''' Persists the data of the DBcontaxt in memory to a json file on drive.
        ''' </summary>
        Public Overrides Function SaveChanges() As Integer
            ' save changes to json file on disk
            Dim serializer As Newtonsoft.Json.JsonSerializer = New Newtonsoft.Json.JsonSerializer With {.NullValueHandling = NullValueHandling.Ignore}

            Using sw As StreamWriter = New StreamWriter(_jsonFilePath)

                Using writer As JsonWriter = New JsonTextWriter(sw)
                    serializer.Serialize(writer, Database)
                End Using
            End Using
            Return Nothing
        End Function


    End Class
End Namespace