Public Class screenshot

    Public picture As Bitmap
    Public result As String = Nothing
    Public isquestion As Boolean

    Dim preview As Bitmap
    Dim graphics As Graphics
    Dim beginPoint As Point
    Dim rectSize As Point
    Dim rectPosition As Point

    Private Sub picScreenshot_MouseDown(sender As Object, e As MouseEventArgs) Handles picScreenshot.MouseDown
        drawingTimer.Enabled = True
        beginPoint = Cursor.Position
    End Sub

    Private Sub drawingTimer_Tick(sender As Object, e As EventArgs) Handles drawingTimer.Tick
        preview = New Bitmap(picture)
        graphics = Graphics.FromImage(preview)

        rectSize = Cursor.Position - beginPoint
        rectPosition = beginPoint
        If rectSize.X < 0 Then
            rectPosition.X = Cursor.Position.X
            rectSize.X = beginPoint.X - rectPosition.X
        End If
        If rectSize.Y < 0 Then
            rectPosition.Y = Cursor.Position.Y
            rectSize.Y = beginPoint.Y - rectPosition.Y
        End If
        graphics.DrawRectangle(New Pen(Color.Red, 1), New Rectangle(rectPosition, rectSize))
        picScreenshot.Image = preview
    End Sub

    Private Sub picScreenshot_MouseUp(sender As Object, e As MouseEventArgs) Handles picScreenshot.MouseUp
        drawingTimer.Enabled = False

        Dim resultimage As New Bitmap(rectSize.X, rectSize.Y)
        graphics = Graphics.FromImage(resultimage)
        graphics.DrawImage(picture, 0, 0, New Rectangle(rectPosition, rectSize), GraphicsUnit.Pixel)

        Dim counter As Integer = 0
        While IO.File.Exists("screenshot" + counter.ToString() + ".png")
            counter += 1
        End While

        resultimage.Save("screenshot" + counter.ToString + ".png")
        result = "screenshot" + counter.ToString + ".png"
        If isquestion Then
            Form1.assessments(Form1.getSelectedAssessment()).questions(Form1.listboxQuestions.SelectedItem.ID).questions(Form1.listQuestionParts.SelectedIndex) = "screenshot" + counter.ToString + ".png"
            Form1.picQuestion.ImageLocation = Form1.assessments(Form1.getSelectedAssessment()).questions(Form1.listboxQuestions.SelectedItem.ID).questions(Form1.listQuestionParts.SelectedIndex)
        Else
            Form1.assessments(Form1.getSelectedAssessment()).questions(Form1.listboxQuestions.SelectedItem.ID).markSchemes(Form1.listQuestionParts.SelectedIndex) = "screenshot" + counter.ToString + ".png"
            Form1.picMarkScheme.ImageLocation = Form1.assessments(Form1.getSelectedAssessment()).questions(Form1.listboxQuestions.SelectedItem.ID).markSchemes(Form1.listQuestionParts.SelectedIndex)
        End If
        Me.Hide()
        result = Nothing
    End Sub

    Public Sub takeScreenshot()
        Me.Show()
        Dim previousstate = Form1.WindowState
        Form1.WindowState = FormWindowState.Minimized
        Me.WindowState = FormWindowState.Minimized
        Threading.Thread.Sleep(500)

        Dim bounds As Rectangle
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        picture = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        graph = Graphics.FromImage(picture)
        graph.CopyFromScreen(0, 0, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        picScreenshot.Image = picture
        Me.WindowState = FormWindowState.Maximized
        Form1.WindowState = previousstate
    End Sub
End Class