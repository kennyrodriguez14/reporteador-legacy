Imports Disar.data

Public Class frmVentasProveedorAgro

    Dim Conexion As New clsVentasProveedorAgro
    Dim Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, FTemporal, FTemporal2 As Date
    Dim FiR1, FfR1, FiR2, FfR2, FiR3, FfR3, FTemporaRl, FTemporalR2 As Date
    Dim DiasTrabajadosR, DiasMesR, DomingosR, aR As Integer
    Dim DiasTrabajados, DiasMes, Domingos, a As Integer
    Dim PorcentajeProyeccion As Double
    Dim style, estilo2 As Microsoft.Office.Interop.Excel.Style

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        DiasMensuales()
        DiasMensuales2()
        GenerarFechas()
        Try
            _gridAgroSrc.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "AGRO-SRC", DiasTrabajados, DiasMes - Domingos)
            _gridAgroGracias.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "AGRO-GRACIAS", DiasTrabajados, DiasMes - Domingos)
            _GridAgroSantaB.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "AGRO-SANTABARBARA", DiasTrabajados, DiasMes - Domingos)
            _gridAgroCede.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "AGRO-CEDE", DiasTrabajados, DiasMes - Domingos)
            _gridMovil41.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "MOVIL-41", DiasTrabajados, DiasMes - Domingos)
            _gridMovil40.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "MOVIL-40", DiasTrabajados, DiasMes - Domingos)
            _gridMovil07.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "MOVIL-07", DiasTrabajados, DiasMes - Domingos)
            _gridResumen.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "RESUMEN", DiasTrabajados, DiasMes - Domingos)
            _gridResumenCierre.DataSource = Conexion.GenerarDatos(FiR1, FfR1, FiR2, FfR2, FiR3, FfR3, "RESUMEN2", DiasTrabajadosR, DiasMesR - DomingosR)
            _gridAgroSanjuan.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "AGRO-SANJUAN", DiasTrabajados, DiasMes - Domingos)

            CambiarTitulos()
        Catch ex As Exception
            MsgBox("Error al Generar datos " + ex.Message)
        End Try
    End Sub

    Sub GenerarFechas()
        Fi1 = 1 & "/" & cmbFechaInicial.Value.AddMonths(-2).Month & "/" & cmbFechaInicial.Value.AddMonths(-2).Year
        Ff1 = cmbFechaInicial.Value.AddMonths(-2).Date

        Fi2 = 1 & "/" & cmbFechaInicial.Value.AddMonths(-1).Month & "/" & cmbFechaInicial.Value.AddMonths(-1).Year
        Ff2 = cmbFechaInicial.Value.AddMonths(-1).Date

        Fi3 = 1 & "/" & cmbFechaInicial.Value.Month & "/" & cmbFechaInicial.Value.Year
        Ff3 = cmbFechaInicial.Value.Date

        If cmbFechaInicial.Value.Day = DateTime.DaysInMonth(cmbFechaInicial.Value.Year, cmbFechaInicial.Value.Month) Then
            FiR1 = 1 & "/" & cmbFechaInicial.Value.AddMonths(-2).Month & "/" & cmbFechaInicial.Value.AddMonths(-2).Year
            FfR1 = cmbFechaInicial.Value.AddMonths(-2).Date

            FiR2 = 1 & "/" & cmbFechaInicial.Value.AddMonths(-1).Month & "/" & cmbFechaInicial.Value.AddMonths(-1).Year
            FfR2 = cmbFechaInicial.Value.AddMonths(-1).Date

            FiR3 = 1 & "/" & cmbFechaInicial.Value.Month & "/" & cmbFechaInicial.Value.Year
            FfR3 = cmbFechaInicial.Value.Date
        Else
            FiR1 = 1 & "/" & cmbFechaInicial.Value.AddMonths(-3).Month & "/" & cmbFechaInicial.Value.AddMonths(-3).Year
            FfR1 = DateTime.DaysInMonth(cmbFechaInicial.Value.AddMonths(-3).Year, cmbFechaInicial.Value.AddMonths(-3).Month) & "/" & cmbFechaInicial.Value.AddMonths(-3).Month & "/" & cmbFechaInicial.Value.AddMonths(-3).Year

            FiR2 = 1 & "/" & cmbFechaInicial.Value.AddMonths(-2).Month & "/" & cmbFechaInicial.Value.AddMonths(-2).Year
            FfR2 = DateTime.DaysInMonth(cmbFechaInicial.Value.AddMonths(-2).Year, cmbFechaInicial.Value.AddMonths(-2).Month) & "/" & cmbFechaInicial.Value.AddMonths(-2).Month & "/" & cmbFechaInicial.Value.AddMonths(-2).Year

            FiR3 = 1 & "/" & cmbFechaInicial.Value.AddMonths(-1).Month & "/" & cmbFechaInicial.Value.AddMonths(-1).Year
            FfR3 = DateTime.DaysInMonth(cmbFechaInicial.Value.AddMonths(-1).Year, cmbFechaInicial.Value.AddMonths(-1).Month) & "/" & cmbFechaInicial.Value.AddMonths(-1).Month & "/" & cmbFechaInicial.Value.AddMonths(-1).Year
        End If


    End Sub

    Sub CambiarTitulos()
        _gridAgroSrc.Columns(0).HeaderText = "CODIGO"
        _gridAgroSrc.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridAgroSrc.Columns(2).HeaderText = MonthName(Fi1.Month, False).ToUpper
        _gridAgroSrc.Columns(3).HeaderText = MonthName(Fi2.Month, False).ToUpper
        _gridAgroSrc.Columns(4).HeaderText = MonthName(Fi3.Month, False).ToUpper

        _gridAgroGracias.Columns(0).HeaderText = "CODIGO"
        _gridAgroGracias.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridAgroGracias.Columns(2).HeaderText = MonthName(Fi1.Month, False).ToUpper
        _gridAgroGracias.Columns(3).HeaderText = MonthName(Fi2.Month, False).ToUpper
        _gridAgroGracias.Columns(4).HeaderText = MonthName(Fi3.Month, False).ToUpper

        _gridAgroSanjuan.Columns(0).HeaderText = "CODIGO"
        _gridAgroSanjuan.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridAgroSanjuan.Columns(2).HeaderText = MonthName(Fi1.Month, False).ToUpper
        _gridAgroSanjuan.Columns(3).HeaderText = MonthName(Fi2.Month, False).ToUpper
        _gridAgroSanjuan.Columns(4).HeaderText = MonthName(Fi3.Month, False).ToUpper

        _GridAgroSantaB.Columns(0).HeaderText = "CODIGO"
        _GridAgroSantaB.Columns(1).HeaderText = "CASA COMERCIAL"
        _GridAgroSantaB.Columns(2).HeaderText = MonthName(Fi1.Month, False).ToUpper
        _GridAgroSantaB.Columns(3).HeaderText = MonthName(Fi2.Month, False).ToUpper
        _GridAgroSantaB.Columns(4).HeaderText = MonthName(Fi3.Month, False).ToUpper

        _gridAgroCede.Columns(0).HeaderText = "CODIGO"
        _gridAgroCede.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridAgroCede.Columns(2).HeaderText = MonthName(Fi1.Month, False).ToUpper
        _gridAgroCede.Columns(3).HeaderText = MonthName(Fi2.Month, False).ToUpper
        _gridAgroCede.Columns(4).HeaderText = MonthName(Fi3.Month, False).ToUpper


        _gridMovil40.Columns(0).HeaderText = "CODIGO"
        _gridMovil40.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridMovil40.Columns(2).HeaderText = MonthName(Fi1.Month, False).ToUpper
        _gridMovil40.Columns(3).HeaderText = MonthName(Fi2.Month, False).ToUpper
        _gridMovil40.Columns(4).HeaderText = MonthName(Fi3.Month, False).ToUpper


        _gridMovil41.Columns(0).HeaderText = "CODIGO"
        _gridMovil41.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridMovil41.Columns(2).HeaderText = MonthName(Fi1.Month, False).ToUpper
        _gridMovil41.Columns(3).HeaderText = MonthName(Fi2.Month, False).ToUpper
        _gridMovil41.Columns(4).HeaderText = MonthName(Fi3.Month, False).ToUpper

        _gridMovil07.Columns(0).HeaderText = "CODIGO"
        _gridMovil07.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridMovil07.Columns(2).HeaderText = MonthName(Fi1.Month, False).ToUpper
        _gridMovil07.Columns(3).HeaderText = MonthName(Fi2.Month, False).ToUpper
        _gridMovil07.Columns(4).HeaderText = MonthName(Fi3.Month, False).ToUpper

        _gridResumen.Columns(0).HeaderText = "CODIGO"
        _gridResumen.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridResumen.Columns(2).HeaderText = MonthName(Fi1.Month, False).ToUpper
        _gridResumen.Columns(3).HeaderText = MonthName(Fi2.Month, False).ToUpper
        _gridResumen.Columns(4).HeaderText = MonthName(Fi3.Month, False).ToUpper


        _gridResumenCierre.Columns(0).HeaderText = "CODIGO"
        _gridResumenCierre.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridResumenCierre.Columns(2).HeaderText = MonthName(FiR1.Month, False).ToUpper
        _gridResumenCierre.Columns(3).HeaderText = MonthName(FiR2.Month, False).ToUpper
        _gridResumenCierre.Columns(4).HeaderText = MonthName(FiR3.Month, False).ToUpper
    End Sub

    Sub DiasMensuales()
        Try
            DiasTrabajados = 0
            Domingos = 0
            DiasMes = 0
            a = cmbFechaInicial.Value.Day
            DiasMes = DateTime.DaysInMonth(cmbFechaInicial.Value.Year, cmbFechaInicial.Value.Month)

            For j As Integer = 1 To DiasMes
                FTemporal2 = j & "/" & cmbFechaInicial.Value.Month & "/" & cmbFechaInicial.Value.Year
                If FTemporal2.DayOfWeek = DayOfWeek.Sunday Then
                    Domingos += 1
                End If
            Next
            For i As Integer = 1 To a
                FTemporal = i & "/" & cmbFechaInicial.Value.Month & "/" & cmbFechaInicial.Value.Year
                If FTemporal.DayOfWeek <> DayOfWeek.Sunday Then
                    DiasTrabajados += 1
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DiasMensuales2()
        If cmbFechaInicial.Value.Day = DateTime.DaysInMonth(cmbFechaInicial.Value.Year, cmbFechaInicial.Value.Month) Then

            Try
                DiasTrabajadosR = 0
                DomingosR = 0
                DiasMesR = 0
                aR = cmbFechaInicial.Value.Day
                DiasMesR = DateTime.DaysInMonth(cmbFechaInicial.Value.Year, cmbFechaInicial.Value.Month)

                For j As Integer = 1 To DiasMesR
                    FTemporalR2 = j & "/" & cmbFechaInicial.Value.Month & "/" & cmbFechaInicial.Value.Year
                    If FTemporalR2.DayOfWeek = DayOfWeek.Sunday Then
                        DomingosR += 1
                    End If
                Next
                For i As Integer = 1 To aR
                    FTemporaRl = i & "/" & cmbFechaInicial.Value.Month & "/" & cmbFechaInicial.Value.Year
                    If FTemporaRl.DayOfWeek <> DayOfWeek.Sunday Then
                        DiasTrabajadosR += 1
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Try
                DiasTrabajadosR = 0
                DomingosR = 0
                DiasMesR = 0
                aR = cmbFechaInicial.Value.Day
                DiasMesR = DateTime.DaysInMonth(cmbFechaInicial.Value.AddMonths(-1).Year, cmbFechaInicial.Value.AddMonths(-1).Month)
                For j As Integer = 1 To DiasMesR
                    FTemporalR2 = j & "/" & cmbFechaInicial.Value.AddMonths(-1).Month & "/" & cmbFechaInicial.Value.AddMonths(-1).Year
                    If FTemporalR2.DayOfWeek = DayOfWeek.Sunday Then
                        DomingosR += 1
                    End If
                Next
                For i As Integer = 1 To DiasMesR
                    FTemporaRl = i & "/" & cmbFechaInicial.Value.AddMonths(-1).Month & "/" & cmbFechaInicial.Value.AddMonths(-1).Year
                    If FTemporaRl.DayOfWeek <> DayOfWeek.Sunday Then
                        DiasTrabajadosR += 1
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet2 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet3 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet4 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet5 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet6 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet7 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet8 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet9 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet10 As Microsoft.Office.Interop.Excel.Worksheet

            wBook = excel.Workbooks.Add()

            'src
            wSheet2 = wBook.ActiveSheet()
            wSheet2.Name = "SRC-AGRO"

            style = wSheet2.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 10
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            For c As Integer = 0 To _gridAgroSrc.Columns.Count - 1
                wSheet2.Cells(1, c + 1).value = _gridAgroSrc.Columns(c).HeaderText
                wSheet2.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridAgroSrc.RowCount - 1
                For c As Integer = 0 To _gridAgroSrc.Columns.Count - 1
                    wSheet2.Cells(r + 2, c + 1).value = _gridAgroSrc.Item(c, r).Value
                    wSheet2.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet2.Cells(r + 2, c + 1).font.Size = 11
                    wSheet2.Cells(r + 2, c + 3).NumberFormat = "L. #,##0.00"

                Next
            Next
            wSheet2.Columns.AutoFit()

            'GRACIAS    
            wSheet3 = wBook.Sheets.Add()
            wSheet3.Name = "AGRO-GRACIAS"

            For c As Integer = 0 To _gridAgroGracias.Columns.Count - 1
                wSheet3.Cells(1, c + 1).value = "  " + _gridAgroGracias.Columns(c).HeaderText + "  "
                wSheet3.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridAgroGracias.RowCount - 1
                For c As Integer = 0 To _gridAgroGracias.Columns.Count - 1
                    wSheet3.Cells(r + 2, c + 1).value = _gridAgroGracias.Item(c, r).Value
                    wSheet3.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet3.Cells(r + 2, c + 3).NumberFormat = "L. #,##0.00"
                Next
            Next

            wSheet3.Columns.AutoFit()

            'GRACIAS    
            wSheet10 = wBook.Sheets.Add()
            wSheet10.Name = "AGRO-SANTA BARBARA"

            For c As Integer = 0 To _GridAgroSantaB.Columns.Count - 1
                wSheet10.Cells(1, c + 1).value = "  " + _GridAgroSantaB.Columns(c).HeaderText + "  "
                wSheet10.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _GridAgroSantaB.RowCount - 1
                For c As Integer = 0 To _GridAgroSantaB.Columns.Count - 1
                    wSheet10.Cells(r + 2, c + 1).value = _GridAgroSantaB.Item(c, r).Value
                    wSheet10.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet10.Cells(r + 2, c + 3).NumberFormat = "L. #,##0.00"
                Next
            Next

            wSheet10.Columns.AutoFit()



            'SAN JUAN    
            wSheet9 = wBook.Sheets.Add()
            wSheet9.Name = "AGRO-SANJUAN"

            For c As Integer = 0 To _gridAgroSanjuan.Columns.Count - 1
                wSheet9.Cells(1, c + 1).value = "  " + _gridAgroSanjuan.Columns(c).HeaderText + "  "
                wSheet9.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridAgroSanjuan.RowCount - 1
                For c As Integer = 0 To _gridAgroSanjuan.Columns.Count - 1
                    wSheet9.Cells(r + 2, c + 1).value = _gridAgroSanjuan.Item(c, r).Value
                    wSheet9.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet9.Cells(r + 2, c + 3).NumberFormat = "L. #,##0.00"
                Next
            Next

            wSheet9.Columns.AutoFit()


            'AGRO-CEDE   
            wSheet4 = wBook.Sheets.Add()
            wSheet4.Name = "AGRO-CEDE"

            For c As Integer = 0 To _gridAgroCede.Columns.Count - 1
                wSheet4.Cells(1, c + 1).value = "  " + _gridAgroCede.Columns(c).HeaderText + "  "
                wSheet4.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridAgroCede.RowCount - 1
                For c As Integer = 0 To _gridAgroCede.Columns.Count - 1
                    wSheet4.Cells(r + 2, c + 1).value = _gridAgroCede.Item(c, r).Value
                    wSheet4.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet4.Cells(r + 2, c + 3).NumberFormat = "L. #,##0.00"
                Next
            Next

            wSheet4.Columns.AutoFit()

            'MOVIL 40   
            wSheet5 = wBook.Sheets.Add()
            wSheet5.Name = "MOVIL-40"

            For c As Integer = 0 To _gridMovil40.Columns.Count - 1
                wSheet5.Cells(1, c + 1).value = "  " + _gridMovil40.Columns(c).HeaderText + "  "
                wSheet5.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridMovil40.RowCount - 1
                For c As Integer = 0 To _gridMovil40.Columns.Count - 1
                    wSheet5.Cells(r + 2, c + 1).value = _gridMovil40.Item(c, r).Value
                    wSheet5.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet5.Cells(r + 2, c + 3).NumberFormat = "L. #,##0.00"
                Next
            Next

            wSheet5.Columns.AutoFit()


            'MOVIL 41   
            wSheet6 = wBook.Sheets.Add()
            wSheet6.Name = "MOVIL-41"

            For c As Integer = 0 To _gridMovil41.Columns.Count - 1
                wSheet6.Cells(1, c + 1).value = "  " + _gridMovil41.Columns(c).HeaderText + "  "
                wSheet6.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridMovil41.RowCount - 1
                For c As Integer = 0 To _gridMovil41.Columns.Count - 1
                    wSheet6.Cells(r + 2, c + 1).value = _gridMovil41.Item(c, r).Value
                    wSheet6.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet6.Cells(r + 2, c + 3).NumberFormat = "L. #,##0.00"
                Next
            Next

            wSheet6.Columns.AutoFit()



            'MOVIL 07   
            wSheet7 = wBook.Sheets.Add()
            wSheet7.Name = "MOVIL-07"

            For c As Integer = 0 To _gridMovil07.Columns.Count - 1
                wSheet7.Cells(1, c + 1).value = "  " + _gridMovil07.Columns(c).HeaderText + "  "
                wSheet7.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridMovil07.RowCount - 1
                For c As Integer = 0 To _gridMovil07.Columns.Count - 1
                    wSheet7.Cells(r + 2, c + 1).value = _gridMovil07.Item(c, r).Value
                    wSheet7.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet7.Cells(r + 2, c + 3).NumberFormat = "L. #,##0.00"
                Next
            Next

            wSheet7.Columns.AutoFit()

            wSheet = wBook.Sheets.Add()
            wSheet.Name = "RESUMEN"

            wSheet.Cells.Range("A1").Value = "------------------"
            wSheet.Cells.Range("A1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet.Cells.Range("B1").Value = "-------------------------------"
            wSheet.Cells.Range("B1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet.Cells.Range("C1").Value = "-------------------"
            wSheet.Cells.Range("C1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet.Cells.Range("D1").Value = "-------------------"
            wSheet.Cells.Range("D1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet.Cells.Range("E1").Value = "-------------------"
            wSheet.Cells.Range("E1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet.Cells.Range("F1").Value = "-------------------"
            wSheet.Cells.Range("F1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet.Cells.Range("C3:F3").Merge()
            wSheet.Cells.Range("C3:F3").Value = "VENTAS POR PROVEEDOR AL " & cmbFechaInicial.Value.Date
            wSheet.Cells.Range("C3:F3").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("C3:F3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick)
            wSheet.Cells.Range("C3:F3").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("C3:F3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            Clipboard.Clear()
            '  Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet.Cells.Range("A1").Select()
            Try
                wSheet.Paste()
            Catch ex As Exception
            End Try
            For c As Integer = 0 To _gridResumen.Columns.Count - 1
                wSheet.Cells(6, c + 1).value = _gridResumen.Columns(c).HeaderText
                wSheet.Cells(6, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridResumen.RowCount - 1
                For c As Integer = 0 To _gridResumen.Columns.Count - 1
                    wSheet.Cells(r + 7, c + 1).value = _gridResumen.Item(c, r).Value
                    wSheet.Cells(r + 7, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 7, c + 3).NumberFormat = "L. #,##0.00"
                    'If r = _gridResumen.RowCount - 1 Then
                    'wSheet.Cells(r + 9, c + 1).font.Size = 11
                    'wSheet.Cells(r + 9, c + 1).font.bold = True
                    'wSheet.Cells(r + 9, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                    'wSheet.Cells(r + 9, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    'End If
                Next
            Next
            wSheet.Columns.AutoFit()

            wSheet8 = wBook.Sheets.Add()
            wSheet8.Name = "RESUMEN A CIERRE"

            wSheet8.Cells.Range("A1").Value = "------------------"
            wSheet8.Cells.Range("A1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet8.Cells.Range("B1").Value = "-------------------------------"
            wSheet8.Cells.Range("B1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet8.Cells.Range("C1").Value = "-------------------"
            wSheet8.Cells.Range("C1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet8.Cells.Range("D1").Value = "-------------------"
            wSheet8.Cells.Range("D1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet8.Cells.Range("E1").Value = "-------------------"
            wSheet8.Cells.Range("E1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet8.Cells.Range("F1").Value = "-------------------"
            wSheet8.Cells.Range("F1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet8.Cells.Range("C3:F3").Merge()
            wSheet8.Cells.Range("C3:F3").Value = "VENTAS POR PROVEEDOR AL CIERRE DE CADA MES"
            wSheet8.Cells.Range("C3:F3").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet8.Cells.Range("C3:F3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick)
            wSheet8.Cells.Range("C3:F3").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet8.Cells.Range("C3:F3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            ' Clipboard.Clear()
            ' Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            wSheet8.Cells.Range("A1").Select()
            Try
                wSheet8.Paste()
            Catch ex As Exception
            End Try
            For c As Integer = 0 To _gridResumenCierre.Columns.Count - 1
                wSheet8.Cells(6, c + 1).value = _gridResumenCierre.Columns(c).HeaderText
                wSheet8.Cells(6, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridResumenCierre.RowCount - 1
                For c As Integer = 0 To _gridResumenCierre.Columns.Count - 1
                    wSheet8.Cells(r + 7, c + 1).value = _gridResumenCierre.Item(c, r).Value
                    wSheet8.Cells(r + 7, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet8.Cells(r + 7, c + 3).NumberFormat = "L. #,##0.00"
                    'If r = _gridResumen.RowCount - 1 Then
                    'wSheet.Cells(r + 9, c + 1).font.Size = 11
                    'wSheet.Cells(r + 9, c + 1).font.bold = True
                    'wSheet.Cells(r + 9, c + 1).interior.color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
                    'wSheet.Cells(r + 9, c + 1).font.color = System.Drawing.ColorTranslator.ToOle(Color.Black)
                    'End If
                Next
            Next
            wSheet8.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub VentasporProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbFechaInicial.Value = cmbFechaInicial.Value.Date.AddDays(-1).Date
    End Sub

  
End Class
