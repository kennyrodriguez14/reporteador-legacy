Imports Disar.data

Public Class frmReporte_Productos_Averiados
    Dim conexion As New cls_reporte_de_productos_averiados
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim ambos_almacenes As New cls_almacen

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            grdReporte.DataSource = conexion.Reporte(cmFechaIni.Value.Date, cmbFin.Value.Date, cmb_almacen.SelectedValue, ComboEmpresa.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

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


            wSheet.Cells.Range("A1:G1").Merge()
            wSheet.Cells.Range("A1:G1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:G1").Value = "Reporte de Productos averiados del" + cmFechaIni.Value.Date + " al " + cmbFin.Value.Date
            wSheet.Cells.Range("A1:G1").Style = "Reportes"


            For c As Integer = 0 To grdReporte.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grdReporte.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next

            Dim Fila As Integer = 1

            For r As Integer = 0 To grdReporte.RowCount - 1
                For c As Integer = 0 To grdReporte.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = grdReporte.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
                Fila = r + 5
            Next

            wSheet.Cells(Fila, 2).value = "_____________________________"
            wSheet.Cells(Fila, 2).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(Fila, 2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells(Fila, 2).value = "Firma Entregado"
            wSheet.Cells(Fila, 2).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(Fila, 2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells(Fila, 4).value = "_____________________________"
            wSheet.Cells(Fila, 4).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(Fila, 4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells(Fila, 4).value = "Firma Recibido"
            wSheet.Cells(Fila, 2).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells(Fila, 2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmReporte_Productos_Averiados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_almacen()
    End Sub

    Sub Cargar_almacen()
        If ComboEmpresa.Text = "SAN RAFAEL" Then
            cmb_almacen.DataSource = ambos_almacenes.get_almacen
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"
        Else
            cmb_almacen.DataSource = ambos_almacenes.get_almacenDimosa
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"
        End If
        
    End Sub

    Private Sub ComboEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEmpresa.SelectedIndexChanged
        Cargar_almacen()
    End Sub
End Class