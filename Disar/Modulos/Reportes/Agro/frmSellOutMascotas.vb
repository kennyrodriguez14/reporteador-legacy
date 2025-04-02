Imports Disar.data
Public Class frmSellOutMascotas
    Dim SellOutMascotas As New cls_sell_out_mascotas 'clsSellOutMascotas
    Dim tabla As New DataTable
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        tabla = SellOutMascotas.General(_cmbFechai.Value.Date, _cmbFechaf.Value.Date)
        GridGeneral.DataSource = tabla
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            For c As Integer = 0 To GridGeneral.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = GridGeneral.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next
            For r As Integer = 0 To GridGeneral.RowCount - 1
                For c As Integer = 0 To GridGeneral.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = GridGeneral.Item(c, r).Value
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

 
End Class