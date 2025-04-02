Imports Disar.data

Public Class frm_facturas_vendedor

    Dim conexion As New cls_facturas_vendedor
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            If cmbSucursal.SelectedItem = "SRC" Then
                grd_ventas.DataSource = conexion.Facturas_Vendedor(cmb_F1.Value.Date, cmb_f2.Value.Date, 2)
            ElseIf cmbSucursal.SelectedItem = "SPS" Then
                grd_ventas.DataSource = conexion.Facturas_Vendedor(cmb_F1.Value.Date, cmb_f2.Value.Date, 1)
            ElseIf cmbSucursal.SelectedItem = "Saba" Then
                grd_ventas.DataSource = conexion.Facturas_Vendedor(cmb_F1.Value.Date, cmb_f2.Value.Date, 3)
            ElseIf cmbSucursal.SelectedItem = "Tegucigalpa" Then
                grd_ventas.DataSource = conexion.Facturas_Vendedor(cmb_F1.Value.Date, cmb_f2.Value.Date, 4)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frm_facturas_vendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSucursal.SelectedItem = "SRC"
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            For c As Integer = 0 To grd_ventas.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grd_ventas.Columns(c).HeaderText
            Next
            For r As Integer = 0 To grd_ventas.RowCount - 1
                For c As Integer = 0 To grd_ventas.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = grd_ventas.Item(c, r).Value
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub
End Class