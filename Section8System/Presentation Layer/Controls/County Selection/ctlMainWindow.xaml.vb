Imports System.Data
Public Class ctlMainWindow

#Region " Declarations"

    Dim dtCounties As DataTable

#End Region

#Region " Public Methods"

    Public Sub Startup()
        Dim objDataAccess As New clsDataAccess
        dtCounties = objDataAccess.GetCounties
        If dtCounties.Rows.Count = 0 Then
            MsgBox("There was no data found while trying to load the database!", MsgBoxStyle.Critical)
        Else
            ' Clear the listbox
            lstCounties.Items.Clear()

            Dim t As New System.Threading.Thread(Sub() FillCountyList())
            t.Start()
        End If
    End Sub

#End Region

#Region " Private Methods"

    Private Sub FillCountyList()
        Try
            ' Loop through each county that was found
            For Each drMessage As DataRow In dtCounties.Rows
                With drMessage
                    ' Setup the county item object
                    lstCounties.Dispatcher.Invoke(New BindServiceGridDelegate(AddressOf BindServiceGrid), CInt(.Item("County")), .Item("Descr").ToString)
                End With
                System.Threading.Thread.Sleep(100)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Delegate Sub BindServiceGridDelegate(ByVal CountyID As Integer, ByVal CountyName As String)
    Private Sub BindServiceGrid(ByVal CountyID As Integer, ByVal CountyName As String)
        ' Setup the county detail item object
        Dim objCountyItem As New ctlCountyItem
        With objCountyItem
            ' Set the values of the item object
            .CountyID = CountyID
            .CountyName = CountyName
        End With
        lstCounties.Items.Add(objCountyItem)
        objCountyItem.Startup()
    End Sub

#End Region

#Region " Events"

    Public Event LoadCounty(ByVal CountyID As Integer, ByVal CountyName As String)

    Public Event LoadSettings()

#End Region

#Region " Window Events"

    Private Sub ctlMainWindow_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        ' Clear the listbox on object initialization
        lstCounties.Items.Clear()
    End Sub

    Private Sub lstCounties_MouseDoubleClick(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles lstCounties.MouseDoubleClick
        If lstCounties.SelectedIndex >= 0 Then
            Dim objCounty As ctlCountyItem = CType(lstCounties.Items(lstCounties.SelectedIndex), ctlCountyItem)
            RaiseEvent LoadCounty(objCounty.CountyID, objCounty.CountyName)
        End If
    End Sub

#End Region

#Region " Database Location Configuration"

    Dim blnSettingsClicked As Boolean = False
    Private Sub imgDatabase_MouseDown(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles imgDatabase.MouseDown
        blnSettingsClicked = True
    End Sub

    Private Sub imgDatabase_MouseEnter(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles imgDatabase.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub imgDatabase_MouseLeave(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles imgDatabase.MouseLeave
        Me.Cursor = Cursors.Arrow
        blnSettingsClicked = False
    End Sub

    Private Sub imgDatabase_MouseUp(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles imgDatabase.MouseUp
        ' Check for a true click
        If blnSettingsClicked Then
            RaiseEvent LoadSettings()

            'My.Application.ApplicationControl.IsEnabled = False

            '' The icon has been clicked, open the settings window
            'SettingsPopup.IsOpen = True
            ''Dim objOpenFileDialog As New Microsoft.Win32.OpenFileDialog
            ''If objOpenFileDialog.ShowDialog Then
            ''    ' Save the new database location
            ''    My.Settings.DatabaseLocation = objOpenFileDialog.FileName
            ''    My.Settings.Save()
            ''    ' Try refresh the county listing using the new database location
            ''    Startup()
            ''End If
        End If
    End Sub

    'Private Sub SettingsPopupControl_CloseWindow() Handles SettingsPopupControl.CloseWindow
    '    SettingsPopup.IsOpen = False
    '    My.Application.ApplicationControl.IsEnabled = True
    'End Sub

#End Region


End Class
