Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Friend Class cSQLDatabase
#Region " Class Variables"

    Private _cnConnection As SqlConnection

    ' Create connection string using SQL Server authentication 
    Private _adpAdapter As SqlDataAdapter
    Private _cmdSqlCommand As SqlCommand
    Public Event DataProcessingComplete()

    Private blnUseStandardFormat As Boolean = False

#End Region
#Region " Class Constructors/Destructor"
    ''' <summary>New - Class constructor allowing user to specify the database name, 
    ''' server and user credentials. This routine will create and open a connection 
    ''' to the database as well as create a DataAdapter for use by the class.</summary>
    ''' <param name="Server">Server Name</param>
    ''' <param name="DatabaseName">Database Name</param>
    ''' <param name="Username">Username</param>
    ''' <param name="Password">Password</param>
    ''' <remarks>Copyright © 2007 by Corning, Inc.</remarks>
    Public Sub New(ByVal Server As String, ByVal DatabaseName As String, ByVal Username As String, ByVal Password As String, Optional ByVal UseStandardFormat As Boolean = False)
        Dim strDbConnString As String = String.Format("Persist Security Info=False;Connection Timeout=5;Integrated Security=False;database={1};server={0};User ID={2};Pwd={3}", _
                                         Server, DatabaseName, Username, Password)
        blnUseStandardFormat = UseStandardFormat
        CreateConnection(strDbConnString)
    End Sub
    Public Sub New(ByVal ConnectionString As String, Optional ByVal UseStandardFormat As Boolean = False)
        blnUseStandardFormat = UseStandardFormat
        CreateConnection(ConnectionString)
    End Sub

    Private Sub CreateConnection(ByVal ConnectionString As String)
        Try
            _cnConnection = New SqlConnection(ConnectionString)     'Create connection object
            Call _cnConnection.Open()                               'Open connection to database.
            _adpAdapter = New SqlDataAdapter                                 'Create new DataAdapter object

            ' Create new SQL Command object and pass it our connection object.
            _cmdSqlCommand = New SqlCommand
            _cmdSqlCommand.Connection = _cnConnection               'Pass in our connection
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Dispose - Class destructor. Disposes the objects created by the class.
    ''' </summary>
    ''' <remarks>Copyright © 2007 by Corning, Inc.</remarks>
    Public Sub Dispose()
        If Not _adpAdapter Is Nothing Then Call _adpAdapter.Dispose() 'Dispose of our DataAdapter
        If Not _cmdSqlCommand Is Nothing Then Call _cmdSqlCommand.Dispose() 'Dispose of our Command object

        If Not _cnConnection Is Nothing Then
            If _cnConnection.State <> ConnectionState.Closed Then
                Call _cnConnection.Close()      'Close database connection
            End If

            Call _cnConnection.Dispose()    'Dispose of the database connection object.
            _cnConnection = Nothing
        End If
    End Sub

