Imports Disar.data
Public Class frm_resumen_descuentos_tacticos_admin_proveedor
    Dim conexion As New cls_descuentos_tacticos
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            grd_lista.DataSource = conexion.ListarDescuentos_administracion_concepto_proveedor(cmb_fecha_ini.Value, cmb_fecha_fin.Value, cmb_almacen.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_almacen()
        cmb_almacen.DataSource = conexion.ListarAlmacenes()
        cmb_almacen.ValueMember = "ID"
        cmb_almacen.DisplayMember = "ALMACEN"
    End Sub

    Private Sub frm_resumen_descuentos_tacticos_admin_proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_almacen()
    End Sub

    Sub exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            For c As Integer = 0 To grd_lista.Columns.Count - 1
                wSheet.Cells(1, c + 1).value = grd_lista.Columns(c).HeaderText
                wSheet.Cells(1, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                wSheet.Cells(1, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(1, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Next
            For r As Integer = 0 To grd_lista.RowCount - 1
                For c As Integer = 0 To grd_lista.Columns.Count - 1
                    wSheet.Cells(r + 2, c + 1).value = grd_lista.Item(c, r).Value
                    wSheet.Cells(r + 2, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
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

End Class