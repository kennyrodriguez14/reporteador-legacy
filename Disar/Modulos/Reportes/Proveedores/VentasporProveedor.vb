Imports Disar.data
Public Class VentasporProveedor
    Dim Conexion As New cls_ventas_por_proveedor
    Dim Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, FTemporal, FTemporal2 As Date
    Dim DiasTrabajados, DiasMes, Domingos, a As Integer
    Dim PorcentajeProyeccion As Double
    Dim style, estilo2 As Microsoft.Office.Interop.Excel.Style

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        DiasMensuales()
        GenerarFechas()
        Try
            _gridSRC.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "SRC", DiasTrabajados, DiasMes - Domingos)
            _gridSPS.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "SPS", DiasTrabajados, DiasMes - Domingos)
            grd_tocoa.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "Tocoa", DiasTrabajados, DiasMes - Domingos)
            grd_Teg.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "Tegucigalpa", DiasTrabajados, DiasMes - Domingos)

            grd_movil1.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "movil1", DiasTrabajados, DiasMes - Domingos)
            grdmovil2.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "movil2", DiasTrabajados, DiasMes - Domingos)

            _gridResumen.DataSource = Conexion.GenerarDatos(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "RESUMEN", DiasTrabajados, DiasMes - Domingos)

            CambiarTitulos()
            CargaDatosExtra()
        Catch ex As Exception
            MsgBox("Error al Generar datos: " + ex.Message)
        End Try
    End Sub

    Sub CargaDatosExtra()
        For Each row As DataGridViewRow In _gridResumen.Rows

            row.Cells(6).Value = Math.Round(Val(row.Cells(4).Value) - Val(row.Cells(3).Value), 2)
            For Each rowSaba As DataGridViewRow In grd_tocoa.Rows
                If row.Cells(1).Value = rowSaba.Cells(1).Value Then
                    row.Cells(7).Value = Math.Round(Val(rowSaba.Cells(4).Value) - Val(rowSaba.Cells(3).Value), 2)
                End If
            Next
            For Each rowSPS As DataGridViewRow In _gridSPS.Rows
                If row.Cells(1).Value = rowSPS.Cells(1).Value Then
                    row.Cells(8).Value = Math.Round(Val(rowSPS.Cells(4).Value) - Val(rowSPS.Cells(3).Value), 2)
                End If
            Next
            For Each rowSRC As DataGridViewRow In _gridSRC.Rows
                If row.Cells(1).Value = rowSRC.Cells(1).Value Then
                    row.Cells(9).Value = Math.Round(Val(rowSRC.Cells(4).Value) - Val(rowSRC.Cells(3).Value), 2)
                End If
            Next
            For Each rowMovil As DataGridViewRow In grd_movil1.Rows
                If row.Cells(1).Value = rowMovil.Cells(1).Value Then
                    row.Cells(10).Value = Math.Round(Val(rowMovil.Cells(4).Value) - Val(rowMovil.Cells(3).Value), 2)
                End If
            Next
            For Each rowMovil As DataGridViewRow In grdmovil2.Rows
                If row.Cells(1).Value = rowMovil.Cells(1).Value Then
                    row.Cells(11).Value = Math.Round(Val(rowMovil.Cells(4).Value) - Val(rowMovil.Cells(3).Value), 2)
                End If
            Next
            'If Val(row.Cells(2).Value) = 0 And Val(row.Cells(3).Value) = 0 And Val(row.Cells(4).Value) = 0 Then
            '    _gridResumen.Rows.Remove(row)
            '    'MsgBox(row.Cells(1).Value)
            'End If

        Next

        For Each row As DataGridViewRow In grd_Teg.Rows
            row.Cells(6).Value = Math.Round(Val(row.Cells(4).Value) - Val(row.Cells(3).Value), 2)
            'If Val(row.Cells(2).Value) = 0 And Val(row.Cells(3).Value) = 0 And Val(row.Cells(4).Value) = 0 Then
            '    grd_Teg.Rows.Remove(row)
            'End If
        Next

    End Sub


    Sub GenerarFechas()
        Fi1 = cmb_fecha_ini.Value.Date.AddMonths(-2) '1 & "/" & cmbFechaFinal.Value.AddMonths(-2).Month & "/" & cmbFechaFinal.Value.AddMonths(-2).Year
        Ff1 = cmbFechaFinal.Value.AddMonths(-2).Date

        Fi2 = cmb_fecha_ini.Value.Date.AddMonths(-1) '1 & "/" & cmbFechaFinal.Value.AddMonths(-1).Month & "/" & cmbFechaFinal.Value.AddMonths(-1).Year
        Ff2 = cmbFechaFinal.Value.AddMonths(-1).Date

        Fi3 = cmb_fecha_ini.Value.Date '1 & "/" & cmbFechaFinal.Value.Month & "/" & cmbFechaFinal.Value.Year
        Ff3 = cmbFechaFinal.Value.Date
    End Sub

    Sub CambiarTitulos()
        _gridSRC.Columns(0).HeaderText = "CODIGO"
        _gridSRC.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridSRC.Columns(2).HeaderText = Fi1.Date.Day & "-" & Ff1.Date.Day & " " & MonthName(Fi1.Month, False).ToUpper
        _gridSRC.Columns(3).HeaderText = Fi2.Date.Day & "-" & Ff2.Date.Day & " " & MonthName(Fi2.Month, False).ToUpper
        'MonthName(Fi2.Month, False).ToUpper
        _gridSRC.Columns(4).HeaderText = Fi3.Date.Day & "-" & Ff3.Date.Day & " " & MonthName(Fi3.Month, False).ToUpper
        'MonthName(Fi3.Month, False).ToUpper

        _gridSPS.Columns(0).HeaderText = "CODIGO"
        _gridSPS.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridSPS.Columns(2).HeaderText = Fi1.Date.Day & "-" & Ff1.Date.Day & " " & MonthName(Fi1.Month, False).ToUpper
        _gridSPS.Columns(3).HeaderText = Fi2.Date.Day & "-" & Ff2.Date.Day & " " & MonthName(Fi2.Month, False).ToUpper
        _gridSPS.Columns(4).HeaderText = Fi3.Date.Day & "-" & Ff3.Date.Day & " " & MonthName(Fi3.Month, False).ToUpper

        grd_tocoa.Columns(0).HeaderText = "CODIGO"
        grd_tocoa.Columns(1).HeaderText = "CASA COMERCIAL"
        grd_tocoa.Columns(2).HeaderText = Fi1.Date.Day & "-" & Ff1.Date.Day & " " & MonthName(Fi1.Month, False).ToUpper
        grd_tocoa.Columns(3).HeaderText = Fi2.Date.Day & "-" & Ff2.Date.Day & " " & MonthName(Fi2.Month, False).ToUpper
        grd_tocoa.Columns(4).HeaderText = Fi3.Date.Day & "-" & Ff3.Date.Day & " " & MonthName(Fi3.Month, False).ToUpper

        grd_Teg.Columns(0).HeaderText = "CODIGO"
        grd_Teg.Columns(1).HeaderText = "CASA COMERCIAL"
        grd_Teg.Columns(2).HeaderText = Fi1.Date.Day & "-" & Ff1.Date.Day & " " & MonthName(Fi1.Month, False).ToUpper
        grd_Teg.Columns(3).HeaderText = Fi2.Date.Day & "-" & Ff2.Date.Day & " " & MonthName(Fi2.Month, False).ToUpper
        grd_Teg.Columns(4).HeaderText = Fi3.Date.Day & "-" & Ff3.Date.Day & " " & MonthName(Fi3.Month, False).ToUpper

        _gridResumen.Columns(0).HeaderText = "CODIGO"
        _gridResumen.Columns(1).HeaderText = "CASA COMERCIAL"
        _gridResumen.Columns(2).HeaderText = Fi1.Date.Day & "-" & Ff1.Date.Day & " " & MonthName(Fi1.Month, False).ToUpper
        _gridResumen.Columns(3).HeaderText = Fi2.Date.Day & "-" & Ff2.Date.Day & " " & MonthName(Fi2.Month, False).ToUpper
        _gridResumen.Columns(4).HeaderText = Fi3.Date.Day & "-" & Ff3.Date.Day & " " & MonthName(Fi3.Month, False).ToUpper
    End Sub

    Sub DiasMensuales()
        Try
            DiasTrabajados = 0
            Domingos = 0
            DiasMes = 0
            a = cmbFechaFinal.Value.Day
            DiasMes = DateTime.DaysInMonth(cmbFechaFinal.Value.Year, cmbFechaFinal.Value.Month)

            For j As Integer = 1 To DiasMes
                FTemporal2 = j & "/" & cmbFechaFinal.Value.Month & "/" & cmbFechaFinal.Value.Year
                If FTemporal2.DayOfWeek = DayOfWeek.Sunday Then
                    Domingos += 1
                End If
            Next
            For i As Integer = 1 To a
                FTemporal = i & "/" & cmbFechaFinal.Value.Month & "/" & cmbFechaFinal.Value.Year
                If FTemporal.DayOfWeek <> DayOfWeek.Sunday Then
                    DiasTrabajados += 1
                End If
            Next

            If cmbFechaFinal.Value.Year = 2016 And cmbFechaFinal.Value.Month = 12 Then
                DiasMes = DiasMes - 2
                If cmbFechaFinal.Value.Day >= 24 Then
                    DiasTrabajados = DiasTrabajados - 1
                End If

                If cmbFechaFinal.Value.Day >= 31 Then
                    DiasTrabajados = DiasTrabajados - 1
                End If
            End If

            If cmbFechaFinal.Value.Year = 2017 And cmbFechaFinal.Value.Month = 4 Then
                DiasMes = DiasMes - 3
                If cmbFechaFinal.Value.Day >= 13 Then
                    DiasTrabajados = DiasTrabajados - 3
                End If

            End If

            If cmbFechaFinal.Value.Year = 2018 And cmbFechaFinal.Value.Month = 3 Then
                DiasMes = DiasMes - 3
                If cmbFechaFinal.Value.Day >= 29 Then
                    DiasTrabajados = DiasTrabajados - 3
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            'Dim wSheet7 As Microsoft.Office.Interop.Excel.Worksheet
            Dim wSheet8 As Microsoft.Office.Interop.Excel.Worksheet

            wBook = excel.Workbooks.Add()

            'src
            wSheet2 = wBook.ActiveSheet()
            wSheet2.Name = "SRC"

            style = wSheet2.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 10
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            For c As Integer = 0 To _gridSRC.Columns.Count - 1
                wSheet2.Cells(1, c + 1).value = _gridSRC.Columns(c).HeaderText
                wSheet2.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridSRC.RowCount - 1
                For c As Integer = 0 To _gridSRC.Columns.Count - 1
                    wSheet2.Cells(r + 2, c + 1).value = _gridSRC.Item(c, r).Value
                    wSheet2.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet2.Cells(r + 2, c + 1).font.Size = 11
                Next
            Next
            wSheet2.Columns.AutoFit()

            'sps    
            wSheet3 = wBook.Sheets.Add()
            wSheet3.Name = "SPS"

            For c As Integer = 0 To _gridSPS.Columns.Count - 1
                wSheet3.Cells(1, c + 1).value = "  " + _gridSPS.Columns(c).HeaderText + "  "
                wSheet3.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _gridSPS.RowCount - 1
                For c As Integer = 0 To _gridSPS.Columns.Count - 1
                    wSheet3.Cells(r + 2, c + 1).value = _gridSPS.Item(c, r).Value
                    wSheet3.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next

            wSheet3.Columns.AutoFit()

            'TOCOA    
            wSheet4 = wBook.Sheets.Add()
            wSheet4.Name = "Tocoa"

            For c As Integer = 0 To grd_tocoa.Columns.Count - 1
                wSheet4.Cells(1, c + 1).value = "  " + grd_tocoa.Columns(c).HeaderText + "  "
                wSheet4.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To grd_tocoa.RowCount - 1
                For c As Integer = 0 To grd_tocoa.Columns.Count - 1
                    wSheet4.Cells(r + 2, c + 1).value = grd_tocoa.Item(c, r).Value
                    wSheet4.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next

            'Tegucigalpa    
            wSheet8 = wBook.Sheets.Add()
            wSheet8.Name = "Tegucigalpa"

            For c As Integer = 0 To grd_Teg.Columns.Count - 1
                wSheet8.Cells(1, c + 1).value = "  " + grd_Teg.Columns(c).HeaderText + "  "
                wSheet8.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To grd_Teg.RowCount - 1
                For c As Integer = 0 To grd_Teg.Columns.Count - 1
                    wSheet8.Cells(r + 2, c + 1).value = grd_Teg.Item(c, r).Value
                    wSheet8.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next


            'Movil 1    
            wSheet5 = wBook.Sheets.Add()
            wSheet5.Name = "Almacén móvil Daniel Milla"

            For c As Integer = 0 To grd_movil1.Columns.Count - 1
                wSheet5.Cells(1, c + 1).value = "  " + grd_movil1.Columns(c).HeaderText + "  "
                wSheet5.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To grd_movil1.RowCount - 1
                For c As Integer = 0 To grd_movil1.Columns.Count - 1
                    wSheet5.Cells(r + 2, c + 1).value = grd_movil1.Item(c, r).Value
                    wSheet5.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next

            'Movil 2
            wSheet6 = wBook.Sheets.Add()
            wSheet6.Name = "Almacén Móvil Selvin Zelaya"

            For c As Integer = 0 To grdmovil2.Columns.Count - 1
                wSheet6.Cells(1, c + 1).value = "  " + grdmovil2.Columns(c).HeaderText + "  "
                wSheet6.Cells(1, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To grdmovil2.RowCount - 1
                For c As Integer = 0 To grdmovil2.Columns.Count - 1
                    wSheet6.Cells(r + 2, c + 1).value = grdmovil2.Item(c, r).Value
                    wSheet6.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next

            ''Movil 3
            'wSheet7 = wBook.Sheets.Add()
            'wSheet7.Name = "Movil 3"

            'For c As Integer = 0 To grdmovil3.Columns.Count - 1
            '    wSheet7.Cells(1, c + 1).value = "  " + grdmovil3.Columns(c).HeaderText + "  "
            '    wSheet7.Cells(1, c + 1).Style = "Reportes"
            'Next
            'For r As Integer = 0 To grdmovil3.RowCount - 1
            '    For c As Integer = 0 To grdmovil3.Columns.Count - 1
            '        wSheet7.Cells(r + 2, c + 1).value = grdmovil3.Item(c, r).Value
            '        wSheet7.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            '    Next
            'Next

            wSheet = wBook.Sheets.Add()
            wSheet.Name = "RESUMEN NOROCCIDENTE"

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
            wSheet.Cells.Range("C3:F3").Value = "VENTAS POR PROVEEDOR AL " & cmbFechaFinal.Value.Date
            wSheet.Cells.Range("C3:F3").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("C3:F3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick)
            wSheet.Cells.Range("C3:F3").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("C3:F3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            Clipboard.Clear()
            Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
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
                Next
            Next


            For c As Integer = 0 To grd_Teg.Columns.Count - 1
                wSheet.Cells(6, c + 14).value = "  " + grd_Teg.Columns(c).HeaderText + "  "
                wSheet.Cells(6, c + 14).Style = "Reportes"
            Next
            For r As Integer = 0 To grd_Teg.RowCount - 1
                For c As Integer = 0 To grd_Teg.Columns.Count - 1
                    wSheet.Cells(r + 7, c + 14).value = grd_Teg.Item(c, r).Value
                    wSheet.Cells(r + 7, c + 14).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next

            wSheet.Columns.AutoFit()


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
        Try
            cmb_fecha_ini.Value = "01/" & Today.Month & "/" & Today.Year
        Catch ex As Exception
        End Try
    End Sub
End Class