Imports Disar.data
Public Class frm_tab_rutas_principal
    Dim conexion As New cls_guardar_tabulacion
    Private Sub NuevaTabulacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaTabulacionToolStripMenuItem.Click
        frm_tabulacion_rutas.Close()
        frm_tabulacion_rutas.ShowDialog()
        Cargar()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Cargar()
    End Sub


    Sub Cargar()
        Try
            grd_lista_rutas.DataSource = conexion.ListarRutas(txt_busqueda_ruta.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub frm_tab_rutas_principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar()
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

    Private Sub grd_lista_rutas_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_lista_rutas.CellMouseDoubleClick
        Try
            frm_tab_detalle_rutas.Close()
            frm_tab_detalle_rutas.txt_ruta.Text = grd_lista_rutas.CurrentRow.Cells(0).Value
            frm_tab_detalle_rutas.txt_salida.Text = grd_lista_rutas.CurrentRow.Cells(2).Value
            frm_tab_detalle_rutas.txt_desayuno.Text = grd_lista_rutas.CurrentRow.Cells(3).Value
            frm_tab_detalle_rutas.txt_almuerzo.Text = grd_lista_rutas.CurrentRow.Cells(4).Value
            frm_tab_detalle_rutas.txt_regreso.Text = grd_lista_rutas.CurrentRow.Cells(5).Value
            frm_tab_detalle_rutas.txt_devoluciones.Text = grd_lista_rutas.CurrentRow.Cells(6).Value
            frm_tab_detalle_rutas.txt_liquidacion.Text = grd_lista_rutas.CurrentRow.Cells(7).Value
            frm_tab_detalle_rutas.txt_tiempo.Text = grd_lista_rutas.CurrentRow.Cells(8).Value
            frm_tab_detalle_rutas.fecha = grd_lista_rutas.CurrentRow.Cells(1).Value
            frm_tab_detalle_rutas.txt_id.Text = grd_lista_rutas.CurrentRow.Cells(9).Value
            frm_tab_detalle_rutas.ShowDialog()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub IngresarDatosARutasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarDatosARutasToolStripMenuItem.Click
        frm_tabulacion_rutas_SIP.Close()
        frm_tabulacion_rutas_SIP.ShowDialog()
        Cargar()
    End Sub

    Private Sub ReporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteToolStripMenuItem.Click
        frm_resumen_rutas.Close()
        frm_resumen_rutas.ShowDialog()
    End Sub

    Private Sub txt_busqueda_ruta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda_ruta.TextChanged
        Cargar()
    End Sub
End Class