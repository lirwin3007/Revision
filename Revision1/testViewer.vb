﻿Public Class testViewer

    Public test As test

    Sub showForm(test As test)
        Me.test = test
        For Each path In test.pages
            pageList.Add(New Bitmap(path))
        Next
        workingPageList = New List(Of Bitmap)(pageList)
        Me.Show()
    End Sub

    Dim pageList As New List(Of Bitmap)
    Dim workingPageList As List(Of Bitmap)
    Dim pageCount As Integer = 0
    Dim printPreviewDone As Boolean = False

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim scaleFactor As Double = e.PageSettings.PrintableArea.Height / workingPageList(0).Height
        Dim scaledImage As New Bitmap(workingPageList(0), workingPageList(0).Width * scaleFactor, workingPageList(0).Height * scaleFactor)
        e.Graphics.DrawImage(scaledImage, 0, 0)
        workingPageList.RemoveAt(0)
        If Not printPreviewDone Then
            pageCount += 1
            VScrollBar1.Maximum = pageCount - 1
        End If
        If workingPageList.Count > 0 Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            workingPageList = New List(Of Bitmap)(pageList)
            printPreviewDone = True
        End If
    End Sub

    Private Sub buttonPrint_Click(sender As Object, e As EventArgs) Handles buttonPrint.Click
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        printPreview.StartPage = VScrollBar1.Value
    End Sub

    Private Sub testViewer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        GC.Collect()
    End Sub
End Class