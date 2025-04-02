Imports Disar.data

Public Class frm_reporte_carga_camiones
    Dim conexion As New cls_carga_camiones_formatofactura
    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Try
            grd_listado.DataSource = conexion.GetReporte(cmb_fecha_ini.Value.Date, cmb_fecha_fin.Value.Date, cmb_almacen.SelectedValue, "DETALLADO")
            grd_encabezado.DataSource = conexion.GetReporte(cmb_fecha_ini.Value.Date, cmb_fecha_fin.Value.Date, cmb_almacen.SelectedValue, "ENCABEZADO")
            grd_resumen.DataSource = conexion.GetReporte(cmb_fecha_ini.Value.Date, cmb_fecha_fin.Value.Date, cmb_almacen.SelectedValue, "RESUMEN")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_reporte_carga_camiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_almacen()
    End Sub

    Sub cargar_almacen()
        cmb_almacen.DataSource = conexion.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
        cmb_almacen.ValueMember = "ID"
        cmb_almacen.DisplayMember = "ALMACEN"
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet, wSheet2 As Microsoft.Office.Interop.Excel.Worksheet

            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Detalle"

            Dim Cont As Integer = 0
            Dim f As Integer = 0
            For c As Integer = 0 To grd_encabezado.Columns.Count - 1
                wSheet.Cells(1, c + 1).value = grd_encabezado.Columns(c).HeaderText
                wSheet.Cells(1, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(1, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(1, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Next
            wSheet.Cells(1, grd_encabezado.Columns.Count).value = "Cargado por:"
            wSheet.Cells(1, grd_encabezado.Columns.Count).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(1, grd_encabezado.Columns.Count).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells(1, grd_encabezado.Columns.Count).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Cont = 2

            For r As Integer = 0 To grd_encabezado.RowCount - 1
                For c As Integer = 0 To grd_encabezado.Columns.Count - 1
                    wSheet.Cells(r + Cont, c + 1).value = grd_encabezado.Item(c, r).Value
                    wSheet.Cells(r + Cont, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
                wSheet.Cells(r + Cont, grd_encabezado.RowCount).value = ""
                wSheet.Cells(r + Cont, grd_encabezado.RowCount).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next
            Cont = grd_encabezado.RowCount + 3

            For c As Integer = 0 To grd_listado.Columns.Count - 1
                wSheet.Cells(Cont, c + 1).value = grd_listado.Columns(c).HeaderText
                wSheet.Cells(Cont, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(Cont, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(Cont, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Next

            Cont += 1

            For r As Integer = 0 To grd_listado.RowCount - 1
                For c As Integer = 0 To grd_listado.Columns.Count - 1
                    wSheet.Cells(r + Cont, c + 1).value = grd_listado.Item(c, r).Value
                    wSheet.Cells(r + Cont, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()

            wSheet2 = wBook.Sheets.Add()
            wSheet2.Name = "Resumen"
            For c As Integer = 0 To grd_resumen.Columns.Count - 1
                wSheet2.Cells(1, c + 1).value = grd_resumen.Columns(c).HeaderText
                wSheet2.Cells(1, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(1, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet2.Cells(1, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Next

            For r As Integer = 0 To grd_resumen.RowCount - 1
                For c As Integer = 0 To grd_resumen.Columns.Count - 1
                    wSheet2.Cells(r + 2, c + 1).value = grd_resumen.Item(c, r).Value
                    wSheet2.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet2.Columns.AutoFit()

            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class