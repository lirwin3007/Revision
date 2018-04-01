<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Marker
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
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.buttonPrevious = New System.Windows.Forms.Button()
        Me.buttonNext = New System.Windows.Forms.Button()
        Me.buttonFinish = New System.Windows.Forms.Button()
        Me.progress = New System.Windows.Forms.ProgressBar()
        Me.tabMain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.TabPage1)
        Me.tabMain.Controls.Add(Me.TabPage2)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Location = New System.Drawing.Point(3, 3)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(733, 532)
        Me.tabMain.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(725, 506)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(257, 377)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tabMain, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(739, 579)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.buttonPrevious, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.buttonNext, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.buttonFinish, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.progress, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 541)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(733, 35)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'buttonPrevious
        '
        Me.buttonPrevious.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonPrevious.Location = New System.Drawing.Point(406, 3)
        Me.buttonPrevious.Name = "buttonPrevious"
        Me.buttonPrevious.Size = New System.Drawing.Size(103, 29)
        Me.buttonPrevious.TabIndex = 0
        Me.buttonPrevious.Text = "< Previous"
        Me.buttonPrevious.UseVisualStyleBackColor = True
        '
        'buttonNext
        '
        Me.buttonNext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonNext.Location = New System.Drawing.Point(515, 3)
        Me.buttonNext.Name = "buttonNext"
        Me.buttonNext.Size = New System.Drawing.Size(103, 29)
        Me.buttonNext.TabIndex = 1
        Me.buttonNext.Text = "Next >"
        Me.buttonNext.UseVisualStyleBackColor = True
        '
        'buttonFinish
        '
        Me.buttonFinish.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonFinish.Location = New System.Drawing.Point(624, 3)
        Me.buttonFinish.Name = "buttonFinish"
        Me.buttonFinish.Size = New System.Drawing.Size(106, 29)
        Me.buttonFinish.TabIndex = 2
        Me.buttonFinish.Text = "Finish"
        Me.buttonFinish.UseVisualStyleBackColor = True
        '
        'progress
        '
        Me.progress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.progress.Location = New System.Drawing.Point(3, 3)
        Me.progress.Name = "progress"
        Me.progress.Size = New System.Drawing.Size(397, 29)
        Me.progress.TabIndex = 3
        '
        'Marker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 579)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Marker"
        Me.Text = "Marker"
        Me.tabMain.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabMain As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents buttonPrevious As Button
    Friend WithEvents buttonNext As Button
    Friend WithEvents buttonFinish As Button
    Friend WithEvents progress As ProgressBar
End Class
