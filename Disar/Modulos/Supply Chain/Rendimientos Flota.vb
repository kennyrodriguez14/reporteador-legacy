Imports Disar.data
Public Class Rendimientos_Flota
    Dim Conexion As New clsRendimientos
    Private Sub Rendimientos_Flota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicio.Value = 1 & "/" & Now.Month & "/" & Now.Year
        sucursal.SelectedItem = "SRC"
    End Sub

    Private Sub sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sucursal.SelectedIndexChanged
        If sucursal.SelectedItem = "SRC" Then
            concepto.DataSource = Conexion.Redimientos(Now.Date, Now.Date, "SRCCON", "1")
            concepto.ValueMember = "ID"
            concepto.DisplayMember = "NOMBRE"
        End If
        If sucursal.SelectedItem = "SPS" Then
            concepto.DataSource = Conexion.Redimientos(Now.Date, Now.Date, "SPSCON", "1")
            concepto.ValueMember = "ID"
            concepto.DisplayMember = "NOMBRE"
        End If
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            gridRendimientos.DataSource = Conexion.Redimientos(Inicio.Value.Date, Fin.Value.Date, sucursal.SelectedItem, concepto.SelectedValue)
        Catch ex As Exception
            MsgBox("Error al generar la informacion " + ex.ToString)
        End Try
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Cells.Range("A1:G1").Merge()
            wSheet.Cells.Range("A1:G1").Value = "Rendimientos de: " + concepto.SelectedItem("NOMBRE").ToString + " por Vehiculo del " + Inicio.Value.Date + " al " + Fin.Value.Date
            wSheet.Cells.Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A1:G1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:G1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:G1").Font.Bold = True
            For c As Integer = 0 To gridRendimientos.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = gridRendimientos.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(2, c + 1).Font.Bold = True
            Next
            For r As Integer = 0 To gridRendimientos.RowCount - 1
                For c As Integer = 0 To gridRendimientos.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = gridRendimientos.Item(c, r).Value
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