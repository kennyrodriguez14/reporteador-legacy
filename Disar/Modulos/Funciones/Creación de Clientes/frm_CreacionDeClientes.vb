Imports Disar.data

Public Class frm_CreacionDeClientes

    Dim DiaVisita As String = "1_LUNES"
    Public Empresa As String = "SAN RAFAEL"


    Private Sub frm_CreacionDeClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            If _Inicio.SANRAFAEL = 1 Then
                ComboBox1.Items.Add("SAN RAFAEL")
            End If
            If _Inicio.DIMOSA = 1 Then
                ComboBox1.Items.Add("DIMOSA")
            End If
            If _Inicio.AGRO = 1 Then
                ComboBox1.Items.Add("SR AGRO")
            End If
            If _Inicio.OPL = 1 Then
                ComboBox1.Items.Add("OPL")
            End If
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
        End Try

        Dim db As New clsSeguridad
        Dim DT As New DataTable

        DT = db.SuspendeClientes(_Inicio.lblUsuario.Text)

        If DT(0)(0) = 1 Then
            BtnSuspender.Visible = True
            BtnReactivar.Visible = True
            BtnCoordenadas.Visible = True
        Else
            BtnSuspender.Visible = False
            BtnReactivar.Visible = False
            BtnCoordenadas.Visible = False
        End If
        GroupPrincipal.BringToFront()
        BtnActualizar.PerformClick()
        LlenarTipos()
        ComboBox1.SelectedIndex = 0
        Try
            If _Inicio.lbl_usuario_tipo.Text <> "Logistica" Then
                BtnNuevo.Enabled = True
            Else
                BtnNuevo.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click

        If frmSelector_Empresa.ShowDialog = Windows.Forms.DialogResult.OK Then
            Empresa = frmSelector_Empresa.Empresa
            If Empresa = "SAN RAFAEL" Then
                PictureBox1.Image = My.Resources.SANRAFAEL2
                TextCarga.Enabled = False
            ElseIf Empresa = "DIMOSA" Then
                PictureBox1.Image = My.Resources.DIMOSA_26
                TextCarga.Enabled = True
            ElseIf Empresa = "OPL" Then
                PictureBox1.Image = My.Resources.OPL
                TextCarga.Enabled = True
            End If
        End If
        TextCarga.Text = ""
        LlenarVENDEDORES()
        GroupClienteNuevo.BringToFront()
        Clear1()
        ComboDiaVisita.SelectedIndex = Today.DayOfWeek - 1
        LlenarTipos()
        TextTipoPago.Text = "CONTADO"
        TextNombre.Focus()
        Try
            ComboTipo.SelectedValue = "PULPERIA"
        Catch ex As Exception
        End Try
        Try
            If _Inicio.Almacen = 4 Then
                ComboSucursal.SelectedItem = "TEGUCIGALPA"
                ComboSucursal.Enabled = False
            Else
                ComboSucursal.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim a = MsgBox("¿Está seguro que desea cancelar la creación del cliente?", MsgBoxStyle.YesNo, "Atención")
        If a = MsgBoxResult.Yes Then
            GroupPrincipal.BringToFront()
        End If
    End Sub

    Private Sub ComboSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSucursal.SelectedIndexChanged
        If ComboSucursal.Text = "TEGUCIGALPA" Then
            TextEncuesta.Text = 1
        Else
            TextEncuesta.Text = 0
        End If

        If ComboSucursal.Text = "SAN PEDRO SULA" Or ComboSucursal.Text = "SABA" Or ComboSucursal.Text = "TEGUCIGALPA" Then
            CheckNestle.CheckState = CheckState.Checked
            CheckNestle.Enabled = False
        Else
            CheckNestle.CheckState = CheckState.Unchecked
            CheckNestle.Enabled = True
        End If
        If ComboSucursal.Text = "SANTA ROSA DE COPÁN" Then
            CheckCargill.CheckState = CheckState.Checked
        Else
            CheckCargill.CheckState = CheckState.Unchecked
        End If
    End Sub

    Sub LlenarTipos()
        Dim db As New ClsCreacionClientes
        ComboTipo.DataSource = db.VerCategorias
        ComboTipo.ValueMember = "Tipo"
        ComboTipo.DisplayMember = "Tipo"
    End Sub

    Sub LlenarVENDEDORES()
        Try
            Dim db As New ClsCreacionClientes
            If Empresa = "SAN RAFAEL" Then
                ComboVendedor.DataSource = db.VerVENDEDORES
            ElseIf Empresa = "DIMOSA" Then
                ComboVendedor.DataSource = db.VerVENDEDORESDIMOSA
            ElseIf Empresa = "OPL" Then
                ComboVendedor.DataSource = db.VerVENDEDORESOPL
            End If
            ComboVendedor.ValueMember = "CVE_VEND"
            ComboVendedor.DisplayMember = "NOMBRE"
        Catch ex As Exception
        End Try
    End Sub

    Sub Clear()
        TextColonia.Text = ""
        TextDepartamento.Text = ""
        TextDireccion.Text = ""
        TextLat.Text = ""
        TextLong.Text = ""
        TextMunicipio.Text = ""
        TextPropietario.Text = ""
        TextRTN.Text = ""
        TextTelefono.Text = ""
        TextTipoPago.Text = ""
        TextNombre.Text = ""
        TextCarga.Text = ""
        LSemana.Visible = False
        TtxOPL.Text = ""
        LlenarTipos()
        LlenarVENDEDORES()
    End Sub

    Sub Clear1()
        TextColonia.Text = ""
        TextDireccion.Text = ""
        TextLat.Text = ""
        TextLong.Text = ""
        TextPropietario.Text = ""
        TextRTN.Text = ""
        TextTelefono.Text = ""
        TextNombre.Text = ""
        LSemana.Visible = False
        TtxOPL.Text = ""
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        DiaVisita = ""
        If ComboDiaVisita.Text = "LUNES" Or ComboDiaVisita.Text = "lunes" Then
            DiaVisita = "1_LUNES"
        End If
        If ComboDiaVisita.Text = "MARTES" Or ComboDiaVisita.Text = "martes" Then
            DiaVisita = "2_MARTES"
        End If
        If ComboDiaVisita.Text = "MIERCOLES" Or ComboDiaVisita.Text = "miercoles" Then
            DiaVisita = "3_MIERCOLES"
        End If
        If ComboDiaVisita.Text = "JUEVES" Or ComboDiaVisita.Text = "jueves" Then
            DiaVisita = "4_JUEVES"
        End If
        If ComboDiaVisita.Text = "VIERNES" Or ComboDiaVisita.Text = "viernes" Then
            DiaVisita = "5_VIERNES"
        End If
        If ComboDiaVisita.Text = "SABADO" Or ComboDiaVisita.Text = "sabado" Then
            DiaVisita = "6_SABADO"
        End If
        If TextNombre.Text = "" Or TextDireccion.Text = "" Or TextDepartamento.Text = "" Or TextPropietario.Text = "" Then
            MsgBox("Falta ingresar algunos campos obligatorios.", MsgBoxStyle.Information, "Aviso")
        Else
            Dim Clasif As String
            If ComboSucursal.Text = "SANTA ROSA DE COPÁN" Then
                Clasif = "????R"
            ElseIf ComboSucursal.Text = "SAN PEDRO SULA" Then
                Clasif = "????P"
            ElseIf ComboSucursal.Text = "SABA" Then
                Clasif = "????T"
            Else
                Clasif = "????G"
            End If
            Dim Cargill As String = ""
            Dim Nestle As String = ""
            If CheckCargill.CheckState = CheckState.Checked Then
                Cargill = "S"
            Else
                Cargill = ""
            End If
            If CheckNestle.CheckState = CheckState.Checked Then
                Nestle = "S"
            Else
                Nestle = ""
            End If

            If ComboSemana.Visible = True Then
                DiaVisita = DiaVisita & " " & ComboSemana.Text
            End If

            If Empresa = "SAN RAFAEL" Then

                If ComboSucursal.Text <> "SANTA ROSA DE COPÁN" Then
                    Try
                        Dim DB As New ClsCreacionClientes
                        Dim S As String = DB.NuevoCliente("1", TextNombre.Text, TextPropietario.Text, TextDepartamento.Text.ToUpper, TextMunicipio.Text, TextDireccion.Text, TextColonia.Text, TextRTN.Text, TextTelefono.Text, Clasif, TextInterno.Text, ComboVendedor.SelectedValue, ComboVendedor.SelectedValue, "CONTADO", DiaVisita, TextNestle.Text, TextColgate.Text, TextLong.Text, TextLat.Text, Today.Date, Clasif, Nestle, Cargill)
                        If S.Substring(0, 1) = " " Then
                            MsgBox("Guardado exitosamente: " & S)
                            Try
                                Dim conexion_bita As New cls_bitacora_reporteador
                                conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Guardó Cliente Nuevo: " & S & " - " & TextNombre.Text & " - " & ComboSucursal.Text, "Creación de Clientes",
                                                          "Fecha: " & DateTime.Now)
                            Catch ex As Exception
                            End Try
                            GroupPrincipal.BringToFront()
                            BtnActualizar.PerformClick()
                        Else
                            MsgBox(S)
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    Try
                        Dim DB As New ClsCreacionClientes
                        Dim S As String = DB.NuevoClienteSantaRosa("1", TextNombre.Text, TextPropietario.Text, TextDepartamento.Text.ToUpper, TextMunicipio.Text, TextDireccion.Text, TextColonia.Text, TextRTN.Text, TextTelefono.Text, Clasif, TextInterno.Text, ComboVendedor.SelectedValue, ComboVendedor.SelectedValue, "CONTADO", DiaVisita, TextNestle.Text, TextColgate.Text, TextLong.Text, TextLat.Text, Today.Date, Clasif, Nestle, Cargill)
                        If S.Substring(0, 1) = " " Then
                            MsgBox("Guardado exitosamente: " & S)
                            Try
                                Dim conexion_bita As New cls_bitacora_reporteador
                                conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Guardó Cliente Nuevo: " & S & " - " & TextNombre.Text & " - " & ComboSucursal.Text, "Creación de Clientes",
                                                          "Fecha: " & DateTime.Now)
                            Catch ex As Exception
                            End Try
                            GroupPrincipal.BringToFront()
                            BtnActualizar.PerformClick()
                            BtnNuevo.Focus()
                        Else
                            MsgBox(S)
                        End If
                    Catch ex As Exception
                    End Try
                End If
            ElseIf Empresa = "DIMOSA" Then
                Try
                    Dim DB As New ClsCreacionClientes
                    Dim S As String = DB.NuevoClienteDIMOSA("1", TextNombre.Text, TextPropietario.Text, TextDepartamento.Text.ToUpper, TextMunicipio.Text, TextDireccion.Text, TextColonia.Text, TextRTN.Text, TextTelefono.Text, Clasif, TextInterno.Text, ComboVendedor.SelectedValue, ComboVendedor.SelectedValue, "CONTADO", DiaVisita, TextNestle.Text, TextColgate.Text, TextLong.Text, TextLat.Text, Today.Date, Clasif, Nestle, Cargill, TextCarga.Text)
                    If S.Substring(0, 1) = " " Then
                        MsgBox("Guardado exitosamente: " & S)
                        Try
                            Dim conexion_bita As New cls_bitacora_reporteador
                            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Guardó Cliente Nuevo: " & S & " - " & TextNombre.Text & " - " & ComboSucursal.Text, "Creación de Clientes DIMOSA",
                                                      "Fecha: " & DateTime.Now)
                        Catch ex As Exception
                        End Try
                        GroupPrincipal.BringToFront()
                        BtnActualizar.PerformClick()
                    Else
                        MsgBox(S)
                    End If
                Catch ex As Exception

                End Try

            ElseIf Empresa = "OPL" Then
                If TtxOPL.Text = "" Then
                    MsgBox("No puede crear un cliente OPL sin anexarlo a un código existente.", MsgBoxStyle.Critical, "No se puede crear el cliente")
                    TtxOPL.Focus()
                Else
                    Try
                        Dim DB As New ClsCreacionClientes
                        Dim S As String = DB.NuevoClienteOPL("1", TextNombre.Text, TextPropietario.Text, TextDepartamento.Text.ToUpper, TextMunicipio.Text, TextDireccion.Text, TextColonia.Text, TextRTN.Text, TextTelefono.Text, Clasif, TextInterno.Text, ComboVendedor.SelectedValue, ComboVendedor.SelectedValue, "CONTADO", DiaVisita, TextNestle.Text, TextColgate.Text, TextLong.Text, TextLat.Text, Today.Date, Clasif, Nestle, Cargill, TextCarga.Text, TtxOPL.Text, "JAREMAR")
                        If S.Substring(0, 1) = " " Then
                            MsgBox("Guardado exitosamente: " & S)
                            Try
                                Dim conexion_bita As New cls_bitacora_reporteador
                                conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Guardó Cliente Nuevo: " & S & " - " & TextNombre.Text & " - " & ComboSucursal.Text, "Creación de Clientes OPL",
                                                          "Fecha: " & DateTime.Now)
                            Catch ex As Exception
                            End Try
                            GroupPrincipal.BringToFront()
                            BtnActualizar.PerformClick()
                        Else
                            MsgBox(S)
                        End If
                    Catch ex As Exception

                    End Try
                End If

            End If

        End If
       
        TextBuscar.Focus()

    End Sub

    Private Sub ComboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTipo.SelectedIndexChanged
        Dim dt As New DataTable
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        Dim db As New ClsCreacionClientes
        dt = db.VerUnaCategorias(ComboTipo.Text)
        Try
            TextColgate.Text = dt(0)(2)
            TextNestle.Text = dt(0)(1)
            TextInterno.Text = dt(0)(3)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboDiaVisita_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDiaVisita.SelectedIndexChanged, TextDepartamento.SelectedIndexChanged
        DiaVisita = ""
        If ComboDiaVisita.Text = "LUNES" Or ComboDiaVisita.Text = "lunes" Then
            DiaVisita = "1_LUNES"
        End If
        If ComboDiaVisita.Text = "MARTES" Or ComboDiaVisita.Text = "martes" Then
            DiaVisita = "2_MARTES"
        End If
        If ComboDiaVisita.Text = "MIERCOLES" Or ComboDiaVisita.Text = "miercoles" Then
            DiaVisita = "3_MIERCOLES"
        End If
        If ComboDiaVisita.Text = "JUEVES" Or ComboDiaVisita.Text = "jueves" Then
            DiaVisita = "4_JUEVES"
        End If
        If ComboDiaVisita.Text = "VIERNES" Or ComboDiaVisita.Text = "viernes" Then
            DiaVisita = "5_VIERNES"
        End If
        If ComboDiaVisita.Text = "SABADO" Or ComboDiaVisita.Text = "sabado" Then
            DiaVisita = "6_SABADO"
        End If
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Dim db As New ClsCreacionClientes
        If ComboBox1.Text = "DIMOSA" Then
            DataClientes.DataSource = db.VerTodosClientesDIMOSA
        ElseIf ComboBox1.Text = "SAN RAFAEL" Then
            DataClientes.DataSource = db.VerTodosClientes
        ElseIf ComboBox1.Text = "OPL" Then
            DataClientes.DataSource = db.VerTodosClientesOPL
        ElseIf ComboBox1.Text = "SR AGRO" Then
            DataClientes.DataSource = db.VerTodosClientesAgro
        End If

    End Sub

    Private Sub TextBuscar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBuscar.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim db As New ClsCreacionClientes
            If ComboBox1.Text = "DIMOSA" Then
                Try
                    DataClientes.DataSource = db.VerBuscaClientesDIMOSA(TextBuscar.Text)
                Catch ex As Exception
                End Try
            ElseIf ComboBox1.Text = "SAN RAFAEL" Then
                Try
                    DataClientes.DataSource = db.VerBuscaClientes(TextBuscar.Text)
                Catch ex As Exception
                End Try
            ElseIf ComboBox1.Text = "OPL" Then
                Try
                    DataClientes.DataSource = db.VerBuscaClientesOPL(TextBuscar.Text)
                Catch ex As Exception
                End Try
            ElseIf ComboBox1.Text = "SR AGRO" Then
                Try
                    DataClientes.DataSource = db.VerBuscaClientesAgro(TextBuscar.Text)
                Catch ex As Exception
                End Try
            End If

        End If
    End Sub

    Private Sub TextVendedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextVendedor.KeyDown
        If e.KeyData = Keys.Enter Then
            Try
                For X As Integer = TextVendedor.Text.Length To 4
                    TextVendedor.Text = " " & TextVendedor.Text
                Next
                ComboVendedor.SelectedValue = TextVendedor.Text
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Clear()
    End Sub

    Private Sub ComboVendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboVendedor.SelectedIndexChanged
        Dim db As New ClsCreacionClientes
        Dim dt As New DataTable
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        Try
            If Empresa = "SAN RAFAEL" Then
                dt = db.TipoVendedor(ComboVendedor.SelectedValue)
            ElseIf Empresa = "DIMOSA" Then
                dt = db.TipoVendedorDIMOSA(ComboVendedor.SelectedValue)
            End If

            If dt(0)(0) = "V.Int" Then
                LSemana.Visible = True
                ComboSemana.Visible = True
                ComboSemana.SelectedIndex = 0
            Else
                LSemana.Visible = False
                ComboSemana.Visible = False
            End If

            If dt(0)(1) = "SR@C" Then
                ComboSucursal.SelectedIndex = 1
            ElseIf dt(0)(1) = "SP@S" Then
                ComboSucursal.SelectedIndex = 0
            ElseIf dt(0)(1) = "TOC@A" Then
                ComboSucursal.SelectedIndex = 2
            ElseIf dt(0)(1) = "S@BA" Then
                ComboSucursal.SelectedIndex = 2
            Else
                ComboSucursal.SelectedIndex = 3
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnSuspender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSuspender.Click
        Dim db As New ClsCreacionClientes
        Dim s
        If DataClientes.CurrentRow.Cells("CLAVE VENDEDOR").Value = "  100" Then
            MsgBox("El cliente ya se encuentra suspendido")
        Else
            Dim a = MsgBox("Está seguro que desea suspender al cliente " & DataClientes.CurrentRow.Cells(0).Value & ": " & DataClientes.CurrentRow.Cells(1).Value & "?", MsgBoxStyle.YesNo)
            If a = MsgBoxResult.Yes Then
                If ComboBox1.Text = "DIMOSA" Then
                    s = db.SuspenderClienteDIMOSA(DataClientes.CurrentRow.Cells(0).Value, DataClientes.CurrentRow.Cells("CLAVE VENDEDOR").Value)
                ElseIf ComboBox1.Text = "SAN RAFAEL" Then
                    s = db.SuspenderCliente(DataClientes.CurrentRow.Cells(0).Value, DataClientes.CurrentRow.Cells("CLAVE VENDEDOR").Value)
                Else
                    s = "La función de suspención de clientes solo se encuentra habilitada para las empresas SAN RAFAEL y DIMOSA"
                End If

                If s = "s" Then
                    Dim Conexion_bita As New cls_bitacora_reporteador
                    Conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Suspendió cliente: " & s & " - " & DataClientes.CurrentRow.Cells(0).Value & " - " & ComboBox1.Text, "Creación de Clientes", _
                                                          "Fecha: " & DateTime.Now)
                    MsgBox("El cliente ha sido suspendido", MsgBoxStyle.Information, "Aviso")
                    BtnActualizar.PerformClick()
                Else
                    MsgBox(s)
                End If
            End If
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        BtnActualizar.PerformClick()
        If _Inicio.lbl_usuario_tipo.Text = "Logistica" Then
            If ComboBox1.Text = "OPL" Then
                BtnNuevo.Enabled = True
            Else
                BtnNuevo.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If ComboBox1.Text = "SAN RAFAEL" Or ComboBox1.Text = "DIMOSA" Or ComboBox1.Text = "OPL" Then
            Try
                If Not IsDBNull(DataClientes.CurrentRow.Cells(0).Value) Then
                    FrmModificarClientes.TextID.Text = DataClientes.CurrentRow.Cells(0).Value
                End If

                If Not IsDBNull(DataClientes.CurrentRow.Cells(1).Value) Then
                    FrmModificarClientes.TextNombre.Text = LTrim(DataClientes.CurrentRow.Cells(1).Value)
                End If
                If Not IsDBNull(DataClientes.CurrentRow.Cells(2).Value) Then
                    FrmModificarClientes.TextPropietario.Text = DataClientes.CurrentRow.Cells(2).Value
                End If
                If Not IsDBNull(DataClientes.CurrentRow.Cells(3).Value) Then
                    FrmModificarClientes.TextDepartamento.Text = DataClientes.CurrentRow.Cells(3).Value
                End If
                If Not IsDBNull(DataClientes.CurrentRow.Cells(4).Value) Then
                    FrmModificarClientes.TextMunicipio.Text = DataClientes.CurrentRow.Cells(4).Value
                End If
                If Not IsDBNull(DataClientes.CurrentRow.Cells(5).Value) Then
                    FrmModificarClientes.TextDireccion.Text = DataClientes.CurrentRow.Cells(5).Value
                End If
                If Not IsDBNull(DataClientes.CurrentRow.Cells(6).Value) Then
                    FrmModificarClientes.TextBarrio.Text = DataClientes.CurrentRow.Cells(6).Value
                End If
                If Not IsDBNull(DataClientes.CurrentRow.Cells(7).Value) Then
                    FrmModificarClientes.TextRTN.Text = DataClientes.CurrentRow.Cells(7).Value
                End If
                If Not IsDBNull(DataClientes.CurrentRow.Cells(8).Value) Then
                    FrmModificarClientes.TextTelefono.Text = DataClientes.CurrentRow.Cells(8).Value
                End If
                If Not IsDBNull(DataClientes.CurrentRow.Cells(14).Value) Then
                    FrmModificarClientes.TextDiaVisita.Text = DataClientes.CurrentRow.Cells(14).Value
                End If
                If Not IsDBNull(DataClientes.CurrentRow.Cells(17).Value) Then
                    FrmModificarClientes.TextLongitud.Text = DataClientes.CurrentRow.Cells(17).Value
                End If
                If Not IsDBNull(DataClientes.CurrentRow.Cells(18).Value) Then
                    FrmModificarClientes.TextLatitud.Text = DataClientes.CurrentRow.Cells(18).Value
                End If

                FrmModificarClientes.Empresa = ComboBox1.Text

                Try
                    Dim db As New ClsCreacionClientes
                    If ComboBox1.Text = "SAN RAFAEL" Then
                        FrmModificarClientes.ComboVendedor.DataSource = db.VerVENDEDORES
                    ElseIf ComboBox1.Text = "DIMOSA" Then
                        FrmModificarClientes.ComboVendedor.DataSource = db.VerVENDEDORESDIMOSA
                    ElseIf ComboBox1.Text = "OPL" Then
                        FrmModificarClientes.ComboVendedor.DataSource = db.VerVENDEDORESOPL
                    End If
                    FrmModificarClientes.ComboVendedor.ValueMember = "CVE_VEND"
                    FrmModificarClientes.ComboVendedor.DisplayMember = "NOMBRE"

                    FrmModificarClientes.ComboVendedor.SelectedValue = DataClientes.CurrentRow.Cells(11).Value
                    If BtnSuspender.Visible = True Then
                        FrmModificarClientes.ComboVendedor.Enabled = True
                        FrmModificarClientes.TextVendedor.Enabled = True
                    Else
                        FrmModificarClientes.ComboVendedor.Enabled = False
                        FrmModificarClientes.TextVendedor.Enabled = False
                    End If
                Catch ex As Exception
                End Try
                Try
                    If _Inicio.lbl_usuario_tipo.Text <> "Logistica" Then
                        FrmModificarClientes.ComboVendedor.Enabled = True
                        FrmModificarClientes.TextVendedor.Enabled = True
                        FrmModificarClientes.TextDiaVisita.Enabled = True
                    Else
                        FrmModificarClientes.ComboVendedor.Enabled = False
                        FrmModificarClientes.TextVendedor.Enabled = False
                        FrmModificarClientes.TextDiaVisita.Enabled = False
                        If ComboBox1.Text = "OPL" Then
                            FrmModificarClientes.ComboVendedor.Enabled = True
                            FrmModificarClientes.TextVendedor.Enabled = True
                            FrmModificarClientes.TextDiaVisita.Enabled = True
                        End If
                    End If
                Catch ex As Exception
                End Try

                If FrmModificarClientes.ShowDialog = Windows.Forms.DialogResult.OK Then
                    BtnActualizar.PerformClick()
                End If

            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub TextCarga_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextCarga.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dt As New DataTable
            Dim db As New ClsCreacionClientes
            Try
                dt = db.VerBuscaClientes(TextCarga.Text)

                If Not IsDBNull(dt(0)(1)) Then
                    TextNombre.Text = LTrim(dt(0)(1))
                Else
                    TextNombre.Text = ""
                End If

                If Not IsDBNull(dt(0)(5)) Then
                    TextDireccion.Text = dt(0)(5)
                Else
                    TextDireccion.Text = ""
                End If
                If Not IsDBNull(dt(0)(6)) Then
                    TextColonia.Text = dt(0)(6)
                Else
                    TextColonia.Text = ""
                End If
                If Not IsDBNull(dt(0)(4)) Then
                    TextMunicipio.Text = dt(0)(4)
                Else
                    TextMunicipio.Text = ""
                End If
                If Not IsDBNull(dt(0)(3)) Then
                    TextDepartamento.Text = dt(0)(3)
                Else
                    TextDepartamento.Text = ""
                End If
                If Not IsDBNull(dt(0)(7)) Then
                    TextRTN.Text = dt(0)(7)
                Else
                    TextRTN.Text = ""
                End If
                If Not IsDBNull(dt(0)(2)) Then
                    TextPropietario.Text = dt(0)(2)
                Else
                    TextPropietario.Text = ""
                End If
                If Not IsDBNull(dt(0)(8)) Then
                    TextTelefono.Text = dt(0)(8)
                Else
                    TextTelefono.Text = ""
                End If
                If Not IsDBNull(dt(0)(17)) Then
                    TextLong.Text = dt(0)(17)
                Else
                    TextLong.Text = ""
                End If
                If Not IsDBNull(dt(0)(18)) Then
                    TextLat.Text = dt(0)(18)
                Else
                    TextLat.Text = ""
                End If
                If Not IsDBNull(dt(0)(15)) Then
                    TextNestle.Text = dt(0)(15)
                Else
                    TextNestle.Text = ""
                End If
                If Not IsDBNull(dt(0)(16)) Then
                    TextColgate.Text = dt(0)(16)
                Else
                    TextColgate.Text = ""
                End If
                If Not IsDBNull(dt(0)(10)) Then
                    TextInterno.Text = dt(0)(10)
                Else
                    TextInterno.Text = ""
                End If
            Catch ex As Exception
            End Try
            Try
                'MsgBox("PRUEBA")
                Dim DTX As New DataTable
                DTX = db.VALIDACLIENTE(TextCarga.Text)

                If DTX.Rows.Count > 0 Then
                    MsgBox("El Cliente ya se encuentra creado en DIMOSA con el código: " & DTX(0)(0) & " con nombre: " & DTX(0)(1), MsgBoxStyle.Information, " CLIENTE TRASPASADO")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DataClientes_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataClientes.CellDoubleClick
        btnModificar.PerformClick()
    End Sub

    Private Sub BtnReactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReactivar.Click
        If DataClientes.RowCount > 0 Then
            If DataClientes.CurrentRow.Cells("CLAVE VENDEDOR").Value = "  100" And DataClientes.CurrentRow.Cells(1).Value <> "" Then
                Dim a = MsgBox("¿Está seguro que desea reactivar el cliente " & DataClientes.CurrentRow.Cells(1).Value & "?", MsgBoxStyle.YesNo, "Reactivación de Clientes")
                If a = MsgBoxResult.Yes Then
                    Dim s
                    Dim db As New ClsCreacionClientes
                    If ComboBox1.Text = "DIMOSA" Then
                        s = db.ReactivarClienteDimosa(DataClientes.CurrentRow.Cells(0).Value)
                    Else
                        s = db.ReactivarCliente(DataClientes.CurrentRow.Cells(0).Value)
                    End If

                    If s = "s" Then
                        Dim Conexion_bita As New cls_bitacora_reporteador
                        Conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Reactivó cliente: " & s & " - " & DataClientes.CurrentRow.Cells(0).Value & " - " & ComboBox1.Text, "Creación de Clientes", _
                                                              "Fecha: " & DateTime.Now)
                        MsgBox("El cliente ha sido reactivado", MsgBoxStyle.Information, "Aviso")
                        BtnActualizar.PerformClick()
                    Else
                        MsgBox(s)
                    End If
                End If
            Else
                MsgBox("El cliente seleccionado no se encuentra suspendido", MsgBoxStyle.Information, "Reactivación de Cliente")
            End If
            
        End If

    End Sub

    Private Sub BtnCoordenadas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCoordenadas.Click
        If DataClientes.RowCount > 0 Then
            If DataClientes.CurrentRow.Cells("CERTIFICACION COORDENADAS").Value = "NO" Then
                Dim Resp = MsgBox("¿Está seguro que desea verificar las coordenadas del cliente " & DataClientes.CurrentRow.Cells(1).Value & "?", MsgBoxStyle.YesNo, "Certificación de Coordenadas")
                If Resp = MsgBoxResult.Yes Then
                    Dim db As New ClsCreacionClientes
                    Dim S
                    If ComboBox1.Text = "SAN RAFAEL" Then
                        S = db.VerificarCoordenadas(DataClientes.CurrentRow.Cells(0).Value)
                    ElseIf ComboBox1.Text = "DIMOSA" Then
                        S = db.VerificarCoordenadasDIMOSA(DataClientes.CurrentRow.Cells(0).Value)
                    Else
                        S = db.VerificarCoordenadasAGRO(DataClientes.CurrentRow.Cells(0).Value)
                    End If
                    If S = "s" Then
                        Dim Conexion_bita As New cls_bitacora_reporteador
                        Conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Certificó Coordenadas: " & ComboBox1.Text & " - " & DataClientes.CurrentRow.Cells(0).Value & " - " & ComboBox1.Text, "Creación de Clientes", _
                                                              "Fecha: " & DateTime.Now)
                        BtnActualizar.PerformClick()
                    Else
                        MsgBox(S)
                    End If
                End If
            Else
                MsgBox("LAS COORDENADAS DEL CLIENTE SELECCIONADO YA SE ENCUENTRAN VERIFICADAS Y CERTIFICADAS", MsgBoxStyle.Information, " ")
            End If
        End If
    End Sub
  
End Class