Imports System.Data
Imports System.Reflection

Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

#Region " Properties"

    Public Property ApplicationControl As MainWindow

    Public Property SelectedCountyID As Integer

    Public Property SelectedCountyName As String

    Public Property CurrentPageLoaded As enPageLoaded = enPageLoaded.None

#End Region

#Region " Enumerations"

    Public Enum enPageLoaded
        None
        MainWindow
        Dashboard
        Settings
    End Enum

#End Region

#Region " Database Methods"

    Public Function GetCountyName(ByVal CountyID As Integer) As String
        Dim strCountyName As String = "UNKNOWN"

        Try
            Dim objDataAccess As New clsDataAccess
            Dim dtResults As DataTable = objDataAccess.PerformQuery(String.Format("SELECT Descr FROM Counties WHERE County = {0}", CountyID.ToString))
            If dtResults.Rows.Count = 1 Then
                strCountyName = dtResults.Rows(0).Item(0).ToString
            End If
        Catch ex As Exception
            ' Do nothing
        End Try

        Return strCountyName

    End Function

#End Region

#Region " Embedded DLL"

    ''' <summary>
    ''' This method will handle reading the embedded dll into memory
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AssemblyResolve(ByVal sender As Object, ByVal e As ResolveEventArgs) As Assembly
        ' Create the assembly object to return
        Dim objAssembly As Assembly = Nothing
        ' See what assembly is trying to be loaded and load the correct resource
        Select Case UCase(Split(e.Name, ",")(0))
            Case UCase("WPFPAGETRANSITIONS")
                objAssembly = Assembly.Load(My.Resources.WpfPageTransitions)

        End Select
        ' Return the assembly just created if the resource was found
        Return objAssembly
    End Function

#End Region

    Public Sub New()
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf AssemblyResolve
    End Sub
End Class
