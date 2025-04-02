Imports Disar.data
Public Class Reporte_80_20
    Dim Fini, Ffin, Ftemporal As Date
    Dim dt As DataTable
    Dim dr As DataRow
    Dim Conexion As New cls_reportes_varios

    Private Sub Reporte_80_20_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbMes.SelectedItem = MonthName(Now.Month, False)
        _cmbSucursal.SelectedItem = "Santa Rosa Copan"
        _txtAño.Value = Now.Year
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        CrearFechas()
        Cargar()
    End Sub

    Sub CrearFechas()
        Fini = 1 & "/" & 1 & "/" & _txtAño.Value
        If cmbMes.SelectedIndex = 0 Then
            Ffin = DateTime.DaysInMonth(_txtAño.Value, cmbMes.SelectedIndex + 1) & "/" & cmbMes.SelectedIndex + 1 & "/" & _txtAño.Value
        Else
            Ffin = DateTime.DaysInMonth(_txtAño.Value, cmbMes.SelectedIndex) & "/" & cmbMes.SelectedIndex & "/" & _txtAño.Value
        End If
        MsgBox("Este Reporte se Generara desde " & Fini & " hasta " & Ffin)
    End Sub

    Sub Cargar()
        If _cmbSucursal.SelectedItem = "Santa Rosa Copan" Then
            Try
                _gridBIC.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "srcBIC")
                _gridLivsmart.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "srcLIVSMART")
                _gridColgate.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "srcCOLGATE")
                _gridNestle.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "srcNESTLE")
                _gridKC.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "srcKC")
                _gridAlcon.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "srcAlcon")

            Catch ex As Exception
                MsgBox("Error al Cargar SRC " + ex.Message)
            End Try
        ElseIf _cmbSucursal.SelectedItem = "San Pedro Sula" Then
            Try
                _gridBIC.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "spsBIC")
                _gridLivsmart.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "spsLIVSMART")
                _gridColgate.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "spsCOLGATE")
                _gridNestle.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "spsNESTLE")
                _gridKC.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "spsKC")
                _gridAlcon.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "spsAlcon")

            Catch ex As Exception
                MsgBox("Error al Cargar SPS " + ex.Message)
            End Try
        ElseIf _cmbSucursal.SelectedItem = "Saba" Then
            Try
                _gridBIC.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tocoaBIC")
                _gridLivsmart.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tocoaLIVSMART")
                _gridColgate.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tocoaCOLGATE")
                _gridNestle.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tocoaNESTLE")
                _gridKC.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tocoaKC")
                _gridAlcon.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tocoaAlcon")

            Catch ex As Exception
                MsgBox("Error al Cargar Saba " + ex.Message)
            End Try
        ElseIf _cmbSucursal.SelectedItem = "Tegucigalpa" Then
            Try
                _gridBIC.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tegucigalpaBIC")
                _gridLivsmart.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tegucigalpaLIVSMART")
                _gridColgate.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tegucigalpaCOLGATE")
                _gridNestle.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tegucigalpaNESTLE")
                _gridKC.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tegucigalpaKC")
                _gridAlcon.DataSource = Conexion.Reporte80_20(Fini.Date, Ffin.Date, "tegucigalpaAlcon")

            Catch ex As Exception
                MsgBox("Error al Cargar Tegucigalpa " + ex.Message)
            End Try
        End If
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ExportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet, wSheet2, wSheet3, wSheet4, wSheet5, wSheet6 As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = BIC.Text

            For c As Integer = 0 To _gridBIC.Columns.Count - 1
                wSheet.Cells(1, c + 1).value = _gridBIC.Columns(c).HeaderText
            Next
            For r As Integer = 0 To _gridBIC.RowCount - 1
                For c As Integer = 0 To _gridBIC.Columns.Count - 1
                    wSheet.Cells(r + 2, c + 1).value = _gridBIC.Item(c, r).Value
                Next
            Next

            wSheet6 = wBook.Sheets.Add()
            wSheet6.Name = alcon.Text
            For c As Integer = 0 To _gridAlcon.Columns.Count - 1
                wSheet6.Cells(1, c + 1).value = _gridAlcon.Columns(c).HeaderText
            Next
            For r As Integer = 0 To _gridAlcon.RowCount - 1
                For c As Integer = 0 To _gridAlcon.Columns.Count - 1
                    wSheet6.Cells(r + 2, c + 1).value = _gridAlcon.Item(c, r).Value
                Next
            Next

            wSheet2 = wBook.Sheets.Add()
            wSheet2.Name = LIVSMART.Text

            For c As Integer = 0 To _gridLivsmart.Columns.Count - 1
                wSheet2.Cells(1, c + 1).value = _gridLivsmart.Columns(c).HeaderText
            Next
            For r As Integer = 0 To _gridLivsmart.RowCount - 1
                For c As Integer = 0 To _gridLivsmart.Columns.Count - 1
                    wSheet2.Cells(r + 2, c + 1).value = _gridLivsmart.Item(c, r).Value
                Next
            Next

            wSheet3 = wBook.Sheets.Add()
            wSheet3.Name = COLGATE.Text
            For c As Integer = 0 To _gridColgate.Columns.Count - 1
                wSheet3.Cells(1, c + 1).value = _gridColgate.Columns(c).HeaderText
            Next
            For r As Integer = 0 To _gridColgate.RowCount - 1
                For c As Integer = 0 To _gridColgate.Columns.Count - 1
                    wSheet3.Cells(r + 2, c + 1).value = _gridColgate.Item(c, r).Value
                Next
            Next

            wSheet4 = wBook.Sheets.Add()
            wSheet4.Name = NESTLE.Text
            For c As Integer = 0 To _gridNestle.Columns.Count - 1
                wSheet4.Cells(1, c + 1).value = _gridNestle.Columns(c).HeaderText
            Next
            For r As Integer = 0 To _gridNestle.RowCount - 1
                For c As Integer = 0 To _gridNestle.Columns.Count - 1
                    wSheet4.Cells(r + 2, c + 1).value = _gridNestle.Item(c, r).Value
                Next
            Next

            wSheet5 = wBook.Sheets.Add()
            wSheet5.Name = KC.Text
            For c As Integer = 0 To _gridKC.Columns.Count - 1
                wSheet5.Cells(1, c + 1).value = _gridKC.Columns(c).HeaderText
            Next
            For r As Integer = 0 To _gridKC.RowCount - 1
                For c As Integer = 0 To _gridKC.Columns.Count - 1
                    wSheet5.Cells(r + 2, c + 1).value = _gridKC.Item(c, r).Value
                Next
            Next

            wSheet6.Columns.AutoFit()
            wSheet5.Columns.AutoFit()
            wSheet4.Columns.AutoFit()
            wSheet3.Columns.AutoFit()
            wSheet2.Columns.AutoFit()
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class