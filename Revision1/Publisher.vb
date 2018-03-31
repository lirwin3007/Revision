Public Class Publisher

    Dim styles As New Dictionary(Of String, Bitmap)
    Public assessment As assessment

    Private Sub buttonNext_Click(sender As Object, e As EventArgs) Handles buttonNext.Click
        mainTab.SelectedIndex += 1
        updateEnables()
    End Sub

    Private Sub buttonPrevious_Click(sender As Object, e As EventArgs) Handles buttonPrevious.Click
        mainTab.SelectedIndex += -1
        updateEnables()
    End Sub

    Sub updateEnables()
        If mainTab.SelectedIndex = 0 Then
            buttonPrevious.Enabled = False
        Else
            buttonPrevious.Enabled = True
        End If
        If mainTab.SelectedIndex >= mainTab.TabPages.Count - 2 Then
            buttonNext.Enabled = False
        Else
            buttonNext.Enabled = True
        End If
    End Sub

    Private Sub buttonFinish_Click(sender As Object, e As EventArgs) Handles buttonFinish.Click
        If buttonFinish.Text = "Finish" Then
            mainTab.SelectedIndex = mainTab.TabPages.Count - 1
            buttonCancel.Visible = False
            buttonNext.Visible = False
            buttonPrevious.Visible = False
            updateEnables()
            buttonFinish.Text = "Close"
            generatePublication()
        Else
            Me.Close()
            Form1.updatePublicationsGUI()
        End If
    End Sub

    Private Sub buttonCancel_Click(sender As Object, e As EventArgs) Handles buttonCancel.Click
        Me.Close()
    End Sub

    Private Sub Publisher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mainTab.Appearance = TabAppearance.FlatButtons
        mainTab.ItemSize = New Size(0, 1)
        mainTab.SizeMode = TabSizeMode.Fixed

        styles.Add("Edexcel Style", New Bitmap("ExamStyles/Edexcel.png"))
        For Each styleKey In styles.Keys
            listStyles.Items.Add(styleKey)
        Next
        If listStyles.Items.Count > 0 Then listStyles.SelectedIndex = 0

        For Each tagName In assessment.tags
            listTags.Items.Add(tagName, True)
        Next

        nudQuestionCount.Maximum = assessment.questions.Count
        nudQuestionCount.Value = nudQuestionCount.Maximum

    End Sub

    Private Sub listStyles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listStyles.SelectedIndexChanged
        PictureBox1.Image = styles(listStyles.SelectedItem)
    End Sub

    Private Sub nudMinMark_ValueChanged(sender As Object, e As EventArgs) Handles nudMinMark.ValueChanged
        nudMaxMark.Minimum = nudMinMark.Value + 1
    End Sub

    Private Sub nudMaxMark_ValueChanged(sender As Object, e As EventArgs) Handles nudMaxMark.ValueChanged
        nudMinMark.Maximum = nudMaxMark.Value
    End Sub



    Sub generatePublication()

        If getquestions().Count = 0 Then
            MsgBox("No questions found! Please broaden search criteria", MsgBoxStyle.Critical, "Error")
            mainTab.SelectedIndex = 2
            buttonCancel.Visible = True
            buttonNext.Visible = True
            buttonPrevious.Visible = True
            updateEnables()
            buttonFinish.Text = "Finish"
            Exit Sub
        End If

        Dim tagList As New List(Of String)
        For Each item In listTags.CheckedItems
            tagList.Add(item)
        Next

        Form1.assessments(assessment.name).addNewPublication(styles(listStyles.SelectedItem), nudMinMark.Value, nudMaxMark.Value, tagList, checkIncludeUntagged.Checked, nudQuestionCount.Value, Form1.getSelectedPath, checkRandom.Checked)

    End Sub

    Private Sub listTags_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listTags.SelectedIndexChanged
        nudQuestionCount.Maximum = getQuestions().Count
    End Sub



    Function getQuestions() As Dictionary(Of String, question)
        Dim result As New Dictionary(Of String, question)
        For Each questionKey In assessment.questions.Keys
            Dim question As question = assessment.questions(questionKey)
            For Each tagName In listTags.CheckedItems
                If question.tags.Contains(tagName) Then
                    If question.marks > nudMinMark.Value And question.marks < nudMaxMark.Value Then
                        result.Add(questionKey, question)
                    End If
                    Exit For
                End If
            Next
            If question.tags.Count = 0 And checkIncludeUntagged.Checked Then
                If question.marks > nudMinMark.Value And question.marks < nudMaxMark.Value Then
                    result.Add(questionKey, question)
                End If
            End If
        Next

        Dim finalResult As Dictionary(Of String, question) = result
        If result.Count > nudQuestionCount.Value Then
            result = jumble(result)
            finalResult = New Dictionary(Of String, question)
            For counter = 0 To nudQuestionCount.Value - 1
                finalResult.Add(result.Keys(counter), result(result.Keys(counter)))
            Next
        End If

        Return result
    End Function

    Function jumble(collection As Dictionary(Of String, question)) As Dictionary(Of String, question)
        Dim result As New Dictionary(Of String, question)
        Do Until collection.Count = 0
            Dim random As Integer = Rnd() * (collection.Count - 1)
            Dim randomKey As String = collection.Keys(random)
            result.Add(randomKey, collection(randomKey))
            collection.Remove(randomKey)
        Loop
        Return result
    End Function

End Class

Public Class questionCollection

    Public questions As New List(Of Integer)
    Public quantity As Integer
    Public maximum As Integer
    Public containsFullPage As Boolean = False

    Sub New(maximum As Integer, containsFullPage As Boolean)
        Me.maximum = maximum
        Me.containsFullPage = containsFullPage
    End Sub

    Function canFit(item As KeyValuePair(Of String, Integer))
        If quantity + item.Value < maximum Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub addItem(item As KeyValuePair(Of String, Integer))
        questions.Add(item.Key)
        quantity += item.Value
    End Sub

End Class