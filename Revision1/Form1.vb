Public Class Form1

    Public assessments As New Dictionary(Of String, assessment)

    Enum stages
        home = 0
        overview = 1
        questions = 2
        resources = 3
        publications = 4
        results = 5
    End Enum

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim path As String = getSelectedPath()
        If Not folderStructure.SelectedNode Is Nothing Then
            Dim name As String = InputBox("New folder name:")
            folderStructure.SelectedNode.Nodes.Add(name)
            IO.Directory.CreateDirectory(path + name)
            assessments(getSelectedAssessment()).tags.Add(name)
            updateQuestionsGUI()
        Else
            MsgBox("Please select and assessment or folder")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim name As String = InputBox("Assessment name:")
        assessments.Add(name, New assessment(name, folderStructure))
    End Sub

    Sub updateResourcesGUI()
        Dim assessmentName As String = getSelectedAssessment()
        flowResources.Controls.Clear()
        For Each key In assessments(assessmentName).resources.Keys
            Dim resource As resource = assessments(assessmentName).resources(key)
            If resource.path = getSelectedPath() Then
                Dim newImageBox As New PictureBox
                newImageBox.Image = resource.image
                newImageBox.SizeMode = PictureBoxSizeMode.Zoom
                Dim width As Integer = Math.Floor((flowResources.Width - (trackZoom.Value * (newImageBox.Margin.Left + newImageBox.Margin.Right))) / trackZoom.Value)
                newImageBox.Size = New Size(width, width * (9 / 16))
                newImageBox.BorderStyle = BorderStyle.Fixed3D
                newImageBox.Cursor = Cursors.Hand
                flowResources.Controls.Add(newImageBox)
            End If
        Next
    End Sub

    Sub updateQuestionsGUI()
        Dim assessmentName As String = getSelectedAssessment()
        listboxQuestions.Items.Clear()
        For Each questionID In assessments(assessmentName).questions.Keys
            If assessments(assessmentName).questions(questionID).path = getSelectedPath() Then listboxQuestions.Items.Add(assessments(assessmentName).questions(questionID))
        Next
        If listboxQuestions.Items.Count <> 0 Then listboxQuestions.SelectedIndex = listboxQuestions.Items.Count - 1
        lbxTags.Items.Clear()
        For Each tagName In assessments(assessmentName).tags
            Dim checked As Boolean = False
            If listboxQuestions.SelectedIndex <> -1 Then
                If assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).tags.Contains(tagName) Then
                    checked = True
                End If
            End If
            lbxTags.Items.Add(tagName, checked)
        Next
        If listboxQuestions.SelectedIndex <> -1 Then
            TextBox1.Text = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).title
            cbxLinePage.SelectedItem = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).lineOrPage
            nudSpace.Value = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).linepagecount
            cbxQuestionType.SelectedItem = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).questionType
            cbxMarksSchemeType.SelectedItem = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).markSchemeType
            If cbxQuestionType.SelectedItem = "Written" Then
                tabQuestionType.SelectedIndex = 0
            Else
                tabQuestionType.SelectedIndex = 1
            End If
            If cbxMarksSchemeType.SelectedItem = "Written" Then
                tabMarkSchemeType.SelectedIndex = 0
            Else
                tabMarkSchemeType.SelectedIndex = 1
            End If
            If assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).questionImageLocation <> Nothing Then
                picQuestion.ImageLocation = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).questionImageLocation
            End If
            If assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).markSchemeImageLocation <> Nothing Then
                picMarkScheme.ImageLocation = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).markSchemeImageLocation
            End If
        End If
    End Sub

    Sub updateOverviewGUI()
        Dim assessmentName As String = getSelectedAssessment()
        lbxTagOverview.Items.Clear()
        For Each tagname In assessments(assessmentName).tags
            lbxTagOverview.Items.Add(tagname)
        Next
    End Sub

    Sub updatePublicationsGUI()
        Dim a = assessments(getSelectedAssessment())
        listPublications.Items.Clear()
        For Each publication In assessments(getSelectedAssessment()).publications
            listPublications.Items.Add(publication.Value)
        Next
        If listPublications.Items.Count > 0 Then listPublications.SelectedIndex = 0
    End Sub

    Private Sub folderStructure_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles folderStructure.AfterSelect
        Dim currentNode = folderStructure.SelectedNode
        Do Until currentNode.Text = "Questions" Or currentNode.Text = "Publications" Or currentNode.Text = "Results" Or currentNode.Text = "Resources" Or currentNode.Parent Is Nothing
            currentNode = currentNode.Parent
        Loop
        If currentNode.Parent Is Nothing Then
            MainTab.SelectedIndex = stages.overview
            updateOverviewGUI()
            Exit Sub
        End If
        Select Case currentNode.Text
            Case = "Questions"
                updateQuestionsGUI()
                MainTab.SelectedIndex = stages.questions
            Case = "Resources"
                updateResourcesGUI()
                MainTab.SelectedIndex = stages.resources
            Case = "Publications"
                updatePublicationsGUI()
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

    Function getSelectedPath() As String
        Dim nodeList As New List(Of TreeNode)
        Dim currentNode = folderStructure.SelectedNode
        Do Until currentNode.Parent Is Nothing
            nodeList.Add(currentNode)
            currentNode = currentNode.Parent
        Loop
        nodeList.Add(currentNode)
        Dim path As String = Nothing
        For i = nodeList.Count - 1 To 0 Step -1
            path += nodeList(i).Text + "\"
        Next
        Return path
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainTab.Appearance = TabAppearance.FlatButtons
        MainTab.ItemSize = New Size(0, 1)
        MainTab.SizeMode = TabSizeMode.Fixed

        tabQuestionType.Appearance = TabAppearance.FlatButtons
        tabQuestionType.ItemSize = New Size(0, 1)
        tabQuestionType.SizeMode = TabSizeMode.Fixed

        tabMarkSchemeType.Appearance = TabAppearance.FlatButtons
        tabMarkSchemeType.ItemSize = New Size(0, 1)
        tabMarkSchemeType.SizeMode = TabSizeMode.Fixed

        For Each tab As TabPage In MainTab.TabPages
            tab.Text = ""
        Next

        Dim directory As New IO.DirectoryInfo(IO.Directory.GetCurrentDirectory())
        Dim folders = directory.GetDirectories()
        For Each folder In folders
            If folder.Name <> "ExamStyles" Then assessments.Add(folder.Name, New assessment(folder.Name, folderStructure, True))
        Next

    End Sub

    Private Sub btnAddQuestion_Click(sender As Object, e As EventArgs) Handles btnAddQuestion.Click
        assessments(getSelectedAssessment()).addNewQuestion(Nothing, Nothing, nudMarks.Minimum, getSelectedPath())
        updateQuestionsGUI()
    End Sub

    Private Sub listboxQuestions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listboxQuestions.SelectedIndexChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        tbxQuestion.Text = CType(listboxQuestions.SelectedItem, question).question
        tbxMarkScheme.Text = CType(listboxQuestions.SelectedItem, question).markScheme
        nudMarks.Value = CType(listboxQuestions.SelectedItem, question).marks
        listResources.Items.Clear()
        listIncludedResources.Items.Clear()
        For Each resource In assessments(getSelectedAssessment()).resources
            listResources.Items.Add(resource.Value)
        Next
        If getSelectedAssessment() <> Nothing Then
            For Each resource In assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).resources
                listIncludedResources.Items.Add(resource)
            Next
        End If
        lbxTags.Items.Clear()
        For Each tagName In assessments(getSelectedAssessment()).tags
            Dim checked As Boolean = False
            If listboxQuestions.SelectedIndex <> -1 Then
                If assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).tags.Contains(tagName) Then
                    checked = True
                End If
            End If
            lbxTags.Items.Add(tagName, checked)
        Next
        TextBox1.Text = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).title
        cbxLinePage.SelectedItem = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).lineOrPage
        nudSpace.Value = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).linepagecount
        cbxQuestionType.SelectedItem = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).questionType
        cbxMarksSchemeType.SelectedItem = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).markSchemeType
        If cbxQuestionType.SelectedItem = "Written" Then
            tabQuestionType.SelectedIndex = 0
        Else
            tabQuestionType.SelectedIndex = 1
        End If
        If cbxMarksSchemeType.SelectedItem = "Written" Then
            tabMarkSchemeType.SelectedIndex = 0
        Else
            tabMarkSchemeType.SelectedIndex = 1
        End If
        If assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).questionImageLocation <> Nothing Then
            picQuestion.ImageLocation = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).questionImageLocation
        End If
        If assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).markSchemeImageLocation <> Nothing Then
            picMarkScheme.ImageLocation = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).markSchemeImageLocation
        End If
    End Sub

    Private Sub nudMarks_ValueChanged(sender As Object, e As EventArgs) Handles nudMarks.ValueChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).marks = nudMarks.Value
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        For Each key As String In assessments.Keys
            assessments(key).save()
        Next
    End Sub

    Private Sub addResourceButton_Click(sender As Object, e As EventArgs) Handles addResourceButton.Click
        If openFileResource.ShowDialog() = DialogResult.OK Then
            assessments(getSelectedAssessment()).addNewResource(openFileResource.FileName, getSelectedPath())
            updateResourcesGUI()
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles trackZoom.Scroll
        updateResourcesGUI()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If MainTab.SelectedIndex = stages.resources Then updateResourcesGUI()
    End Sub

    Private Sub btnResourceAdd_Click(sender As Object, e As EventArgs) Handles btnResourceAdd.Click
        If listResources.SelectedIndex <> -1 Then
            If getSelectedAssessment() Is Nothing Then Exit Sub
            listIncludedResources.Items.Add(listResources.SelectedItem)
            assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).resources.Add(listResources.SelectedItem)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        assessments(getSelectedAssessment()).tags.Add(InputBox("New Tag Name:"))
        updateOverviewGUI()
    End Sub

    Private Sub lbxTags_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lbxTags.ItemCheck
        If Not lbxTags.CheckedIndices.Contains(lbxTags.SelectedIndex) Then
            assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).tags.Add(lbxTags.SelectedItem)
        Else
            assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).tags.Remove(lbxTags.SelectedItem)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).title = TextBox1.Text
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Dim selectedIndex As Integer = listboxQuestions.SelectedIndex
        Dim assessmentName As String = getSelectedAssessment()
        listboxQuestions.Items.Clear()
        For Each questionID In assessments(assessmentName).questions.Keys
            If assessments(assessmentName).questions(questionID).path = getSelectedPath() Then listboxQuestions.Items.Add(assessments(assessmentName).questions(questionID))
        Next
        listboxQuestions.SelectedIndex = selectedIndex
    End Sub

    Private Sub nudSpace_ValueChanged(sender As Object, e As EventArgs) Handles nudSpace.ValueChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).linepagecount = nudSpace.Value
    End Sub

    Private Sub cbxLinePage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxLinePage.SelectedIndexChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).lineOrPage = cbxLinePage.SelectedItem
    End Sub

    Private Sub cbxQuestionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxQuestionType.SelectedIndexChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).questionType = cbxQuestionType.SelectedItem
        If cbxQuestionType.SelectedItem = "Written" Then
            tabQuestionType.SelectedIndex = 0
        Else
            tabQuestionType.SelectedIndex = 1
        End If
    End Sub

    Private Sub cbxMarksSchemeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMarksSchemeType.SelectedIndexChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).markSchemeType = cbxMarksSchemeType.SelectedItem
        If cbxMarksSchemeType.SelectedItem = "Written" Then
            tabMarkSchemeType.SelectedIndex = 0
        Else
            tabMarkSchemeType.SelectedIndex = 1
        End If
    End Sub

    Private Sub btnLoadQuestionImage_Click(sender As Object, e As EventArgs) Handles btnLoadQuestionImage.Click
        If openFileImage.ShowDialog() = DialogResult.OK Then
            assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).questionImageLocation = openFileImage.FileName
            picQuestion.ImageLocation = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).questionImageLocation
        End If
    End Sub

    Private Sub btnLoadMarkSchemeImage_Click(sender As Object, e As EventArgs) Handles btnLoadMarkSchemeImage.Click
        If openFileImage.ShowDialog() = DialogResult.OK Then
            assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).markSchemeImageLocation = openFileImage.FileName
            picMarkScheme.ImageLocation = assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).markSchemeImageLocation
        End If
    End Sub

    Private Sub btnScreenshotImageQuestion_Click(sender As Object, e As EventArgs) Handles btnScreenshotImageQuestion.Click
        screenshot.isquestion = True
        screenshot.takeScreenshot()
    End Sub

    Private Sub btnMarkSchemeScreenshot_Click(sender As Object, e As EventArgs) Handles btnMarkSchemeScreenshot.Click
        screenshot.isquestion = False
        screenshot.takeScreenshot()
    End Sub

    Private Sub tbxQuestion_TextChanged_1(sender As Object, e As EventArgs) Handles tbxQuestion.TextChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).question = tbxQuestion.Text
    End Sub

    Private Sub tbxMarkScheme_TextChanged_1(sender As Object, e As EventArgs) Handles tbxMarkScheme.TextChanged
        If getSelectedAssessment() Is Nothing Then Exit Sub
        assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).markScheme = tbxMarkScheme.Text
    End Sub

    Private Sub buttonDeleteFolder_Click(sender As Object, e As EventArgs) Handles buttonDeleteFolder.Click
        Dim path As String = getSelectedPath()
        If Not folderStructure.SelectedNode Is Nothing Then
            If folderStructure.SelectedNode.Parent Is Nothing Then
                If MsgBox("Are you sure you want to delete " + folderStructure.SelectedNode.Text + "?", MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                    assessments.Remove(folderStructure.SelectedNode.Text)
                    folderStructure.Nodes.Remove(folderStructure.SelectedNode)
                    IO.Directory.Delete(path, True)
                End If
            ElseIf folderStructure.SelectedNode.Parent.Text = getSelectedAssessment() Then
                MsgBox("Cannot delete this folder!")
            Else
                If MsgBox("Are you sure you want to delete " + folderStructure.SelectedNode.Text + "?", MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                    Dim assessment As String = getSelectedAssessment()
                    assessments(assessment).save()
                    folderStructure.Nodes.Remove(folderStructure.Nodes.Find(assessment, False)(0))
                    IO.Directory.Delete(path, True)
                    assessments.Remove(assessment)
                    assessments.Add(assessment, New assessment(assessment, folderStructure, True))
                End If
            End If
        Else
            MsgBox("Please select and assessment or folder")
        End If
    End Sub

    Private Sub btnRemoveTag_Click(sender As Object, e As EventArgs) Handles btnRemoveTag.Click
        Dim tagToRemove As String = lbxTagOverview.SelectedItem
        For Each key As String In assessments(getSelectedAssessment()).questions.Keys
            If assessments(getSelectedAssessment()).questions(key).tags.Contains(tagToRemove) Then assessments(getSelectedAssessment()).questions(key).tags.Remove(tagToRemove)
        Next
        assessments(getSelectedAssessment()).tags.Remove(tagToRemove)
        updateOverviewGUI()
    End Sub

    Private Sub btnRemoveQuestion_Click(sender As Object, e As EventArgs) Handles btnRemoveQuestion.Click
        IO.File.Delete(getSelectedPath() + CType(listboxQuestions.SelectedItem, question).ID.ToString() + ".txt")
        assessments(getSelectedAssessment()).questions.Remove(CType(listboxQuestions.SelectedItem, question).ID)
        updateQuestionsGUI()
    End Sub

    Private Sub btnResourceRemove_Click(sender As Object, e As EventArgs) Handles btnResourceRemove.Click
        If listIncludedResources.SelectedIndex <> -1 Then
            assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).resources.Remove(listIncludedResources.SelectedItem)
            listIncludedResources.Items.Remove(listIncludedResources.SelectedItem)
        End If
    End Sub

    Private Sub btnAddNewTag_Click(sender As Object, e As EventArgs) Handles btnAddNewTag.Click
        Dim name As String = InputBox("Name of New Tag:")
        If name <> Nothing Then
            assessments(getSelectedAssessment()).tags.Add(name)
            updateQuestionsGUI()
            For i = 0 To lbxTags.Items.Count - 1
                If lbxTags.Items(i) = name Then
                    lbxTags.SetItemChecked(i, True)
                    assessments(getSelectedAssessment()).questions(listboxQuestions.SelectedItem.ID).tags.Add(lbxTags.Items(i))
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnRemoveTag2_Click(sender As Object, e As EventArgs) Handles btnRemoveTag2.Click
        Dim tagToRemove As String = lbxTags.SelectedItem
        For Each key As String In assessments(getSelectedAssessment()).questions.Keys
            If assessments(getSelectedAssessment()).questions(key).tags.Contains(tagToRemove) Then assessments(getSelectedAssessment()).questions(key).tags.Remove(tagToRemove)
        Next
        assessments(getSelectedAssessment()).tags.Remove(tagToRemove)
        updateQuestionsGUI()
    End Sub

    Private Sub btnPreviewQuestion_Click(sender As Object, e As EventArgs) Handles btnPreviewQuestion.Click
        If listboxQuestions.SelectedIndex <> -1 Then
            imagePopup.showForm(CType(listboxQuestions.SelectedItem, question).renderQuestion())
        End If
    End Sub

    Private Sub buttonAddPublication_Click(sender As Object, e As EventArgs) Handles buttonAddPublication.Click
        Publisher.assessment = assessments(getSelectedAssessment())
        Publisher.Show()
    End Sub

    Private Sub listPublications_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listPublications.SelectedIndexChanged
        listTests.Items.Clear()
        For Each kvp As KeyValuePair(Of Integer, test) In CType(listPublications.SelectedItem, publication).tests
            Dim test As test = kvp.Value
            listTests.Items.Add(test)
        Next
    End Sub

    Private Sub btnTestsGen_Click(sender As Object, e As EventArgs) Handles btnTestsGen.Click
        assessments(getSelectedAssessment()).publications(CType(listPublications.SelectedItem, publication).ID).generateTest(assessments(getSelectedAssessment()).questions)
        GC.Collect()
    End Sub

    Private Sub btnMarkTest_Click(sender As Object, e As EventArgs) Handles btnMarkTest.Click
        Marker.showForm(listTests.SelectedItem, assessments(getSelectedAssessment()).questions)
    End Sub

    Private Sub btnPrintTest_Click(sender As Object, e As EventArgs) Handles btnPrintTest.Click
        testViewer.showForm(CType(listPublications.SelectedItem, publication).tests(CType(listTests.SelectedItem, test).ID))
    End Sub
End Class

Public Enum paperRatio
    A = 16
End Enum

Public Class assessment
    Public name As String
    Public questions As New Dictionary(Of Integer, question)
    Public resources As New Dictionary(Of Integer, resource)
    Public tags As New List(Of String)
    Public publications As New Dictionary(Of Integer, publication)
    'Public results As New Dictionary(Of Integer, question)

    Shared listOfAssessmentNames As New List(Of String)

    Sub New(name As String, ByRef folderStructure As TreeView)
        If Not listOfAssessmentNames.Contains(name) Then
            Me.name = name
            listOfAssessmentNames.Add(name)

            folderStructure.Nodes.Add(name, name, 0)

            Dim counter = 0
            For Each node As TreeNode In folderStructure.Nodes
                If node.Text = name Then Exit For
                counter += 1
            Next
            folderStructure.Nodes(counter).Nodes.Add("Questions", "Questions", 2)
            folderStructure.Nodes(counter).Nodes.Add("Resources", "Resources", 2)
            folderStructure.Nodes(counter).Nodes.Add("Publications", "Publications", 1)
            folderStructure.Nodes(counter).Nodes.Add("Results", "Results", 3)

            IO.Directory.CreateDirectory(name)
            IO.Directory.CreateDirectory(name + "/questions")
            IO.Directory.CreateDirectory(name + "/publications")
            IO.Directory.CreateDirectory(name + "/results")
            IO.Directory.CreateDirectory(name + "/resources")
        Else
            Throw New Exception("Assessment already exists")
        End If
    End Sub

    Sub New(filepath As String, ByRef folderStructure As TreeView, fromFile As Boolean)
        name = filepath
        listOfAssessmentNames.Add(name)

        folderStructure.Nodes.Add(name, name, 0)

        Dim counter = 0
        For Each node As TreeNode In folderStructure.Nodes
            If node.Text = name Then Exit For
            counter += 1
        Next
        folderStructure.Nodes(counter).Nodes.Add("Questions", "Questions", 2)
        addFolders({New IO.DirectoryInfo(filepath + "\Questions")}, folderStructure)
        folderStructure.Nodes(counter).Nodes.Add("Resources", "Resources", 2)
        addFolders({New IO.DirectoryInfo(filepath + "\Resources")}, folderStructure)
        folderStructure.Nodes(counter).Nodes.Add("Publications", "Publications", 1)
        folderStructure.Nodes(counter).Nodes.Add("Results", "Results", 3)

        parseResources({New IO.DirectoryInfo(filepath + "\Resources")})
        parseQuestions({New IO.DirectoryInfo(filepath + "\Questions")})
        parsePublications(filepath + "\Publications")
        parseInfo()

    End Sub

    Private Sub _save()
        Dim file As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(name + "/info.txt", False)
        Dim tagString As String = ""
        For Each tag In tags
            tagString += tag.ToString + ","
        Next
        If tagString.Length > 0 Then tagString = Mid(tagString, 1, tagString.Length - 1)
        file.WriteLine(tagString)
        file.Close()
    End Sub

    Public Sub addNewQuestion(question, markScheme, marks, path)
        Dim counter As Integer = 0
        While questions.ContainsKey(counter)
            counter += 1
        End While
        Dim newQuestion As New question(question, markScheme, marks, path, counter)
        For Each subpath In path.split("\")
            If tags.Contains(subpath) Then newQuestion.tags.Add(subpath)
        Next
        questions.Add(newQuestion.ID, newQuestion)
    End Sub

    Public Sub addNewResource(location, path)
        Dim counter As Integer = 0
        While resources.ContainsKey(counter)
            counter += 1
        End While
        Dim newResource As New resource(location, path, counter)
        resources.Add(newResource.ID, newResource)
    End Sub

    Public Sub addNewPublication(style As Bitmap, minMarks As Integer, maxMarks As Integer, tags As List(Of String), includeuntagged As Boolean, questionCount As Integer, path As String, randomised As Boolean, pubName As String)
        Dim counter As Integer = 0
        While publications.ContainsKey(counter)
            counter += 1
        End While
        Dim newPublication As New publication(counter, style, minMarks, maxMarks, tags, includeuntagged, questionCount, randomised, Me.name + "\Publications\", pubName)
        publications.Add(newPublication.ID, newPublication)
    End Sub

    Public Sub addNewResult(ByRef test As test, scores As Dictionary(Of Integer, Integer))
        Dim counter As Integer = 0
        While test.results.ContainsKey(counter)
            counter += 1
        End While
        Dim newResult As New result(counter, scores)
        test.results.Add(newResult.ID, newResult)
    End Sub

    Private Sub addFolders(paths As IO.DirectoryInfo(), ByRef folderStructure As TreeView)
        For Each path In paths
            Dim nodeToAddTo As TreeNode
            For Each folder In IO.Directory.GetDirectories(path.ToString)
                nodeToAddTo = folderStructure.Nodes.Find(path.ToString().Split("\")(0), True)(0)
                For Each nodeLevel In path.ToString().Split("\").Skip(1)
                    Dim a = nodeToAddTo.Nodes.Find(nodeLevel, True)
                    nodeToAddTo = nodeToAddTo.Nodes.Find(nodeLevel, True)(0)
                Next
                nodeToAddTo.Nodes.Add(folder.Split("\").Last, folder.Split("\").Last)
            Next
            Dim nextDirectory As New IO.DirectoryInfo(path.ToString)
            Dim directories = nextDirectory.GetDirectories()
            For i = 0 To directories.Length - 1
                directories(i) = New IO.DirectoryInfo(path.ToString + "\" + directories(i).ToString)
            Next
            addFolders(directories, folderStructure)
        Next
    End Sub

    Private Sub parseQuestions(paths As IO.DirectoryInfo())
        For Each path In paths
            For Each file In IO.Directory.GetFiles(path.ToString)
                Dim newQuestion As New question(file, resources)
                questions.Add(newQuestion.ID, newQuestion)
            Next
            Dim nextDirectory As New IO.DirectoryInfo(path.ToString)
            Dim directories = nextDirectory.GetDirectories()
            For i = 0 To directories.Length - 1
                directories(i) = New IO.DirectoryInfo(path.ToString + "\" + directories(i).ToString)
            Next
            parseQuestions(directories)
        Next
    End Sub

    Private Sub parseResources(paths As IO.DirectoryInfo())
        For Each path In paths
            For Each file In IO.Directory.GetFiles(path.ToString)
                Dim newResource As New resource(file)
                resources.Add(newResource.ID, newResource)
            Next
            Dim nextDirectory As New IO.DirectoryInfo(path.ToString)
            Dim directories = nextDirectory.GetDirectories()
            For i = 0 To directories.Length - 1
                directories(i) = New IO.DirectoryInfo(path.ToString + "\" + directories(i).ToString)
            Next
            parseResources(directories)
        Next
    End Sub

    Private Sub parsePublications(path As String)
        For Each directory In IO.Directory.GetDirectories(path.ToString)
            Dim newPublications As New publication(directory)
            publications.Add(newPublications.ID, newPublications)
        Next
    End Sub

    Private Sub parseInfo()
        Dim fileReader As IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(name + "/info.txt")
        Dim lines() As String = fileReader.ReadToEnd().Split("¬")
        For Each tag In lines(0).Split(",")
            If tag <> "" Then Me.tags.Add(tag.Trim({Chr(13), Chr(10)}))
        Next
        fileReader.Close()
    End Sub

    Public Sub save()
        For Each key In questions.Keys
            questions(key).save()
        Next
        For Each publication In publications
            publication.Value.save()
        Next
        Me._save()
    End Sub

End Class

Public Class question
    Public question As String
    Public markScheme As String
    Public marks As Integer
    Public path As String
    Public ID As Integer
    Public resources As New List(Of resource)
    Public tags As New List(Of String)
    Public title As String
    Public lineOrPage As String
    Public linepagecount As Integer
    Public questionType As String
    Public markSchemeType As String
    Public questionImageLocation As String
    Public markSchemeImageLocation As String

    Sub New(question, markScheme, marks, path, ID)
        Me.question = question
        Me.markScheme = markScheme
        Me.marks = marks
        Me.path = path
        Me.ID = ID
        Me.title = "New Question in " + path
        Me.lineOrPage = "Lines"
        Me.linepagecount = marks
        Me.questionType = "Written"
        Me.markSchemeType = "Written"
        Me.questionImageLocation = Nothing
        Me.markSchemeImageLocation = Nothing
    End Sub

    Sub New(filepath As String, resources As Dictionary(Of Integer, resource))
        Dim fileReader As IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(filepath)
        Dim lines() As String = fileReader.ReadToEnd().Split("¬")
        question = lines(0)
        markScheme = lines(1)
        marks = Int(lines(2))
        For Each resourceID In lines(3).Split(",")
            If IsNumeric(resourceID) Then Me.resources.Add(resources(Int(resourceID)))
        Next
        For Each tag In lines(4).Split(",")
            tag = tag.Trim({Chr(13), Chr(10)})
            If tag <> "" Then Me.tags.Add(tag)
        Next
        title = lines(5).Trim({Chr(13), Chr(10)})
        lineOrPage = lines(6).Trim({Chr(13), Chr(10)})
        linepagecount = Int(lines(7))
        questionType = lines(8).Trim({Chr(13), Chr(10)})
        markSchemeType = lines(9).Trim({Chr(13), Chr(10)})
        questionImageLocation = lines(10).Trim({Chr(13), Chr(10)})
        markSchemeImageLocation = lines(11).Trim({Chr(13), Chr(10)})
        path = Mid(filepath, 1, filepath.LastIndexOf("\") + 1)
        Me.ID = Mid(filepath.Split("\").Last, 1, filepath.Split("\").Last.IndexOf("."))
        fileReader.Close()
    End Sub

    Public Overrides Function ToString() As String
        If Me.title <> Nothing Then
            Return Me.title
        Else
            Return "Untitled Question"
        End If
    End Function

    Sub save()
        Dim file As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(path + ID.ToString() + ".txt", False)
        file.Write(question + "¬" + markScheme + "¬" + marks.ToString() + "¬")
        Dim resourceString As String = ""
        For Each resource In resources
            resourceString += resource.ID.ToString + ","
        Next
        If resourceString.Length > 0 Then resourceString = Mid(resourceString, 1, resourceString.Length - 1)
        file.Write(resourceString + "¬")
        Dim tagString As String = ""
        For Each tag In tags
            tagString += tag + ","
        Next
        If tagString.Length > 0 Then tagString = Mid(tagString, 1, tagString.Length - 1)
        file.Write(tagString + "¬")
        file.WriteLine(title + "¬" + lineOrPage + "¬" + linepagecount.ToString() + "¬" + questionType + "¬" + markSchemeType + "¬" + questionImageLocation + "¬" + markSchemeImageLocation)
        file.Close()
    End Sub

    Function renderQuestion(Optional questionNumber As Integer = 0, Optional format As format = Nothing, Optional papersize As paperRatio = paperRatio.A)

        If format Is Nothing Then format = New format()

        Dim resultList As New List(Of Bitmap)

        Dim result As New Bitmap(1000, CType(100 * papersize, Integer))
        Dim position As Point
        Dim graphics As Graphics
        graphics = Graphics.FromImage(result)
        graphics.Clear(Color.White)

        Dim boldFont As New Font(format.font, FontStyle.Bold)
        Dim boldItalicFont As New Font(boldFont, FontStyle.Italic)

        TextRenderer.DrawText(graphics, questionNumber.ToString() + ".", boldFont, New Point(0, 0), format.fontColour)
        Dim questionNumberPosition As New Rectangle(New Point(0, 0), TextRenderer.MeasureText(questionNumber.ToString() + ".", boldFont))

        Dim textPadding As Integer = 5
        Dim questionPosition As New Rectangle(New Point(questionNumberPosition.Width + textPadding, 0), New Size(result.Width - (questionNumberPosition.Width + textPadding + textPadding), result.Height))

        If questionType = "Written" Then
            Dim counter = question.Length
            Dim workingString As String = question
            Dim lines As New List(Of String)
            Dim addString As String = workingString
            Dim width As Integer = 0
            Dim cutString As Boolean = False
            Do Until workingString.Length = 0
                addString = workingString
                width = TextRenderer.MeasureText(addString, format.font).Width
                While width > questionPosition.Width
                    cutString = True
                    counter += -1
                    addString = Mid(workingString, 1, counter)
                    width = TextRenderer.MeasureText(addString, format.font).Width
                End While
                If addString.LastIndexOf(" ") <> -1 And cutString Then
                    counter = addString.LastIndexOf(" ")
                    addString = Mid(workingString, 1, counter)
                End If
                lines.Add(addString)
                workingString = Mid(workingString, counter + 1)
                counter = workingString.Length
                cutString = False
            Loop
            position = New Point(questionNumberPosition.Width + textPadding, 0)
            For Each line In lines
                TextRenderer.DrawText(graphics, line, format.font, position, format.fontColour)
                position.Y += TextRenderer.MeasureText(line, format.font).Height
            Next
            questionPosition.Height = position.Y
        Else
            Dim questionImage As New Bitmap(questionImageLocation)
            Dim resultQuestionImage As Bitmap
            'If questionImage.Width > questionPosition.Width Or questionImage.Width < questionPosition.Width * 0.4 Then
            Dim scalefactor As Double = questionPosition.Width / questionImage.Width
                resultQuestionImage = New Bitmap(questionImage, questionImage.Width * scalefactor, questionImage.Height * scalefactor)
            'End If
            If questionImage.Height > questionPosition.Height Then
                scalefactor = questionPosition.Height / questionImage.Height
                resultQuestionImage = New Bitmap(questionImage, questionImage.Width * scalefactor, questionImage.Height * scalefactor)
            End If
            graphics.DrawImage(resultQuestionImage, questionPosition.Location)
            questionPosition.Height = resultQuestionImage.Height
        End If
        For Each resource In resources
            Dim resourceScaled As New Bitmap(resource.image)
            If resourceScaled.Width < result.Width * 0.5 Then
                Dim scaleFactor As Double = (result.Width * 0.5) / resourceScaled.Width
                resourceScaled = New Bitmap(resourceScaled, resourceScaled.Width * scaleFactor, resourceScaled.Height * scaleFactor)
            ElseIf resourceScaled.Width > result.Width Then
                Dim scaleFactor As Double = result.Width / resourceScaled.Width
                resourceScaled = New Bitmap(resourceScaled, resourceScaled.Width * scaleFactor, resourceScaled.Height * scaleFactor)
            End If
            position = New Point((result.Width - resourceScaled.Width) / 2, questionPosition.Bottom)
            graphics.DrawImage(resourceScaled, position)
            questionPosition.Height += resourceScaled.Height
        Next

        If questionType = "Written" Then
            Dim Size As Size = TextRenderer.MeasureText("(" + marks.ToString + ")", boldItalicFont)
            position = New Point(result.Width - Size.Width, questionPosition.Bottom - Size.Height)
            TextRenderer.DrawText(graphics, "(" + marks.ToString + ")", boldItalicFont, position, format.fontColour)
        End If

        Dim questionanswerpadding As Integer = 10
        Dim lineSpacing As Integer = 50
        Dim answerPosition As New Rectangle(New Point(0, questionPosition.Y + questionPosition.Height + questionanswerpadding + lineSpacing), New Size(result.Width, 0))

        If lineOrPage = "Lines" Then
            For counter = 1 To linepagecount
                graphics.DrawLine(New Pen(Color.Black), New Point(answerPosition.X, answerPosition.Y + answerPosition.Height), New Point(answerPosition.Width, answerPosition.Y + answerPosition.Height))
                If answerPosition.Y + answerPosition.Height + lineSpacing < result.Height Then
                    answerPosition.Height += lineSpacing
                Else
                    resultList.Add(New Bitmap(result))
                    graphics.Clear(Color.White)
                    TextRenderer.DrawText(graphics, "Question " + questionNumber.ToString() + " continued", format.font, New Point(0, 0), format.fontColour)
                    answerPosition.Height = 0
                    answerPosition.Y = TextRenderer.MeasureText("Question " + questionNumber.ToString() + " continued", format.font).Height + questionanswerpadding + lineSpacing
                End If
            Next
            Dim old As New Bitmap(result)
            result = New Bitmap(result.Width, answerPosition.Y + answerPosition.Height + 1)
            graphics = Graphics.FromImage(result)
            graphics.DrawImage(old, New Point(0, 0))
        Else
            Dim newPageCount As Integer = 0
            Do
                graphics.DrawLine(New Pen(Color.Black), New Point(answerPosition.X, answerPosition.Y + answerPosition.Height), New Point(answerPosition.Width, answerPosition.Y + answerPosition.Height))
                If answerPosition.Y + answerPosition.Height + lineSpacing < result.Height Then
                    answerPosition.Height += lineSpacing
                Else
                    If newPageCount + 2 > linepagecount Then Exit Do
                    resultList.Add(New Bitmap(result))
                    graphics.Clear(Color.White)
                    TextRenderer.DrawText(graphics, "Question " + questionNumber.ToString() + " continued", format.font, New Point(0, 0), format.fontColour)
                    answerPosition.Height = 0
                    answerPosition.Y = TextRenderer.MeasureText("Question " + questionNumber.ToString() + " continued", format.font).Height + questionanswerpadding + lineSpacing
                    newPageCount += 1
                End If
            Loop
            Dim old As New Bitmap(result)
            result = New Bitmap(result.Width, answerPosition.Y + answerPosition.Height + 1)
            graphics = Graphics.FromImage(result)
            graphics.DrawImage(old, New Point(0, 0))
        End If

        resultList.Add(result)
        Return resultList
    End Function

End Class

Public Class resource
    Public image As Bitmap
    Public path As String
    Public ID As Integer
    Public name As String

    Sub New(location As String, path As String, ID As Integer)
        Me.image = New Bitmap(location)
        Me.path = path
        Me.ID = ID
        name = Mid(location.Split("\").Last, 1, location.Split("\").Last.IndexOf("."))
        Me.image.Save(path + ID.ToString() + "¬" + name + ".png")
    End Sub

    Sub New(filepath As String)
        image = New Bitmap(filepath)
        path = Mid(filepath, 1, filepath.LastIndexOf("\") + 1)
        Dim info() As String = Mid(filepath, filepath.LastIndexOf("\") + 2).Split("¬")
        ID = info(0)
        name = Mid(info(1), 1, info(1).LastIndexOf("."))
    End Sub

    Public Overrides Function ToString() As String
        Return name
    End Function

End Class

Public Class publication
    Public ID As Integer
    Public style As Bitmap
    Public minMarks As Integer
    Public maxMarks As Integer
    Public includeUntagged As Boolean
    Public tags As New List(Of String)
    Public questionCount As Integer
    Public randomised As Boolean
    Public path As String
    Public name As String

    Public tests As New Dictionary(Of Integer, test)

    Sub New(ID As Integer, style As Bitmap, minMarks As Integer, maxMarks As Integer, tags As List(Of String), includeuntagged As Boolean, questionCount As Integer, randomised As Boolean, path As String, name As String)
        Me.ID = ID
        Me.style = style
        Me.minMarks = minMarks
        Me.maxMarks = maxMarks
        Me.tags = tags
        Me.includeUntagged = includeuntagged
        Me.questionCount = questionCount
        Me.randomised = randomised
        Me.path = path + ID.ToString()
        Me.name = name
        IO.Directory.CreateDirectory(path + ID.ToString())
        save()
    End Sub

    Sub New(path As String)
        Me.path = path
        Me.ID = path.Split("\").Last
        For Each directory In IO.Directory.GetDirectories(path)
            Dim newTest As New test(directory)
            tests.Add(newTest.ID, newTest)
        Next

        Dim fileReader As IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(path + "\info.txt")
        Dim lines() As String = fileReader.ReadToEnd().Split("¬")
        Me.minMarks = lines(0).Trim({Chr(13), Chr(10)})
        Me.maxMarks = lines(1).Trim({Chr(13), Chr(10)})
        For Each tagName In lines(2).Split(",")
            Me.tags.Add(tagName)
        Next
        Me.includeUntagged = CType(lines(3).Trim({Chr(13), Chr(10)}), Boolean)
        Me.questionCount = lines(4).Trim({Chr(13), Chr(10)})
        Me.randomised = CType(lines(5).Trim({Chr(13), Chr(10)}), Boolean)
        Me.name = lines(6).Trim({Chr(13), Chr(10)})
        fileReader.Close()

        Me.style = New Bitmap(path + "\¬style.png")
    End Sub

    Sub save()
        If Not IO.File.Exists(path + "\¬style.png") Then style.Save(path + "\¬style.png")
        Dim file As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(path + "\info.txt", False)
        file.Write(minMarks.ToString() + "¬" + maxMarks.ToString() + "¬")
        Dim tagString As String = ""
        For Each tagName In tags
            tagString += tagName + ","
        Next
        If tagString.Length > 0 Then tagString = Mid(tagString, 1, tagString.Length - 1)
        file.Write(tagString + "¬")
        file.WriteLine(includeUntagged.ToString + "¬" + questionCount.ToString + "¬" + randomised.ToString() + "¬" + name)
        file.Close()
        For Each test In tests
            test.Value.save(path)
        Next
    End Sub

    Public Sub generateTest(completeQuestions As Dictionary(Of Integer, question))
        'Collect Questions
        Dim questionsToUse As Dictionary(Of Integer, question) = getQuestions(completeQuestions)

        'Pack Questions
        Dim singlePageQuestionHeights As New Dictionary(Of String, Integer)
        Dim multiPageQuestionHeights As New Dictionary(Of String, Integer)
        For Each questionKey In questionsToUse.Keys
            Dim question As question = questionsToUse(questionKey)
            Dim render As List(Of Bitmap) = question.renderQuestion()
            If render.Count = 1 Then
                singlePageQuestionHeights.Add(questionKey, render(0).Height)
            Else
                multiPageQuestionHeights.Add(questionKey, render.Last.Height)
            End If
        Next

        Dim questionCollections As New List(Of questionCollection)
        If randomised Then
            For Each question In multiPageQuestionHeights
                Dim newCol As New questionCollection(100 * paperRatio.A, True)
                newCol.addItem(question)
                questionCollections.Add(newCol)
            Next
            Dim collected As Boolean = False
            For counter = 0 To singlePageQuestionHeights.Count - 1
                Dim question As KeyValuePair(Of String, Integer) = singlePageQuestionHeights.Single(Function(item) item.Key = maximum(singlePageQuestionHeights))
                collected = False
                For Each bin In questionCollections
                    If bin.canFit(question) Then
                        bin.addItem(question)
                        collected = True
                        Exit For
                    End If
                Next
                If Not collected Then
                    Dim newBin As New questionCollection(100 * paperRatio.A, False)
                    If newBin.canFit(question) Then
                        newBin.addItem(question)
                    End If
                    questionCollections.Add(newBin)
                End If
                singlePageQuestionHeights.Remove(question.Key)
            Next

            For Each collection In questionCollections
                collection.questions = jumble(collection.questions)
            Next
            questionCollections = jumble(questionCollections)
        Else
            Dim sortedQuestionKeys As List(Of Integer) = questionsToUse.Keys.ToList
            sortedQuestionKeys.Sort()
            For Each questionKey In sortedQuestionKeys
                If multiPageQuestionHeights.ContainsKey(questionKey) Then
                    Dim newBin As New questionCollection(100 * paperRatio.A, True)
                    If newBin.canFit(New KeyValuePair(Of String, Integer)(questionKey, multiPageQuestionHeights(questionKey))) Then
                        newBin.addItem(New KeyValuePair(Of String, Integer)(questionKey, multiPageQuestionHeights(questionKey)))
                    End If
                    questionCollections.Add(newBin)
                Else
                    If questionCollections.Count = 0 Then
                        Dim newBin As New questionCollection(100 * paperRatio.A, False)
                        If newBin.canFit(New KeyValuePair(Of String, Integer)(questionKey, singlePageQuestionHeights(questionKey))) Then
                            newBin.addItem(New KeyValuePair(Of String, Integer)(questionKey, singlePageQuestionHeights(questionKey)))
                        End If
                        questionCollections.Add(newBin)
                    Else
                        If questionCollections.Last.canFit(New KeyValuePair(Of String, Integer)(questionKey, singlePageQuestionHeights(questionKey))) Then
                            questionCollections(questionCollections.Count - 1).addItem(New KeyValuePair(Of String, Integer)(questionKey, singlePageQuestionHeights(questionKey)))
                        Else
                            Dim newBin As New questionCollection(100 * paperRatio.A, False)
                            If newBin.canFit(New KeyValuePair(Of String, Integer)(questionKey, singlePageQuestionHeights(questionKey))) Then
                                newBin.addItem(New KeyValuePair(Of String, Integer)(questionKey, singlePageQuestionHeights(questionKey)))
                            End If
                            questionCollections.Add(newBin)
                        End If
                    End If
                End If
            Next
        End If


        'Render Questions
        Dim pages As New List(Of Bitmap)
        Dim coverPage As New Bitmap("ExamStyles/Edexcel-Cover.png")
        pages.Add(New Bitmap(coverPage, coverPage.Width / 2, coverPage.Height / 2))
        coverPage.Dispose()
        Dim currentPage As Bitmap
        Dim graphics As Graphics
        Dim currentY As Integer = 0
        Dim skip As Integer = 0
        Dim questionCounter As Integer = 1
        For Each collection In questionCollections
            skip = 0
            If collection.containsFullPage = True Then
                skip = 1
                For Each page As Bitmap In completeQuestions(collection.questions(0)).renderQuestion(questionNumber:=questionCounter)
                    currentPage = New Bitmap(style)
                    graphics = Graphics.FromImage(currentPage)
                    graphics.DrawImage(page, New Point(262, 286))
                    pages.Add(New Bitmap(currentPage))
                Next
                questionCounter += 1
            End If
            currentY = 0
            currentPage = New Bitmap(style, style.Width / 2, style.Height / 2)
            Dim addedTo As Boolean = False
            For Each key In collection.questions.Skip(skip)
                addedTo = True
                graphics = Graphics.FromImage(currentPage)
                Dim render As Bitmap = completeQuestions(key).renderQuestion(questionNumber:=questionCounter)(0)
                questionCounter += 1
                graphics.DrawImage(render, New Point(262 / 2, (286 / 2) + currentY))
                currentY += render.Height
            Next
            If addedTo Then pages.Add(New Bitmap(currentPage))
        Next

        'Save Publication
        addNewTest(pages, questionsToUse.Keys.ToList)
        Form1.updatePublicationsGUI()
        graphics.Dispose()
        GC.Collect()
    End Sub

    Sub addNewTest(pages As List(Of Bitmap), questionsIDs As List(Of Integer))
        Dim counter As Integer = 0
        While tests.ContainsKey(counter)
            counter += 1
        End While

        IO.Directory.CreateDirectory(path + "\" + counter.ToString())
        IO.Directory.CreateDirectory(path + "\" + counter.ToString() + "\Results")
        Dim pagePaths As New List(Of String)
        Dim secondCounter As Integer = 0
        For Each page In pages
            page.Save(path + "\" + counter.ToString() + "\" + secondCounter.ToString() + ".png")
            pagePaths.Add(path + "\" + counter.ToString() + "\" + secondCounter.ToString() + ".png")
            secondCounter += 1
        Next

        Dim newTest As New test(counter, pagePaths, questionsIDs)
        tests.Add(newTest.ID, newTest)
    End Sub

    Function getQuestions(completeQuestions As Dictionary(Of Integer, question)) As Dictionary(Of Integer, question)
        Dim result As New Dictionary(Of Integer, question)
        For Each questionKey In completeQuestions.Keys
            Dim question As question = completeQuestions(questionKey)
            For Each tagName In Me.tags
                If question.tags.Contains(tagName) Then
                    If question.marks > minMarks And question.marks < maxMarks Then
                        result.Add(questionKey, question)
                    End If
                    Exit For
                End If
            Next
            If question.tags.Count = 0 And includeUntagged Then
                If question.marks > minMarks And question.marks < maxMarks Then
                    result.Add(questionKey, question)
                End If
            End If
        Next

        Dim finalResult As Dictionary(Of Integer, question) = result
        If result.Count > questionCount Then
            result = jumble(result)
            finalResult = New Dictionary(Of Integer, question)
            For counter = 0 To questionCount - 1
                finalResult.Add(result.Keys(counter), result(result.Keys(counter)))
            Next
            result = finalResult
        End If

        Return result
    End Function

    Function jumble(collection As Dictionary(Of Integer, question)) As Dictionary(Of Integer, question)
        Randomize()
        Dim result As New Dictionary(Of Integer, question)
        Do Until collection.Count = 0
            Dim random As Integer = Rnd() * (collection.Count - 1)
            Dim randomKey As String = collection.Keys(random)
            result.Add(randomKey, collection(randomKey))
            collection.Remove(randomKey)
        Loop
        Return result
    End Function

    Function jumble(collection As List(Of Integer)) As List(Of Integer)
        Randomize()
        Dim result As New List(Of Integer)
        Do Until collection.Count = 0
            Dim random As Integer = Rnd() * (collection.Count - 1)
            result.Add(collection(random))
            collection.RemoveAt(random)
        Loop
        Return result
    End Function

    Function jumble(collection As List(Of questionCollection)) As List(Of questionCollection)
        Randomize()
        Dim result As New List(Of questionCollection)
        Do Until collection.Count = 0
            Dim random As Integer = Rnd() * (collection.Count - 1)
            result.Add(collection(random))
            collection.RemoveAt(random)
        Loop
        Return result
    End Function

    Public Function maximum(ByVal list As Dictionary(Of String, Integer)) As String

        Dim max As New KeyValuePair(Of String, Integer)(list.Keys(0), list(list.Keys(0)))

        For Each keyValPair In list
            If keyValPair.Value > max.Value Then
                max = keyValPair
            End If
        Next

        Return max.Key

    End Function

    Overrides Function tostring() As String
        If Me.name <> Nothing Then
            Return Me.name
        Else
            Return "Untitled Publication"
        End If
    End Function

End Class

Public Class test
    Public ID As Integer
    Public pages As New List(Of String)
    Public name As String
    Public questionIDs As New List(Of Integer)
    Public results As New Dictionary(Of Integer, result)

    Sub New(ID As Integer, pages As List(Of String), questionIDs As List(Of Integer))
        Me.ID = ID
        Me.pages = pages
        Me.questionIDs = questionIDs
    End Sub

    Sub New(path As String)
        Me.ID = path.Split("\").Last
        For Each file In IO.Directory.GetFiles(path)
            If file.Split("\").Last <> "info.txt" Then pages.Add(file)
        Next
        For Each file In IO.Directory.GetFiles(path + "\results")
            Dim newResult As New result(file)
            results.Add(newResult.ID, newResult)
        Next
        Dim fileReader As IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(path + "\info.txt")
        Dim lines() As String = fileReader.ReadToEnd().Split("¬")
        For Each q In lines(0).Split(",")
            Me.questionIDs.Add(Int(q))
        Next
        fileReader.Close()
    End Sub

    Sub save(path)
        Dim file As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(path + "\" + ID.ToString() + "\info.txt", False)
        Dim qString As String = ""
        For Each questionID In questionIDs
            qString += questionID.ToString() + ","
        Next
        If qString.Length > 0 Then qString = Mid(qString, 1, qString.Length - 1)
        file.WriteLine(qString + "¬")
        file.Close()
        For Each result In results
            result.Value.save(path + "\" + ID.ToString() + "\results")
        Next
    End Sub

End Class

Public Class result
    Public ID As Integer
    Public scores As New Dictionary(Of Integer, Integer)

    Sub New(ID As Integer, scores As Dictionary(Of Integer, Integer))
        Me.ID = ID
        Me.scores = scores
    End Sub

    Sub New(path As String)
        Me.ID = Mid(path.Split("\").Last, 1, path.Split("\").Last.IndexOf("."))
        Dim fileReader As IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(path)
        Dim lines() As String = fileReader.ReadToEnd().Split(",")
        For Each score In lines
            Me.scores.Add(score.Split("¬")(0).Trim({Chr(13), Chr(10)}), score.Split("¬")(1).Trim({Chr(13), Chr(10)}))
        Next
        fileReader.Close()
    End Sub

    Sub save(path)
        Dim file As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(path + "\" + ID.ToString() + ".txt", False)
        Dim scoreString As String = ""
        For Each score In scores
            scoreString += score.Key.ToString() + "¬" + score.Value.ToString() + ","
        Next
        If scoreString.Length > 0 Then scoreString = Mid(scoreString, 1, scoreString.Length - 1)
        file.WriteLine(scoreString)
        file.Close()
    End Sub

End Class

Public Class format
    Public font As Font
    Public fontColour As Color

    Sub New()
        font = New Font("Microsoft Sans Serif", 15)
        fontColour = Color.Black
    End Sub
End Class