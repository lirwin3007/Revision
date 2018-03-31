Public Class imagePopup

    Dim images As List(Of Bitmap)

    Public Sub showForm(images As List(Of Bitmap))
        Me.images = images
        TrackBar1.Maximum = images.Count - 1
        TrackBar1.Value = 0
        PictureBox1.Image = images(TrackBar1.Value)
        Me.Show()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        PictureBox1.Image = images(TrackBar1.Value)
    End Sub
End Class