Public Class ctlDashboard

#Region " Declarations"

    Private WithEvents tmrDateTime As System.Timers.Timer
    Private intCountyID As Integer
    Private strCurrentContent As String

#End Region

#Region " Public Events"

    Public Event ExitCounty()

#End Region

#Region " Public Methods"

    Public Sub Startup(ByVal CountyID As Integer)
        intCountyID = CountyID
        lblTitle.Content = String.Format("{0} County", My.Application.GetCountyName(CountyID))
        lblDate.Content = Now.ToString

        ' Start the date/time timer
        If Not IsNothing(tmrDateTime) Then
            tmrDateTime.Stop()
            tmrDateTime.Dispose()
            tmrDateTime = Nothing
        End If
        tmrDateTime = New System.Timers.Timer(1000)
        tmrDateTime.AutoReset = True
        tmrDateTime.Start()
    End Sub

#End Region

#Region " Private Methods"

    Private Sub tmrDateTime_Elapsed(sender As Object, e As System.Timers.ElapsedEventArgs) Handles tmrDateTime.Elapsed
        ' Update the date/time label control
        lblDate.Dispatcher.Invoke(New Action(Sub() lblDate.Content = Now.ToString))
    End Sub

#End Region

#Region " Window Events"

    Private Sub ctlDashboard_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        lblDate.Content = String.Empty
        lblTitle.Content = String.Empty
    End Sub

#End Region

#Region " Exit Methods"
    Private blnExit As Boolean = False
    Private Sub grdExit_MouseDown(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles imgExit.MouseDown, lblExit.MouseDown
        blnExit = True
    End Sub

    Private Sub grdExit_MouseLeave(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles imgExit.MouseLeave, lblExit.MouseLeave
        blnExit = False
    End Sub

    Private Sub grdExit_MouseUp(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles imgExit.MouseUp, lblExit.MouseUp
        If blnExit Then
            ' Stop the date/time timer
            tmrDateTime.Stop()

            ' Raise the event to close the page
            RaiseEvent ExitCounty()
        End If
    End Sub

    Private Sub imgExit_MouseEnter(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles imgExit.MouseEnter, lblExit.MouseEnter
        Me.Cursor = System.Windows.Input.Cursors.Hand
    End Sub

    Private Sub imgExit_MouseLeave(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles imgExit.MouseLeave, lblExit.MouseLeave
        Me.Cursor = System.Windows.Input.Cursors.Arrow
    End Sub

#End Region

    Private Sub Item_ContentClicked(ContentHeader As String) Handles Item_SystemMaintenance.ContentClicked, Item_UnitRecertification.ContentClicked,
        Item_InputModify.ContentClicked

        If UCase(strCurrentContent) = UCase(ContentHeader) Then
            Exit Sub
        End If

        Select Case UCase(ContentHeader)
            Case UCase("Item_InputModify")
                pgPlugin.ShowPage(New ctlInputModify_Main)

            Case UCase("Item_SystemMaintenance")
                pgPlugin.ShowPage(New ctlSystemMaintenance_Main)

            Case UCase("Item_UnitRecertification")
                pgPlugin.ShowPage(New ctlUnitRecertification_Main)

        End Select

        strCurrentContent = ContentHeader
    End Sub

End Class
