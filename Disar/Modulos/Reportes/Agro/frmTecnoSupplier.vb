Imports Disar.data
Public Class frmTecnoSupplier
    Dim conexion As New cls_ventas_diarias_agro
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            _gridgeneral.DataSource = conexion.Quintales(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "TECNO SUPPLIER", "45")
        Catch ex As Exception
            MsgBox("Error al cargar los datos " + ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Datos BASE"

            For c As Integer = 0 To _gridgeneral.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _gridgeneral.Columns(c).HeaderText
            Next
            For r As Integer = 0 To _gridgeneral.RowCount - 1
                For c As Integer = 0 To _gridgeneral.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _gridgeneral.Item(c, r).Value
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub
End Class