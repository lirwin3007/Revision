Public Class Marker

    Public testToMark As test
    Public questions As Dictionary(Of Integer, question)

    Public Sub showForm(testTomark As test, questions As Dictionary(Of Integer, question))
        Me.testToMark = testTomark
        Me.questions = questions
        Me.Show()
    End Sub

    Sub updateEnables()
        If tabMain.SelectedIndex = 0 Then
            buttonPrevious.Enabled = False
        Else
            buttonPrevious.Enabled = True
        End If
        If tabMain.SelectedIndex >= tabMain.TabPages.Count - 1 Then
            buttonNext.Enabled = False
        Else
            buttonNext.Enabled = True
        End If
    End Sub

    Private Sub Marker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabMain.TabPages.Clear()
        For counter = 0 To testToMark.questionIDs.Count - 1
            Dim newTabPage As New TabPage

            Dim tableLayout As New TableLayoutPanel
            tableLayout.RowCount = 2
            tableLayout.ColumnCount = 1
            tableLayout.RowStyles.Add(New ColumnStyle(SizeType.Percent, 90))
            tableLayout.RowStyles.Add(New ColumnStyle(SizeType.Percent, 10))
            tableLayout.Dock = DockStyle.Fill

            Dim markContainer As New TableLayoutPanel
            markContainer.RowCount = 1
            markContainer.ColumnCount = 2
            markContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 90))
            markContainer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 10))
            markContainer.Dock = DockStyle.Fill
            Dim trackbar As New TrackBar
            trackbar.Minimum = 0
            trackbar.Maximum = questions(testToMark.questionIDs(counter)).marks
            trackbar.Dock = DockStyle.Fill
            trackbar.Value = trackbar.Maximum
            AddHandler trackbar.ValueChanged, New EventHandler(AddressOf trackbarChange)
            Dim label As New Label
            label.Dock = DockStyle.Fill
            label.TextAlign = ContentAlignment.MiddleCenter
            label.Text = trackbar.Maximum.ToString + "/" + trackbar.Maximum.ToString()
            markContainer.Controls.Add(trackbar)
            markContainer.Controls.Add(label)

            Dim markscheme As Object
            If questions(testToMark.questionIDs(counter)).markSchemeType = "Image" Then
                markscheme = New PictureBox
                markscheme.Dock = DockStyle.Fill
                markscheme.SizeMode = PictureBoxSizeMode.Zoom
                markscheme.ImageLocation = questions(testToMark.questionIDs(counter)).markSchemeImageLocation
            Else
                markscheme = New Label
                markscheme.Dock = DockStyle.Fill
                markscheme.text = questions(testToMark.questionIDs(counter)).markScheme
            End If

            tableLayout.Controls.Add(markscheme)
            tableLayout.Controls.Add(markContainer)

            newTabPage.Controls.Add(tableLayout)
            newTabPage.Text = "Question " + (counter + 1).ToString()
            tabMain.TabPages.Add(newTabPage)
        Next
        progress.Maximum = tabMain.TabPages.Count - 1
        updateEnables()
    End Sub

    Private Sub trackbarChange(sender As Object, e As EventArgs)
        Dim controls = sender.parent.controls
        CType(controls(1), Label).Text = sender.value.ToString() + "/" + sender.maximum.ToString()
    End Sub

    Private Sub buttonPrevious_Click(sender As Object, e As EventArgs) Handles buttonPrevious.Click
        tabMain.SelectedIndex += -1
        updateEnables()
    End Sub

    Private Sub buttonNext_Click(sender As Object, e As EventArgs) Handles buttonNext.Click
        tabMain.SelectedIndex += 1
        updateEnables()
    End Sub

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged
        If tabMain.SelectedIndex <> -1 Then progress.Value = tabMain.SelectedIndex
    End Sub

    Private Sub buttonFinish_Click(sender As Object, e As EventArgs) Handles buttonFinish.Click
        Dim scores As New Dictionary(Of Integer, Integer)
        For counter = 0 To testToMark.questionIDs.Count - 1
            Dim question As Integer = questions(testToMark.questionIDs(counter)).ID
            Dim score As Integer = CType(CType(CType(tabMain.TabPages(counter).Controls(0), TableLayoutPanel).Controls(1), TableLayoutPanel).Controls(0), TrackBar).Value
            scores.Add(question, score)
        Next
        Form1.assessments(Form1.getSelectedAssessment()).addNewResult(Form1.assessments(Form1.getSelectedAssessment()).publications(CType(Form1.listPublications.SelectedItem, publication).ID).tests(CType(Form1.listTests.SelectedItem, test).ID), scores)
        Me.Close()
    End Sub
End Class