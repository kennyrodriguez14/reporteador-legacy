Imports Disar.data

Public Class VentasporProveedorDimosa

    Dim Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, FTemporal, FTemporal2 As Date
    Dim DiasTrabajados, DiasMes, Domingos, a As Integer
    Dim PorcentajeProyeccion As Double

    Dim Conexion As New cls_ventas_por_proveedor
    Private Sub VentasporProveedorDimosa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        DiasMensuales()
        GenerarFechas()
        Dim DT As New DataTable
        DT = Conexion.GenerarDatosDimosa(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "lista_almacenes", DiasTrabajados, DiasMes - Domingos, 0)
        'MsgBox(DT.Rows.Count)
        For a As Integer = 0 To DT.Rows.Count - 1
            Dim Pantalla As New TabPage
            Pantalla.Text = DT(a)(1)
            Pestañas.TabPages.Add(Pantalla)
            Pantalla.Name = DT(a)(1)

            Dim Tablita1 As New DataGridView
            Tablita1.Name = "TAB" & a
            Tablita1.Width = (Pestañas.Width) - 15
            Tablita1.Height = (Pestañas.Height / 1.6) - 15
            Tablita1.Location = New Point(1, 1)
            Tablita1.Dock = DockStyle.Fill
            Pantalla.Controls.Add(Tablita1)
            Tablita1.AllowUserToAddRows = False
            Tablita1.AllowUserToDeleteRows = False
            Tablita1.AllowUserToResizeColumns = True

            Tablita1.DataSource = Conexion.GenerarDatosDimosa(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "SUC", DiasTrabajados, DiasMes - Domingos, DT(a)(0))
            Tablita1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Next
        Dim Pantalla2 As New TabPage
        Pantalla2.Text = "RESUMEN"
        Pestañas.TabPages.Add(Pantalla2)
        Pantalla2.Name = "RESUMEN"
        Dim Tablita2 As New DataGridView
        Tablita2.Name = "TAB" & a
        Tablita2.Width = (Pestañas.Width) - 15
        Tablita2.Height = (Pestañas.Height / 1.6) - 15
        Tablita2.Location = New Point(1, 1)
        Tablita2.Dock = DockStyle.Fill
        Pantalla2.Controls.Add(Tablita2)
        Tablita2.AllowUserToAddRows = False
        Tablita2.AllowUserToDeleteRows = False
        Tablita2.AllowUserToResizeColumns = True

        Tablita2.DataSource = Conexion.GenerarDatosDimosa(Fi1, Ff1, Fi2, Ff2, Fi3, Ff3, "RESUMEN", DiasTrabajados, DiasMes - Domingos, 0)
        Tablita2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
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

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub VentasporProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmb_fecha_ini.Value = "01/" & Today.Month & "/" & Today.Year
        Catch ex As Exception
        End Try
    End Sub

    Sub GenerarFechas()
        Fi1 = cmb_fecha_ini.Value.Date.AddMonths(-2) '1 & "/" & cmbFechaFinal.Value.AddMonths(-2).Month & "/" & cmbFechaFinal.Value.AddMonths(-2).Year
        Ff1 = cmbFechaFinal.Value.AddMonths(-2).Date

        Fi2 = cmb_fecha_ini.Value.Date.AddMonths(-1) '1 & "/" & cmbFechaFinal.Value.AddMonths(-1).Month & "/" & cmbFechaFinal.Value.AddMonths(-1).Year
        Ff2 = cmbFechaFinal.Value.AddMonths(-1).Date

        Fi3 = cmb_fecha_ini.Value.Date '1 & "/" & cmbFechaFinal.Value.Month & "/" & cmbFechaFinal.Value.Year
        Ff3 = cmbFechaFinal.Value.Date
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            
            wBook = excel.Workbooks.Add()

            For Each pestaña As TabPage In Pestañas.TabPages
                
                For Each Grilla As DataGridView In pestaña.Controls
                    Dim wSheet2 As New Microsoft.Office.Interop.Excel.Worksheet
                    wSheet2 = wBook.Sheets.Add()
                    wSheet2 = wBook.ActiveSheet()
                    wSheet2.Name = pestaña.Name

                    Dim style As Microsoft.Office.Interop.Excel.Style

                    Try
                        style = wSheet2.Application.ActiveWorkbook.Styles.Add("Reportes")
                        style.Font.Bold = True
                        style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                        style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                        style.Font.Size = 10
                        style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                        style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    Catch ex As Exception
                    End Try
                    
                    For c As Integer = 0 To Grilla.Columns.Count - 1
                        wSheet2.Cells(1, c + 1).value = Grilla.Columns(c).HeaderText
                        wSheet2.Cells(1, c + 1).Style = "Reportes"
                    Next
                    For r As Integer = 0 To Grilla.RowCount - 1
                        For c As Integer = 0 To Grilla.Columns.Count - 1
                            wSheet2.Cells(r + 2, c + 1).value = Grilla.Item(c, r).Value
                            wSheet2.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                            wSheet2.Cells(r + 2, c + 1).font.Size = 11
                        Next
                    Next
                    wSheet2.Columns.AutoFit()
                Next
            Next
            


            'wSheet = wBook.Sheets.Add()
            'wSheet.Name = "RESUMEN NOROCCIDENTE"

            'wSheet.Cells.Range("A1").Value = "------------------"
            'wSheet.Cells.Range("A1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            'wSheet.Cells.Range("B1").Value = "-------------------------------"
            'wSheet.Cells.Range("B1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            'wSheet.Cells.Range("C1").Value = "-------------------"
            'wSheet.Cells.Range("C1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            'wSheet.Cells.Range("D1").Value = "-------------------"
            'wSheet.Cells.Range("D1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            'wSheet.Cells.Range("E1").Value = "-------------------"
            'wSheet.Cells.Range("E1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            'wSheet.Cells.Range("F1").Value = "-------------------"
            'wSheet.Cells.Range("F1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            'wSheet.Cells.Range("C3:F3").Merge()
            'wSheet.Cells.Range("C3:F3").Value = "VENTAS POR PROVEEDOR AL " & cmbFechaFinal.Value.Date
            'wSheet.Cells.Range("C3:F3").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            'wSheet.Cells.Range("C3:F3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick)
            'wSheet.Cells.Range("C3:F3").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            'wSheet.Cells.Range("C3:F3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            'Clipboard.Clear()
            'Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, Imagen.Image) 'imagen en picturebox Picture1 formato .bmp 
            'wSheet.Cells.Range("A1").Select()
            'Try
            '    wSheet.Paste()
            'Catch ex As Exception
            'End Try
            'For c As Integer = 0 To _gridResumen.Columns.Count - 1
            '    wSheet.Cells(6, c + 1).value = _gridResumen.Columns(c).HeaderText
            '    wSheet.Cells(6, c + 1).Style = "Reportes"
            'Next
            'For r As Integer = 0 To _gridResumen.RowCount - 1
            '    For c As Integer = 0 To _gridResumen.Columns.Count - 1
            '        wSheet.Cells(r + 7, c + 1).value = _gridResumen.Item(c, r).Value
            '        wSheet.Cells(r + 7, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            '    Next
            'Next


            'wSheet.Columns.AutoFit()


            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class