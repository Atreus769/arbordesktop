Public Class ctlSettings

    Public Event CloseWindow()

    Private Sub btnSave_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles btnSave.Click
        ' Call the method to save the settings and raise the event to close the window
        SaveSettings()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles btnCancel.Click
        ' Raise the event for the parent window to close this one
        RaiseEvent CloseWindow()
    End Sub

    Private Sub ctlSettings_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        ' Load the current settings
        With My.Settings
            txtServerName.Text = .DatabaseServer
            txtDatabase.Text = .DatabaseName
            txtUsername.Text = .DatabaseUsername
            txtPassword.Password = .DatabasePassword
        End With

        ' Set the initial focus to the server textbox
        txtServerName.Focus()
    End Sub

    Private Sub btnTestConnection_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles btnTestConnection.Click
        ' Initialize the data access class
        Dim objDataAccess As New clsDataAccess

        ' Show the results of the connection testing
        MsgBox(String.Format("Test Connection was: {0}", IIf(objDataAccess.TestConnection, "Successful!", "Error")), MsgBoxStyle.OkOnly, "Test Connection")
    End Sub

    Private Sub txtDatabase_GotFocus(sender As Object, e As System.Windows.RoutedEventArgs) Handles txtDatabase.GotFocus, txtServerName.GotFocus, txtUsername.GotFocus
        ' Highlight everything in the textbox
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As System.Windows.RoutedEventArgs) Handles txtPassword.GotFocus
        ' Highlight everything in the password box
        txtPassword.SelectAll()
    End Sub

    Private Sub txtDatabase_KeyUp(sender As Object, e As System.Windows.Input.KeyEventArgs) Handles txtDatabase.KeyUp, txtServerName.KeyUp, _
        txtUsername.KeyUp, txtPassword.KeyUp

        ' Allow the user to hit the 'ENTER' key to save the settings and close the window
        If e.Key = Key.Enter Or e.Key = Key.Return Then
            SaveSettings()
        End If
    End Sub

    Private Sub SaveSettings()
        ' Save the new settings
        With My.Settings
            .DatabaseServer = txtServerName.Text
            .DatabaseName = txtDatabase.Text
            .DatabaseUsername = txtUsername.Text
            .DatabasePassword = txtPassword.Password
            .Save()
        End With

        ' Raise the event for the parent window to close this one
        RaiseEvent CloseWindow()
    End Sub

End Class
