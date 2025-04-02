Imports Disar.data

Public Class FrmRepuestos

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        FrmRegistroRepuestos.ShowDialog()
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Dim db As New clsInventarioIT
        Try
            DataDatos.DataSource = db.VerRepuestos
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmRepuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BtnActualizar.PerformClick()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet
            wSheet.Cells.Range("A1:J1").Merge()
            wSheet.Cells.Range("A1:J1").Value = "INVENTARIO DE EQUIPO [SISTEMAS Y TECNOLOGÍA] - REPUESTOS "
            wSheet.Cells.Range("A1:J1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("A1:J1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:J1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:J1").Font.Bold = True
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Exportar()
    End Sub
End Class