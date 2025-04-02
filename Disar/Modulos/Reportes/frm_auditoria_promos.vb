Imports Disar.data
Public Class frm_auditoria_promos
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim conexion As New cls_ventas_contado_credito
    Dim Clase As New cls_reporte_carga


    Sub Cargar_Almacen()
        cmbAlmacen.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
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
            wSheet.Name = "Promociones"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

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
            grdReporte.DataSource = conexion.auditoria_promos(cmFechaIni.Value, "", cmbAlmacen.SelectedValue, "GENERAL")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub

    Private Sub frm_auditoria_promos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Almacen()
    End Sub

    Private Sub grdReporte_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdReporte.CellClick
        Try
            DataGridView1.DataSource = conexion.auditoria_promos(cmFechaIni.Value, grdReporte.CurrentRow.Cells(0).Value, cmbAlmacen.SelectedValue, "DETALLE")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grdReporte_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdReporte.KeyDown
        Try
            DataGridView1.DataSource = conexion.auditoria_promos(cmFechaIni.Value, grdReporte.CurrentRow.Cells(0).Value, cmbAlmacen.SelectedValue, "DETALLE")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class



