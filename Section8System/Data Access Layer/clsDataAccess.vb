Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class clsDataAccess

#Region " Declarations"

    Dim objConnection As OleDbConnection
    Dim objSQLConnection As cSQLDatabase

#End Region

#Region " Private Functions"

    Private Sub CreateConnection()
        ' Determine which database connection is going to be used
        If My.Settings.UseSqlServer Then
            ' Dispose of the object if it is initialized
            If Not IsNothing(objSQLConnection) Then
                CloseConnection()
            End If

            ' Create the connection to the SQL Server
            With My.Settings
                objSQLConnection = New cSQLDatabase(.DatabaseServer, .DatabaseName, .DatabaseUsername, .DatabasePassword)
            End With
        Else
            ' Dispose of the object if it is initialized
            If Not IsNothing(objConnection) Then
                CloseConnection()
            End If

            ' Create the connection to the database file
            objConnection = New OleDbConnection(String.Format("Provider=Microsoft.Jet.Oledb.4.0; Data Source={0}", My.Settings.DatabaseLocation))
            objConnection.Open()
        End If
    End Sub

    Private Sub CloseConnection()
        ' Determine which database connection is going to be used
        If My.Settings.UseSqlServer Then
            Try
                ' Try to destroy the SQL connection
                objSQLConnection.Dispose()
                objSQLConnection = Nothing
            Catch ex As Exception
                ' Do nothing
            End Try
        Else
            Try
                ' Try to destroy the file connection
                objConnection.Close()
                objConnection.Dispose()
                objConnection = Nothing
            Catch ex As Exception
                ' Do nothing
            End Try
        End If
    End Sub

#End Region

