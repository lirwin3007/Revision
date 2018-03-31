<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class screenshot
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
        Me.components = New System.ComponentModel.Container()
        Me.picScreenshot = New System.Windows.Forms.PictureBox()
        Me.drawingTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picScreenshot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picScreenshot
        '
        Me.picScreenshot.Cursor = System.Windows.Forms.Cursors.Cross
        Me.picScreenshot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picScreenshot.Location = New System.Drawing.Point(0, 0)
        Me.picScreenshot.Name = "picScreenshot"
        Me.picScreenshot.Size = New System.Drawing.Size(941, 587)
        Me.picScreenshot.TabIndex = 0
        Me.picScreenshot.TabStop = False
        '
        'drawingTimer
        '
        Me.drawingTimer.Interval = 1
        '
        'screenshot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 587)
        Me.Controls.Add(Me.picScreenshot)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "screenshot"
        Me.ShowInTaskbar = False
        Me.Text = "screenshot"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.picScreenshot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picScreenshot As PictureBox
    Friend WithEvents drawingTimer As Timer
End Class
