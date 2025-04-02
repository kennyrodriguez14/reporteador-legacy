Imports Disar.data

Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class frmLiquidacion

    Dim Actual As String
    Dim almacen As Integer
    Dim Entregador As Integer
    Public NumeroLiquidacion As Integer
    Dim Ultima As Integer
    Dim direccion_archivo = ""
    Dim Clase As New cls_reporte_carga 'clsRptCarga

    Dim TotalDineroMDevGeneral As Decimal
    Dim dinerobodegaGeneral As Decimal
    Dim dinerocontadoGeneral As Decimal
    Dim dinerocreditoGeneral As Decimal
    Dim devoGeneral As Decimal

    Dim TotalDineroMDev As Decimal
    Dim NotasCredito As Decimal

    Dim suc As Integer

    Private Sub frmLiquidacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _Inicio.SANRAFAEL = 1 Then
            ComboEmpresa.Items.Add("SAN RAFAEL")
        End If
        If _Inicio.DIMOSA = 1 Then
            ComboEmpresa.Items.Add("DIMOSA")
        End If
        If _Inicio.AGRO = 1 Then
            ComboEmpresa.Items.Add("SR AGRO")
        End If
        If _Inicio.OPL = 1 Then
            ComboEmpresa.Items.Add("OPL")
        End If
        ComboEmpresa.SelectedIndex = 0
        ComboTipo.SelectedItem = "Contado"
        ComboEmpresa.SelectedIndex = 0
        DateTimePicker1.Value = DateAdd(DateInterval.Day, -1, Today.Date)
        DateTimePicker2.Value = DateAdd(DateInterval.Day, -1, Today.Date)
        Try
            suc = _Inicio.Almacen
        Catch ex As Exception
        End Try
        Carga()
        Dim db As New ClsEfectividad
        Try
            ComboEntregador.DataSource = db.Entregadores(suc, "SAN RAFAEL")
            ComboEntregador.ValueMember = "EntregadorCodigo"
            ComboEntregador.DisplayMember = "EntregadorNombre"
        Catch ex As Exception
        End Try
        Dim UsuarioNombre As String = ""
        Dim dt As New DataTable

        dt = db.NombreUsuario(_Inicio.lblUsuario.Text)

        Try
            UsuarioNombre = dt(0)(0).ToString.ToUpper
            'ComboEntregador.Text = ""
            'ComboEntregador.SelectedIndex = ComboEntregador.FindString(UsuarioNombre)

            'MsgBox(UsuarioNombre & " " & ComboEntregador.SelectedValue)

            If _Inicio.NumEntregador <> 0 Then
                ComboEntregador.SelectedValue = _Inicio.NumEntregador
                ComboEntregador.Enabled = False
                GroupBox6.BringToFront()
                'DateTimePicker1.Visible = False
            Else
                ComboEntregador.Enabled = True
                GroupBox6.SendToBack()
                'DateTimePicker1.Visible = True
            End If
        Catch ex As Exception
        End Try

        Try
            TextFecha.Text = db.FechaHora()(0)(0)
            TextHora.Text = db.FechaHora()(0)(1)
        Catch ex As Exception
        End Try

    End Sub

    Sub Carga()

        Try
            DateTimePicker1.Value = DateAdd(DateInterval.Day, -1, Today.Date)
            DateTimePicker2.Value = DateAdd(DateInterval.Day, -1, Today.Date)
            If (DateTimePicker1.Value.DayOfWeek) = DayOfWeek.Sunday Then
                DateTimePicker1.Value = DateAdd(DateInterval.Day, -1, DateTimePicker1.Value)
            End If
            If (DateTimePicker2.Value.DayOfWeek) = DayOfWeek.Sunday Then
                DateTimePicker2.Value = DateAdd(DateInterval.Day, -1, DateTimePicker2.Value)
            End If
        Catch ex As Exception
        End Try

        Arqueo.Rows.Clear()
        Arqueo.Rows.Add("500")
        Arqueo.Rows.Add("100")
        Arqueo.Rows.Add("50")
        Arqueo.Rows.Add("20")
        Arqueo.Rows.Add("10")
        Arqueo.Rows.Add("5")
        Arqueo.Rows.Add("2")
        Arqueo.Rows.Add("1")
        Arqueo.Rows.Add("0.50")
        Arqueo.Rows.Add("0.20")
        Arqueo.Rows.Add("0.10")
        Arqueo.Rows.Add("0.05")

        TextTotalArqueo.Text = "0"
        TextTotalGastos.Text = "0"

        Try
            GastosFijos.Rows.Clear()
        Catch ex As Exception
        End Try
        Try
            GastosVariables.Rows.Clear()
        Catch ex As Exception
        End Try



        GastosFijos.Rows.Add("Gastos de Representación", "", "", "", 1, "")
        GastosFijos.Rows.Add("Transporte Autorizado por Supervisor", "", "", "", 1, "")
        GastosFijos.Rows.Add("Gasto Externo", "", "", "", 1, "")

        GastosVariables.Rows.Add("Alimentación")
        GastosVariables.Rows.Add("SubTotal Hotel")
        GastosVariables.Rows.Add("ISV 15% Hotel")
        GastosVariables.Rows.Add("ISV 4% Hotel")
        GastosVariables.Rows.Add("Impuestos Municipales")
        GastosVariables.Rows.Add("Impuesto de Guerra")
        GastosVariables.Rows.Add("Peaje")
        GastosVariables.Rows.Add("Reparación de llantas")
        GastosVariables.Rows.Add("Reengauche de llantas")
        GastosVariables.Rows.Add("Lubricantes")
        GastosVariables.Rows.Add("Combustible")
        GastosVariables.Rows.Add("Alquiler de Trocos")
        GastosVariables.Rows.Add("Gastos del vehículo")


        GastosFijos.Rows(1).Visible = False
        GastosVariables.Rows(0).Visible = False
        GastosVariables.Rows(8).Visible = False


        For a As Integer = 0 To 11
            GastosVariables.Rows(a).Cells(0).ReadOnly = True
        Next

        Datos.Rows.Clear()

        Datos.Rows.Add("TOTAL CARGA")
        Datos.Rows.Add("Total Devolución")
        Datos.Rows.Add("TOTAL A TRAER")
        Datos.Rows.Add("Gastos c/factura")
        Datos.Rows.Add("N/c")
        Datos.Rows.Add("RETENCION 1%")
        Datos.Rows.Add("SUB TOTAL EFECTIVO")
        Datos.Rows.Add("Total Cheques")
        Datos.Rows.Add("Depósito Occidente")
        Datos.Rows.Add("Los Trabajadores")
        Datos.Rows.Add("Davivienda")
        Datos.Rows.Add("Bac Honduras")
        Datos.Rows.Add("Depósito Atlántida")
        Datos.Rows.Add("Total Efectivo")
        Datos.Rows.Add("DIFERENCIA")

        For Each row As DataGridViewRow In Datos.Rows
            ' Or   row.Cells(0).Value = "N/c"
            If row.Cells(0).Value = "TOTAL A TRAER" Or row.Cells(0).Value = "Gastos c/factura" Or row.Cells(0).Value = "SUB TOTAL EFECTIVO" Or row.Cells(0).Value = "Total Cheques" Or row.Cells(0).Value = "Total Efectivo" Or row.Cells(0).Value = "DIFERENCIA" Or row.Cells(0).Value = "TOTAL CARGA" Or row.Cells(0).Value = "Total Devolución" Then
                row.Cells(1).ReadOnly = True
                row.Cells(2).ReadOnly = True
            Else
                row.Cells(1).ReadOnly = False
                row.Cells(2).ReadOnly = False
            End If
        Next
        For Each column As DataGridViewColumn In Arqueo.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For Each column As DataGridViewColumn In GastosFijos.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For Each column As DataGridViewColumn In GastosVariables.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For Each column As DataGridViewColumn In Rangos.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For Each column As DataGridViewColumn In Datos.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub Arqueo_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Arqueo.CellEndEdit
        If Not IsNumeric(Arqueo.CurrentRow.Cells(e.ColumnIndex).Value) Then
            Arqueo.CurrentRow.Cells(e.ColumnIndex).Value = ""
        End If
        Arqueo.CurrentRow.Cells(2).Value = Val(Arqueo.CurrentRow.Cells(0).Value) * Val(Arqueo.CurrentRow.Cells(1).Value)

        TextTotalArqueo.Text = 0
        For Each row As DataGridViewRow In Arqueo.Rows
            TextTotalArqueo.Text = Val(TextTotalArqueo.Text) + Val(row.Cells(2).Value)
        Next
    End Sub

    Private Sub Edición(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GastosFijos.CellEndEdit, GastosVariables.CellEndEdit
        SumaGastos()
        GastosVariables.Rows(2).Cells(1).Value = GastosVariables.Rows(1).Cells(1).Value
        GastosVariables.Rows(3).Cells(1).Value = GastosVariables.Rows(1).Cells(1).Value
        GastosVariables.Rows(2).Cells(2).Value = GastosVariables.Rows(1).Cells(2).Value
        GastosVariables.Rows(3).Cells(2).Value = GastosVariables.Rows(1).Cells(2).Value
    End Sub

    Private Sub BtnPantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPantalla1.Click
        Dim dt As New DataTable
        dt.Columns.Add("A")
        dt.Columns.Add("B")
        For Each a As DataGridViewRow In Rangos.Rows
            dt.Rows.Add(a.Cells(0).Value, a.Cells(1).Value)
        Next
        Actual = "Guardar"
        If Actual = "Guardar" Then
            Dim db As New ClsEfectividad
            If TextNumeroFact.Text <> "" Then
                Dim s = db.Pantalla1(NumeroLiquidacion, ComboRuta.SelectedValue, DteVenta.Value, DteFacturado.Value, DteCobro.Value, TextNumeroFact.Text, dt, Val(TextVehiculo.Text), Val(TextKilometraje.Text))
                If s = "s" Then
                    TabControl1.SelectedTab = TabPage2
                    Pantalla.Text = "2"
                    If Val(Pantalla.Text) > Ultima Then
                        Actual = "Guardar"
                    End If
                Else
                    MsgBox(s)
                End If
            End If
        End If
    End Sub

    Private Sub BtnPantalla2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPantalla2.Click
        Dim dba As New ClsEfectividad
        Dim aas = dba.VerificaPantalla2(NumeroLiquidacion)
        Actual = "Guardar"
        If Actual = "Guardar" Then
            Dim dt As New DataTable
            Try
                dt.Rows.Clear()
            Catch ex As Exception
            End Try
            dt.Columns.Add("A")
            For Each row As DataGridViewRow In Arqueo.Rows
                dt.Rows.Add(row.Cells(1).Value)
            Next

            Dim s = ""
            If TextNDeposito.Text <> "" Then
                Dim db As New ClsEfectividad
                s = db.Pantalla2(NumeroLiquidacion, dt, Val(TextTotalArqueo.Text), TextNDeposito.Text)
            Else
                If ComboTipo.Text = "Contado" Then
                    MsgBox("Debe ingresar el número de depósito antes de continuar con la liquidación")
                Else
                    s = "s"
                End If
            End If


            If s = "s" Then
                Pantalla.Text = "3"
                TabControl1.SelectedTab = TabPage3
                If Val(Pantalla.Text) > Ultima Then
                    Actual = "Guardar"
                End If
            Else
                If s <> "" Then
                    MsgBox(s)
                End If
            End If
        Else
            TabControl1.SelectedTab = TabPage3
            Actual = "Editar"
        End If


    End Sub

    Private Sub BtnPantalla3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPantalla3.Click
        Dim Validador As Boolean = True
        Dim dba As New ClsEfectividad
        Dim aas = dba.VerificaPantalla3(NumeroLiquidacion)
        Actual = "Guardar"
        If Actual = "Guardar" Then
            Dim dtGastos As New DataTable
            Try
                dtGastos.Rows.Clear()
            Catch ex As Exception
            End Try

            dtGastos.Columns.Add("Numero")
            dtGastos.Columns.Add("NumeroGasto")
            dtGastos.Columns.Add("TipoGasto")
            dtGastos.Columns.Add("NombreGasto")
            dtGastos.Columns.Add("Num_Factura")
            dtGastos.Columns.Add("Negocio")
            dtGastos.Columns.Add("Valor")
            dtGastos.Columns.Add("Cantidad")
            dtGastos.Columns.Add("ValorTotal")
            dtGastos.Columns.Add("ISV15")
            dtGastos.Columns.Add("ISV4")

            For Each row As DataGridViewRow In GastosFijos.Rows
                dtGastos.Rows.Add(NumeroLiquidacion, 0, "Fijo", row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value)
            Next
            For Each row As DataGridViewRow In GastosVariables.Rows
                'If (IsDBNull(row.Cells(0).Value)) And (Not IsDBNull(row.Cells(3).Value)) Then
                '    Validador = False
                'End If
                dtGastos.Rows.Add(NumeroLiquidacion, 0, "Variable", row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, 1, row.Cells(3).Value)
            Next
            Validador = True
            If Validador = True Then
                Dim db As New ClsEfectividad
                Dim s = db.Pantalla3(NumeroLiquidacion, dtGastos, Val(TextGalones.Text), Val(txtKMGastos.Text))
                If s = "s" Then
                    TabControl1.SelectedTab = TabPage4
                    Actual = "Guardar"
                    If Val(Pantalla.Text) > Ultima Then
                        Actual = "Guardar"
                    End If
                Else
                    MsgBox(s)
                End If
            Else
                MsgBox("Algunos gastos están mal registrados. Corrija los nombres de los gastos para continuar.")
            End If

        Else
            TabControl1.SelectedTab = TabPage4
            Actual = "Guardar"
        End If

    End Sub

    Private Sub BtnPantalla4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPantalla4.Click

        If ComboTipo.Text <> "Contado" Then
            If ComboTipo.Text = "Crédito" Then
                Frm_Det_Creditos.GroupBox1.Text = "Detalle de Créditos"
            ElseIf ComboTipo.Text = "Cobro" Then
                Frm_Det_Creditos.GroupBox1.Text = "Detalle de Cobros"
            Else
                Frm_Det_Creditos.GroupBox1.Text = "Detalle"
            End If
            Frm_Det_Creditos.Tipo.Text = ComboTipo.Text
            Frm_Det_Creditos.Entregador.Text = Entregador
            Frm_Det_Creditos.Liquidacion.Text = NumeroLiquidacion
            Frm_Det_Creditos.ShowDialog()
        End If

        Dim dba As New ClsEfectividad
        Dim aas = dba.VerificaPantalla4(NumeroLiquidacion)
        Actual = "Guardar"

        If Actual = "Guardar" Then

            Dim dtCheques As New DataTable
            Try
                dtCheques.Rows.Clear()
            Catch ex As Exception
            End Try

            dtCheques.Columns.Add("Numero")
            dtCheques.Columns.Add("Cheque_Numero")
            dtCheques.Columns.Add("NombreNegocio")
            dtCheques.Columns.Add("Numero_Cheque")
            dtCheques.Columns.Add("Numero_Factura")
            dtCheques.Columns.Add("Valor")
            dtCheques.Columns.Add("Banco")

            For Each row As DataGridViewRow In Cheques.Rows
                dtCheques.Rows.Add(NumeroLiquidacion, 0, row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value)
            Next

            Dim db As New ClsEfectividad
            Dim s = db.Pantalla4(NumeroLiquidacion, dtCheques)

            If s = "s" Then
                Pantalla.Text = "5"
                TabControl1.SelectedTab = TabPage5
                If Val(Pantalla.Text) > Ultima Then
                    Actual = "Guardar"
                End If
            Else
                MsgBox(s)
            End If

        Else
            TabControl1.SelectedTab = TabPage5
            Actual = "Guardar"
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContinuarInicio.Click

        Try
            DteFacturado.Value = DateTimePicker1.Value
            If DteFacturado.Value.DayOfWeek = DayOfWeek.Sunday Then
                DteFacturado.Value = DateAdd(DateInterval.Day, -1, DteFacturado.Value)
            End If

            DteVenta.Value = DateAdd(DateInterval.Day, -1, DteFacturado.Value)
            If DteVenta.Value.DayOfWeek = DayOfWeek.Sunday Then
                DteVenta.Value = DateAdd(DateInterval.Day, -1, DteVenta.Value)
            End If
        Catch ex As Exception
        End Try

        If ComboEntregador.Enabled = False Then
            Actual = "Guardar"
            BtnPantalla1.Visible = True
            BtnPantalla2.Visible = True
            BtnPantalla3.Visible = True
            BtnPantalla4.Visible = True
            BtnGuardar.Visible = True
            BtnVolver2.Visible = True
            BtnVolver3.Visible = True
            BtnVolver4.Visible = True
            BtnVolver5.Visible = True
        Else
            Actual = "Editar"
            BtnPantalla1.Visible = True
            BtnPantalla2.Visible = True
            BtnPantalla3.Visible = True
            BtnPantalla4.Visible = True
            BtnGuardar.Visible = False
            BtnVolver2.Visible = True
            BtnVolver3.Visible = True
            BtnVolver4.Visible = True
            BtnVolver5.Visible = True
        End If

        Dim db As New ClsEfectividad
        Dim Valido As Boolean = True

        Dim Verificar As DataTable
        If DateTimePicker1.Visible = True Then
            TextFecha.Text = DateTimePicker1.Value.Date.ToString
        End If

        If ComboEntregador.Enabled = False Then
            Verificar = db.VerificarLiquidación(ComboEntregador.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value, ComboTipo.Text, "No", ComboEmpresa.Text)
        Else
            Verificar = db.VerificarLiquidación(ComboEntregador.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value, ComboTipo.Text, "Si", ComboEmpresa.Text)
        End If

        Button1.Visible = False
        If Verificar.Rows.Count > 0 And (ComboTipo.Text = "Contado" Or ComboTipo.Text = "Crédito") Then
            Valido = False
            Dim a = MsgBox("Ya se inicio una liquidación para esta fecha:" & vbNewLine & "Número: " & Verificar(0)(0) & vbNewLine & "Estado: " & Verificar(0)(1) & vbNewLine & "Pantallas Completadas: " & Verificar(0)(2) & vbNewLine & "Hora de Inicio: " & Verificar(0)(3) & vbNewLine & vbNewLine & "¿Desea continuar modificando la liquidación?", MsgBoxStyle.YesNo, "Liquidación empezada")
            If a = MsgBoxResult.Yes Then
                Actual = "Editar"
                Valido = True
                Ultima = Verificar(0)(2)
                If Ultima >= 1 Then
                    Try
                        Dim dta As New DataTable
                        dta = db.VerificarRuta(Verificar(0)(0))
                        ComboRuta.SelectedValue = dta(0)(0)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If


        If Valido = True Then
            Try
                Dim dt As New DataTable
                dt = db.Almacen(ComboEntregador.SelectedValue)

                If dt.Rows.Count > 0 Then
                    If dt(0)(0) = "SRC" Then
                        almacen = 2
                    ElseIf dt(0)(0) = "SPS" Then
                        almacen = 1
                    ElseIf dt(0)(0) = "3" Then
                        almacen = 3
                    Else
                        almacen = 4
                    End If
                End If
            Catch ex As Exception
            End Try
            Try
                ComboRuta.DataSource = db.Rutas(almacen)
                ComboRuta.ValueMember = "RutaID"
                ComboRuta.DisplayMember = "Ruta"
            Catch ex As Exception
            End Try
            TextEntregador.Text = ComboEntregador.Text
            Entregador = ComboEntregador.SelectedValue

            Try
                TextFecha.Text = db.FechaHora()(0)(0)
                TextHora.Text = db.FechaHora()(0)(1)
            Catch ex As Exception
            End Try
            If Actual = "Guardar" Then
                Dim s = db.NuevaLiquidacion(Entregador, TextFecha.Text, TextHora.Text, ComboTipo.Text, DateTimePicker1.Value, DateTimePicker2.Value, ComboEmpresa.Text, Hora1.Text, Hora2.Text)
                If IsNumeric(s) Then
                    TabControl1.SelectedTab = TabPage1
                    NumeroLiquidacion = s
                    Pantalla.Text = "1"
                Else
                    MsgBox(s)
                End If
            Else
                If Verificar.Rows.Count > 0 Then
                    Button1.Visible = True
                    If Verificar(0)(2) = 1 Then
                        NumeroLiquidacion = Verificar(0)(0)
                        ComboRuta.SelectedValue = Verificar(0)(5)
                        TextNumeroFact.Text = Verificar(0)(6)
                        Actual = "Guardar"
                        TabControl1.SelectedTab = TabPage2
                    ElseIf Verificar(0)(2) = 2 Then
                        NumeroLiquidacion = Verificar(0)(0)
                        ComboRuta.SelectedValue = Verificar(0)(5)
                        TextNumeroFact.Text = Verificar(0)(6)
                        Actual = "Guardar"
                        CargaArqueo()
                        TabControl1.SelectedTab = TabPage3
                    ElseIf Verificar(0)(2) = 3 Then
                        NumeroLiquidacion = Verificar(0)(0)
                        ComboRuta.SelectedValue = Verificar(0)(5)
                        TextNumeroFact.Text = Verificar(0)(6)
                        Actual = "Guardar"
                        CargaArqueo()
                        CargaGastos()
                        TabControl1.SelectedTab = TabPage4
                    ElseIf Verificar(0)(2) = 4 Then
                        NumeroLiquidacion = Verificar(0)(0)
                        ComboRuta.SelectedValue = Verificar(0)(5)
                        TextNumeroFact.Text = Verificar(0)(6)
                        Actual = "Guardar"
                        CargaArqueo()
                        CargaCheques()
                        CargaGastos()
                        TabControl1.SelectedTab = TabPage4
                        Try
                            PAGINAFINAL(Nothing, Nothing)
                        Catch ex As Exception
                        End Try

                    ElseIf Verificar(0)(2) = 5 Then
                        NumeroLiquidacion = Verificar(0)(0)
                        ComboRuta.SelectedValue = Verificar(0)(5)
                        TextNumeroFact.Text = Verificar(0)(6)
                        Actual = "Editar"
                        CargaArqueo()
                        CargaCheques()
                        CargaGastos()
                        TabControl1.SelectedTab = TabPage4
                        Try
                            PAGINAFINAL(Nothing, Nothing)
                        Catch ex As Exception
                        End Try
                    End If
                    Pantalla.Text = Verificar(0)(2) + 1
                    If Pantalla.Text = "6" Then
                        Pantalla.Text = "Finalizada"
                    End If
                Else
                    MsgBox("No se ha guardado ninguna liquidación para este vendedor esta fecha")
                End If

            End If

            Llena()
            LlenaTotales()
            Try
                dinerobodegaGeneral = 0
                devoGeneral = 0
                TextNumeroFact.Text = ""
                If ComboTipo.Text = "Contado" Then
                    For Each Row As DataGridViewRow In RangosContado.Rows
                        TextNumeroFact.Text = TextNumeroFact.Text & Row.Cells(0).Value & " - " & Row.Cells(1).Value & vbNewLine
                        Rangos.Rows.Add(Row.Cells(0).Value, Row.Cells(1).Value)
                        dinerobodegaGeneral += Row.Cells(2).Value
                        devoGeneral += Row.Cells(3).Value
                    Next
                End If
                If ComboTipo.Text = "Crédito" Then
                    For Each Row As DataGridViewRow In RangosCredito.Rows
                        TextNumeroFact.Text = TextNumeroFact.Text & Row.Cells(0).Value & " - " & Row.Cells(1).Value & vbNewLine
                        Rangos.Rows.Add(Row.Cells(0).Value, Row.Cells(1).Value)
                        dinerobodegaGeneral += Row.Cells(2).Value
                        devoGeneral += Row.Cells(3).Value
                    Next
                End If
            Catch ex As Exception

            End Try


            Try

                Dim dtRuta As New DataTable
                If ComboEmpresa.Text = "SAN RAFAEL" Then
                    dtRuta = db.SeleccionaRuta(Entregador, DateAdd(DateInterval.Day, 0, DateTimePicker1.Value.Date))
                ElseIf ComboEmpresa.Text = "DIMOSA" Then
                    dtRuta = db.SeleccionaRutaDIMOSA(Entregador, DateAdd(DateInterval.Day, 0, DateTimePicker1.Value.Date))
                ElseIf ComboEmpresa.Text = "OPL" Then
                    dtRuta = db.SeleccionaRutaOPL(Entregador, DateAdd(DateInterval.Day, 0, DateTimePicker1.Value.Date))
                End If

                ComboRuta.SelectedIndex = ComboRuta.FindString(dtRuta(0)(0))
                TextVehiculo.Text = dtRuta(0)(1)
            Catch ex As Exception
            End Try


        End If
    End Sub

    Private Sub BtnVolver2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver2.Click
        TabControl1.SelectedTab = TabPage1
        Actual = "Editar"
    End Sub

    Private Sub BtnVolver3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver3.Click
        TabControl1.SelectedTab = TabPage2
        Actual = "Editar"
    End Sub

    Private Sub BtnVolver4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver4.Click
        TabControl1.SelectedTab = TabPage3
        Actual = "Editar"
    End Sub

    Private Sub BtnVolver5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver5.Click
        TabControl1.SelectedTab = TabPage4
        Actual = "Editar"
    End Sub

    Sub CargaArqueo()
        Dim dt As New DataTable
        Dim db As New ClsEfectividad
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        dt = db.CargaArqueo(NumeroLiquidacion)
        Try
            Arqueo.Rows(0).Cells(1).Value = dt(0)(1) '500
            Arqueo.Rows(1).Cells(1).Value = dt(0)(2) '100
            Arqueo.Rows(2).Cells(1).Value = dt(0)(3) '50
            Arqueo.Rows(3).Cells(1).Value = dt(0)(4) '20
            Arqueo.Rows(4).Cells(1).Value = dt(0)(5) '10
            Arqueo.Rows(5).Cells(1).Value = dt(0)(6) '5
            Arqueo.Rows(6).Cells(1).Value = dt(0)(7) '2
            Arqueo.Rows(7).Cells(1).Value = dt(0)(8) '1
            Arqueo.Rows(8).Cells(1).Value = dt(0)(9) '050
            Arqueo.Rows(9).Cells(1).Value = dt(0)(10) '020
            Arqueo.Rows(10).Cells(1).Value = dt(0)(11) '010
            Arqueo.Rows(11).Cells(1).Value = dt(0)(12) '005
            TextNDeposito.Text = dt(0)(13)
            TextDepositoFinal.Text = dt(0)(13) 'DE
        Catch ex As Exception
        End Try

        Try
            TextTotalArqueo.Text = 0
            For Each row As DataGridViewRow In Arqueo.Rows
                row.Cells(2).Value = (Val(row.Cells(0).Value) * Val(row.Cells(1).Value))
                TextTotalArqueo.Text = (Val(TextTotalArqueo.Text) + Val(row.Cells(2).Value))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub CargaCheques()
        Cheques.Rows.Clear()
        Dim dt As New DataTable
        Dim db As New ClsEfectividad
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        dt = db.CargaCheques(NumeroLiquidacion)
        For a As Integer = 0 To dt.Rows.Count - 1
            Cheques.Rows.Add(dt(a)(2), dt(a)(3), dt(a)(4), dt(a)(5), dt(a)(6))
        Next
        Try
            TextTotalCheques.Text = "0"
            For Each row As DataGridViewRow In Cheques.Rows
                TextTotalCheques.Text = (Val(TextTotalCheques.Text) + Val(row.Cells(3).Value))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub CargaGastos()
        GastosFijos.Rows.Clear()
        GastosVariables.Rows.Clear()
        Dim dt As New DataTable
        Dim db As New ClsEfectividad
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        dt = db.CargaGastos(NumeroLiquidacion)
        For a As Integer = 0 To dt.Rows.Count - 1
            If dt(a)(2) = "Fijo" Then
                GastosFijos.Rows.Add(dt(a)(3), dt(a)(4), dt(a)(5), dt(a)(6), dt(a)(7), dt(a)(8))
            Else
                GastosVariables.Rows.Add(dt(a)(3), dt(a)(4), dt(a)(5), dt(a)(8))
            End If
        Next
        TextTotalGastos.Text = 0
        For Each row As DataGridViewRow In GastosFijos.Rows
            Try
                row.Cells(5).Value = Val(row.Cells(3).Value) * (row.Cells(4).Value)
                TextTotalGastos.Text = Val(TextTotalGastos.Text) + Val(row.Cells(5).Value)
            Catch ex As Exception
            End Try
        Next
        For Each row As DataGridViewRow In GastosVariables.Rows
            Try
                TextTotalGastos.Text = Val(TextTotalGastos.Text) + Val(row.Cells(3).Value)
            Catch ex As Exception
            End Try
        Next
        Try
            GastosFijos.Rows(1).Visible = False
            GastosVariables.Rows(0).Visible = False
            GastosVariables.Rows(8).Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Cheques_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Cheques.CellEndEdit

        TextTotalCheques.Text = "0"
        For Each row As DataGridViewRow In Cheques.Rows
            Try
                If Not IsNumeric(row.Cells(3).Value = 0) Then
                    row.Cells(3).Value = 0
                End If
                TextTotalCheques.Text = Val(TextTotalCheques.Text) + Val(row.Cells(3).Value)
            Catch ex As Exception
            End Try
        Next

    End Sub

    Private Sub PAGINAFINAL(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage5.Enter
        Dim dinerobodega As Decimal
        Dim dinerocontado As Decimal
        Dim dinerocredito As Decimal
        Dim devo As Decimal

        Dim TotalDineroMDev As Decimal
        Dim NotasCredito As Decimal
        Dim db As New ClsEfectividad

        Try
            Dim Clase As New cls_reporte_carga
            If ComboEmpresa.Text = "SAN RAFAEL" Then
                grdBodega.DataSource = Clase.RCDumbar(Entregador, DateTimePicker1.Value.Date, "N", "GENERAL", DateTimePicker2.Value.Date)
                grdBodega.Columns(6).Visible = False
                grdContado.DataSource = Clase.RCDumbar(Entregador, DateTimePicker1.Value.Date, "Cont", "FILTRO", DateTimePicker2.Value.Date)
                grdCredito.DataSource = Clase.RCDumbar(Entregador, DateTimePicker1.Value.Date, "Cred", "FILTRO", DateTimePicker2.Value.Date)
            ElseIf ComboEmpresa.Text = "DIMOSA" Then
                grdBodega.DataSource = Clase.RCDumbarDIMOSA(Entregador, DateTimePicker1.Value.Date, "N", "GENERAL", DateTimePicker2.Value.Date)
                grdBodega.Columns(6).Visible = False
                grdContado.DataSource = Clase.RCDumbarAgro(Entregador, DateTimePicker1.Value.Date, "Cont", "FILTRO", DateTimePicker2.Value.Date)
                grdCredito.DataSource = Clase.RCDumbarAgro(Entregador, DateTimePicker1.Value.Date, "Cred", "FILTRO", DateTimePicker2.Value.Date)
            ElseIf ComboEmpresa.Text = "OPL" Then
                grdBodega.DataSource = Clase.RCDumbarOPL(Entregador, DateTimePicker1.Value.Date, "N", "GENERAL", DateTimePicker2.Value.Date)
                grdBodega.Columns(6).Visible = False
                grdContado.DataSource = Clase.RCDumbarOPL(Entregador, DateTimePicker1.Value.Date, "Cont", "FILTRO", DateTimePicker2.Value.Date)
                grdCredito.DataSource = Clase.RCDumbarOPL(Entregador, DateTimePicker1.Value.Date, "Cred", "FILTRO", DateTimePicker2.Value.Date)
            Else
                grdBodega.DataSource = Clase.RCDumbarAgro(Entregador, DateTimePicker1.Value.Date, "N", "GENERAL", DateTimePicker2.Value.Date)
                grdBodega.Columns(6).Visible = False
                grdContado.DataSource = Clase.RCDumbarAgro(Entregador, DateTimePicker1.Value.Date, "Cont", "FILTRO", DateTimePicker2.Value.Date)
                grdCredito.DataSource = Clase.RCDumbarAgro(Entregador, DateTimePicker1.Value.Date, "Cred", "FILTRO", DateTimePicker2.Value.Date)
            End If

            Dim Uni, pes, dine As Double
            For i As Integer = 0 To grdBodega.RowCount - 1
                'Uni += grdBodega.Rows(i).Cells(2).Value
                Uni += grdBodega.Rows(i).Cells.Item("CANT").Value

                'dine += grdBodega.Rows(i).Cells.Item("TOTAL").Value
                'dine += grdBodega.Rows(i).Cells(4).Value
                'pes += grdBodega.Rows(i).Cells(6).Value
                pes += grdBodega.Rows(i).Cells.Item("PESO").Value
            Next

            dinerobodega = Math.Round(dine, 2)

            dine = 0
            Uni = 0
            pes = 0
            For i As Integer = 0 To grdContado.RowCount - 1
                'Uni += grdContado.Rows(i).Cells(2).Value
                Uni += grdContado.Rows(i).Cells.Item("CANT").Value

                'dine += grdContado.Rows(i).Cells(3).Value
                dine += grdContado.Rows(i).Cells.Item("TOTAL").Value

                'pes += grdContado.Rows(i).Cells(4).Value
                pes += grdContado.Rows(i).Cells.Item("PESO").Value
            Next
            dinerocontado = Math.Round(dine, 2)
            pesocontado.Text = FormatNumber(pes, 2)
            unidadescontado.Text = FormatNumber(Uni, 2)

            dine = 0
            Uni = 0
            pes = 0

            For i As Integer = 0 To grdCredito.RowCount - 1
                'Uni += grdCredito.Rows(i).Cells(2).Value
                Uni += grdCredito.Rows(i).Cells.Item("CANT").Value

                'dine += grdCredito.Rows(i).Cells(3).Value
                dine += grdCredito.Rows(i).Cells.Item("TOTAL").Value

                'pes += grdCredito.Rows(i).Cells(4).Value
                pes += grdCredito.Rows(i).Cells.Item("PESO").Value
            Next
            dinerocredito = Math.Round(dine, 2)
            pesocredito.Text = FormatNumber(pes, 2)
            unidadescredito.Text = FormatNumber(Uni, 2)
            dine = 0
            Uni = 0
            pes = 0

            Dim dta As New DataTable
            dta.Rows.Clear()

            Dim Dev As Decimal = 0

            If ComboTipo.Text = "Contado" Then
                If ComboEmpresa.Text = "SAN RAFAEL" Then
                    For x As Integer = 0 To Rangos.RowCount - 1
                        If Rangos.Rows(x).Cells(1).Value <> "" Then
                            dta = Clase.CargarDevolucionesSRF(Entregador, DateTimePicker1.Value.Date, "A", "DEV_CONT", DateTimePicker2.Value.Date, Rangos.Rows(x).Cells(0).Value, Rangos.Rows(x).Cells(1).Value)
                            Try
                                Dev += dta(0)(0)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                ElseIf ComboEmpresa.Text = "DIMOSA" Then

                    For x As Integer = 0 To Rangos.RowCount - 1
                        If Rangos.Rows(x).Cells(1).Value <> "" Then
                            dta = Clase.CargarDevolucionesDIM(Entregador, DateTimePicker1.Value.Date, "A", "DEV_CONT", DateTimePicker2.Value.Date, Rangos.Rows(x).Cells(0).Value, Rangos.Rows(x).Cells(1).Value)
                            Try
                                Dev += dta(0)(0)
                            Catch ex As Exception
                            End Try
                        End If
                    Next

                ElseIf ComboEmpresa.Text = "OPL" Then

                    For x As Integer = 0 To Rangos.RowCount - 1
                        If Rangos.Rows(x).Cells(1).Value <> "" Then
                            dta = Clase.CargarDevolucionesOPL(Entregador, DateTimePicker1.Value.Date, "A", "DEV_CONT", DateTimePicker2.Value.Date, Rangos.Rows(x).Cells(0).Value, Rangos.Rows(x).Cells(1).Value)
                            Try
                                Dev += dta(0)(0)
                            Catch ex As Exception
                            End Try
                        End If
                    Next


                Else
                    For x As Integer = 0 To Rangos.RowCount - 1
                        If Rangos.Rows(x).Cells(1).Value <> "" Then
                            dta = Clase.CargarDevolucionesSRA(Entregador, DateTimePicker1.Value.Date, "A", "DEV_CONT", DateTimePicker2.Value.Date, Rangos.Rows(x).Cells(0).Value, Rangos.Rows(x).Cells(1).Value)
                            Try
                                Dev += dta(0)(0)
                            Catch ex As Exception
                            End Try
                        End If
                    Next

                End If
            End If
            If ComboTipo.Text = "Crédito" Then
                If ComboEmpresa.Text = "SAN RAFAEL" Then
                    For x As Integer = 0 To Rangos.RowCount - 1
                        If Rangos.Rows(x).Cells(1).Value <> "" Then
                            dta = Clase.CargarDevolucionesSRF(Entregador, DateTimePicker1.Value.Date, "A", "DEV_CRED", DateTimePicker2.Value.Date, Rangos.Rows(x).Cells(0).Value, Rangos.Rows(x).Cells(1).Value)
                            Try
                                Dev += dta(0)(0)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                ElseIf ComboEmpresa.Text = "DIMOSA" Then
                    For x As Integer = 0 To Rangos.RowCount - 1
                        If Rangos.Rows(x).Cells(1).Value <> "" Then
                            dta = Clase.CargarDevolucionesDIM(Entregador, DateTimePicker1.Value.Date, "A", "DEV_CRED", DateTimePicker2.Value.Date, Rangos.Rows(x).Cells(0).Value, Rangos.Rows(x).Cells(1).Value)
                            Try
                                Dev += dta(0)(0)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                ElseIf ComboEmpresa.Text = "OPL" Then
                    For x As Integer = 0 To Rangos.RowCount - 1
                        If Rangos.Rows(x).Cells(1).Value <> "" Then
                            dta = Clase.CargarDevolucionesOPL(Entregador, DateTimePicker1.Value.Date, "A", "DEV_CRED", DateTimePicker2.Value.Date, Rangos.Rows(x).Cells(0).Value, Rangos.Rows(x).Cells(1).Value)
                            Try
                                Dev += dta(0)(0)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                Else
                    For x As Integer = 0 To Rangos.RowCount - 1
                        If Rangos.Rows(x).Cells(1).Value <> "" Then
                            dta = Clase.CargarDevolucionesSRA(Entregador, DateTimePicker1.Value.Date, "A", "DEV_CRED", DateTimePicker2.Value.Date, Rangos.Rows(x).Cells(0).Value, Rangos.Rows(x).Cells(1).Value)
                            Try
                                Dev += dta(0)(0)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                End If
            End If


            Try
                Dim dt As New DataTable
                If ComboEmpresa.Text = "SAN RAFAEL" Then
                    dt = db.NotasCredito(Entregador, DateTimePicker1.Value.Date, ComboTipo.Text, DateTimePicker2.Value.Date)
                ElseIf ComboEmpresa.Text = "SR AGRO" Then
                    dt = db.NotasCreditoAgro(Entregador, DateTimePicker1.Value.Date, ComboTipo.Text, DateTimePicker2.Value.Date)
                ElseIf ComboEmpresa.Text = "OPL" Then
                    dt = Nothing
                Else
                    dt = db.NotasCreditoDimosa(Entregador, DateTimePicker1.Value.Date, ComboTipo.Text, DateTimePicker2.Value.Date)
                End If
                NotasCredito = dt(0)(0)
                'MsgBox(NotasCredito)
            Catch ex As Exception
            End Try
            NotasCredito = 0

            If ComboTipo.Text = "Contado" Then
                dinerobodega = Val(dinerocontado)
            End If
            If ComboTipo.Text = "Crédito" Then
                dinerobodega = Val(dinerocredito)
            End If


            If Rangos.RowCount > 0 Then
                Dim DineroTotal As Decimal = 0

                For Each Row As DataGridViewRow In Rangos.Rows
                    Dim dtProd As New DataTable

                    If Row.Cells(0).Value <> "" Then

                        If ComboEmpresa.Text = "SAN RAFAEL" Then
                            dtProd = Clase.RCDumbarRangos(Row.Cells(0).Value, Row.Cells(1).Value)
                        ElseIf ComboEmpresa.Text = "DIMOSA" Then
                            dtProd = Clase.RCDumbarRangosDimosa(Row.Cells(0).Value, Row.Cells(1).Value)
                        ElseIf ComboEmpresa.Text = "OPL" Then
                            dtProd = Clase.RCDumbarRangosOPL(Row.Cells(0).Value, Row.Cells(1).Value)
                        Else
                            dtProd = Clase.RCDumbarRangosAgro(Row.Cells(0).Value, Row.Cells(1).Value)
                        End If

                        If dtProd.Rows.Count > 0 Then
                            For a As Integer = 0 To dtProd.Rows.Count - 1
                                DineroTotal += dtProd(a)(3)
                                'MsgBox(DineroTotal)
                            Next
                        End If
                    End If

                Next
                dinerobodegaGeneral = DineroTotal
            End If

            devo = Dev

            TotalDineroMDevGeneral = dinerobodegaGeneral - Dev
            TotalDineroMDev = Val(dinerobodega) - Val(Dev)
            dinerocredito = FormatNumber(Val(dinerocredito), 2)
            dinerocontado = FormatNumber(Val(dinerocontado), 2)

            Datos.Rows(0).Cells(2).Value = FormatNumber(Val(dinerobodegaGeneral), 2)
            Datos.Rows(1).Cells(2).Value = FormatNumber(Val(Dev), 2)
            Datos.Rows(2).Cells(2).Value = FormatNumber(Val(TotalDineroMDevGeneral), 2)
            Datos.Rows(3).Cells(2).Value = FormatNumber(Val(TextTotalGastos.Text), 2)
            Datos.Rows(4).Cells(2).Value = FormatNumber(Val(NotasCredito), 2)
            Datos.Rows(6).Cells(2).Value = TotalDineroMDevGeneral - Val(TextTotalGastos.Text) - Val(NotasCredito)
            Datos.Rows(7).Cells(2).Value = TextTotalCheques.Text
            Try
                DataDetallesCredCob.DataSource = db.CargaDetallesCredito(NumeroLiquidacion)
            Catch ex As Exception
            End Try
            COMPLETA()
        Catch ex As Exception
            MsgBox("Error al Generar Reporte de Carga ")
        End Try

    End Sub

    Private Sub Datos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datos.CellEndEdit
        If Not IsNumeric(Datos.CurrentRow.Cells(2).Value) Then
            Datos.CurrentRow.Cells(2).Value = 0
        End If
        COMPLETA()
    End Sub

    Sub COMPLETA()
        Try
            Dim dbx As New ClsEfectividad
            Dim dtx As New DataTable
            dtx = dbx.ObtieneNC(NumeroLiquidacion)
            If dtx.Rows.Count > 0 Then
                If IsDBNull(Datos.Rows(4).Cells(2).Value) Then
                    Datos.Rows(4).Cells(2).Value = dtx(0)(0)
                Else
                    If Datos.Rows(4).Cells(2).Value = 0 Then
                        Datos.Rows(4).Cells(2).Value = dtx(0)(0)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            Datos.Rows(2).Cells(2).Value = Val(Replace(Datos.Rows(0).Cells(2).Value, ",", "")) - Val(Replace(Datos.Rows(1).Cells(2).Value, ",", ""))
        Catch ex As Exception
        End Try
        Try
            Datos.Rows(6).Cells(2).Value = Val(Replace(Datos.Rows(2).Cells(2).Value, ",", "")) - Val(Replace(Datos.Rows(3).Cells(2).Value, ",", ""))
        Catch ex As Exception
        End Try
        Try
            Datos.Rows(6).Cells(2).Value = Val(Replace(Datos.Rows(6).Cells(2).Value, ",", "")) - Val(Replace(Datos.Rows(4).Cells(2).Value, ",", ""))
        Catch ex As Exception
        End Try
        Try
            Datos.Rows(6).Cells(2).Value = Val(Replace(Datos.Rows(6).Cells(2).Value, ",", "")) - Val(Replace(Datos.Rows(5).Cells(2).Value, ",", ""))
        Catch ex As Exception
        End Try
        Try
            Datos.Rows(13).Cells(2).Value = Datos.Rows(6).Cells(2).Value
        Catch ex As Exception
        End Try
        Try
            Datos.Rows(13).Cells(2).Value = Val(Replace(Datos.Rows(13).Cells(2).Value, ",", "")) - Val(Replace(Datos.Rows(7).Cells(2).Value, ",", ""))
        Catch ex As Exception
        End Try
        Try
            Datos.Rows(13).Cells(2).Value = Val(Replace(Datos.Rows(13).Cells(2).Value, ",", "")) - Val(Replace(Datos.Rows(8).Cells(2).Value, ",", ""))
        Catch ex As Exception
        End Try
        Try
            Datos.Rows(13).Cells(2).Value = Val(Replace(Datos.Rows(13).Cells(2).Value, ",", "")) - Val(Replace(Datos.Rows(9).Cells(2).Value, ",", ""))
        Catch ex As Exception
        End Try
        Try
            Datos.Rows(13).Cells(2).Value = Val(Replace(Datos.Rows(13).Cells(2).Value, ",", "")) - Val(Replace(Datos.Rows(10).Cells(2).Value, ",", ""))
        Catch ex As Exception
        End Try
        Try
            Datos.Rows(13).Cells(2).Value = Val(Replace(Datos.Rows(13).Cells(2).Value, ",", "")) - Val(Replace(Datos.Rows(11).Cells(2).Value, ",", ""))
        Catch ex As Exception
        End Try
        Try
            Datos.Rows(13).Cells(2).Value = Val(Replace(Datos.Rows(13).Cells(2).Value, ",", "")) - Val(Replace(Datos.Rows(12).Cells(2).Value, ",", ""))
        Catch ex As Exception
        End Try


        Try
            Datos.Rows(14).Cells(2).Value = FormatNumber(Datos.Rows(13).Cells(2).Value - Val(TextTotalArqueo.Text), 2)

            If Datos.Rows(14).Cells(2).Value >= 0 Then
                Datos.Rows(14).Cells(1).Value = "FALTANTE"
                Datos.Rows(14).DefaultCellStyle.BackColor = Drawing.Color.DarkRed
                Datos.Rows(14).DefaultCellStyle.ForeColor = Drawing.Color.White
            Else
                Datos.Rows(14).Cells(1).Value = "SOBRANTE"
                Datos.Rows(14).Cells(2).Value = Datos.Rows(14).Cells(2).Value * -1
                Datos.Rows(14).DefaultCellStyle.BackColor = Drawing.Color.DarkGreen
                Datos.Rows(14).DefaultCellStyle.ForeColor = Drawing.Color.White
            End If
            Datos.Rows(14).Cells(2).Value = FormatNumber(Datos.Rows(14).Cells(2).Value, 2)
        Catch ex As Exception
        End Try
        'Try
        '    Datos.Rows(5).Cells(2).Value = FormatNumber(Datos.Rows(5).Cells(2).Value, 2)
        '    Datos.Rows(6).Cells(2).Value = FormatNumber(Datos.Rows(6).Cells(2).Value, 2)
        '    Datos.Rows(7).Cells(2).Value = FormatNumber(Datos.Rows(7).Cells(2).Value, 2)
        '    Datos.Rows(8).Cells(2).Value = FormatNumber(Datos.Rows(8).Cells(2).Value, 2)
        '    Datos.Rows(9).Cells(2).Value = FormatNumber(Datos.Rows(9).Cells(2).Value, 2)
        '    Datos.Rows(10).Cells(2).Value = FormatNumber(Datos.Rows(10).Cells(2).Value, 2)
        '    Datos.Rows(11).Cells(2).Value = FormatNumber(Datos.Rows(11).Cells(2).Value, 2)
        '    Datos.Rows(12).Cells(2).Value = FormatNumber(Datos.Rows(12).Cells(2).Value, 2)
        '    Datos.Rows(13).Cells(2).Value = FormatNumber(Datos.Rows(13).Cells(2).Value, 2)
        'Catch ex As Exception
        'End Try
        Dim TotalCreditos As Decimal = 0
        If DataDetallesCredCob.RowCount > 0 And ComboTipo.Text <> "Contado" Then
            For Each Row As DataGridViewRow In DataDetallesCredCob.Rows
                TotalCreditos += Row.Cells(3).Value
            Next
        End If
        Try
            Datos.Rows(14).Cells(2).Value = FormatNumber(Val(Replace(Datos.Rows(14).Cells(2).Value, ",", "")) - TotalCreditos, 2)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If (Not IsNumeric(TextDepositoFinal.Text)) And ComboTipo.Text = "Contado" Then
            MsgBox("No ha registrador número de depósito. Registre el número de depósito de arqueo para continuar.")
        Else

            Dim xxx = MsgBox("¿Está seguro que ha finalizado la liquidación?", MsgBoxStyle.YesNo)
            If xxx = MsgBoxResult.Yes Then


                Dim dba As New ClsEfectividad
                Dim aas As String = ""
                aas = dba.VerificaPantalla5(NumeroLiquidacion)

                Actual = "Guardar"

                If Datos.Rows(14).Cells(1).Value = "FALTANTE" Then
                Else
                    Datos.Rows(14).Cells(2).Value = FormatNumber(Val(Replace(Datos.Rows(14).Cells(2).Value, ",", "")) * -1, 2)
                End If

                If Actual = "Guardar" Then
                    Dim db As New ClsEfectividad
                    Dim s As String

                    Dim dt As New DataTable
                    Try
                        dt.Rows.Clear()
                        dt.Columns.Clear()
                    Catch ex As Exception
                    End Try

                    dt.Columns.Add("Det")
                    dt.Columns.Add("Doc")
                    dt.Columns.Add("Mon")

                    For Each row As DataGridViewRow In Datos.Rows
                        Dim a As String = "0"
                        Try
                            a = row.Cells(2).Value.ToString.Replace(",", "")
                        Catch ex As Exception
                            a = row.Cells(2).Value
                        End Try
                        dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, a)
                    Next

                    Dim Hora As String = ""
                    Try
                        Hora = db.FechaHora()(0)(1)
                    Catch ex As Exception
                    End Try

                    Try
                        s = db.Pantalla5(NumeroLiquidacion, dt, Hora, TextDepositoFinal.Text)
                        If s = "s" Then
                            MsgBox("Se guardó la liquidación exitosamente")
                            Try
                                TextNumeroFact.Text = ""
                                For Each Row As DataGridViewRow In Rangos.Rows
                                    TextNumeroFact.Text = TextNumeroFact.Text & Row.Cells(0).Value & " - " & Row.Cells(1).Value & vbNewLine
                                Next
                            Catch ex As Exception
                            End Try
                            ImprimirGastos()
                            ImprimirRemision_DISAR()
                            Me.Dispose()
                        Else
                            MsgBox(s)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged, DateTimePicker2.ValueChanged
        TextFecha.Text = DateTimePicker1.Value.Date
    End Sub

    Sub ImprimirRemision_DISAR()
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
        tabla_transportista.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_transportista.WidthPercentage = (400 / 5.23F)
        tabla_transportista.SetWidths(New Integer() {1, 4, 1})

        Dim tabla_grilla As New PdfPTable(4)
        tabla_grilla.DefaultCell.Padding = 3
        tabla_grilla.WidthPercentage = 30
        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla.DefaultCell.BorderWidth = 1
        tabla_grilla.WidthPercentage = (480 / 5.23F)
        tabla_grilla.SetWidths(New Integer() {2, 3, 3, 3})
        tabla_grilla.SpacingBefore = 20

        Dim tabla_transportista2 As New PdfPTable(3)
        tabla_transportista2.DefaultCell.Padding = 3
        tabla_transportista2.DefaultCell.BorderColor = Color.WHITE
        tabla_transportista2.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_transportista2.WidthPercentage = (400 / 5.23F)
        tabla_transportista2.SetWidths(New Integer() {1, 4, 1})
        tabla_transportista2.SpacingBefore = 20

        Dim tabla_grilla2 As New PdfPTable(6)
        tabla_grilla2.DefaultCell.Padding = 3
        tabla_grilla2.WidthPercentage = 30
        tabla_grilla2.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla2.DefaultCell.BorderWidth = 1
        tabla_grilla2.WidthPercentage = (480 / 5.23F)
        tabla_grilla2.SetWidths(New Integer() {2, 2, 2, 2, 2, 1})
        tabla_grilla2.SpacingBefore = 20

        Dim tabla_transportista3 As New PdfPTable(3)
        tabla_transportista3.DefaultCell.Padding = 3
        tabla_transportista3.DefaultCell.BorderColor = Color.WHITE
        tabla_transportista3.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_transportista3.WidthPercentage = (400 / 5.23F)
        tabla_transportista3.SetWidths(New Integer() {1, 4, 1})
        tabla_transportista3.SpacingBefore = 20

        Dim tabla_grilla3 As New PdfPTable(4)
        tabla_grilla3.DefaultCell.Padding = 3
        tabla_grilla3.WidthPercentage = 30
        tabla_grilla3.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla3.DefaultCell.BorderWidth = 1
        tabla_grilla3.WidthPercentage = (480 / 5.23F)
        tabla_grilla3.SetWidths(New Integer() {2, 3, 3, 3})
        tabla_grilla3.SpacingBefore = 20

        Dim tabla_transportista4 As New PdfPTable(3)
        tabla_transportista4.DefaultCell.Padding = 3
        tabla_transportista4.DefaultCell.BorderColor = Color.WHITE
        tabla_transportista4.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_transportista4.WidthPercentage = (400 / 5.23F)
        tabla_transportista4.SetWidths(New Integer() {1, 4, 1})
        tabla_transportista4.SpacingBefore = 20

        Dim tabla_grilla4 As New PdfPTable(5)
        tabla_grilla4.DefaultCell.Padding = 3
        tabla_grilla4.WidthPercentage = 30
        tabla_grilla4.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla4.DefaultCell.BorderWidth = 1
        tabla_grilla4.WidthPercentage = (480 / 5.23F)
        tabla_grilla4.SetWidths(New Integer() {2, 2, 3, 2, 2})
        tabla_grilla4.SpacingBefore = 20

        Dim tabla_motivo As New PdfPTable(5)
        tabla_motivo.DefaultCell.Padding = 3
        tabla_motivo.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_motivo.WidthPercentage = (385 / 5.23F)
        tabla_motivo.SetWidths(New Integer() {1, 4, 1, 1, 2})
        tabla_motivo.SpacingBefore = 20

        Dim tabla_datos_adicionales As New PdfPTable(2)
        tabla_datos_adicionales.DefaultCell.Padding = 3
        tabla_datos_adicionales.DefaultCell.BorderColor = Color.WHITE
        tabla_datos_adicionales.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_datos_adicionales.WidthPercentage = (385 / 5.23F)
        tabla_datos_adicionales.SetWidths(New Integer() {1, 5})
        tabla_datos_adicionales.SpacingBefore = 20

        Dim tabla_fimas As New PdfPTable(2)
        tabla_fimas.DefaultCell.Padding = 3
        tabla_fimas.DefaultCell.BorderColor = Color.WHITE
        tabla_fimas.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_fimas.WidthPercentage = (300 / 5.23F)
        tabla_fimas.SetWidths(New Integer() {1, 1})
        tabla_fimas.SpacingBefore = 120

        'Exporting to PDF
        If direccion_archivo = "" Then
            direccion_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
            'If Not Directory.Exists(direccion_archivo) Then
            '    Directory.CreateDirectory(direccion_archivo)
            'End If
        End If

        Using stream As New FileStream(direccion_archivo & "Liquidacion N " & NumeroLiquidacion & ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory
            logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")
            If ComboEmpresa.Text = "SAN RAFAEL" Then
                logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")
            ElseIf ComboEmpresa.Text = "DIMOSA" Then
                logo = Image.GetInstance(recurso & "\Resources\DIMOSA-26.png")
            ElseIf ComboEmpresa.Text = "OPL" Then
                logo = Image.GetInstance(recurso & "\Resources\OPL.png")
            Else
                logo = Image.GetInstance(recurso & "\Resources\SR AGRO LOGO.jpg")
            End If
            tabla_encabezado.AddCell(logo)
            Dim cell As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL, S.A. DE C.V. " & vbCrLf & _
                            "Formato de Liquidación", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell(New Phrase("Liquidación #: " & _
                            NumeroLiquidacion & vbCrLf & "Tipo: " & ComboTipo.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))

            tabla_sub_encabezado.AddCell(New Phrase("Entregador: " & TextEntregador.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Ruta:     " & ComboRuta.Text & vbCrLf & "Fecha Venta:         " & DteVenta.Value.Date & vbCrLf & _
                                         "Fecha Facturado: " & DteFacturado.Value.Date & vbCrLf & "Fecha Cobro: " & DteCobro.Value & vbCrLf & "Nº Fact: " & vbCrLf & TextNumeroFact.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("", FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell(New Phrase(""))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase(""))

            tabla_transportista.AddCell("")
            tabla_transportista.AddCell(New Phrase("Arqueo de Efectivo", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_transportista.AddCell("")

            Dim cell_sangria_titulo As New PdfPCell(New Phrase(""))
            cell_sangria_titulo.BorderColor = Color.WHITE
            tabla_grilla.AddCell(cell_sangria_titulo)
            For index As Integer = 0 To Arqueo.ColumnCount - 1
                'If grd_detalle.Columns(index).HeaderText <> "CONLOTE" Then
                Dim cell_encabezado As New PdfPCell(New Phrase(Arqueo.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 15, Font.Bold, Color.BLACK)))
                cell_encabezado.BackgroundColor = Color.GRAY
                tabla_grilla.AddCell(cell_encabezado)
                'End If
            Next

            For i As Integer = 0 To Arqueo.RowCount - 1
                Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                cell_sangria_contenido.BorderColor = Color.WHITE
                tabla_grilla.AddCell(cell_sangria_contenido)
                For j As Integer = 0 To Arqueo.ColumnCount - 1
                    'If grd_detalle.Columns(j).HeaderText <> "CONLOTE" Then
                    tabla_grilla.AddCell(New Phrase(Convert.ToString(Arqueo.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 13, Font.Bold, Color.BLACK)))
                    'End If
                Next
            Next
            Dim cell_sangria_contenido2 As New PdfPCell(New Phrase(""))
            cell_sangria_contenido2.BorderColor = Color.WHITE
            tabla_grilla.AddCell(cell_sangria_contenido2)
            tabla_grilla.AddCell("")
            tabla_grilla.AddCell("Total Arqueo")
            tabla_grilla.AddCell(TextTotalArqueo.Text)

            tabla_transportista2.AddCell("")
            tabla_transportista2.AddCell(New Phrase("Cheques", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_transportista2.AddCell("")

            cell_sangria_titulo.BorderColor = Color.WHITE
            tabla_grilla2.AddCell(cell_sangria_titulo)
            For index As Integer = 0 To Cheques.ColumnCount - 1
                'If grd_detalle.Columns(index).HeaderText <> "CONLOTE" Then
                Dim cell_encabezado As New PdfPCell(New Phrase(Cheques.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 15, Font.Bold, Color.BLACK)))
                cell_encabezado.BackgroundColor = Color.GRAY
                tabla_grilla2.AddCell(cell_encabezado)
                'End If
            Next

            For i As Integer = 0 To Cheques.RowCount - 1
                Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                cell_sangria_contenido.BorderColor = Color.WHITE
                tabla_grilla2.AddCell(cell_sangria_contenido)
                For j As Integer = 0 To Cheques.ColumnCount - 1
                    'If grd_detalle.Columns(j).HeaderText <> "CONLOTE" Then
                    tabla_grilla2.AddCell(New Phrase(Convert.ToString(Cheques.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 13, Font.Bold, Color.BLACK)))
                    'End If
                Next
            Next


            tabla_grilla2.AddCell(cell_sangria_contenido2)
            tabla_grilla2.AddCell("")
            tabla_grilla2.AddCell("")
            tabla_grilla2.AddCell("")
            tabla_grilla2.AddCell("Total Cheques")
            tabla_grilla2.AddCell(TextTotalCheques.Text)

            tabla_transportista3.AddCell("")
            tabla_transportista3.AddCell(New Phrase("Resumen", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_transportista3.AddCell("")

            cell_sangria_titulo.BorderColor = Color.WHITE
            tabla_grilla3.AddCell(cell_sangria_titulo)
            For index As Integer = 0 To Datos.ColumnCount - 1
                'If grd_detalle.Columns(index).HeaderText <> "CONLOTE" Then
                Dim cell_encabezado As New PdfPCell(New Phrase(Datos.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 15, Font.Bold, Color.BLACK)))
                cell_encabezado.BackgroundColor = Color.GRAY
                tabla_grilla3.AddCell(cell_encabezado)
                'End If
            Next

            For i As Integer = 0 To Datos.RowCount - 1
                Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                cell_sangria_contenido.BorderColor = Color.WHITE
                tabla_grilla3.AddCell(cell_sangria_contenido)
                For j As Integer = 0 To Datos.ColumnCount - 1
                    'If grd_detalle.Columns(j).HeaderText <> "CONLOTE" Then
                    tabla_grilla3.AddCell(New Phrase(Convert.ToString(Datos.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 13, Font.Bold, Color.BLACK)))
                    'End If
                Next
            Next

            If ComboTipo.Text <> "Contado" Then
                tabla_transportista4.AddCell("")
                tabla_transportista4.AddCell(New Phrase("Resumen de " & ComboTipo.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
                tabla_transportista4.AddCell("")

                cell_sangria_titulo.BorderColor = Color.WHITE
                tabla_grilla4.AddCell(cell_sangria_titulo)

                For index As Integer = 0 To DataDetallesCredCob.ColumnCount - 1
                    'If grd_detalle.Columns(index).HeaderText <> "CONLOTE" Then
                    Dim cell_encabezado As New PdfPCell(New Phrase(DataDetallesCredCob.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 15, Font.Bold, Color.BLACK)))
                    cell_encabezado.BackgroundColor = Color.GRAY
                    tabla_grilla4.AddCell(cell_encabezado)
                    'End If
                Next

                For i As Integer = 0 To DataDetallesCredCob.RowCount - 1
                    Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                    cell_sangria_contenido.BorderColor = Color.WHITE
                    tabla_grilla4.AddCell(cell_sangria_contenido)
                    For j As Integer = 0 To DataDetallesCredCob.ColumnCount - 1
                        'If grd_detalle.Columns(j).HeaderText <> "CONLOTE" Then
                        tabla_grilla4.AddCell(New Phrase(Convert.ToString(DataDetallesCredCob.Rows(i).Cells(j).Value), FontFactory.GetFont("arial", 13, Font.Bold, Color.BLACK)))
                        'End If
                    Next
                Next
            End If


            Dim cell_motivo As New PdfPCell(New Phrase("Motivo: ", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo)

            Dim cell_motivo_des As New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo_des.BackgroundColor = Color.GRAY
            tabla_motivo.AddCell(cell_motivo_des)

            Dim cell_motivo_sangria As New PdfPCell(New Phrase(""))
            cell_motivo_sangria.BorderColor = Color.WHITE
            tabla_motivo.AddCell(cell_motivo_sangria)

            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                              Nombre y firma de Entregador       ")
            tabla_fimas.AddCell("                                 Revisado Liquidaciones        ")
            tabla_fimas.AddCell("                                   ")
            tabla_fimas.AddCell("                                   ")
            tabla_fimas.AddCell("                                   ")
            tabla_fimas.AddCell("                                   ")
            tabla_fimas.AddCell("                                   ")
            tabla_fimas.AddCell("                                   ")


            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                               Aurotizado por Logística       ")
            tabla_fimas.AddCell("                               Revisado por Contabilidad       ")

            pdfDoc.Add(tabla_encabezado)
            pdfDoc.Add(tabla_sub_encabezado)
            pdfDoc.Add(tabla_transportista)
            pdfDoc.Add(tabla_grilla)

            pdfDoc.Add(tabla_transportista2)
            pdfDoc.Add(tabla_grilla2)

            pdfDoc.Add(tabla_transportista3)
            pdfDoc.Add(tabla_grilla3)

            If ComboTipo.Text <> "Contado" Then
                pdfDoc.Add(tabla_transportista4)
                pdfDoc.Add(tabla_grilla4)
            End If

            pdfDoc.Add(tabla_motivo)
            pdfDoc.Add(tabla_fimas)
            'pdfDoc.Add(tabla_datos_adicionales)
            pdfDoc.Close()
            stream.Close()

            Process.Start(direccion_archivo & "Liquidacion N " & NumeroLiquidacion & ".pdf")
        End Using
    End Sub

    Sub ImprimirGastos()
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
        tabla_transportista.SetWidths(New Integer() {1, 10, 1})

        Dim tabla_grilla As New PdfPTable(7)
        tabla_grilla.DefaultCell.Padding = 3
        tabla_grilla.WidthPercentage = 30
        tabla_grilla.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla.DefaultCell.BorderWidth = 1
        tabla_grilla.WidthPercentage = (480 / 5.23F)
        tabla_grilla.SetWidths(New Integer() {3, 5, 4, 3, 3, 3, 3})
        tabla_grilla.SpacingBefore = 20

        Dim tabla_transportista2 As New PdfPTable(3)
        tabla_transportista2.DefaultCell.Padding = 3
        tabla_transportista2.DefaultCell.BorderColor = Color.WHITE
        tabla_transportista2.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_transportista2.WidthPercentage = (400 / 5.23F)
        tabla_transportista2.SetWidths(New Integer() {1, 4, 1})

        Dim tabla_grilla2 As New PdfPTable(5)
        tabla_grilla2.DefaultCell.Padding = 3
        tabla_grilla2.WidthPercentage = 30
        tabla_grilla2.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_grilla2.DefaultCell.BorderWidth = 1
        tabla_grilla2.WidthPercentage = (480 / 5.23F)
        tabla_grilla2.SetWidths(New Integer() {3, 7, 6, 4, 4})
        tabla_grilla2.SpacingBefore = 20

        Dim tabla_motivo As New PdfPTable(3)
        tabla_motivo.DefaultCell.Padding = 3
        tabla_motivo.DefaultCell.BorderColor = Color.WHITE
        tabla_motivo.HorizontalAlignment = Element.ALIGN_LEFT
        tabla_motivo.WidthPercentage = (480 / 5.23F)
        tabla_motivo.SetWidths(New Integer() {1, 1, 1})
        tabla_motivo.SpacingBefore = 20

        Dim tabla_datos_adicionales As New PdfPTable(2)
        tabla_datos_adicionales.DefaultCell.Padding = 3
        tabla_datos_adicionales.DefaultCell.BorderColor = Color.WHITE
        tabla_datos_adicionales.HorizontalAlignment = Element.ALIGN_RIGHT
        tabla_datos_adicionales.WidthPercentage = (385 / 5.23F)
        tabla_datos_adicionales.SetWidths(New Integer() {1, 5})
        tabla_datos_adicionales.SpacingBefore = 20

        Dim tabla_fimas As New PdfPTable(2)
        tabla_fimas.DefaultCell.Padding = 3
        tabla_fimas.DefaultCell.BorderColor = Color.WHITE
        tabla_fimas.HorizontalAlignment = Element.ALIGN_CENTER
        tabla_fimas.WidthPercentage = (300 / 5.23F)
        tabla_fimas.SetWidths(New Integer() {1, 1})
        tabla_fimas.SpacingBefore = 120

        'Exporting to PDF
        If direccion_archivo = "" Then
            direccion_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"
            'If Not Directory.Exists(direccion_archivo) Then
            '    Directory.CreateDirectory(direccion_archivo)
            'End If
        End If

        Using stream As New FileStream(direccion_archivo & "Gastos Liquidacion N " & NumeroLiquidacion & ".pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim logo As Image
            Dim recurso As String = My.Computer.FileSystem.CurrentDirectory
            logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")
            If ComboEmpresa.Text = "SAN RAFAEL" Then
                logo = Image.GetInstance(recurso & "\Resources\DISTRIBUIDORA_SAN_RAFAEL.png")
            ElseIf ComboEmpresa.Text = "DIMOSA" Then
                logo = Image.GetInstance(recurso & "\Resources\DIMOSA-26.png")
            Else
                logo = Image.GetInstance(recurso & "\Resources\SR AGRO LOGO.jpg")
            End If

            tabla_encabezado.AddCell(logo)
            Dim cell As New PdfPCell(New Phrase("DISTRIBUIDORA SAN RAFAEL, S.A. DE C.V. " & vbCrLf & _
                            "Formato de Liquidación", FontFactory.GetFont("arial", 20, Font.Bold, Color.BLACK)))
            cell.BorderColor = Color.WHITE
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla_encabezado.AddCell(cell)
            tabla_encabezado.AddCell(New Phrase("Liquidación #: " & _
                            NumeroLiquidacion & vbCrLf & "Tipo: " & ComboTipo.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))

            tabla_sub_encabezado.AddCell(New Phrase("Entregador: " & TextEntregador.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("Ruta:     " & ComboRuta.Text & vbCrLf & "Fecha Venta:         " & DteVenta.Value.Date & vbCrLf & _
                                         "Fecha Facturado: " & DteFacturado.Value.Date & vbCrLf & "Fecha Cobro: " & DteCobro.Value & vbCrLf & "Nº Fact: " & vbCrLf & TextNumeroFact.Text, FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase("", FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))
            tabla_sub_encabezado.AddCell(New Phrase(""))
            tabla_sub_encabezado.AddCell("")
            tabla_sub_encabezado.AddCell(New Phrase(""))

            tabla_transportista.AddCell("")
            tabla_transportista.AddCell("")
            tabla_transportista.AddCell("")
            tabla_transportista.AddCell("")
            tabla_transportista.AddCell(New Phrase("Formato de Registro de Gastos", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_transportista.AddCell("")
            tabla_transportista.AddCell("")
            tabla_transportista.AddCell("")
            tabla_transportista.AddCell("")

            Dim cell_sangria_titulo As New PdfPCell(New Phrase(""))
            cell_sangria_titulo.BorderColor = Color.WHITE
            tabla_grilla.AddCell(cell_sangria_titulo)
            For index As Integer = 0 To GastosFijos.ColumnCount - 1
                'If grd_detalle.Columns(index).HeaderText <> "CONLOTE" Then
                Dim cell_encabezado As New PdfPCell(New Phrase(GastosFijos.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))
                cell_encabezado.BackgroundColor = Color.GRAY
                tabla_grilla.AddCell(cell_encabezado)
                'End If
            Next

            For i As Integer = 0 To GastosFijos.RowCount - 1
                If i <> 1 Then
                    Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                    cell_sangria_contenido.BorderColor = Color.WHITE
                    tabla_grilla.AddCell(cell_sangria_contenido)
                    For j As Integer = 0 To GastosFijos.ColumnCount - 1
                        Dim Carga As String = ""
                        If Not IsDBNull(GastosFijos.Rows(i).Cells(j).Value) Then
                            Carga = GastosFijos.Rows(i).Cells(j).Value
                        Else
                            Carga = ""
                        End If
                        tabla_grilla.AddCell(New Phrase(Convert.ToString(Carga), FontFactory.GetFont("arial", 13, Font.Bold, Color.BLACK)))
                        'End If
                    Next
                End If
            Next

            tabla_transportista2.AddCell("")
            'tabla_transportista2.AddCell(New Phrase("Gastos Variables", FontFactory.GetFont("arial", 18, Font.Bold, Color.BLACK)))
            tabla_transportista2.AddCell("")
            tabla_transportista2.AddCell("")
            tabla_transportista2.AddCell("")
            tabla_transportista2.AddCell("")
            tabla_transportista2.AddCell("")

            Dim cell_sangria_titulo2 As New PdfPCell(New Phrase(""))
            cell_sangria_titulo2.BorderColor = Color.WHITE
            tabla_grilla2.AddCell(cell_sangria_titulo2)
            For index As Integer = 0 To GastosVariables.ColumnCount - 1
                'If grd_detalle.Columns(index).HeaderText <> "CONLOTE" Then
                Dim cell_encabezado As New PdfPCell(New Phrase(GastosVariables.Columns(index).HeaderText.ToUpper, FontFactory.GetFont("arial", 14, Font.Bold, Color.BLACK)))
                cell_encabezado.BackgroundColor = Color.GRAY
                tabla_grilla2.AddCell(cell_encabezado)
                'End If
            Next

            For i As Integer = 0 To GastosVariables.RowCount - 1
                If i <> 0 And i <> 8 Then
                    Dim cell_sangria_contenido As New PdfPCell(New Phrase(""))
                    cell_sangria_contenido.BorderColor = Color.WHITE
                    tabla_grilla2.AddCell(cell_sangria_contenido)
                    For j As Integer = 0 To GastosVariables.ColumnCount - 1
                        Dim Carga As String = ""
                        If Not IsDBNull(GastosVariables.Rows(i).Cells(j).Value) Then
                            Carga = GastosVariables.Rows(i).Cells(j).Value
                        Else
                            Carga = ""
                        End If
                        tabla_grilla2.AddCell(New Phrase(Convert.ToString(Carga), FontFactory.GetFont("arial", 13, Font.Bold, Color.BLACK)))
                        'End If
                    Next
                End If
            Next

            Dim cell_sangria_contenido2 As New PdfPCell(New Phrase(""))
            cell_sangria_contenido2.BorderColor = Color.WHITE

            'tabla_grilla2.AddCell(cell_sangria_contenido2)
            'tabla_grilla2.AddCell("")
            'tabla_grilla2.AddCell("")
            'tabla_grilla2.AddCell("")
            'tabla_grilla2.AddCell("")

            'tabla_grilla2.AddCell(cell_sangria_contenido2)
            ''tabla_grilla2.AddCell("")
            'tabla_grilla2.AddCell("")
            'tabla_grilla2.AddCell("")
            'tabla_grilla2.AddCell("Total Gastos: ")
            'tabla_grilla2.AddCell(TextTotalGastos.Text)


            Dim cell_motivo As New PdfPCell(New Phrase("", FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo.BackgroundColor = Color.WHITE
            cell_motivo.BorderColor = Color.WHITE
            cell_motivo.HorizontalAlignment = Element.ALIGN_RIGHT
            tabla_motivo.AddCell(cell_motivo)
            tabla_motivo.AddCell(cell_motivo)

            Dim cell_motivo_des As New PdfPCell(New Phrase("Total de Gastos: L " & FormatNumber(TextTotalGastos.Text, 2), FontFactory.GetFont("arial", 16, Font.Bold, Color.BLACK)))
            cell_motivo_des.BackgroundColor = Color.WHITE
            cell_motivo_des.HorizontalAlignment = Element.ALIGN_RIGHT
            tabla_motivo.AddCell(cell_motivo_des)

            Dim cell_motivo_sangria As New PdfPCell(New Phrase(""))
            cell_motivo_sangria.BorderColor = Color.WHITE
            tabla_motivo.AddCell(cell_motivo_sangria)

            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                              Nombre y firma de Entregador       ")
            tabla_fimas.AddCell("                                 Revisado Liquidaciones        ")
            tabla_fimas.AddCell("                                   ")
            tabla_fimas.AddCell("                                   ")
            tabla_fimas.AddCell("                                   ")
            tabla_fimas.AddCell("                                   ")
            tabla_fimas.AddCell("                                   ")
            tabla_fimas.AddCell("                                   ")


            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                    ____________________________________")
            tabla_fimas.AddCell("                               Aurotizado por Logística       ")
            tabla_fimas.AddCell("                               Revisado por Contabilidad       ")


            pdfDoc.Add(tabla_encabezado)
            pdfDoc.Add(tabla_sub_encabezado)
            pdfDoc.Add(tabla_transportista)
            pdfDoc.Add(tabla_grilla)
            pdfDoc.Add(tabla_grilla2)



            pdfDoc.Add(tabla_motivo)
            pdfDoc.Add(tabla_fimas)
            'pdfDoc.Add(tabla_datos_adicionales)
            pdfDoc.Close()
            stream.Close()

            Process.Start(direccion_archivo & "Gastos Liquidacion N " & NumeroLiquidacion & ".pdf")
        End Using
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            FolderBrowserDialog1.Description = "Guardar Remision"
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
             Then
                direccion_archivo = FolderBrowserDialog1.SelectedPath + "\"
            End If
            Try
                TextNumeroFact.Text = ""
                For Each Row As DataGridViewRow In Rangos.Rows
                    TextNumeroFact.Text = TextNumeroFact.Text & Row.Cells(0).Value & " - " & Row.Cells(1).Value & vbNewLine
                Next
            Catch ex As Exception

            End Try
            ImprimirGastos()
            ImprimirRemision_DISAR()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub Llena()
        Try
            Rangos.Rows.Clear()
            RangosContado.Rows.Clear()
            RangosCredito.Rows.Clear()
        Catch ex As Exception
        End Try


        Try

            If ComboEmpresa.Text = "SAN RAFAEL" Then
                grdBodega.DataSource = Clase.RCDumbar(Entregador, DateTimePicker1.Value.Date, "N", "GENERAL", DateTimePicker1.Value.Date)
                grdBodega.Columns(6).Visible = False
                grdContado.DataSource = Clase.RCDumbar(Entregador, DateTimePicker1.Value.Date, "Cont", "FILTRO", DateTimePicker2.Value.Date)
                grdCredito.DataSource = Clase.RCDumbar(Entregador, DateTimePicker1.Value.Date, "Cred", "FILTRO", DateTimePicker2.Value.Date)
            ElseIf ComboEmpresa.Text = "DIMOSA" Then
                grdBodega.DataSource = Clase.RCDumbarDIMOSA(Entregador, DateTimePicker1.Value.Date, "N", "GENERAL", DateTimePicker1.Value.Date)
                grdBodega.Columns(6).Visible = False
                grdContado.DataSource = Clase.RCDumbarDIMOSA(Entregador, DateTimePicker1.Value.Date, "Cont", "FILTRO", DateTimePicker2.Value.Date)
                grdCredito.DataSource = Clase.RCDumbarDIMOSA(Entregador, DateTimePicker1.Value.Date, "Cred", "FILTRO", DateTimePicker2.Value.Date)
            ElseIf ComboEmpresa.Text = "OPL" Then
                grdBodega.DataSource = Clase.RCDumbarOPL(Entregador, DateTimePicker1.Value.Date, "N", "GENERAL", DateTimePicker1.Value.Date)
                grdBodega.Columns(6).Visible = False
                grdContado.DataSource = Clase.RCDumbarOPL(Entregador, DateTimePicker1.Value.Date, "Cont", "FILTRO", DateTimePicker2.Value.Date)
                grdCredito.DataSource = Clase.RCDumbarOPL(Entregador, DateTimePicker1.Value.Date, "Cred", "FILTRO", DateTimePicker2.Value.Date)
            Else
                grdBodega.DataSource = Clase.RCDumbarAgro(Entregador, DateTimePicker1.Value.Date, "N", "GENERAL", DateTimePicker1.Value.Date)
                grdBodega.Columns(6).Visible = False
                grdContado.DataSource = Clase.RCDumbarAgro(Entregador, DateTimePicker1.Value.Date, "Cont", "FILTRO", DateTimePicker2.Value.Date)
                grdCredito.DataSource = Clase.RCDumbarAgro(Entregador, DateTimePicker1.Value.Date, "Cred", "FILTRO", DateTimePicker2.Value.Date)
            End If
            Dim Uni, pes, dine As Double
            For i As Integer = 0 To grdBodega.RowCount - 1
                'Uni += grdBodega.Rows(i).Cells(2).Value
                Uni += grdBodega.Rows(i).Cells.Item("CANT").Value

                'dine += grdBodega.Rows(i).Cells.Item("TOTAL").Value
                'dine += grdBodega.Rows(i).Cells(4).Value
                'pes += grdBodega.Rows(i).Cells(6).Value
                pes += grdBodega.Rows(i).Cells.Item("PESO").Value
            Next

            Dim dinerobodega As Decimal = 0
            Dim pesobodega As Decimal = 0
            Dim unidadesbodega As Decimal = 0

            dinerobodega = Math.Round(dine, 2)
            pesobodega = FormatNumber(pes, 2)
            unidadesbodega = FormatNumber(Uni, 2)
            dine = 0
            Uni = 0
            pes = 0
            For i As Integer = 0 To grdContado.RowCount - 1

                'Uni += grdContado.Rows(i).Cells(2).Value
                Uni += grdContado.Rows(i).Cells.Item("CANT").Value

                'dine += grdContado.Rows(i).Cells(3).Value
                dine += grdContado.Rows(i).Cells.Item("TOTAL").Value

                'pes += grdContado.Rows(i).Cells(4).Value
                pes += grdContado.Rows(i).Cells.Item("PESO").Value


            Next

            Dim dinerocontado As Decimal = 0
            Dim pesocontado As Decimal = 0
            Dim unidadescontado As Decimal = 0
            dinerocontado = Math.Round(dine, 2)
            pesocontado = FormatNumber(pes, 2)
            unidadescontado = FormatNumber(Uni, 2)
            dine = 0
            Uni = 0
            pes = 0
            For i As Integer = 0 To grdCredito.RowCount - 1


                'Uni += grdCredito.Rows(i).Cells(2).Value
                Uni += grdCredito.Rows(i).Cells.Item("CANT").Value

                'dine += grdCredito.Rows(i).Cells(3).Value
                dine += grdCredito.Rows(i).Cells.Item("TOTAL").Value

                'pes += grdCredito.Rows(i).Cells(4).Value
                pes += grdCredito.Rows(i).Cells.Item("PESO").Value

            Next

            Dim dinerocredito As Decimal = 0
            Dim pesocredito As Decimal = 0
            Dim unidadescredito As Decimal = 0

            dinerocredito = Math.Round(dine, 2)
            pesocredito = FormatNumber(pes, 2)
            unidadescredito = FormatNumber(Uni, 2)
            dine = 0
            Uni = 0
            pes = 0

            'Try
            '    If Rangos.Rows.Count > 0 Then
            '        Dim dine
            '        For Each Row As DataGridViewRow In Rangos.Rows

            '        Next
            '    End If
            'Catch ex As Exception
            'End Try

            Dim dta As New DataTable
            dta.Rows.Clear()
            If ComboEmpresa.Text = "SAN RAFAEL" Then
                dta = Clase.RCDumbar(Entregador, DateTimePicker1.Value.Date, "A", "DEV", DateTimePicker2.Value.Date)
            ElseIf ComboEmpresa.Text = "DIMOSA" Then
                dta = Clase.RCDumbarDIMOSA(Entregador, DateTimePicker1.Value.Date, "A", "DEV", DateTimePicker2.Value.Date)
            ElseIf ComboEmpresa.Text = "OPL" Then
                dta = Clase.RCDumbarOPL(Entregador, DateTimePicker1.Value.Date, "A", "DEV", DateTimePicker2.Value.Date)
            Else
                dta = Clase.RCDumbarAgro(Entregador, DateTimePicker1.Value.Date, "A", "DEV", DateTimePicker2.Value.Date)
            End If

            Dim Dev As Decimal = 0
            Try
                Dev = dta(0)(0)
            Catch ex As Exception
            End Try

            Dim dinerodevoluciones As Decimal = 0
            dinerobodega = Val(dinerocontado) + Val(dinerocredito)
            dinerodevoluciones = Val(Dev)


            Dim TotalDineroMDev As Decimal = 0

            TotalDineroMDev = Val(dinerobodega) - Val(dinerodevoluciones)
            TotalDineroMDev = FormatNumber(Val(TotalDineroMDev), 2)
            dinerodevoluciones = FormatNumber(Val(dinerodevoluciones), 2)
            dinerobodega = FormatNumber(Val(dinerobodega), 2)
            dinerocredito = FormatNumber(Val(dinerocredito), 2)
            dinerocontado = FormatNumber(Val(dinerocontado), 2)

            CalculaRangos()


        Catch ex As Exception
            MsgBox("Error al Generar Reporte de Carga ")
        End Try


    End Sub

    Sub CalculaRangos()
        Dim db As New cls_reporte_carga
        If ComboEmpresa.Text = "SAN RAFAEL" Then
            DataGridView1.DataSource = db.RCDumbarFacturas(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
            FacturasContado.DataSource = db.RCDumbarFacturasContado(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
            FacturasCredito.DataSource = db.RCDumbarFacturasCredito(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
        ElseIf ComboEmpresa.Text = "DIMOSA" Then
            DataGridView1.DataSource = db.RCDumbarFacturasDimosa(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
            FacturasContado.DataSource = db.RCDumbarFacturasContadoDIMOSA(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
            FacturasCredito.DataSource = db.RCDumbarFacturasCreditoDIMOSA(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
        ElseIf ComboEmpresa.Text = "OPL" Then
            DataGridView1.DataSource = db.RCDumbarFacturasOPL(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
            FacturasContado.DataSource = db.RCDumbarFacturasContadoOPL(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
            FacturasCredito.DataSource = db.RCDumbarFacturasContadoOPL(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
        Else

            DataGridView1.DataSource = db.RCDumbarFacturasAgro(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
            FacturasContado.DataSource = db.RCDumbarFacturasContadoAgro(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
            FacturasCredito.DataSource = db.RCDumbarFacturasCreditoAgro(Entregador, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)

        End If

        'Dim counter As Integer = 0
        Try
            Dim Primera As String = DataGridView1.Rows(0).Cells(0).Value
            Dim Segunda As String = DataGridView1.Rows(0).Cells(0).Value
            Dim B As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim A As Integer = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                If row.Index = 0 Then
                    B = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                Else
                    B = Val(DataGridView1.Rows(row.Index - 1).Cells(0).Value.ToString.Substring(10, 8))
                    Segunda = DataGridView1.Rows(row.Index - 1).Cells(0).Value
                End If
                Try
                    If A <= B + 1 Then
                    Else
                        Dim dtx As New DataTable
                        dtx = db.VerificaRangoGuardado(Primera, Segunda)
                        If dtx.Rows.Count > 0 Then
                        Else
                            Rangos.Rows.Add(Primera, Segunda)
                        End If
                        Primera = row.Cells(0).Value
                    End If

                    If row.Index = DataGridView1.RowCount - 1 Then
                        Rangos.Rows.Add(Primera, DataGridView1.Rows(row.Index).Cells(0).Value)
                    End If

                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            'MsgBox("error" & ex.Message)
        End Try

        'Contado
        'Dim counter As Integer = 0
        Try
            Dim Primera As String = FacturasContado.Rows(0).Cells(0).Value
            Dim Segunda As String = FacturasContado.Rows(0).Cells(0).Value
            Dim B As Integer = 0
            For Each row As DataGridViewRow In FacturasContado.Rows
                Dim A As Integer = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                If row.Index = 0 Then
                    B = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                Else
                    B = Val(FacturasContado.Rows(row.Index - 1).Cells(0).Value.ToString.Substring(10, 8))
                    Segunda = FacturasContado.Rows(row.Index - 1).Cells(0).Value
                End If
                Try
                    If A <= B + 1 Then
                    Else
                        Dim dtx As New DataTable
                        dtx = db.VerificaRangoGuardado(Primera, Segunda)
                        If dtx.Rows.Count > 0 Then
                        Else
                            RangosContado.Rows.Add(Primera, Segunda)
                        End If
                        Primera = row.Cells(0).Value
                    End If

                    If row.Index = FacturasContado.RowCount - 1 Then
                        RangosContado.Rows.Add(Primera, FacturasContado.Rows(row.Index).Cells(0).Value)
                    End If

                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            'MsgBox("error" & ex.Message)
        End Try

        'Crédito
        'Dim counter As Integer = 0
        Try
            Dim Primera As String = FacturasCredito.Rows(0).Cells(0).Value
            Dim Segunda As String = FacturasCredito.Rows(0).Cells(0).Value
            Dim B As Integer = 0
            For Each row As DataGridViewRow In FacturasCredito.Rows
                Dim A As Integer = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                If row.Index = 0 Then
                    B = Val(row.Cells(0).Value.ToString.Substring(10, 8))
                Else
                    B = Val(FacturasCredito.Rows(row.Index - 1).Cells(0).Value.ToString.Substring(10, 8))
                    Segunda = FacturasCredito.Rows(row.Index - 1).Cells(0).Value
                End If
                Try
                    If A <= B + 1 Then
                    Else
                        Dim dtx As New DataTable
                        dtx = db.VerificaRangoGuardado(Primera, Segunda)
                        If dtx.Rows.Count > 0 Then
                        Else
                            RangosCredito.Rows.Add(Primera, Segunda)
                        End If
                        Primera = row.Cells(0).Value
                    End If

                    If row.Index = FacturasCredito.RowCount - 1 Then
                        RangosCredito.Rows.Add(Primera, FacturasCredito.Rows(row.Index).Cells(0).Value)
                    End If

                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            'MsgBox("error" & ex.Message)
        End Try

    End Sub

    Sub LlenaTotales()
        For Each row As DataGridViewRow In RangosContado.Rows
            Try
                Dim db As New cls_reporte_carga
                Dim dt As New DataTable
                dt.Rows.Clear()
                If ComboEmpresa.Text = "SAN RAFAEL" Then
                    dt = db.RCDumbarTotales(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                ElseIf ComboEmpresa.Text = "DIMOSA" Then
                    dt = db.RCDumbarTotalesDIMOSA(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                ElseIf ComboEmpresa.Text = "OPL" Then
                    dt = db.RCDumbarTotalesOPL(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                Else
                    dt = db.RCDumbarTotalesAgro(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                End If
                Dim Total As Decimal = 0
                Total = dt(0)(0)
                row.Cells(2).Value = Total

                dt.Rows.Clear()
                If ComboEmpresa.Text = "SAN RAFAEL" Then
                    dt = db.RCDumbarDevoluciones(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                ElseIf ComboEmpresa.Text = "DIMOSA" Then
                    dt = db.RCDumbarDevolucionesDIMOSA(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                ElseIf ComboEmpresa.Text = "OPL" Then
                    dt = db.RCDumbarDevolucionesOPL(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                Else
                    dt = db.RCDumbarDevolucionesAgro(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                End If

                Total = 0
                Try
                    Total = dt(0)(0)
                    row.Cells(3).Value = Total
                Catch ex As Exception
                    row.Cells(3).Value = "0.00"
                End Try
            Catch ex As Exception
            End Try
        Next

        For Each row As DataGridViewRow In RangosCredito.Rows
            Try
                Dim db As New cls_reporte_carga
                Dim dt As New DataTable
                dt.Rows.Clear()
                If ComboEmpresa.Text = "SAN RAFAEL" Then
                    dt = db.RCDumbarTotales(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                ElseIf ComboEmpresa.Text = "DIMOSA" Then
                    dt = db.RCDumbarTotalesDIMOSA(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                ElseIf ComboEmpresa.Text = "OPL" Then
                    dt = db.RCDumbarTotalesOPL(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                Else
                    dt = db.RCDumbarTotalesAgro(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                End If

                Dim Total As Decimal = 0
                Total = dt(0)(0)
                row.Cells(2).Value = Total

                dt.Rows.Clear()
                If ComboEmpresa.Text = "SAN RAFAEL" Then
                    dt = db.RCDumbarDevoluciones(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                ElseIf ComboEmpresa.Text = "DIMOSA" Then
                    dt = db.RCDumbarDevolucionesDIMOSA(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                ElseIf ComboEmpresa.Text = "OPL" Then
                    dt = db.RCDumbarDevolucionesOPL(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                Else
                    dt = db.RCDumbarDevolucionesAgro(Entregador, row.Cells(0).Value, row.Cells(1).Value)
                End If

                Total = 0
                Try
                    Total = dt(0)(0)
                    row.Cells(3).Value = Total
                Catch ex As Exception
                    row.Cells(3).Value = "0.00"
                End Try
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub Cheques_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Cheques.CellClick
        FormFacturaCliente.Fecha1 = DateTimePicker1.Value
        FormFacturaCliente.Fecha2 = DateTimePicker2.Value

        FormFacturaCliente.Entregador = Entregador

        If e.ColumnIndex = 0 Or e.ColumnIndex = 2 Then
            If FormFacturaCliente.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cheques.CurrentRow.Cells(0).Value = FormFacturaCliente.Cliente
                Cheques.CurrentRow.Cells(2).Value = FormFacturaCliente.Facturas
            End If
        End If
    End Sub

    'Private Sub GastosFijos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GastosFijos.KeyPress
    '    'If GastosFijos.CurrentCell.ColumnIndex >= 3 Then
    '    '    If Char.IsLetter(e.KeyChar) Then
    '    '        e.Handled = False
    '    '    ElseIf Char.IsControl(e.KeyChar) Then
    '    '        e.Handled = False
    '    '    Else
    '    '        e.Handled = True
    '    '    End If
    '    'End If
    'End Sub

    'Private Sub GastosVariables_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GastosVariables.KeyPress
    '    'If GastosVariables.CurrentCell.ColumnIndex >= 3 Then
    '    '    If Char.IsLetter(e.KeyChar) Then
    '    '        e.Handled = False
    '    '    ElseIf Char.IsControl(e.KeyChar) Then
    '    '        e.Handled = False
    '    '    Else
    '    '        e.Handled = True
    '    '    End If
    '    'End If
    'End Sub

    'Private Sub Cheques_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cheques.KeyPress
    '    'If Cheques.CurrentCell.ColumnIndex = 3 Then
    '    '    If Char.IsLetter(e.KeyChar) Then
    '    '        e.Handled = False
    '    '    ElseIf Char.IsControl(e.KeyChar) Then
    '    '        e.Handled = False
    '    '    Else
    '    '        e.Handled = True
    '    '    End If
    '    'End If
    'End Sub

    Private Sub Rangos_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Rangos.RowsAdded
        TextNumeroFact.Text = ""
        For Each Row As DataGridViewRow In Rangos.Rows
            TextNumeroFact.Text = TextNumeroFact.Text & " " & Row.Cells(0).Value & " - " & Row.Cells(1).Value
            If Row.Index < Rangos.RowCount Then
                TextNumeroFact.Text = TextNumeroFact.Text & vbNewLine
            End If
        Next
    End Sub

    Private Sub Arqueo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Arqueo.KeyDown
        Try
            If Arqueo.Rows(Arqueo.CurrentRow.Index).Cells(Arqueo.CurrentCell.ColumnIndex).ReadOnly = False Then
                If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
                    Arqueo.Rows(Arqueo.CurrentRow.Index).Cells(Arqueo.CurrentCell.ColumnIndex).Value = ""
                End If
            End If

            Arqueo.CurrentRow.Cells(2).Value = Val(Arqueo.CurrentRow.Cells(0).Value) * Val(Arqueo.CurrentRow.Cells(1).Value)
            TextTotalArqueo.Text = 0
            For Each row As DataGridViewRow In Arqueo.Rows
                TextTotalArqueo.Text = Val(TextTotalArqueo.Text) + Val(row.Cells(2).Value)
            Next
        Catch ex As Exception
        End Try

        'Try
        '    If Char.IsLetter(e.KeyValue) Then
        '        e.Handled = False
        '    ElseIf Char.IsControl(e.KeyChar) Then
        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub GastosFijos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GastosFijos.KeyDown
        Try
            If GastosFijos.Rows(GastosFijos.CurrentRow.Index).Cells(GastosFijos.CurrentCell.ColumnIndex).ReadOnly = False Then
                If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
                    GastosFijos.Rows(GastosFijos.CurrentRow.Index).Cells(GastosFijos.CurrentCell.ColumnIndex).Value = ""
                End If
            End If
        Catch ex As Exception
        End Try

        SumaGastos()
    End Sub

    Private Sub GastosVariables_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GastosVariables.KeyDown
        Try
            If GastosVariables.Rows(GastosVariables.CurrentRow.Index).Cells(GastosVariables.CurrentCell.ColumnIndex).ReadOnly = False Then
                If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
                    GastosVariables.Rows(GastosVariables.CurrentRow.Index).Cells(GastosVariables.CurrentCell.ColumnIndex).Value = ""
                End If
            End If
        Catch ex As Exception
        End Try
        SumaGastos()
        GastosVariables.Rows(2).Cells(1).Value = GastosVariables.Rows(1).Cells(1).Value
        GastosVariables.Rows(3).Cells(1).Value = GastosVariables.Rows(1).Cells(1).Value
        GastosVariables.Rows(2).Cells(2).Value = GastosVariables.Rows(1).Cells(2).Value
        GastosVariables.Rows(3).Cells(2).Value = GastosVariables.Rows(1).Cells(2).Value

    End Sub

    Sub SumaGastos()
        TextTotalGastos.Text = 0
        For Each row As DataGridViewRow In GastosFijos.Rows
            Try
                If Not IsNumeric(row.Cells(3).Value) Then
                    row.Cells(3).Value = 0
                End If
                row.Cells(5).Value = Val(row.Cells(3).Value) * (row.Cells(4).Value)
                TextTotalGastos.Text = Val(TextTotalGastos.Text) + Val(row.Cells(5).Value)
            Catch ex As Exception
            End Try
        Next
        For Each row As DataGridViewRow In GastosVariables.Rows
            Try
                If Not IsNumeric(row.Cells(3).Value) Then
                    row.Cells(3).Value = 0
                End If
                TextTotalGastos.Text = Val(TextTotalGastos.Text) + Val(row.Cells(3).Value)
            Catch ex As Exception
            End Try
        Next
        'Try
        '    TextTotalGastos.Text = FormatNumber(TextTotalGastos.Text, 2)
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub Cheques_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cheques.KeyDown
        Try
            If Cheques.Rows(Cheques.CurrentRow.Index).Cells(Cheques.CurrentCell.ColumnIndex).ReadOnly = False Then
                If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
                    Cheques.Rows(Cheques.CurrentRow.Index).Cells(Cheques.CurrentCell.ColumnIndex).Value = ""
                End If
            End If
        Catch ex As Exception
        End Try

        TextTotalCheques.Text = "0"
        For Each row As DataGridViewRow In Cheques.Rows
            Try
                If Not IsNumeric(row.Cells(3).Value = 0) Then
                    row.Cells(3).Value = 0
                End If
                TextTotalCheques.Text = Val(TextTotalCheques.Text) + Val(row.Cells(3).Value)
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub Datos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Datos.KeyDown
        Try
            If Datos.Rows(Datos.CurrentRow.Index).Cells(Datos.CurrentCell.ColumnIndex).ReadOnly = False Then
                If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
                    Datos.Rows(Datos.CurrentRow.Index).Cells(Datos.CurrentCell.ColumnIndex).Value = ""
                End If
            End If
        Catch ex As Exception
        End Try
        If Not IsNumeric(Datos.CurrentRow.Cells(2).Value) Then
            Datos.CurrentRow.Cells(2).Value = 0
        End If
        COMPLETA()
    End Sub

    Private Sub Btn_Quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quitar.Click
        If Rangos.RowCount > 0 Then
            Rangos.Rows.Remove(Rangos.CurrentRow)
        End If
    End Sub

    Private Sub Rangos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Rangos.CellEndEdit
        Dim Folio As String = ""
        If ComboEmpresa.Text = "SAN RAFAEL" Then
            If almacen = 1 Then
                Folio = "00-001-01-"
            ElseIf almacen = 2 Then
                Folio = "01-001-01-"
            ElseIf almacen = 3 Then
                Folio = "04-001-01-"
            ElseIf almacen = 4 Then
                Folio = "03-001-01-"
            End If
            While Rangos.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Length < 7
                Rangos.CurrentRow.Cells(e.ColumnIndex).Value = "0" & Rangos.CurrentRow.Cells(e.ColumnIndex).Value.ToString
            End While
            If Rangos.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Length < 10 Then
                Rangos.CurrentRow.Cells(e.ColumnIndex).Value = Folio & Rangos.CurrentRow.Cells(e.ColumnIndex).Value.ToString
            End If
        End If
        If ComboEmpresa.Text = "DIMOSA" Then
            If almacen = 1 Then
                Folio = "00-005-01-"
            ElseIf almacen = 2 Then
                Folio = "02-003-01-"
            ElseIf almacen = 3 Then
                Folio = "01-005-01-"
            End If
            While Rangos.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Length < 7
                Rangos.CurrentRow.Cells(e.ColumnIndex).Value = "0" & Rangos.CurrentRow.Cells(e.ColumnIndex).Value.ToString
            End While
            If Rangos.CurrentRow.Cells(e.ColumnIndex).Value.ToString.Length < 10 Then
                Rangos.CurrentRow.Cells(e.ColumnIndex).Value = Folio & Rangos.CurrentRow.Cells(e.ColumnIndex).Value.ToString
            End If
        End If
    End Sub

    Private Sub TextNDeposito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextNDeposito.TextChanged
        TextDepositoFinal.Text = TextNDeposito.Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frm_problemas_mecanicos_quejas.Entregador = ComboEntregador.SelectedValue
        frm_problemas_mecanicos_quejas.Entregadornombre = ComboEntregador.Text
        frm_problemas_mecanicos_quejas.ShowDialog()
    End Sub

    Private Sub DteFacturado_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DteFacturado.ValueChanged
        DateTimePicker1.Value = DteFacturado.Value
        DateTimePicker2.Value = DteFacturado.Value
    End Sub

    Private Sub TextKilometraje_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextKilometraje.TextChanged
        txtKMGastos.Text = TextKilometraje.Text
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(Hora1.Text & " --- " & Hora2.Text)
    End Sub

End Class