#Region " Public Functions"

    Public Function TestConnection() As Boolean
        Dim blnResult As Boolean = False

        Try
            ' Attempt to create the connection 
            CreateConnection()

            ' If we are here then the connection worked
            blnResult = True
        Catch ex As Exception
            ' Do nothing
        Finally
            CloseConnection()
        End Try

        ' Return the results
        Return blnResult
    End Function

    Public Function PerformQuery(ByVal Query As String) As DataTable
        ' Initialize the variable to hold the results datatable
        Dim dtResults As New DataTable

        Try
            ' Create the connection to the database
            CreateConnection()

            ' Determine which database connection is going to be used
            If My.Settings.UseSqlServer Then
                ' Execute the query on the database server
                dtResults = objSQLConnection.AdHocQuery(Query)
            Else
                ' Execute the query against the database file
                Dim objCommand As New OleDbCommand(Query, objConnection)
                Dim objDataAdapter As New OleDbDataAdapter(objCommand)
                objDataAdapter.Fill(dtResults)
            End If
        Catch ex As Exception
            ' Do nothing
        Finally
            ' Close the database connection being used
            CloseConnection()
        End Try

        ' Return the results that were found
        Return dtResults
    End Function

    Public Function GetCounties() As DataTable
        ' Initialize the variables to be used
        Dim dtResults As New DataTable
        Dim strQuery As String = "SELECT * FROM Counties"

        Try
            ' Create the connection to the database
            CreateConnection()

            ' Determine which database connection is going to be used
            If My.Settings.UseSqlServer Then
                ' Execute the query on the database server
                dtResults = objSQLConnection.AdHocQuery(strQuery)
            Else
                ' Execute the query against the database file
                Dim objCommand As New OleDbCommand(strQuery, objConnection)
                Dim objDataAdapter As New OleDbDataAdapter(objCommand)
                objDataAdapter.Fill(dtResults)
            End If
        Catch ex As Exception
            ' Do nothing
        Finally
            ' Close the database connection being used
            CloseConnection()
        End Try

        ' Return the results that were found
        Return dtResults
    End Function

    Public Function GetTypeCodes() As DataTable
        ' Initialize the variables to be used
        Dim dtResults As New DataTable
        Dim strQuery As String = "SELECT * FROM TypeCodes"

        Try
            ' Create the connection to the database
            CreateConnection()

            ' Determine which database connection is going to be used
            If My.Settings.UseSqlServer Then
                ' Execute the query on the database server
                dtResults = objSQLConnection.AdHocQuery(strQuery)
            Else
                ' Execute the query against the database file
                Dim objCommand As New OleDbCommand(strQuery, objConnection)
                Dim objDataAdapter As New OleDbDataAdapter(objCommand)
                objDataAdapter.Fill(dtResults)
            End If
        Catch ex As Exception
            ' Do nothing
        Finally
            ' Close the database connection being used
            CloseConnection()
        End Try

        ' Return the results that were found
        Return dtResults
    End Function

    Public Function GetTypeCodeValues(ByVal TypeCode As String, ByVal CountyID As Integer) As DataTable
        ' Initialize the variables to be used
        Dim dtResults As New DataTable
        Dim strQuery As String = String.Format("SELECT * FROM Schedule WHERE TypeCode='{0}' AND County={1} AND Description IS NOT NULL ORDER BY Description ASC", TypeCode, CountyID.ToString)

        Try
            ' Create the connection to the database
            CreateConnection()

            ' Determine which database connection is going to be used
            If My.Settings.UseSqlServer Then
                ' Execute the query on the database server
                dtResults = objSQLConnection.AdHocQuery(strQuery)
            Else
                ' Execute the query against the database file
                Dim objCommand As New OleDbCommand(strQuery, objConnection)
                Dim objDataAdapter As New OleDbDataAdapter(objCommand)
                objDataAdapter.Fill(dtResults)
            End If
        Catch ex As Exception
            ' Do nothing
        Finally
            ' Close the database connection being used
            CloseConnection()
        End Try

        ' Return the results that were found
        Return dtResults
    End Function

    Public Function GetUnitsForRecertification(ByVal CountyID As Integer) As DataTable
        ' Initialize the variables to be used
        Dim dtResults As New DataTable
        Dim strQuery As String = String.Format("SELECT * FROM Master WHERE County={0} AND RecertDate>='{0}'", CountyID.ToString, Now.AddDays(60))

        Try
            ' Create the connection to the database
            CreateConnection()

            ' Determine which database connection is going to be used
            If My.Settings.UseSqlServer Then
                ' Execute the query on the database server
                dtResults = objSQLConnection.AdHocQuery(strQuery)
            Else
                ' Execute the query against the database file
                Dim objCommand As New OleDbCommand(strQuery.ToString, objConnection)
                Dim objDataAdapter As New OleDbDataAdapter(objCommand)
                objDataAdapter.Fill(dtResults)
            End If

            ' Filter the results
            dtResults = dtResults.Select(String.Format("County={0}", CountyID.ToString)).CopyToDataTable
        Catch ex As Exception
            ' Do nothing
        Finally
            ' Close the database connection being used
            CloseConnection()
        End Try

        ' Return the results that were found
        Return dtResults
    End Function

    Public Function GetMasterUnitList(ByVal CountyID As Integer) As DataTable
        ' Initialize the variables to be used
        Dim dtResults As New DataTable
        Dim strQuery As String = String.Format("SELECT * FROM Master WHERE County={0}", CountyID.ToString)

        Try
            ' Create the connection to the database
            CreateConnection()

            ' Determine which database connection is going to be used
            If My.Settings.UseSqlServer Then
                ' Execute the query on the database server
                dtResults = objSQLConnection.AdHocQuery(strQuery)
            Else
                ' Execute the query against the database file
                Dim objCommand As New OleDbCommand(strQuery.ToString, objConnection)
                Dim objDataAdapter As New OleDbDataAdapter(objCommand)
                objDataAdapter.Fill(dtResults)
            End If

            '' Filter the results
            'dtResults = dtResults.Select(String.Format("County={0}", CountyID.ToString)).CopyToDataTable
        Catch ex As Exception
            ' Do nothing
        Finally
            ' Close the database connection being used
            CloseConnection()
        End Try

        ' Return the results that were found
        Return dtResults
    End Function

#End Region

End Class
