Public Class ctlCountyItem

#Region " Public Properties"

    Public Property CountyID As Integer

    Public Property CountyName As String

#End Region

#Region " Public Events"

    Public Sub Startup()
        Me.Opacity = 0
        lblName.Content = CountyName
        Dim aniFadeIn As New Animation.DoubleAnimation(1, TimeSpan.FromMilliseconds(500))
        Me.BeginAnimation(Canvas.OpacityProperty, aniFadeIn)
    End Sub

#End Region

End Class
