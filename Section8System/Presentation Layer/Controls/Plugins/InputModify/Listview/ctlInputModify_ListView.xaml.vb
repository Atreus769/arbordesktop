Imports System.Data.SqlClient
Public Class ctlInputModify_ListView

    Public Sub Startup()
        Dim oDAL As New clsDataAccess
        dgUnits.ItemsSource = oDAL.GetMasterUnitList(My.Application.SelectedCountyID).DefaultView

    End Sub

End Class
