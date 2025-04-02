Imports Disar.data

Public Class Saldos_Detallado

    Dim Conexion As New cls_antiguedad_saldos

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            GridSaldos.DataSource = Conexion.Saldos_detallados(f1.Value.Date, cmbSucursal.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            Dim hasta As Integer = GridSaldos.ColumnCount - 1
            wSheet.Cells.Range("A1:P1").MergeCells = True

            If cmbSucursal.Text = "CARTERA INCOBRABLE" Then
                wSheet.Cells.Range("A1:P1").Value = "CARTERA INCOBRABLE " + f1.Value.Date()
            Else
                wSheet.Cells.Range("A1:P1").Value = "ANTIGUEDAD DE SALDOS AL " + f1.Value.Date()
            End If


            wSheet.Cells.Range("A1:P1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:P1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A1:P1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:P1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:P1").Font.Bold = True
            For c As Integer = 0 To GridSaldos.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = "'" + GridSaldos.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(2, c + 1).Font.Bold = True
            Next
            For r As Integer = 0 To GridSaldos.RowCount - 1
                For c As Integer = 0 To GridSaldos.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = GridSaldos.Item(c, r).Value
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

    Private Sub Saldos_Detallado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmbSucursal.DataSource = Conexion.llenar_combo_box(Now.Date, "LLENAR_COMBO_BOX")
            cmbSucursal.ValueMember = "ID"
            cmbSucursal.DisplayMember = "SUCURSAL"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Exportar()
    End Sub

End Class