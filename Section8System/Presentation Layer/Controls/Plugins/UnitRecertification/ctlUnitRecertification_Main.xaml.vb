Public Class ctlUnitRecertification_Main

    Private Sub ctlUnitRecertification_Main_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        Dim objDataAccess As New clsDataAccess
        DataGrid1.ItemsSource = objDataAccess.GetUnitsForRecertification(My.Application.SelectedCountyID).DefaultView
    End Sub

End Class
