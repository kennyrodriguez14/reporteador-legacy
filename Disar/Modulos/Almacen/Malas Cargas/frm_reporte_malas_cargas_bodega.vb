Imports Disar.data

Public Class frm_reporte_malas_cargas_bodega
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim conexion As New cls_reporte_malas_cargas
    Dim ambos_almacenes As New cls_almacen
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            Dim Cont As Integer = 0
            Dim f As Integer = 0
            For c As Integer = 0 To grd_encabezado.Columns.Count - 1
                wSheet.Cells(1, c + 1).value = grd_encabezado.Columns(c).HeaderText
                wSheet.Cells(1, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(1, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(1, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Next
            Cont = 2

            For r As Integer = 0 To grd_encabezado.RowCount - 1
                For c As Integer = 0 To grd_encabezado.Columns.Count - 1
                    wSheet.Cells(r + Cont, c + 1).value = grd_encabezado.Item(c, r).Value
                    wSheet.Cells(r + Cont, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next

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
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            grd_listado.DataSource = conexion.NuevoReporte(cmFechaIni.Value.Date, cmbFin.Value.Date, cmbAlmacen.SelectedValue, "DETALLE")
            grd_encabezado.DataSource = conexion.NuevoReporte(cmFechaIni.Value.Date, cmbFin.Value.Date, cmbAlmacen.SelectedValue, "ENCABEZADO")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_reporte_malas_cargas_bodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_almacen()
    End Sub

    Sub Cargar_almacen()
        cmbAlmacen.DataSource = ambos_almacenes.get_almacen
        cmbAlmacen.ValueMember = "ID"
        cmbAlmacen.DisplayMember = "ALMACEN"
    End Sub
End Class