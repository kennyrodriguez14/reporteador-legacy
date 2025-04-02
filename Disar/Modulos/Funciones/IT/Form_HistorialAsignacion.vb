Imports Disar.data

Public Class Form_HistorialAsignacion

 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet
            wSheet.Cells.Range("A1:M1").Merge()
            wSheet.Cells.Range("A1:M1").Value = "INVENTARIO DE EQUIPO [SISTEMAS Y TECNOLOGÍA] - HISTORIAL "
            wSheet.Cells.Range("A1:M1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("A1:M1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:M1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:M1").Font.Bold = True
            For c As Integer = 0 To DataDatos.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = DataDatos.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next
            For r As Integer = 0 To DataDatos.RowCount - 1
                For c As Integer = 0 To DataDatos.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = DataDatos.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class