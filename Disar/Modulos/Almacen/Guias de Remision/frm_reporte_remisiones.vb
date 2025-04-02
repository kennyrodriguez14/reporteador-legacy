Imports Disar.data
Public Class frm_reporte_remisiones
    Dim conexion As New cls_remisiones
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_lista_remisiones.DataSource = conexion.reporte_remisiones(cmb_fecha_ini.Value.Date, cmb_fecha_fin.Value.Date)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            For c As Integer = 0 To grd_lista_remisiones.Columns.Count - 1
                wSheet.Cells(1, c + 1).value = grd_lista_remisiones.Columns(c).HeaderText
            Next
            For r As Integer = 0 To grd_lista_remisiones.RowCount - 1
                For c As Integer = 0 To grd_lista_remisiones.Columns.Count - 1
                    wSheet.Cells(r + 2, c + 1).value = grd_lista_remisiones.Item(c, r).Value
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
        Exportar()
    End Sub
End Class