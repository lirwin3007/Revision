Public Class Publisher

    Dim styles As New Dictionary(Of String, Bitmap)
    Public assessment As assessment

    Dim updateNumberOfQuestion As Boolean = True

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
            listTagsExcluded.Items.Add(tagName, False)
        Next

        nudQuestionCount.Maximum = assessment.questions.Count
        nudQuestionCount.Value = nudQuestionCount.Maximum

    End Sub

    Private Sub listStyles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listStyles.SelectedIndexChanged
        PictureBox1.Image = styles(listStyles.SelectedItem)
    End Sub

    Private Sub nudMinMark_ValueChanged(sender As Object, e As EventArgs) Handles nudMinMark.ValueChanged
        nudMaxMark.Minimum = nudMinMark.Value + 1
        updateQuestionCount()
    End Sub

    Private Sub nudMaxMark_ValueChanged(sender As Object, e As EventArgs) Handles nudMaxMark.ValueChanged
        nudMinMark.Maximum = nudMaxMark.Value
        updateQuestionCount()
    End Sub



    Sub generatePublication()

        If getQuestions(assessment.questions).Count = 0 Then
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

        Dim excludedTagList As New List(Of String)
        For Each item In listTagsExcluded.CheckedItems
            excludedTagList.Add(item)
        Next

        Form1.assessments(assessment.name).addNewPublication(styles(listStyles.SelectedItem), nudMinMark.Value, nudMaxMark.Value, tagList, excludedTagList, checkIncludeUntagged.Checked, nudQuestionCount.Value, Form1.getSelectedPath, checkRandom.Checked, textboxName.Text)

    End Sub

    Sub updateQuestionCount()
        If Not assessment Is Nothing Then
            nudQuestionCount.Maximum = getQuestions(assessment.questions).Count
            If updateNumberOfQuestion Then
                nudQuestionCount.Value = nudQuestionCount.Maximum
            End If
        End If
    End Sub

    Private Sub listTags_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listTags.SelectedIndexChanged
        updateQuestionCount()
    End Sub

    Function getQuestions(completeQuestions As Dictionary(Of Integer, question)) As Dictionary(Of Integer, question)
        Dim result As New Dictionary(Of Integer, question)
        For Each questionKey In completeQuestions.Keys
            Dim question As question = completeQuestions(questionKey)
            Dim tags As New List(Of String)
            For Each item In listTags.CheckedItems
                tags.Add(item)
            Next
            Dim excludedTags As New List(Of String)
            For Each item In listTagsExcluded.CheckedItems
                excludedTags.Add(item)
            Next
            If question.containsTag(tags) And Not question.containsTag(excludedTags) Then
                If question.totalMarks > nudMinMark.Value And question.totalMarks < nudMaxMark.Value Then
                    result.Add(questionKey, question)
                End If
            End If
            If question.tags.Count = 0 And checkIncludeUntagged.Checked Then
                If question.totalMarks > nudMinMark.Value And question.totalMarks < nudMaxMark.Value Then
                    result.Add(questionKey, question)
                End If
            End If
        Next

        Return result
    End Function

    Private Sub btnSelectAllInclude_Click(sender As Object, e As EventArgs) Handles btnSelectAllInclude.Click
        For i = 0 To listTags.Items.Count - 1
            listTags.SetItemChecked(i, True)
        Next
        updateQuestionCount()
    End Sub

    Private Sub btnDeselectAllInclude_Click(sender As Object, e As EventArgs) Handles btnDeselectAllInclude.Click
        For i = 0 To listTags.Items.Count - 1
            listTags.SetItemChecked(i, False)
        Next
        updateQuestionCount()
    End Sub

    Private Sub btnSelectAllExclude_Click(sender As Object, e As EventArgs) Handles btnSelectAllExclude.Click
        For i = 0 To listTagsExcluded.Items.Count - 1
            listTagsExcluded.SetItemChecked(i, True)
        Next
        updateQuestionCount()
    End Sub

    Private Sub btnDeselectAllExclude_Click(sender As Object, e As EventArgs) Handles btnDeselectAllExclude.Click
        For i = 0 To listTagsExcluded.Items.Count - 1
            listTagsExcluded.SetItemChecked(i, False)
        Next
        updateQuestionCount()
    End Sub

    Private Sub listTagsExcluded_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listTagsExcluded.SelectedIndexChanged
        updateQuestionCount()
    End Sub

    Private Sub checkIncludeUntagged_CheckedChanged(sender As Object, e As EventArgs) Handles checkIncludeUntagged.CheckedChanged
        updateQuestionCount()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        updateNumberOfQuestion = True
        updateQuestionCount()
    End Sub

    Private Sub nudQuestionCount_Enter(sender As Object, e As EventArgs) Handles nudQuestionCount.Enter
        updateNumberOfQuestion = False
    End Sub
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