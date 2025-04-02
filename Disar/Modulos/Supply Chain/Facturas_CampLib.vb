Imports Disar.data
Public Class Facturas_CampLib
    Dim Conexion As New cls_reportes_varios
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        _gridFacturas.DataSource = Conexion.VentaPromedio(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, _cmbSucursal.SelectedItem + "_CAMPLIB")
    End Sub

    Private Sub Facturas_CampLib_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _cmbSucursal.SelectedItem = "SPS"
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Cells.Range("A1:G1").Merge()
            wSheet.Cells.Range("A1:G1").Value = "Facturas y Campos Libres "
            wSheet.Cells.Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A1:G1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:G1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:G1").Font.Bold = True
            For c As Integer = 0 To _gridFacturas.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _gridFacturas.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            Next
            For r As Integer = 0 To _gridFacturas.RowCount - 1
                For c As Integer = 0 To _gridFacturas.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _gridFacturas.Item(c, r).Value
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

    Private Sub ExportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarToolStripMenuItem.Click
        Exportar()
    End Sub

    Private Sub _cmbSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cmbSucursal.SelectedIndexChanged

    End Sub
End Class