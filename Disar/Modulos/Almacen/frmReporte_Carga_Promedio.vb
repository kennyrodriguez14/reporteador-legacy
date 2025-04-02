﻿Imports Disar.data
Public Class frmReporte_Carga_Promedio
    Dim conexion As New clsCarga_Promedio_Camiones
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim ambos_almacenes As New cls_almacen
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim diferencia, i, dias_mes, dias_trab As Integer
        Dim fecha_prueba As Date
        dias_mes = 0
        fecha_prueba = cmFechaIni.Value.Date
        diferencia = (DateDiff(DateInterval.Day, cmFechaIni.Value.Date, cmbFin.Value.Date)) + 1

        For i = 1 To diferencia
            If fecha_prueba.DayOfWeek = DayOfWeek.Sunday Then
                dias_mes = dias_mes + 1
            End If
            fecha_prueba = fecha_prueba.AddDays(1)
        Next
        dias_trab = diferencia - dias_mes
        grdReporte.DataSource = conexion.Reporte(cmFechaIni.Value.Date, cmbFin.Value.Date, dias_trab, cmb_sucursal.SelectedValue)
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
            wSheet.Name = "Promedio"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            wSheet.Cells.Range("A1:E1").Merge()
            wSheet.Cells.Range("A1:E1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:E1").Value = "Carga de camiones del " + cmFechaIni.Value.Date + " al " + cmbFin.Value.Date
            wSheet.Cells.Range("A1:E1").Style = "Reportes"


            For c As Integer = 0 To grdReporte.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grdReporte.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To grdReporte.RowCount - 1
                For c As Integer = 0 To grdReporte.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = grdReporte.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmReporte_Carga_Promedio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_almacen()
    End Sub

    Sub Cargar_almacen()
        cmb_sucursal.DataSource = ambos_almacenes.get_almacen
        cmb_sucursal.ValueMember = "ID"
        cmb_sucursal.DisplayMember = "ALMACEN"
    End Sub
End Class