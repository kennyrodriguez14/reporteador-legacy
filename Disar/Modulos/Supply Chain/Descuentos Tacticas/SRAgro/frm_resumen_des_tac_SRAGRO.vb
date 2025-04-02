Imports Disar.data
Public Class frm_resumen_des_tac_SRAGRO
    Dim conexion As New cls_descuentos_tacticos_sragro
    Private Sub frm_resumen_des_tac_SRAGRO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_almacenes()
    End Sub

    Sub cargar_almacenes()
        Try
            cmb_almacen.DataSource = conexion.ListarAlmacenes_para_resumen
            cmb_almacen.DisplayMember = "ALMACEN"
            cmb_almacen.ValueMember = "ID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            grd_listado.DataSource = conexion.reporte_resumen(cmb_fecha_inicial.Value, cmb_fecha_final.Value, cmb_almacen.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            For c As Integer = 0 To grd_listado.Columns.Count - 1
                wSheet.Cells(1, c + 1).value = grd_listado.Columns(c).HeaderText
                wSheet.Cells(1, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(1, c + 1).Font.Bold = True
                wSheet.Cells(1, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(1, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Next
            For r As Integer = 0 To grd_listado.RowCount - 1
                For c As Integer = 0 To grd_listado.Columns.Count - 1
                    wSheet.Cells(r + 2, c + 1).value = grd_listado.Item(c, r).Value
                    wSheet.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
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