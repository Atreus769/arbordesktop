Public Class ctlInputModify_Main

#Region " Declarations"

    Dim objCurrentView As enViewType

#End Region

#Region " Enumerations"

    Private Enum enViewType
        GUI
        List
    End Enum

#End Region

#Region " Add new type code value"

    Private blnListViewMouseDown As Boolean = False
    Private Sub txtListView_MouseDown(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles txtListView.MouseDown
        blnListViewMouseDown = True
    End Sub

    Private Sub txtListView_MouseUp(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles txtListView.MouseUp
        If blnListViewMouseDown Then
            ' Diable the main screen behind the pop-up window
            'My.Application.ApplicationControl.IsEnabled = False

            ' Open the pop-up window
            ' *** TODO

            ' Show the add new type code window to the user
            ' *** TODO

        End If
    End Sub

    Private Sub txtListView_MouseEnter(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles txtListView.MouseEnter
        Me.Cursor = Cursors.Hand
        txtListView.TextDecorations = System.Windows.TextDecorations.Underline
    End Sub

    Private Sub txtListView_MouseLeave(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles txtListView.MouseLeave
        blnListViewMouseDown = False
        Me.Cursor = Cursors.Arrow
        txtListView.TextDecorations = Nothing
    End Sub

#End Region

    Private Sub ctlInputModify_Main_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        ' The default view is GUI on startup
        LoadViewControl(enViewType.GUI)

        ' DEBUGGING
        'LoadViewControl(enViewType.List)
    End Sub

    Private Sub LoadViewControl(ByVal ModeToLoad As enViewType)
        Select Case ModeToLoad
            Case enViewType.GUI
                CtlInputModify_GUI1.Opacity = 1
                CtlInputModify_ListView1.Opacity = 0
                CtlInputModify_GUI1.Startup()

            Case enViewType.List
                CtlInputModify_GUI1.Opacity = 0
                CtlInputModify_ListView1.Opacity = 1
                CtlInputModify_ListView1.Startup()

        End Select

        ' Set the current mode that is being shown
        objCurrentView = ModeToLoad
    End Sub

End Class
