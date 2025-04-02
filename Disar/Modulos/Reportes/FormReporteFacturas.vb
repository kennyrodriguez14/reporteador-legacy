Imports Disar.data

Public Class FormReporteFacturas
    Dim style As Microsoft.Office.Interop.Excel.Style
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim db As New cls_reportes_varios
        DataGridView1.DataSource = db.ReporteFacturas(DateTimePicker1.Value, DateTimePicker2.Value, ComboBox1.Text, TextBox1.Text, TextBox2.Text)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Fechas" Then
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        Else
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            TextBox1.Enabled = True
            TextBox2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Exportar()
    End Sub


    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Informacion"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:I1").Merge()
            wSheet.Cells.Range("A1:I1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:I1").Value = "Resumen de Facturas"
            wSheet.Cells.Range("A1:I1").Style = "Reportes"

            For c As Integer = 0 To DataGridView1.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = DataGridView1.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To DataGridView1.RowCount - 1
                For c As Integer = 0 To DataGridView1.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = DataGridView1.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class