Public Class ctlContentItem

    Public Event ContentClicked(ByVal ContentHeader As String)

    Private objItemImage As ImageSource
    Public Property ItemImage As ImageSource
        Get
            Return objItemImage
        End Get
        Set(value As ImageSource)
            Image1.Height = Me.Height
            Image1.Width = Me.Width
            Image1.Margin = New System.Windows.Thickness(2)
            Image1.Source = value
        End Set
    End Property

    Private strContentHeader As String
    Public Property ContentHeader As String
        Get
            Return strContentHeader
        End Get
        Set(value As String)
            strContentHeader = value
        End Set
    End Property

    Private Sub ctlContentItem_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        TextBlock1.Text = ContentHeader
        colBGColor = Me.Background
    End Sub

    Private blnMouseDown As Boolean = False
    Private Sub ctlContentItem_MouseDown(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles Me.MouseDown
        blnMouseDown = True
    End Sub

    Private colBGColor As SolidColorBrush
    Private Sub ctlContentItem_MouseEnter(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles Me.MouseEnter
        Me.Background = New SolidColorBrush(Colors.White)
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub ctlContentItem_MouseLeave(sender As Object, e As System.Windows.Input.MouseEventArgs) Handles Me.MouseLeave
        blnMouseDown = False
        Me.Background = colBGColor
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ctlContentItem_MouseUp(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles Me.MouseUp
        If blnMouseDown Then
            'RaiseEvent ContentClicked(strContentHeader)
            RaiseEvent ContentClicked(Me.Name)
        End If
    End Sub

End Class
