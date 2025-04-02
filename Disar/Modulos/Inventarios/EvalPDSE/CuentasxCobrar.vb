Imports Disar.data
Public Class CuentasxCobrar
    Dim Conexion As New cls_evaluacion_pdse
    Dim Reporte As String
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            If cmbSucursal.SelectedItem = "CONSUMO" Then
                Reporte = "cxc_consumo"
            ElseIf cmbSucursal.SelectedItem = "SR AGRO" Then
                Reporte = "cxc_sragro"
            End If
            _gridgeneral.DataSource = Conexion.VentasTotProd(Now.Date, _cmbFechai.Value.Date, Reporte, "")
        Catch ex As Exception
            MsgBox("Error " + ex.ToString)
        End Try
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Exportar()
    End Sub
    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            Clipboard.Clear()
            If cmbSucursal.Text = "CONSUMO" Then
                Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            Else
                Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen2.Image) 'imagen en picturebox Picture1 formato .bmp 
            End If
            wSheet.Cells.Range("A1").Select()
            Try
                wSheet.Paste()
            Catch ex As Exception
            End Try
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, imagencargill.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet.Cells.Range("C1").Select()
            Try
                wSheet.Paste()
            Catch ex As Exception
            End Try
            Clipboard.Clear()
            wSheet.Cells.Range("A5").Value = "GENERADO :"
            wSheet.Cells.Range("B5").Value = Now
            wSheet.Cells.Range("A7:E7").Merge()
            wSheet.Cells.Range("A7:E7").Value = "CUENTAS POR COBRAR AL " + _cmbFechai.Value.Date
            wSheet.Cells.Range("A7:E7").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A7:E7").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A7:E7").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A7:E7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A7:E7").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("A7:E7").Font.Bold = True
            wSheet.Cells.Range("A1").Select()
            For c As Integer = 0 To _gridgeneral.Columns.Count - 1
                wSheet.Cells(8, c + 1).value = _gridgeneral.Columns(c).HeaderText
                wSheet.Cells(8, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(8, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(8, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(8, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                wSheet.Cells(8, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                wSheet.Cells(8, c + 1).Font.Bold = True
            Next
            For r As Integer = 0 To _gridgeneral.RowCount - 1
                For c As Integer = 0 To _gridgeneral.Columns.Count - 1
                    wSheet.Cells(r + 9, c + 1).value = _gridgeneral.Item(c, r).Value
                    wSheet.Cells(r + 9, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Ventas_Totales_Cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSucursal.SelectedItem = "CONSUMO"
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub
End Class