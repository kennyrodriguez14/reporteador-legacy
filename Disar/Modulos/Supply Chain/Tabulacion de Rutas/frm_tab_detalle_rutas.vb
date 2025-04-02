Imports Disar.data
Public Class frm_tab_detalle_rutas
    Dim conexion As New cls_guardar_tabulacion
    Public fecha As DateTime
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub frm_tab_detalle_rutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_lista_rutas.DataSource = conexion.DetalleRutas(Val(txt_id.Text), fecha)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        exportar()
    End Sub

    Sub exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            wSheet.Cells(1, 4).Value = "Tiempo: "
            wSheet.Cells(1, 4).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells(1, 4).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells(1, 4).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(1, 4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            wSheet.Cells(1, 4).Font.Bold = True

            wSheet.Cells(1, 5).Value = txt_tiempo.Text
            wSheet.Cells(1, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells(2, 4).Value = "Salida: "
            wSheet.Cells(2, 4).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells(2, 4).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells(2, 4).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(2, 4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            wSheet.Cells(2, 4).Font.Bold = True

            wSheet.Cells(2, 5).Value = txt_salida.Text
            wSheet.Cells(2, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells(3, 4).Value = "Desayuno: "
            wSheet.Cells(3, 4).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells(3, 4).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells(3, 4).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(3, 4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            wSheet.Cells(3, 4).Font.Bold = True

            wSheet.Cells(3, 5).Value = txt_desayuno.Text
            wSheet.Cells(3, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells(4, 4).Value = "Almuerzo: "
            wSheet.Cells(4, 4).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells(4, 4).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells(4, 4).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(4, 4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            wSheet.Cells(4, 4).Font.Bold = True

            wSheet.Cells(4, 5).Value = txt_almuerzo.Text
            wSheet.Cells(4, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells(5, 4).Value = "Devoluciones: "
            wSheet.Cells(5, 4).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells(5, 4).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells(5, 4).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(5, 4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            wSheet.Cells(5, 4).Font.Bold = True

            wSheet.Cells(5, 5).Value = txt_devoluciones.Text
            wSheet.Cells(5, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells(6, 4).Value = "Regreso a CD: "
            wSheet.Cells(6, 4).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells(6, 4).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells(6, 4).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(6, 4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            wSheet.Cells(6, 4).Font.Bold = True

            wSheet.Cells(6, 5).Value = txt_liquidacion.Text
            wSheet.Cells(6, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells(7, 4).Value = "Liquidacion: "
            wSheet.Cells(7, 4).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells(7, 4).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells(7, 4).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(7, 4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            wSheet.Cells(7, 4).Font.Bold = True

            wSheet.Cells(7, 5).Value = txt_liquidacion.Text
            wSheet.Cells(7, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("A9:E9").Merge()
            wSheet.Cells.Range("A9:E9").Value = "Detalle de Tabulacion de Ruta " + txt_ruta.Text
            wSheet.Cells.Range("A9:E9").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A9:E9").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A9:E9").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A9:E9").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A9:E9").Font.Bold = True

            For c As Integer = 0 To grd_lista_rutas.Columns.Count - 1
                wSheet.Cells(10, c + 1).value = grd_lista_rutas.Columns(c).HeaderText
                wSheet.Cells(10, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(10, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(10, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            Next
            For r As Integer = 0 To grd_lista_rutas.RowCount - 1
                For c As Integer = 0 To grd_lista_rutas.Columns.Count - 1
                    wSheet.Cells(r + 11, c + 1).value = grd_lista_rutas.Item(c, r).Value
                    wSheet.Cells(r + 11, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
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