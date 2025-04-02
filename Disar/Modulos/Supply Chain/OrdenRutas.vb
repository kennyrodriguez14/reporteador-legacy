Imports Disar.data
Public Class OrdenRutas
    Dim Clase As New cls_reporte_carga
    Dim Clase2 As New clsOrden_Rutas
    Dim style, style2 As Microsoft.Office.Interop.Excel.Style
    Dim Tabla As New DataTable
    Dim TotalCan, TotalImp, TotaPes As Integer
    Dim Filas As DataRow = Tabla.NewRow
    Dim Activo As Integer = 0
    Private Sub OrdenRutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Almacen()
    End Sub

    Sub Cargar_Almacen()
        cmbAlmacen.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
        cmbAlmacen.ValueMember = "ID"
        cmbAlmacen.DisplayMember = "ALMACEN"
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            grd_orden_rutas.DataSource = Clase2.GetOrden(_cmbFechai.Value, _cmbFechaf.Value, cmbAlmacen.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub


    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            For c As Integer = 0 To grd_orden_rutas.Columns.Count - 1
                wSheet.Cells(1, c + 1).value = grd_orden_rutas.Columns(c).HeaderText
            Next
            For r As Integer = 0 To grd_orden_rutas.RowCount - 1
                For c As Integer = 0 To grd_orden_rutas.Columns.Count - 1
                    wSheet.Cells(r + 2, c + 1).value = grd_orden_rutas.Item(c, r).Value
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Exportar()
    End Sub
End Class