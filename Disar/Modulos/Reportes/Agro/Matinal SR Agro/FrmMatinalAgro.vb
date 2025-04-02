Imports Disar.data
Imports System.IO
Imports System.Data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class FrmMatinalAgro

    Dim dias, i, Lun, Mar, Mie, Jue, Vie, sab, TotalVisitas, TotalEfectivos, TotalNC, TotalV, TotalE As Integer
    Dim fechainicio, fechaterminal As Date
    Dim DataView, dv As DataView

    Dim _ListaSPS As New _clsVendedoresSRC
    Dim _VisitadosSRC As New cls_efectividad_src
    Dim miDataTable As New DataTable
    Dim Lineas As DataRow = miDataTable.NewRow()
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim activo As Integer = 0

    Dim direccion_archivo = ""
    Dim Total As Integer = 0

    Public Tipo As String

    Private Sub BtnListarVendedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnListarVendedores.Click
        Dim dbVendedores As New ClsMatinalAgro
        Try
            DataVendedores.Columns.Clear()
            DataVendedores.DataSource = Nothing
        Catch ex As Exception
        End Try
        Try
            Dim Data As New DataView
            Data = dbVendedores.MuestraVendedoresMatinal
            If Not (IsNothing(dbVendedores.MuestraVendedoresMatinal)) Then
                DataVendedores.DataSource = Data
                If DataVendedores.ColumnCount = 4 Then
                    Dim chk As New DataGridViewCheckBoxColumn()
                    DataVendedores.Columns.Add(chk)
                    chk.HeaderText = "Calcular"
                    chk.Name = "chk"
                End If
                DataVendedores.Columns(1).Width = 220%
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnMostrarInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrarInfo.Click

        Dim db As New ClsMatinalAgro

        GroupBox1.SendToBack()
        GroupBox2.BringToFront()
        TabControl1.TabPages.Clear()

        CalculoDias()

        For A As Integer = 0 To DataVendedores.RowCount - 1

            If DataVendedores.Rows(A).Cells("chk").Value = True Then
                Dim Pantalla As New TabPage
                Pantalla.Text = DataVendedores.Rows(A).Cells(1).Value
                TabControl1.TabPages.Add(Pantalla)
                Pantalla.Name = DataVendedores.Rows(A).Cells(0).Value

                Dim TABC As New TabControl
                TABC.Name = "CONTROL" & A
                TABC.Dock = DockStyle.Fill
                Pantalla.Controls.Add(TABC)

                Dim dtPantallas As New DataTable
                Try
                    dtPantallas.Rows.Clear()
                Catch ex As Exception
                End Try

                dtPantallas = db.Pantallas(Val(Pantalla.Name))

                If dtPantallas.Rows.Count > 0 Then
                    For Az As Integer = 0 To dtPantallas.Rows.Count - 1
                        Dim SubPantalla As New TabPage
                        SubPantalla.Text = dtPantallas(Az)(1)
                        TABC.TabPages.Add(SubPantalla)
                        SubPantalla.Name = "SUB" & dtPantallas(Az)(1)

                        Dim Tablita1 As New DataGridView
                        Tablita1.Name = "TAB" & dtPantallas(Az)(1) & A
                        Tablita1.Width = (TabControl1.Width) - 15
                        Tablita1.Height = (TabControl1.Height / 1.6) - 15
                        Tablita1.Location = New Point(1, 1)
                        Tablita1.Dock = DockStyle.Fill
                        SubPantalla.Controls.Add(Tablita1)
                        Tablita1.AllowUserToAddRows = False
                        Tablita1.AllowUserToDeleteRows = False
                        Tablita1.AllowUserToResizeColumns = True


                        Tablita1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                        Dim FEC As Date = 1 & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year

                        If Tipo = "Diario" Then
                            FEC = Cmb_Fecha_Inicial.Value
                        End If

                        For Each column As DataGridViewColumn In Tablita1.Columns
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                        Next
                        Try
                            Tablita1.DataSource = db.CargaMetas(Pantalla.Name, SubPantalla.Text, Cmb_Fecha_Inicial.Value.Month, Cmb_Fecha_Inicial.Value.Year)
                            Tablita1.Columns(0).ReadOnly = True
                            Tablita1.Columns(1).ReadOnly = True
                            Tablita1.Columns(2).ReadOnly = True
                            Tablita1.Columns(3).ReadOnly = True
                            Tablita1.Columns(4).ReadOnly = True
                            Tablita1.Columns(5).ReadOnly = True
                            Tablita1.Columns(5).HeaderText = "% PROYECCION"
                            Tablita1.Columns(6).ReadOnly = True
                        Catch ex As Exception
                        End Try

                        Dim Mensual As Decimal = 0
                        Dim TotalReal As Decimal = 0
                        For Each row As DataGridViewRow In Tablita1.Rows
                            If row.Index >= 0 And row.Index < Tablita1.RowCount Then
                                If Not IsDBNull(row.Cells("META").Value) Then
                                    Mensual = row.Cells("META").Value
                                End If

                                Dim dt As New DataTable
                                If row.Cells("TIPO").Value = "QQ" Or row.Cells("TIPO").Value = "TM" Or row.Cells("TIPO").Value = "L" Or row.Cells("TIPO").Value = "" Or row.Cells("TIPO").Value = "VOL" Then
                                    dt = db.LlenaInfo_QQ_TM(FEC, Cmb_Fecha_Inicial.Value.Date, Pantalla.Name, SubPantalla.Text, row.Cells(0).Value.ToString)
                                    'MsgBox("1." & FEC & " 2." & Cmb_Fecha_Inicial.Value.Date & " 3." & Pantalla.Name & " 4." & SubPantalla.Text & " 5." & row.Cells(0).Value.ToString & " = " & dt.Rows.Count)
                                    'MsgBox(FEC & vbNewLine & Cmb_Fecha_Inicial.Value.Date & vbNewLine & Pantalla.Name & vbNewLine & SubPantalla.Text & vbNewLine & row.Cells(0).Value.ToString)
                                    'MsgBox(dt(0)(5) & " " & dt(0)(6))
                                End If

                                Dim Real As Decimal = 0
                                If dt.Rows.Count > 0 Then

                                    'MsgBox(dt(0)(5) & " " & dt(0)(6))
                                    If row.Cells("TIPO").Value = "QQ" Then
                                        Real = dt(0)(5)
                                    ElseIf row.Cells("TIPO").Value = "TM" Then
                                        Real = dt(0)(6)
                                    ElseIf row.Cells("TIPO").Value = "L" Or row.Cells("TIPO").Value = "VOL" Then
                                        Real = dt(0)(7)
                                    End If
                                End If
                                Try
                                    Real = Math.Round(Real, 2)
                                Catch ex As Exception
                                End Try
                                Dim Metadiaria As Decimal
                                Try
                                    Metadiaria = Math.Round((Mensual - Real) / Val(TextDiasRestantes.Text), 2)
                                Catch ex As Exception
                                End Try
                                row.Cells("REAL").Value = Real.ToString("N2")
                                TotalReal += Real
                                Try
                                    If Tipo = "Matinal" Then
                                        row.Cells(5).Value = Math.Round(Real / row.Cells("META").Value * 100, 2) & " %"
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If Tipo = "Matinal" Then
                                        row.Cells("META DIARIA").Value = Metadiaria.ToString("N2")
                                    End If
                                Catch ex As Exception
                                End Try
                            End If
                            If row.Index = Tablita1.RowCount - 1 Then
                                row.Cells(1).Value = SubPantalla.Text
                                row.Cells(3).Value = Tablita1.Rows(0).Cells(3).Value
                                row.Cells(4).Value = TotalReal
                                If Not IsDBNull(row.Cells("META").Value) Then
                                    Mensual = row.Cells("META").Value
                                End If
                                Dim Metadiaria As Decimal
                                Try
                                    Metadiaria = Math.Round((Mensual - TotalReal) / Val(TextDiasRestantes.Text), 2)
                                Catch ex As Exception
                                End Try
                                Try
                                    If Tipo = "Matinal" Then
                                        row.Cells(5).Value = Math.Round(TotalReal / row.Cells("META").Value * 100, 2) & " %"
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If Tipo = "Matinal" Then
                                        row.Cells("META DIARIA").Value = Metadiaria.ToString("N2")
                                    End If
                                Catch ex As Exception
                                End Try
                            End If
                        Next
                        If Tipo = "Diario" Then
                            Tablita1.Columns("REAL").HeaderText = "REAL DEL DÍA"
                        End If

                        For Each Row As DataGridViewRow In Tablita1.Rows
                            Dim Porcentaje As Decimal = 0
                            Dim Proyeccion As Decimal = 0
                            Try
                                Proyeccion = (Row.Cells(4).Value / Val(TextDiasTrabajados.Text)) * Val(TextDiasMensuales.Text)
                                Porcentaje = (Proyeccion / Row.Cells(2).Value) * 100
                            Catch ex As Exception
                            End Try

                            Try
                                Porcentaje = Math.Round(Porcentaje, 2)
                            Catch ex As Exception
                            End Try
                            If Tipo = "Matinal" Then
                                Row.Cells("%").Value = Porcentaje.ToString & " %"
                            End If

                        Next

                    Next
                End If

            End If
        Next

        Dim PantallaX As New TabPage
        PantallaX.Text = "RESUMEN"
        TabControl1.TabPages.Add(PantallaX)
        PantallaX.Name = "RESUMEN"

        Dim Tablita2 As New DataGridView
        Tablita2.Name = "TBRESUMEN"
        Tablita2.Width = (TabControl1.Width) - 15
        Tablita2.Height = (TabControl1.Height / 1.6) - 15
        Tablita2.Location = New Point(1, 1)
        Tablita2.Dock = DockStyle.Fill
        PantallaX.Controls.Add(Tablita2)
        Tablita2.AllowUserToAddRows = False
        Tablita2.AllowUserToDeleteRows = False
        Tablita2.AllowUserToResizeColumns = True

        Tablita2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Dim FEC2 As Date = 1 & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
        If Tipo = "Diario" Then
            FEC2 = Cmb_Fecha_Inicial.Value
        End If
        Tablita2.DataSource = db.CargaMetasGenerales(Cmb_Fecha_Inicial.Value.Month, Cmb_Fecha_Inicial.Value.Year)

        Dim Mensual2 As Decimal = 0
        Dim TotalReal2 As Decimal = 0
        For Each row As DataGridViewRow In Tablita2.Rows

            If Not IsDBNull(row.Cells("META").Value) Then
                Mensual2 = row.Cells("META").Value
            End If

            Dim dt As New DataTable
            If row.Cells("TIPO").Value = "QQ" Or row.Cells("TIPO").Value = "TM" Or row.Cells("TIPO").Value = "L" Then
                dt = db.LlenaInfo_QQ_TM(FEC2, Cmb_Fecha_Inicial.Value.Date, 0, row.Cells(1).Value, row.Cells(0).Value.ToString)
                'MsgBox(FEC & vbNewLine & Cmb_Fecha_Inicial.Value.Date & vbNewLine & Pantalla.Name & vbNewLine & SubPantalla.Text & vbNewLine & row.Cells(0).Value.ToString)
                'MsgBox(dt(0)(5) & " " & dt(0)(6))
            End If
            Dim Real As Decimal = 0
            If dt.Rows.Count > 0 Then
                'MsgBox(dt(0)(5) & " " & dt(0)(6))
                If row.Cells("TIPO").Value = "QQ" Then
                    Real = dt(0)(5)
                ElseIf row.Cells("TIPO").Value = "TM" Then
                    Real = dt(0)(6)
                ElseIf row.Cells("TIPO").Value = "L" Then
                    Real = dt(0)(7)
                End If
            End If
            Try
                Real = Math.Round(Real, 2)
            Catch ex As Exception
            End Try
            Dim Metadiaria As Decimal
            Try
                Metadiaria = Math.Round((Mensual2 - Real) / Val(TextDiasRestantes.Text), 2)
            Catch ex As Exception
            End Try
            row.Cells("REAL").Value = Real.ToString("N2")
            TotalReal2 += Real
            Try
                If Tipo = "Matinal" Then
                    row.Cells(5).Value = Math.Round(Real / row.Cells("META").Value * 100, 2) & " %"
                End If
            Catch ex As Exception
            End Try
            Try
                If Tipo = "Matinal" Then
                    row.Cells("META DIARIA").Value = Metadiaria.ToString("N2")
                End If
            Catch ex As Exception
            End Try
        Next

        For Each Row As DataGridViewRow In Tablita2.Rows
            Dim Porcentaje As Decimal = 0
            Dim Proyeccion As Decimal = 0
            Try
                Proyeccion = (Row.Cells(4).Value / Val(TextDiasTrabajados.Text)) * Val(TextDiasMensuales.Text)
                Porcentaje = (Proyeccion / Row.Cells(2).Value) * 100
            Catch ex As Exception
            End Try

            Try
                Porcentaje = Math.Round(Porcentaje, 2)
            Catch ex As Exception
            End Try
            If Tipo = "Matinal" Then
                Row.Cells("%").Value = Porcentaje.ToString & " %"
            End If
        Next
        Try
            Tablita2.Columns(0).ReadOnly = True
            Tablita2.Columns(1).ReadOnly = True
            Tablita2.Columns(2).ReadOnly = True
            Tablita2.Columns(3).ReadOnly = True
            Tablita2.Columns(4).ReadOnly = True
            Tablita2.Columns(5).ReadOnly = True
            Tablita2.Columns(5).HeaderText = "% PROYECCION"
            Tablita2.Columns(6).ReadOnly = True
        Catch ex As Exception
        End Try

        If Tipo = "Diario" Then
            Tablita2.Columns("REAL").HeaderText = "REAL DEL DÍA"
        End If


    End Sub

    Sub CalculoDias()
        Try

            Dim contador As Integer = Cmb_Fecha_Inicial.Value.Day
            Dim Fecha As Date = Cmb_Fecha_Inicial.Value
            Dim Cantidad_Dias = DateTime.DaysInMonth(Cmb_Fecha_Inicial.Value.Year, Cmb_Fecha_Inicial.Value.Month)
            Dim domingos As Integer = 0
            Dim domingosActuales As Integer = 0

            For j As Integer = 1 To Cantidad_Dias
                Fecha = j & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
                If Fecha.DayOfWeek = DayOfWeek.Sunday Then
                    domingos += 1
                End If
            Next
            For j As Integer = 1 To contador
                Fecha = j & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
                If Fecha.DayOfWeek = DayOfWeek.Sunday Then
                    domingosActuales += 1
                End If
            Next

            If Cmb_Fecha_Inicial.Value.Month = 12 Then
                domingos += 1
            End If

            If Cmb_Fecha_Inicial.Value.Month = 1 Then
                domingos += 1
            End If

            If Cmb_Fecha_Inicial.Value.Month = 3 And Cmb_Fecha_Inicial.Value.Year = 2018 Then
                domingos += 3
            End If

            TextDiasMensuales.Text = Cantidad_Dias - domingos
            TextDiasTrabajados.Text = contador - domingosActuales

            If Cmb_Fecha_Inicial.Value.Month = 12 And Cmb_Fecha_Inicial.Value.Day >= 25 Then
                TextDiasTrabajados.Text = (Val(TextDiasTrabajados.Text) - 1)
                'MsgBox("Si")
            End If
            If Cmb_Fecha_Inicial.Value.Month = 1 And Cmb_Fecha_Inicial.Value.Day >= 2 Then
                TextDiasTrabajados.Text = (Val(TextDiasTrabajados.Text) - 1)
                'MsgBox("Si")
            End If
            If Cmb_Fecha_Inicial.Value.Month = 3 And Cmb_Fecha_Inicial.Value.Year = 2018 And Cmb_Fecha_Inicial.Value.Day >= 29 Then
                TextDiasTrabajados.Text = TextDiasMensuales.Text
                'MsgBox("Si")
            End If

            TextDiasRestantes.Text = TextDiasMensuales.Text - TextDiasTrabajados.Text


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            i = 1
            ClearDias()
            fechainicio = "1" & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
            fechaterminal = Cmb_Fecha_Inicial.Value
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

    Private Sub FrmMatinalAgro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupBox1.BringToFront()
        'Try
        '    BtnListarVendedores.PerformClick()
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If ChkTodos.CheckState = CheckState.Checked Then
            For A As Integer = 0 To DataVendedores.RowCount - 1
                DataVendedores.Rows(A).Cells(3).Value = True
            Next
        Else
            For A As Integer = 0 To DataVendedores.RowCount - 1
                DataVendedores.Rows(A).Cells(3).Value = False
            Next
        End If
    End Sub

    Private Sub BtnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver.Click
        GroupBox1.BringToFront()
        GroupBox2.SendToBack()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        Try
            FolderBrowserDialog1.Description = "Guardar hoja"
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
             Then
                direccion_archivo = FolderBrowserDialog1.SelectedPath + "\"
            End If
        Catch ex As Exception
        End Try
        Dim FECHACARGA As Date = 1 & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
        For Each TB As TabPage In TabControl1.TabPages

            If TB.Name <> "RESUMEN" Then
                'Dim db As New ClassVendedores
                'Dim dtSupervisor As New DataTable
                Dim SUPERVISOR As String = ""
                'Try
                '    dtSupervisor.Rows.Clear()
                '    dtSupervisor = db.SeleccionaSupervisor(TB.Name)
                '    SUPERVISOR = dtSupervisor(0)(0)
                'Catch ex As Exception
                'End Try
                SUPERVISOR = "Supervisor"
                'Dim db2 As New cls_bonificaciones
                'Dim dtVentas As New DataTable
                'Dim Ventas As Decimal = 0
                'Try
                '    dtVentas.Rows.Clear()
                '    dtVentas = db2.Bonificaciones_VentasMatinal(FECHACARGA.Date, Cmb_Fecha_Inicial.Value.Date, TB.Name, "COBERTURA_CLIENTES", 90)
                '    Ventas = dtVentas(0)(3)
                '    Ventas = Math.Round(Ventas, 2)
                'Catch ex As Exception
                'End Try

                'Dim Efectividad As String = "0"
                'Try
                '    Efectividad = CargaEfectivos(TB.Name)
                'Catch ex As Exception
                '    MsgBox("    ." & ex.Message)
                'End Try
                For Each TbInterno As TabControl In TB.Controls

                    Dim tabla_encabezado As New PdfPTable(3)
                    tabla_encabezado.DefaultCell.Padding = 3
                    tabla_encabezado.DefaultCell.BorderColor = Color.WHITE
                    tabla_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
                    tabla_encabezado.WidthPercentage = (500 / 5.1F)
                    tabla_encabezado.SetWidths(New Integer() {1, 4, 1})
                    tabla_encabezado.SpacingAfter = 20

                    Dim tabla_sub_encabezado As New PdfPTable(3)
                    tabla_sub_encabezado.DefaultCell.Padding = 3
                    tabla_sub_encabezado.DefaultCell.BorderColor = Color.WHITE
                    tabla_sub_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
                    tabla_sub_encabezado.WidthPercentage = (400 / 5.23F)
                    tabla_sub_encabezado.SetWidths(New Integer() {4, 0, 2})

                    Dim tabla_transportista As New PdfPTable(3)
                    tabla_transportista.DefaultCell.Padding = 3
                    tabla_transportista.DefaultCell.BorderColor = Color.WHITE
                    tabla_transportista.HorizontalAlignment = Element.ALIGN_CENTER
                    tabla_transportista.WidthPercentage = (400 / 5.23F)
                    tabla_transportista.SetWidths(New Integer() {1, 4, 1})

                    Dim Titulostabla_grilla As New PdfPTable(5)
                    Titulostabla_grilla.DefaultCell.Padding = 3
                    Titulostabla_grilla.WidthPercentage = 30
                    Titulostabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
                    Titulostabla_grilla.DefaultCell.BorderWidth = 1
                    Titulostabla_grilla.WidthPercentage = (480 / 5.23F)
                    Titulostabla_grilla.SetWidths(New Integer() {2, 6, 6, 1, 6})
                    Titulostabla_grilla.SpacingBefore = 60

                    Dim tabla_grilla As New PdfPTable(10)
                    tabla_grilla.DefaultCell.Padding = 3
                    tabla_grilla.WidthPercentage = 30
                    tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
                    tabla_grilla.DefaultCell.BorderWidth = 1
                    tabla_grilla.WidthPercentage = (480 / 5.23F)
                    tabla_grilla.SetWidths(New Integer() {2, 3, 3, 2, 2, 2, 1, 2, 2, 2})
                    tabla_grilla.SpacingBefore = 0

                    Dim tabla_grilla2 As New PdfPTable(10)
                    tabla_grilla2.DefaultCell.Padding = 3
                    tabla_grilla2.WidthPercentage = 30
                    tabla_grilla2.HorizontalAlignment = Element.ALIGN_LEFT
                    tabla_grilla2.DefaultCell.BorderWidth = 1
                    tabla_grilla2.WidthPercentage = (480 / 5.23F)
                    tabla_grilla2.SetWidths(New Integer() {2, 1, 3, 2, 2, 2, 1, 2, 2, 2})
                    tabla_grilla2.SpacingBefore = 0

                    Dim tabla_motivo As New PdfPTable(5)
                    tabla_motivo.DefaultCell.Padding = 3
                    tabla_motivo.HorizontalAlignment = Element.ALIGN_CENTER
                    tabla_motivo.WidthPercentage = (385 / 5.23F)
                    tabla_motivo.SetWidths(New Integer() {1, 4, 1, 1, 2})
                    tabla_motivo.SpacingBefore = 20

                    Dim tabla_datos_adicionales As New PdfPTable(4)
                    tabla_datos_adicionales.DefaultCell.Padding = 3
                    tabla_datos_adicionales.DefaultCell.BorderColor = Color.WHITE
                    tabla_datos_adicionales.HorizontalAlignment = Element.ALIGN_LEFT
                    tabla_datos_adicionales.WidthPercentage = (385 / 5.23F)
                    tabla_datos_adicionales.SetWidths(New Integer() {1, 1, 1, 1})
                    tabla_datos_adicionales.SpacingBefore = 20

                    Dim tabla_datos_adicionales2 As New PdfPTable(4)
                    tabla_datos_adicionales2.DefaultCell.Padding = 3
                    tabla_datos_adicionales2.DefaultCell.BorderColor = Color.WHITE
                    tabla_datos_adicionales2.HorizontalAlignment = Element.ALIGN_LEFT
                    tabla_datos_adicionales2.WidthPercentage = (385 / 5.23F)
                    tabla_datos_adicionales2.SetWidths(New Integer() {1, 1, 1, 1})
                    tabla_datos_adicionales2.SpacingBefore = 20

                    Dim tabla_fimas As New PdfPTable(2)
                    tabla_fimas.DefaultCell.Padding = 3
                    tabla_fimas.DefaultCell.BorderColor = Color.WHITE
                    tabla_fimas.HorizontalAlignment = Element.ALIGN_CENTER
                    tabla_fimas.WidthPercentage = (300 / 5.23F)
                    tabla_fimas.SetWidths(New Integer() {1, 1})
                    tabla_fimas.SpacingBefore = 120

                    'MsgBox(Grilla.Name)
                    Dim EsSupervisor As Boolean = False
                    If IsNumeric(TB.Name.ToString.Substring(0, 1)) Then
                        EsSupervisor = True
                    Else
                        EsSupervisor = False
                    End If

                    'Exporting to PDF
                    If direccion_archivo = "" Then
                        direccion_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
                        'If Not Directory.Exists(direccion_archivo) Then
                        '    Directory.CreateDirectory(direccion_archivo)
                        'End If
                    End If

                    Using stream As New FileStream(direccion_archivo & "Venta Diaria " & TB.Name & " " & Today.Date.Day & "-" & Today.Date.Month & ".pdf", FileMode.Create)
                        Dim pdfDoc As New Document(PageSize.A2.Rotate, 10.0F, 10.0F, 10.0F, 0.0F)

                        PdfWriter.GetInstance(pdfDoc, stream)
                        pdfDoc.Open()


                        Dim logo As Image
                        Dim recurso As String = My.Computer.FileSystem.CurrentDirectory
                        logo = Image.GetInstance(recurso & "\Resources\SR AGRO LOGO.jpg")
                        tabla_encabezado.AddCell(logo)
                        Dim A As String = ""
                        If Tipo = "Matinal" Then
                            A = "MATINAL "
                        Else
                            A = "VENTA DIARIA "
                        End If
                        Dim cell As New PdfPCell(New Phrase("SR AGRO, S.A. DE C.V. " & vbCrLf & _
                                        A & vbCrLf & "MES: " & (MonthName(Month(Cmb_Fecha_Inicial.Value))).ToUpper & " - " & Year(Cmb_Fecha_Inicial.Value), FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
                        cell.BorderColor = Color.WHITE
                        cell.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_encabezado.AddCell(cell)
                        tabla_encabezado.AddCell(New Phrase("Días Mensuales:  " & _
                                        vbTab & TextDiasMensuales.Text & vbCrLf & "Días Trabajados: " & vbTab & TextDiasTrabajados.Text & vbCrLf & "Días Restantes:   " & vbTab & TextDiasRestantes.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        If EsSupervisor = False Then
                            tabla_sub_encabezado.AddCell(New Phrase("Supervisor:    " & vbTab & "", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                            tabla_sub_encabezado.AddCell("")
                            tabla_sub_encabezado.AddCell("")
                            tabla_sub_encabezado.AddCell(New Phrase("Vendedor:     " & vbTab & TB.Text & vbTab & vbTab & vbTab & "                                         Fecha: " & Today.Date, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                            tabla_sub_encabezado.AddCell("")
                        Else
                            tabla_sub_encabezado.AddCell(New Phrase("Supervisor:    " & vbTab & Replace(TB.Text, "(Supervisor)", ""), FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                            tabla_sub_encabezado.AddCell("")
                            tabla_sub_encabezado.AddCell("")
                            tabla_sub_encabezado.AddCell("")
                            tabla_sub_encabezado.AddCell("")
                        End If

                        'tabla_sub_encabezado.AddCell(New Phrase("Fecha inicio de traslado: " & vbCrLf & cmb_fecha_inicio.Value.Date, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))
                        'tabla_sub_encabezado.AddCell(New Phrase("Destino:    " & txt_destino.Text & vbCrLf & "RTN:         " & rtn_destino & vbCrLf & _
                        '                             "Direccion: " & direccion_destino, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        tabla_sub_encabezado.AddCell("")
                        'tabla_sub_encabezado.AddCell(New Phrase("Fecha final de traslado: " & vbCrLf & cmb_fecha_final.Value.Date, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))

                        tabla_transportista.AddCell("")
                        'tabla_transportista.AddCell(New Phrase("    Transportista: " & txt_transportista.Text & vbCrLf & _
                        '                            "                 RTN: " & rtn_transportista & vbCrLf & _
                        '                            "Vehiculo Marca: " & marca & vbCrLf & _
                        '                            "              #Placa: " & placa, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        tabla_transportista.AddCell("")
                        Dim cell_sangria_titulo As New PdfPCell(New Phrase(""))
                        cell_sangria_titulo.BorderColor = Color.WHITE
                        Titulostabla_grilla.AddCell(cell_sangria_titulo)
                        Dim cell_sangria_titulo2 As New PdfPCell(New Phrase(""))
                        cell_sangria_titulo2.BorderColor = Color.WHITE
                        cell_sangria_titulo2.BorderColorLeft = Color.BLACK
                        cell_sangria_titulo2.BorderWidthLeft = 1


                        Dim cell_encabezadosPrincipales1 As New PdfPCell(New Phrase("MEDICIONES", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        cell_encabezadosPrincipales1.HorizontalAlignment = Element.ALIGN_CENTER
                        Titulostabla_grilla.AddCell(cell_encabezadosPrincipales1)
                        Dim cell_encabezadosPrincipales2 As New PdfPCell(New Phrase("ACUMULADO", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        cell_encabezadosPrincipales2.HorizontalAlignment = Element.ALIGN_CENTER
                        Titulostabla_grilla.AddCell(cell_encabezadosPrincipales2)
                        Titulostabla_grilla.AddCell(cell_sangria_titulo2)
                        Dim cell_encabezadosPrincipales3 As New PdfPCell(New Phrase("DIARIO", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        cell_encabezadosPrincipales3.HorizontalAlignment = Element.ALIGN_CENTER
                        Titulostabla_grilla.AddCell(cell_encabezadosPrincipales3)
                        Dim Cambio As Integer = 0
                        For Each TabInterna As TabPage In TbInterno.TabPages

                            For Each Grilla As DataGridView In TabInterna.Controls

                                If Grilla.Name.Substring(0, 3) = "TAB" Then
                                    If Cambio = 0 Then
                                        tabla_grilla.AddCell(cell_sangria_titulo)
                                        tabla_grilla2.AddCell(cell_sangria_titulo)


                                        For index As Integer = 0 To Grilla.ColumnCount - 1
                                            If index <> 3 Then
                                                Dim cell_encabezado As New PdfPCell(New Phrase(Grilla.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                                                cell_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
                                                cell_encabezado.BackgroundColor = Color.GRAY
                                                tabla_grilla.AddCell(cell_encabezado)
                                            End If
                                            If index = 5 Then
                                                tabla_grilla.AddCell(cell_sangria_titulo2)
                                            End If
                                        Next
                                        'If TB.Text = "EDIN MEJIA" Then
                                        Cambio = 1
                                        'End If

                                    End If


                                    For i As Integer = 0 To Grilla.RowCount - 1
                                        Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                                        cell_sangria_contenido.BorderColor = Color.WHITE
                                        Dim cell_sangria_contenido2 As New PdfPCell(New Phrase(""))
                                        cell_sangria_contenido2.BorderColor = Color.WHITE
                                        cell_sangria_contenido2.BorderColorLeft = Color.BLACK
                                        cell_sangria_contenido2.BorderWidthLeft = 1
                                        tabla_grilla.AddCell(cell_sangria_contenido)
                                        For j As Integer = 0 To Grilla.ColumnCount - 1
                                            'Dim CCC As Boolean = False
                                            If j <> 3 And j <> 2 Then
                                                Dim s As String = Grilla.Rows(i).Cells(j).Value.ToString
                                                Dim cellda As New PdfPCell
                                                cellda = New PdfPCell(New Phrase(s, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                                                If Grilla.Columns(j).HeaderText = "REAL" Then
                                                    cellda = New PdfPCell(New Phrase(Format(Val(CDec(s)), "##,##0.00"), FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                                                End If
                                                If j > 1 Then
                                                    cellda.HorizontalAlignment = Element.ALIGN_RIGHT
                                                End If
                                                If Grilla.Rows(i).Cells(0).Value.ToString = "TOTAL" Then
                                                    cellda.BackgroundColor = Color.LIGHT_GRAY
                                                Else
                                                    'CCC = False
                                                End If
                                                tabla_grilla.AddCell(cellda)
                                            End If
                                            If j = 2 Then
                                                Dim s As String = Grilla.Rows(i).Cells("META").Value.ToString
                                                Dim cellda As New PdfPCell(New Phrase(Format(Val(CDec(s)), "##,##0.00"), FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                                                cellda.HorizontalAlignment = Element.ALIGN_RIGHT
                                                If Grilla.Rows(i).Cells(0).Value.ToString = "TOTAL" Then
                                                    'CCC = True
                                                    cellda.BackgroundColor = Color.LIGHT_GRAY
                                                Else
                                                    'CCC = False
                                                End If
                                                tabla_grilla.AddCell(cellda)
                                            End If

                                            If j = 5 Then
                                                tabla_grilla.AddCell(cell_sangria_contenido2)
                                            End If
                                        Next
                                    Next


                                End If
                            Next
                        Next
                        Dim cell_motivo As New PdfPCell(New Phrase("Motivo: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                        cell_motivo.BackgroundColor = Color.GRAY
                        tabla_motivo.AddCell(cell_motivo)

                        'Dim cell_motivo_des As New PdfPCell(New Phrase(txt_motivo.Text, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                        'cell_motivo_des.BackgroundColor = Color.GRAY
                        'tabla_motivo.AddCell(cell_motivo_des)

                        Dim cell_motivo_sangria As New PdfPCell(New Phrase(""))
                        cell_motivo_sangria.BorderColor = Color.WHITE
                        tabla_motivo.AddCell(cell_motivo_sangria)

                        Dim cell_peso_titulo As New PdfPCell(New Phrase("Peso Total: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                        cell_peso_titulo.BackgroundColor = Color.GRAY
                        tabla_motivo.AddCell(cell_peso_titulo)

                        'Dim cell_peso_valor As New PdfPCell(New Phrase(txt_peso_total.Text, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                        'cell_peso_valor.BackgroundColor = Color.GRAY
                        'tabla_motivo.AddCell(cell_peso_valor)

                        'tabla_datos_adicionales.AddCell("Rango: ")
                        'tabla_datos_adicionales.AddCell(rango)

                        Dim cell_sangria_contenidoAdicional As New PdfPCell(New Phrase("Objetivo Cobertura"))
                        cell_sangria_contenidoAdicional.BorderColor = Color.BLACK
                        cell_sangria_contenidoAdicional.BorderWidth = 1
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(New Phrase("", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("Cobertura Real"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("Cobertura del día"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)

                        tabla_datos_adicionales.AddCell(New Phrase("", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        cell_sangria_contenidoAdicional.BorderColor = Color.BLACK
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("90%"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)
                        cell_sangria_contenidoAdicional.BorderColor = Color.BLACK
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("" & "%"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase(""))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)

                        'tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)
                        'tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)
                        'tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)


                        tabla_datos_adicionales2.AddCell(New Phrase("", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("Objetivo Efectividad"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("Efectividad Real"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("Efectividad del día"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)

                        tabla_datos_adicionales2.AddCell(New Phrase("", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("60%"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase(""))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase(""))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)



                        tabla_fimas.AddCell("                    _____________________________________________")
                        tabla_fimas.AddCell("                    ____________________________________")
                        tabla_fimas.AddCell("                                            " & TB.Text & "       ")
                        tabla_fimas.AddCell("                                         " & SUPERVISOR & "        ")

                        pdfDoc.Add(tabla_encabezado)
                        pdfDoc.Add(tabla_sub_encabezado)
                        pdfDoc.Add(tabla_transportista)
                        pdfDoc.Add(Titulostabla_grilla)
                        pdfDoc.Add(tabla_grilla)

                        pdfDoc.Add(tabla_motivo)
                        'pdfDoc.Add(tabla_datos_adicionales)
                        'pdfDoc.Add(tabla_datos_adicionales2)
                        pdfDoc.Add(tabla_fimas)

                        pdfDoc.Close()
                        stream.Close()

                        Process.Start(direccion_archivo & "Venta Diaria " & TB.Name & " " & Today.Date.Day & "-" & Today.Date.Month & ".pdf")
                    End Using
                Next
            End If
        Next
    End Sub

End Class
