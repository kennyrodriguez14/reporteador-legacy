Imports Disar.data
Public Class frmReporte_Recurrencias
    Dim conexion As New cls_reporte_recurrencias
    Dim style As Microsoft.Office.Interop.Excel.Style
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

    'Sub Exportar()
    '    Try
    '        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
    '        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
    '        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
    '        wBook = excel.Workbooks.Add()
    '        wSheet = wBook.ActiveSheet()
    '        wSheet.Name = "Productos"

    '        style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
    '        style.Font.Bold = True
    '        style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
    '        style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
    '        style.Font.Size = 11
    '        style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
    '        style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

    '        wSheet.Cells.Range("A1:H1").Merge()
    '        wSheet.Cells.Range("A1:H1").Borders.LineStyle = BorderStyle.FixedSingle
    '        wSheet.Cells.Range("A1:H1").Value = "Reporte de Recurrencias del " + cmFechaIni.Value.Date + " al " + cmbFin.Value.Date
    '        wSheet.Cells.Range("A1:H1").Style = "Reportes"

    '        For c As Integer = 0 To grd_listado.Columns.Count - 1
    '            wSheet.Cells(2, c + 1).value = grd_listado.Columns(c).HeaderText
    '            wSheet.Cells(2, c + 1).Style = "Reportes"
    '        Next
    '        For r As Integer = 0 To grd_listado.RowCount - 1
    '            For c As Integer = 0 To grd_listado.Columns.Count - 1
    '                wSheet.Cells(r + 3, c + 1).value = grd_listado.Item(c, r).Value
    '                wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
    '            Next
    '        Next
    '        wSheet.Columns.AutoFit()
    '        excel.Visible = True
    '        excel.Quit()
    '    Catch ex As Exception
    '        MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            grd_listado.DataSource = conexion.Reporte(cmFechaIni.Value.Date, cmbFin.Value.Date, cmb_almacen.SelectedValue, "DETALLE", cmb_empresa.Text)
            grd_encabezado.DataSource = conexion.Reporte(cmFechaIni.Value.Date, cmbFin.Value.Date, cmb_almacen.SelectedValue, "ENCABEZADO", cmb_empresa.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmReporte_Recurrencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_empresa.Text = "TODAS"
        Cargar_almacen()
    End Sub

    Sub Cargar_almacen()
        If cmb_empresa.Text = "TODAS" Then
            cmb_almacen.DataSource = ambos_almacenes.get_Todosalmacen
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"
        ElseIf cmb_empresa.Text = "SAN RAFAEL" Then
            cmb_almacen.DataSource = ambos_almacenes.get_almacen
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"

        ElseIf cmb_empresa.Text = "DIMOSA" Then
            cmb_almacen.DataSource = ambos_almacenes.get_almacenDimosa
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"
        ElseIf cmb_empresa.Text = "OPL" Then
            cmb_almacen.DataSource = ambos_almacenes.get_almacenOPL
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"
        End If

    End Sub
 

    Private Sub cmb_empresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_empresa.SelectedIndexChanged
        Cargar_almacen()
    End Sub
End Class