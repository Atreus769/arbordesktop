Public Class ctlSystemMaintenance_Main

    Private Sub ctlSystemMaintenance_Main_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        RefreshTypeCodes()
    End Sub

    Private Sub RefreshTypeCodes()
        ' Clear the combobox
        cmbTypeCode.ItemsSource = Nothing

        ' Clear the datagrid
        dgTypeCode.ItemsSource = Nothing

        ' Initialize the object to lookup the data
        Dim objDataAccess As New clsDataAccess

        ' Populate the combobox values
        cmbTypeCode.ItemsSource = objDataAccess.GetTypeCodes.DefaultView
        cmbTypeCode.DisplayMemberPath = "Description"
        cmbTypeCode.SelectedValuePath = "TypeCode"
        cmbTypeCode.SelectedIndex = -1

    End Sub

    Private Sub cmbTypeCode_SelectionChanged(sender As Object, e As System.Windows.Controls.SelectionChangedEventArgs) Handles cmbTypeCode.SelectionChanged
        If cmbTypeCode.SelectedIndex < 0 Then
            ' Invalid selection
            Exit Sub
        End If

        Dim objDataAccess As New clsDataAccess
        dgTypeCode.ItemsSource = objDataAccess.GetTypeCodeValues(cmbTypeCode.SelectedValue.ToString, My.Application.SelectedCountyID).DefaultView

        CType(dgTypeCode.Columns(0), DataGridTextColumn).Binding = New Binding("Description")
        CType(dgTypeCode.Columns(1), DataGridTextColumn).Binding = New Binding("Points")
    End Sub

#Region " Refreshing"

    Private blnRefreshMouseDown As Boolean = False
    Private Sub imgRefresh_MouseDown(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles imgRefresh.MouseDown
        blnRefreshMouseDown = True
    End Sub

    Private Sub imgRefresh_MouseUp(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles imgRefresh.MouseUp
        If blnRefreshMouseDown Then
            RefreshTypeCodes()
        End If
    End Sub

    Private Sub imgRefresh_MouseEnter(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles imgRefresh.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub imgRefresh_MouseLeave(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles imgRefresh.MouseLeave
        blnRefreshMouseDown = False
        Me.Cursor = Cursors.Arrow
    End Sub

#End Region

#Region " Add new type code value"

    Private blnAddNewCodeMouseDown As Boolean = False
    Private Sub txtAddNewCode_MouseDown(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles txtAddNewValue.MouseDown
        blnAddNewCodeMouseDown = True
    End Sub

    Private Sub txtAddNewCode_MouseUp(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles txtAddNewValue.MouseUp
        If blnAddNewCodeMouseDown Then
            ' Diable the main screen behind the pop-up window
            'My.Application.ApplicationControl.IsEnabled = False

            ' Open the pop-up window
            ' *** TODO

            ' Show the add new type code window to the user
            ' *** TODO

        End If
    End Sub

    Private Sub txtAddNewCode_MouseEnter(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles txtAddNewValue.MouseEnter
        Me.Cursor = Cursors.Hand
        txtAddNewValue.TextDecorations = System.Windows.TextDecorations.Underline
    End Sub

    Private Sub txtAddNewCode_MouseLeave(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles txtAddNewValue.MouseLeave
        blnAddNewCodeMouseDown = False
        Me.Cursor = Cursors.Arrow
        txtAddNewValue.TextDecorations = Nothing
    End Sub

#End Region

End Class
