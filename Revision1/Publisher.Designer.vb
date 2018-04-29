<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Publisher
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.mainTab = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textboxName = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.listStyles = New System.Windows.Forms.ListBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.checkIncludeUntagged = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnDeselectAllExclude = New System.Windows.Forms.Button()
        Me.btnSelectAllExclude = New System.Windows.Forms.Button()
        Me.listTags = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.listTagsExcluded = New System.Windows.Forms.CheckedListBox()
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnDeselectAllInclude = New System.Windows.Forms.Button()
        Me.btnSelectAllInclude = New System.Windows.Forms.Button()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.nudMaxMark = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudMinMark = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.checkRandom = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.nudQuestionCount = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.buttonNext = New System.Windows.Forms.Button()
        Me.buttonFinish = New System.Windows.Forms.Button()
        Me.buttonPrevious = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.mainTab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel13.SuspendLayout()
        Me.TableLayoutPanel12.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        CType(Me.nudMaxMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinMark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        CType(Me.nudQuestionCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.mainTab, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(691, 508)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'mainTab
        '
        Me.mainTab.Controls.Add(Me.TabPage1)
        Me.mainTab.Controls.Add(Me.TabPage2)
        Me.mainTab.Controls.Add(Me.TabPage3)
        Me.mainTab.Controls.Add(Me.TabPage4)
        Me.mainTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainTab.Location = New System.Drawing.Point(3, 3)
        Me.mainTab.Name = "mainTab"
        Me.mainTab.SelectedIndex = 0
        Me.mainTab.Size = New System.Drawing.Size(685, 466)
        Me.mainTab.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(677, 440)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Details"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.textboxName, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(671, 434)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(239, 210)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Publication Name:"
        '
        'textboxName
        '
        Me.textboxName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxName.Location = New System.Drawing.Point(338, 207)
        Me.textboxName.Name = "textboxName"
        Me.textboxName.Size = New System.Drawing.Size(330, 20)
        Me.textboxName.TabIndex = 1
        Me.textboxName.Text = "My Publication"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(677, 440)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Style"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.listStyles, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.PictureBox1, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(671, 434)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'listStyles
        '
        Me.listStyles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listStyles.FormattingEnabled = True
        Me.listStyles.Location = New System.Drawing.Point(3, 3)
        Me.listStyles.Name = "listStyles"
        Me.listStyles.Size = New System.Drawing.Size(396, 428)
        Me.listStyles.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(405, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(263, 428)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(677, 440)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Questions"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel10, 0, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel8, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel7, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel6, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel11, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 5
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(677, 440)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 2
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.checkIncludeUntagged, 1, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(3, 399)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(671, 38)
        Me.TableLayoutPanel10.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(190, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Include Untagged Questions"
        '
        'checkIncludeUntagged
        '
        Me.checkIncludeUntagged.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.checkIncludeUntagged.AutoSize = True
        Me.checkIncludeUntagged.Location = New System.Drawing.Point(338, 12)
        Me.checkIncludeUntagged.Name = "checkIncludeUntagged"
        Me.checkIncludeUntagged.Size = New System.Drawing.Size(15, 14)
        Me.checkIncludeUntagged.TabIndex = 3
        Me.checkIncludeUntagged.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel13, 1, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.listTags, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Label8, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.listTagsExcluded, 1, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel12, 0, 2)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 135)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 3
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(671, 258)
        Me.TableLayoutPanel8.TabIndex = 2
        '
        'TableLayoutPanel13
        '
        Me.TableLayoutPanel13.ColumnCount = 2
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel13.Controls.Add(Me.btnDeselectAllExclude, 1, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.btnSelectAllExclude, 0, 0)
        Me.TableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel13.Location = New System.Drawing.Point(338, 221)
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        Me.TableLayoutPanel13.RowCount = 1
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel13.Size = New System.Drawing.Size(330, 34)
        Me.TableLayoutPanel13.TabIndex = 5
        '
        'btnDeselectAllExclude
        '
        Me.btnDeselectAllExclude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDeselectAllExclude.Location = New System.Drawing.Point(168, 3)
        Me.btnDeselectAllExclude.Name = "btnDeselectAllExclude"
        Me.btnDeselectAllExclude.Size = New System.Drawing.Size(159, 28)
        Me.btnDeselectAllExclude.TabIndex = 1
        Me.btnDeselectAllExclude.Text = "Deselect All"
        Me.btnDeselectAllExclude.UseVisualStyleBackColor = True
        '
        'btnSelectAllExclude
        '
        Me.btnSelectAllExclude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSelectAllExclude.Location = New System.Drawing.Point(3, 3)
        Me.btnSelectAllExclude.Name = "btnSelectAllExclude"
        Me.btnSelectAllExclude.Size = New System.Drawing.Size(159, 28)
        Me.btnSelectAllExclude.TabIndex = 0
        Me.btnSelectAllExclude.Text = "Select All"
        Me.btnSelectAllExclude.UseVisualStyleBackColor = True
        '
        'listTags
        '
        Me.listTags.CheckOnClick = True
        Me.listTags.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listTags.FormattingEnabled = True
        Me.listTags.Location = New System.Drawing.Point(3, 15)
        Me.listTags.Name = "listTags"
        Me.listTags.Size = New System.Drawing.Size(329, 200)
        Me.listTags.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Include Tags:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(338, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 12)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Exclude Tags:"
        '
        'listTagsExcluded
        '
        Me.listTagsExcluded.CheckOnClick = True
        Me.listTagsExcluded.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listTagsExcluded.FormattingEnabled = True
        Me.listTagsExcluded.Location = New System.Drawing.Point(338, 15)
        Me.listTagsExcluded.Name = "listTagsExcluded"
        Me.listTagsExcluded.Size = New System.Drawing.Size(330, 200)
        Me.listTagsExcluded.TabIndex = 3
        '
        'TableLayoutPanel12
        '
        Me.TableLayoutPanel12.ColumnCount = 2
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel12.Controls.Add(Me.btnDeselectAllInclude, 1, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.btnSelectAllInclude, 0, 0)
        Me.TableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel12.Location = New System.Drawing.Point(3, 221)
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        Me.TableLayoutPanel12.RowCount = 1
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel12.Size = New System.Drawing.Size(329, 34)
        Me.TableLayoutPanel12.TabIndex = 4
        '
        'btnDeselectAllInclude
        '
        Me.btnDeselectAllInclude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDeselectAllInclude.Location = New System.Drawing.Point(167, 3)
        Me.btnDeselectAllInclude.Name = "btnDeselectAllInclude"
        Me.btnDeselectAllInclude.Size = New System.Drawing.Size(159, 28)
        Me.btnDeselectAllInclude.TabIndex = 1
        Me.btnDeselectAllInclude.Text = "Deselect All"
        Me.btnDeselectAllInclude.UseVisualStyleBackColor = True
        '
        'btnSelectAllInclude
        '
        Me.btnSelectAllInclude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSelectAllInclude.Location = New System.Drawing.Point(3, 3)
        Me.btnSelectAllInclude.Name = "btnSelectAllInclude"
        Me.btnSelectAllInclude.Size = New System.Drawing.Size(158, 28)
        Me.btnSelectAllInclude.TabIndex = 0
        Me.btnSelectAllInclude.Text = "Select All"
        Me.btnSelectAllInclude.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.TableLayoutPanel9, 1, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 91)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(671, 38)
        Me.TableLayoutPanel7.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(263, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Mark Range:"
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 3
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.nudMaxMark, 2, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.Label5, 1, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.nudMinMark, 0, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(338, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(330, 32)
        Me.TableLayoutPanel9.TabIndex = 3
        '
        'nudMaxMark
        '
        Me.nudMaxMark.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudMaxMark.Location = New System.Drawing.Point(184, 6)
        Me.nudMaxMark.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudMaxMark.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMaxMark.Name = "nudMaxMark"
        Me.nudMaxMark.Size = New System.Drawing.Size(143, 20)
        Me.nudMaxMark.TabIndex = 5
        Me.nudMaxMark.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(151, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "to"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'nudMinMark
        '
        Me.nudMinMark.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudMinMark.Location = New System.Drawing.Point(3, 6)
        Me.nudMinMark.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudMinMark.Name = "nudMinMark"
        Me.nudMinMark.Size = New System.Drawing.Size(142, 20)
        Me.nudMinMark.TabIndex = 4
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.checkRandom, 1, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 47)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(671, 38)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(193, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Randomly Order Questions?"
        '
        'checkRandom
        '
        Me.checkRandom.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.checkRandom.AutoSize = True
        Me.checkRandom.Checked = True
        Me.checkRandom.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkRandom.Location = New System.Drawing.Point(338, 12)
        Me.checkRandom.Name = "checkRandom"
        Me.checkRandom.Size = New System.Drawing.Size(15, 14)
        Me.checkRandom.TabIndex = 3
        Me.checkRandom.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.ColumnCount = 2
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.Controls.Add(Me.nudQuestionCount, 0, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 1
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(671, 38)
        Me.TableLayoutPanel11.TabIndex = 4
        '
        'nudQuestionCount
        '
        Me.nudQuestionCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudQuestionCount.Location = New System.Drawing.Point(338, 9)
        Me.nudQuestionCount.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nudQuestionCount.Name = "nudQuestionCount"
        Me.nudQuestionCount.Size = New System.Drawing.Size(330, 20)
        Me.nudQuestionCount.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(226, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Number of Questions"
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(677, 440)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Finish"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.buttonCancel, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.buttonNext, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.buttonFinish, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.buttonPrevious, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 475)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(685, 30)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'buttonCancel
        '
        Me.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonCancel.Location = New System.Drawing.Point(277, 3)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(96, 24)
        Me.buttonCancel.TabIndex = 3
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonNext
        '
        Me.buttonNext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonNext.Location = New System.Drawing.Point(481, 3)
        Me.buttonNext.Name = "buttonNext"
        Me.buttonNext.Size = New System.Drawing.Size(96, 24)
        Me.buttonNext.TabIndex = 0
        Me.buttonNext.Text = "Next >"
        Me.buttonNext.UseVisualStyleBackColor = True
        '
        'buttonFinish
        '
        Me.buttonFinish.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonFinish.Location = New System.Drawing.Point(583, 3)
        Me.buttonFinish.Name = "buttonFinish"
        Me.buttonFinish.Size = New System.Drawing.Size(99, 24)
        Me.buttonFinish.TabIndex = 2
        Me.buttonFinish.Text = "Finish"
        Me.buttonFinish.UseVisualStyleBackColor = True
        '
        'buttonPrevious
        '
        Me.buttonPrevious.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonPrevious.Enabled = False
        Me.buttonPrevious.Location = New System.Drawing.Point(379, 3)
        Me.buttonPrevious.Name = "buttonPrevious"
        Me.buttonPrevious.Size = New System.Drawing.Size(96, 24)
        Me.buttonPrevious.TabIndex = 1
        Me.buttonPrevious.Text = "< Previous"
        Me.buttonPrevious.UseVisualStyleBackColor = True
        '
        'Publisher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 508)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Publisher"
        Me.Text = "Publisher"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.mainTab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel13.ResumeLayout(False)
        Me.TableLayoutPanel12.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        CType(Me.nudMaxMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinMark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.TableLayoutPanel11.PerformLayout()
        CType(Me.nudQuestionCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents mainTab As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents buttonCancel As Button
    Friend WithEvents buttonNext As Button
    Friend WithEvents buttonFinish As Button
    Friend WithEvents buttonPrevious As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents textboxName As TextBox
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents listStyles As ListBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents nudMaxMark As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents nudMinMark As NumericUpDown
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents listTags As CheckedListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents checkRandom As CheckBox
    Friend WithEvents TableLayoutPanel10 As TableLayoutPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents checkIncludeUntagged As CheckBox
    Friend WithEvents TableLayoutPanel11 As TableLayoutPanel
    Friend WithEvents nudQuestionCount As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents listTagsExcluded As CheckedListBox
    Friend WithEvents TableLayoutPanel13 As TableLayoutPanel
    Friend WithEvents btnDeselectAllExclude As Button
    Friend WithEvents btnSelectAllExclude As Button
    Friend WithEvents TableLayoutPanel12 As TableLayoutPanel
    Friend WithEvents btnDeselectAllInclude As Button
    Friend WithEvents btnSelectAllInclude As Button
End Class
