Imports Disar.data

Public Class frm_reporte_sobrantes
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim conexion As New clsReporte_Sobrantes
    Dim ambos_almacenes As New cls_almacen
    Dim Clase As New cls_reporte_carga

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
            wSheet.Name = "Productos"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:H1").Merge()
            wSheet.Cells.Range("A1:H1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:H1").Value = "Reporte de Sobrantes del " + cmFechaIni.Value.Date + " al " + cmbFin.Value.Date
            wSheet.Cells.Range("A1:H1").Style = "Reportes"

            For c As Integer = 0 To grdReporte.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grdReporte.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To grdReporte.RowCount - 1
                For c As Integer = 0 To grdReporte.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = "'" & grdReporte.Item(c, r).Value
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
            grdReporte.DataSource = conexion.Reporte(cmFechaIni.Value.Date, cmbFin.Value.Date, cmb_sucursal.SelectedValue, cmb_empresa.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_reporte_sobrantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_empresa.Text = "SAN RAFAEL"
        Cargar_almacen()
    End Sub

    Sub Cargar_almacen()

        If cmb_empresa.Text = "SAN RAFAEL" Then
            cmb_sucursal.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"
        ElseIf cmb_empresa.Text = "DIMOSA" Then
            cmb_sucursal.DataSource = Clase.getAlmacen(0, 0, "DIMOSA", Now, "", "ALM", 1)
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"
        ElseIf cmb_empresa.Text = "SR AGRO" Then
            cmb_sucursal.DataSource = Clase.getAlmacen(0, 0, "SR AGRO", Now, "", "ALM", 1)
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"
        End If



    End Sub

    Private Sub cmb_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectedIndexChanged
        Cargar_almacen()
        If cmb_empresa.Text = "TODAS" Then
            cmb_sucursal.Enabled = False
        Else
            cmb_sucursal.Enabled = True
        End If
    End Sub
End Class