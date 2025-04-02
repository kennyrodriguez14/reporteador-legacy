Imports Disar.data

Public Class EfectividadRangoFechasDIMOSA

    Dim dias, i, Lun, Mar, Mie, Jue, Vie, sab, TotalVisitas, TotalEfectivos, TotalNC, TotalV, TotalE As Integer
    Dim fechainicio, fechaterminal As Date
    Dim DataView, dv As DataView

    Dim _ListaSPS As New _clsVendedoresSRC
    Dim _ListaSRC As New _clsVendedoresSPS
    Dim _ListaTocoa As New _clsVendedoresTocoa
    Dim _ListaTegucigalpa As New _clsVendedoresTegucigalpa

    Dim _VisitadosSPS As New cls_efectividad_sps
    Dim _VisitadosSRC As New cls_efectividad_src
    Dim _VisitadosTocoa As New cls_efectividad_tocoa
    Dim _VisitadosTegucigalpa As New cls_efectividadTegucigalpa

    Dim miDataTable As New DataTable
    Dim Lineas As DataRow = miDataTable.NewRow()
    Dim Clase_ListaVendedores, Clase_Efectivos As New Object
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim activo As Integer = 0

    Private Sub EfectividadRangoFechas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = _Inicio
        inicializardate()
        _cmbSucursal.SelectedItem = "SRC"
        LlenarEncabezado()
        RadioTodos.Checked = True
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            activo = 1
            limpiar()
            SeleccionarSucursal()
            ListaEmpleados()
            If _cmbFechaf.Value < _cmbFechai.Value Then
                MessageBox.Show("Debe especificar una fecha final mayor a la inicial", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                CalculoDias()
                For c As Integer = 0 To _GridVendedores.RowCount - 1
                    If _GridVendedores.Rows(c).Cells(2).Value = "DET" Then
                        TotalVisitas = 0
                        TotalNC = 0
                        TotalEfectivos = 0
                        Efectivos(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, _GridVendedores.Rows(c).Cells(0).Value)
                        NotasCredto(_cmbFechai.Value.Date, _cmbFechaf.Value.Date, _GridVendedores.Rows(c).Cells(0).Value)

                        TotaldeVisitas(_GridVendedores.Rows(c).Cells(0).Value)

                        TotalNC = _GridNC.RowCount
                        _GridNC.DataSource = Nothing
                        TotalEfectivos = _GridEfectivos.RowCount + TotalNC
                        Lineas("Fecha") = "De " & _cmbFechai.Value.Day & "-" & _cmbFechai.Value.Month & "-" & _cmbFechai.Value.Year & " Hasta " & _cmbFechaf.Value.Day & "-" & _cmbFechaf.Value.Month & "-" & _cmbFechaf.Value.Year
                        Lineas("Clave") = _GridVendedores.Rows(c).Cells(0).Value
                        Lineas("Nombre del Vendedor") = _GridVendedores.Rows(c).Cells(1).Value
                        Lineas("Clientes Visitados") = TotalVisitas
                        Lineas("Efectivos") = TotalEfectivos
                        If TotalVisitas = 0 Then
                            Lineas("Porcentaje") = 0 & " %"
                        Else
                            Lineas("Porcentaje") = Math.Round(TotalEfectivos / TotalVisitas * 100) & " %"
                        End If
                        If TotalEfectivos > 0 Then
                            miDataTable.Rows.Add(Lineas)
                            Lineas = miDataTable.NewRow()
                            TotalNC = 0
                            TotalE = 0
                            _GridEfectivos.DataSource = Nothing
                            _GridNC.DataSource = Nothing
                            _GridVisitados.DataSource = Nothing
                        End If

                    End If
                Next
                Me._GridEfectividadRF.DataSource = miDataTable
                'TotalV = 0
                'TotalE = 0
                'For d As Integer = 0 To _GridEfectividadRF.RowCount - 1
                '    TotalV = TotalV + (_GridEfectividadRF.Rows(d).Cells(3).Value)
                '    TotalE = TotalE + (_GridEfectividadRF.Rows(d).Cells(4).Value)
                'Next

                'Lineas("Clave") = "SUPERVISOR"
                'If _cmbSucursal.SelectedItem = "SRC" Then
                '    Lineas("Nombre del Vendedor") = "OLVIN "
                'ElseIf _cmbSucursal.SelectedItem = "SPS" Then
                '    Lineas("Nombre del Vendedor") = "WILMER FUENTES "
                'End If

                'Lineas("Clientes Visitados") = TotalV
                'Lineas("Efectivos") = TotalE
                'Lineas("Porcentaje") = Math.Round(TotalE / TotalV * 100) & "%"

            End If
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub SeleccionarSucursal()
        If _cmbSucursal.SelectedItem = "SPS" Then
            Clase_ListaVendedores = _ListaSPS
            Clase_Efectivos = _VisitadosSPS
        ElseIf _cmbSucursal.SelectedItem = "SRC" Then
            Clase_ListaVendedores = _ListaSRC
            Clase_Efectivos = _VisitadosSRC
        ElseIf _cmbSucursal.SelectedItem = "Saba" Then
            Clase_ListaVendedores = _ListaTocoa
            Clase_Efectivos = _VisitadosTocoa
        ElseIf _cmbSucursal.SelectedItem = "Tegucigalpa" Then
            Clase_ListaVendedores = _ListaTegucigalpa
            Clase_Efectivos = _VisitadosTegucigalpa
        End If
    End Sub

    Sub ListaEmpleados()
        Try
            DataView = Clase_ListaVendedores.DatosDimosa()
            If Not IsNothing(Clase_ListaVendedores.DatosDimosa()) Then
                _GridVendedores.DataSource = DataView
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub ClearDias()
        Lun = 0
        Mar = 0
        Mie = 0
        Jue = 0
        Vie = 0
        sab = 0
    End Sub

    Sub CalculoDias()
        i = 1
        ClearDias()
        fechainicio = _cmbFechai.Value
        fechaterminal = _cmbFechaf.Value
        dias = DateDiff(DateInterval.Day, fechainicio, fechaterminal) + 1
        While i <= dias
            If fechainicio.DayOfWeek = DayOfWeek.Monday Then
                Lun += 1
            ElseIf fechainicio.DayOfWeek = DayOfWeek.Tuesday Then
                Mar += 1
            ElseIf fechainicio.DayOfWeek = DayOfWeek.Wednesday Then
                Mie += 1
            ElseIf fechainicio.DayOfWeek = DayOfWeek.Thursday Then
                Jue += 1
            ElseIf fechainicio.DayOfWeek = DayOfWeek.Friday Then
                Vie += 1
            ElseIf fechainicio.DayOfWeek = DayOfWeek.Saturday Then
                sab += 1
            End If
            i += 1
            fechainicio = fechainicio.AddDays(1)
        End While
    End Sub

    Sub TotaldeVisitas(ByVal clave As Integer)
        If Lun > 0 Then
            Visita(clave, "1_LUNES", "1_LUNES 1", "1_LUNES 2")
            TotalVisitas += _GridVisitados.Rows(0).Cells(0).Value * Lun
        End If
        If Mar > 0 Then
            Visita(clave, "2_MARTES", "2_MARTES 1", "2_MARTES 2")
            TotalVisitas += _GridVisitados.Rows(0).Cells(0).Value * Mar
        End If
        If Mie > 0 Then
            Visita(clave, "3_MIERCOLES", "3_MIERCOLES 1", "3_MIERCOLES 2")
            TotalVisitas += _GridVisitados.Rows(0).Cells(0).Value * Mie
        End If
        If Jue > 0 Then
            Visita(clave, "4_JUEVES", "4_JUEVES 1", "4_JUEVES 2")
            TotalVisitas += _GridVisitados.Rows(0).Cells(0).Value * Jue
        End If
        If Vie > 0 Then
            Visita(clave, "5_VIERNES", "5_VIERNES 1", "5_VIERNES 2")
            TotalVisitas += _GridVisitados.Rows(0).Cells(0).Value * Vie
        End If
        If sab > 0 Then
            Visita(clave, "6_SABADO", "6_SABADO 1", "6_SABADO 2")
            TotalVisitas += _GridVisitados.Rows(0).Cells(0).Value * sab
        End If
    End Sub

    Sub Visita(ByVal Clave As Integer, ByVal dias As String, ByVal dias1 As String, ByVal dias2 As String)
        dv = Clase_Efectivos.VisitadosRangoFechasDimosa(Clave, dias, dias1, dias2)
        If Not IsNothing(Clase_Efectivos.VisitadosRangoFechasDIMOSA(Clave, dias, dias1, dias2)) Then
            _GridVisitados.DataSource = dv
        End If
    End Sub

    Sub Efectivos(ByVal Fecha As Date, ByVal Fecha2 As Date, ByVal Clave As Integer)
        Try
            If RadioTodos.Checked = True Then
                DataView = Clase_Efectivos.EfectivosRangoFechasDIMOSA(Fecha, Fecha2, Clave)
            Else
                DataView = Clase_Efectivos.EfectivosRangoFechasMenores30DIMOSA(Fecha, Fecha2, Clave)
            End If

            If Not IsNothing(Clase_Efectivos.EfectivosRangoFechasDIMOSA(Fecha, Fecha2, Clave)) Then
                _GridEfectivos.DataSource = DataView
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub NotasCredto(ByVal Fecha As Date, ByVal Fecha2 As Date, ByVal Clave As Integer)
        'Try
        DataView = Clase_Efectivos.NotasCreditoDIMOSA(Fecha, Fecha2, Clave)
        If Not IsNothing(Clase_Efectivos.NotasCreditoDIMOSA(Fecha, Fecha2, Clave)) Then
            _GridNC.DataSource = DataView
        End If
        'Catch ex As Exception
        'End Try
    End Sub

    Sub LlenarEncabezado()
        Try
            miDataTable.Columns.Add("Fecha")
            miDataTable.Columns.Add("Clave")
            miDataTable.Columns.Add("Nombre del Vendedor")
            miDataTable.Columns.Add("Clientes Visitados")
            miDataTable.Columns.Add("Efectivos")
            miDataTable.Columns.Add("Porcentaje")
        Catch ex As Exception
            MessageBox.Show("Problemas en el Header " + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub limpiar()
        Try
            For c = 0 To _GridEfectividadRF.RowCount - 1
                miDataTable.Clear()
            Next
        Catch ex As Exception
            MessageBox.Show("Error " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            wSheet.Cells.Range("A1:F1").Merge()
            wSheet.Cells.Range("A1:F1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:F1").Value = "Reporte de Efectividad del  " + _cmbFechai.Value.Date + "  al  " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A1:F1").Style = "Reportes"
            For c As Integer = 0 To _GridEfectividadRF.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _GridEfectividadRF.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To _GridEfectividadRF.RowCount - 1
                For c As Integer = 0 To _GridEfectividadRF.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _GridEfectividadRF.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
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

    Private Sub EnviarACorreoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If activo = 1 Then
            CorreoAdjunto()
            Correo.DocAdjunto = "C:\Reportes\Efectividad\Reporte de Efectividad por Rango de Fechas.XLSX"
            Correo._txtAsunto.Text = "Reporte de Efectividad del  " + _cmbFechai.Value.Date + "  al  " + _cmbFechaf.Value.Date
            Correo.Visible = True
        Else
            MsgBox("Aun no se han Generado los Datos", MsgBoxStyle.Information, "Informacion")
        End If

    End Sub

    Sub CorreoAdjunto()
        Try

            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Hoja"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("NewStyle")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 14
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:F1").Merge()
            wSheet.Cells.Range("A1:F1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:F1").Value = "Reporte de Efectividad del  " + _cmbFechai.Value.Date + "  al  " + _cmbFechaf.Value.Date
            wSheet.Cells.Range("A1:F1").Style = "NewStyle"


            For c As Integer = 0 To _GridEfectividadRF.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = _GridEfectividadRF.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "NewStyle"
            Next
            For r As Integer = 0 To _GridEfectividadRF.RowCount - 1
                For c As Integer = 0 To _GridEfectividadRF.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = _GridEfectividadRF.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next
            wSheet.Columns.AutoFit()
            wBook.SaveAs("C:\Reportes\Efectividad\Reporte de Efectividad por Rango de Fechas.XLSX")
            excel.Quit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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



