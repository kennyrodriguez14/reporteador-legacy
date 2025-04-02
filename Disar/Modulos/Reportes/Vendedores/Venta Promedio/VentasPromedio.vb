Imports Disar.data
Public Class VentasPromedio
    Dim Fecha1, Fecha2 As Date
    Dim Conexion As New cls_reportes_varios
    Private Sub VentasPromedio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSucursal.SelectedItem = "SRC"
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Fechas()
        Cargar()
    End Sub

    Sub Fechas()
        Fecha1 = 1 & "/" & cmbFecha.Value.AddMonths(-12).Month & "/" & cmbFecha.Value.AddMonths(-12).Year
        Fecha2 = DateTime.DaysInMonth(cmbFecha.Value.Year, cmbFecha.Value.AddMonths(-1).Month) & "/" & cmbFecha.Value.AddMonths(-1).Month & "/" & cmbFecha.Value.AddMonths(-1).Year
        MsgBox("Este reporte sera generado desde " & Fecha1 & " hasta " & Fecha2)
    End Sub

    Sub Cargar()
        If cmbSucursal.SelectedItem = "SRC" Then
            Try
                _gridVentaPromedio.DataSource = Conexion.VentaPromedio(Fecha1, Fecha2, "VentaPromedioSRC")
            Catch ex As Exception
                MsgBox("Error al cargar datos de SRC")
            End Try
        ElseIf cmbSucursal.SelectedItem = "SPS" Then
            Try
                _gridVentaPromedio.DataSource = Conexion.VentaPromedio(Fecha1, Fecha2, "VentaPromedioSPS")
            Catch ex As Exception
                MsgBox("Error al cargar datos de SPS")
            End Try
        ElseIf cmbSucursal.SelectedItem = "Saba" Then
            Try
                _gridVentaPromedio.DataSource = Conexion.VentaPromedio(Fecha1, Fecha2, "VentaPromedioTocoa")
            Catch ex As Exception
                MsgBox("Error al cargar datos de Saba")
            End Try
        ElseIf cmbSucursal.SelectedItem = "Tegucigalpa" Then
            Try
                _gridVentaPromedio.DataSource = Conexion.VentaPromedio(Fecha1, Fecha2, "VentaPromedioTegucigalpa")
            Catch ex As Exception
                MsgBox("Error al cargar datos de Tegucigalpa")
            End Try
        End If
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            wSheet.Cells.Range("A1:E1").Merge()
            wSheet.Cells.Range("A1:E1").Font.Bold = True
            wSheet.Cells.Range("A1:E1").Value = "Ventas Promedio de " & Fecha1.Date & "al " + Fecha2.Date
            wSheet.Cells.Range("A1:E1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:E1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            For c As Integer = 0 To _gridVentaPromedio.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _gridVentaPromedio.Columns(c).HeaderText
            Next
            For r As Integer = 0 To _gridVentaPromedio.RowCount - 1
                For c As Integer = 0 To _gridVentaPromedio.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _gridVentaPromedio.Item(c, r).Value
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