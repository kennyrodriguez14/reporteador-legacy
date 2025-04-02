Imports Disar.data
Public Class EjecucionPresupuestos
    Dim Conexion As New clsPresupuestoXdepto
    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            GridPresupuestos.DataSource = Conexion.EjecutarPresupuestos _
            (cmbFecha_ini.Value.Date, cmbFecha_fin.Value.Date, txtCuenta_ini.Text, txtCuenta_Fin.Text)
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            wSheet = wBook.ActiveSheet()

            wSheet.Cells.Range("A1:C1").MergeCells = True
            wSheet.Cells.Range("A1:C1").Value = "PRESUPUESTOS POR DEPARTAMENTO"
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
            wSheet.Cells.Range("F2").Value = cmbFecha_ini.Value.Date
            wSheet.Cells.Range("F2").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("E3").Value = "FIN"
            wSheet.Cells.Range("E3").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("E3").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("E3").Font.Bold = True
            wSheet.Cells.Range("E3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("F3").Value = cmbFecha_fin.Value.Date
            wSheet.Cells.Range("F3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("E4").Value = "CUENTAS"
            wSheet.Cells.Range("E4").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            wSheet.Cells.Range("E4").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            wSheet.Cells.Range("E4").Font.Bold = True
            wSheet.Cells.Range("E4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("F4").Value = txtCuenta_ini.Text
            wSheet.Cells.Range("F4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("G4").Value = txtCuenta_Fin.Text
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

    Private Sub GridPresupuestos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridPresupuestos.CellDoubleClick
        frmDetallePresupuestos.txtDepartamento.Text = GridPresupuestos.CurrentRow.Cells(0).Value
        frmDetallePresupuestos.Inicio.Value = cmbFecha_ini.Value.Date
        frmDetallePresupuestos.Fin.Value = cmbFecha_fin.Value.Date
        frmDetallePresupuestos.txtcveIni.Text = txtCuenta_ini.Text
        frmDetallePresupuestos.txtcveFin.Text = txtCuenta_Fin.Text
        frmDetallePresupuestos.MdiParent = _Inicio
        frmDetallePresupuestos.Visible = True
    End Sub

    Private Sub EjecucionPresupuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class