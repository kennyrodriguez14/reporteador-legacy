Imports Disar.data
Public Class frm_resumen_rutas
    Dim conexion As New cls_guardar_tabulacion
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_lista_rutas.DataSource = conexion.reporte_rutas(txt_busqueda_ruta.Text.ToUpper)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            wSheet.Cells.Range("A1:H1").Merge()
            wSheet.Cells.Range("A1:H1").Value = "EVALUACION DE TIEMPOS POR RUTAS "
            wSheet.Cells.Range("A1:H1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:H1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A1:H1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:H1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:H1").Font.Bold = True

            For c As Integer = 0 To grd_lista_rutas.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grd_lista_rutas.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            Next
            For r As Integer = 0 To grd_lista_rutas.RowCount - 1
                For c As Integer = 0 To grd_lista_rutas.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = grd_lista_rutas.Item(c, r).Value
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

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        exportar()
    End Sub

    Private Sub txt_busqueda_ruta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda_ruta.TextChanged
        cargar()
    End Sub
End Class