Imports Disar.data
Public Class frm_resumen_debitos_creditos_sragro
    Dim Conexion As New cls_notas_debito_SRAGRO
    Private Sub frm_resumen_debitos_creditos_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_proveedores()
    End Sub

    Sub cargar_proveedores()
        Try
            cmbProveedor.DataSource = Conexion.resumen_debitosycreditos(Now.Date, Now.Date, "", "LIS")
            cmbProveedor.ValueMember = "CLAVE"
            cmbProveedor.DisplayMember = "NOMBRE"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            grd_reporte.DataSource = Conexion.resumen_debitosycreditos(_FechaInicial.Value.Date, _fechafinal.Value.Date, cmbProveedor.SelectedValue, "REP")
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
            wSheet = wBook.ActiveSheet
            wSheet.Cells.Range("A1:G1").Merge()
            wSheet.Cells.Range("A1:G1").Value = "Resumen Debitos y Creditos " & _FechaInicial.Value.Date & " AL " & _fechafinal.Value.Date
            wSheet.Cells.Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("A1:G1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:G1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:G1").Font.Bold = True
            wSheet.Cells.Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)

            For c As Integer = 0 To grd_reporte.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = grd_reporte.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Next
            For r As Integer = 0 To grd_reporte.RowCount - 1
                For c As Integer = 0 To grd_reporte.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = grd_reporte.Item(c, r).Value
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