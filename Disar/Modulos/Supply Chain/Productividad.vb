Imports Disar.data
Public Class Productividad
    Dim Conexion As New cls_productividad
    Dim FI, FF As DateTime
    Dim hora1, hora2, hora3, minuto1, minuto2, minuto3 As Double
    Dim style, estilo2, style3, estilo4, style2, estilo3 As Microsoft.Office.Interop.Excel.Style

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        FI = _cmbFechai.Value.Date.AddHours(1)
        FF = _cmbFechai.Value.Date.AddHours(23)
        Cargar()
        Try
            LlenarLabels()
        Catch ex As Exception

        End Try
    End Sub

    Sub Cargar()
        limpiar()
        Try
            _gridUsuario1.DataSource = Conexion.ProductividadFacturacion(FI, FF, "SC", "786")
            _gridUsuario2.DataSource = Conexion.ProductividadFacturacion(FI, FF, "SC", "787")

            If _gridUsuario1.RowCount > 0 Then
                Usuario1.Text = _gridUsuario1.Rows(0).Cells(2).Value
            End If
            If _gridUsuario2.RowCount > 0 Then
                Usuario2.Text = _gridUsuario2.Rows(0).Cells(2).Value
            End If
            If _gridUsuario3.RowCount > 0 Then
                Usuario3.Text = _gridUsuario3.Rows(0).Cells(2).Value
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub LlenarLabels()
        If _gridUsuario1.RowCount > 0 Then
            txtHoraInicial.Text = _gridUsuario1.Rows(0).Cells(3).Value
            txtHorafinal.Text = _gridUsuario1.Rows(_gridUsuario1.RowCount - 1).Cells(3).Value
            txtNumeroFacturas.Text = _gridUsuario1.RowCount
            minuto1 = DateDiff(DateInterval.Minute, _gridUsuario1.Rows(0).Cells(4).Value, _gridUsuario1.Rows(_gridUsuario1.RowCount - 1).Cells(4).Value) - 60 '- 30720
            hora1 = minuto1 / 60
            txtNumHoras.Text = FormatNumber(hora1, 2)
            txtNumMinutos.Text = minuto1
            txtPromedioHoras.Text = FormatNumber((Val(txtNumeroFacturas.Text) / Val(txtNumHoras.Text)))
            txtPromedioMinutos.Text = FormatNumber(Val(txtNumeroFacturas.Text) / minuto1)
            txtMinutosXF1.Text = FormatNumber(minuto1 / Val(txtNumeroFacturas.Text))
        End If
        If _gridUsuario2.RowCount > 0 Then
            txtHoraInicial2.Text = _gridUsuario2.Rows(0).Cells(3).Value
            txtHoraFinal2.Text = _gridUsuario2.Rows(_gridUsuario2.RowCount - 1).Cells(3).Value
            txtNumeroFacturas2.Text = _gridUsuario2.RowCount
            minuto2 = DateDiff(DateInterval.Minute, _gridUsuario2.Rows(0).Cells(4).Value, _gridUsuario2.Rows(_gridUsuario2.RowCount - 1).Cells(4).Value) - 60
            hora2 = minuto2 / 60
            txtNumHoras2.Text = FormatNumber(hora2, 2)
            txtNumMinutos2.Text = minuto2
            txtPromedioHoras2.Text = FormatNumber((Val(txtNumeroFacturas2.Text) / Val(txtNumHoras2.Text)))
            txtPromMinutos2.Text = FormatNumber(Val(txtNumeroFacturas2.Text) / minuto1)
            txtMinutosXF2.Text = FormatNumber(minuto2 / Val(txtNumeroFacturas2.Text))
        End If
        If _gridUsuario3.RowCount > 0 Then
            txtHinicial3.Text = _gridUsuario3.Rows(0).Cells(3).Value
            txtHfinal3.Text = _gridUsuario3.Rows(_gridUsuario3.RowCount - 1).Cells(3).Value
            txtNF3.Text = _gridUsuario3.RowCount
            minuto3 = DateDiff(DateInterval.Minute, _gridUsuario3.Rows(0).Cells(4).Value, _gridUsuario3.Rows(_gridUsuario3.RowCount - 1).Cells(4).Value) - 60
            hora3 = minuto3 / 60
            txtnh3.Text = FormatNumber(hora3, 2)
            txtnum3.Text = minuto3
            txtFxh3.Text = FormatNumber((Val(txtNF3.Text) / Val(txtnh3.Text)))
            txtfxm3.Text = FormatNumber(Val(txtNF3.Text) / minuto3)
            txtMF3.Text = FormatNumber(minuto3 / Val(txtNF3.Text))
        End If
    End Sub

    Sub limpiar()
        txtHorafinal.Text = ""
        txtHoraFinal2.Text = ""
        txtHfinal3.Text = ""
        txtHoraInicial.Text = ""
        txtHoraInicial2.Text = ""
        txtHinicial3.Text = ""
        txtMinutosXF1.Text = ""
        txtMinutosXF2.Text = ""
        txtMF3.Text = ""
        txtNumeroFacturas.Text = ""
        txtNumeroFacturas2.Text = ""
        txtNF3.Text = ""
        txtNumHoras.Text = ""
        txtNumHoras2.Text = ""
        txtnh3.Text = ""
        txtNumMinutos.Text = ""
        txtNumMinutos2.Text = ""
        txtnum3.Text = ""
        txtPromedioHoras.Text = ""
        txtPromedioHoras2.Text = ""
        txtFxh3.Text = ""
        txtPromedioMinutos.Text = ""
        txtPromMinutos2.Text = ""
        txtfxm3.Text = ""
        hora1 = 0
        hora2 = 0
        minuto1 = 0
        minuto2 = 0
        hora3 = 0
        minuto3 = 0
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet, wSheet2, wSheet3 As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            If _gridUsuario1.RowCount <= 0 Then
            Else
                wSheet.Name = Usuario1.Text
                style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
                style.Font.Bold = True
                style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                style.Font.Size = 11
                style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                wSheet.Cells.Range("A1").Value = "------------------"
                Clipboard.Clear()
                Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
                wSheet.Cells.Range("A1").Select()
                Try
                    wSheet.Paste()
                Catch ex As Exception
                End Try
                wSheet.Cells(1, 5).value = "HORA INICIAL"
                wSheet.Cells(1, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(1, 5).style = "Reportes"
                wSheet.Cells(2, 5).value = "HORA FINAL"
                wSheet.Cells(2, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, 5).style = "Reportes"
                wSheet.Cells(3, 5).value = "NUM. FACTURAS"
                wSheet.Cells(3, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(3, 5).style = "Reportes"
                wSheet.Cells(4, 5).value = "FACTURAS/HORA"
                wSheet.Cells(4, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(4, 5).style = "Reportes"
                wSheet.Cells(5, 5).value = "FACTURAS/MINUTO"
                wSheet.Cells(5, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(5, 5).style = "Reportes"
                wSheet.Cells(6, 5).value = "MINUTOS/FACTURA"
                wSheet.Cells(6, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(6, 5).style = "Reportes"

                wSheet.Cells.Range("A8:F8").Merge()
                wSheet.Cells.Range("A8:F8").Borders.LineStyle = BorderStyle.FixedSingle
                wSheet.Cells.Range("A8:F8").Value = "REPORTE DE PRODUCTIVIDAD DEL " + _cmbFechai.Value.Date
                wSheet.Cells.Range("A8:F8").Style = "Reportes"
                wSheet.Cells(1, 6).value = txtHoraInicial.Text
                wSheet.Cells(1, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(2, 6).value = txtHorafinal.Text
                wSheet.Cells(2, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(3, 6).value = txtNumeroFacturas.Text
                wSheet.Cells(3, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(4, 6).value = txtPromedioHoras.Text
                wSheet.Cells(4, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(5, 6).value = txtPromedioMinutos.Text
                wSheet.Cells(5, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(6, 6).value = txtMinutosXF1.Text
                wSheet.Cells(6, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                For c As Integer = 0 To _gridUsuario1.Columns.Count - 1
                    wSheet.Cells(9, c + 1).value = _gridUsuario1.Columns(c).HeaderText
                    wSheet.Cells(9, c + 1).Style = "Reportes"
                Next
                For r As Integer = 0 To _gridUsuario1.RowCount - 1
                    For c As Integer = 0 To _gridUsuario1.Columns.Count - 1
                        wSheet.Cells(r + 10, c + 1).value = _gridUsuario1.Item(c, r).Value
                        wSheet.Cells(r + 10, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    Next
                Next
                wSheet.Columns.AutoFit()
            End If

            If _gridUsuario2.RowCount <= 0 Then
            Else
                wSheet2 = wBook.Sheets.Add()
                wSheet2.Name = Usuario2.Text
                wSheet2.Cells.Range("A1").Value = "--------------------"
                Clipboard.Clear()
                Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
                wSheet2.Cells.Range("A1").Select()
                Try
                    wSheet2.Paste()
                Catch ex As Exception
                End Try
                wSheet2.Cells(1, 5).value = "HORA INICIAL"
                wSheet2.Cells(1, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(1, 5).style = "Reportes"
                wSheet2.Cells(2, 5).value = "HORA FINAL"
                wSheet2.Cells(2, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(2, 5).style = "Reportes"
                wSheet2.Cells(3, 5).value = "NUM. FACTURAS"
                wSheet2.Cells(3, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(3, 5).style = "Reportes"
                wSheet2.Cells(4, 5).value = "FACTURAS/HORA"
                wSheet2.Cells(4, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(4, 5).style = "Reportes"
                wSheet2.Cells(5, 5).value = "FACTURAS/MINUTO"
                wSheet2.Cells(5, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(5, 5).style = "Reportes"
                wSheet2.Cells(6, 5).value = "MINUTOS/FACTURA"
                wSheet2.Cells(6, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(6, 5).style = "Reportes"

                wSheet2.Cells.Range("A8:F8").Merge()
                wSheet2.Cells.Range("A8:F8").Borders.LineStyle = BorderStyle.FixedSingle
                wSheet2.Cells.Range("A8:F8").Value = "REPORTE DE PRODUCTIVIDAD DEL " + _cmbFechai.Value.Date
                wSheet2.Cells.Range("A8:F8").Style = "Reportes"
                wSheet2.Cells(1, 6).value = txtHoraInicial2.Text
                wSheet2.Cells(1, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(2, 6).value = txtHoraFinal2.Text
                wSheet2.Cells(2, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(3, 6).value = txtNumeroFacturas2.Text
                wSheet2.Cells(3, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(4, 6).value = txtPromedioHoras2.Text
                wSheet2.Cells(4, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(5, 6).value = txtPromMinutos2.Text
                wSheet2.Cells(5, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet2.Cells(6, 6).value = txtMinutosXF2.Text
                wSheet2.Cells(6, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                For c As Integer = 0 To _gridUsuario2.Columns.Count - 1
                    wSheet2.Cells(9, c + 1).value = _gridUsuario2.Columns(c).HeaderText
                    wSheet2.Cells(9, c + 1).Style = "Reportes"
                Next
                For r As Integer = 0 To _gridUsuario2.RowCount - 1
                    For c As Integer = 0 To _gridUsuario2.Columns.Count - 1
                        wSheet2.Cells(r + 10, c + 1).value = _gridUsuario2.Item(c, r).Value
                        wSheet2.Cells(r + 10, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    Next
                Next
                wSheet2.Columns.AutoFit()
            End If

            If _gridUsuario3.RowCount <= 0 Then
            Else
                wSheet3 = wBook.Sheets.Add()
                wSheet3.Name = Usuario3.Text
                wSheet3.Cells.Range("A1").Value = "--------------------"
                Clipboard.Clear()
                Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
                wSheet3.Cells.Range("A1").Select()
                Try
                    wSheet3.Paste()
                Catch ex As Exception
                End Try
                wSheet3.Cells(1, 5).value = "HORA INICIAL"
                wSheet3.Cells(1, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(1, 5).style = "Reportes"
                wSheet3.Cells(2, 5).value = "HORA FINAL"
                wSheet3.Cells(2, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(2, 5).style = "Reportes"
                wSheet3.Cells(3, 5).value = "NUM. FACTURAS"
                wSheet3.Cells(3, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(3, 5).style = "Reportes"
                wSheet3.Cells(4, 5).value = "FACTURAS/HORA"
                wSheet3.Cells(4, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(4, 5).style = "Reportes"
                wSheet3.Cells(5, 5).value = "FACTURAS/MINUTO"
                wSheet3.Cells(5, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(5, 5).style = "Reportes"
                wSheet3.Cells(6, 5).value = "MINUTOS/FACTURA"
                wSheet3.Cells(6, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(6, 5).style = "Reportes"

                wSheet3.Cells.Range("A8:F8").Merge()
                wSheet3.Cells.Range("A8:F8").Borders.LineStyle = BorderStyle.FixedSingle
                wSheet3.Cells.Range("A8:F8").Value = "REPORTE DE PRODUCTIVIDAD DEL " + _cmbFechai.Value.Date
                wSheet3.Cells.Range("A8:F8").Style = "Reportes"
                wSheet3.Cells(1, 6).value = txtHinicial3.Text
                wSheet3.Cells(1, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(2, 6).value = txtHfinal3.Text
                wSheet3.Cells(2, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(3, 6).value = txtNF3.Text
                wSheet3.Cells(3, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(4, 6).value = txtFxh3.Text
                wSheet3.Cells(4, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(5, 6).value = txtfxm3.Text
                wSheet3.Cells(5, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet3.Cells(6, 6).value = txtMF3.Text
                wSheet3.Cells(6, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                For c As Integer = 0 To _gridUsuario2.Columns.Count - 1
                    wSheet3.Cells(9, c + 1).value = _gridUsuario3.Columns(c).HeaderText
                    wSheet3.Cells(9, c + 1).Style = "Reportes"
                Next
                For r As Integer = 0 To _gridUsuario3.RowCount - 1
                    For c As Integer = 0 To _gridUsuario3.Columns.Count - 1
                        wSheet3.Cells(r + 10, c + 1).value = _gridUsuario3.Item(c, r).Value
                        wSheet3.Cells(r + 10, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    Next
                Next
                wSheet3.Columns.AutoFit()
            End If

            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Productividad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _cmbFechai.Value = _cmbFechai.Value.Date.AddDays(-1).Date
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class