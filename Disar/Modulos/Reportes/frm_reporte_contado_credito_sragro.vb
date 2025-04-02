Imports Disar.data
Public Class frm_reporte_contado_credito_sragro
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim conexion As New cls_ventas_contado_credito
    Dim Clase As New cls_reporte_carga
    Private Sub frm_reporte_contado_credito_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Almacen()
    End Sub

    Sub Cargar_Almacen()
        cmbAlmacen.DataSource = Clase.getAlmacen(0, 0, "SR AGRO", Now, "", "ALM", 1)
        cmbAlmacen.ValueMember = "ID"
        cmbAlmacen.DisplayMember = "ALMACEN"
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Promedio"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            wSheet.Cells.Range("A1:D1").Merge()
            wSheet.Cells.Range("A1:D1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:D1").Value = "Detalle de Ventas Contado/Credito "
            wSheet.Cells.Range("A1:D1").Style = "Reportes"


            For c As Integer = 0 To grdReporte.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grdReporte.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To grdReporte.RowCount - 1
                For c As Integer = 0 To grdReporte.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = grdReporte.Item(c, r).Value
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            grdReporte.DataSource = conexion.Reporte_sragro(cmFechaIni.Value.Date, DateTimePicker1.Value.Date, cmbAlmacen.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub
End Class
