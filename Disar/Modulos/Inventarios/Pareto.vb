Imports Disar.data
Public Class Pareto
    Dim Conexion As New cls_inventarios
    Dim Tablas As New DataTable
    Dim filas6 As DataRow = Tablas.NewRow()
    Dim Contador As Integer
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            Columnas()
            grd_pareto.DataSource = Conexion.Pareto(Inicio.Value.Date, fin.Value.Date, cmbsucursal.SelectedItem)
            '***'
            Contador = 0
            For i As Integer = 0 To grd_pareto.RowCount - 1
                filas6("Clave Articulo") = grd_pareto.Rows(i).Cells(0).Value
                filas6("Desc. del Producto") = grd_pareto.Rows(i).Cells(1).Value
                filas6("Unidades Facturadas") = grd_pareto.Rows(i).Cells(2).Value
                filas6("Unidades Devueltas") = grd_pareto.Rows(i).Cells(3).Value
                filas6("Total Vendidas") = grd_pareto.Rows(i).Cells(4).Value
                filas6("Cajas") = grd_pareto.Rows(i).Cells(5).Value
                filas6("%") = grd_pareto.Rows(i).Cells(6).Value
                Contador += grd_pareto.Rows(i).Cells(6).Value
                If i = 0 Then
                    filas6("% Acumulado") = grd_pareto.Rows(i).Cells(6).Value
                Else
                    filas6("% Acumulado") = Contador
                End If
                filas6("Monto Facturado") = grd_pareto.Rows(i).Cells(7).Value
                Tablas.Rows.Add(filas6)
                filas6 = Tablas.NewRow()
            Next
            grd_ParetoFinal.DataSource = Tablas
            '***'
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Pareto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbsucursal.SelectedItem = "CONSUMO"
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
            wSheet.Cells.Range("A1:I1").Merge()
            wSheet.Cells.Range("A1:I1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:I1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:I1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:I1").Value = "Reporte 80/20 de " + cmbsucursal.SelectedItem + " del " + Inicio.Value.Date + " al " + fin.Value.Date
            For c As Integer = 0 To grd_ParetoFinal.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grd_ParetoFinal.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next
            For r As Integer = 0 To grd_ParetoFinal.RowCount - 1
                For c As Integer = 0 To grd_ParetoFinal.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = grd_ParetoFinal.Item(c, r).Value
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

    Sub Columnas()
        Tablas.Clear()
        Tablas.Columns.Clear()
        Tablas.Columns.Add("Clave Articulo")
        Tablas.Columns.Add("Desc. del Producto")
        Tablas.Columns.Add("Unidades Facturadas")
        Tablas.Columns.Add("Unidades Devueltas")
        Tablas.Columns.Add("Total Vendidas")
        Tablas.Columns.Add("Cajas")
        Tablas.Columns.Add("%")
        Tablas.Columns.Add("% Acumulado")
        Tablas.Columns.Add("Monto Facturado")
    End Sub
End Class