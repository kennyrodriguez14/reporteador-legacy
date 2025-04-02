Imports Disar.data
Public Class Cajas
    Dim cajas As New cls_cajas_livsmart
    Dim daysT, daysM, daysR, contador, Cantidad_Dias, ContadorFilas, CFilas, Activador As Integer
    Dim FechaTemp As Date
    Dim Tabla1 As New DataTable
    Dim Tabla2 As New DataTable
    Dim Fila1 As DataRow = Tabla1.NewRow
    Dim Filas2 As DataRow = Tabla2.NewRow
    Dim Producto, Codigo As String
    Dim TspsCalifornia, TsrcCalifornia, TgeneralCalifornia, Tsps, Tsrc, Tgeneral, TotalColumnaSPS, TotalColumnaSRC As Double
    Dim style, estilo2 As Microsoft.Office.Interop.Excel.Style

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        If _cmbFechaf.Value.Date < _cmbFechai.Value.Date Then
            MessageBox.Show("La fecha inicial no puede ser mayor a la final", "Fechas Incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                limpiar()
                CalculoDias()
                cargar()
                LlenarSRC()
                LlenarSPS()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Sub cargar()
        Try
            _gridcajasSRC.DataSource = cajas.CajasLiv(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "SC")
            _gridcajasSPS.DataSource = cajas.CajasLiv(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "SS")
            _gridJC1.DataSource = cajas.CajasLiv(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "JC1")
            _gridJC2.DataSource = cajas.CajasLiv(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "JC2")
            _gridJC3.DataSource = cajas.CajasLiv(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "JC3")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CalculoDias()
        Try
            daysT = 0
            daysM = 0
            daysR = 0
            contador = _cmbFechaf.Value.Day
            If _cmbFechai.Value.Month = _cmbFechaf.Value.Month Then
                Cantidad_Dias = DateTime.DaysInMonth(_cmbFechaf.Value.Year, _cmbFechaf.Value.Month)
                For i As Integer = 1 To Cantidad_Dias
                    FechaTemp = i & "/" & _cmbFechaf.Value.Month & "/" & _cmbFechaf.Value.Year
                    If FechaTemp.DayOfWeek <> DayOfWeek.Sunday Then
                        daysM += 1
                    End If
                Next
                For j As Integer = 1 To contador
                    FechaTemp = j & "/" & _cmbFechaf.Value.Month & "/" & _cmbFechaf.Value.Year
                    If FechaTemp.DayOfWeek <> DayOfWeek.Sunday Then
                        daysT += 1
                    End If
                Next
                daysR = daysM - daysT
            End If
            DiasM.Text = daysM
            DiasT.Text = daysT
            DiasR.Text = daysR
            Porcentaje.Text = (daysT / daysM) * 100
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub LlenarSRC()
        TspsCalifornia = 0
        TsrcCalifornia = 0
        TgeneralCalifornia = 0
        For i As Integer = 0 To _gridcajasSRC.RowCount - 1
            Tsps = 0
            Tsrc = 0
            Tgeneral = 0
            For c As Integer = 0 To _gridcajasSPS.RowCount - 1
                If _gridcajasSRC.Rows(i).Cells(0).Value = _gridcajasSPS.Rows(c).Cells(0).Value Then
                    Tsps = _gridcajasSPS.Rows(c).Cells(4).Value
                End If
            Next
            Tsrc = _gridcajasSRC.Rows(i).Cells(4).Value
            Tgeneral = Tsrc + Tsps
            Fila1("CODIGO") = _gridcajasSRC.Rows(i).Cells(0).Value
            Fila1("PRODUCTO") = _gridcajasSRC.Rows(i).Cells(1).Value
            Fila1("SPS") = FormatNumber(Tsps, 2)
            Fila1("SRC") = FormatNumber(Tsrc)
            Fila1("TOTAL") = FormatNumber(Tgeneral)
            Tabla1.Rows.Add(Fila1)
            Fila1 = Tabla1.NewRow
        Next
        _gridResumen.DataSource = Tabla1
        Tgeneral = 0
    End Sub

    Sub LlenarSPS()
        Activador = 0
        For i As Integer = 0 To _gridcajasSPS.RowCount - 1
            Tsps = 0
            Tsrc = 0
            Tgeneral = 0
            For c As Integer = 0 To _gridResumen.RowCount - 1
                If _gridcajasSPS.Rows(i).Cells(0).Value = _gridResumen.Rows(c).Cells(0).Value Then
                    c = _gridResumen.RowCount - 1
                    Activador = 1
                Else
                    Activador = 0
                End If
            Next
            If Activador = 0 Then
                Tsps = _gridcajasSPS.Rows(i).Cells(4).Value
                Tgeneral = Tsps
                Filas2("CODIGO") = _gridcajasSPS.Rows(i).Cells(0).Value
                Filas2("PRODUCTO") = _gridcajasSPS.Rows(i).Cells(1).Value
                Filas2("SPS") = FormatNumber(Tsps)
                Filas2("SRC") = 0
                Filas2("TOTAL") = FormatNumber(Tsps)
                Tabla2.Rows.Add(Filas2)
                Filas2 = Tabla2.NewRow
            End If
        Next
        California()
        _gridResumen.DataSource = Tabla1
        For i As Integer = 0 To _gridResumen.RowCount - 1
            Filas2("CODIGO") = _gridResumen.Rows(i).Cells(0).Value
            Filas2("PRODUCTO") = _gridResumen.Rows(i).Cells(1).Value
            Filas2("SPS") = _gridResumen.Rows(i).Cells(2).Value
            Filas2("SRC") = _gridResumen.Rows(i).Cells(3).Value
            Filas2("TOTAL") = _gridResumen.Rows(i).Cells(4).Value
            Tabla2.Rows.Add(Filas2)
            Filas2 = Tabla2.NewRow
        Next
        _gridFinal.DataSource = Tabla2
        For i As Integer = 0 To _gridFinal.RowCount - 1
            TotalColumnaSPS += _gridFinal.Rows(i).Cells(2).Value
            TotalColumnaSRC += _gridFinal.Rows(i).Cells(3).Value
        Next
        Filas2("CODIGO") = ""
        Filas2("PRODUCTO") = "TOTAL"
        Filas2("SPS") = FormatNumber(TotalColumnaSPS, 2)
        Filas2("SRC") = FormatNumber(TotalColumnaSRC, 2)
        Filas2("TOTAL") = FormatNumber(TotalColumnaSPS + TotalColumnaSRC, 2)
        Tabla2.Rows.Add(Filas2)
        Filas2 = Tabla2.NewRow
        _gridFinal.DataSource = Tabla2
        TotalColumnaSPS = 0
        TotalColumnaSRC = 0
    End Sub

    Sub California()
        If _gridJC1.RowCount >= 0 Then
            For i As Integer = 0 To _gridJC1.RowCount - 1
                If _gridJC1.Rows(i).Cells(0).Value = "SPS" Then
                    TspsCalifornia += _gridJC1.Rows(i).Cells(5).Value
                ElseIf _gridJC1.Rows(i).Cells(0).Value = "SRC" Then
                    TsrcCalifornia += _gridJC1.Rows(i).Cells(5).Value
                End If
                Producto = _gridJC1.Rows(i).Cells(2).Value
                Codigo = _gridJC1.Rows(i).Cells(1).Value
            Next
            TgeneralCalifornia = TspsCalifornia + TsrcCalifornia
            Filas2("CODIGO") = Codigo
            Filas2("PRODUCTO") = Producto
            Filas2("SPS") = TspsCalifornia
            Filas2("SRC") = TsrcCalifornia
            Filas2("TOTAL") = TgeneralCalifornia
            Tabla2.Rows.Add(Filas2)
            Filas2 = Tabla2.NewRow
            TspsCalifornia = 0
            TgeneralCalifornia = 0
            TsrcCalifornia = 0
        End If
        If _gridJC2.RowCount >= 0 Then
            For i As Integer = 0 To _gridJC2.RowCount - 1
                If _gridJC2.Rows(i).Cells(0).Value = "SPS" Then
                    TspsCalifornia += _gridJC2.Rows(i).Cells(5).Value
                ElseIf _gridJC2.Rows(i).Cells(0).Value = "SRC" Then
                    TsrcCalifornia += _gridJC2.Rows(i).Cells(5).Value
                End If
                Producto = _gridJC2.Rows(i).Cells(2).Value
                Codigo = _gridJC2.Rows(i).Cells(1).Value
            Next
            TgeneralCalifornia = TspsCalifornia + TsrcCalifornia
            Filas2("CODIGO") = Codigo
            Filas2("PRODUCTO") = Producto
            Filas2("SPS") = TspsCalifornia
            Filas2("SRC") = TsrcCalifornia
            Filas2("TOTAL") = TgeneralCalifornia
            Tabla2.Rows.Add(Filas2)
            Filas2 = Tabla2.NewRow
            TspsCalifornia = 0
            TgeneralCalifornia = 0
            TsrcCalifornia = 0
        End If
        If _gridJC3.RowCount >= 0 Then
            For i As Integer = 0 To _gridJC3.RowCount - 1
                If _gridJC3.Rows(i).Cells(0).Value = "SPS" Then
                    TspsCalifornia += _gridJC3.Rows(i).Cells(5).Value
                ElseIf _gridJC3.Rows(i).Cells(0).Value = "SRC" Then
                    TsrcCalifornia += _gridJC3.Rows(i).Cells(5).Value
                End If
                Producto = _gridJC3.Rows(i).Cells(2).Value
                Codigo = _gridJC3.Rows(i).Cells(1).Value
            Next
            TgeneralCalifornia = TspsCalifornia + TsrcCalifornia
            Filas2("CODIGO") = Codigo
            Filas2("PRODUCTO") = Producto
            Filas2("SPS") = TspsCalifornia
            Filas2("SRC") = TsrcCalifornia
            Filas2("TOTAL") = TgeneralCalifornia
            Tabla2.Rows.Add(Filas2)
            Filas2 = Tabla2.NewRow
            TspsCalifornia = 0
            TgeneralCalifornia = 0
            TsrcCalifornia = 0
        End If
    End Sub

    Sub Columnas()
        Tabla1.Columns.Add("CODIGO")
        Tabla1.Columns.Add("PRODUCTO")
        Tabla1.Columns.Add("SPS")
        Tabla1.Columns.Add("SRC")
        Tabla1.Columns.Add("TOTAL")

        Tabla2.Columns.Add("CODIGO")
        Tabla2.Columns.Add("PRODUCTO")
        Tabla2.Columns.Add("SPS")
        Tabla2.Columns.Add("SRC")
        Tabla2.Columns.Add("TOTAL")
    End Sub

    Private Sub Cajas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Columnas()
        inicializardate()
    End Sub

    Sub limpiar()
        For c = 0 To _gridResumen.RowCount - 1
            Tabla1.Clear()
        Next
        For c = 0 To _gridFinal.RowCount - 1
            Tabla2.Clear()
        Next
        _gridJC1.DataSource = Nothing
        _gridJC2.DataSource = Nothing
        _gridJC3.DataSource = Nothing
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Hoja"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1").Value = "-----------------"
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet.Cells.Range("A1").Select()
            Try
                wSheet.Paste()
            Catch ex As Exception
            End Try
            wSheet.Cells(1, 4).value = "FECHA REALIZADO"
            wSheet.Cells(1, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(1, 4).style = "Reportes"
            wSheet.Cells(2, 4).value = "DIAS TRABAJADOS"
            wSheet.Cells(2, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(2, 4).style = "Reportes"
            wSheet.Cells(3, 4).value = "DIAS MENSUALES"
            wSheet.Cells(3, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(3, 4).style = "Reportes"
            wSheet.Cells(4, 4).value = "PROYECCION SRC"
            wSheet.Cells(4, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(4, 4).style = "Reportes"
            wSheet.Cells(5, 4).value = "PROYECCION SPS"
            wSheet.Cells(5, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(5, 4).style = "Reportes"
            wSheet.Cells(6, 4).value = "PROYECCION DISAR"
            wSheet.Cells(6, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(6, 4).style = "Reportes"

            wSheet.Cells(1, 5).value = Today.Date
            wSheet.Cells(1, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(2, 5).value = DiasT.Text
            wSheet.Cells(2, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(3, 5).value = DiasM.Text
            wSheet.Cells(3, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(4, 5).value = FormatNumber(_gridFinal.Rows(_gridFinal.RowCount - 1).Cells(3).Value / Val(DiasT.Text) * Val(DiasM.Text), 2)
            wSheet.Cells(4, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(5, 5).value = FormatNumber(_gridFinal.Rows(_gridFinal.RowCount - 1).Cells(2).Value / Val(DiasT.Text) * Val(DiasM.Text), 2)
            wSheet.Cells(5, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(6, 5).value = FormatNumber(_gridFinal.Rows(_gridFinal.RowCount - 1).Cells(4).Value / Val(DiasT.Text) * Val(DiasM.Text), 2)
            wSheet.Cells(6, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("A8:E8").Merge()
            wSheet.Cells.Range("A8:E8").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A8:E8").Value = "REPORTE DE CAJAS DE LIVSMART AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A8:E8").Style = "Reportes"


            For c As Integer = 0 To _gridFinal.Columns.Count - 1
                wSheet.Cells(9, c + 1).value = _gridFinal.Columns(c).HeaderText
                wSheet.Cells(9, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridFinal.RowCount - 1
                For c As Integer = 0 To _gridFinal.Columns.Count - 1
                    wSheet.Cells(r + 10, c + 1).value = _gridFinal.Item(c, r).Value
                    wSheet.Cells(r + 10, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 10, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 10, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    If r = _gridFinal.RowCount - 1 Then
                        wSheet.Cells(r + 10, c + 1).Style = "Reportes"
                    End If
                Next
                
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Sub inicializardate()
        _cmbFechai.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            _cmbFechaf.Value = Today
        Else
            _cmbFechaf.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub
     
End Class