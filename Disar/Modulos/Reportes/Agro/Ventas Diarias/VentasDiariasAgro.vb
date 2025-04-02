Imports Disar.data

Public Class VentasDiariasAgro
    Dim daysT, daysM, daysR, contador, Cantidad_Dias, ContadorFilas, CFilas As Integer
    Dim FechaTemp As Date
    Dim Conexion As New cls_ventas_diarias_agro '
    Dim Presupuesto As New clsPresupuestos
    Dim Tablas As New DataTable
    Dim Filas As DataRow = Tablas.NewRow
    Dim style, estilo2 As Microsoft.Office.Interop.Excel.Style

    Private Sub VentasDiariasAgro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicializardate()
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
                If _cmbFechai.Value.Month = 12 Then
                    daysM = daysM - 1
                    daysT = daysT - 1
                End If
                If _cmbFechai.Value.Month = 1 Then
                    daysM = daysM - 1
                    daysT = daysT - 1
                End If
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
            PorcentajeFinal.Text = FormatPercent((daysT / daysM), 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        If _cmbFechaf.Value.Date < _cmbFechai.Value.Date Then
            MessageBox.Show("La fecha inicial no puede ser mayor a la final", "Fechas Incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            CalculoDias()
            ColumnasDias()
            Cargar()
            ListarVentaDiaria()
        End If
    End Sub

    Sub Cargar()
        Try
            _gridVEOSFINAL.DataSource = Conexion.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "VentasTotalesVEOS", DiasT.Text, DiasM.Text)
        Catch ex As Exception
            MsgBox("Error en Ventas de Veos " + ex.ToString)
        End Try
        Try
            gridoficinas.DataSource = Conexion.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "VentasTotalesOFI", DiasT.Text, DiasM.Text)
        Catch ex As Exception
            MsgBox("Error en Ventas de Oficinas " + ex.ToString)
        End Try
        Try
            _gridresumen.DataSource = Conexion.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "Resumen", DiasT.Text, DiasM.Text)
        Catch ex As Exception
            MsgBox("Error en Resumen General " + ex.ToString)
        End Try
        'Try
        '    _gridCoberturas.DataSource = Conexion.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "srcCOBERTURAS", DiasT.Text, DiasM.Text)
        'Catch ex As Exception
        '    MsgBox("Error en Coberturas " + ex.ToString)
        'End Try
    End Sub

    Sub inicializardate()
        _cmbFechai.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            _cmbFechaf.Value = Today
        Else
            _cmbFechaf.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub

    Sub ColumnasDias()
        Tablas.Clear()
        Tablas.Columns.Clear()
        Tablas.Columns.Add("VENDEDOR")
        For i As Integer = 0 To _cmbFechaf.Value.Day - _cmbFechai.Value.Day
            If __cmbFechai.Value.AddDays(i).Date.DayOfWeek <> DayOfWeek.Sunday Then
                Tablas.Columns.Add(_cmbFechai.Value.AddDays(i).Date)
            End If
        Next
        _gridvd.DataSource = Tablas
    End Sub

    Sub ListarVentaDiaria()
        Try
            Dim Cont As Integer = 0
            gridVendedores.DataSource = Conexion.Ventas(_gridvd.Columns(1).HeaderText, _gridvd.Columns(1).HeaderText, "DetalleVentasDiarias", 0, 0)
            Cont = gridVendedores.RowCount - 1
            For c As Integer = 0 To Cont
                For i As Integer = 1 To _gridvd.ColumnCount - 1
                    gridVendedores.DataSource = Conexion.Ventas(_gridvd.Columns(i).HeaderText, _gridvd.Columns(i).HeaderText, "DetalleVentasDiarias", 0, 0)
                    Filas("VENDEDOR") = gridVendedores.Rows(c).Cells(0).Value
                    Filas(_gridvd.Columns(i).HeaderText) = FormatNumber(gridVendedores.Rows(c).Cells(1).Value, 2)
                Next
                Tablas.Rows.Add(Filas)
                Filas = Tablas.NewRow()
            Next
            _gridvd.DataSource = Tablas
        Catch ex As Exception
            MsgBox("Error al listar el detalle de las ventas")
        End Try
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            ContadorFilas = 0
            CFilas = 0
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet3 As Microsoft.Office.Interop.Excel.Worksheet
            'Dim wSheet2 As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()

            ''coberturas
            'wSheet2 = wBook.ActiveSheet()
            'wSheet2.Name = "Coberturas"

            

            'wSheet2.Cells.Range("A1").Value = ""
            'wSheet2.Cells.Range("A1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            'Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            'wSheet2.Cells.Range("A1").Select()
            'wSheet2.Cells.Range("F3:H3").Merge()
            'wSheet2.Cells.Range("F3:H3").Value = "COBERTURAS"
            'wSheet2.Cells.Range("F3:H3").Font.Size = 14
            'wSheet2.Cells.Range("F3:H3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium)
            'wSheet2.Cells.Range("F3:H3").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            'wSheet2.Cells.Range("F3:h3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            'Try
            '    wSheet2.Paste()
            'Catch ex As Exception
            'End Try

            'For c As Integer = 0 To _gridCoberturas.Columns.Count - 1
            '    wSheet2.Cells(6, c + 1).value = _gridCoberturas.Columns(c).HeaderText
            '    wSheet2.Cells(6, c + 1).Style = "Titulos"
            'Next
            'For r As Integer = 0 To _gridCoberturas.RowCount - 1
            '    For c As Integer = 0 To _gridCoberturas.Columns.Count - 1
            '        wSheet2.Cells(r + 7, c + 1).value = _gridCoberturas.Item(c, r).Value
            '        wSheet2.Cells(r + 7, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            '    Next
            'Next
            'wSheet2.Columns.AutoFit()

            'ventas diarias    
            wSheet3 = wBook.Sheets.Add()
            wSheet3.Name = "Ventas Diarias "

            style = wSheet3.Application.ActiveWorkbook.Styles.Add("Titulos")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet3.Cells.Range("A1").Value = ""
            wSheet3.Cells.Range("A1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet3.Cells.Range("A1").Select()
            wSheet3.Cells.Range("F3:H3").Merge()
            wSheet3.Cells.Range("F3:H3").Value = "VENTAS DIARIAS"
            wSheet3.Cells.Range("F3:H3").Font.Size = 14
            wSheet3.Cells.Range("F3:H3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium)
            wSheet3.Cells.Range("F3:H3").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet3.Cells.Range("F3:H3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            Try
                wSheet3.Paste()
            Catch ex As Exception
            End Try

            For c As Integer = 0 To _gridvd.Columns.Count - 1
                wSheet3.Cells(6, c + 1).value = "  " + _gridvd.Columns(c).HeaderText + "  "
                wSheet3.Cells(6, c + 1).Style = "Titulos"
            Next
            For r As Integer = 0 To _gridvd.RowCount - 1
                For c As Integer = 0 To _gridvd.Columns.Count - 1
                    If c > 0 Then
                        wSheet3.Cells(r + 7, c + 1).value = FormatNumber(_gridvd.Item(c, r).Value)
                    Else
                        wSheet3.Cells(r + 7, c + 1).value = _gridvd.Item(c, r).Value
                    End If

                    wSheet3.Cells(r + 7, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet3.Columns.AutoFit()

            wSheet = wBook.Sheets.Add()
            wSheet.Name = "Cuadro de Ventas"
            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            estilo2 = wSheet.Application.ActiveWorkbook.Styles.Add("Titulo")
            estilo2.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            estilo2.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            estilo2.Font.Bold = True

            wSheet.Cells.Range("A1").Value = "---------------------------------------------------"
            wSheet.Cells.Range("A1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet.Cells.Range("A1").Select()
            wSheet.Cells.Range("B3:D3").Merge()
            wSheet.Cells.Range("B3:D3").Value = "VENTAS"
            wSheet.Cells.Range("B3:D3").Font.Size = 14
            wSheet.Cells.Range("B3:D3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium)
            wSheet.Cells.Range("B3:D3").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("B3:D3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            Try
                wSheet.Paste()
            Catch ex As Exception
            End Try
            wSheet.Cells(1, 6).value = "FECHA REALIZADO"
            wSheet.Cells(1, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(1, 6).style = "Titulo"
            wSheet.Cells(2, 6).value = "DIAS TRABAJADOS"
            wSheet.Cells(2, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(2, 6).style = "Titulo"
            wSheet.Cells(3, 6).value = "DIAS MENSUALES"
            wSheet.Cells(3, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(3, 6).style = "Titulo"
            wSheet.Cells(4, 6).value = "DIAS RESTANTES"
            wSheet.Cells(4, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(4, 6).style = "Titulo"
            wSheet.Cells(5, 6).value = "% IDEAL"
            wSheet.Cells(5, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(5, 6).style = "Titulo"

            wSheet.Cells.Range("A7:G7").Merge()
            wSheet.Cells.Range("A7:G7").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A7:G7").Value = "DETALLE VEO'S" 'AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A7:G7").Style = "Reportes"
            wSheet.Cells(1, 7).value = Today.Date
            wSheet.Cells(1, 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(2, 7).value = DiasT.Text
            wSheet.Cells(2, 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(3, 7).value = DiasM.Text
            wSheet.Cells(3, 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(4, 7).value = DiasR.Text
            wSheet.Cells(4, 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(5, 7).value = FormatPercent((Porcentaje.Text) / 100)
            wSheet.Cells(5, 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            ContadorFilas = 11

            For c As Integer = 0 To _gridVEOSFINAL.Columns.Count - 1
                wSheet.Cells(8, c + 1).value = _gridVEOSFINAL.Columns(c).HeaderText
                wSheet.Cells(8, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridVEOSFINAL.RowCount - 1
                For c As Integer = 0 To _gridVEOSFINAL.Columns.Count - 1
                    wSheet.Cells(r + 9, c + 1).value = _gridVEOSFINAL.Item(c, r).Value
                    wSheet.Cells(r + 9, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = _gridVEOSFINAL.RowCount - 1 Then
                        wSheet.Cells(r + 9, c + 1).font.Size = 11
                        wSheet.Cells(r + 9, c + 1).font.bold = True
                        wSheet.Cells(r + 9, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.DarkGreen)
                        wSheet.Cells(r + 9, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next
                ContadorFilas += 1

            Next
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Merge()
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Value = "DETALLE SALAS DE VENTA" 'AL "' + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Style = "Reportes"
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Merge()
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Borders.LineStyle = BorderStyle.FixedSingle

            For c As Integer = 0 To gridoficinas.Columns.Count - 1
                wSheet.Cells(ContadorFilas + 1, c + 1).value = gridoficinas.Columns(c).HeaderText
                wSheet.Cells(ContadorFilas + 1, c + 1).Style = "Reportes"
            Next
            ContadorFilas += 2
            For r As Integer = 0 To gridoficinas.RowCount - 1
                For c As Integer = 0 To gridoficinas.Columns.Count - 1
                    wSheet.Cells(r + ContadorFilas, c + 1).value = gridoficinas.Item(c, r).Value
                    wSheet.Cells(r + ContadorFilas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = gridoficinas.RowCount - 1 Then
                        wSheet.Cells(r + ContadorFilas, c + 1).font.Size = 11
                        wSheet.Cells(r + ContadorFilas, c + 1).font.bold = True
                        wSheet.Cells(r + ContadorFilas, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.DarkGreen)
                        wSheet.Cells(r + ContadorFilas, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next
                CFilas += 1
            Next
            CFilas += ContadorFilas - 1

            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Merge()
            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Value = "RESUMEN SR AGRO" ' + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Style = "Reportes"
            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Merge()
            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Borders.LineStyle = BorderStyle.FixedSingle

            CFilas += 1
            For c As Integer = 0 To _gridResumen.Columns.Count - 1
                wSheet.Cells(CFilas + 3, c + 1).value = _gridResumen.Columns(c).HeaderText
                wSheet.Cells(CFilas + 3, c + 1).Style = "Reportes"
            Next

            CFilas += 3
            For r As Integer = 0 To _gridResumen.RowCount - 1
                For c As Integer = 0 To _gridResumen.Columns.Count - 1
                    wSheet.Cells(r + CFilas + 1, c + 1).value = _gridResumen.Item(c, r).Value
                    wSheet.Cells(r + CFilas + 1, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = _gridResumen.RowCount - 1 Then
                        wSheet.Cells(r + CFilas + 1, c + 1).font.Size = 11
                        wSheet.Cells(r + CFilas + 1, c + 1).font.bold = True
                        wSheet.Cells(r + CFilas + 1, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.DarkGreen)
                        wSheet.Cells(r + CFilas + 1, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next

            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error al exportar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

     
End Class