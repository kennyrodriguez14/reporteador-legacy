Imports Disar.data

Public Class frmDetallePresupuestos
    Dim Conexion As New clsPresupuestoXdepto
    Private Sub frmDetallePresupuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GridPresupuestos.DataSource = Conexion.DetallarPresupuesto _
            (Inicio.Value.Date, Fin.Value.Date, txtcveIni.Text, txtcveFin.Text, txtDepartamento.Text)
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            wSheet.Cells.Range("A1:C1").MergeCells = True
            wSheet.Cells.Range("A1:C1").Value = txtDepartamento.Text.ToUpper
            wSheet.Cells.Range("A1:C1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("A1:C1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("A1:C1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:C1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:C1").Font.Bold = True
            
            wSheet.Cells.Range("E2").Value = "INICIO"
            wSheet.Cells.Range("E2").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("E2").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("E2").Font.Bold = True
            wSheet.Cells.Range("E2").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("F2").Value = Inicio.Value.Date
            wSheet.Cells.Range("F2").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("E3").Value = "FIN"
            wSheet.Cells.Range("E3").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("E3").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("E3").Font.Bold = True
            wSheet.Cells.Range("E3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("F3").Value = Fin.Value.Date
            wSheet.Cells.Range("F3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("E4").Value = "CUENTAS"
            wSheet.Cells.Range("E4").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("E4").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("E4").Font.Bold = True
            wSheet.Cells.Range("E4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("F4").Value = txtcveIni.Text
            wSheet.Cells.Range("F4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("G4").Value = txtcveFin.Text
            wSheet.Cells.Range("G4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)



            For c As Integer = 0 To GridPresupuestos.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = GridPresupuestos.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                wSheet.Cells(2, c + 1).Font.Bold = True
            Next
            For r As Integer = 0 To GridPresupuestos.RowCount - 1
                For c As Integer = 0 To GridPresupuestos.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = GridPresupuestos.Item(c, r).Value
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

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub
End Class