Imports Disar.data
Public Class VentasDiarias2

    Dim Clase2 As New cls_cuadro_ventas_diarias
    Dim ClasePresu As New clsPresupuestos
    Dim Tabla1, Tabla2, Tabla3, Tabla4, Tabla5, TablaVentasDiariasSRC, TablaVentasDiariasSPS, TablaVentasDiariasTOCOA, TablaVentasDiariasTegucigalpa As New DataTable
    Dim Filas1 As DataRow = Tabla1.NewRow()
    Dim Filas2 As DataRow = Tabla2.NewRow()
    Dim filas3 As DataRow = Tabla3.NewRow()
    Dim filas4 As DataRow = Tabla4.NewRow()
    Dim filas5 As DataRow = Tabla5.NewRow()
    Dim filas6 As DataRow = TablaVentasDiariasSRC.NewRow()
    Dim filas7 As DataRow = TablaVentasDiariasSPS.NewRow()
    Dim filas8 As DataRow = TablaVentasDiariasTOCOA.NewRow()
    Dim filas9 As DataRow = TablaVentasDiariasTegucigalpa.NewRow()

    Dim Tot, devo, presu, division, TPresu, TVenta, tpDET, tvDET, tpMAY, tvMAY As Double
    Dim FechaTemp As Date
    Dim style, estilo2 As Microsoft.Office.Interop.Excel.Style
    Dim daysT, daysM, daysR, contador, Cantidad_Dias, ContadorFilas, CFilas As Integer
    Private Sub VentasDiarias2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicializardate()
    End Sub

    Sub limpiar()
        Tabla1.Clear()
        Tabla2.Clear()
        Tabla3.Clear()
        Tabla5.Clear()
        Tabla4.Clear()
        TablaVentasDiariasSPS.Clear()
        TablaVentasDiariasSRC.Clear()
        TablaVentasDiariasTOCOA.Clear()
        TablaVentasDiariasSPS.Columns.Clear()
        TablaVentasDiariasSRC.Columns.Clear()
        TablaVentasDiariasTOCOA.Columns.Clear()
        TablaVentasDiariasTegucigalpa.Columns.Clear()
        _gridVentas.DataSource = Nothing
        _gridDevos.DataSource = Nothing
        _gridVentasDiariasDetalle.DataSource = Nothing
    End Sub

    Sub inicializardate()
        _cmbFechai.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            _cmbFechaf.Value = Today
        Else
            _cmbFechaf.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub

    Sub CalculoDias()
        Try
            daysT = 0
            daysM = 0
            daysR = 0
            contador = _cmbFechaf.Value.Day
            Dim domingos As Integer = 0

            For j As Integer = 1 To contador
                FechaTemp = j & "/" & _cmbFechaf.Value.Month & "/" & _cmbFechaf.Value.Year
                If FechaTemp.DayOfWeek = DayOfWeek.Sunday Then
                    domingos += 1
                End If

            Next


            If _cmbFechai.Value.Month = _cmbFechaf.Value.Month Then
                Cantidad_Dias = DateTime.DaysInMonth(_cmbFechaf.Value.Year, _cmbFechaf.Value.Month)

                For i As Integer = 1 To Cantidad_Dias
                    FechaTemp = i & "/" & _cmbFechaf.Value.Month & "/" & _cmbFechaf.Value.Year
                    If FechaTemp.DayOfWeek <> DayOfWeek.Sunday Then
                        daysM += 1
                    End If
                Next
            End If
            For j As Integer = 1 To contador - domingos
                daysT += 1
            Next

            If _cmbFechaf.Value.Year >= 2017 And _cmbFechaf.Value.Month = 12 Then
                daysM = daysM - 1

                If _cmbFechaf.Value.Day >= 24 Then
                    daysT = daysT - 1
                End If



                daysR = (daysM - daysT)
                DiasM.Text = daysM
                DiasT.Text = daysT
                DiasR.Text = daysR
                Porcentaje.Text = ((daysT) / (daysM)) * 100
                PorcentajeFinal.Text = FormatPercent(daysT / daysM)
            ElseIf _cmbFechaf.Value.Year >= 2018 And _cmbFechaf.Value.Month = 3 Then
                daysM = daysM - 3
                If _cmbFechaf.Value.Day >= 29 Then
                    daysT = daysT - 3
                End If
                daysR = (daysM - daysT)
                DiasM.Text = daysM
                DiasT.Text = daysT
                DiasR.Text = daysR
                Porcentaje.Text = ((daysT) / (daysM)) * 100
                PorcentajeFinal.Text = FormatPercent(daysT / daysM)
            Else
                daysR = (daysM) - (daysT)
                DiasM.Text = daysM
                DiasT.Text = daysT
                DiasR.Text = daysR
                Porcentaje.Text = ((daysT) / (daysM)) * 100
                PorcentajeFinal.Text = FormatPercent(daysT / daysM)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub Exportar()
        Try
            ContadorFilas = 0
            CFilas = 0
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet2 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet3 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet4 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet5 As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()

            'tegucigalpa
            wSheet5 = wBook.ActiveSheet()
            wSheet5 = wBook.Sheets.Add()
            wSheet5.Name = "VENTAS DIARIAS TEGUCIGALPA"

            style = wSheet5.Application.ActiveWorkbook.Styles.Add("EstiloVDTegucigalpa")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            For c As Integer = 0 To grd_VDG.Columns.Count - 1
                If c = 0 Then
                    wSheet5.Cells(1, c + 1).value = grd_VDG.Columns(c).HeaderText
                    wSheet5.Cells(1, c + 1).Style = "EstiloVDTegucigalpa"
                Else
                    wSheet5.Cells(1, c + 1).value = "  " + grd_VDG.Columns(c).HeaderText + "  "
                    wSheet5.Cells(1, c + 1).Style = "EstiloVDTegucigalpa"
                End If
            Next
            For r As Integer = 0 To grd_VDG.RowCount - 1
                For c As Integer = 0 To grd_VDG.Columns.Count - 1
                    wSheet5.Cells(r + 2, c + 1).value = grd_VDG.Item(c, r).Value
                    wSheet5.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet5.Cells(r + 2, c + 1).font.Size = 11
                Next
            Next
            wSheet5.Columns.AutoFit()


            'tocoa
            wSheet4 = wBook.ActiveSheet()
            wSheet4 = wBook.Sheets.Add()
            wSheet4.Name = "VENTAS DIARIAS TOCOA"

            style = wSheet4.Application.ActiveWorkbook.Styles.Add("EstiloVDTocoa")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            For c As Integer = 0 To grd_VDT.Columns.Count - 1
                If c = 0 Then
                    wSheet4.Cells(1, c + 1).value = grd_VDT.Columns(c).HeaderText
                    wSheet4.Cells(1, c + 1).Style = "EstiloVDTocoa"
                Else
                    wSheet4.Cells(1, c + 1).value = "  " + grd_VDT.Columns(c).HeaderText + "  "
                    wSheet4.Cells(1, c + 1).Style = "EstiloVDTocoa"
                End If
            Next
            For r As Integer = 0 To grd_VDT.RowCount - 1
                For c As Integer = 0 To grd_VDT.Columns.Count - 1
                    wSheet4.Cells(r + 2, c + 1).value = grd_VDT.Item(c, r).Value
                    wSheet4.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet4.Cells(r + 2, c + 1).font.Size = 11
                Next
            Next
            wSheet4.Columns.AutoFit()

            'src
            wSheet2 = wBook.Sheets.Add()
            wSheet2.Name = "VENTAS DIARIAS SRC"

            style = wSheet2.Application.ActiveWorkbook.Styles.Add("EstiloVDSRC")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            For c As Integer = 0 To _gridVDSRC.Columns.Count - 1
                If c = 0 Then
                    wSheet2.Cells(1, c + 1).value = _gridVDSRC.Columns(c).HeaderText
                    wSheet2.Cells(1, c + 1).Style = "EstiloVDSRC"
                Else
                    wSheet2.Cells(1, c + 1).value = "  " + _gridVDSRC.Columns(c).HeaderText + "  "
                    wSheet2.Cells(1, c + 1).Style = "EstiloVDSRC"
                End If
            Next
            For r As Integer = 0 To _gridVDSRC.RowCount - 1
                For c As Integer = 0 To _gridVDSRC.Columns.Count - 1
                    wSheet2.Cells(r + 2, c + 1).value = _gridVDSRC.Item(c, r).Value
                    wSheet2.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet2.Cells(r + 2, c + 1).font.Size = 11
                Next
            Next
            wSheet2.Columns.AutoFit()

            'sps    
            wSheet3 = wBook.Sheets.Add()
            wSheet3.Name = "VENTAS DIARIAS SPS"

            style = wSheet3.Application.ActiveWorkbook.Styles.Add("EstiloVDSPS")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            For c As Integer = 0 To _gridVDSPS.Columns.Count - 1
                wSheet3.Cells(1, c + 1).value = "  " + _gridVDSPS.Columns(c).HeaderText + "  "
                wSheet3.Cells(1, c + 1).Style = "EstiloVDSRC"
            Next
            For r As Integer = 0 To _gridVDSPS.RowCount - 1
                For c As Integer = 0 To _gridVDSPS.Columns.Count - 1
                    wSheet3.Cells(r + 2, c + 1).value = _gridVDSPS.Item(c, r).Value
                    wSheet3.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next

            wSheet3.Columns.AutoFit()

            wSheet = wBook.Sheets.Add()

            wSheet.Name = "VENTAS DIARIAS"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("NewStyle")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            estilo2 = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo2")
            estilo2.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            estilo2.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            estilo2.Font.Bold = True

            wSheet.Cells.Range("A1").Value = "----------------------------------------"
            wSheet.Cells.Range("A1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet.Cells.Range("A1").Select()
            Try
                wSheet.Paste()
            Catch ex As Exception
            End Try
            wSheet.Cells(1, 6).value = "FECHA REALIZADO"
            wSheet.Cells(1, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(1, 6).style = "Estilo2"
            wSheet.Cells(2, 6).value = "DIAS TRABAJADOS"
            wSheet.Cells(2, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(2, 6).style = "Estilo2"
            wSheet.Cells(3, 6).value = "DIAS MENSUALES"
            wSheet.Cells(3, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(3, 6).style = "Estilo2"
            wSheet.Cells(4, 6).value = "DIAS RESTANTES"
            wSheet.Cells(4, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(4, 6).style = "Estilo2"
            wSheet.Cells(5, 6).value = "% IDEAL"
            wSheet.Cells(5, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells(5, 6).style = "Estilo2"

            wSheet.Cells.Range("A7:G7").Merge()
            wSheet.Cells.Range("A7:G7").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A7:G7").Value = "VENTAS SANTA ROSA DE COPAN AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A7:G7").Style = "NewStyle"
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

            For c As Integer = 0 To _gridVentasDiariasSRC.Columns.Count - 1
                wSheet.Cells(8, c + 1).value = _gridVentasDiariasSRC.Columns(c).HeaderText
                wSheet.Cells(8, c + 1).Style = "NewStyle"
            Next
            For r As Integer = 0 To _gridVentasDiariasSRC.RowCount - 1
                For c As Integer = 0 To _gridVentasDiariasSRC.Columns.Count - 1
                    wSheet.Cells(r + 9, c + 1).value = _gridVentasDiariasSRC.Item(c, r).Value
                    wSheet.Cells(r + 9, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = _gridVentasDiariasSRC.RowCount - 1 Then
                        wSheet.Cells(r + 9, c + 1).font.Size = 11
                        wSheet.Cells(r + 9, c + 1).font.bold = True
                        wSheet.Cells(r + 9, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                        wSheet.Cells(r + 9, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next
                ContadorFilas += 1

            Next
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Merge()
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Value = "RESUMEN SUCURSAL SANTA ROSA DE COPAN VENTAS AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Style = "NewStyle"
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Merge()
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Borders.LineStyle = BorderStyle.FixedSingle

            For c As Integer = 0 To gridRSRC.Columns.Count - 1
                wSheet.Cells(ContadorFilas + 1, c + 1).value = gridRSRC.Columns(c).HeaderText
                wSheet.Cells(ContadorFilas + 1, c + 1).Style = "NewStyle"
            Next
            ContadorFilas += 2
            For r As Integer = 0 To gridRSRC.RowCount - 1
                For c As Integer = 0 To gridRSRC.Columns.Count - 1
                    wSheet.Cells(r + ContadorFilas, c + 1).value = gridRSRC.Item(c, r).Value
                    wSheet.Cells(r + ContadorFilas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = gridRSRC.RowCount - 1 Then
                        wSheet.Cells(r + ContadorFilas, c + 1).font.Size = 11
                        wSheet.Cells(r + ContadorFilas, c + 1).font.bold = True
                        wSheet.Cells(r + ContadorFilas, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                        wSheet.Cells(r + ContadorFilas, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next
                CFilas += 1
            Next
            ContadorFilas += CFilas + 2
            CFilas = 0
            '---------------------------------
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Merge()
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Value = "VENTAS SAN PEDRO SULA AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Style = "NewStyle"
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Merge()
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Borders.LineStyle = BorderStyle.FixedSingle


            For c As Integer = 0 To _gridVentasDiariasSRC.Columns.Count - 1
                wSheet.Cells(ContadorFilas + 2, c + 1).value = _gridVentasDiariasSRC.Columns(c).HeaderText
                wSheet.Cells(ContadorFilas + 2, c + 1).Style = "NewStyle"
            Next

            ContadorFilas += 3

            For r As Integer = 0 To _gridVentasDiariasSPS.RowCount - 1
                For c As Integer = 0 To _gridVentasDiariasSPS.Columns.Count - 1
                    wSheet.Cells(r + ContadorFilas, c + 1).value = _gridVentasDiariasSPS.Item(c, r).Value
                    wSheet.Cells(r + ContadorFilas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = _gridVentasDiariasSPS.RowCount - 1 Then
                        wSheet.Cells(r + ContadorFilas, c + 1).font.Size = 11
                        wSheet.Cells(r + ContadorFilas, c + 1).font.bold = True
                        wSheet.Cells(r + ContadorFilas, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                        wSheet.Cells(r + ContadorFilas, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next
                CFilas += 1
            Next

            ContadorFilas += CFilas + 2
            CFilas = 0

            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Merge()
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Value = "RESUMEN SUCURSAL SAN PEDRO SULA VENTAS AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Style = "NewStyle"
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Merge()
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Borders.LineStyle = BorderStyle.FixedSingle

            For c As Integer = 0 To gridRSPS.Columns.Count - 1
                wSheet.Cells(ContadorFilas + 1, c + 1).value = gridRSPS.Columns(c).HeaderText
                wSheet.Cells(ContadorFilas + 1, c + 1).Style = "NewStyle"
            Next
            ContadorFilas += 2
            For r As Integer = 0 To gridRSPS.RowCount - 1
                For c As Integer = 0 To gridRSPS.Columns.Count - 1
                    wSheet.Cells(r + ContadorFilas, c + 1).value = gridRSPS.Item(c, r).Value
                    wSheet.Cells(r + ContadorFilas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = gridRSPS.RowCount - 1 Then
                        wSheet.Cells(r + ContadorFilas, c + 1).font.Size = 11
                        wSheet.Cells(r + ContadorFilas, c + 1).font.bold = True
                        wSheet.Cells(r + ContadorFilas, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                        wSheet.Cells(r + ContadorFilas, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next
                CFilas += 1
            Next

            'TOCOA
            ContadorFilas += CFilas + 2
            CFilas = 0

            '---------------------------------
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Merge()
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Value = "VENTAS TOCOA AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Style = "NewStyle"
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Merge()
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Borders.LineStyle = BorderStyle.FixedSingle


            For c As Integer = 0 To grd_tocoa.Columns.Count - 1
                wSheet.Cells(ContadorFilas + 2, c + 1).value = grd_tocoa.Columns(c).HeaderText
                wSheet.Cells(ContadorFilas + 2, c + 1).Style = "NewStyle"
            Next

            ContadorFilas += 3

            For r As Integer = 0 To grd_tocoa.RowCount - 1
                For c As Integer = 0 To grd_tocoa.Columns.Count - 1
                    wSheet.Cells(r + ContadorFilas, c + 1).value = grd_tocoa.Item(c, r).Value
                    wSheet.Cells(r + ContadorFilas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = grd_tocoa.RowCount - 1 Then
                        wSheet.Cells(r + ContadorFilas, c + 1).font.Size = 11
                        wSheet.Cells(r + ContadorFilas, c + 1).font.bold = True
                        wSheet.Cells(r + ContadorFilas, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                        wSheet.Cells(r + ContadorFilas, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next
                CFilas += 1
            Next

            ContadorFilas += CFilas + 2
            CFilas = 0

            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Merge()
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Value = "RESUMEN SUCURSAL TOCOA VENTAS AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Style = "NewStyle"
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Merge()
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Borders.LineStyle = BorderStyle.FixedSingle

            For c As Integer = 0 To grd_resumen_tocoa.Columns.Count - 1
                wSheet.Cells(ContadorFilas + 1, c + 1).value = grd_resumen_tocoa.Columns(c).HeaderText
                wSheet.Cells(ContadorFilas + 1, c + 1).Style = "NewStyle"
            Next
            ContadorFilas += 2
            For r As Integer = 0 To grd_resumen_tocoa.RowCount - 1
                For c As Integer = 0 To grd_resumen_tocoa.Columns.Count - 1
                    wSheet.Cells(r + ContadorFilas, c + 1).value = grd_resumen_tocoa.Item(c, r).Value
                    wSheet.Cells(r + ContadorFilas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = grd_resumen_tocoa.RowCount - 1 Then
                        wSheet.Cells(r + ContadorFilas, c + 1).font.Size = 11
                        wSheet.Cells(r + ContadorFilas, c + 1).font.bold = True
                        wSheet.Cells(r + ContadorFilas, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                        wSheet.Cells(r + ContadorFilas, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next
                CFilas += 1
            Next
            'ContadorFilas += CFilas
            'CFilas = 0
            'CFilas += ContadorFilas
            'FIN TOCOA

            'TEG
            ContadorFilas += CFilas + 2
            CFilas = 0

            '---------------------------------
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Merge()
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Value = "VENTAS TEGUCIGALPA AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Style = "NewStyle"
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Merge()
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Borders.LineStyle = BorderStyle.FixedSingle


            For c As Integer = 0 To grdTeg.Columns.Count - 1
                wSheet.Cells(ContadorFilas + 2, c + 1).value = grdTeg.Columns(c).HeaderText
                wSheet.Cells(ContadorFilas + 2, c + 1).Style = "NewStyle"
            Next

            ContadorFilas += 3

            For r As Integer = 0 To grdTeg.RowCount - 1
                For c As Integer = 0 To grdTeg.Columns.Count - 1
                    wSheet.Cells(r + ContadorFilas, c + 1).value = grdTeg.Item(c, r).Value
                    wSheet.Cells(r + ContadorFilas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = grdTeg.RowCount - 1 Then
                        wSheet.Cells(r + ContadorFilas, c + 1).font.Size = 11
                        wSheet.Cells(r + ContadorFilas, c + 1).font.bold = True
                        wSheet.Cells(r + ContadorFilas, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                        wSheet.Cells(r + ContadorFilas, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next
                CFilas += 1
            Next

            ContadorFilas += CFilas + 2
            CFilas = 0

            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Merge()
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Value = "RESUMEN SUCURSAL TEGUCIGALPA VENTAS AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Style = "NewStyle"
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Merge()
            wSheet.Cells.Range("A" & ContadorFilas & ":G" & ContadorFilas).Borders.LineStyle = BorderStyle.FixedSingle

            For c As Integer = 0 To grd_resumen_tocoa.Columns.Count - 1
                wSheet.Cells(ContadorFilas + 1, c + 1).value = grd_Resumen_Teg.Columns(c).HeaderText
                wSheet.Cells(ContadorFilas + 1, c + 1).Style = "NewStyle"
            Next
            ContadorFilas += 2
            For r As Integer = 0 To grd_Resumen_Teg.RowCount - 1
                For c As Integer = 0 To grd_Resumen_Teg.Columns.Count - 1
                    wSheet.Cells(r + ContadorFilas, c + 1).value = grd_Resumen_Teg.Item(c, r).Value
                    wSheet.Cells(r + ContadorFilas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = grd_Resumen_Teg.RowCount - 1 Then
                        wSheet.Cells(r + ContadorFilas, c + 1).font.Size = 11
                        wSheet.Cells(r + ContadorFilas, c + 1).font.bold = True
                        wSheet.Cells(r + ContadorFilas, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                        wSheet.Cells(r + ContadorFilas, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next
                CFilas += 1
            Next
            ContadorFilas += CFilas
            CFilas = 0
            CFilas += ContadorFilas
            'FIN TEG



            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Merge()
            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Value = "RESUMEN DE VENTAS GENERAL AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Style = "NewStyle"
            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Merge()
            wSheet.Cells.Range("A" & CFilas + 3 & ":G" & CFilas + 3).Borders.LineStyle = BorderStyle.FixedSingle

            CFilas += 1
            For c As Integer = 0 To _gridResumen.Columns.Count - 1
                wSheet.Cells(CFilas + 3, c + 1).value = _gridResumen.Columns(c).HeaderText
                wSheet.Cells(CFilas + 3, c + 1).Style = "NewStyle"
            Next

            CFilas += 3
            For r As Integer = 0 To _gridResumen.RowCount - 1
                For c As Integer = 0 To _gridResumen.Columns.Count - 1
                    wSheet.Cells(r + CFilas + 1, c + 1).value = _gridResumen.Item(c, r).Value
                    wSheet.Cells(r + CFilas + 1, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = _gridResumen.RowCount - 1 Then
                        wSheet.Cells(r + CFilas + 1, c + 1).font.Size = 11
                        wSheet.Cells(r + CFilas + 1, c + 1).font.bold = True
                        wSheet.Cells(r + CFilas + 1, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                        wSheet.Cells(r + CFilas + 1, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next
            Next

            ContadorFilas += 9
            'proyectos nuevos
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Merge()
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Value = "VENTAS PROYECTOS NUEVOS AL " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Style = "NewStyle"
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Merge()
            wSheet.Cells.Range("A" & ContadorFilas + 1 & ":G" & ContadorFilas + 1).Borders.LineStyle = BorderStyle.FixedSingle
            ContadorFilas += 2

            For r As Integer = 0 To grd_ventas_proyectos_nuevos.RowCount - 1
                For c As Integer = 0 To grd_ventas_proyectos_nuevos.Columns.Count - 1
                    wSheet.Cells(r + ContadorFilas, c + 1).value = grd_ventas_proyectos_nuevos.Item(c, r).Value
                    wSheet.Cells(r + ContadorFilas, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    If r = grd_ventas_proyectos_nuevos.RowCount - 1 Then
                        wSheet.Cells(r + ContadorFilas, c + 1).font.Size = 11
                        wSheet.Cells(r + ContadorFilas, c + 1).font.bold = True
                        wSheet.Cells(r + ContadorFilas, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                        wSheet.Cells(r + ContadorFilas, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    End If
                Next

            Next
            'fin proyectos nuevos

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error al exportar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ColumnasDias()
        TablaVentasDiariasSRC.Columns.Add("VENDEDOR")
        TablaVentasDiariasSPS.Columns.Add("VENDEDOR")
        TablaVentasDiariasTOCOA.Columns.Add("VENDEDOR")
        TablaVentasDiariasTegucigalpa.Columns.Add("VENDEDOR")

        For i As Integer = 0 To _cmbFechaf.Value.Day - _cmbFechai.Value.Day
            If __cmbFechai.Value.AddDays(i).Date.DayOfWeek <> DayOfWeek.Sunday Then
                TablaVentasDiariasSRC.Columns.Add(_cmbFechai.Value.AddDays(i).Date)
                TablaVentasDiariasSPS.Columns.Add(_cmbFechai.Value.AddDays(i).Date)
                TablaVentasDiariasTOCOA.Columns.Add(_cmbFechai.Value.AddDays(i).Date)
                TablaVentasDiariasTegucigalpa.Columns.Add(_cmbFechai.Value.AddDays(i).Date)
            End If
        Next
        _gridVDSRC.DataSource = TablaVentasDiariasSRC
        _gridVDSPS.DataSource = TablaVentasDiariasSPS
        grd_VDT.DataSource = TablaVentasDiariasTOCOA
        grd_VDG.DataSource = TablaVentasDiariasTegucigalpa
    End Sub

    Private Sub VentasDiariasDetalleSRC()
        Try
            Dim Cont As Integer = 0
            _gridVentasDiariasDetalle.DataSource = Clase2.Ventas(_gridVDSRC.Columns(1).HeaderText, _gridVDSRC.Columns(1).HeaderText, "VDSRC", 1, 1)
            Cont = _gridVentasDiariasDetalle.RowCount - 1

            For c As Integer = 0 To Cont
                For I As Integer = 1 To _gridVDSRC.ColumnCount - 1
                    _gridVentasDiariasDetalle.DataSource = Clase2.Ventas(_gridVDSRC.Columns(I).HeaderText, _gridVDSRC.Columns(I).HeaderText, "VDSRC", 1, 1)
                    filas6("VENDEDOR") = _gridVentasDiariasDetalle.Rows(c).Cells(1).Value
                    filas6(_gridVDSRC.Columns(I).HeaderText) = FormatNumber(_gridVentasDiariasDetalle.Rows(c).Cells(2).Value, 2)
                Next
                TablaVentasDiariasSRC.Rows.Add(filas6)
                filas6 = TablaVentasDiariasSRC.NewRow()
            Next
            _gridVDSRC.DataSource = TablaVentasDiariasSRC
        Catch ex As Exception
            MsgBox("Error al Generar el detalle de Ventas Diarias de SRC " + ex.Message)
        End Try
    End Sub

    Private Sub VentasDiariasDetalleSPS()
        Try
            Dim Cont As Integer = 0
            _gridVentasDiariasDetalle.DataSource = Clase2.Ventas(_gridVDSPS.Columns(1).HeaderText, _gridVDSPS.Columns(1).HeaderText, "VDSPS", 1, 1)
            Cont = _gridVentasDiariasDetalle.RowCount - 1

            For c As Integer = 0 To Cont
                For I As Integer = 1 To _gridVDSPS.ColumnCount - 1
                    _gridVentasDiariasDetalle.DataSource = Clase2.Ventas(_gridVDSPS.Columns(I).HeaderText, _gridVDSPS.Columns(I).HeaderText, "VDSPS", 1, 1)
                    filas7("VENDEDOR") = _gridVentasDiariasDetalle.Rows(c).Cells(1).Value
                    filas7(_gridVDSPS.Columns(I).HeaderText) = FormatNumber(_gridVentasDiariasDetalle.Rows(c).Cells(2).Value, 2)
                Next
                TablaVentasDiariasSPS.Rows.Add(filas7)
                filas7 = TablaVentasDiariasSPS.NewRow()
            Next
            _gridVDSPS.DataSource = TablaVentasDiariasSPS
        Catch ex As Exception
            MsgBox("Error al Generar el Detalle de Ventas diarias de SPS " + ex.Message)
        End Try
    End Sub

    Private Sub VentasDiariasDetalleTOCOA()
        Try
            Dim Cont As Integer = 0
            _gridVentasDiariasDetalle.DataSource = Clase2.Ventas(grd_VDT.Columns(1).HeaderText, _
                                                                 grd_VDT.Columns(1).HeaderText, "VDTOCOA", 1, 1)
            Cont = _gridVentasDiariasDetalle.RowCount - 1

            For c As Integer = 0 To Cont
                For I As Integer = 1 To grd_VDT.ColumnCount - 1
                    _gridVentasDiariasDetalle.DataSource = Clase2.Ventas(grd_VDT.Columns(I).HeaderText, grd_VDT.Columns(I).HeaderText, "VDTOCOA", 1, 1)
                    filas8("VENDEDOR") = _gridVentasDiariasDetalle.Rows(c).Cells(1).Value
                    filas8(grd_VDT.Columns(I).HeaderText) = FormatNumber(_gridVentasDiariasDetalle.Rows(c).Cells(2).Value, 2)
                Next
                TablaVentasDiariasTOCOA.Rows.Add(filas8)
                filas8 = TablaVentasDiariasTOCOA.NewRow()
            Next
            grd_VDT.DataSource = TablaVentasDiariasTOCOA
        Catch ex As Exception
            MsgBox("Error al Generar el Detalle de Ventas diarias de TOCOA " + ex.Message)
        End Try
    End Sub

    Private Sub VentasDiariasDetalleTEG()
        Try
            Dim Cont As Integer = 0
            _gridVentasDiariasDetalle.DataSource = Clase2.Ventas(grd_VDG.Columns(1).HeaderText, _
                                                                 grd_VDG.Columns(1).HeaderText, "VDTEGUCIGALPA", 1, 1)
            Cont = _gridVentasDiariasDetalle.RowCount - 1

            For c As Integer = 0 To Cont
                For I As Integer = 1 To grd_VDT.ColumnCount - 1
                    _gridVentasDiariasDetalle.DataSource = Clase2.Ventas(grd_VDG.Columns(I).HeaderText, grd_VDG.Columns(I).HeaderText, "VDTEGUCIGALPA", 1, 1)
                    filas9("VENDEDOR") = _gridVentasDiariasDetalle.Rows(c).Cells(1).Value
                    filas9(grd_VDG.Columns(I).HeaderText) = FormatNumber(_gridVentasDiariasDetalle.Rows(c).Cells(2).Value, 2)
                Next
                TablaVentasDiariasTegucigalpa.Rows.Add(filas9)
                filas9 = TablaVentasDiariasTegucigalpa.NewRow()
            Next
            grd_VDG.DataSource = TablaVentasDiariasTegucigalpa
        Catch ex As Exception
            MsgBox("Error al Generar el Detalle de Ventas diarias de Tegucigalpa " + ex.Message)
        End Try
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        If _cmbFechaf.Value.Date < _cmbFechai.Value.Date Then
            MessageBox.Show("La fecha inicial no puede ser mayor a la final", "Fechas Incorrectas", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                CalculoDias()
                limpiar()
                ColumnasDias()

                'cuadro de ventas de Santa Rosa
                Dim tabla_src As New DataTable
                Dim tabla_src_agregada As New DataTable
                tabla_src = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, _
                                                                 "SRC", Val(DiasM.Text), Val(DiasT.Text))
                tabla_src_agregada.Columns.Add("NOMBRE")
                tabla_src_agregada.Columns.Add("PRESUPUESTO")
                tabla_src_agregada.Columns.Add("VENTA")
                tabla_src_agregada.Columns.Add("DIFERENCIA")
                tabla_src_agregada.Columns.Add("% ALCANZADO")
                tabla_src_agregada.Columns.Add("L. PROYECCION")
                tabla_src_agregada.Columns.Add("%. PROYECCION")

                Dim fila_src As DataRow
                Dim presupuesto_src As Double = 0
                Dim venta_src As Double = 0
                For index As Integer = 0 To tabla_src.Rows.Count - 1
                    fila_src = tabla_src_agregada.NewRow
                    fila_src("NOMBRE") = tabla_src.Rows(index)(0)
                    fila_src("PRESUPUESTO") = FormatNumber(tabla_src.Rows(index)(1), 2)
                    presupuesto_src += tabla_src.Rows(index)(1)
                    fila_src("VENTA") = FormatNumber(tabla_src.Rows(index)(2), 2)
                    venta_src += tabla_src.Rows(index)(2)
                    fila_src("DIFERENCIA") = FormatNumber(tabla_src.Rows(index)(3), 2)
                    fila_src("% ALCANZADO") = tabla_src.Rows(index)(4)
                    fila_src("L. PROYECCION") = FormatNumber(tabla_src.Rows(index)(5), 2)
                    fila_src("%. PROYECCION") = tabla_src.Rows(index)(6)
                    tabla_src_agregada.Rows.Add(fila_src)
                Next

                fila_src = tabla_src_agregada.NewRow
                fila_src("NOMBRE") = "SAN RAFAEL SRC"
                fila_src("PRESUPUESTO") = FormatNumber(presupuesto_src, 2)
                fila_src("VENTA") = FormatNumber(venta_src, 2)
                fila_src("DIFERENCIA") = FormatNumber(venta_src - presupuesto_src, 2)

                If presupuesto_src > 0 Then
                    fila_src("% ALCANZADO") = FormatNumber((venta_src / presupuesto_src) * 100, 2)
                Else
                    fila_src("% ALCANZADO") = 0
                End If


                If Val(DiasT.Text) > 0 Then
                    fila_src("L. PROYECCION") = FormatNumber(venta_src * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_src("%. PROYECCION") = venta_src * ((Val(DiasM.Text) / Val(DiasT.Text))) / presupuesto_src * 100
                Else
                    fila_src("L. PROYECCION") = 0
                    fila_src("%. PROYECCION") = 0
                End If

                tabla_src_agregada.Rows.Add(fila_src)
                _gridVentasDiariasSRC.DataSource = tabla_src_agregada
                '_gridVentasDiariasSRC.DataSource = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, _
                '                                                 "SRC", Val(DiasM.Text), Val(DiasT.Text))

                Dim tabla_resumen_src As New DataTable
                Dim tabla_resumen_src_agregada As New DataTable
                tabla_resumen_src = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "RESUMEN_SRC", _
                                                    Val(DiasM.Text), Val(DiasT.Text))
                tabla_resumen_src_agregada.Columns.Add("NOMBRE")
                tabla_resumen_src_agregada.Columns.Add("PRESUPUESTO")
                tabla_resumen_src_agregada.Columns.Add("VENTA")
                tabla_resumen_src_agregada.Columns.Add("DIFERENCIA")
                tabla_resumen_src_agregada.Columns.Add("% ALCANZADO")
                tabla_resumen_src_agregada.Columns.Add("L. PROYECCION")
                tabla_resumen_src_agregada.Columns.Add("%. PROYECCION")

                Dim fila_resumen_src As DataRow
                Dim presupuesto_resumen_src As Double = 0
                Dim venta_resumen_src As Double = 0

                For index As Integer = 0 To tabla_resumen_src.Rows.Count - 1
                    fila_resumen_src = tabla_resumen_src_agregada.NewRow
                    fila_resumen_src("NOMBRE") = tabla_resumen_src.Rows(index)(0)
                    fila_resumen_src("PRESUPUESTO") = FormatNumber(tabla_resumen_src.Rows(index)(1), 2)
                    presupuesto_resumen_src += tabla_resumen_src.Rows(index)(1)
                    fila_resumen_src("VENTA") = FormatNumber(tabla_resumen_src.Rows(index)(2), 2)
                    venta_resumen_src += tabla_resumen_src.Rows(index)(2)
                    fila_resumen_src("DIFERENCIA") = FormatNumber(tabla_resumen_src.Rows(index)(3), 2)
                    fila_resumen_src("% ALCANZADO") = tabla_resumen_src.Rows(index)(4)
                    fila_resumen_src("L. PROYECCION") = FormatNumber(tabla_resumen_src.Rows(index)(5), 2)
                    fila_resumen_src("%. PROYECCION") = tabla_resumen_src.Rows(index)(6)
                    tabla_resumen_src_agregada.Rows.Add(fila_resumen_src)
                Next

                fila_resumen_src = tabla_resumen_src_agregada.NewRow
                fila_resumen_src("NOMBRE") = "SAN RAFAEL SRC"
                fila_resumen_src("PRESUPUESTO") = FormatNumber(presupuesto_resumen_src, 2)
                fila_resumen_src("VENTA") = FormatNumber(venta_resumen_src, 2)
                fila_resumen_src("DIFERENCIA") = FormatNumber(venta_resumen_src - presupuesto_resumen_src, 2)

                If presupuesto_src > 0 Then
                    fila_resumen_src("% ALCANZADO") = FormatNumber((venta_resumen_src / presupuesto_resumen_src) * 100, 2)
                Else
                    fila_resumen_src("% ALCANZADO") = 0
                End If


                If Val(DiasT.Text) > 0 Then
                    fila_resumen_src("L. PROYECCION") = FormatNumber(venta_resumen_src * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_resumen_src("%. PROYECCION") = FormatNumber(venta_resumen_src * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        presupuesto_resumen_src * 100, 2)
                Else
                    fila_resumen_src("L. PROYECCION") = 0
                    fila_resumen_src("%. PROYECCION") = 0
                End If

                tabla_resumen_src_agregada.Rows.Add(fila_resumen_src)
                gridRSRC.DataSource = tabla_resumen_src_agregada







                'gridRSRC.DataSource = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "RESUMEN_SRC", _
                '                                    Val(DiasM.Text), Val(DiasT.Text))

                'Fin de cuadro de ventas de Santa Rosa


                'cuadro de ventas de Tegucigalpa
                Dim tabla_tg As New DataTable
                Dim tabla_tg_agregada As New DataTable
                tabla_tg = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, _
                                                                 "TEGUCIGALPA", Val(DiasM.Text), Val(DiasT.Text))
                tabla_tg_agregada.Columns.Add("NOMBRE")
                tabla_tg_agregada.Columns.Add("PRESUPUESTO")
                tabla_tg_agregada.Columns.Add("VENTA")
                tabla_tg_agregada.Columns.Add("DIFERENCIA")
                tabla_tg_agregada.Columns.Add("% ALCANZADO")
                tabla_tg_agregada.Columns.Add("L. PROYECCION")
                tabla_tg_agregada.Columns.Add("%. PROYECCION")

                Dim fila_tg As DataRow
                Dim presupuesto_tg As Double = 0
                Dim venta_tg As Double = 0
                For index As Integer = 0 To tabla_tg.Rows.Count - 1
                    fila_tg = tabla_tg_agregada.NewRow
                    fila_tg("NOMBRE") = tabla_tg.Rows(index)(0)
                    fila_tg("PRESUPUESTO") = FormatNumber(tabla_tg.Rows(index)(1), 2)
                    presupuesto_tg += tabla_tg.Rows(index)(1)
                    fila_tg("VENTA") = FormatNumber(tabla_tg.Rows(index)(2), 2)
                    venta_tg += tabla_tg.Rows(index)(2)
                    fila_tg("DIFERENCIA") = FormatNumber(tabla_tg.Rows(index)(3), 2)
                    fila_tg("% ALCANZADO") = tabla_tg.Rows(index)(4)
                    fila_tg("L. PROYECCION") = FormatNumber(tabla_tg.Rows(index)(5), 2)
                    fila_tg("%. PROYECCION") = tabla_tg.Rows(index)(6)
                    tabla_tg_agregada.Rows.Add(fila_tg)
                Next

                fila_tg = tabla_tg_agregada.NewRow
                fila_tg("NOMBRE") = "SAN RAFAEL TEGUCIGALPA"
                fila_tg("PRESUPUESTO") = FormatNumber(presupuesto_tg, 2)
                fila_tg("VENTA") = FormatNumber(venta_tg, 2)
                fila_tg("DIFERENCIA") = FormatNumber(venta_tg - presupuesto_tg, 2)

                If presupuesto_tg > 0 Then
                    fila_tg("% ALCANZADO") = FormatNumber((venta_tg / presupuesto_tg) * 100, 2)
                Else
                    fila_tg("% ALCANZADO") = 0
                End If


                If Val(DiasT.Text) > 0 Then
                    fila_tg("L. PROYECCION") = FormatNumber(venta_tg * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_tg("%. PROYECCION") = venta_tg * ((Val(DiasM.Text) / Val(DiasT.Text))) / presupuesto_tg * 100
                Else
                    fila_tg("L. PROYECCION") = 0
                    fila_tg("%. PROYECCION") = 0
                End If

                tabla_tg_agregada.Rows.Add(fila_tg)
                grdTeg.DataSource = tabla_tg_agregada
                '_gridVentasDiariasSRC.DataSource = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, _
                '                                                 "SRC", Val(DiasM.Text), Val(DiasT.Text))

                Dim tabla_resumen_tg As New DataTable
                Dim tabla_resumen_tg_agregada As New DataTable
                tabla_resumen_tg = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "RESUMEN_TEGUCIGALPA", _
                                                    Val(DiasM.Text), Val(DiasT.Text))
                tabla_resumen_tg_agregada.Columns.Add("NOMBRE")
                tabla_resumen_tg_agregada.Columns.Add("PRESUPUESTO")
                tabla_resumen_tg_agregada.Columns.Add("VENTA")
                tabla_resumen_tg_agregada.Columns.Add("DIFERENCIA")
                tabla_resumen_tg_agregada.Columns.Add("% ALCANZADO")
                tabla_resumen_tg_agregada.Columns.Add("L. PROYECCION")
                tabla_resumen_tg_agregada.Columns.Add("%. PROYECCION")

                Dim fila_resumen_tg As DataRow
                Dim presupuesto_resumen_tg As Double = 0
                Dim venta_resumen_tg As Double = 0

                For index As Integer = 0 To tabla_resumen_tg.Rows.Count - 1
                    fila_resumen_tg = tabla_resumen_tg_agregada.NewRow
                    fila_resumen_tg("NOMBRE") = tabla_resumen_tg.Rows(index)(0)
                    fila_resumen_tg("PRESUPUESTO") = FormatNumber(tabla_resumen_tg.Rows(index)(1), 2)
                    presupuesto_resumen_tg += tabla_resumen_tg.Rows(index)(1)
                    fila_resumen_tg("VENTA") = FormatNumber(tabla_resumen_tg.Rows(index)(2), 2)
                    venta_resumen_tg += tabla_resumen_tg.Rows(index)(2)
                    fila_resumen_tg("DIFERENCIA") = FormatNumber(tabla_resumen_tg.Rows(index)(3), 2)
                    fila_resumen_tg("% ALCANZADO") = tabla_resumen_tg.Rows(index)(4)
                    fila_resumen_tg("L. PROYECCION") = FormatNumber(tabla_resumen_tg.Rows(index)(5), 2)
                    fila_resumen_tg("%. PROYECCION") = tabla_resumen_tg.Rows(index)(6)
                    tabla_resumen_tg_agregada.Rows.Add(fila_resumen_tg)
                Next

                fila_resumen_tg = tabla_resumen_tg_agregada.NewRow
                fila_resumen_tg("NOMBRE") = "SAN RAFAEL TEGUCIGALPA"
                fila_resumen_tg("PRESUPUESTO") = FormatNumber(presupuesto_resumen_tg, 2)
                fila_resumen_tg("VENTA") = FormatNumber(venta_resumen_tg, 2)
                fila_resumen_tg("DIFERENCIA") = FormatNumber(venta_resumen_tg - presupuesto_resumen_tg, 2)

                If presupuesto_tg > 0 Then
                    fila_resumen_tg("% ALCANZADO") = FormatNumber((venta_resumen_tg / presupuesto_resumen_tg) * 100, 2)
                Else
                    fila_resumen_tg("% ALCANZADO") = 0
                End If


                If Val(DiasT.Text) > 0 Then
                    fila_resumen_tg("L. PROYECCION") = FormatNumber(venta_resumen_tg * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_resumen_tg("%. PROYECCION") = FormatNumber(venta_resumen_tg * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        presupuesto_resumen_tg * 100, 2)
                Else
                    fila_resumen_tg("L. PROYECCION") = 0
                    fila_resumen_tg("%. PROYECCION") = 0
                End If

                tabla_resumen_tg_agregada.Rows.Add(fila_resumen_tg)
                grd_Resumen_Teg.DataSource = tabla_resumen_tg_agregada

                'Fin Tegucigalpa





                'cuadro de ventas de San Pedro Sula

                Dim tabla_sps As New DataTable
                Dim tabla_sps_agregada As New DataTable
                tabla_sps = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "SPS", _
                                                                Val(DiasM.Text), Val(DiasT.Text))
                tabla_sps_agregada.Columns.Add("NOMBRE")
                tabla_sps_agregada.Columns.Add("PRESUPUESTO")
                tabla_sps_agregada.Columns.Add("VENTA")
                tabla_sps_agregada.Columns.Add("DIFERENCIA")
                tabla_sps_agregada.Columns.Add("% ALCANZADO")
                tabla_sps_agregada.Columns.Add("L. PROYECCION")
                tabla_sps_agregada.Columns.Add("%. PROYECCION")

                Dim fila_sps As DataRow
                Dim presupuesto_sps As Double = 0
                Dim venta_sps As Double = 0

                For index As Integer = 0 To tabla_sps.Rows.Count - 1
                    fila_sps = tabla_sps_agregada.NewRow
                    fila_sps("NOMBRE") = tabla_sps.Rows(index)(0)
                    fila_sps("PRESUPUESTO") = FormatNumber(tabla_sps.Rows(index)(1), 2)
                    presupuesto_sps += tabla_sps.Rows(index)(1)
                    fila_sps("VENTA") = FormatNumber(tabla_sps.Rows(index)(2), 2)
                    venta_sps += tabla_sps.Rows(index)(2)
                    fila_sps("DIFERENCIA") = FormatNumber(tabla_sps.Rows(index)(3), 2)
                    fila_sps("% ALCANZADO") = tabla_sps.Rows(index)(4)
                    fila_sps("L. PROYECCION") = FormatNumber(tabla_sps.Rows(index)(5), 2)
                    fila_sps("%. PROYECCION") = tabla_sps.Rows(index)(6)
                    tabla_sps_agregada.Rows.Add(fila_sps)
                Next

                fila_sps = tabla_sps_agregada.NewRow
                fila_sps("NOMBRE") = "SAN RAFAEL SPS"
                fila_sps("PRESUPUESTO") = FormatNumber(presupuesto_sps, 2)
                fila_sps("VENTA") = FormatNumber(venta_sps, 2)
                fila_sps("DIFERENCIA") = FormatNumber(venta_sps - presupuesto_sps, 2)

                If presupuesto_sps > 0 Then
                    fila_sps("% ALCANZADO") = FormatNumber((venta_sps / presupuesto_sps) * 100, 2)
                Else
                    fila_sps("% ALCANZADO") = 0
                End If

                If Val(DiasT.Text) > 0 Then
                    fila_sps("L. PROYECCION") = FormatNumber(venta_sps * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_sps("%. PROYECCION") = FormatNumber(venta_sps * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        presupuesto_sps * 100, 2)
                Else
                    fila_sps("L. PROYECCION") = 0
                    fila_sps("%. PROYECCION") = 0
                End If

                tabla_sps_agregada.Rows.Add(fila_sps)
                _gridVentasDiariasSPS.DataSource = tabla_sps_agregada

                '_gridVentasDiariasSPS.DataSource = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "SPS", _
                '                                                Val(DiasM.Text), Val(DiasT.Text))



                Dim tabla_resumen_sps As New DataTable
                Dim tabla_resumen_sps_agregada As New DataTable
                tabla_resumen_sps = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "RESUMEN_SPS", Val(DiasM.Text), Val(DiasT.Text))

                tabla_resumen_sps_agregada.Columns.Add("NOMBRE")
                tabla_resumen_sps_agregada.Columns.Add("PRESUPUESTO")
                tabla_resumen_sps_agregada.Columns.Add("VENTA")
                tabla_resumen_sps_agregada.Columns.Add("DIFERENCIA")
                tabla_resumen_sps_agregada.Columns.Add("% ALCANZADO")
                tabla_resumen_sps_agregada.Columns.Add("L. PROYECCION")
                tabla_resumen_sps_agregada.Columns.Add("%. PROYECCION")

                Dim fila_resumen_sps As DataRow
                Dim presupuesto_resumen_sps As Double = 0
                Dim venta_resumen_sps As Double = 0

                For index As Integer = 0 To tabla_resumen_sps.Rows.Count - 1
                    fila_resumen_sps = tabla_resumen_sps_agregada.NewRow
                    fila_resumen_sps("NOMBRE") = tabla_resumen_sps.Rows(index)(0)
                    fila_resumen_sps("PRESUPUESTO") = FormatNumber(tabla_resumen_sps.Rows(index)(1), 2)
                    presupuesto_resumen_sps += tabla_resumen_sps.Rows(index)(1)
                    fila_resumen_sps("VENTA") = FormatNumber(tabla_resumen_sps.Rows(index)(2), 2)
                    venta_resumen_sps += tabla_resumen_sps.Rows(index)(2)
                    fila_resumen_sps("DIFERENCIA") = FormatNumber(tabla_resumen_sps.Rows(index)(3), 2)
                    fila_resumen_sps("% ALCANZADO") = tabla_resumen_sps.Rows(index)(4)
                    fila_resumen_sps("L. PROYECCION") = FormatNumber(tabla_resumen_sps.Rows(index)(5), 2)
                    fila_resumen_sps("%. PROYECCION") = tabla_resumen_sps.Rows(index)(6)
                    tabla_resumen_sps_agregada.Rows.Add(fila_resumen_sps)
                Next

                fila_resumen_sps = tabla_resumen_sps_agregada.NewRow
                fila_resumen_sps("NOMBRE") = "SAN RAFAEL SPS"
                fila_resumen_sps("PRESUPUESTO") = FormatNumber(presupuesto_resumen_sps, 2)
                fila_resumen_sps("VENTA") = FormatNumber(venta_resumen_sps, 2)
                fila_resumen_sps("DIFERENCIA") = FormatNumber(venta_resumen_sps - presupuesto_resumen_sps, 2)

                If presupuesto_resumen_sps > 0 Then
                    fila_resumen_sps("% ALCANZADO") = FormatNumber((venta_resumen_sps / presupuesto_resumen_sps) * 100, 2)
                Else
                    fila_resumen_sps("% ALCANZADO") = 0
                End If


                If Val(DiasT.Text) > 0 Then
                    fila_resumen_sps("L. PROYECCION") = FormatNumber(venta_resumen_sps * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_resumen_sps("%. PROYECCION") = FormatNumber(venta_resumen_sps * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        presupuesto_resumen_sps * 100, 2)
                Else
                    fila_resumen_sps("L. PROYECCION") = 0
                    fila_resumen_sps("%. PROYECCION") = 0
                End If

                tabla_resumen_sps_agregada.Rows.Add(fila_resumen_sps)
                gridRSPS.DataSource = tabla_resumen_sps_agregada

                'gridRSPS.DataSource = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "RESUMEN_SPS", Val(DiasM.Text), Val(DiasT.Text))

                'Fin de cuadro de ventas de San Pedro Sula

                'cuadro de ventas de Proyectos Nuevos

                Dim tabla_proyectos As New DataTable
                Dim tabla_proyectos_agregada As New DataTable
                tabla_proyectos = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "PROYECTOS_N", _
                                                                       Val(DiasM.Text), Val(DiasT.Text))
                tabla_proyectos_agregada.Columns.Add("NOMBRE")
                tabla_proyectos_agregada.Columns.Add("PRESUPUESTO")
                tabla_proyectos_agregada.Columns.Add("VENTA")
                tabla_proyectos_agregada.Columns.Add("DIFERENCIA")
                tabla_proyectos_agregada.Columns.Add("% ALCANZADO")
                tabla_proyectos_agregada.Columns.Add("L. PROYECCION")
                tabla_proyectos_agregada.Columns.Add("%. PROYECCION")

                Dim fila_proyectos As DataRow
                Dim presupuesto_proyectos As Double = 0
                Dim venta_proyectos As Double = 0

                For index As Integer = 0 To tabla_proyectos.Rows.Count - 1
                    fila_proyectos = tabla_proyectos_agregada.NewRow
                    fila_proyectos("NOMBRE") = tabla_proyectos.Rows(index)(0)
                    fila_proyectos("PRESUPUESTO") = FormatNumber(tabla_proyectos.Rows(index)(1), 2)
                    presupuesto_proyectos += tabla_proyectos.Rows(index)(1)
                    fila_proyectos("VENTA") = FormatNumber(tabla_proyectos.Rows(index)(2), 2)
                    venta_proyectos += tabla_proyectos.Rows(index)(2)
                    fila_proyectos("DIFERENCIA") = FormatNumber(tabla_proyectos.Rows(index)(3), 2)
                    fila_proyectos("% ALCANZADO") = tabla_proyectos.Rows(index)(4)
                    fila_proyectos("L. PROYECCION") = FormatNumber(tabla_proyectos.Rows(index)(5), 2)
                    fila_proyectos("%. PROYECCION") = tabla_proyectos.Rows(index)(6)
                    tabla_proyectos_agregada.Rows.Add(fila_proyectos)
                Next

                fila_proyectos = tabla_proyectos_agregada.NewRow
                fila_proyectos("NOMBRE") = "TOTAL"
                fila_proyectos("PRESUPUESTO") = FormatNumber(presupuesto_proyectos, 2)
                fila_proyectos("VENTA") = FormatNumber(venta_proyectos, 2)
                fila_proyectos("DIFERENCIA") = FormatNumber(venta_proyectos - presupuesto_proyectos, 2)

                If presupuesto_proyectos > 0 Then
                    fila_proyectos("% ALCANZADO") = FormatNumber((venta_proyectos / presupuesto_proyectos) * 100, 2)
                Else
                    fila_proyectos("% ALCANZADO") = 0
                End If

                If Val(DiasT.Text) > 0 Then
                    fila_proyectos("L. PROYECCION") = FormatNumber(venta_proyectos * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_proyectos("%. PROYECCION") = FormatNumber(venta_proyectos * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        presupuesto_proyectos * 100, 2)
                Else
                    fila_proyectos("L. PROYECCION") = 0
                    fila_proyectos("%. PROYECCION") = 0
                End If

                tabla_proyectos_agregada.Rows.Add(fila_proyectos)
                grd_ventas_proyectos_nuevos.DataSource = tabla_proyectos_agregada

                ' grd_ventas_proyectos_nuevos.DataSource = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "PROYECTOS_N", _
                '                                                       Val(DiasM.Text), Val(DiasT.Text))
                'Fin de Proyectos Nuevos

                'cuadro de ventas de Tocoa

                Dim tabla_tocoa As New DataTable
                Dim tabla_tocoa_agregada As New DataTable
                tabla_tocoa = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "TOCOA", Val(DiasM.Text), Val(DiasT.Text))

                tabla_tocoa_agregada.Columns.Add("NOMBRE")
                tabla_tocoa_agregada.Columns.Add("PRESUPUESTO")
                tabla_tocoa_agregada.Columns.Add("VENTA")
                tabla_tocoa_agregada.Columns.Add("DIFERENCIA")
                tabla_tocoa_agregada.Columns.Add("% ALCANZADO")
                tabla_tocoa_agregada.Columns.Add("L. PROYECCION")
                tabla_tocoa_agregada.Columns.Add("%. PROYECCION")

                Dim fila_tocoa As DataRow
                Dim presupuesto_tocoa As Double = 0
                Dim venta_tocoa As Double = 0

                For index As Integer = 0 To tabla_tocoa.Rows.Count - 1
                    fila_tocoa = tabla_tocoa_agregada.NewRow
                    fila_tocoa("NOMBRE") = tabla_tocoa.Rows(index)(0)
                    fila_tocoa("PRESUPUESTO") = FormatNumber(tabla_tocoa.Rows(index)(1), 2)
                    presupuesto_tocoa += tabla_tocoa.Rows(index)(1)
                    fila_tocoa("VENTA") = FormatNumber(tabla_tocoa.Rows(index)(2), 2)
                    venta_tocoa += tabla_tocoa.Rows(index)(2)
                    fila_tocoa("DIFERENCIA") = FormatNumber(tabla_tocoa.Rows(index)(3), 2)
                    fila_tocoa("% ALCANZADO") = tabla_tocoa.Rows(index)(4)
                    fila_tocoa("L. PROYECCION") = FormatNumber(tabla_tocoa.Rows(index)(5), 2)
                    fila_tocoa("%. PROYECCION") = tabla_tocoa.Rows(index)(6)
                    tabla_tocoa_agregada.Rows.Add(fila_tocoa)
                Next

                fila_tocoa = tabla_tocoa_agregada.NewRow
                fila_tocoa("NOMBRE") = "SAN RAFAEL TOCOA"
                fila_tocoa("PRESUPUESTO") = FormatNumber(presupuesto_tocoa, 2)
                fila_tocoa("VENTA") = FormatNumber(venta_tocoa, 2)
                fila_tocoa("DIFERENCIA") = FormatNumber(venta_tocoa - presupuesto_tocoa, 2)

                If presupuesto_tocoa > 0 Then
                    fila_tocoa("% ALCANZADO") = FormatNumber((venta_tocoa / presupuesto_tocoa) * 100, 2)
                Else
                    fila_tocoa("% ALCANZADO") = 0
                End If

                If Val(DiasT.Text) > 0 Then
                    fila_tocoa("L. PROYECCION") = FormatNumber(venta_tocoa * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_tocoa("%. PROYECCION") = FormatNumber(venta_tocoa * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        presupuesto_tocoa * 100, 2)
                Else
                    fila_tocoa("L. PROYECCION") = 0
                    fila_tocoa("%. PROYECCION") = 0
                End If

                tabla_tocoa_agregada.Rows.Add(fila_tocoa)
                grd_tocoa.DataSource = tabla_tocoa_agregada

                'grd_tocoa.DataSource = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "TOCOA", Val(DiasM.Text), Val(DiasT.Text))                                               Val(DiasM.Text), Val(DiasT.Text))

                Dim tabla_resumen_tocoa As New DataTable
                Dim tabla_resumen_tocoa_agregada As New DataTable
                tabla_resumen_tocoa = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "RESUMEN_TOCOA", Val(DiasM.Text), Val(DiasT.Text))

                tabla_resumen_tocoa_agregada.Columns.Add("NOMBRE")
                tabla_resumen_tocoa_agregada.Columns.Add("PRESUPUESTO")
                tabla_resumen_tocoa_agregada.Columns.Add("VENTA")
                tabla_resumen_tocoa_agregada.Columns.Add("DIFERENCIA")
                tabla_resumen_tocoa_agregada.Columns.Add("% ALCANZADO")
                tabla_resumen_tocoa_agregada.Columns.Add("L. PROYECCION")
                tabla_resumen_tocoa_agregada.Columns.Add("%. PROYECCION")

                Dim fila_resumen_tocoa As DataRow
                Dim presupuesto_resumen_tocoa As Double = 0
                Dim venta_resumen_tocoa As Double = 0

                For index As Integer = 0 To tabla_resumen_tocoa.Rows.Count - 1
                    fila_resumen_tocoa = tabla_resumen_tocoa_agregada.NewRow
                    fila_resumen_tocoa("NOMBRE") = tabla_resumen_tocoa.Rows(index)(0)
                    fila_resumen_tocoa("PRESUPUESTO") = FormatNumber(tabla_resumen_tocoa.Rows(index)(1), 2)
                    presupuesto_resumen_tocoa += tabla_resumen_tocoa.Rows(index)(1)
                    fila_resumen_tocoa("VENTA") = FormatNumber(tabla_resumen_tocoa.Rows(index)(2), 2)
                    venta_resumen_tocoa += tabla_resumen_tocoa.Rows(index)(2)
                    fila_resumen_tocoa("DIFERENCIA") = FormatNumber(tabla_resumen_tocoa.Rows(index)(3), 2)
                    fila_resumen_tocoa("% ALCANZADO") = tabla_resumen_tocoa.Rows(index)(4)
                    fila_resumen_tocoa("L. PROYECCION") = FormatNumber(tabla_resumen_tocoa.Rows(index)(5), 2)
                    fila_resumen_tocoa("%. PROYECCION") = tabla_resumen_tocoa.Rows(index)(6)
                    tabla_resumen_tocoa_agregada.Rows.Add(fila_resumen_tocoa)
                Next

                fila_resumen_tocoa = tabla_resumen_tocoa_agregada.NewRow
                fila_resumen_tocoa("NOMBRE") = "SAN RAFAEL TOCOA"
                fila_resumen_tocoa("PRESUPUESTO") = FormatNumber(presupuesto_resumen_tocoa, 2)
                fila_resumen_tocoa("VENTA") = FormatNumber(venta_resumen_tocoa, 2)
                fila_resumen_tocoa("DIFERENCIA") = FormatNumber(venta_resumen_tocoa - presupuesto_resumen_tocoa, 2)

                If presupuesto_resumen_tocoa > 0 Then
                    fila_resumen_tocoa("% ALCANZADO") = FormatNumber((venta_resumen_tocoa / presupuesto_resumen_tocoa) * 100, 2)
                Else
                    fila_resumen_tocoa("% ALCANZADO") = 0
                End If


                If Val(DiasT.Text) > 0 Then
                    fila_resumen_tocoa("L. PROYECCION") = FormatNumber(venta_resumen_tocoa * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_resumen_tocoa("%. PROYECCION") = FormatNumber(venta_resumen_tocoa * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        presupuesto_resumen_tocoa * 100, 2)
                Else
                    fila_resumen_sps("L. PROYECCION") = 0
                    fila_resumen_sps("%. PROYECCION") = 0
                End If

                tabla_resumen_tocoa_agregada.Rows.Add(fila_resumen_tocoa)
                grd_resumen_tocoa.DataSource = tabla_resumen_tocoa_agregada

                'grd_resumen_tocoa.DataSource = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "RESUMEN_TOCOA", _
                'Val(DiasM.Text), Val(DiasT.Text))
                'Fin de cuadro de ventas de Tocoa

                'Resumen de Disar

                Dim tabla_resumen_disar_agregada As New DataTable
                'tabla_resumen_disar = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "DISAR", Val(DiasM.Text), Val(DiasT.Text))

                tabla_resumen_disar_agregada.Columns.Add("NOMBRE")
                tabla_resumen_disar_agregada.Columns.Add("PRESUPUESTO")
                tabla_resumen_disar_agregada.Columns.Add("VENTA")
                tabla_resumen_disar_agregada.Columns.Add("DIFERENCIA")
                tabla_resumen_disar_agregada.Columns.Add("% ALCANZADO")
                tabla_resumen_disar_agregada.Columns.Add("L. PROYECCION")
                tabla_resumen_disar_agregada.Columns.Add("%. PROYECCION")

                Dim fila_resumen_disar As DataRow
                Dim presupuesto_resumen_disar As Double = 0
                Dim venta_resumen_disar As Double = 0

                'src
                fila_resumen_disar = tabla_resumen_disar_agregada.NewRow
                fila_resumen_disar("NOMBRE") = "SAN RAFAEL SRC"
                fila_resumen_disar("PRESUPUESTO") = FormatNumber(presupuesto_src, 2)
                fila_resumen_disar("VENTA") = FormatNumber(venta_src, 2)
                fila_resumen_disar("DIFERENCIA") = FormatNumber(venta_src - presupuesto_src, 2)

                If presupuesto_src > 0 Then
                    fila_resumen_disar("% ALCANZADO") = FormatNumber((venta_src / presupuesto_src) * 100, 2)
                Else
                    fila_resumen_disar("% ALCANZADO") = 0
                End If

                If Val(DiasT.Text) > 0 Then
                    fila_resumen_disar("L. PROYECCION") = FormatNumber(venta_src * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_resumen_disar("%. PROYECCION") = FormatNumber(venta_src * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        presupuesto_src * 100, 2)
                Else
                    fila_resumen_disar("L. PROYECCION") = 0
                    fila_resumen_disar("%. PROYECCION") = 0
                End If

                tabla_resumen_disar_agregada.Rows.Add(fila_resumen_disar)
                'fin src
                'sps
                fila_resumen_disar = tabla_resumen_disar_agregada.NewRow
                fila_resumen_disar("NOMBRE") = "SAN RAFAEL SPS"
                fila_resumen_disar("PRESUPUESTO") = FormatNumber(presupuesto_sps, 2)
                fila_resumen_disar("VENTA") = FormatNumber(venta_sps, 2)
                fila_resumen_disar("DIFERENCIA") = FormatNumber(venta_sps - presupuesto_sps, 2)

                If presupuesto_src > 0 Then
                    fila_resumen_disar("% ALCANZADO") = FormatNumber((venta_sps / presupuesto_sps) * 100, 2)
                Else
                    fila_resumen_disar("% ALCANZADO") = 0
                End If

                If Val(DiasT.Text) > 0 Then
                    fila_resumen_disar("L. PROYECCION") = FormatNumber(venta_sps * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_resumen_disar("%. PROYECCION") = FormatNumber(venta_sps * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        presupuesto_sps * 100, 2)
                Else
                    fila_resumen_disar("L. PROYECCION") = 0
                    fila_resumen_disar("%. PROYECCION") = 0
                End If
                tabla_resumen_disar_agregada.Rows.Add(fila_resumen_disar)
                'fin sps
                'tocoa
                fila_resumen_disar = tabla_resumen_disar_agregada.NewRow
                fila_resumen_disar("NOMBRE") = "SAN RAFAEL TOCOA"
                fila_resumen_disar("PRESUPUESTO") = FormatNumber(presupuesto_tocoa, 2)
                fila_resumen_disar("VENTA") = FormatNumber(venta_tocoa, 2)
                fila_resumen_disar("DIFERENCIA") = FormatNumber(venta_tocoa - presupuesto_tocoa, 2)

                If presupuesto_tocoa > 0 Then
                    fila_resumen_disar("% ALCANZADO") = FormatNumber((venta_tocoa / presupuesto_tocoa) * 100, 2)
                Else
                    fila_resumen_disar("% ALCANZADO") = 0
                End If

                If Val(DiasT.Text) > 0 Then
                    fila_resumen_disar("L. PROYECCION") = FormatNumber(venta_tocoa * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_resumen_disar("%. PROYECCION") = FormatNumber(venta_tocoa * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        presupuesto_tocoa * 100, 2)
                Else
                    fila_resumen_disar("L. PROYECCION") = 0
                    fila_resumen_disar("%. PROYECCION") = 0
                End If
                tabla_resumen_disar_agregada.Rows.Add(fila_resumen_disar)
                'fin tocoa

                'teg
                fila_resumen_disar = tabla_resumen_disar_agregada.NewRow
                fila_resumen_disar("NOMBRE") = "SAN RAFAEL TEGUCIGALPA"
                fila_resumen_disar("PRESUPUESTO") = FormatNumber(presupuesto_tg, 2)
                fila_resumen_disar("VENTA") = FormatNumber(venta_tg, 2)
                fila_resumen_disar("DIFERENCIA") = FormatNumber(venta_tg - presupuesto_tg, 2)

                If presupuesto_tocoa > 0 Then
                    fila_resumen_disar("% ALCANZADO") = FormatNumber((venta_tg / presupuesto_tg) * 100, 2)
                Else
                    fila_resumen_disar("% ALCANZADO") = 0
                End If

                If Val(DiasT.Text) > 0 Then
                    fila_resumen_disar("L. PROYECCION") = FormatNumber(venta_tg * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_resumen_disar("%. PROYECCION") = FormatNumber(venta_tg * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        presupuesto_tg * 100, 2)
                Else
                    fila_resumen_disar("L. PROYECCION") = 0
                    fila_resumen_disar("%. PROYECCION") = 0
                End If
                tabla_resumen_disar_agregada.Rows.Add(fila_resumen_disar)
                'fin teg
                'disar
                fila_resumen_disar = tabla_resumen_disar_agregada.NewRow
                fila_resumen_disar("NOMBRE") = "SAN RAFAEL HONDURAS"
                fila_resumen_disar("PRESUPUESTO") = FormatNumber(presupuesto_tocoa + presupuesto_resumen_src + presupuesto_resumen_sps + presupuesto_resumen_tg, 2)
                fila_resumen_disar("VENTA") = FormatNumber(venta_tocoa + venta_src + venta_sps + venta_tg, 2)
                fila_resumen_disar("DIFERENCIA") = FormatNumber((venta_tocoa + venta_src + venta_sps + venta_tg) - _
                                                                (presupuesto_tocoa + presupuesto_resumen_src + presupuesto_resumen_sps + presupuesto_resumen_tg), 2)

                If presupuesto_tg > 0 Then
                    fila_resumen_disar("% ALCANZADO") = FormatNumber(((venta_tocoa + venta_src + venta_sps + venta_tg) / _
                                                                      (presupuesto_tocoa + presupuesto_resumen_src + presupuesto_resumen_sps + presupuesto_resumen_tg)) * 100, 2)
                Else
                    fila_resumen_disar("% ALCANZADO") = 0
                End If

                If Val(DiasT.Text) > 0 Then
                    fila_resumen_disar("L. PROYECCION") = FormatNumber((venta_tocoa + venta_src + venta_sps) * (Val(DiasM.Text) / Val(DiasT.Text)), 2)
                    fila_resumen_disar("%. PROYECCION") = FormatNumber((venta_tocoa + venta_src + venta_sps) * ((Val(DiasM.Text) / Val(DiasT.Text))) / _
                                                        (presupuesto_tocoa + presupuesto_resumen_src + presupuesto_resumen_sps) * 100, 2)
                Else
                    fila_resumen_disar("L. PROYECCION") = 0
                    fila_resumen_disar("%. PROYECCION") = 0
                End If
                tabla_resumen_disar_agregada.Rows.Add(fila_resumen_disar)
                'fin Disar

                _gridResumen.DataSource = tabla_resumen_disar_agregada

                '_gridResumen.DataSource = Clase2.Ventas(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, "DISAR", Val(DiasM.Text), Val(DiasT.Text))                                                    Val(DiasM.Text), Val(DiasT.Text))
                'Fin de Resumen de Disar

                VentasDiariasDetalleSRC()
                VentasDiariasDetalleSPS()
                VentasDiariasDetalleTOCOA()
                VentasDiariasDetalleTEG()

                Dim conexion As New cls_bitacora_reporteador
                conexion.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Genero cuadro de ventas", "Reportes", _
                                          "Fecha del reporte: " + _cmbFechai.Value.Date + " " + _cmbFechaf.Value.Date)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Exportar()
    End Sub
End Class