Imports Disar.data
Public Class QuintalesMen
    Dim conexion As New cls_ventas_diarias_agro 'clsventasdiariasagro
    Dim style4 As Microsoft.Office.Interop.Excel.Style

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            _gridgeneral.DataSource = conexion.Quintales(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "quintales", cmblinea.SelectedItem)
        Catch ex As Exception
            MsgBox("Error al cargar los datos " + ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub QuintalesMen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmblinea.SelectedItem = "23"
        _cmbFechai.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            _cmbFechaf.Value = Today
        Else
            _cmbFechaf.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Datos BASE"

            'style4 = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            'style4.Font.Bold = True
            'style4.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'style4.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            'style4.Font.Size = 11
            'style4.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            'style4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            For c As Integer = 0 To _gridgeneral.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _gridgeneral.Columns(c).HeaderText
                'wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridgeneral.RowCount - 1
                For c As Integer = 0 To _gridgeneral.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _gridgeneral.Item(c, r).Value
                    'wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class