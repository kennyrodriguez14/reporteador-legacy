Imports Disar.data

Public Class frm_Ventas_Categoria

    Dim style As Microsoft.Office.Interop.Excel.Style

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Try
            Dim db As New cls_ventas_por_proveedor
            DataGridView1.DataSource = db.VentasCategoria(ComboAlmacen.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frm_Ventas_Categoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenaAlm()
    End Sub

    Sub LlenaAlm()
        Try
            Dim db As New cls_ventas_por_proveedor
            ComboAlmacen.DataSource = db.ListaAlmacenes
            ComboAlmacen.DisplayMember = "NOMBRE"
            ComboAlmacen.ValueMember = "CLAVE"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Ventas Categoría"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            wSheet.Cells.Range("A1:D1").Merge()
            wSheet.Cells.Range("A1:D1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:D1").Value = "Reporte de Ventas por Categoría"
            wSheet.Cells.Range("A1:D1").Style = "Reportes"

            wSheet.Cells.Range("A2:D2").Merge()
            wSheet.Cells.Range("A2:D2").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A2:D2").Value = ComboAlmacen.Text & ": " & DateTimePicker1.Value.Date & " - " & DateTimePicker2.Value.Date
            wSheet.Cells.Range("A2:D2").Style = "Reportes"


            For c As Integer = 0 To DataGridView1.Columns.Count - 1
                wSheet.Cells(3, c + 1).value = DataGridView1.Columns(c).HeaderText
                wSheet.Cells(3, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To DataGridView1.RowCount - 1
                For c As Integer = 0 To DataGridView1.Columns.Count - 1
                    wSheet.Cells(r + 4, c + 1).value = DataGridView1.Item(c, r).Value
                    wSheet.Cells(r + 4, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 4, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 4, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
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