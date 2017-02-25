Imports System.Reflection

Class MainWindow

#Region " Declarations"

    Dim WithEvents objMainWindow As ctlMainWindow
    Dim WithEvents objCountyDashboard As ctlDashboard
    Dim WithEvents objSettings As ctlSettings

#End Region

    Private Sub MainWindow_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        My.Application.ApplicationControl = Me
        ShowMainWindow()
    End Sub

    Private Sub ShowMainWindow()
        ' Create/Initialize the main window object
        If Not IsNothing(objMainWindow) Then
            objMainWindow = Nothing
        End If
        objMainWindow = New ctlMainWindow
        objMainWindow.Tag = UCase("MainWindow")


        pgTransition.ShowPage(objMainWindow)
    End Sub

    Private Sub pgTransition_PageLoaded(e As System.Windows.Controls.UserControl) Handles pgTransition.PageLoaded
        Select Case UCase(e.Tag.ToString)
            Case UCase("MainWindow")
                If My.Application.CurrentPageLoaded <> Application.enPageLoaded.MainWindow Then
                    My.Application.CurrentPageLoaded = Application.enPageLoaded.MainWindow
                    objMainWindow.Startup()
                End If

            Case UCase("CountyDashboard")
                If My.Application.CurrentPageLoaded <> Application.enPageLoaded.Dashboard Then
                    My.Application.CurrentPageLoaded = Application.enPageLoaded.Dashboard
                    objCountyDashboard.Startup(My.Application.SelectedCountyID)
                End If

            Case UCase("Settings")
                If My.Application.CurrentPageLoaded <> Application.enPageLoaded.Settings Then
                    My.Application.CurrentPageLoaded = Application.enPageLoaded.Settings
                End If

        End Select
    End Sub

    Private Sub objMainWindow_LoadCounty(CountyID As Integer, CountyName As String) Handles objMainWindow.LoadCounty
        If Not IsNothing(objCountyDashboard) Then
            objCountyDashboard = Nothing
        End If
        objCountyDashboard = New ctlDashboard
        objCountyDashboard.Tag = UCase("CountyDashboard")

        ' Set the currenty county selected
        My.Application.SelectedCountyID = CountyID
        My.Application.SelectedCountyName = CountyName

        ' Load the dashboard for the selected county
        pgTransition.ShowPage(objCountyDashboard)

    End Sub

    Private Sub objMainWindow_LoadSettings() Handles objMainWindow.LoadSettings
        If Not IsNothing(objSettings) Then
            objSettings = Nothing
        End If

        objSettings = New ctlSettings
        objSettings.Tag = UCase("Settings")

        ' Load the settings window
        pgTransition.ShowPage(objSettings)
    End Sub

    Private Sub objCountyDashboard_ExitCounty() Handles objCountyDashboard.ExitCounty
        ShowMainWindow()
    End Sub

    Private Sub objCountyDashboard_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles objCountyDashboard.Loaded
        ' Reset the page transition object size
        pgTransition.Height = Double.NaN
        pgTransition.Width = Double.NaN
    End Sub

    Private Sub objMainWindow_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles objMainWindow.Loaded
        pgTransition.Height = 300
        pgTransition.Width = 400
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region " Settings"

    Private Sub objSettings_CloseWindow() Handles objSettings.CloseWindow
        ShowMainWindow()
    End Sub

    Private Sub objSettings_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles objSettings.Loaded
        pgTransition.Height = 235
        pgTransition.Width = 300
    End Sub

#End Region

    Private Sub MainWindow_SizeChanged(sender As Object, e As System.Windows.SizeChangedEventArgs) Handles Me.SizeChanged
        Console.WriteLine(String.Format("Width: {0}; Height: {1}", e.NewSize.Width.ToString, e.NewSize.Height.ToString))
    End Sub
End Class
