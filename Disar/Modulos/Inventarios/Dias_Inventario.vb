Imports Disar.data
Public Class Dias_Inventario
    Dim Conexion As New cls_inventarios
    Private Sub Dias_Inventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSucursal.SelectedItem = "AGRO SRC"
    End Sub
    Private Sub cmbSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSucursal.SelectedIndexChanged
        If cmbSucursal.SelectedItem = "SRC" Then
            cmbProveedor.DataSource = Conexion.ListaProveedores("1", Now, "ProvSRC")
            cmbProveedor.ValueMember = "ID"
            cmbProveedor.DisplayMember = "NOMBRE"
        ElseIf cmbSucursal.SelectedItem = "AGRO SRC" Then
            cmbProveedor.DataSource = Conexion.ListaProveedores("1", Now, "ProvSRCagro")
            cmbProveedor.ValueMember = "ID"
            cmbProveedor.DisplayMember = "NOMBRE"
        ElseIf cmbSucursal.SelectedItem = "AGRO GRACIAS" Then
            cmbProveedor.DataSource = Conexion.ListaProveedores("1", Now, "ProvGRACagro")
            cmbProveedor.ValueMember = "ID"
            cmbProveedor.DisplayMember = "NOMBRE"
        ElseIf cmbSucursal.SelectedItem = "SPS" Then
            cmbProveedor.DataSource = Conexion.ListaProveedores("1", Now, "ProvSPS")
            cmbProveedor.ValueMember = "ID"
            cmbProveedor.DisplayMember = "NOMBRE"

        ElseIf cmbSucursal.SelectedItem = "Saba" Then
            cmbProveedor.DataSource = Conexion.ListaProveedores("1", Now, "ProvTocoa")
            cmbProveedor.ValueMember = "ID"
            cmbProveedor.DisplayMember = "NOMBRE"

        ElseIf cmbSucursal.SelectedItem = "Tegucigalpa" Then
            cmbProveedor.DataSource = Conexion.ListaProveedores("1", Now, "ProvTegucigalpa")
            cmbProveedor.ValueMember = "ID"
            cmbProveedor.DisplayMember = "NOMBRE"

        ElseIf cmbSucursal.SelectedItem = "AGRO 08" Then
            cmbProveedor.DataSource = Conexion.ListaProveedores("1", Now, "ProvAGRO08")
            cmbProveedor.ValueMember = "ID"
            cmbProveedor.DisplayMember = "NOMBRE"
        ElseIf cmbSucursal.SelectedItem = "AGRO SAN JUAN" Then
            cmbProveedor.DataSource = Conexion.ListaProveedores("1", Now, "ProvSRCagro")
            cmbProveedor.ValueMember = "ID"
            cmbProveedor.DisplayMember = "NOMBRE"
        ElseIf cmbSucursal.SelectedItem = "AGRO SANTA BARBARA" Then
            cmbProveedor.DataSource = Conexion.ListaProveedores("1", Now, "ProvSRCagro")
            cmbProveedor.ValueMember = "ID"
            cmbProveedor.DisplayMember = "NOMBRE"
        End If
    End Sub
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            GridDiasInve.DataSource = Conexion.Dias_Inve(cmbProveedor.SelectedValue, _FechaInicial.Value.Date, cmbSucursal.SelectedItem)
        Catch ex As Exception
            MessageBox.Show("Error al generar el reporte" + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            wSheet = wBook.ActiveSheet
            wSheet.Cells.Range("A1:E1").Merge()
            wSheet.Cells.Range("A1:E1").Value = "INVENTARIO / DIAS DE INVENTARIO DE " & cmbSucursal.SelectedItem & " AL " & _FechaInicial.Value.Date
            wSheet.Cells.Range("A1:E1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("A1:E1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:E1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:E1").Font.Bold = True
            For c As Integer = 0 To GridDiasInve.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = GridDiasInve.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next
            For r As Integer = 0 To GridDiasInve.RowCount - 1
                For c As Integer = 0 To GridDiasInve.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = GridDiasInve.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class