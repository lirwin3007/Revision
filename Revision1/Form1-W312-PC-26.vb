Public Class Form1

    Dim assessments As New Dictionary(Of String, assessment)

    Enum stages
        home = 0
        overview = 1
        questions = 2
        publications = 3
        results = 4
    End Enum

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not folderStructure.SelectedNode Is Nothing Then
            folderStructure.SelectedNode.Nodes.Add(InputBox("New folder name:"))
        Else
            MsgBox("Please select and assesment or folder")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim name As String = InputBox("Assesment name:")
        folderStructure.Nodes.Add(name, name, 0)
        assessments.Add(name, New assessment(name))
        Dim a = folderStructure.Nodes.IndexOfKey(name)
        Dim counter = 0
        For Each node As TreeNode In folderStructure.Nodes
            If node.Text = name Then Exit For
            counter += 1
        Next
        folderStructure.Nodes(counter).Nodes.Add("Questions", "Questions", 2)
        folderStructure.Nodes(counter).Nodes.Add("Publications", "Publications", 1)
        folderStructure.Nodes(counter).Nodes.Add("Results", "Results", 3)
    End Sub

    Private Sub folderStructure_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles folderStructure.AfterSelect
        Dim currentNode = folderStructure.SelectedNode
        Do Until currentNode.Text = "Questions" Or currentNode.Text = "Publications" Or currentNode.Text = "Results" Or currentNode.Parent Is Nothing
            currentNode = currentNode.Parent
        Loop
        If currentNode.Parent Is Nothing Then
            MainTab.SelectedIndex = stages.overview
            Exit Sub
        End If
        Select Case currentNode.Text
            Case = "Questions"
                updateQuestionsGUI()
                MainTab.SelectedIndex = stages.questions
            Case = "Publications"
                MainTab.SelectedIndex = stages.publications
            Case = "Results"
                MainTab.SelectedIndex = stages.results
        End Select
    End Sub

    Function getSelectedAssessment() As String
        If folderStructure.SelectedNode Is Nothing Then Return Nothing
        Dim currentNode = folderStructure.SelectedNode
        Do Until assessments.ContainsKey(currentNode.Text)
            currentNode = currentNode.Parent
        Loop
        Return currentNode.Text
    End Function

    Sub updateQuestionsGUI()
        Dim assessmentName As String = getSelectedAssessment()
        listboxQuestions.Items.Clear()
        For Each question In assessments(assessmentName).questions
            listboxQuestions.Items.Add(question)
        Next
        If listboxQuestions.Items.Count <> 0 Then listboxQuestions.SelectedIndex = listboxQuestions.Items.Count - 1
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainTab.Appearance = TabAppearance.FlatButtons
        MainTab.ItemSize = New Size(0, 1)
        MainTab.SizeMode = TabSizeMode.Fixed

        For Each tab As TabPage In MainTab.TabPages
            tab.Text = ""
        Next
    End Sub

    Private Sub btnAddQuestion_Click(sender As Object, e As EventArgs) Handles btnAddQuestion.Click
        Dim newQuestion As New question(Nothing, Nothing, nudMarks.Minimum)
        assessments(getSelectedAssessment()).questions.Add(newQuestion)
        updateQuestionsGUI()
    End Sub

    Private Sub listboxQuestions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listboxQuestions.SelectedIndexChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        tbxQuestion.Text = CType(listboxQuestions.SelectedItem, question).question
        tbxMarkScheme.Text = CType(listboxQuestions.SelectedItem, question).markScheme
        nudMarks.Value = CType(listboxQuestions.SelectedItem, question).marks
    End Sub

    Private Sub nudMarks_ValueChanged(sender As Object, e As EventArgs) Handles nudMarks.ValueChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedIndex).marks = nudMarks.Value
    End Sub

    Private Sub tbxQuestion_TextChanged(sender As Object, e As EventArgs) Handles tbxQuestion.TextChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedIndex).question = tbxQuestion.Text
    End Sub

    Private Sub tbxMarkScheme_TextChanged(sender As Object, e As EventArgs) Handles tbxMarkScheme.TextChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedIndex).markScheme = tbxMarkScheme.Text
    End Sub
End Class

Public Class assessment
    Public name As String
    Public questions As New List(Of question)
    Public publications As New List(Of question)
    Public results As New List(Of question)

    Shared listOfAssessmentNames As New List(Of String)

    Sub New(name As String)
        If Not listOfAssessmentNames.Contains(name) Then
            Me.name = name
            listOfAssessmentNames.Add(name)
            IO.Directory.CreateDirectory(name)
            IO.Directory.CreateDirectory(name + "/questions")
            IO.Directory.CreateDirectory(name + "/publications")
            IO.Directory.CreateDirectory(name + "/results")
        Else
            Throw New Exception("Assessment already exists")
        End If
    End Sub
End Class

Public Class question
    Public question As String
    Public markScheme As String
    Public marks As Integer

    Sub New(question, markScheme, marks)
        Me.question = question
        Me.markScheme = markScheme
        Me.marks = marks
    End Sub

    Sub New(filepath As String)
        lDim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\\testfile.txt")
        Dim stringReader As String
        stringReader = fileReader.ReadLine()
        MsgBox("The first line of the file is " & stringReader)
    End Sub

    Sub save(filepath As String)
        Dim file As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(filepath, False)
        file.Write(Me.question + "¬" + Me.markScheme + "¬" + Me.marks)
        file.Close()
    End Sub

End Class

Public Class publication

End Class

Public Class result

End Class