Imports Disar.data
Imports System.IO
Imports System.Data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class FrmReporteMatinal

    Dim direccion_archivo = ""
    Dim Total As Integer = 0
    Dim Permiso As Integer = 0

    Private Sub FrmReporteMatinal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboEmpresa.Items.Clear()

        Try
            If _Inicio.SANRAFAEL = 1 Then
                ComboEmpresa.Items.Add("SAN RAFAEL")
            End If

            If _Inicio.DIMOSA = 1 Then
                ComboEmpresa.Items.Add("DIMOSA")
            End If
        Catch ex As Exception
        End Try

        ComboEmpresa.SelectedIndex = 0
        Dim db As New ClassVendedores
        Try
            Dim dt As New DataTable
            dt = db.Permiso(_Inicio.lblUsuario.Text)
            If Not IsDBNull(dt(0)(0)) Then
                Permiso = dt(0)(0)
            End If
            If Permiso > 0 Then
                ComboSuper.SelectedValue = Permiso
                'ComboSuper.Enabled = True
            Else
                'ComboSuper.Enabled = True
            End If
        Catch ex As Exception
        End Try
        DataVendedores.Columns.Clear()
        DataVendedores.DataSource = Nothing

        ComboTipo.SelectedItem = "DETALLE"

        GroupBox1.BringToFront()
        BtnListarVendedores.PerformClick()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataVendedores.CellValueChanged
        Total = 0
        For a = 0 To DataVendedores.RowCount - 1
            If DataVendedores.Rows(a).Cells(4).Value Then
                Total += 1
            End If
        Next
        'For a = 0 To DataSupervisores.RowCount - 1
        '    If DataSupervisores.Rows(a).Cells(4).Value Then
        '        Total += 1
        '    End If
        'Next
        Seleccionados.Text = Total
        'DataVendedores.CurrentCell = DataVendedores(1, DataVendedores.CurrentRow.Index)
        'DataVendedores.CurrentCell = DataVendedores(4, DataVendedores.CurrentRow.Index)
    End Sub

    Private Sub BtnListarVendedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnListarVendedores.Click
        ComboSuper.Visible = True
        LlenaSupervisores()
        If Permiso = 0 Then
            ComboSuper.Enabled = True
            If ComboSuper.SelectedValue = 10000 Then
                DataVendedores.DataSource = Nothing
                DataVendedores.Columns.Clear()
                DataSupervisores.DataSource = Nothing
                DataSupervisores.Columns.Clear()
                ChkTodos.CheckState = CheckState.Unchecked
                ChkTodos.Visible = True
                Dim dbVendedores As New ClassVendedores
                Dim Data As New DataView
                Dim Data2 As New DataView
                Seleccionados.Text = 0
                Total = 1
                Try
                    Data = dbVendedores.CargarVendedores(ComboEmpresa.Text, ComboTipo.Text)
                    If Not (IsNothing(dbVendedores.CargarVendedores(ComboEmpresa.Text, ComboTipo.Text))) Then
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

                Try
                    Data2 = dbVendedores.CargarSupervisores(ComboEmpresa.Text)
                    If Not (IsNothing(dbVendedores.CargarSupervisores(ComboEmpresa.Text))) Then
                        DataSupervisores.DataSource = Data2
                        If DataSupervisores.ColumnCount = 4 Then
                            Dim chk2 As New DataGridViewCheckBoxColumn()
                            DataSupervisores.Columns.Add(chk2)
                            chk2.HeaderText = "Calcular"
                            chk2.Name = "chk2"
                        End If

                        DataSupervisores.Columns(1).Width = 220%
                    End If
                Catch ex As Exception
                End Try

                BtnListarVendedores.Text = "Resetear Listado"
            End If
            DataSupervisores.ReadOnly = False
        Else
            'ComboSuper.Enabled = False
            ComboSuper.SelectedValue = Permiso
            DataSupervisores.ReadOnly = True
            For Each Row As DataGridViewRow In DataSupervisores.Rows
                If Row.Cells(0).Value = Permiso Then
                    Row.Cells(4).Value = True
                End If
            Next
        End If
        If _Inicio.Multiples = 1 Then
            DataSupervisores.ReadOnly = False
        End If
    End Sub

    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If ChkTodos.CheckState = CheckState.Checked Then
            For A As Integer = 0 To DataVendedores.RowCount - 1
                DataVendedores.Rows(A).Cells(4).Value = True
            Next
        Else
            For A As Integer = 0 To DataVendedores.RowCount - 1
                DataVendedores.Rows(A).Cells(4).Value = False
            Next
        End If

        'If ChkTodos.CheckState = CheckState.Checked Then
        '    For A As Integer = 0 To DataSupervisores.RowCount - 1
        '        DataSupervisores.Rows(A).Cells(4).Value = True
        '    Next
        'Else
        '    For A As Integer = 0 To DataSupervisores.RowCount - 1
        '        DataSupervisores.Rows(A).Cells(4).Value = False
        '    Next
        'End If
    End Sub

    Private Sub BtnMostrarInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrarInfo.Click

        GroupBox1.SendToBack()
        GroupBox2.BringToFront()
        TabControl1.TabPages.Clear()

        CalculoDias()
        For A As Integer = 0 To DataVendedores.RowCount - 1

            If DataVendedores.Rows(A).Cells(4).Value = True Then
                Dim Pantalla As New TabPage
                Pantalla.Text = DataVendedores.Rows(A).Cells(1).Value
                TabControl1.TabPages.Add(Pantalla)
                Pantalla.Name = DataVendedores.Rows(A).Cells(0).Value

                Dim Tipo As String = DataVendedores.Rows(A).Cells(3).Value

                Dim Tablita1 As New DataGridView
                Tablita1.Name = "TAB" & A
                Tablita1.Width = (TabControl1.Width) - 15
                Tablita1.Height = (TabControl1.Height / 1.6) - 15
                Tablita1.Location = New Point(1, 1)
                'Tablita1.Dock = DockStyle.Fill
                Pantalla.Controls.Add(Tablita1)
                Tablita1.AllowUserToAddRows = False
                Tablita1.AllowUserToDeleteRows = False
                Tablita1.AllowUserToResizeColumns = True
                For Each column As DataGridViewColumn In Tablita1.Columns
                    column.SortMode = DataGridViewColumnSortMode.NotSortable
                Next
                'With Tablita1.ColumnHeadersDefaultCellStyle
                '    .BackColor = Color.
                '    .ForeColor = Color.Black
                '    .Font = New Font(Tablita1.Font, FontStyle.Bold)
                'End With

                Dim Tablita2 As New DataGridView
                Tablita2.Name = "PROD" & A
                Tablita2.Width = (TabControl1.Width) - 15
                Tablita2.Height = (Tablita1.Height / 2) - 15
                Tablita2.Location = New Point(1, Tablita1.Height + 15)
                'Tablita1.Dock = DockStyle.Fill
                Pantalla.Controls.Add(Tablita2)
                Tablita2.AllowUserToAddRows = False
                Tablita2.AllowUserToDeleteRows = False
                Tablita2.AllowUserToResizeColumns = True
                For Each column As DataGridViewColumn In Tablita2.Columns
                    column.SortMode = DataGridViewColumnSortMode.NotSortable
                Next

                Dim db As New ClassVendedores

                Dim FEC As Date = 1 & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
                Dim dtMetas As New DataTable
                If ComboEmpresa.Text = "DIMOSA" Then
                    dtMetas = db.CargaMetasDIMOSA(Pantalla.Name.ToString)
                    Tablita2.DataSource = db.CargaMetasProductosDIMOSA(Pantalla.Name.ToString)
                Else
                    dtMetas = db.CargaMetas(Pantalla.Name.ToString)
                    Tablita2.DataSource = db.CargaMetasProductos(Pantalla.Name.ToString)
                End If

 
                Dim COL1 As New DataGridViewTextBoxColumn
                COL1.Name = "LINEA"
                COL1.HeaderText = "LINEA"

                Dim COL2 As New DataGridViewTextBoxColumn
                COL2.Name = "PROVEEDOR"
                COL2.HeaderText = "PROVEEDOR"

                Dim COL3 As New DataGridViewTextBoxColumn
                COL3.Name = "META_MENSUAL"
                COL3.HeaderText = "META MENSUAL"

                Dim COL4 As New DataGridViewTextBoxColumn
                COL4.Name = "TIPO"
                COL4.HeaderText = "TIPO"

                Dim COL5 As New DataGridViewTextBoxColumn
                COL5.Name = "REAL"
                COL5.HeaderText = "REAL"

                Dim COL6 As New DataGridViewTextBoxColumn
                COL6.Name = "PORC"
                COL6.HeaderText = "%"

                Dim COL7 As New DataGridViewTextBoxColumn
                COL7.Name = "META_DIARIA"
                COL7.HeaderText = "META DIARIA"

                Dim COL8 As New DataGridViewTextBoxColumn
                COL8.Name = "DESAFIO"
                COL8.HeaderText = "DESAFIO"

                Dim COL9 As New DataGridViewTextBoxColumn
                COL9.Name = "REAL_DIARIO"
                COL9.HeaderText = "REAL"

                Dim COL10 As New DataGridViewTextBoxColumn
                COL10.Name = "PRUEBA"
                COL10.HeaderText = "PRUEBA"

                Tablita1.Columns.Add(COL1)
                Tablita1.Columns.Add(COL2)
                Tablita1.Columns.Add(COL3)
                Tablita1.Columns.Add(COL4)
                Tablita1.Columns.Add(COL5)
                Tablita1.Columns.Add(COL6)
                Tablita1.Columns.Add(COL7)
                Tablita1.Columns.Add(COL8)
                Tablita1.Columns.Add(COL9)
                Tablita1.Columns.Add(COL10)

                Dim FECHA As Date = 1 & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
                For index As Integer = 0 To dtMetas.Rows.Count - 1
                    Dim DT1 As New DataTable
                    If ComboEmpresa.Text = "SAN RAFAEL" Then
                        DT1 = db.LineaMatinal(FECHA, Cmb_Fecha_Inicial.Value, Pantalla.Name.ToString, dtMetas.Rows(index)(0), TextDiasTrabajados.Text, TextDiasMensuales.Text, TextDiasRestantes.Text, dtMetas(index)(1))
                    Else
                        DT1 = db.LineaMatinalDIMOSA(FECHA, Cmb_Fecha_Inicial.Value, Pantalla.Name.ToString, dtMetas.Rows(index)(0), TextDiasTrabajados.Text, TextDiasMensuales.Text, TextDiasRestantes.Text, dtMetas(index)(1))
                    End If
                    Tablita1.Rows.Add(DT1(0)(0), DT1(0)(1), DT1(0)(2), DT1(0)(3), DT1(0)(4), DT1(0)(5), DT1(0)(6), DT1(0)(7), DT1(0)(8), DT1(0)(9))
                Next

                For Each column As DataGridViewColumn In Tablita2.Columns
                    column.ReadOnly = True
                Next

                Tablita1.Columns(3).Visible = False
                Tablita1.Columns("Prueba").Visible = False
                Tablita1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                Tablita1.Refresh()


                ''Matinal2
                Dim Mensual As Integer = 0
                For Each row As DataGridViewRow In Tablita2.Rows
                    If row.Index >= 0 Then
                        If Not IsDBNull(row.Cells("META MENSUAL").Value) Then
                            Mensual = row.Cells("META MENSUAL").Value
                        End If

                        Dim Metadiaria As Decimal = Math.Round(Mensual / Val(TextDiasMensuales.Text), 2)
                        row.Cells("META DIARIA").Value = Metadiaria.ToString("N2")

                        Dim dt As New DataTable
                        'Dim FECHA As Date = 1 & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
                        Dim Porcentaje As Decimal
                        If row.Cells(3).Value = "L" Then
                            If ComboEmpresa.Text = "DIMOSA" Then
                                dt = db.VentasLpsProductoDIMOSA(row.Cells("CONTAR DESDE").Value, Cmb_Fecha_Inicial.Value.Date, Pantalla.Name.ToString, row.Cells(0).Value)
                            Else
                                dt = db.VentasLpsProducto(row.Cells("CONTAR DESDE").Value, Cmb_Fecha_Inicial.Value.Date, Pantalla.Name.ToString, row.Cells(0).Value)
                            End If

                            Dim Real As Decimal = 0
                            If Not IsDBNull(dt(0)(0)) Then
                                Real = dt(0)(0)
                            End If
                            Try
                                Real = Math.Round(Real, 2)
                            Catch ex As Exception
                            End Try
                            Try
                                Metadiaria = Math.Round((Mensual - Real) / Val(TextDiasRestantes.Text), 2)
                            Catch ex As Exception
                            End Try

                            row.Cells("REAL").Value = Real.ToString("N2")
                            row.Cells("META DIARIA").Value = Metadiaria.ToString("N2")
                            Porcentaje = 0
                            Try
                                Porcentaje = (Val(row.Cells("REAL").Value) / Val(row.Cells("META MENSUAL").Value)) * 100
                                Porcentaje = Math.Round(Porcentaje, 2)
                            Catch ex As Exception
                            End Try
                        ElseIf row.Cells(3).Value = "CJ" Or row.Cells(3).Value = "Q" Or row.Cells(3).Value = "U" Then
                            If ComboEmpresa.Text = "DIMOSA" Then
                                dt = db.VentasCajasProductoDIMOSA(row.Cells("CONTAR DESDE").Value, Cmb_Fecha_Inicial.Value.Date, Pantalla.Name.ToString, row.Cells(0).Value, row.Cells(3).Value)
                            Else
                                dt = db.VentasCajasProducto(row.Cells("CONTAR DESDE").Value, Cmb_Fecha_Inicial.Value.Date, Pantalla.Name.ToString, row.Cells(0).Value, row.Cells(3).Value)
                            End If

                            Dim Real As Decimal = 0
                            Try
                                If Not IsDBNull(dt(0)(0)) Then
                                    Real = dt(0)(0)
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                If row.Cells(3).Value = "CJ" Then
                                    Real = Math.Floor(Real)
                                Else
                                    Real = Math.Round(Real, 2)
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                Metadiaria = Math.Round((Mensual - Real) / Val(TextDiasRestantes.Text), 2)
                            Catch ex As Exception
                            End Try
                            If row.Cells(3).Value = "CJ" Then
                                row.Cells("REAL").Value = Int(Real.ToString("N2"))
                            Else
                                row.Cells("REAL").Value = Real.ToString("N2")
                            End If

                            row.Cells("META DIARIA").Value = Metadiaria.ToString("N2")

                            Porcentaje = 0
                            Try
                                Porcentaje = (Val(row.Cells("REAL").Value) / Val(row.Cells("META MENSUAL").Value)) * 100
                                Porcentaje = Math.Round(Porcentaje, 2)
                            Catch ex As Exception
                            End Try
                        Else

                        End If
                        row.Cells("%").Value = Porcentaje & "%"
                    End If
                Next

                Tablita2.Columns(3).Visible = False
                Tablita2.Columns("Prueba").Visible = False
                Tablita2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                Tablita2.Refresh()
                Tablita2.Columns("REAL DIARIO").HeaderText = "REAL"

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

                    Row.Cells("%").Value = Porcentaje.ToString & " %"
                Next
            End If
        Next

        For A As Integer = 0 To DataSupervisores.RowCount - 1
            If DataSupervisores.Rows(A).Cells(4).Value = True Then
                Dim Pantalla As New TabPage
                Pantalla.Text = DataSupervisores.Rows(A).Cells(1).Value & " (Supervisor)"
                TabControl1.TabPages.Add(Pantalla)
                Pantalla.Name = DataSupervisores.Rows(A).Cells(0).Value

                Dim Tipo As String = DataSupervisores.Rows(A).Cells(3).Value

                Dim Tablita1 As New DataGridView
                Tablita1.Name = "TAB" & A
                Tablita1.Width = (TabControl1.Width / 2) - 15
                Tablita1.Location = New Point(1, 1)
                Tablita1.Dock = DockStyle.Fill
                Pantalla.Controls.Add(Tablita1)
                Tablita1.AllowUserToAddRows = False
                Tablita1.AllowUserToDeleteRows = False
                Tablita1.AllowUserToResizeColumns = True
                For Each column As DataGridViewColumn In Tablita1.Columns
                    column.SortMode = DataGridViewColumnSortMode.NotSortable
                Next
                'With Tablita1.ColumnHeadersDefaultCellStyle
                '    .BackColor = Color.
                '    .ForeColor = Color.Black
                '    .Font = New Font(Tablita1.Font, FontStyle.Bold)
                'End With

                Dim db As New ClassVendedores

                Dim FEC As Date = 1 & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
                If Pantalla.Text = "Ricardo Hernandez (Supervisor)" Then
                    Tablita1.DataSource = db.CargaMetasSupervisorPrincipal
                Else

                    If ComboEmpresa.Text = "DIMOSA" Then
                        Tablita1.DataSource = db.CargaMetasSupervisorDIMOSA(Pantalla.Name)
                    Else
                        Tablita1.DataSource = db.CargaMetasSupervisor(Pantalla.Name)
                    End If

                End If



                Dim dbC As New cls_bonificaciones
                Dim dtVolVentas As New DataTable

                Dim dtVend As New DataTable
                dtVend.Rows.Clear()
                If Pantalla.Text = "Ricardo Hernandez (Supervisor)" Then
                    Try
                        dtVend = db.VendedoresGeneral()
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If ComboEmpresa.Text = "DIMOSA" Then
                            dtVend = db.VendedoresNoMayoreoDIMOSA(Val(Pantalla.Name))
                        Else
                            dtVend = db.VendedoresNoMayoreo(Val(Pantalla.Name))
                        End If

                    Catch ex As Exception
                    End Try
                End If

                Dim VentaGeneral As Decimal = 0
                Dim MetaGeneral As Decimal = 0

                If ComboEmpresa.Text = "DIMOSA" Then
                    dtVolVentas = dbC.Bonificaciones_VentasMatinalDIMOSA(FEC, Cmb_Fecha_Inicial.Value.Date, Val(Pantalla.Name), "VENTAS_TOTALES_SUPERVISOR", 90)
                Else
                    dtVolVentas = dbC.Bonificaciones_VentasMatinal(FEC, Cmb_Fecha_Inicial.Value.Date, Val(Pantalla.Name), "VENTAS_TOTALES_SUPERVISOR", 90)
                End If

                If Not IsDBNull(dtVolVentas(0)(1)) Then
                    MetaGeneral += Convert.ToDecimal(dtVolVentas(0)(0))
                End If
                If Not IsDBNull(dtVolVentas(0)("Ventas")) Then
                    VentaGeneral += Convert.ToDecimal(dtVolVentas(0)("Ventas"))
                End If

                'dtVolVentas = dbC.Bonificaciones_VentasMatinal_Det_Super(FEC, Cmb_Fecha_Inicial.Value.Date, Pantalla.Name, "VENTAS_TOTALES", 90, 1)

                Tablita1.Rows(0).Cells(2).Value = Convert.ToDecimal(MetaGeneral)

                Dim style As New DataGridViewCellStyle
                style.Format = "N2"

                For Each column As DataGridViewColumn In Tablita1.Columns
                    If column.Index = 2 Or column.Index = 4 Then
                        column.DefaultCellStyle = style
                    End If
                    column.ReadOnly = True
                Next

                Dim Mensual As Decimal = 0
                For Each row As DataGridViewRow In Tablita1.Rows
                    If row.Index >= 0 Then
                        If Not IsDBNull(row.Cells("META MENSUAL").Value) Then
                            Mensual = row.Cells("META MENSUAL").Value
                        End If

                        Dim Metadiaria As Decimal = Math.Round(Mensual / Val(TextDiasMensuales.Text), 2)
                        row.Cells("META DIARIA").Value = Metadiaria.ToString("N2")

                        Dim dt As New DataTable
                        Dim FECHA As Date = 1 & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
                        Dim Porcentaje As Decimal
                        If row.Cells(3).Value = "L" Then
                            Dim dtVendedores As New DataTable
                            dtVendedores.Rows.Clear()
                            If Pantalla.Text = "Ricardo Hernandez (Supervisor)" Then
                                Try
                                    dtVend = db.VendedoresGeneral()
                                Catch ex As Exception
                                End Try
                            Else
                                Try
                                    If ComboEmpresa.Text = "DIMOSA" Then
                                        dtVend = db.VendedoresNoMayoreoDIMOSA(Val(Pantalla.Name))
                                    Else
                                        dtVend = db.VendedoresNoMayoreo(Val(Pantalla.Name))
                                    End If

                                Catch ex As Exception
                                End Try
                            End If

                            Dim Real As Decimal = 0
                            For x As Integer = 0 To dtVend.Rows.Count - 1
                                If ComboEmpresa.Text = "DIMOSA" Then
                                    dt = db.VentasLpsDIMOSA(FECHA.Date, Cmb_Fecha_Inicial.Value.Date, dtVend(x)(0), row.Cells(0).Value)
                                Else
                                    dt = db.VentasLps(FECHA.Date, Cmb_Fecha_Inicial.Value.Date, dtVend(x)(0), row.Cells(0).Value)
                                End If

                                If Not IsDBNull(dt(0)(0)) Then
                                    Real += dt(0)(0)
                                End If
                            Next

                            Try
                                Real = Math.Round(Real, 2)
                            Catch ex As Exception
                            End Try
                            Try
                                Metadiaria = Math.Round((Mensual - Real) / Val(TextDiasRestantes.Text), 2)
                            Catch ex As Exception
                            End Try

                            row.Cells("REAL").Value = Real.ToString("N2")
                            row.Cells("META DIARIA").Value = Metadiaria.ToString("N2")
                            Porcentaje = 0
                            Try
                                Porcentaje = (Val(row.Cells("REAL").Value) / Val(row.Cells("META MENSUAL").Value)) * 100
                                Porcentaje = Math.Round(Porcentaje, 2)
                            Catch ex As Exception
                            End Try
                        ElseIf row.Cells(3).Value = "CJ" Or row.Cells(3).Value = "Q" Then
                            Dim dtVendedores As New DataTable
                            dtVendedores.Rows.Clear()
                            If Pantalla.Text = "Ricardo Hernandez (Supervisor)" Then
                                Try
                                    dtVend = db.VendedoresGeneral()
                                Catch ex As Exception
                                End Try
                            Else
                                Try
                                    If ComboEmpresa.Text = "DIMOSA" Then
                                        dtVend = db.VendedoresNoMayoreoDIMOSA(Val(Pantalla.Name))
                                    Else
                                        dtVend = db.VendedoresNoMayoreo(Val(Pantalla.Name))
                                    End If

                                Catch ex As Exception
                                End Try
                            End If

                            Dim Real As Decimal = 0
                            For x As Integer = 0 To dtVend.Rows.Count - 1
                                If ComboEmpresa.Text = "DIMOSA" Then
                                    dt = db.VentasCajasDIMOSA(FECHA.Date, Cmb_Fecha_Inicial.Value.Date, dtVend(x)(0), row.Cells(0).Value, row.Cells(3).Value)
                                Else
                                    dt = db.VentasCajas(FECHA.Date, Cmb_Fecha_Inicial.Value.Date, dtVend(x)(0), row.Cells(0).Value, row.Cells(3).Value)
                                End If

                                Try
                                    If Not IsDBNull(dt(0)(0)) Then
                                        Real += dt(0)(0)
                                    End If
                                Catch ex As Exception
                                End Try

                            Next

                            Try
                                If row.Cells(3).Value = "CJ" Then
                                    Real = Math.Floor(Real)
                                Else
                                    Real = Math.Round(Real, 2)
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                Metadiaria = Math.Round((Mensual - Real) / Val(TextDiasRestantes.Text), 2)
                            Catch ex As Exception
                            End Try
                            If row.Cells(3).Value = "CJ" Then
                                row.Cells("REAL").Value = Int(Real.ToString("N2"))
                            Else
                                row.Cells("REAL").Value = Real.ToString("N2")
                            End If

                            row.Cells("META DIARIA").Value = Metadiaria.ToString("N2")

                            Porcentaje = 0
                            Try
                                Porcentaje = (Val(row.Cells("REAL").Value) / Val(row.Cells("META MENSUAL").Value)) * 100
                                Porcentaje = Math.Round(Porcentaje, 2)
                            Catch ex As Exception
                            End Try
                        Else

                        End If

                        row.Cells("%").Value = Porcentaje & "%"

                    End If
                Next

                Tablita1.Columns(3).Visible = False
                Tablita1.Columns("Prueba").Visible = False
                Tablita1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                Tablita1.Refresh()
                Tablita1.Columns("REAL DIARIO").HeaderText = "REAL"


                'MsgBox(Convert.ToDecimal(dtVolVentas(0)("Ventas")) & " -  " & dtVolVentas(0)("Ventas"))

                Tablita1.Rows(0).Cells(4).Value = Convert.ToDecimal(VentaGeneral).ToString("N2")

                Tablita1.Rows(0).Cells("Prueba").Value = MetaGeneral.ToString("N2")

                Dim Diaria0 = 0
                Dim Ventas0 As Decimal = 0

                Try
                    Ventas0 = dtVolVentas(0)("Ventas")
                Catch ex As Exception

                End Try

                Dim Mensual0 = 0
                Mensual0 = 0

                Try
                    Mensual0 = dtVolVentas(0)(1)
                Catch ex As Exception
                End Try

                Try
                    Diaria0 = Math.Round((Mensual0 - Ventas0) / Val(TextDiasRestantes.Text), 2)
                Catch ex As Exception
                End Try

                Tablita1.Rows(0).Cells("META DIARIA").Value = Diaria0.ToString("N2")

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

                    Row.Cells("%").Value = Porcentaje.ToString & " %"

                    Try
                        If Row.Index = 0 Then
                            Dim MENS As Decimal = 0
                            Dim REAL As Decimal = 0
                            Dim DIARIA As Decimal = 0
                            MENS = Row.Cells("META MENSUAL").Value
                            REAL = Row.Cells("REAL").Value
                            DIARIA = (MENS - REAL) / Val(TextDiasRestantes.Text)
                            Row.Cells(6).Value = DIARIA.ToString("N2")
                            'MsgBox(Row.Cells(5).Value)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Next

            End If
        Next

    End Sub

    Private Sub BtnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver.Click
        GroupBox1.BringToFront()
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

            Dim Feriados As Integer = 0
            Dim dt As New DataTable
            Dim db As New clsPresupuestos

            Try
                dt = db.ListarFeriadosMes(Cmb_Fecha_Inicial.Value.Month, Cmb_Fecha_Inicial.Value.Year)
                Feriados = dt.Rows.Count
            Catch ex As Exception
            End Try

            TextDiasMensuales.Text = Cantidad_Dias - domingos - Feriados
            TextDiasTrabajados.Text = contador - domingosActuales

            For a As Integer = 0 To dt.Rows.Count - 1
                If Today.Date >= dt.Rows(a)(0) Then
                    TextDiasTrabajados.Text = Val(TextDiasTrabajados.Text) - 1
                End If
            Next

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

        'Exporting to PDF
        If direccion_archivo = "" Then
            direccion_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
            'If Not Directory.Exists(direccion_archivo) Then
            '    Directory.CreateDirectory(direccion_archivo)
            'End If
        End If

        Using stream As New FileStream(direccion_archivo & "Venta Diaria " & Today.Date.Day & "-" & Today.Date.Month & ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2.Rotate, 10.0F, 10.0F, 10.0F, 0.0F)

            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            For Each TB As TabPage In TabControl1.TabPages

                Dim db As New ClassVendedores
                Dim dtSupervisor As New DataTable
                Dim SUPERVISOR As String = ""
                Try
                    dtSupervisor.Rows.Clear()
                    dtSupervisor = db.SeleccionaSupervisor(TB.Name, ComboEmpresa.Text)
                    SUPERVISOR = dtSupervisor(0)(0)
                Catch ex As Exception
                End Try

                Dim db2 As New cls_bonificaciones
                Dim dtVentas As New DataTable
                Dim Ventas As Decimal = 0
                Dim Ideal As Integer = 0
                Dim MetaC As Decimal
                Dim MetaE As Decimal
                Dim TotalEfectividad As Decimal

                If InStr(TB.Text, "Supervisor") > 0 Then
                    Try
                        dtVentas.Rows.Clear()
                        If ComboEmpresa.Text = "SAN RAFAEL" Then
                            dtVentas = db2.Bonificaciones_VentasMatinal(FECHACARGA.Date, Cmb_Fecha_Inicial.Value.Date, TB.Name, "COBERTURA_CLIENTES_SUPERVISOR", 90)
                        Else
                            dtVentas = db2.Bonificaciones_VentasMatinalDIMOSA(FECHACARGA.Date, Cmb_Fecha_Inicial.Value.Date, TB.Name, "COBERTURA_CLIENTES_SUPERVISOR", 90)
                        End If


                        'MsgBox(Tb.name)
                        Ventas = dtVentas(0)(2)
                        Ventas = Math.Round(Ventas, 2)

                        Ideal = dtVentas(0)(1)

                        MetaC = dtVentas(0)(4)
                        MetaC = Math.Round(MetaC, 2)

                        MetaE = dtVentas(0)(5)
                        MetaE = Math.Round(MetaE, 2)

                        TotalEfectividad = dtVentas(0)(6)
                        TotalEfectividad = Math.Round(TotalEfectividad, 2)
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        dtVentas.Rows.Clear()
                        If ComboEmpresa.Text = "SAN RAFAEL" Then
                            dtVentas = db2.Bonificaciones_VentasMatinal(FECHACARGA.Date, Cmb_Fecha_Inicial.Value.Date, TB.Name, "COBERTURA_CLIENTES", 90)
                        Else
                            dtVentas = db2.Bonificaciones_VentasMatinalDIMOSA(FECHACARGA.Date, Cmb_Fecha_Inicial.Value.Date, TB.Name, "COBERTURA_CLIENTES", 90)
                        End If

                        'MsgBox(Tb.name)
                        Ventas = dtVentas(0)(2)
                        Ventas = Math.Round(Ventas, 2)

                        Ideal = dtVentas(0)(1)

                        MetaC = dtVentas(0)(4)
                        MetaC = Math.Round(MetaC, 2)

                        MetaE = dtVentas(0)(5)
                        MetaE = Math.Round(MetaE, 2)

                        TotalEfectividad = dtVentas(0)(6)
                        TotalEfectividad = Math.Round(TotalEfectividad, 2)
                    Catch ex As Exception
                    End Try
                End If

                

                Dim Efectividad As Decimal = 0
                Try
                    If InStr(TB.Text, "Supervisor") > 0 Then
                        Dim DT As New DataTable
                        If ComboEmpresa.Text = "SAN RAFAEL" Then
                            DT = db2.Bonificaciones_VentasMatinal(FECHACARGA.Date, Cmb_Fecha_Inicial.Value.Date, TB.Name, "EFECTIVIDAD_SUPERVISOR", 90)
                        Else
                            DT = db2.Bonificaciones_VentasMatinalDIMOSA(FECHACARGA.Date, Cmb_Fecha_Inicial.Value.Date, TB.Name, "EFECTIVIDAD_SUPERVISOR", 90)
                        End If
                        Efectividad = DT(0)(0)
                    Else
                        Dim DT As New DataTable
                        If ComboEmpresa.Text = "SAN RAFAEL" Then
                            Efectividad = CargaEfectivos(TB.Name)
                        Else
                            DT = db2.Bonificaciones_VentasMatinalDIMOSA(FECHACARGA.Date, Cmb_Fecha_Inicial.Value.Date, TB.Name, "EFECTIVIDAD", 90)
                        End If
                        Efectividad = DT(0)(0)
                    End If

                Catch ex As Exception
                    'MsgBox("    ." & ex.Message)
                End Try

                For Each Grilla As DataGridView In TB.Controls
                    If Grilla.Name.Substring(0, 3) = "TAB" Then
                        'MsgBox(Grilla.Name)

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
                        Titulostabla_grilla.SetWidths(New Integer() {2, 4, 6, 1, 6})
                        Titulostabla_grilla.SpacingBefore = 30

                        Dim tabla_grilla As New PdfPTable(10)
                        tabla_grilla.DefaultCell.Padding = 3
                        tabla_grilla.WidthPercentage = 30
                        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
                        tabla_grilla.DefaultCell.BorderWidth = 1
                        tabla_grilla.WidthPercentage = (480 / 5.23F)
                        tabla_grilla.SetWidths(New Integer() {2, 1, 3, 2, 2, 2, 1, 2, 2, 2})
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
                        tabla_motivo.SpacingBefore = 0

                        Dim tabla_datos_adicionales As New PdfPTable(5)
                        tabla_datos_adicionales.DefaultCell.Padding = 3
                        tabla_datos_adicionales.DefaultCell.BorderColor = Color.WHITE
                        tabla_datos_adicionales.HorizontalAlignment = Element.ALIGN_LEFT
                        tabla_datos_adicionales.WidthPercentage = (385 / 5.23F)
                        tabla_datos_adicionales.SetWidths(New Integer() {1, 1, 1, 1, 1})
                        tabla_datos_adicionales.SpacingBefore = 30

                        Dim tabla_datos_adicionales2 As New PdfPTable(5)
                        tabla_datos_adicionales2.DefaultCell.Padding = 3
                        tabla_datos_adicionales2.DefaultCell.BorderColor = Color.WHITE
                        tabla_datos_adicionales2.HorizontalAlignment = Element.ALIGN_LEFT
                        tabla_datos_adicionales2.WidthPercentage = (385 / 5.23F)
                        tabla_datos_adicionales2.SetWidths(New Integer() {1, 1, 1, 1, 1})
                        tabla_datos_adicionales2.SpacingBefore = 0

                        Dim tabla_fimas As New PdfPTable(2)
                        tabla_fimas.DefaultCell.Padding = 3
                        tabla_fimas.DefaultCell.BorderColor = Color.WHITE
                        tabla_fimas.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_fimas.WidthPercentage = (300 / 5.23F)
                        tabla_fimas.SetWidths(New Integer() {1, 1})
                        tabla_fimas.SpacingBefore = 80

                        Dim EsSupervisor As Boolean = False
                        If IsNumeric(TB.Name.ToString.Substring(0, 1)) Then
                            EsSupervisor = True
                        Else
                            EsSupervisor = False
                        End If


                        Dim logo As Image
                        Dim recurso As String = My.Computer.FileSystem.CurrentDirectory
                        If ComboEmpresa.Text = "DIMOSA" Then
                            logo = Image.GetInstance(recurso & "\Resources\DIMOSA.png")
                        Else
                            logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")
                        End If

                        tabla_encabezado.AddCell(logo)
                        Dim cell
                        If ComboEmpresa.Text = "DIMOSA" Then
                            cell = New PdfPCell(New Phrase("DISTRIBUIDORA MODERNA S.A. DE C.V. " & vbCrLf & _
                         "MATINAL DIMOSA", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
                        Else
                            cell = New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL, S. DE R.L. DE C.V. " & vbCrLf & _
                        "MATINAL", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
                        End If

                        cell.BorderColor = Color.WHITE
                        cell.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_encabezado.AddCell(cell)
                        tabla_encabezado.AddCell(New Phrase("Días Mensuales:  " & _
                                        vbTab & TextDiasMensuales.Text & vbCrLf & "Días Trabajados: " & vbTab & TextDiasTrabajados.Text & vbCrLf & "Días Restantes:   " & vbTab & TextDiasRestantes.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        If EsSupervisor = False Then
                            tabla_sub_encabezado.AddCell(New Phrase("Supervisor:    " & vbTab & SUPERVISOR, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                            tabla_sub_encabezado.AddCell("")
                            tabla_sub_encabezado.AddCell("")
                            tabla_sub_encabezado.AddCell(New Phrase("Vendedor:     " & vbTab & TB.Text & vbTab & vbTab & vbTab & "                                         Fecha: " & Today.Date, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                            tabla_sub_encabezado.AddCell("")
                        Else
                            tabla_sub_encabezado.AddCell(New Phrase("Supervisor:    " & vbTab & Replace(TB.Text, "(Supervisor)", ""), FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                            tabla_sub_encabezado.AddCell("")
                            'tabla_sub_encabezado.AddCell("")
                            'tabla_sub_encabezado.AddCell("")
                            'tabla_sub_encabezado.AddCell("")
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
                        tabla_grilla.AddCell(cell_sangria_titulo)
                        tabla_grilla2.AddCell(cell_sangria_titulo)
                        Dim cell_sangria_titulo2 As New PdfPCell(New Phrase(""))
                        cell_sangria_titulo2.BorderColor = Color.WHITE
                        cell_sangria_titulo2.BorderColorLeft = Color.BLACK
                        cell_sangria_titulo2.BorderWidthLeft = 1

                        Titulostabla_grilla.AddCell(cell_sangria_titulo)

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

                        For index As Integer = 0 To Grilla.ColumnCount - 2
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

                        For i As Integer = 0 To Grilla.RowCount - 1
                            Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                            cell_sangria_contenido.BorderColor = Color.WHITE
                            Dim cell_sangria_contenido2 As New PdfPCell(New Phrase(""))
                            cell_sangria_contenido2.BorderColor = Color.WHITE
                            cell_sangria_contenido2.BorderColorLeft = Color.BLACK
                            cell_sangria_contenido2.BorderWidthLeft = 1
                            tabla_grilla.AddCell(cell_sangria_contenido)
                            For j As Integer = 0 To Grilla.ColumnCount - 2
                                If j <> 3 And j <> 2 Then
                                    Dim s As String = Grilla.Rows(i).Cells(j).Value.ToString
                                    Dim cellda As New PdfPCell(New Phrase(s, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                                    If j > 1 Then
                                        cellda.HorizontalAlignment = Element.ALIGN_RIGHT
                                    End If
                                    tabla_grilla.AddCell(cellda)
                                End If
                                If j = 2 Then
                                    Dim s As String = Grilla.Rows(i).Cells("PRUEBA").Value.ToString
                                    Dim cellda As New PdfPCell(New Phrase(s, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                                    cellda.HorizontalAlignment = Element.ALIGN_RIGHT
                                    tabla_grilla.AddCell(cellda)
                                End If
                                If j = 5 Then
                                    tabla_grilla.AddCell(cell_sangria_contenido2)
                                End If
                            Next
                        Next

                        For Each TABLITA As DataGridView In TB.Controls
                            If TABLITA.Name.Substring(0, 3) = "PRO" Then
                                If TABLITA.RowCount > 0 Then

                                    For index As Integer = 0 To TABLITA.ColumnCount - 3
                                        If index <> 3 Then
                                            Dim cell_encabezado As New PdfPCell(New Phrase(TABLITA.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                                            cell_encabezado.HorizontalAlignment = Element.ALIGN_CENTER
                                            cell_encabezado.BackgroundColor = Color.GRAY
                                            tabla_grilla2.AddCell(cell_encabezado)
                                        End If
                                        If index = 5 Then
                                            tabla_grilla2.AddCell(cell_sangria_titulo2)
                                        End If
                                    Next

                                    For i As Integer = 0 To TABLITA.RowCount - 1
                                        Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                                        cell_sangria_contenido.BorderColor = Color.WHITE
                                        Dim cell_sangria_contenido2 As New PdfPCell(New Phrase(""))
                                        cell_sangria_contenido2.BorderColor = Color.WHITE
                                        cell_sangria_contenido2.BorderColorLeft = Color.BLACK
                                        cell_sangria_contenido2.BorderWidthLeft = 1
                                        tabla_grilla2.AddCell(cell_sangria_contenido)
                                        For j As Integer = 0 To TABLITA.ColumnCount - 3
                                            If j <> 3 And j <> 2 Then
                                                Dim s As String = TABLITA.Rows(i).Cells(j).Value.ToString
                                                Dim cellda As New PdfPCell(New Phrase(s, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                                                If j > 1 Then
                                                    cellda.HorizontalAlignment = Element.ALIGN_RIGHT
                                                End If
                                                tabla_grilla2.AddCell(cellda)
                                            End If
                                            If j = 2 Then
                                                Dim s As String = TABLITA.Rows(i).Cells("PRUEBA").Value.ToString
                                                Dim cellda As New PdfPCell(New Phrase(s, FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
                                                cellda.HorizontalAlignment = Element.ALIGN_RIGHT
                                                tabla_grilla2.AddCell(cellda)
                                            End If
                                            If j = 5 Then
                                                tabla_grilla2.AddCell(cell_sangria_contenido2)
                                            End If
                                        Next
                                    Next
                                End If
                            End If
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
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("Total Universo"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("Objetivo Cobertura"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("Cobertura Real"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("%"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)

                        'Dim Ini As Decimal = 90 * Val(TextDiasTrabajados.Text)
                        tabla_datos_adicionales.AddCell(New Phrase("", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                        cell_sangria_contenidoAdicional.BorderColor = Color.BLACK
                        'Dim Valor As Decimal = 90 * Val(TextDiasTrabajados.Text)
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase(Ideal.ToString))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase(MetaC.ToString))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)
                        cell_sangria_contenidoAdicional.BorderColor = Color.BLACK
                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase(Ventas.ToString))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)

                        Dim Porc As Decimal = 0
                        Try
                            Porc = (Ventas / MetaC) * 100
                        Catch ex As Exception
                        End Try

                        Porc = Math.Round(Porc, 2)

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase(Porc.ToString & "%"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)

                        'tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)
                        'tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)
                        'tabla_datos_adicionales.AddCell(cell_sangria_contenidoAdicional)

                        tabla_datos_adicionales2.AddCell(New Phrase("", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("Total Efectividad"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("Objetivo Efectividad"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("Efectividad Real"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase("%"))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)

                        tabla_datos_adicionales2.AddCell(New Phrase("", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase(TotalEfectividad.ToString))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase(MetaE.ToString))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase(Efectividad.ToString))
                        cell_sangria_contenidoAdicional.HorizontalAlignment = Element.ALIGN_CENTER
                        tabla_datos_adicionales2.AddCell(cell_sangria_contenidoAdicional)

                        Dim PorcEf As Decimal = 0
                        Try
                            PorcEf = (Efectividad / MetaE) * 100
                        Catch ex As Exception
                        End Try

                        PorcEf = Math.Round(PorcEf, 2)

                        cell_sangria_contenidoAdicional = New PdfPCell(New Phrase(PorcEf.ToString & "%"))
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
                        For Each TABLITA As DataGridView In TB.Controls
                            If TABLITA.Name.Substring(0, 3) = "PRO" Then
                                If TABLITA.RowCount > 0 Then
                                    pdfDoc.Add(Titulostabla_grilla)
                                    pdfDoc.Add(tabla_grilla2)
                                End If
                            End If
                        Next
                        pdfDoc.Add(tabla_motivo)
                        pdfDoc.Add(tabla_datos_adicionales)
                        pdfDoc.Add(tabla_datos_adicionales2)
                        pdfDoc.Add(tabla_fimas)


                    End If
                Next
                pdfDoc.NewPage()
            Next
            pdfDoc.Close()
            stream.Close()

            Process.Start(direccion_archivo & "Venta Diaria " & Today.Date.Day & "-" & Today.Date.Month & ".pdf")
        End Using
    End Sub

    Dim dias, i, Lun, Mar, Mie, Jue, Vie, sab, TotalVisitas, TotalEfectivos, TotalNC, TotalV, TotalE As Integer
    Dim fechainicio, fechaterminal As Date
    Dim DataView, dv As DataView

    Dim _ListaSPS As New _clsVendedoresSRC
    Dim _VisitadosSRC As New cls_efectividad_src
    Dim miDataTable As New DataTable
    Dim Lineas As DataRow = miDataTable.NewRow()
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim activo As Integer = 0

    Sub ClearDias()
        Lun = 0
        Mar = 0
        Mie = 0
        Jue = 0
        Vie = 0
        sab = 0
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
        Dim db As New cls_efectividad_src
        dv = db.VisitadosRangoFechas(Clave, dias, dias1, dias2)
        If Not IsNothing(db.VisitadosRangoFechas(Clave, dias, dias1, dias2)) Then
            _GridVisitados.DataSource = dv
        End If
    End Sub

    Sub Efectivos(ByVal Fecha As Date, ByVal Fecha2 As Date, ByVal Clave As Integer)
        Try
            Dim db As New cls_efectividad_src
            DataView = db.EfectivosRangoFechasGeneral(Fecha, Fecha2, Clave)

            If Not IsNothing(db.EfectivosRangoFechasGeneral(Fecha, Fecha2, Clave)) Then
                _GridEfectivos.DataSource = DataView
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub NotasCredto(ByVal Fecha As Date, ByVal Fecha2 As Date, ByVal Clave As Integer)
        'Try
        Dim db As New cls_efectividad_src
        DataView = db.NotasCreditoGeneral(Fecha, Fecha2, Clave)
        If Not IsNothing(db.NotasCreditoGeneral(Fecha, Fecha2, Clave)) Then
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

    Public Function CargaEfectivos(ByVal VENDEDOR As String)

        Dim Porcentaje As String = ""

        Try
            activo = 1
            limpiar()

            TotalVisitas = 0
            TotalNC = 0
            TotalEfectivos = 0
            Dim Fecha As Date = 1 & "/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
            Efectivos(Fecha.Date, Cmb_Fecha_Inicial.Value.Date, VENDEDOR)
            NotasCredto(Fecha.Date, Cmb_Fecha_Inicial.Value.Date, VENDEDOR)

            TotaldeVisitas(VENDEDOR)

            TotalNC = _GridNC.RowCount
            _GridNC.DataSource = Nothing
            TotalEfectivos = _GridEfectivos.RowCount + TotalNC


            If TotalVisitas = 0 Then

                Porcentaje = 0
            Else
                ' Lineas("Porcentaje") = Math.Round(TotalEfectivos / TotalVisitas * 100) & " %"
                Porcentaje = Math.Round(TotalEfectivos / TotalVisitas * 100)
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

        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return TotalEfectivos

    End Function

    Sub LlenaSupervisores()
        Dim db As New ClassVendedores
        Try
            ComboSuper.DataSource = db.CargarSupervisoresCombo(ComboEmpresa.Text, Permiso)
            ComboSuper.ValueMember = "Código de Supervisor"
            ComboSuper.DisplayMember = "Nombre"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboSuper_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSuper.SelectedValueChanged, ComboTipo.SelectedIndexChanged
        Try
            If ComboSuper.SelectedValue = 10000 Then
                DataVendedores.DataSource = Nothing
                DataVendedores.Columns.Clear()
                DataSupervisores.DataSource = Nothing
                DataSupervisores.Columns.Clear()
                ChkTodos.CheckState = CheckState.Unchecked
                ChkTodos.Visible = True
                Dim dbVendedores As New ClassVendedores
                Dim Data As New DataView
                Dim Data2 As New DataView
                Seleccionados.Text = 0
                Total = 1
                Try
                    Data = dbVendedores.CargarVendedores(ComboEmpresa.Text, ComboTipo.Text)
                    If Not (IsNothing(dbVendedores.CargarVendedores(ComboEmpresa.Text, ComboTipo.Text))) Then
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

                Try
                    Data2 = dbVendedores.CargarSupervisores(ComboEmpresa.Text)
                    If Not (IsNothing(dbVendedores.CargarSupervisores(ComboEmpresa.Text))) Then
                        DataSupervisores.DataSource = Data2
                        If DataSupervisores.ColumnCount = 4 Then
                            Dim chk2 As New DataGridViewCheckBoxColumn()
                            DataSupervisores.Columns.Add(chk2)
                            chk2.HeaderText = "Calcular"
                            chk2.Name = "chk2"
                        End If

                        DataSupervisores.Columns(1).Width = 220%
                    End If
                Catch ex As Exception
                End Try

                BtnListarVendedores.Text = "Resetear Listado"
            Else
                DataVendedores.DataSource = Nothing
                DataVendedores.Columns.Clear()
                DataSupervisores.DataSource = Nothing
                DataSupervisores.Columns.Clear()
                ChkTodos.CheckState = CheckState.Unchecked
                ChkTodos.Visible = True
                Dim dbVendedores As New ClassVendedores
                Dim Data As New DataView
                Dim Data2 As New DataView
                Seleccionados.Text = 0
                Total = 1
                Try
                    Data = dbVendedores.CargarVendedoresPORSUPERVISOR(ComboSuper.SelectedValue, ComboEmpresa.Text, ComboTipo.Text)
                    If Not (IsNothing(dbVendedores.CargarVendedoresPORSUPERVISOR(ComboSuper.SelectedValue, ComboEmpresa.Text, ComboTipo.Text))) Then
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

                Try
                    Data2 = dbVendedores.CargarSupervisores(ComboEmpresa.Text)
                    If Not (IsNothing(dbVendedores.CargarSupervisores(ComboEmpresa.Text))) Then
                        DataSupervisores.DataSource = Data2
                        If DataSupervisores.ColumnCount = 4 Then
                            Dim chk2 As New DataGridViewCheckBoxColumn()
                            DataSupervisores.Columns.Add(chk2)
                            chk2.HeaderText = "Calcular"
                            chk2.Name = "chk2"
                        End If

                        DataSupervisores.Columns(1).Width = 220%
                    End If
                Catch ex As Exception
                End Try

                BtnListarVendedores.Text = "Resetear Listado"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEmpresa.SelectedIndexChanged
        'Dim db As New ClassVendedores
        'Try
        '    ComboSuper.DataSource = db.CargarSupervisoresEmpresa(ComboEmpresa.Text)
        '    ComboSuper.ValueMember = "Código de Supervisor"
        '    ComboSuper.DisplayMember = "Nombre"
        'Catch ex As Exception
        'End Try
        LlenaSupervisores()
    End Sub

End Class