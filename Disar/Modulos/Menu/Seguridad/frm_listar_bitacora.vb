Imports Disar.data

Public Class frm_listar_bitacora
    Dim style As Microsoft.Office.Interop.Excel.Style
    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Bitacora"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:F1").Merge()
            wSheet.Cells.Range("A1:F1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:F1").Value = "Bitacora Reporteador " + cmb_fecha_ini.Value.Date + "-" + cmb_fecha_fin.Value.Date
            wSheet.Cells.Range("A1:F1").Style = "Reportes"

            For c As Integer = 0 To grd_listado.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grd_listado.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To grd_listado.RowCount - 1
                For c As Integer = 0 To grd_listado.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = grd_listado.Item(c, r).Value
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

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Try
            Dim conexion As New cls_bitacora_reporteador
            grd_listado.DataSource = conexion.listar_bitacora(cmb_fecha_ini.Value.Date, cmb_fecha_fin.Value.Date)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class