Imports Disar.data

Public Class Frm_Bonificaciones_Nuevo
    Dim Conexion As New cls_bonificaciones
    Dim dias_habiles As Integer = 0
    Dim tcpe_peso_supervisor As Double = 0, tcpe_resultado_supervisor As Double = 0, tcpe_meta_supervisor As Double = 0
    Dim tcpe_medicion_supervisor As Double = 0, tcpe_divisor As Double = 0

    Dim efe_peso_supervisor As Double = 0, efe_resultado_supervisor As Double = 0, efe_meta_supervisor As Double = 0
    Dim efe_medicion_supervisor As Double = 0, efe_divisor_supervisor As Double = 0

    Dim cob_peso_supervisor As Double = 0, cob_resultado_supervisor As Double = 0, cob_meta_supervisor As Double = 0
    Dim cob_medicion_supervisor As Double = 0, cob_divisor_supervisor As Double = 0

    Dim vol_peso_supervisor As Double = 0, vol_resultado_supervisor As Double = 0, vol_meta_supervisor As Double = 0
    Dim vol_medicion_supervisor As Double = 0, vol_divisor_supervisor As Double = 0, vol_divisor_supervisor_may As Double = 0
    Dim vol_meta_total As Double = 0, vol_venta_total As Double = 0, cob_meta_total As Double = 0, cob_resultado_total As Double = 0
    Dim efe_metal_total As Double = 0, efe_resultado_total As Double = 0
    Dim dt_cobertura_proveedores_estrategicos As New DataTable

    Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
    Dim excel2 As New Microsoft.Office.Interop.Excel.ApplicationClass
    Dim clase_efectivos As New cls_efectividad_sps
    Dim style As Microsoft.Office.Interop.Excel.Style

    Dim Permiso As Integer = 0

    Private Sub BtnMostrarInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrarInfo.Click
        Button1.Visible = True
        dias_habiles = get_dias_habiles()
        GroupBox1.Visible = False
        tab_control_ejecutivos.Visible = True
        Dim dtx As New DataTable

        For A As Integer = 0 To DataSupervisores.RowCount - 1
            If DataSupervisores.Rows(A).Cells(4).Value = True Then
                If DataSupervisores.Rows(A).Cells(0).Value = 5 Or DataSupervisores.Rows(A).Cells(0).Value = 10 Or DataSupervisores.Rows(A).Cells(0).Value = 15 Then
                    dtx = Conexion.rptn_bonos_nuevos(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, DataSupervisores.Rows(A).Cells(2).Value, "LISTAR_SUPERVISORES", DataSupervisores.Rows(A).Cells(3).Value, DataSupervisores.Rows(A).Cells(0).Value)
                End If
            End If
        Next

        For a As Integer = 0 To DataSupervisores.RowCount - 1
            For b As Integer = 0 To dtx.Rows.Count - 1
                If DataSupervisores.Rows(a).Cells(0).Value = dtx(b)(0) Then
                    DataSupervisores.Rows(a).Cells(4).Value = True
                End If
            Next
        Next

        For A As Integer = 0 To DataSupervisores.RowCount - 1
            If DataSupervisores.Rows(A).Cells(4).Value = True Then
                tcpe_peso_supervisor = 0
                tcpe_resultado_supervisor = 0
                tcpe_meta_supervisor = 0
                tcpe_medicion_supervisor = 0
                tcpe_divisor = 0

                efe_peso_supervisor = 0
                efe_resultado_supervisor = 0
                efe_meta_supervisor = 0
                efe_medicion_supervisor = 0
                efe_divisor_supervisor = 0

                cob_peso_supervisor = 0
                cob_resultado_supervisor = 0
                cob_meta_supervisor = 0
                cob_medicion_supervisor = 0
                cob_divisor_supervisor = 0

                vol_peso_supervisor = 0
                vol_resultado_supervisor = 0
                vol_meta_supervisor = 0
                vol_medicion_supervisor = 0
                vol_divisor_supervisor = 0
                vol_divisor_supervisor_may = 0

                vol_meta_total = 0
                vol_venta_total = 0

                cob_meta_total = 0
                cob_resultado_total = 0
                efe_metal_total = 0
                efe_resultado_total = 0

                dt_cobertura_proveedores_estrategicos.Clear()

                Dim dt_vendedores_asignados As New DataTable
                Dim Pantalla As New TabPage
                If ComboEmpresa.Text <> "SR AGRO" Then
                    Pantalla.Text = DataSupervisores.Rows(A).Cells(1).Value & " (Supervisor)"
                Else
                    Pantalla.Text = DataSupervisores.Rows(A).Cells(1).Value
                End If

                tab_control_ejecutivos.TabPages.Add(Pantalla)
                Pantalla.Name = DataSupervisores.Rows(A).Cells(0).Value
                If ComboEmpresa.Text <> "SR AGRO" Then
                    dt_vendedores_asignados = Conexion.rptn_bonos_nuevos(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, DataSupervisores.Rows(A).Cells(2).Value, "LISTAR_VENDEDORES", DataSupervisores.Rows(A).Cells(3).Value, DataSupervisores.Rows(A).Cells(0).Value)
                End If
                If ComboEmpresa.Text = "SAN RAFAEL" Then
                    cargar_ejecutivos(dt_vendedores_asignados)
                    cargar_supervisores(DataSupervisores.Rows(A).Cells(0).Value, DataSupervisores.Rows(A).Cells(1).Value, Pantalla, DataSupervisores.Rows(A).Cells(2).Value)
                ElseIf ComboEmpresa.Text = "DIMOSA" Then
                    cargar_ejecutivos_dimosa(dt_vendedores_asignados)
                    cargar_supervisores_dimosa(DataSupervisores.Rows(A).Cells(0).Value, DataSupervisores.Rows(A).Cells(1).Value, Pantalla, DataSupervisores.Rows(A).Cells(2).Value)
                Else
                    cargar_supervisores_agro(DataSupervisores.Rows(A).Cells(0).Value, DataSupervisores.Rows(A).Cells(1).Value, Pantalla, DataSupervisores.Rows(A).Cells(2).Value)
                End If
            End If
        Next
    End Sub

    Function get_dias_habiles() As Integer
        Dim i As Integer = 0, dias As Integer = 0, Lun As Integer = 0, Mar As Integer = 0, Mie As Integer = 0
        Dim Jue As Integer = 0, Vie As Integer = 0, sab As Integer = 0
        Dim fechainicio As Date, fechaterminal As Date
        i = 1
        fechainicio = "01/" & Cmb_Fecha_Inicial.Value.Month & "/" & Cmb_Fecha_Inicial.Value.Year
        fechaterminal = Cmb_Fecha_Final.Value
        fechaterminal = "01/" & fechaterminal.AddMonths(1).Month & "/" & Cmb_Fecha_Final.Value.Year
        fechaterminal = fechaterminal.AddDays(-1)

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
        Dim dias_habiles As Integer = 0
        dias_habiles = Lun + Mar + Mie + Jue + Vie + sab
        Return dias_habiles
    End Function

    Sub cargar_ejecutivos(ByVal dt_vendedores As DataTable)
        Dim ancho As Double
        Dim anchor As AnchorStyles
        anchor = AnchorStyles.Right Or AnchorStyles.Left Or AnchorStyles.Top

        For index As Integer = 0 To dt_vendedores.Rows.Count - 1
            Dim hoja_vendedor_index As New TabPage
            Dim label_index = New Label, label2_index = New Label, label3_index = New Label, label4_index = New Label
            Dim label5_index = New Label, label6_index = New Label, label7_index = New Label, label8_index = New Label
            Dim label9_index = New Label, label10_index = New Label, label66_index = New Label

            Dim grid_resumen_variables_index As New DataGridView, grid_resumen_variables2_index As New DataGridView
            Dim grid_valor_bono_index As New DataGridView, grid_efectividad_index As New DataGridView, grid_cobertura_clientes_index As New DataGridView
            Dim grid_cobertura_proveedores_estrategicos_index As New DataGridView
            Dim grid_volumen_ventas_index As New DataGridView, grid_productos_rentables_index As New DataGridView, grid_cartera_credito_index As New DataGridView

            grid_resumen_variables_index.ReadOnly = True
            grid_resumen_variables2_index.ReadOnly = True
            grid_valor_bono_index.ReadOnly = True
            grid_efectividad_index.ReadOnly = True
            grid_cobertura_clientes_index.ReadOnly = True
            grid_cobertura_proveedores_estrategicos_index.ReadOnly = True
            grid_volumen_ventas_index.ReadOnly = True
            grid_productos_rentables_index.ReadOnly = True

            grid_resumen_variables_index.AllowUserToAddRows = False
            grid_resumen_variables2_index.AllowUserToAddRows = False
            grid_valor_bono_index.AllowUserToAddRows = False
            grid_efectividad_index.AllowUserToAddRows = False
            grid_cobertura_clientes_index.AllowUserToAddRows = False
            grid_cobertura_proveedores_estrategicos_index.AllowUserToAddRows = False
            grid_volumen_ventas_index.AllowUserToAddRows = False
            grid_productos_rentables_index.AllowUserToAddRows = False

            hoja_vendedor_index.Name = dt_vendedores.Rows(index)(0)
            hoja_vendedor_index.Text = dt_vendedores.Rows(index)(1)
            hoja_vendedor_index.AutoScroll = True

            If DataSupervisores.CurrentRow.Cells(2).Value <> "Jefe" Then
                tab_control_ejecutivos.TabPages.Add(hoja_vendedor_index)
            End If

            ancho = hoja_vendedor_index.Width / 2

            label_index.Text = "Resumen Variables Cobertura"
            hoja_vendedor_index.Controls.Add(label_index)

            Dim ubicacion As Integer = label_index.Height
            grid_resumen_variables_index.Width = ancho
            grid_resumen_variables_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_resumen_variables_index)
            grid_resumen_variables_index.Location = New Point(1, ubicacion)

            ubicacion += grid_resumen_variables_index.Height + 1

            label2_index.Text = "Resumen Variables Volumen"
            label2_index.Location = New Point(1, ubicacion)
            hoja_vendedor_index.Controls.Add(label2_index)
            ubicacion += label2_index.Height

            grid_resumen_variables2_index.Width = ancho
            grid_resumen_variables2_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_resumen_variables2_index)
            grid_resumen_variables2_index.Location = New Point(1, ubicacion)

            ubicacion += grid_resumen_variables2_index.Height
            label3_index.Text = "Bono"
            label3_index.Width = 250
            hoja_vendedor_index.Controls.Add(label3_index)
            label3_index.Location = New Point(1, ubicacion)
            ubicacion += label3_index.Height

            grid_valor_bono_index.Width = ancho
            grid_valor_bono_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_valor_bono_index)
            grid_valor_bono_index.Location = New Point(1, ubicacion)
            ubicacion += grid_valor_bono_index.Height

            label6_index.Text = "Cobertura de Productos Estrategicos"
            label6_index.Width = 250
            hoja_vendedor_index.Controls.Add(label6_index)
            label6_index.Location = New Point(1, ubicacion)
            ubicacion += label6_index.Height

            Dim dt_cobertura_proveedores_estrategicos_index As New DataTable
            If dt_vendedores.Rows(index)(2) = "DET" Then
                dt_cobertura_proveedores_estrategicos_index = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "COBERTURA_PROVEEDORES_ESTRATEGICOS", 82, ComboEmpresa.Text)
            Else
            End If

            Dim tcpe As Double = 0, val1 As Double = 0, val2 As Double = 0, val3 As Double = 0
            For index1 As Integer = 0 To dt_cobertura_proveedores_estrategicos_index.Rows.Count - 1
                Try
                    val1 += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(2)
                Catch ex As Exception
                    val1 += 0
                End Try

                Try
                    val2 += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(3)
                Catch ex As Exception
                    val2 += 0
                End Try

                Try
                    val3 += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(4)
                Catch ex As Exception
                    val3 += 0
                End Try

                Try
                    tcpe += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(5)
                Catch ex As Exception
                    tcpe += 0
                End Try
            Next


            If dt_cobertura_proveedores_estrategicos.Columns.Count > 0 Then

            Else
                dt_cobertura_proveedores_estrategicos = dt_cobertura_proveedores_estrategicos_index.Clone()
            End If

            For Each fila As DataRow In dt_cobertura_proveedores_estrategicos_index.Rows

                Dim db As New cls_bonificaciones
                Dim dtx As New DataTable
                dtx = db.VerCPE(dt_vendedores.Rows(index)(0))
                Dim a As Integer = dtx(0)(0)
                If a = 1 Then
                    dt_cobertura_proveedores_estrategicos.ImportRow(fila)
                End If

            Next

            Try
                dt_cobertura_proveedores_estrategicos_index.Rows.Add("TOTAL", 0, val1, val2, val3, tcpe)
            Catch ex As Exception
            End Try

            grid_cobertura_proveedores_estrategicos_index.Width = ancho
            grid_cobertura_proveedores_estrategicos_index.Anchor = anchor

            grid_cobertura_proveedores_estrategicos_index.Name = "CoberturaProveedores" & dt_vendedores.Rows(index)(0) & index.ToString()

            hoja_vendedor_index.Controls.Add(grid_cobertura_proveedores_estrategicos_index)
            grid_cobertura_proveedores_estrategicos_index.DataSource = dt_cobertura_proveedores_estrategicos_index
            grid_cobertura_proveedores_estrategicos_index.Location = New Point(1, ubicacion)
            ubicacion += grid_cobertura_proveedores_estrategicos_index.Height


            'CARTERA CREDITO
            label66_index.Text = "Cartera de Credito"
            label66_index.Width = 250
            hoja_vendedor_index.Controls.Add(label66_index)
            label66_index.Location = New Point(1, ubicacion)
            ubicacion += label66_index.Height

            Dim dt_cartera_credito_index As New DataTable
            If dt_vendedores.Rows(index)(2) = "MAY" Then
                dt_cartera_credito_index = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "CARTERA CREDITO", 82, ComboEmpresa.Text)
            Else
            End If

            grid_cartera_credito_index.Width = ancho
            grid_cartera_credito_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_cartera_credito_index)
            grid_cartera_credito_index.DataSource = dt_cartera_credito_index
            grid_cartera_credito_index.Location = New Point(1, ubicacion)
            'FIN CARTERA CREDITO

            ubicacion = 0
            label7_index.Text = "Efectividad"
            hoja_vendedor_index.Controls.Add(label7_index)
            label7_index.Location = New Point(ancho + 10, ubicacion)
            ubicacion += label7_index.Height

            Dim dt_efectividad_index As New DataTable
            If dt_vendedores.Rows(index)(2) = "DET" Then
                dt_efectividad_index = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "EFECTIVIDAD", 82, ComboEmpresa.Text)
            Else
            End If

            grid_efectividad_index.Width = ancho
            grid_efectividad_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_efectividad_index)
            grid_efectividad_index.DataSource = dt_efectividad_index
            grid_efectividad_index.Location = New Point(ancho + 10, ubicacion)

            ubicacion += grid_efectividad_index.Height
            label8_index.Text = "Cobertura de Clientes"
            label8_index.Width = 250
            hoja_vendedor_index.Controls.Add(label8_index)
            label8_index.Location = New Point(ancho + 10, ubicacion)
            ubicacion += label8_index.Height

            Dim dt_cobertura_clientes_index As New DataTable
            If dt_vendedores.Rows(index)(2) = "DET" Then
                dt_cobertura_clientes_index = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "COBERTURA_CLIENTES", 82, ComboEmpresa.Text)
            Else
            End If

            grid_cobertura_clientes_index.Width = ancho
            grid_cobertura_clientes_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_cobertura_clientes_index)
            grid_cobertura_clientes_index.DataSource = dt_cobertura_clientes_index
            grid_cobertura_clientes_index.Location = New Point(ancho + 10, ubicacion)
            ubicacion += grid_cobertura_clientes_index.Height
            label9_index.Text = "Volumen de Ventas"
            hoja_vendedor_index.Controls.Add(label9_index)
            label9_index.Location = New Point(ancho + 10, ubicacion)
            ubicacion += label9_index.Height

            Dim dt_volumnen_ventas_index As New DataTable
            dt_volumnen_ventas_index = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "VENTAS_TOTALES", 82, ComboEmpresa.Text)

            grid_volumen_ventas_index.Width = ancho
            grid_volumen_ventas_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_volumen_ventas_index)
            grid_volumen_ventas_index.DataSource = dt_volumnen_ventas_index
            grid_volumen_ventas_index.Location = New Point(ancho + 10, ubicacion)

            ubicacion += grid_volumen_ventas_index.Height

            label10_index.Text = "Productos Rentables"
            label10_index.Width = 250
            hoja_vendedor_index.Controls.Add(label10_index)
            label10_index.Location = New Point(ancho + 10, ubicacion)
            ubicacion += label10_index.Height

            grid_productos_rentables_index.Width = ancho
            grid_productos_rentables_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_productos_rentables_index)
            grid_productos_rentables_index.Location = New Point(ancho + 10, ubicacion)

            'Resumen de las Variables'
            Dim tablita1_temporal As New DataTable
            tablita1_temporal.Columns.Add("Variable")
            tablita1_temporal.Columns.Add("Peso")
            tablita1_temporal.Columns.Add("Resultado")
            tablita1_temporal.Columns.Add("Meta")
            tablita1_temporal.Columns.Add("Medicion")
            tablita1_temporal.Columns.Add("Flag")

            Dim total_peso As Double = 0
            Dim resultado_total As Double = 0
            Dim ventas_totales As Double = 0
            Dim cobertura_clientes As Double = 0

            Try
                ventas_totales = dt_volumnen_ventas_index.Rows(0)(3)
                vol_meta_total += dt_volumnen_ventas_index.Rows(0)(1)
                vol_venta_total += dt_volumnen_ventas_index.Rows(0)(2)
            Catch ex As Exception
                ventas_totales = 0
                vol_meta_total += 0
                vol_venta_total += 0
            End Try

            Dim tabla_datos As New DataTable
            Dim PESO As Double = 0, META As Double = 0, MEDICION As Double = 0
            Dim flag As Integer = 0
            Dim resultado As Double = 0
            Dim resultado_cobertura As Double = 0
            Dim resultado_coberturas As Double = 0
            Dim cartera_clientes As Double = 0
            Dim resultado_cartera As Double = 0
            If dt_vendedores.Rows(index)(2) = "DET" Then
                Try
                    cobertura_clientes = dt_cobertura_clientes_index.Rows(0)(3)
                    cob_meta_total += dt_cobertura_clientes_index.Rows(0)(1)
                    cob_resultado_total += dt_cobertura_clientes_index.Rows(0)(2)
                Catch ex As Exception
                    cobertura_clientes = 0
                    cob_meta_total += 0
                    cob_resultado_total += 0
                End Try

                Try
                    cartera_clientes = dt_cartera_credito_index.Rows(0)(3)
                Catch ex As Exception
                    cartera_clientes = 0
                End Try

                tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 2, ComboEmpresa.Text)

                If tabla_datos.Rows.Count > 0 Then
                    PESO = tabla_datos.Rows(0)(0)
                    META = tabla_datos.Rows(0)(1)
                    MEDICION = tabla_datos.Rows(0)(2)
                Else
                    PESO = 0
                    META = 0
                    MEDICION = 0
                End If

                flag = 0
                If tcpe >= MEDICION Then
                    flag = 1
                End If

                If tcpe > 100 Then
                    resultado = PESO
                Else
                    resultado = Math.Round(tcpe * PESO / 100, 2)
                End If

                tablita1_temporal.Rows.Add("Cobertura de Proveedores Estrategicos", PESO, resultado, META, MEDICION, flag)

                'VARIABLES SUPERVISOR
                tcpe_peso_supervisor += PESO
                tcpe_resultado_supervisor += resultado
                tcpe_meta_supervisor += META
                tcpe_medicion_supervisor += MEDICION
                tcpe_divisor += 1
                'FIN VARIABLES SUPERVISOR

                total_peso += PESO
                If flag = 1 Then
                    resultado_total += resultado
                Else
                    resultado_total += 0
                End If

                tabla_datos = Nothing
                tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 1, ComboEmpresa.Text)
                PESO = 0
                META = 0
                MEDICION = 0
                If tabla_datos.Rows.Count > 0 Then
                    PESO = tabla_datos.Rows(0)(0)
                    META = tabla_datos.Rows(0)(1)
                    MEDICION = tabla_datos.Rows(0)(2)
                Else
                    PESO = 0
                    META = 0
                    MEDICION = 0
                End If


                Dim db As New ClsClientes
                Dim dtUniverso As New DataTable

                flag = 0
                Dim tefectividad As Double = 0
                Dim universo As Double = 0

                Dim Cantidad_E As Decimal = 0
                Try
                    dtUniverso = db.ClientesIdeales(Cmb_Fecha_Final.Value.Year, Cmb_Fecha_Final.Value.Month, dt_vendedores.Rows(index)(0))
                    Cantidad_E = (dtUniverso(0)(3) / 6)
                Catch ex As Exception
                End Try
                universo = Math.Round(dias_habiles * Cantidad_E, 0)
                Try
                    universo = dtUniverso(0)(6)
                Catch ex As Exception
                End Try

                Try
                    dt_efectividad_index.Rows(0)(0) = universo
                    tefectividad = dt_efectividad_index.Rows(0)(1)
                    resultado_cobertura = (tefectividad / universo) * 100
                    dt_efectividad_index.Rows(0)(2) = resultado_cobertura

                    efe_metal_total += universo
                    efe_resultado_total += tefectividad
                Catch ex As Exception
                    resultado_cobertura = 0
                End Try

                If resultado_cobertura >= MEDICION Then
                    flag = 1
                End If

                If resultado_cobertura > MEDICION Then
                    resultado = PESO
                Else
                    resultado = Math.Round(resultado_cobertura * PESO / MEDICION, 2)
                End If
                tablita1_temporal.Rows.Add("Efectividad", PESO, resultado, META, MEDICION, flag)

                efe_peso_supervisor += PESO
                efe_resultado_supervisor += resultado
                efe_meta_supervisor += META
                efe_medicion_supervisor += MEDICION
                efe_divisor_supervisor += 1

                total_peso += PESO

                tabla_datos = Nothing
                tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 4, ComboEmpresa.Text)
                PESO = 0
                META = 0
                MEDICION = 0
                If tabla_datos.Rows.Count > 0 Then
                    PESO = tabla_datos.Rows(0)(0)
                    META = tabla_datos.Rows(0)(1)
                    MEDICION = tabla_datos.Rows(0)(2)
                Else
                    PESO = 0
                    META = 0
                    MEDICION = 0
                End If

                flag = 0
                If cobertura_clientes >= MEDICION Then
                    flag = 1
                End If

                If cobertura_clientes > 100 Then
                    resultado = PESO
                Else
                    resultado = Math.Round(cobertura_clientes * PESO / 100, 2)
                End If

                tablita1_temporal.Rows.Add("Cobertura de Clientes", PESO, resultado, META, MEDICION, flag)

                cob_peso_supervisor += PESO
                cob_resultado_supervisor += resultado
                cob_meta_supervisor += META
                cob_medicion_supervisor += MEDICION
                cob_divisor_supervisor += 1

                total_peso += PESO
                If flag = 1 Then
                    resultado_total += resultado
                Else
                    resultado_total += 0
                End If

                tablita1_temporal.Rows.Add("Total", total_peso, resultado_total, 0, 0, 0)
                resultado_coberturas = resultado_total
                grid_resumen_variables_index.DataSource = tablita1_temporal
                total_peso = 0
                resultado_total = 0
            Else
            End If
            'variables de volumen
            Dim tablita1_temporal2 As New DataTable
            tablita1_temporal2.Columns.Add("Variable")
            tablita1_temporal2.Columns.Add("Peso")
            tablita1_temporal2.Columns.Add("Resultado")
            tablita1_temporal2.Columns.Add("Meta")
            tablita1_temporal2.Columns.Add("Medicion")
            tablita1_temporal2.Columns.Add("Flag")

            tabla_datos = Nothing
            tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 3, ComboEmpresa.Text)
            PESO = 0
            META = 0
            MEDICION = 0
            If tabla_datos.Rows.Count > 0 Then
                PESO = tabla_datos.Rows(0)(0)
                META = tabla_datos.Rows(0)(1)
                MEDICION = tabla_datos.Rows(0)(2)
            Else
                PESO = 0
                META = 0
                MEDICION = 0
            End If

            flag = 0
            If ventas_totales >= MEDICION Then
                flag = 1
            End If

            If ventas_totales > 100 Then
                resultado = PESO
            Else
                resultado = Math.Round(ventas_totales * PESO / 100, 2)
            End If

            tablita1_temporal2.Rows.Add("Volumen de Ventas", PESO, resultado, META, MEDICION, flag)

            vol_resultado_supervisor += resultado
            vol_meta_supervisor += META
            vol_divisor_supervisor += 1

            If dt_vendedores.Rows(index)(2) = "MAY" Then
                vol_divisor_supervisor_may += 1
            Else
                vol_peso_supervisor += PESO
                vol_medicion_supervisor += MEDICION
            End If

            total_peso += PESO

            If flag = 1 Then
                resultado_total += resultado
            Else
                resultado_total += 0
            End If

            'CARTERA DE CLIENTES'
            If dt_vendedores.Rows(index)(2) = "MAY" Then
                tabla_datos = Nothing
                tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 6, ComboEmpresa.Text)
                PESO = 0
                META = 0
                MEDICION = 0
                If tabla_datos.Rows.Count > 0 Then
                    PESO = tabla_datos.Rows(0)(0)
                    META = tabla_datos.Rows(0)(1)
                    MEDICION = tabla_datos.Rows(0)(2)
                Else
                    PESO = 0
                    META = 0
                    MEDICION = 0
                End If

                flag = 0
                If cartera_clientes >= MEDICION Then
                    flag = 1
                End If

                If cartera_clientes > 100 Then
                    resultado = PESO
                Else
                    resultado = Math.Round(cartera_clientes * PESO / 100, 2)
                End If

                tablita1_temporal2.Rows.Add("Cartera Clientes", PESO, resultado, META, MEDICION, flag)
                total_peso += PESO
                If flag = 1 Then
                    resultado_total += resultado
                    resultado_cartera = resultado
                Else
                    resultado_total += 0
                End If

                ''  Cartera de Clientes Siempre 100
                resultado_cartera = 100
                ''

            End If
            'FIN CARTERA DE CLIENTES'
            If dt_vendedores.Rows(index)(2) = "DET" Then
                Dim productos_rentables As Double = 0
                tabla_datos = Nothing
                tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 5, ComboEmpresa.Text)
                PESO = 0
                resultado = 0
                META = 0
                MEDICION = 0
                If tabla_datos.Rows.Count > 0 Then
                    PESO = tabla_datos.Rows(0)(0)
                    META = tabla_datos.Rows(0)(1)
                    MEDICION = tabla_datos.Rows(0)(2)
                Else
                    PESO = 0
                    META = 0
                    MEDICION = 0
                End If

                flag = 0
                If productos_rentables >= MEDICION Then
                    flag = 1
                End If

                If productos_rentables > 100 Then
                    resultado = PESO
                Else
                    resultado = Math.Round(productos_rentables * PESO / 100, 2)
                End If

                tablita1_temporal2.Rows.Add("Productos Rentables", PESO, resultado, META, MEDICION, flag)
                If flag = 1 Then
                    resultado_total += resultado
                Else
                    resultado_total += 0
                End If
                total_peso += PESO
            Else
            End If

            tablita1_temporal2.Rows.Add("Total", total_peso, resultado_total, 0, 0, 0)
            grid_resumen_variables2_index.DataSource = tablita1_temporal2
            Dim resultado_volumen As Double = 0
            resultado_volumen = resultado_total
            'fin resumen de las variables

            'resumen del bono
            grid_valor_bono_index.Columns.Add("Descripcion", "Descripcion")
            grid_valor_bono_index.Columns.Add("Valor", "Valor")

            Dim Cobertura As Integer = 0
            If dt_vendedores.Rows(index)(2) = "DET" Then
                Dim val_bono_cob As Double = 0
                If resultado_coberturas >= 96.25 Then
                    val_bono_cob = 1500
                ElseIf resultado_coberturas >= 92.51 Then
                    val_bono_cob = 1200
                ElseIf resultado_coberturas >= 85 Then
                    val_bono_cob = 900
                Else
                    val_bono_cob = 0
                End If
                grid_valor_bono_index.Rows.Add("Valor del Bono Coberturas", val_bono_cob)
                Cobertura = val_bono_cob
            Else
                Cobertura = 1
            End If

            Dim Cartera As Integer = 0
            If dt_vendedores.Rows(index)(2) = "MAY" Then
                Dim val_bono_cartera As Double = 0
                If resultado_cartera >= 100 Then
                    val_bono_cartera = 1500
                ElseIf resultado_cartera >= 98 Then
                    val_bono_cartera = 1200
                ElseIf resultado_cartera >= 95 Then
                    val_bono_cartera = 900
                Else
                    val_bono_cartera = 0
                End If
                grid_valor_bono_index.Rows.Add("Valor del Bono Cartera Clientes", val_bono_cartera)
                Cartera = val_bono_cartera
            Else
                Cartera = 1
            End If


            Dim val_bono_vol As Double = 0
            If resultado_volumen >= 100 Then
                val_bono_vol = 1500
            ElseIf resultado_volumen >= 98 Then
                val_bono_vol = 1200
            ElseIf resultado_volumen >= 95 Then
                val_bono_vol = 900
            Else
                val_bono_vol = 0
            End If
            grid_valor_bono_index.Rows.Add("Valor del Bono Volumen", val_bono_vol)

            Dim bono_extra As Double = 0
            If val_bono_vol > 0 And Cartera > 0 And val_bono_vol > 0 Then
                If ventas_totales >= 110 Then
                    bono_extra = 3000
                ElseIf ventas_totales >= 105 Then
                    bono_extra = 1500
                Else
                    bono_extra = 0
                End If
            End If
            grid_valor_bono_index.Rows.Add("Bono Extra", bono_extra)

            grid_resumen_variables_index.Name = "ResumenVariables1" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_resumen_variables2_index.Name = "ResumenVariables2" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_valor_bono_index.Name = "ValorBono" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_cartera_credito_index.Name = "CarteraCredito" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_efectividad_index.Name = "Efectividad" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_cobertura_clientes_index.Name = "CoberturaClientes" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_volumen_ventas_index.Name = "VolumenVentas" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_productos_rentables_index.Name = "ProductosRentables" & dt_vendedores.Rows(index)(0) & index.ToString()

        Next
    End Sub

    Sub cargar_supervisores(ByVal codigo_supervisor As String, ByVal nombre_supervisor As String, ByVal hoja_supervisor_index As TabPage, ByVal Tipo As String)
        Dim ancho As Double
        Dim anchor As AnchorStyles
        anchor = AnchorStyles.Right Or AnchorStyles.Left Or AnchorStyles.Top

        Dim label_index = New Label, label2_index = New Label, label3_index = New Label, label4_index = New Label
        Dim label5_index = New Label, label6_index = New Label, label7_index = New Label, label8_index = New Label
        Dim label9_index = New Label, label10_index = New Label, label66_index = New Label

        Dim grid_resumen_variables_index As New DataGridView, grid_resumen_variables2_index As New DataGridView
        Dim grid_valor_bono_index As New DataGridView, grid_efectividad_index As New DataGridView, grid_cobertura_clientes_index As New DataGridView
        Dim grid_cobertura_proveedores_estrategicos_index As New DataGridView
        Dim grid_volumen_ventas_index As New DataGridView, grid_productos_rentables_index As New DataGridView, grid_cartera_credito_index As New DataGridView

        grid_resumen_variables_index.ReadOnly = True
        grid_resumen_variables2_index.ReadOnly = True
        grid_valor_bono_index.ReadOnly = True
        grid_efectividad_index.ReadOnly = True
        grid_cobertura_clientes_index.ReadOnly = True
        grid_cobertura_proveedores_estrategicos_index.ReadOnly = True
        grid_volumen_ventas_index.ReadOnly = True
        grid_productos_rentables_index.ReadOnly = True

        grid_resumen_variables_index.AllowUserToAddRows = False
        grid_resumen_variables2_index.AllowUserToAddRows = False
        grid_valor_bono_index.AllowUserToAddRows = False
        grid_efectividad_index.AllowUserToAddRows = False
        grid_cobertura_clientes_index.AllowUserToAddRows = False
        grid_cobertura_proveedores_estrategicos_index.AllowUserToAddRows = False
        grid_volumen_ventas_index.AllowUserToAddRows = False
        grid_productos_rentables_index.AllowUserToAddRows = False

        hoja_supervisor_index.AutoScroll = True
        ancho = hoja_supervisor_index.Width / 2

        label_index.Text = "Resumen Variables Cobertura"
        hoja_supervisor_index.Controls.Add(label_index)

        Dim ubicacion As Integer = label_index.Height
        grid_resumen_variables_index.Width = ancho
        grid_resumen_variables_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_resumen_variables_index)
        grid_resumen_variables_index.Location = New Point(1, ubicacion)
        ubicacion += grid_resumen_variables_index.Height + 1

        label2_index.Text = "Resumen Variables Volumen"
        label2_index.Location = New Point(1, ubicacion)
        hoja_supervisor_index.Controls.Add(label2_index)
        ubicacion += label2_index.Height

        grid_resumen_variables2_index.Width = ancho
        grid_resumen_variables2_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_resumen_variables2_index)
        grid_resumen_variables2_index.Location = New Point(1, ubicacion)

        ubicacion += grid_resumen_variables2_index.Height
        label3_index.Text = "Bono"
        label3_index.Width = 250
        hoja_supervisor_index.Controls.Add(label3_index)
        label3_index.Location = New Point(1, ubicacion)
        ubicacion += label3_index.Height

        grid_valor_bono_index.Width = ancho
        grid_valor_bono_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_valor_bono_index)
        grid_valor_bono_index.Location = New Point(1, ubicacion)
        ubicacion += grid_valor_bono_index.Height

        label6_index.Text = "Cobertura de Productos Estrategicos"
        label6_index.Width = 250
        hoja_supervisor_index.Controls.Add(label6_index)
        label6_index.Location = New Point(1, ubicacion)
        ubicacion += label6_index.Height

        Dim dt_cobertura_proveedores_estrategicos_index As New DataTable
        Dim tcpe As Double = 0, val1 As Double = 0, val2 As Double = 0, val3 As Double = 0

        dt_cobertura_proveedores_estrategicos_index = dt_cobertura_proveedores_estrategicos.Clone
        Dim resumen_cpe As Double = 0
        Try
            Dim distintos As DataTable = dt_cobertura_proveedores_estrategicos.DefaultView.ToTable(True, "Proveedores Estrategicos")


            For index As Integer = 0 To distintos.Rows.Count - 1
                Dim Meta_cp As Double = 0, Resultado_cp As Double = 0, Peso_cp As Double = 0, Nota_cp As Double = 0, peso_obt_cp As Double = 0
                Try
                    Meta_cp = dt_cobertura_proveedores_estrategicos.Compute("AVG(Meta)", "[Proveedores Estrategicos] = '" + distintos.Rows(index)(0) + "'")
                    Resultado_cp = dt_cobertura_proveedores_estrategicos.Compute("AVG(Resultado)", "[Proveedores Estrategicos] = '" + distintos.Rows(index)(0) + "'")
                    Peso_cp = dt_cobertura_proveedores_estrategicos.Compute("AVG(Peso)", "[Proveedores Estrategicos] = '" + distintos.Rows(index)(0) + "'")
                    Nota_cp = dt_cobertura_proveedores_estrategicos.Compute("AVG(Nota)", "[Proveedores Estrategicos] = '" + distintos.Rows(index)(0) + "'")
                    peso_obt_cp = dt_cobertura_proveedores_estrategicos.Compute("AVG([Peso Obtenido])", "[Proveedores Estrategicos] = '" + distintos.Rows(index)(0) + "'")
                    resumen_cpe += peso_obt_cp
                Catch ex As Exception
                End Try
                dt_cobertura_proveedores_estrategicos_index.Rows.Add(distintos.Rows(index)(0), Meta_cp, Resultado_cp, Peso_cp, Nota_cp, peso_obt_cp)
            Next
        Catch ex As Exception
        End Try
        


        For index1 As Integer = 0 To dt_cobertura_proveedores_estrategicos_index.Rows.Count - 1
            Try
                val1 += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(2)
            Catch ex As Exception
                val1 += 0
            End Try

            Try
                val2 += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(3)
            Catch ex As Exception
                val2 += 0
            End Try

            Try
                val3 += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(4)
            Catch ex As Exception
                val3 += 0
            End Try

            Try
                tcpe += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(5)
            Catch ex As Exception
                tcpe += 0
            End Try
        Next
        Try
            dt_cobertura_proveedores_estrategicos_index.Rows.Add("-TOTAL-", 0, val1, val2, val3, tcpe)
        Catch ex As Exception
        End Try

        grid_cobertura_proveedores_estrategicos_index.Width = ancho
        grid_cobertura_proveedores_estrategicos_index.Anchor = anchor
        grid_cobertura_proveedores_estrategicos_index.DataSource = dt_cobertura_proveedores_estrategicos_index
        hoja_supervisor_index.Controls.Add(grid_cobertura_proveedores_estrategicos_index)
        grid_cobertura_proveedores_estrategicos_index.Location = New Point(1, ubicacion)
        ubicacion += grid_cobertura_proveedores_estrategicos_index.Height

        'CARTERA CREDITO
        label66_index.Text = "Cartera de Credito"
        label66_index.Width = 250
        hoja_supervisor_index.Controls.Add(label66_index)
        label66_index.Location = New Point(1, ubicacion)
        ubicacion += label66_index.Height

        Dim dt_cartera_credito_index As New DataTable
        grid_cartera_credito_index.Width = ancho
        grid_cartera_credito_index.Anchor = anchor
        grid_cartera_credito_index.DataSource = dt_cartera_credito_index
        hoja_supervisor_index.Controls.Add(grid_cartera_credito_index)
        grid_cartera_credito_index.Location = New Point(1, ubicacion)
        'FIN CARTERA CREDITO

        ubicacion = 0
        label7_index.Text = "Efectividad"
        hoja_supervisor_index.Controls.Add(label7_index)
        label7_index.Location = New Point(ancho + 10, ubicacion)
        ubicacion += label7_index.Height

        Dim dt_efectividad_index As New DataTable
        dt_efectividad_index.Columns.Add("META EFECTIVIDAD")
        dt_efectividad_index.Columns.Add("EFECTIVOS")
        dt_efectividad_index.Columns.Add("TOTAL")
        dt_efectividad_index.Columns.Add("METACOBERTURA")
        dt_efectividad_index.Columns.Add("METAEFECTIVIDAD")
        Dim efe_nota As Double = 0
        Try
            efe_nota = efe_resultado_total / efe_metal_total * 100
        Catch ex As Exception
            efe_nota = 0
        End Try
        dt_efectividad_index.Rows.Add(efe_metal_total, efe_resultado_total, efe_nota)

        grid_efectividad_index.DataSource = dt_efectividad_index
        grid_efectividad_index.Width = ancho
        grid_efectividad_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_efectividad_index)
        grid_efectividad_index.Location = New Point(ancho + 10, ubicacion)
        ubicacion += grid_efectividad_index.Height

        label8_index.Text = "Cobertura de Clientes"
        label8_index.Width = 250
        hoja_supervisor_index.Controls.Add(label8_index)
        label8_index.Location = New Point(ancho + 10, ubicacion)
        ubicacion += label8_index.Height

        Dim dt_cobertura_clientes_index As New DataTable
        dt_cobertura_clientes_index.Columns.Add("SUPERVISOR")
        dt_cobertura_clientes_index.Columns.Add("META")
        dt_cobertura_clientes_index.Columns.Add("RESULTADO")
        dt_cobertura_clientes_index.Columns.Add("NOTA")
        Dim cob_nota As Double = 0
        Try
            cob_nota = cob_resultado_total / cob_meta_total * 100
        Catch ex As Exception
            cob_nota = 0
        End Try
        dt_cobertura_clientes_index.Rows.Add(hoja_supervisor_index.Text, cob_meta_total, cob_resultado_total, cob_nota)

        grid_cobertura_clientes_index.DataSource = dt_cobertura_clientes_index
        grid_cobertura_clientes_index.Width = ancho
        grid_cobertura_clientes_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_cobertura_clientes_index)
        grid_cobertura_clientes_index.Location = New Point(ancho + 10, ubicacion)

        ubicacion += grid_cobertura_clientes_index.Height

        label9_index.Text = "Volumen de Ventas"
        hoja_supervisor_index.Controls.Add(label9_index)
        label9_index.Location = New Point(ancho + 10, ubicacion)
        ubicacion += label9_index.Height
        Dim dt_volumnen_ventas_index As New DataTable
        dt_volumnen_ventas_index.Columns.Add("Supevisor")
        dt_volumnen_ventas_index.Columns.Add("Meta")
        dt_volumnen_ventas_index.Columns.Add("Venta")
        dt_volumnen_ventas_index.Columns.Add("Resultado")
        Dim resultado_total_volumen_supervisor As Double = 0

        Try
            resultado_total_volumen_supervisor = vol_venta_total / vol_meta_total * 100
        Catch ex As Exception
            resultado_total_volumen_supervisor = 0
        End Try
        dt_volumnen_ventas_index.Rows.Add(hoja_supervisor_index.Text, vol_meta_total, vol_venta_total, resultado_total_volumen_supervisor)

        grid_volumen_ventas_index.Width = ancho
        grid_volumen_ventas_index.Anchor = anchor
        grid_volumen_ventas_index.DataSource = dt_volumnen_ventas_index
        hoja_supervisor_index.Controls.Add(grid_volumen_ventas_index)
        grid_volumen_ventas_index.Location = New Point(ancho + 10, ubicacion)

        ubicacion += grid_volumen_ventas_index.Height

        label10_index.Text = "Productos Rentables"
        label10_index.Width = 250
        hoja_supervisor_index.Controls.Add(label10_index)
        label10_index.Location = New Point(ancho + 10, ubicacion)
        ubicacion += label10_index.Height

        grid_productos_rentables_index.Width = ancho
        grid_productos_rentables_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_productos_rentables_index)
        grid_productos_rentables_index.Location = New Point(ancho + 10, ubicacion)

        'Resumen de las Variables'
        Dim tablita1_temporal As New DataTable
        tablita1_temporal.Columns.Add("Variable")
        tablita1_temporal.Columns.Add("Peso")
        tablita1_temporal.Columns.Add("Resultado")
        tablita1_temporal.Columns.Add("Meta")
        tablita1_temporal.Columns.Add("Medicion")
        tablita1_temporal.Columns.Add("Flag")

        Dim flag As Integer = 0
        Dim PESO As Double = 0, META As Double = 0, MEDICION As Double = 0, resultado_total As Double = 0, RESULTADO As Double = 0
        Dim total_peso As Double = 0, resultado_cobertura As Double = 0, resultado_coberturas As Double = 0
        Dim resultado_cartera As Double = 0, ventas_totales As Double = 0

        If tcpe_divisor > 0 Then
            PESO = tcpe_peso_supervisor / tcpe_divisor

            RESULTADO = resumen_cpe

            META = tcpe_meta_supervisor / tcpe_divisor
            MEDICION = tcpe_medicion_supervisor / tcpe_divisor
        Else
            PESO = 0
            RESULTADO = 0
            META = 0
            MEDICION = 0
        End If

        flag = 0
        If RESULTADO >= MEDICION Then
            flag = 1
        End If

        If RESULTADO > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(RESULTADO * PESO / 100, 2)
        End If

        tablita1_temporal.Rows.Add("Cobertura de Proveedores Estrategicos", PESO, RESULTADO, META, MEDICION, flag)
        total_peso += PESO
        If flag = 1 Then
            resultado_total += RESULTADO
        Else
            resultado_total += 0
        End If

        PESO = 0
        META = 0
        MEDICION = 0
        flag = 0

        If efe_divisor_supervisor > 0 Then
            PESO = efe_peso_supervisor / efe_divisor_supervisor
            RESULTADO = efe_nota
            META = efe_meta_supervisor / efe_divisor_supervisor
            MEDICION = efe_medicion_supervisor / efe_divisor_supervisor
        Else
            PESO = 0
            RESULTADO = 0
            META = 0
            MEDICION = 0
        End If

        If RESULTADO >= MEDICION Then
            flag = 1
        End If

        If RESULTADO > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(RESULTADO / PESO * 100, 2)
        End If
        tablita1_temporal.Rows.Add("Efectividad", PESO, RESULTADO, META, MEDICION, flag)
        total_peso += PESO

        PESO = 0
        META = 0
        MEDICION = 0
        flag = 0

        If cob_divisor_supervisor > 0 Then
            PESO = cob_peso_supervisor / cob_divisor_supervisor
            RESULTADO = cob_nota
            META = cob_meta_supervisor / cob_divisor_supervisor
            MEDICION = cob_medicion_supervisor / cob_divisor_supervisor
        Else
            PESO = 0
            RESULTADO = 0
            META = 0
            MEDICION = 0
        End If

        If RESULTADO >= MEDICION Then
            flag = 1
        End If

        If RESULTADO > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(RESULTADO / PESO * 100, 2)
        End If

        tablita1_temporal.Rows.Add("Cobertura de Clientes", PESO, RESULTADO, META, MEDICION, flag)
        total_peso += PESO
        If flag = 1 Then
            resultado_total += RESULTADO
        Else
            resultado_total += 0
        End If

        tablita1_temporal.Rows.Add("Total", total_peso, resultado_total, 0, 0, 0)
        resultado_coberturas = resultado_total
        grid_resumen_variables_index.DataSource = tablita1_temporal
        total_peso = 0
        resultado_total = 0

        'variables de volumen
        Dim tablita1_temporal2 As New DataTable
        tablita1_temporal2.Columns.Add("Variable")
        tablita1_temporal2.Columns.Add("Peso")
        tablita1_temporal2.Columns.Add("Resultado")
        tablita1_temporal2.Columns.Add("Meta")
        tablita1_temporal2.Columns.Add("Medicion")
        tablita1_temporal2.Columns.Add("Flag")

        PESO = 0
        META = 0
        MEDICION = 0

        If vol_divisor_supervisor > 0 Then
            If (vol_divisor_supervisor - vol_divisor_supervisor_may) > 0 Then
                PESO = vol_peso_supervisor / (vol_divisor_supervisor - vol_divisor_supervisor_may)
                MEDICION = vol_medicion_supervisor / (vol_divisor_supervisor - vol_divisor_supervisor_may)
            Else
                PESO = vol_peso_supervisor
                MEDICION = vol_medicion_supervisor
            End If

            RESULTADO = resultado_total_volumen_supervisor
            META = vol_meta_supervisor / vol_divisor_supervisor
        Else
            PESO = 0
            RESULTADO = 0
            META = 0
            MEDICION = 0
        End If

        If RESULTADO > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(RESULTADO * PESO / 100, 2)
        End If

        flag = 0
        If RESULTADO >= MEDICION Then
            flag = 1
        End If

        tablita1_temporal2.Rows.Add("Volumen de Ventas", PESO, RESULTADO, META, MEDICION, flag)
        total_peso += PESO

        If flag = 1 Then
            resultado_total += RESULTADO
        Else
            resultado_total += 0
        End If

        'CARTERA DE CLIENTES'

        PESO = 0
        META = 0
        MEDICION = 0
        flag = 0
        Dim cartera_clientes As Double = 0
        If cartera_clientes >= MEDICION Then
            flag = 1
        End If

        If cartera_clientes > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(cartera_clientes * PESO / 100, 2)
        End If

        tablita1_temporal2.Rows.Add("Cartera Clientes", PESO, RESULTADO, META, MEDICION, flag)
        total_peso += PESO
        If flag = 1 Then
            resultado_total += RESULTADO
            resultado_cartera = RESULTADO
        Else
            resultado_total += 0
        End If

        'FIN CARTERA DE CLIENTES'
        Dim productos_rentables As Double = 0
        PESO = 0
        META = 0
        MEDICION = 0

        flag = 0
        If productos_rentables >= MEDICION Then
            flag = 1
        End If

        If productos_rentables > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(productos_rentables * PESO / 100, 2)
        End If

        tablita1_temporal2.Rows.Add("Productos Rentables", PESO, RESULTADO, META, MEDICION, flag)
        If flag = 1 Then
            resultado_total += RESULTADO
        Else
            resultado_total += 0
        End If
        total_peso += PESO

        tablita1_temporal2.Rows.Add("Total", total_peso, resultado_total, 0, 0, 0)
        grid_resumen_variables2_index.DataSource = tablita1_temporal2
        Dim resultado_volumen As Double = 0
        resultado_volumen = resultado_total
        'fin resumen de las variables

        'resumen del bono
        grid_valor_bono_index.Columns.Add("Descripcion", "Descripcion")
        grid_valor_bono_index.Columns.Add("Valor", "Valor")

        Dim val_bono_cob As Double = 0
        If resultado_coberturas >= 96.25 Then
            val_bono_cob = 2500
        ElseIf resultado_coberturas >= 92.51 Then
            val_bono_cob = 2000
        ElseIf resultado_coberturas >= 90 Then
            val_bono_cob = 1500
        Else
            val_bono_cob = 0
        End If
        grid_valor_bono_index.Rows.Add("Valor del Bono Coberturas", val_bono_cob)

        Dim val_bono_cartera As Double = 0
        If Tipo = "Supervisor" Then
            If resultado_cartera >= 100 Then
                val_bono_cartera = 2500
            ElseIf resultado_cartera >= 98 Then
                val_bono_cartera = 2000
            ElseIf resultado_cartera >= 95 Then
                val_bono_cartera = 1500
            Else
                val_bono_cartera = 0
            End If
            'grid_valor_bono_index.Rows.Add("Valor del Bono Cartera Clientes", val_bono_cartera)
        Else
            val_bono_cartera = 1
        End If

        Dim val_bono_ratio As Double = 0
        If Tipo = "Jefe" Then
            If resultado_cartera >= 100 Then
                val_bono_ratio = 1500
            ElseIf resultado_cartera >= 98 Then
                val_bono_ratio = 1200
            ElseIf resultado_cartera >= 95 Then
                val_bono_ratio = 900
            Else
                val_bono_ratio = 0
            End If
            val_bono_ratio = 1500
            grid_valor_bono_index.Rows.Add("Valor del Bono Ratio y Margen", val_bono_cartera)
        Else
            val_bono_ratio = 1
        End If
        

        Dim val_bono_vol As Double = 0
        If resultado_volumen >= 100 Then
            val_bono_vol = 2500
        ElseIf resultado_volumen >= 98 Then
            val_bono_vol = 2000
        ElseIf resultado_volumen >= 95 Then
            val_bono_vol = 1500
        Else
            val_bono_vol = 0
        End If
        grid_valor_bono_index.Rows.Add("Valor del Bono Volumen", val_bono_vol)

        Dim bono_extra As Double = 0
        If val_bono_cartera > 0 And val_bono_cob > 0 And val_bono_vol > 0 Then
            If ventas_totales >= 110 Then
                bono_extra = 3000
            ElseIf ventas_totales >= 105 Then
                bono_extra = 1500
            Else
                bono_extra = 0
            End If
        End If
        grid_valor_bono_index.Rows.Add("Bono Extra", bono_extra)

        grid_resumen_variables_index.Name = "ResumenVariables1" & nombre_supervisor
        grid_resumen_variables2_index.Name = "ResumenVariables2" & nombre_supervisor
        grid_valor_bono_index.Name = "ValorBono" & nombre_supervisor
        grid_cobertura_proveedores_estrategicos_index.Name = "CoberturaProveedores" & nombre_supervisor
        grid_cartera_credito_index.Name = "CarteraCredito" & nombre_supervisor
        grid_efectividad_index.Name = "Efectividad" & nombre_supervisor
        grid_cobertura_clientes_index.Name = "CoberturaClientes" & nombre_supervisor
        grid_volumen_ventas_index.Name = "VolumenVentas" & nombre_supervisor
        grid_productos_rentables_index.Name = "ProductosRentables" & nombre_supervisor
    End Sub

    Private Sub frm_bonos_nuevos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New ClassVendedores
        Try
            Dim dt As New DataTable
            dt = db.Permiso(_Inicio.lblUsuario.Text)
            If Not IsDBNull(dt(0)(0)) Then
                Permiso = dt(0)(0)
            End If
        Catch ex As Exception
        End Try

        If _Inicio.SANRAFAEL = 1 Then
            ComboEmpresa.Items.Add("SAN RAFAEL")
        End If
        If _Inicio.DIMOSA = 1 Then
            ComboEmpresa.Items.Add("DIMOSA")
        End If
        If _Inicio.AGRO = 1 Then
            ComboEmpresa.Items.Add("SR AGRO")
        End If
        ComboEmpresa.SelectedIndex = 0
        tab_control_ejecutivos.Visible = False


        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboEmpresa.Text <> "SR AGRO" Then
            exportar()
        End If

    End Sub

    Sub exportar()
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wvendedor1 As Microsoft.Office.Interop.Excel.Worksheet
        wBook = excel.Workbooks.Add()
        Dim CONTADOR As Integer = 0
        For Each pagina As TabPage In tab_control_ejecutivos.TabPages
            Dim filas As Integer = 1, filas2 As Integer = 1
            CONTADOR += 1
            wvendedor1 = wBook.Sheets.Add()
            Dim Nombre As String
            Try
                Nombre = pagina.Text.Substring(0, 15)
            Catch ex As Exception
                Nombre = pagina.Text
            End Try
            wvendedor1.Name = Nombre & " p" & CONTADOR
            'MsgBox(wvendedor1.Name)
            For Each Grilla As Control In pagina.Controls
                Try
                    If Grilla.Name.Substring(0, 17) = "ResumenVariables1" Then
                        Dim grilla_real As DataGridView
                        grilla_real = Grilla

                        If grilla_real.RowCount > 0 Then
                            wvendedor1.Cells.Range("A1:E1").Merge()
                            wvendedor1.Cells.Range("A1:E1").Borders.LineStyle = BorderStyle.FixedSingle
                            wvendedor1.Cells.Range("A1:E1").Value = "Resumen de Variables"
                            wvendedor1.Cells.Range("A1:E1").Font.Bold = True
                            wvendedor1.Cells.Range("A1:E1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                            wvendedor1.Cells.Range("A1:E1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                            wvendedor1.Cells.Range("A1:E1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            wvendedor1.Cells.Range("A1:E1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                            For c As Integer = 0 To grilla_real.Columns.Count - 2
                                wvendedor1.Cells(2, c + 1).value = grilla_real.Columns(c).HeaderText
                                wvendedor1.Cells(2, c + 1).Font.Bold = True
                                wvendedor1.Cells(2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                wvendedor1.Cells(2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                                wvendedor1.Cells(2, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                            Next
                            For r As Integer = 0 To grilla_real.RowCount - 1
                                For c As Integer = 0 To grilla_real.Columns.Count - 2
                                    wvendedor1.Cells(r + 3, c + 1).value = grilla_real.Item(c, r).Value
                                    wvendedor1.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                                    If grilla_real.Rows(r).Cells(5).Value = 1 And r <> grilla_real.RowCount - 1 Then
                                        wvendedor1.Cells(r + 3, 3).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        wvendedor1.Cells(r + 3, 3).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green)
                                    Else
                                        wvendedor1.Cells(r + 3, 3).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        wvendedor1.Cells(r + 3, 3).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                                    End If

                                    If r = grilla_real.RowCount - 1 Then
                                        wvendedor1.Cells(r + 3, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                        wvendedor1.Cells(r + 3, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    End If
                                Next
                            Next

                            filas = grilla_real.RowCount + 5
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Grilla.Name.Substring(0, 17) = "ResumenVariables2" Then
                        Dim grilla_real2 As DataGridView
                        grilla_real2 = Grilla

                        If grilla_real2.RowCount > 0 Then
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":E" & filas.ToString()).Merge()
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":E" & filas.ToString()).Borders.LineStyle = BorderStyle.FixedSingle
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":E" & filas.ToString()).Value = "Resumen de Variables"
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":E" & filas.ToString()).Font.Bold = True
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":E" & filas.ToString()).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":E" & filas.ToString()).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":E" & filas.ToString()).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":E" & filas.ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                            For c As Integer = 0 To grilla_real2.Columns.Count - 2
                                wvendedor1.Cells(filas + 1, c + 1).value = grilla_real2.Columns(c).HeaderText
                                wvendedor1.Cells(filas + 1, c + 1).Font.Bold = True
                                wvendedor1.Cells(filas + 1, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                wvendedor1.Cells(filas + 1, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                                wvendedor1.Cells(filas + 1, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                            Next
                            For r As Integer = 0 To grilla_real2.RowCount - 1
                                For c As Integer = 0 To grilla_real2.Columns.Count - 2
                                    wvendedor1.Cells(filas + r + 2, c + 1).value = grilla_real2.Item(c, r).Value
                                    wvendedor1.Cells(filas + r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                                    If grilla_real2.Rows(r).Cells(5).Value = 1 And r <> grilla_real2.RowCount - 1 Then
                                        wvendedor1.Cells(filas + r + 2, 3).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        wvendedor1.Cells(filas + r + 2, 3).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green)
                                    Else
                                        wvendedor1.Cells(filas + r + 2, 3).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                        wvendedor1.Cells(filas + r + 2, 3).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                                    End If

                                    If r = grilla_real2.RowCount - 1 Then
                                        wvendedor1.Cells(filas + r + 2, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                        wvendedor1.Cells(filas + r + 2, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    End If
                                Next
                            Next
                            filas += grilla_real2.RowCount + 5
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Grilla.Name.Substring(0, 9) = "ValorBono" Then
                        Dim grilla_real2 As DataGridView
                        grilla_real2 = Grilla
                        If grilla_real2.RowCount > 0 Then
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":B" & filas.ToString()).Merge()
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":B" & filas.ToString()).Borders.LineStyle = BorderStyle.FixedSingle
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":B" & filas.ToString()).Value = "Valor del Bono"
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":B" & filas.ToString()).Font.Bold = True
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":B" & filas.ToString()).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":B" & filas.ToString()).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":B" & filas.ToString()).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            wvendedor1.Cells.Range("A" & filas.ToString() & ":B" & filas.ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                            For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                wvendedor1.Cells(filas + 1, c + 1).value = grilla_real2.Columns(c).HeaderText
                                wvendedor1.Cells(filas + 1, c + 1).Font.Bold = True
                                wvendedor1.Cells(filas + 1, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                wvendedor1.Cells(filas + 1, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                                wvendedor1.Cells(filas + 1, c + 1).Borders.LineStyle = BorderStyle.FixedSingle
                            Next
                            For r As Integer = 0 To grilla_real2.RowCount - 1
                                For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                    wvendedor1.Cells(filas + r + 2, c + 1).value = grilla_real2.Item(c, r).Value
                                    wvendedor1.Cells(filas + r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                                Next
                            Next
                            filas += grilla_real2.RowCount + 5
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Grilla.Name.Substring(0, 20) = "CoberturaProveedores" Then
                        Dim grilla_real2 As DataGridView
                        grilla_real2 = Grilla

                        If grilla_real2.RowCount > 0 Then
                            wvendedor1.Cells.Range("G1:L1").Merge()
                            wvendedor1.Cells.Range("G1:L1").Borders.LineStyle = BorderStyle.FixedSingle
                            wvendedor1.Cells.Range("G1:L1").Value = "Cobertura de Proveedores Estrategicos"
                            wvendedor1.Cells.Range("G1:L1").Font.Bold = True
                            wvendedor1.Cells.Range("G1:L1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                            wvendedor1.Cells.Range("G1:L1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                            wvendedor1.Cells.Range("G1:L1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            wvendedor1.Cells.Range("G1:L1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                            For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                wvendedor1.Cells(2, c + 7).value = grilla_real2.Columns(c).HeaderText
                                wvendedor1.Cells(2, c + 7).Font.Bold = True
                                wvendedor1.Cells(2, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                wvendedor1.Cells(2, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                                wvendedor1.Cells(2, c + 7).Borders.LineStyle = BorderStyle.FixedSingle
                            Next
                            For r As Integer = 0 To grilla_real2.RowCount - 1
                                For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                    wvendedor1.Cells(r + 3, c + 7).value = grilla_real2.Item(c, r).Value
                                    wvendedor1.Cells(r + 3, c + 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                                    If r = grilla_real2.RowCount - 1 Then
                                        wvendedor1.Cells(r + 3, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                        wvendedor1.Cells(r + 3, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    End If
                                Next
                            Next

                            filas2 += grilla_real2.RowCount + 5
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Grilla.Name.Substring(0, 14) = "CarteraCredito" Then
                        Dim grilla_real2 As DataGridView
                        grilla_real2 = Grilla

                        If grilla_real2.RowCount > 0 Then
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Merge()
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Borders.LineStyle = BorderStyle.FixedSingle
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Value = "Cartera Credito"
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Font.Bold = True
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                            For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                wvendedor1.Cells(filas2 + 1, c + 7).value = grilla_real2.Columns(c).HeaderText
                                wvendedor1.Cells(filas2 + 1, c + 7).Font.Bold = True
                                wvendedor1.Cells(filas2 + 1, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                wvendedor1.Cells(filas2 + 1, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                                wvendedor1.Cells(filas2 + 1, c + 7).Borders.LineStyle = BorderStyle.FixedSingle
                            Next
                            For r As Integer = 0 To grilla_real2.RowCount - 1
                                For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                    wvendedor1.Cells(filas2 + r + 2, c + 7).value = grilla_real2.Item(c, r).Value
                                    wvendedor1.Cells(filas2 + r + 2, c + 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                                    If r = grilla_real2.RowCount - 1 Then
                                        wvendedor1.Cells(filas2 + r + 2, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                        wvendedor1.Cells(filas2 + r + 2, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    End If
                                Next
                            Next

                            filas2 += grilla_real2.RowCount + 3
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Grilla.Name.Substring(0, 11) = "Efectividad" Then
                        Dim grilla_real2 As DataGridView
                        grilla_real2 = Grilla

                        If grilla_real2.RowCount > 0 Then
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Merge()
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Borders.LineStyle = BorderStyle.FixedSingle
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Value = "Efectividad"
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Font.Bold = True
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":I" & filas2.ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                            For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                wvendedor1.Cells(filas2 + 1, c + 7).value = grilla_real2.Columns(c).HeaderText
                                wvendedor1.Cells(filas2 + 1, c + 7).Font.Bold = True
                                wvendedor1.Cells(filas2 + 1, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                wvendedor1.Cells(filas2 + 1, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                                wvendedor1.Cells(filas2 + 1, c + 7).Borders.LineStyle = BorderStyle.FixedSingle
                            Next
                            For r As Integer = 0 To grilla_real2.RowCount - 1
                                For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                    wvendedor1.Cells(filas2 + r + 2, c + 7).value = grilla_real2.Item(c, r).Value
                                    wvendedor1.Cells(filas2 + r + 2, c + 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                                    If r = grilla_real2.RowCount - 1 Then
                                        wvendedor1.Cells(filas2 + r + 2, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                        wvendedor1.Cells(filas2 + r + 2, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    End If
                                Next
                            Next
                            filas2 += grilla_real2.RowCount + 3
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Grilla.Name.Substring(0, 17) = "CoberturaClientes" Then
                        Dim grilla_real2 As DataGridView
                        grilla_real2 = Grilla

                        If grilla_real2.RowCount > 0 Then
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Merge()
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Borders.LineStyle = BorderStyle.FixedSingle
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Value = "Cobertura"
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Font.Bold = True
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                            For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                wvendedor1.Cells(filas2 + 1, c + 7).value = grilla_real2.Columns(c).HeaderText
                                wvendedor1.Cells(filas2 + 1, c + 7).Font.Bold = True
                                wvendedor1.Cells(filas2 + 1, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                wvendedor1.Cells(filas2 + 1, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                                wvendedor1.Cells(filas2 + 1, c + 7).Borders.LineStyle = BorderStyle.FixedSingle
                            Next
                            For r As Integer = 0 To grilla_real2.RowCount - 1
                                For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                    wvendedor1.Cells(filas2 + r + 2, c + 7).value = grilla_real2.Item(c, r).Value
                                    wvendedor1.Cells(filas2 + r + 2, c + 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                                    If r = grilla_real2.RowCount - 1 Then
                                        wvendedor1.Cells(filas2 + r + 2, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                        wvendedor1.Cells(filas2 + r + 2, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    End If
                                Next
                            Next
                            filas2 += grilla_real2.RowCount + 3
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Grilla.Name.Substring(0, 13) = "VolumenVentas" Then
                        Dim grilla_real2 As DataGridView
                        grilla_real2 = Grilla

                        If grilla_real2.RowCount > 0 Then
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Merge()
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Borders.LineStyle = BorderStyle.FixedSingle
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Value = "Volumen de Ventas"
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Font.Bold = True
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":J" & filas2.ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                            For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                wvendedor1.Cells(filas2 + 1, c + 7).value = grilla_real2.Columns(c).HeaderText
                                wvendedor1.Cells(filas2 + 1, c + 7).Font.Bold = True
                                wvendedor1.Cells(filas2 + 1, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                wvendedor1.Cells(filas2 + 1, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                                wvendedor1.Cells(filas2 + 1, c + 7).Borders.LineStyle = BorderStyle.FixedSingle
                            Next
                            For r As Integer = 0 To grilla_real2.RowCount - 1
                                For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                    wvendedor1.Cells(filas2 + r + 2, c + 7).value = grilla_real2.Item(c, r).Value
                                    wvendedor1.Cells(filas2 + r + 2, c + 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                                    If r = grilla_real2.RowCount - 1 Then
                                        wvendedor1.Cells(filas2 + r + 2, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                        wvendedor1.Cells(filas2 + r + 2, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    End If
                                Next
                            Next
                            filas2 += grilla_real2.RowCount + 3
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Grilla.Name.Substring(0, 18) = "ProductosRentables" Then
                        Dim grilla_real2 As DataGridView
                        grilla_real2 = Grilla

                        If grilla_real2.RowCount > 0 Then
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":L" & filas2.ToString()).Merge()
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":L" & filas2.ToString()).Borders.LineStyle = BorderStyle.FixedSingle
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":L" & filas2.ToString()).Value = "Productos Rentables"
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":L" & filas2.ToString()).Font.Bold = True
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":L" & filas2.ToString()).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":L" & filas2.ToString()).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":L" & filas2.ToString()).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                            wvendedor1.Cells.Range("G" & filas2.ToString() & ":L" & filas2.ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                            For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                wvendedor1.Cells(filas2 + 1, c + 7).value = grilla_real2.Columns(c).HeaderText
                                wvendedor1.Cells(filas2 + 1, c + 7).Font.Bold = True
                                wvendedor1.Cells(filas2 + 1, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                wvendedor1.Cells(filas2 + 1, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                                wvendedor1.Cells(filas2 + 1, c + 7).Borders.LineStyle = BorderStyle.FixedSingle
                            Next
                            For r As Integer = 0 To grilla_real2.RowCount - 1
                                For c As Integer = 0 To grilla_real2.Columns.Count - 1
                                    wvendedor1.Cells(filas2 + r + 2, c + 7).value = grilla_real2.Item(c, r).Value
                                    wvendedor1.Cells(filas2 + r + 2, c + 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                                    If r = grilla_real2.RowCount - 1 Then
                                        wvendedor1.Cells(filas2 + r + 2, c + 7).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                                        wvendedor1.Cells(filas2 + r + 2, c + 7).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                                    End If
                                Next
                            Next
                            filas2 += grilla_real2.RowCount + 3
                        End If
                    End If
                Catch ex As Exception
                End Try

            Next
            wvendedor1.Columns.AutoFit()
        Next
        excel.Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        exportar()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEmpresa.SelectedIndexChanged
        Dim Data2 As New DataView
        Dim dbVendedores As New ClassVendedores
        Try
            DataSupervisores.Columns.Clear()
            If ComboEmpresa.Text <> "SR AGRO" Then
                Data2 = dbVendedores.CargarSupervisores_nuevos(ComboEmpresa.Text)
            Else
                Data2 = dbVendedores.CargarVendedores(ComboEmpresa.Text, "AMBOS")
            End If

            If Not (IsNothing(dbVendedores.CargarSupervisores_nuevos(ComboEmpresa.Text))) Then
                DataSupervisores.DataSource = Data2
                If (DataSupervisores.ColumnCount = 4) Then
                    Dim chk2 As New DataGridViewCheckBoxColumn()
                    DataSupervisores.Columns.Add(chk2)
                    chk2.HeaderText = "Calcular"
                    chk2.Name = "chk2"
                End If
                DataSupervisores.Columns(1).Width = 220%
            End If
        Catch ex As Exception
        End Try

        Dim dtx As New DataTable

        Dim dbx As New ClassVendedores
        Try
            dtx = dbx.CargarSupervisoresCombo(ComboEmpresa.Text, Permiso)
            'MsgBox(dtx.Rows.Count & " " & Permiso)

            For j As Integer = DataSupervisores.RowCount - 1 To 0 Step -1
                Dim Eva As Integer = 0
                For i As Integer = 0 To dtx.Rows.Count - 1
                    If DataSupervisores.Rows(j).Cells(0).Value = dtx(i)(0) Then
                        Eva = 1
                        'MsgBox(row.Cells(0).Value & " = " & dtx(i)(0))
                    Else
                        'MsgBox(row.Cells(0).Value & " <> " & dtx(i)(0))
                    End If
                Next
                If Eva = 0 Then
                    DataSupervisores.Rows.RemoveAt(j)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub cargar_ejecutivos_dimosa(ByVal dt_vendedores As DataTable)
        Dim ancho As Double
        Dim anchor As AnchorStyles
        anchor = AnchorStyles.Right Or AnchorStyles.Left Or AnchorStyles.Top

        For index As Integer = 0 To dt_vendedores.Rows.Count - 1
            Dim hoja_vendedor_index As New TabPage
            Dim label_index = New Label, label2_index = New Label, label3_index = New Label, label4_index = New Label
            Dim label5_index = New Label, label6_index = New Label, label7_index = New Label, label8_index = New Label
            Dim label9_index = New Label, label10_index = New Label, label66_index = New Label

            Dim grid_resumen_variables_index As New DataGridView, grid_resumen_variables2_index As New DataGridView
            Dim grid_valor_bono_index As New DataGridView, grid_efectividad_index As New DataGridView, grid_cobertura_clientes_index As New DataGridView
            Dim grid_cobertura_proveedores_estrategicos_index As New DataGridView
            Dim grid_volumen_ventas_index As New DataGridView, grid_productos_rentables_index As New DataGridView, grid_cartera_credito_index As New DataGridView

            grid_resumen_variables_index.ReadOnly = True
            grid_resumen_variables2_index.ReadOnly = True
            grid_valor_bono_index.ReadOnly = True
            grid_efectividad_index.ReadOnly = True
            grid_cobertura_clientes_index.ReadOnly = True
            grid_cobertura_proveedores_estrategicos_index.ReadOnly = True
            grid_volumen_ventas_index.ReadOnly = True
            grid_productos_rentables_index.ReadOnly = True

            grid_resumen_variables_index.AllowUserToAddRows = False
            grid_resumen_variables2_index.AllowUserToAddRows = False
            grid_valor_bono_index.AllowUserToAddRows = False
            grid_efectividad_index.AllowUserToAddRows = False
            grid_cobertura_clientes_index.AllowUserToAddRows = False
            grid_cobertura_proveedores_estrategicos_index.AllowUserToAddRows = False
            grid_volumen_ventas_index.AllowUserToAddRows = False
            grid_productos_rentables_index.AllowUserToAddRows = False

            hoja_vendedor_index.Name = dt_vendedores.Rows(index)(0)
            hoja_vendedor_index.Text = dt_vendedores.Rows(index)(1)
            hoja_vendedor_index.AutoScroll = True
            tab_control_ejecutivos.TabPages.Add(hoja_vendedor_index)

            ancho = hoja_vendedor_index.Width / 2

            label_index.Text = "Resumen Variables Cobertura"
            hoja_vendedor_index.Controls.Add(label_index)

            Dim ubicacion As Integer = label_index.Height
            grid_resumen_variables_index.Width = ancho
            grid_resumen_variables_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_resumen_variables_index)
            grid_resumen_variables_index.Location = New Point(1, ubicacion)

            ubicacion += grid_resumen_variables_index.Height + 1

            label2_index.Text = "Resumen Variables Volumen"
            label2_index.Location = New Point(1, ubicacion)
            hoja_vendedor_index.Controls.Add(label2_index)
            ubicacion += label2_index.Height

            grid_resumen_variables2_index.Width = ancho
            grid_resumen_variables2_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_resumen_variables2_index)
            grid_resumen_variables2_index.Location = New Point(1, ubicacion)

            ubicacion += grid_resumen_variables2_index.Height
            label3_index.Text = "Bono"
            label3_index.Width = 250
            hoja_vendedor_index.Controls.Add(label3_index)
            label3_index.Location = New Point(1, ubicacion)
            ubicacion += label3_index.Height

            grid_valor_bono_index.Width = ancho
            grid_valor_bono_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_valor_bono_index)
            grid_valor_bono_index.Location = New Point(1, ubicacion)
            ubicacion += grid_valor_bono_index.Height

            label6_index.Text = "Cobertura de Productos Estrategicos"
            label6_index.Width = 250
            hoja_vendedor_index.Controls.Add(label6_index)
            label6_index.Location = New Point(1, ubicacion)
            ubicacion += label6_index.Height

            Dim tcpe As Double = 0, val1 As Double = 0, val2 As Double = 0, val3 As Double = 0

            grid_cobertura_proveedores_estrategicos_index.Width = ancho
            grid_cobertura_proveedores_estrategicos_index.Anchor = anchor

            grid_cobertura_proveedores_estrategicos_index.Name = "CoberturaProveedores" & dt_vendedores.Rows(index)(0) & index.ToString()

            hoja_vendedor_index.Controls.Add(grid_cobertura_proveedores_estrategicos_index)
            grid_cobertura_proveedores_estrategicos_index.DataSource = Nothing
            grid_cobertura_proveedores_estrategicos_index.Location = New Point(1, ubicacion)
            ubicacion += grid_cobertura_proveedores_estrategicos_index.Height


            'CARTERA CREDITO
            label66_index.Text = "Cartera de Credito"
            label66_index.Width = 250
            hoja_vendedor_index.Controls.Add(label66_index)
            label66_index.Location = New Point(1, ubicacion)
            ubicacion += label66_index.Height

            Dim dt_cartera_credito_index As New DataTable
            If dt_vendedores.Rows(index)(2) = "MAY" Then
                dt_cartera_credito_index = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "CARTERA CREDITO", 82, ComboEmpresa.Text)
            Else
            End If

            grid_cartera_credito_index.Width = ancho
            grid_cartera_credito_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_cartera_credito_index)
            grid_cartera_credito_index.DataSource = dt_cartera_credito_index
            grid_cartera_credito_index.Location = New Point(1, ubicacion)
            'FIN CARTERA CREDITO

            ubicacion = 0
            label7_index.Text = "Efectividad"
            hoja_vendedor_index.Controls.Add(label7_index)
            label7_index.Location = New Point(ancho + 10, ubicacion)
            ubicacion += label7_index.Height

            Dim dt_efectividad_index As New DataTable
            If dt_vendedores.Rows(index)(2) = "DET" Then
                dt_efectividad_index = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "EFECTIVIDAD", 82, ComboEmpresa.Text)
            Else
            End If

            grid_efectividad_index.Width = ancho
            grid_efectividad_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_efectividad_index)
            grid_efectividad_index.DataSource = dt_efectividad_index
            grid_efectividad_index.Location = New Point(ancho + 10, ubicacion)

            ubicacion += grid_efectividad_index.Height
            label8_index.Text = "Cobertura de Clientes"
            label8_index.Width = 250
            hoja_vendedor_index.Controls.Add(label8_index)
            label8_index.Location = New Point(ancho + 10, ubicacion)
            ubicacion += label8_index.Height

            Dim dt_cobertura_clientes_index As New DataTable
            If dt_vendedores.Rows(index)(2) = "DET" Then
                dt_cobertura_clientes_index = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "COBERTURA_CLIENTES", 82, ComboEmpresa.Text)
            Else
            End If

            grid_cobertura_clientes_index.Width = ancho
            grid_cobertura_clientes_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_cobertura_clientes_index)
            grid_cobertura_clientes_index.DataSource = dt_cobertura_clientes_index
            grid_cobertura_clientes_index.Location = New Point(ancho + 10, ubicacion)
            ubicacion += grid_cobertura_clientes_index.Height
            label9_index.Text = "Volumen de Ventas"
            hoja_vendedor_index.Controls.Add(label9_index)
            label9_index.Location = New Point(ancho + 10, ubicacion)
            ubicacion += label9_index.Height

            Dim dt_volumnen_ventas_index As New DataTable
            dt_volumnen_ventas_index = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "VENTAS_TOTALES", 82, ComboEmpresa.Text)

            grid_volumen_ventas_index.Width = ancho
            grid_volumen_ventas_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_volumen_ventas_index)
            grid_volumen_ventas_index.DataSource = dt_volumnen_ventas_index
            grid_volumen_ventas_index.Location = New Point(ancho + 10, ubicacion)

            ubicacion += grid_volumen_ventas_index.Height

            label10_index.Text = "Productos Rentables"
            label10_index.Width = 250
            hoja_vendedor_index.Controls.Add(label10_index)
            label10_index.Location = New Point(ancho + 10, ubicacion)
            ubicacion += label10_index.Height

            grid_productos_rentables_index.Width = ancho
            grid_productos_rentables_index.Anchor = anchor
            hoja_vendedor_index.Controls.Add(grid_productos_rentables_index)
            grid_productos_rentables_index.Location = New Point(ancho + 10, ubicacion)

            'Resumen de las Variables'
            Dim tablita1_temporal As New DataTable
            tablita1_temporal.Columns.Add("Variable")
            tablita1_temporal.Columns.Add("Peso")
            tablita1_temporal.Columns.Add("Resultado")
            tablita1_temporal.Columns.Add("Meta")
            tablita1_temporal.Columns.Add("Medicion")
            tablita1_temporal.Columns.Add("Flag")

            Dim total_peso As Double = 0
            Dim resultado_total As Double = 0
            Dim ventas_totales As Double = 0
            Dim cobertura_clientes As Double = 0

            Try
                ventas_totales = dt_volumnen_ventas_index.Rows(0)(3)
                vol_meta_total += dt_volumnen_ventas_index.Rows(0)(1)
                vol_venta_total += dt_volumnen_ventas_index.Rows(0)(2)
            Catch ex As Exception
                ventas_totales = 0
                vol_meta_total += 0
                vol_venta_total += 0
            End Try

            Dim tabla_datos As New DataTable
            Dim PESO As Double = 0, META As Double = 0, MEDICION As Double = 0
            Dim flag As Integer = 0
            Dim resultado As Double = 0
            Dim resultado_cobertura As Double = 0
            Dim resultado_coberturas As Double = 0
            Dim cartera_clientes As Double = 0
            Dim resultado_cartera As Double = 0
            If dt_vendedores.Rows(index)(2) = "DET" Then
                Try
                    cobertura_clientes = dt_cobertura_clientes_index.Rows(0)(3)
                    cob_meta_total += dt_cobertura_clientes_index.Rows(0)(1)
                    cob_resultado_total += dt_cobertura_clientes_index.Rows(0)(2)
                Catch ex As Exception
                    cobertura_clientes = 0
                    cob_meta_total += 0
                    cob_resultado_total += 0
                End Try

                Try
                    cartera_clientes = dt_cartera_credito_index.Rows(0)(3)
                Catch ex As Exception
                    cartera_clientes = 0
                End Try

                tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 2, ComboEmpresa.Text)

                If tabla_datos.Rows.Count > 0 Then
                    PESO = tabla_datos.Rows(0)(0)
                    META = tabla_datos.Rows(0)(1)
                    MEDICION = tabla_datos.Rows(0)(2)
                Else
                    PESO = 0
                    META = 0
                    MEDICION = 0
                End If

                flag = 0
                If tcpe >= MEDICION Then
                    flag = 1
                End If

                If tcpe > 100 Then
                    resultado = PESO
                Else
                    resultado = Math.Round(tcpe * PESO / 100, 2)
                End If

                'tablita1_temporal.Rows.Add("Cobertura de Proveedores Estrategicos", PESO, resultado, META, MEDICION, flag)

                'VARIABLES SUPERVISOR
                tcpe_peso_supervisor += PESO
                tcpe_resultado_supervisor += resultado
                tcpe_meta_supervisor += META
                tcpe_medicion_supervisor += MEDICION
                tcpe_divisor += 1
                'FIN VARIABLES SUPERVISOR

                total_peso += PESO
                If flag = 1 Then
                    resultado_total += resultado
                Else
                    resultado_total += 0
                End If

                tabla_datos = Nothing
                tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 1, ComboEmpresa.Text)
                PESO = 0
                META = 0
                MEDICION = 0
                If tabla_datos.Rows.Count > 0 Then
                    PESO = tabla_datos.Rows(0)(0)
                    META = tabla_datos.Rows(0)(1)
                    MEDICION = tabla_datos.Rows(0)(2)
                Else
                    PESO = 0
                    META = 0
                    MEDICION = 0
                End If


                Dim db As New ClsClientes
                Dim dtUniverso As New DataTable

                flag = 0
                Dim tefectividad As Double = 0
                Dim universo As Double = 0

                Dim Cantidad_E As Decimal = 0
                Try
                    If ComboEmpresa.Text = "SAN RAFAEL" Then
                        dtUniverso = db.ClientesIdeales(Cmb_Fecha_Final.Value.Year, Cmb_Fecha_Final.Value.Month, dt_vendedores.Rows(index)(0))
                    Else
                        dtUniverso = db.ClientesIdealesDIMOSA(Cmb_Fecha_Final.Value.Year, Cmb_Fecha_Final.Value.Month, dt_vendedores.Rows(index)(0))
                    End If

                    Cantidad_E = (dtUniverso(0)(3) / 6)
                Catch ex As Exception
                End Try
                universo = Math.Round(dias_habiles * Cantidad_E, 0)
                Try
                    universo = dtUniverso(0)(6)
                Catch ex As Exception
                End Try

                Try
                    dt_efectividad_index.Rows(0)(0) = universo
                    tefectividad = dt_efectividad_index.Rows(0)(1)
                    resultado_cobertura = (tefectividad / universo) * 100
                    dt_efectividad_index.Rows(0)(2) = resultado_cobertura

                    efe_metal_total += universo
                    efe_resultado_total += tefectividad
                Catch ex As Exception
                    resultado_cobertura = 0
                End Try

                If resultado_cobertura >= MEDICION Then
                    flag = 1
                End If

                If resultado_cobertura > MEDICION Then
                    resultado = PESO
                Else
                    resultado = Math.Round(resultado_cobertura * PESO / MEDICION, 2)
                End If
                tablita1_temporal.Rows.Add("Efectividad", PESO, resultado, META, MEDICION, flag)

                efe_peso_supervisor += PESO
                efe_resultado_supervisor += resultado
                efe_meta_supervisor += META
                efe_medicion_supervisor += MEDICION
                efe_divisor_supervisor += 1

                total_peso += PESO

                tabla_datos = Nothing
                tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 4, ComboEmpresa.Text)
                PESO = 0
                META = 0
                MEDICION = 0
                If tabla_datos.Rows.Count > 0 Then
                    PESO = tabla_datos.Rows(0)(0)
                    META = tabla_datos.Rows(0)(1)
                    MEDICION = tabla_datos.Rows(0)(2)
                Else
                    PESO = 0
                    META = 0
                    MEDICION = 0
                End If

                flag = 0
                If cobertura_clientes >= MEDICION Then
                    flag = 1
                End If

                If cobertura_clientes > 100 Then
                    resultado = PESO
                Else
                    resultado = Math.Round(cobertura_clientes * PESO / 100, 2)
                End If

                tablita1_temporal.Rows.Add("Cobertura de Clientes", PESO, resultado, META, MEDICION, flag)

                cob_peso_supervisor += PESO
                cob_resultado_supervisor += resultado
                cob_meta_supervisor += META
                cob_medicion_supervisor += MEDICION
                cob_divisor_supervisor += 1

                total_peso += PESO
                If flag = 1 Then
                    resultado_total += resultado
                Else
                    resultado_total += 0
                End If

                tablita1_temporal.Rows.Add("Total", total_peso, resultado_total, 0, 0, 0)
                resultado_coberturas = resultado_total
                grid_resumen_variables_index.DataSource = tablita1_temporal
                total_peso = 0
                resultado_total = 0
            Else
            End If
            'variables de volumen
            Dim tablita1_temporal2 As New DataTable
            tablita1_temporal2.Columns.Add("Variable")
            tablita1_temporal2.Columns.Add("Peso")
            tablita1_temporal2.Columns.Add("Resultado")
            tablita1_temporal2.Columns.Add("Meta")
            tablita1_temporal2.Columns.Add("Medicion")
            tablita1_temporal2.Columns.Add("Flag")

            tabla_datos = Nothing
            tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 3, ComboEmpresa.Text)
            PESO = 0
            META = 0
            MEDICION = 0
            If tabla_datos.Rows.Count > 0 Then
                PESO = tabla_datos.Rows(0)(0)
                META = tabla_datos.Rows(0)(1)
                MEDICION = tabla_datos.Rows(0)(2)
            Else
                PESO = 0
                META = 0
                MEDICION = 0
            End If

            flag = 0
            If ventas_totales >= MEDICION Then
                flag = 1
            End If

            If ventas_totales > 100 Then
                resultado = PESO
            Else
                resultado = Math.Round(ventas_totales * PESO / 100, 2)
            End If

            tablita1_temporal2.Rows.Add("Volumen de Ventas", PESO, resultado, META, MEDICION, flag)

            vol_resultado_supervisor += resultado
            vol_meta_supervisor += META
            vol_divisor_supervisor += 1

            If dt_vendedores.Rows(index)(2) = "MAY" Then
                vol_divisor_supervisor_may += 1
            Else
                vol_peso_supervisor += PESO
                vol_medicion_supervisor += MEDICION
            End If

            total_peso += PESO

            If flag = 1 Then
                resultado_total += resultado
            Else
                resultado_total += 0
            End If

            'CARTERA DE CLIENTES'
            If dt_vendedores.Rows(index)(2) = "MAY" Then
                tabla_datos = Nothing
                tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 6, ComboEmpresa.Text)
                PESO = 0
                META = 0
                MEDICION = 0
                If tabla_datos.Rows.Count > 0 Then
                    PESO = tabla_datos.Rows(0)(0)
                    META = tabla_datos.Rows(0)(1)
                    MEDICION = tabla_datos.Rows(0)(2)
                Else
                    PESO = 0
                    META = 0
                    MEDICION = 0
                End If

                flag = 0
                If cartera_clientes >= MEDICION Then
                    flag = 1
                End If

                If cartera_clientes > 100 Then
                    resultado = PESO
                Else
                    resultado = Math.Round(cartera_clientes * PESO / 100, 2)
                End If

                tablita1_temporal2.Rows.Add("Cartera Clientes", PESO, resultado, META, MEDICION, flag)
                total_peso += PESO
                If flag = 1 Then
                    resultado_total += resultado
                    resultado_cartera = resultado
                Else
                    resultado_total += 0
                End If

                ''  Cartera de Clientes Siempre 100
                resultado_cartera = 100
                ''

            End If
            'FIN CARTERA DE CLIENTES'
            If dt_vendedores.Rows(index)(2) = "DET" Then
                Dim productos_rentables As Double = 0
                tabla_datos = Nothing
                tabla_datos = Conexion.Bonificaciones_Ventas(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, dt_vendedores.Rows(index)(0), "DATOS", 5, ComboEmpresa.Text)
                PESO = 0
                resultado = 0
                META = 0
                MEDICION = 0
                If tabla_datos.Rows.Count > 0 Then
                    PESO = tabla_datos.Rows(0)(0)
                    META = tabla_datos.Rows(0)(1)
                    MEDICION = tabla_datos.Rows(0)(2)
                Else
                    PESO = 0
                    META = 0
                    MEDICION = 0
                End If

                flag = 0
                If productos_rentables >= MEDICION Then
                    flag = 1
                End If

                If productos_rentables > 100 Then
                    resultado = PESO
                Else
                    resultado = Math.Round(productos_rentables * PESO / 100, 2)
                End If

                tablita1_temporal2.Rows.Add("Productos Rentables", PESO, resultado, META, MEDICION, flag)
                If flag = 1 Then
                    resultado_total += resultado
                Else
                    resultado_total += 0
                End If
                total_peso += PESO
            Else
            End If

            tablita1_temporal2.Rows.Add("Total", total_peso, resultado_total, 0, 0, 0)
            grid_resumen_variables2_index.DataSource = tablita1_temporal2
            Dim resultado_volumen As Double = 0
            resultado_volumen = resultado_total
            'fin resumen de las variables

            'resumen del bono
            grid_valor_bono_index.Columns.Add("Descripcion", "Descripcion")
            grid_valor_bono_index.Columns.Add("Valor", "Valor")

            Dim Cobertura As Integer = 0
            If dt_vendedores.Rows(index)(2) = "DET" Then
                Dim val_bono_cob As Double = 0
                If resultado_coberturas >= 96.25 Then
                    val_bono_cob = 1500
                ElseIf resultado_coberturas >= 92.51 Then
                    val_bono_cob = 1200
                ElseIf resultado_coberturas >= 85 Then
                    val_bono_cob = 900
                Else
                    val_bono_cob = 0
                End If
                grid_valor_bono_index.Rows.Add("Valor del Bono Coberturas", val_bono_cob)
                Cobertura = val_bono_cob
            Else
                Cobertura = 1
            End If

            Dim Cartera As Integer = 0
            If dt_vendedores.Rows(index)(2) = "MAY" Then
                Dim val_bono_cartera As Double = 0
                If resultado_cartera >= 100 Then
                    val_bono_cartera = 1500
                ElseIf resultado_cartera >= 98 Then
                    val_bono_cartera = 1200
                ElseIf resultado_cartera >= 95 Then
                    val_bono_cartera = 900
                Else
                    val_bono_cartera = 0
                End If
                grid_valor_bono_index.Rows.Add("Valor del Bono Cartera Clientes", val_bono_cartera)
                Cartera = val_bono_cartera
            Else
                Cartera = 1
            End If


            Dim val_bono_vol As Double = 0
            If resultado_volumen >= 100 Then
                val_bono_vol = 1500
            ElseIf resultado_volumen >= 98 Then
                val_bono_vol = 1200
            ElseIf resultado_volumen >= 95 Then
                val_bono_vol = 900
            Else
                val_bono_vol = 0
            End If
            grid_valor_bono_index.Rows.Add("Valor del Bono Volumen", val_bono_vol)

            Dim bono_extra As Double = 0
            If val_bono_vol > 0 And Cartera > 0 And val_bono_vol > 0 Then
                If ventas_totales >= 110 Then
                    bono_extra = 3000
                ElseIf ventas_totales >= 105 Then
                    bono_extra = 1500
                Else
                    bono_extra = 0
                End If
            End If
            grid_valor_bono_index.Rows.Add("Bono Extra", bono_extra)

            grid_resumen_variables_index.Name = "ResumenVariables1" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_resumen_variables2_index.Name = "ResumenVariables2" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_valor_bono_index.Name = "ValorBono" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_cartera_credito_index.Name = "CarteraCredito" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_efectividad_index.Name = "Efectividad" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_cobertura_clientes_index.Name = "CoberturaClientes" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_volumen_ventas_index.Name = "VolumenVentas" & dt_vendedores.Rows(index)(0) & index.ToString()
            grid_productos_rentables_index.Name = "ProductosRentables" & dt_vendedores.Rows(index)(0) & index.ToString()

        Next
    End Sub

    Sub cargar_supervisores_dimosa(ByVal codigo_supervisor As String, ByVal nombre_supervisor As String, ByVal hoja_supervisor_index As TabPage, ByVal Tipo As String)
        Dim ancho As Double
        Dim anchor As AnchorStyles
        anchor = AnchorStyles.Right Or AnchorStyles.Left Or AnchorStyles.Top

        Dim label_index = New Label, label2_index = New Label, label3_index = New Label, label4_index = New Label
        Dim label5_index = New Label, label6_index = New Label, label7_index = New Label, label8_index = New Label
        Dim label9_index = New Label, label10_index = New Label, label66_index = New Label

        Dim grid_resumen_variables_index As New DataGridView, grid_resumen_variables2_index As New DataGridView
        Dim grid_valor_bono_index As New DataGridView, grid_efectividad_index As New DataGridView, grid_cobertura_clientes_index As New DataGridView
        Dim grid_cobertura_proveedores_estrategicos_index As New DataGridView
        Dim grid_volumen_ventas_index As New DataGridView, grid_productos_rentables_index As New DataGridView, grid_cartera_credito_index As New DataGridView

        grid_resumen_variables_index.ReadOnly = True
        grid_resumen_variables2_index.ReadOnly = True
        grid_valor_bono_index.ReadOnly = True
        grid_efectividad_index.ReadOnly = True
        grid_cobertura_clientes_index.ReadOnly = True
        grid_cobertura_proveedores_estrategicos_index.ReadOnly = True
        grid_volumen_ventas_index.ReadOnly = True
        grid_productos_rentables_index.ReadOnly = True

        grid_resumen_variables_index.AllowUserToAddRows = False
        grid_resumen_variables2_index.AllowUserToAddRows = False
        grid_valor_bono_index.AllowUserToAddRows = False
        grid_efectividad_index.AllowUserToAddRows = False
        grid_cobertura_clientes_index.AllowUserToAddRows = False
        grid_cobertura_proveedores_estrategicos_index.AllowUserToAddRows = False
        grid_volumen_ventas_index.AllowUserToAddRows = False
        grid_productos_rentables_index.AllowUserToAddRows = False

        hoja_supervisor_index.AutoScroll = True
        ancho = hoja_supervisor_index.Width / 2

        label_index.Text = "Resumen Variables Cobertura"
        hoja_supervisor_index.Controls.Add(label_index)

        Dim ubicacion As Integer = label_index.Height
        grid_resumen_variables_index.Width = ancho
        grid_resumen_variables_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_resumen_variables_index)
        grid_resumen_variables_index.Location = New Point(1, ubicacion)
        ubicacion += grid_resumen_variables_index.Height + 1

        label2_index.Text = "Resumen Variables Volumen"
        label2_index.Location = New Point(1, ubicacion)
        hoja_supervisor_index.Controls.Add(label2_index)
        ubicacion += label2_index.Height

        grid_resumen_variables2_index.Width = ancho
        grid_resumen_variables2_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_resumen_variables2_index)
        grid_resumen_variables2_index.Location = New Point(1, ubicacion)

        ubicacion += grid_resumen_variables2_index.Height
        label3_index.Text = "Bono"
        label3_index.Width = 250
        hoja_supervisor_index.Controls.Add(label3_index)
        label3_index.Location = New Point(1, ubicacion)
        ubicacion += label3_index.Height

        grid_valor_bono_index.Width = ancho
        grid_valor_bono_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_valor_bono_index)
        grid_valor_bono_index.Location = New Point(1, ubicacion)
        ubicacion += grid_valor_bono_index.Height

        label6_index.Text = "Cobertura de Productos Estrategicos"
        label6_index.Width = 250
        hoja_supervisor_index.Controls.Add(label6_index)
        label6_index.Location = New Point(1, ubicacion)
        ubicacion += label6_index.Height

        Dim dt_cobertura_proveedores_estrategicos_index As New DataTable
        Dim tcpe As Double = 0, val1 As Double = 0, val2 As Double = 0, val3 As Double = 0

        dt_cobertura_proveedores_estrategicos_index = dt_cobertura_proveedores_estrategicos.Clone
        'Dim distintos As DataTable = dt_cobertura_proveedores_estrategicos.DefaultView.ToTable(True, "Proveedores Estrategicos")

        'Dim resumen_cpe As Double = 0
        'For index As Integer = 0 To distintos.Rows.Count - 1
        '    Dim Meta_cp As Double = 0, Resultado_cp As Double = 0, Peso_cp As Double = 0, Nota_cp As Double = 0, peso_obt_cp As Double = 0
        '    Try
        '        Meta_cp = dt_cobertura_proveedores_estrategicos.Compute("AVG(Meta)", "[Proveedores Estrategicos] = '" + distintos.Rows(index)(0) + "'")
        '        Resultado_cp = dt_cobertura_proveedores_estrategicos.Compute("AVG(Resultado)", "[Proveedores Estrategicos] = '" + distintos.Rows(index)(0) + "'")
        '        Peso_cp = dt_cobertura_proveedores_estrategicos.Compute("AVG(Peso)", "[Proveedores Estrategicos] = '" + distintos.Rows(index)(0) + "'")
        '        Nota_cp = dt_cobertura_proveedores_estrategicos.Compute("AVG(Nota)", "[Proveedores Estrategicos] = '" + distintos.Rows(index)(0) + "'")
        '        peso_obt_cp = dt_cobertura_proveedores_estrategicos.Compute("AVG([Peso Obtenido])", "[Proveedores Estrategicos] = '" + distintos.Rows(index)(0) + "'")
        '        resumen_cpe += peso_obt_cp
        '    Catch ex As Exception
        '    End Try
        '    dt_cobertura_proveedores_estrategicos_index.Rows.Add(distintos.Rows(index)(0), Meta_cp, Resultado_cp, Peso_cp, Nota_cp, peso_obt_cp)
        'Next


        For index1 As Integer = 0 To dt_cobertura_proveedores_estrategicos_index.Rows.Count - 1
            Try
                val1 += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(2)
            Catch ex As Exception
                val1 += 0
            End Try

            Try
                val2 += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(3)
            Catch ex As Exception
                val2 += 0
            End Try

            Try
                val3 += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(4)
            Catch ex As Exception
                val3 += 0
            End Try

            Try
                tcpe += dt_cobertura_proveedores_estrategicos_index.Rows(index1)(5)
            Catch ex As Exception
                tcpe += 0
            End Try
        Next
        Try
            dt_cobertura_proveedores_estrategicos_index.Rows.Add("-TOTAL-", 0, val1, val2, val3, tcpe)
        Catch ex As Exception
        End Try

        grid_cobertura_proveedores_estrategicos_index.Width = ancho
        grid_cobertura_proveedores_estrategicos_index.Anchor = anchor
        grid_cobertura_proveedores_estrategicos_index.DataSource = dt_cobertura_proveedores_estrategicos_index
        hoja_supervisor_index.Controls.Add(grid_cobertura_proveedores_estrategicos_index)
        grid_cobertura_proveedores_estrategicos_index.Location = New Point(1, ubicacion)
        ubicacion += grid_cobertura_proveedores_estrategicos_index.Height

        'CARTERA CREDITO
        label66_index.Text = "Cartera de Credito"
        label66_index.Width = 250
        hoja_supervisor_index.Controls.Add(label66_index)
        label66_index.Location = New Point(1, ubicacion)
        ubicacion += label66_index.Height

        Dim dt_cartera_credito_index As New DataTable
        grid_cartera_credito_index.Width = ancho
        grid_cartera_credito_index.Anchor = anchor
        grid_cartera_credito_index.DataSource = dt_cartera_credito_index
        hoja_supervisor_index.Controls.Add(grid_cartera_credito_index)
        grid_cartera_credito_index.Location = New Point(1, ubicacion)
        'FIN CARTERA CREDITO

        ubicacion = 0
        label7_index.Text = "Efectividad"
        hoja_supervisor_index.Controls.Add(label7_index)
        label7_index.Location = New Point(ancho + 10, ubicacion)
        ubicacion += label7_index.Height

        Dim dt_efectividad_index As New DataTable
        dt_efectividad_index.Columns.Add("UNIVERSO")
        dt_efectividad_index.Columns.Add("EFECTIVOS")
        dt_efectividad_index.Columns.Add("TOTAL")
        Dim efe_nota As Double = 0
        Try
            efe_nota = efe_resultado_total / efe_metal_total * 100
        Catch ex As Exception
            efe_nota = 0
        End Try
        dt_efectividad_index.Rows.Add(efe_metal_total, efe_resultado_total, efe_nota)

        grid_efectividad_index.DataSource = dt_efectividad_index
        grid_efectividad_index.Width = ancho
        grid_efectividad_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_efectividad_index)
        grid_efectividad_index.Location = New Point(ancho + 10, ubicacion)
        ubicacion += grid_efectividad_index.Height

        label8_index.Text = "Cobertura de Clientes"
        label8_index.Width = 250
        hoja_supervisor_index.Controls.Add(label8_index)
        label8_index.Location = New Point(ancho + 10, ubicacion)
        ubicacion += label8_index.Height

        Dim dt_cobertura_clientes_index As New DataTable
        dt_cobertura_clientes_index.Columns.Add("SUPERVISOR")
        dt_cobertura_clientes_index.Columns.Add("META")
        dt_cobertura_clientes_index.Columns.Add("RESULTADO")
        dt_cobertura_clientes_index.Columns.Add("NOTA")
        Dim cob_nota As Double = 0
        Try
            cob_nota = cob_resultado_total / cob_meta_total * 100
        Catch ex As Exception
            cob_nota = 0
        End Try
        dt_cobertura_clientes_index.Rows.Add(hoja_supervisor_index.Text, cob_meta_total, cob_resultado_total, cob_nota)

        grid_cobertura_clientes_index.DataSource = dt_cobertura_clientes_index
        grid_cobertura_clientes_index.Width = ancho
        grid_cobertura_clientes_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_cobertura_clientes_index)
        grid_cobertura_clientes_index.Location = New Point(ancho + 10, ubicacion)

        ubicacion += grid_cobertura_clientes_index.Height

        label9_index.Text = "Volumen de Ventas"
        hoja_supervisor_index.Controls.Add(label9_index)
        label9_index.Location = New Point(ancho + 10, ubicacion)
        ubicacion += label9_index.Height
        Dim dt_volumnen_ventas_index As New DataTable
        dt_volumnen_ventas_index.Columns.Add("Supevisor")
        dt_volumnen_ventas_index.Columns.Add("Meta")
        dt_volumnen_ventas_index.Columns.Add("Venta")
        dt_volumnen_ventas_index.Columns.Add("Resultado")
        Dim resultado_total_volumen_supervisor As Double = 0

        Try
            resultado_total_volumen_supervisor = vol_venta_total / vol_meta_total * 100
        Catch ex As Exception
            resultado_total_volumen_supervisor = 0
        End Try
        dt_volumnen_ventas_index.Rows.Add(hoja_supervisor_index.Text, vol_meta_total, vol_venta_total, resultado_total_volumen_supervisor)

        grid_volumen_ventas_index.Width = ancho
        grid_volumen_ventas_index.Anchor = anchor
        grid_volumen_ventas_index.DataSource = dt_volumnen_ventas_index
        hoja_supervisor_index.Controls.Add(grid_volumen_ventas_index)
        grid_volumen_ventas_index.Location = New Point(ancho + 10, ubicacion)

        ubicacion += grid_volumen_ventas_index.Height

        label10_index.Text = "Productos Rentables"
        label10_index.Width = 250
        hoja_supervisor_index.Controls.Add(label10_index)
        label10_index.Location = New Point(ancho + 10, ubicacion)
        ubicacion += label10_index.Height

        grid_productos_rentables_index.Width = ancho
        grid_productos_rentables_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_productos_rentables_index)
        grid_productos_rentables_index.Location = New Point(ancho + 10, ubicacion)

        'Resumen de las Variables'
        Dim tablita1_temporal As New DataTable
        tablita1_temporal.Columns.Add("Variable")
        tablita1_temporal.Columns.Add("Peso")
        tablita1_temporal.Columns.Add("Resultado")
        tablita1_temporal.Columns.Add("Meta")
        tablita1_temporal.Columns.Add("Medicion")
        tablita1_temporal.Columns.Add("Flag")

        Dim flag As Integer = 0
        Dim PESO As Double = 0, META As Double = 0, MEDICION As Double = 0, resultado_total As Double = 0, RESULTADO As Double = 0
        Dim total_peso As Double = 0, resultado_cobertura As Double = 0, resultado_coberturas As Double = 0
        Dim resultado_cartera As Double = 0, ventas_totales As Double = 0

        If tcpe_divisor > 0 Then
            'PESO = tcpe_peso_supervisor / tcpe_divisor

            'RESULTADO = resumen_cpe

            'META = tcpe_meta_supervisor / tcpe_divisor
            'MEDICION = tcpe_medicion_supervisor / tcpe_divisor
        Else
            PESO = 0
            RESULTADO = 0
            META = 0
            MEDICION = 0
        End If

        flag = 0
        If RESULTADO >= MEDICION Then
            flag = 1
        End If

        If RESULTADO > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(RESULTADO * PESO / 100, 2)
        End If

        tablita1_temporal.Rows.Add("Cobertura de Proveedores Estrategicos", PESO, RESULTADO, META, MEDICION, flag)
        total_peso += PESO
        If flag = 1 Then
            resultado_total += RESULTADO
        Else
            resultado_total += 0
        End If

        PESO = 0
        META = 0
        MEDICION = 0
        flag = 0

        If efe_divisor_supervisor > 0 Then
            PESO = efe_peso_supervisor / efe_divisor_supervisor
            RESULTADO = efe_nota
            META = efe_meta_supervisor / efe_divisor_supervisor
            MEDICION = efe_medicion_supervisor / efe_divisor_supervisor
        Else
            PESO = 0
            RESULTADO = 0
            META = 0
            MEDICION = 0
        End If

        If RESULTADO >= MEDICION Then
            flag = 1
        End If

        If RESULTADO > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(RESULTADO * PESO / 100, 2)
        End If
        tablita1_temporal.Rows.Add("Efectividad", PESO, RESULTADO, META, MEDICION, flag)
        total_peso += PESO

        PESO = 0
        META = 0
        MEDICION = 0
        flag = 0

        If cob_divisor_supervisor > 0 Then
            PESO = cob_peso_supervisor / cob_divisor_supervisor
            RESULTADO = cob_nota
            META = cob_meta_supervisor / cob_divisor_supervisor
            MEDICION = cob_medicion_supervisor / cob_divisor_supervisor
        Else
            PESO = 0
            RESULTADO = 0
            META = 0
            MEDICION = 0
        End If

        If RESULTADO >= MEDICION Then
            flag = 1
        End If

        If RESULTADO > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(RESULTADO * PESO / 100, 2)
        End If

        tablita1_temporal.Rows.Add("Cobertura de Clientes", PESO, RESULTADO, META, MEDICION, flag)
        total_peso += PESO
        If flag = 1 Then
            resultado_total += RESULTADO
        Else
            resultado_total += 0
        End If

        tablita1_temporal.Rows.Add("Total", total_peso, resultado_total, 0, 0, 0)
        resultado_coberturas = resultado_total
        grid_resumen_variables_index.DataSource = tablita1_temporal
        total_peso = 0
        resultado_total = 0

        'variables de volumen
        Dim tablita1_temporal2 As New DataTable
        tablita1_temporal2.Columns.Add("Variable")
        tablita1_temporal2.Columns.Add("Peso")
        tablita1_temporal2.Columns.Add("Resultado")
        tablita1_temporal2.Columns.Add("Meta")
        tablita1_temporal2.Columns.Add("Medicion")
        tablita1_temporal2.Columns.Add("Flag")

        PESO = 0
        META = 0
        MEDICION = 0

        If vol_divisor_supervisor > 0 Then
            If (vol_divisor_supervisor - vol_divisor_supervisor_may) > 0 Then
                PESO = vol_peso_supervisor / (vol_divisor_supervisor - vol_divisor_supervisor_may)
                MEDICION = vol_medicion_supervisor / (vol_divisor_supervisor - vol_divisor_supervisor_may)
            Else
                PESO = vol_peso_supervisor
                MEDICION = vol_medicion_supervisor
            End If

            RESULTADO = resultado_total_volumen_supervisor
            META = vol_meta_supervisor / vol_divisor_supervisor
        Else
            PESO = 0
            RESULTADO = 0
            META = 0
            MEDICION = 0
        End If

        If RESULTADO > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(RESULTADO * PESO / 100, 2)
        End If

        flag = 0
        If RESULTADO >= MEDICION Then
            flag = 1
        End If

        tablita1_temporal2.Rows.Add("Volumen de Ventas", PESO, RESULTADO, META, MEDICION, flag)
        total_peso += PESO

        If flag = 1 Then
            resultado_total += RESULTADO
        Else
            resultado_total += 0
        End If

        'CARTERA DE CLIENTES'

        PESO = 0
        META = 0
        MEDICION = 0
        flag = 0
        Dim cartera_clientes As Double = 0
        If cartera_clientes >= MEDICION Then
            flag = 1
        End If

        If cartera_clientes > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(cartera_clientes * PESO / 100, 2)
        End If

        tablita1_temporal2.Rows.Add("Cartera Clientes", PESO, RESULTADO, META, MEDICION, flag)
        total_peso += PESO
        If flag = 1 Then
            resultado_total += RESULTADO
            resultado_cartera = RESULTADO
        Else
            resultado_total += 0
        End If

        'FIN CARTERA DE CLIENTES'
        Dim productos_rentables As Double = 0
        PESO = 0
        META = 0
        MEDICION = 0

        flag = 0
        If productos_rentables >= MEDICION Then
            flag = 1
        End If

        If productos_rentables > 100 Then
            RESULTADO = PESO
        Else
            RESULTADO = Math.Round(productos_rentables * PESO / 100, 2)
        End If

        tablita1_temporal2.Rows.Add("Productos Rentables", PESO, RESULTADO, META, MEDICION, flag)
        If flag = 1 Then
            resultado_total += RESULTADO
        Else
            resultado_total += 0
        End If
        total_peso += PESO

        tablita1_temporal2.Rows.Add("Total", total_peso, resultado_total, 0, 0, 0)
        grid_resumen_variables2_index.DataSource = tablita1_temporal2
        Dim resultado_volumen As Double = 0
        resultado_volumen = resultado_total
        'fin resumen de las variables

        'resumen del bono
        grid_valor_bono_index.Columns.Add("Descripcion", "Descripcion")
        grid_valor_bono_index.Columns.Add("Valor", "Valor")

        Dim val_bono_cob As Double = 0
        If resultado_coberturas >= 96.25 Then
            val_bono_cob = 1500
        ElseIf resultado_coberturas >= 92.51 Then
            val_bono_cob = 1200
        ElseIf resultado_coberturas >= 90 Then
            val_bono_cob = 900
        Else
            val_bono_cob = 0
        End If
        grid_valor_bono_index.Rows.Add("Valor del Bono Coberturas", val_bono_cob)

        Dim val_bono_cartera As Double = 0
        If Tipo = "Supervisor" Then
            If resultado_cartera >= 100 Then
                val_bono_cartera = 1500
            ElseIf resultado_cartera >= 98 Then
                val_bono_cartera = 1200
            ElseIf resultado_cartera >= 95 Then
                val_bono_cartera = 900
            Else
                val_bono_cartera = 0
            End If
            grid_valor_bono_index.Rows.Add("Valor del Bono Cartera Clientes", val_bono_cartera)
        Else
            val_bono_cartera = 1
        End If

        Dim val_bono_ratio As Double = 0
        If Tipo = "Jefe" Then
            If resultado_cartera >= 100 Then
                val_bono_ratio = 1500
            ElseIf resultado_cartera >= 98 Then
                val_bono_ratio = 1200
            ElseIf resultado_cartera >= 95 Then
                val_bono_ratio = 900
            Else
                val_bono_ratio = 0
            End If
            val_bono_ratio = 1500
            grid_valor_bono_index.Rows.Add("Valor del Bono Ratio y Margen", val_bono_cartera)
        Else
            val_bono_ratio = 1
        End If


        Dim val_bono_vol As Double = 0
        If resultado_volumen >= 100 Then
            val_bono_vol = 1500
        ElseIf resultado_volumen >= 98 Then
            val_bono_vol = 1200
        ElseIf resultado_volumen >= 95 Then
            val_bono_vol = 900
        Else
            val_bono_vol = 0
        End If
        grid_valor_bono_index.Rows.Add("Valor del Bono Volumen", val_bono_vol)

        Dim bono_extra As Double = 0
        If val_bono_cartera > 0 And val_bono_cob > 0 And val_bono_vol > 0 Then
            If ventas_totales >= 110 Then
                bono_extra = 3000
            ElseIf ventas_totales >= 105 Then
                bono_extra = 1500
            Else
                bono_extra = 0
            End If
        End If
        grid_valor_bono_index.Rows.Add("Bono Extra", bono_extra)

        grid_resumen_variables_index.Name = "ResumenVariables1" & nombre_supervisor
        grid_resumen_variables2_index.Name = "ResumenVariables2" & nombre_supervisor
        grid_valor_bono_index.Name = "ValorBono" & nombre_supervisor
        grid_cobertura_proveedores_estrategicos_index.Name = "CoberturaProveedores" & nombre_supervisor
        grid_cartera_credito_index.Name = "CarteraCredito" & nombre_supervisor
        grid_efectividad_index.Name = "Efectividad" & nombre_supervisor
        grid_cobertura_clientes_index.Name = "CoberturaClientes" & nombre_supervisor
        grid_volumen_ventas_index.Name = "VolumenVentas" & nombre_supervisor
        grid_productos_rentables_index.Name = "ProductosRentables" & nombre_supervisor
    End Sub

    Sub cargar_supervisores_agro(ByVal codigo_supervisor As String, ByVal nombre_supervisor As String, ByVal hoja_supervisor_index As TabPage, ByVal Tipo As String)
        Dim ancho As Double
        Dim anchor As AnchorStyles
        anchor = AnchorStyles.Right Or AnchorStyles.Left Or AnchorStyles.Top

        Dim label_index = New Label, label2_index = New Label, label3_index = New Label, label4_index = New Label
        Dim label5_index = New Label, label6_index = New Label, label7_index = New Label, label8_index = New Label
        Dim label9_index = New Label, label10_index = New Label, label66_index = New Label

        Dim grid_vencimientos As New DataGridView
        Dim grid_volumen_ventas_index As New DataGridView
        Dim grid_resumen As New DataGridView
        Dim grid_valor_bono_index As New DataGridView

        grid_vencimientos.ReadOnly = True
        grid_volumen_ventas_index.ReadOnly = True
        grid_resumen.ReadOnly = True
        grid_valor_bono_index.ReadOnly = True
         
        grid_vencimientos.AllowUserToAddRows = False
        grid_volumen_ventas_index.AllowUserToAddRows = False
        grid_resumen.AllowUserToAddRows = False
        grid_valor_bono_index.AllowUserToAddRows = False
         
        hoja_supervisor_index.AutoScroll = True
        ancho = hoja_supervisor_index.Width / 2

        label_index.Text = "Vencimientos"
        hoja_supervisor_index.Controls.Add(label_index)

        Dim ubicacion As Integer = label_index.Height
        grid_vencimientos.Width = ancho
        grid_vencimientos.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_vencimientos)
        grid_vencimientos.Location = New Point(1, ubicacion)
        ubicacion += grid_vencimientos.Height + 3

        label2_index.Text = "Volumen"
        label2_index.Location = New Point(1, ubicacion)
        hoja_supervisor_index.Controls.Add(label2_index)
        ubicacion += label2_index.Height + 3

        grid_volumen_ventas_index.Width = ancho
        grid_volumen_ventas_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_volumen_ventas_index)
        grid_volumen_ventas_index.Location = New Point(1, ubicacion)
        ubicacion += grid_vencimientos.Height + 3
         
        label4_index.Text = "Bono"
        label4_index.Width = 250
        hoja_supervisor_index.Controls.Add(label4_index)
        label4_index.Location = New Point(1, ubicacion)
        ubicacion += label4_index.Height + 3

        grid_valor_bono_index.Width = ancho
        grid_valor_bono_index.Anchor = anchor
        hoja_supervisor_index.Controls.Add(grid_valor_bono_index)
        grid_valor_bono_index.Location = New Point(1, ubicacion)
        ubicacion += grid_valor_bono_index.Height + 3

        grid_vencimientos.Columns.Add("META", "META")
        grid_vencimientos.Columns.Add("RESULTADO", "RESULTADO")
        grid_vencimientos.Columns.Add("PORCENTAJE", "PORCENTAJE")

        Dim dtMetaVolumen As New DataTable
        Dim db As New ClsMatinalAgro
        dtMetaVolumen = db.CargaMetaVolumen(Cmb_Fecha_Final.Value.Month, Cmb_Fecha_Final.Value.Year, codigo_supervisor)
        Dim METAV As Decimal = dtMetaVolumen(0)(0)
        Dim dtVolumen As New DataTable
        dtVolumen = db.LlenaInfo_QQ_TM(Cmb_Fecha_Inicial.Value, Cmb_Fecha_Final.Value, codigo_supervisor, "VOLUMEN", "VOLUMEN")
        Dim VOLUMEN As Decimal = dtVolumen(0)(7)

        Dim ColMetav As New DataGridViewTextBoxColumn
        ColMetav.HeaderText = "META"
        Dim ColResultadov As New DataGridViewTextBoxColumn
        ColResultadov.HeaderText = "RESULTADO"
        Dim ColPORCENTAJEv As New DataGridViewTextBoxColumn
        ColPORCENTAJEv.HeaderText = "PORCENTAJE"

        grid_volumen_ventas_index.Columns.Add(ColMetav)
        grid_volumen_ventas_index.Columns.Add(ColResultadov)
        grid_volumen_ventas_index.Columns.Add(ColPORCENTAJEv)

        Dim NOTAVOLUMEN As Decimal = Math.Round(VOLUMEN / METAV * 100, 2)
        grid_volumen_ventas_index.Rows.Add(METAV.ToString("N2"), VOLUMEN.ToString("N2"), NOTAVOLUMEN)
        Dim ValorBono As Decimal

        If NOTAVOLUMEN >= 100 Then
            ValorBono = 1500
        ElseIf NOTAVOLUMEN >= 98 Then
            ValorBono = 1200
        ElseIf NOTAVOLUMEN >= 95 Then
            ValorBono = 900
        Else
            ValorBono = 0
        End If
        grid_valor_bono_index.Columns.Add("Descripcion", "Descripcion")
        grid_valor_bono_index.Columns.Add("Valor", "Valor")

        grid_valor_bono_index.Rows.Add("Vencimientos", 1500)
        grid_valor_bono_index.Rows.Add("Volumen", ValorBono)
    End Sub

End Class