#End Region
    ''' <summary>
    ''' AdHocQuery - Performs a query against the database via the user's 
    ''' SQL text passed into the function.
    ''' </summary>
    ''' <param name="SqlText">SQL query text to executed</param>
    ''' <returns>Datatable with results</returns>
    ''' <remarks>Copyright © 2007 by Corning, Inc.</remarks>
    Public Function AdHocQuery(ByVal SqlText As String) As DataTable
        Dim dtDataTable As New DataTable

        ' Configure the SqlCommand object

        With _cmdSqlCommand
            .CommandType = CommandType.Text                 'Set type to Text
            .CommandText = SqlText                          'Specify SQL syntax
        End With

        ' Configure Adapter to use newly created command object and fill the dataset.
        _adpAdapter.SelectCommand = _cmdSqlCommand
        _adpAdapter.Fill(dtDataTable)

        ' Notify the host 
        RaiseEvent DataProcessingComplete()

        Return dtDataTable
    End Function

    ''' <summary>
    ''' ExecuteMyScalar - executes a stored procedure with an array of parameters and returns the first row/column value
    ''' </summary>
    ''' <param name="StoredProcedureName">Stored Procedure Name</param>
    ''' <param name="Params">Array of SqlParameters</param>
    ''' <returns>Value from first row/column in the resultset</returns>
    ''' <remarks>Copyright © 2007 by Corning, Inc.</remarks>
    Public Function ExecuteMyScalar(ByVal StoredProcedureName As String, ByVal Params As SqlClient.SqlParameter()) As Object

        With _cmdSqlCommand
            .Parameters.Clear()
            .CommandType = CommandType.StoredProcedure
            .CommandText = StoredProcedureName
            .Parameters.AddRange(Params)
        End With

        Return _cmdSqlCommand.ExecuteScalar.ToString

        ' Notify the host 
        RaiseEvent DataProcessingComplete()

    End Function
    Public Function ExecuteMyScalar(ByVal SQL As String) As String

        With _cmdSqlCommand
            .CommandText = SQL
            Return .ExecuteScalar.ToString()
        End With
    End Function
    ''' <summary>
    ''' ExecuteStoredProcedureDataset - Calls a stored procedure with the passed in parameter array
    ''' </summary>
    ''' <param name="StoredProcedureName"></param>
    ''' <param name="Params">Array of Parameters</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Copyright © 2007 by Corning, Inc.</remarks>
    Public Function ExecuteStoredProcedureDataset(ByVal StoredProcedureName As String, ByVal Params As SqlClient.SqlParameter()) As DataSet

        With _cmdSqlCommand
            .Parameters.Clear()
            .CommandType = CommandType.StoredProcedure
            .CommandText = StoredProcedureName
            If Not IsNothing(Params) Then
                .Parameters.AddRange(Params)
            End If
        End With

        ' Notify the host 
        RaiseEvent DataProcessingComplete()

        Dim _cmdDataset As New DataSet
        Dim _cmdDataAdapter As New SqlDataAdapter

        _cmdDataAdapter.SelectCommand = _cmdSqlCommand
        _cmdDataAdapter.Fill(_cmdDataset)

        Return _cmdDataset
    End Function
    Public Function ExecuteStoredProcedureDataset(ByVal StoredProcedureName As String) As DataSet
        Return ExecuteStoredProcedureDataset(StoredProcedureName, Nothing)
    End Function
    ''' <summary>
    ''' ExecuteStoredProcedure - Calls a stored procedure with the passed in parameter array
    ''' </summary>
    ''' <param name="StoredProcedureName"></param>
    ''' <param name="Params">Array of Parameters</param>
    ''' <returns>Datatable</returns>
    ''' <remarks>Copyright © 2007 by Corning, Inc.</remarks>
    Public Function ExecuteStoredProcedure(ByVal StoredProcedureName As String, ByVal Params As SqlClient.SqlParameter()) As DataTable

        With _cmdSqlCommand
            .Parameters.Clear()
            .CommandType = CommandType.StoredProcedure
            .CommandText = StoredProcedureName
            If Not IsNothing(Params) Then
                .Parameters.AddRange(Params)
            End If
        End With

        ' Notify the host 
        RaiseEvent DataProcessingComplete()

        Return ConvertSQLReaderToDataTable(_cmdSqlCommand.ExecuteReader)
    End Function
    Public Function ExecuteStoredProcedure(ByVal StoredProcedureName As String) As DataTable
        Return ExecuteStoredProcedure(StoredProcedureName, Nothing)
    End Function
    ''' <summary>
    ''' ExecuteStoredProcedureEx - Calls a stored procedure with the passed in parameter array, return error and result table
    ''' </summary>
    ''' <param name="StoredProcedureName"></param>
    ''' <param name="Params">Array of Parameters</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>Copyright © 2013 by Corning, Inc.</remarks>
    Public Function ExecuteStoredProcedureEx(ByVal StoredProcedureName As String, ByVal Params As SqlClient.SqlParameter()) As DataSet

        With _cmdSqlCommand
            .Parameters.Clear()
            .CommandType = CommandType.StoredProcedure
            .CommandText = StoredProcedureName
            .Parameters.AddRange(Params)
        End With

        ' Notify the host 
        RaiseEvent DataProcessingComplete()

        Return ConvertSQLReaderToDataSet(_cmdSqlCommand.ExecuteReader)
    End Function
    ''' <summary>
    ''' ExecuteNoReturnStoredProcedure - Calls a stored procedure with the passed in parameter array
    ''' </summary>
    ''' <param name="StoredProcedureName">Stored procedure to call</param>
    ''' <param name="Params">Array of Parameters</param>
    ''' <remarks>Copyright © 2007 by Corning, Inc.</remarks>
    Public Sub ExecuteNoReturnStoredProcedure(ByVal StoredProcedureName As String, ByVal Params As SqlClient.SqlParameter())
        '1.0.0.9 - new sub
        With _cmdSqlCommand
            .Parameters.Clear()
            .CommandType = CommandType.StoredProcedure
            .CommandText = StoredProcedureName
            If Not IsNothing(Params) Then
                .Parameters.AddRange(Params)
            End If
        End With

        _cmdSqlCommand.ExecuteNonQuery()

    End Sub
    ''' <summary>
    ''' ExecuteNoReturnStoredProcedure - executes a stored procedure that returns no values
    ''' </summary>
    ''' <param name="StoredProcedureName">Stored procedure to call</param>
    ''' <remarks></remarks>
    Public Sub ExecuteNoReturnStoredProcedure(ByVal StoredProcedureName As String)
        '1.0.0.9 - new sub
        ExecuteNoReturnStoredProcedure(StoredProcedureName, Nothing)
    End Sub


    ''' <summary>
    ''' ConvertSQLReaderToDataTable - Takes data from a SQL Data Reader object and loads it into a DataTable
    ''' </summary>
    ''' <param name="SQLReader">SQLDataReader to load into DataTable</param>
    ''' <returns>DataTable</returns>
    ''' <remarks>Copyright © 2007 by Corning, Inc.</remarks>
    Public Shared Function ConvertSQLReaderToDataTable(ByRef SQLReader As SqlClient.SqlDataReader) As DataTable
        Dim dtDataTable As New DataTable

        Try
            dtDataTable.Load(SQLReader)
        Catch ex As Exception
            Throw ex
        End Try

        ' Return the populated Datatable
        Return dtDataTable

    End Function
    ''' <summary>
    ''' ConvertSQLReaderToDataSet - Takes data from a SQL Data Reader object and loads it into a DataSet
    ''' </summary>
    ''' <param name="SQLReader">SQLDataReader to load into DataSet with Error and Result tabke</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>Copyright © 2013 by Corning, Inc.</remarks>

    Public Shared Function ConvertSQLReaderToDataSet(ByRef SQLReader As SqlClient.SqlDataReader) As DataSet
        Dim dsDataSet As New DataSet
        Dim errorTable As New DataTable()
        Dim resultTable As New DataTable()
        errorTable.TableName = "Error"
        resultTable.TableName = "Results"

        dsDataSet.Tables.Add(errorTable)
        dsDataSet.Tables.Add(resultTable)
        Try
            dsDataSet.Load(SQLReader, LoadOption.OverwriteChanges, errorTable, resultTable)
        Catch ex As Exception
            Throw ex
        End Try

        ' Return the populated Datatable
        Return dsDataSet

    End Function
    ''' <summary>
    ''' ExecuteMySQL - Executes a SQL command
    ''' </summary>
    ''' <param name="SqlText">The SQL statement to be executed</param>
    ''' <returns>True or throws an exception</returns>
    ''' <remarks>Copyright © 2007 by Corning, Inc.</remarks>
    Public Function ExecuteMySQL(ByVal SqlText As String) As Boolean

        ' Configure the SqlCommand object
        With _cmdSqlCommand
            .CommandType = CommandType.Text                 'Set type to Text
            .CommandText = SqlText                          'Specify SQL syntax
        End With

        _cmdSqlCommand.ExecuteNonQuery()

        RaiseEvent DataProcessingComplete()
        Return True

    End Function
    ''' <summary>
    ''' ExecuteMySQLEx - Executes a SQL command extented function
    ''' </summary>
    ''' <param name="SqlText">The SQL statement to be executed</param>
    ''' <returns>Number of rows affected </returns>
    ''' <remarks>Copyright © 2007 by Corning, Inc.</remarks>
    Public Function ExecuteMySQLEx(ByVal SqlText As String) As Integer

        ' Configure the SqlCommand object
        With _cmdSqlCommand
            .CommandType = CommandType.Text                 'Set type to Text
            .CommandText = SqlText                          'Specify SQL syntax
        End With

        Return _cmdSqlCommand.ExecuteNonQuery()

    End Function

    ''' <summary>
    ''' GetSQLCompatibleString - Fixes single apostophe issues in sql strings
    ''' </summary>
    ''' <param name="Value">The string value to be checked/corrected</param>
    ''' <param name="WrapWithApostrophes">If set to true, string will be wrapped in apostophes</param>
    ''' <returns>The string value</returns>
    ''' <remarks>Copyright © 2007 by Corning, Inc.</remarks>
    Public Shared Function GetSQLCompatibleString(ByVal Value As String, ByVal WrapWithApostrophes As Boolean) As String
        If WrapWithApostrophes Then
            Return "'" & Value.Replace("'", "''") & "'"
        Else
            Return Value.Replace("'", "''")
        End If
    End Function


End Class
