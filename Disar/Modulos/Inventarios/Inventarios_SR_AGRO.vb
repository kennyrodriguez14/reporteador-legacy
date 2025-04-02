Imports Disar.data
Public Class Inventarios_SR_AGRO
    Dim conexion As New cls_inventarios_sr_agro
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Cargar()
    End Sub

    Sub Cargar()
        Try
            _gridInventarios.DataSource = conexion.Listar(txtCodigo.Text)
        Catch ex As Exception
            MsgBox("Error al cargar los datos " + ex.ToString)
        End Try
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Cells.Range("A1:J1").Merge()
            wSheet.Cells.Range("A1:J1").Value = "Inventarios SR AGRO " + Now
            wSheet.Cells.Range("A1:J1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:J1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A1:J1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:J1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:J1").Font.Bold = True
            For c As Integer = 0 To _gridInventarios.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _gridInventarios.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(2, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet.Cells(2, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                wSheet.Cells(2, c + 1).Font.Bold = True
            Next
            For r As Integer = 0 To _gridInventarios.RowCount - 1
                For c As Integer = 0 To _gridInventarios.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _gridInventarios.Item(c, r).Value
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

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub
End Class