Imports System.IO
Imports Disar.data
Imports System.Net

Imports System.Data
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Public Class _Inicio

    Dim Con As New clsSeguridad
    Dim valor As String = ""
    Public Almacen As Integer
    Public Empresa As String
    Public ID As Integer
    Public IP As String
    Public permiso_cancelador As String
    Public Tiempo As Integer = 0
    Public NumEntregador As Integer = 0
    Public SAE, COI, NOI, BAN As Integer
    Public DIMOSA As String
    Public SANRAFAEL As String
    Public AGRO As String
    Public OPL As String
    Public Multiples As Integer
    Public Departamento As String
    Public AceptaRemisiones As Integer

    Sub BindToRunningProcesses()
        ' Get the current process. You can use currentProcess from this point
        ' to access various properties and call methods to control the process.
        Dim currentProcess As Process = Process.GetCurrentProcess()
        ' Get all processes running on the local computer.
        Dim localAll As Process() = Process.GetProcesses()
        ' Get all instances of Notepad running on the local computer.
        ' This will return an empty array if notepad isn't running.
        'Dim localByName As Process() = Process.GetProcessesByName("notepad")
        ' Get a process on the local computer, using the process id.
        ' This will throw an exception if there is no such process.
        'Dim localById As Process = Process.GetProcessById(1234)
        ' Get processes running on a remote computer. Note that this
        ' and all the following calls will timeout and throw an exception
        ' if "myComputer" and 169.0.0.0 do not exist on your local network.
        ' Get all processes on a remote computer.
        'Dim remoteAll As Process() = Process.GetProcesses("myComputer")
        '' Get all instances of Notepad running on the specific computer, using machine name.
        'Dim remoteByName As Process() = Process.GetProcessesByName("notepad", "myComputer")
        '' Get all instances of Notepad running on the specific computer, using IP address.
        'Dim ipByName As Process() = Process.GetProcessesByName("notepad", "10.254.10.23")
        '' Get a process on a remote computer, using the process id and machine name.
        'Dim remoteById As Process = Process.GetProcessById(2345, "myComputer")
        
        SAE = 0
        COI = 0
        NOI = 0
        NOI = 0

        For Each Process In localAll
            If Process.ProcessName.ToString.ToUpper = "BANWIN40" Then
                BAN += 1
            End If
            If Process.ProcessName.ToString.ToUpper = "SAEWIN60" Then
                SAE += 1
            End If
            If Process.ProcessName.ToString.ToUpper = "COIWIN" Then
                COI += 1
            End If
            If Process.ProcessName.ToString.ToUpper = "NOIWIN70" Then
                NOI += 1
            End If
        Next

    End Sub

    Private Function lF_sDireccionIP(ByVal strNombrePC As String) As String
        Dim valorIp As String
        valorIp = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(i) i.AddressFamily = Sockets.AddressFamily.InterNetwork).ToString()
        Return valorIp
    End Function

    Private Sub _Inicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Label3.Text = System.IO.File.GetLastWriteTime(Application.ExecutablePath)
            Label3.Text = Label3.Text.Substring(0, 5)
        Catch ex As Exception
        End Try
        Dim Ips As String = lF_sDireccionIP(My.Computer.Name)
        If Ips = "10.254.10.131" Then
            LinkLabel1.Enabled = False
            IP = "Escritorio remoto"
        Else
            LinkLabel1.Enabled = True
            IP = Ips
        End If

        Dim dt As New DataTable
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        dt = Con.Actualizando()
        If dt.Rows.Count > 0 Then
        Else
            'MsgBox("Se está realizando una actualización de sistema. Favor ingrese en unos minutos.", MsgBoxStyle.Information, "Atención")
            Shell("taskkill /F /IM Disar.exe /T", 0)
        End If


        Try
            BarraMenu.Visible = False
            If Login.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim dt_datosux As New DataTable
                Dim dt_lista_reportes As New DataTable
                dt_datosux = Con.datosux(lblId.Text)
                dt_lista_reportes = Con.Carga_Permisos(lblId.Text)

                If dt_datosux.Rows(0)(0) = "1" Then
                    mdl_reportes.Visible = True
                Else
                    mdl_reportes.Visible = False
                End If
                If dt_datosux.Rows(0)(1) = "1" Then
                    mdl_logistica.Visible = True
                Else
                    mdl_logistica.Visible = False
                End If
                If dt_datosux.Rows(0)(2) = "1" Then
                    mdl_contabilidad.Visible = True
                Else
                    mdl_contabilidad.Visible = False
                End If
                If dt_datosux.Rows(0)(3) = "1" Then
                    mdl_inventarios.Visible = True
                Else
                    mdl_inventarios.Visible = False
                End If
                If dt_datosux.Rows(0)(4) = "1" Then
                    mdl_almacen.Visible = True
                Else
                    mdl_almacen.Visible = False
                End If
                If dt_datosux.Rows(0)(5) = "1" Then
                    mdl_pdse.Visible = True
                Else
                    mdl_pdse.Visible = False
                End If
                If dt_datosux.Rows(0)(6) = "1" Then
                    mdl_bonificaciones.Visible = True
                Else
                    mdl_bonificaciones.Visible = False
                End If
                If dt_datosux.Rows(0)(7) = "1" Then
                    mdl_configuracion.Visible = True
                Else
                    mdl_configuracion.Visible = False
                End If

                If dt_datosux.Rows(0)(8) = "1" Then
                    mdl_monitoreo.Visible = True
                Else
                    mdl_monitoreo.Visible = False
                End If
                If Not IsDBNull(dt_datosux(0)(9)) Then
                    Empresa = dt_datosux(0)(9)
                Else
                    Empresa = "0"
                End If
                If Not IsDBNull(dt_datosux(0)(10)) Then
                    Almacen = dt_datosux(0)(10)
                Else
                    Almacen = 0
                End If
                If Not IsDBNull(dt_datosux(0)("M12")) Then
                    If dt_datosux.Rows(0)("M12") = "1" Then
                        mdl_Funciones.Visible = True
                    Else
                        mdl_Funciones.Visible = False
                    End If
                Else
                    mdl_Funciones.Visible = False
                End If

                For index As Integer = 0 To dt_lista_reportes.Rows.Count - 1
                    activar_menu(dt_lista_reportes.Rows(index)(0))
                Next

                Dim Db As New cls_reporte_carga
                Dim dta As New DataTable
                Try
                    dta.Rows.Clear()
                Catch ex As Exception
                End Try
                dta = Db.PermisoDumbar(lblId.Text, 131)
                If dta.Rows.Count > 0 Then
                    ReporteDumbar.Visible = True
                Else
                    ReporteDumbar.Visible = False
                End If

                Try
                    dta.Rows.Clear()
                Catch ex As Exception
                End Try
                dta = Db.PermisoDumbar(lblId.Text, 36)
                If dta.Rows.Count > 0 Then
                    mnu_reportecarga.Visible = True
                Else
                    mnu_reportecarga.Visible = False
                End If

                Try
                    dta.Rows.Clear()
                Catch ex As Exception
                End Try
                dta = Db.PermisoDumbar(lblId.Text, 35)
                If dta.Rows.Count > 0 Then
                    mnu_reportecarga_liq.Visible = True
                Else
                    mnu_reportecarga_liq.Visible = False
                End If

                Try
                    dta.Rows.Clear()
                Catch ex As Exception
                End Try
                dta = Db.PermisoDumbar(lblId.Text, 45)
                If dta.Rows.Count > 0 Then
                    mnu_reportecarga_acum.Visible = True
                Else
                    mnu_reportecarga_acum.Visible = False
                End If

                Try
                    dta.Rows.Clear()
                Catch ex As Exception
                End Try
                dta = Db.PermisoDumbar(lblId.Text, 85)
                If dta.Rows.Count > 0 Then
                    mnu_sobrantes_reporte.Visible = True
                Else
                    mnu_sobrantes_reporte.Visible = False
                End If

                Try
                    dta.Rows.Clear()
                Catch ex As Exception
                End Try
                dta = Db.PermisoDumbar(lblId.Text, 136)
                If dta.Rows.Count > 0 Then
                    mnu_orden_compra.Visible = True
                Else
                    mnu_orden_compra.Visible = False
                End If


                Try
                    dta.Rows.Clear()
                Catch ex As Exception
                End Try
                dta = Db.PermisoDumbar(lblId.Text, 137)
                If dta.Rows.Count > 0 Then
                    mnu_devolucion_compras_sr_agro.Visible = True
                Else
                    mnu_devolucion_compras_sr_agro.Visible = False
                End If

                Try
                    dta.Rows.Clear()
                Catch ex As Exception
                End Try
                dta = Db.PermisoDumbar(lblId.Text, 6166)
                If dta.Rows.Count > 0 Then
                    mnu_nuevo_producto.Visible = True
                Else
                    mnu_nuevo_producto.Visible = False
                End If

                Try
                    dta.Rows.Clear()
                Catch ex As Exception
                End Try
                dta = Db.PermisoDumbar(lblId.Text, 6167)
                If dta.Rows.Count > 0 Then
                    mnu_nuevo_proveedor.Visible = True
                Else
                    mnu_nuevo_proveedor.Visible = False
                End If

                If dt_datosux.Rows(0)(12) = 1 Then
                    permiso_cancelador = "1"
                Else
                    permiso_cancelador = "0"
                End If

                If dt_datosux.Rows(0)(13) = 1 Then
                    DIMOSA = "1"
                    'Try
                    '    Me.BackgroundImage = New Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Resources\SAN_RAFAEL_DIMOSA.png")
                    'Catch ex As Exception
                    'End Try
                Else
                    DIMOSA = "0"
                End If

                If dt_datosux.Rows(0)(14) = 1 Then
                    SANRAFAEL = "1"
                Else
                    SANRAFAEL = "0"
                End If

                If dt_datosux.Rows(0)(15) = 1 Then
                    AGRO = "1"
                    'Try
                    '    Me.BackgroundImage = New Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Resources\SAN_RAFAEL_DIMOSA.png")
                    'Catch ex As Exception
                    'End Try
                Else
                    AGRO = "0"
                End If

                If dt_datosux.Rows(0)(16) = 1 Then
                    Multiples = "1"
                Else
                    Multiples = "0"
                End If

                If dt_datosux.Rows(0)(17) = 1 Then
                    OPL = "1"
                Else
                    OPL = "0"
                End If


                Dim dtMantenimientosPendientes As New DataTable
                Dim dbs As New ClsBitacoraEventos
                dtMantenimientosPendientes = dbs.SMuestraSolicitudesUsuarioCompletas(lblUsuario.Text)

                For a As Integer = 0 To dtMantenimientosPendientes.Rows.Count - 1
                    Dim Sol As Integer = dtMantenimientosPendientes(a)(0)
                    Dim sds = MsgBox("Se ha marcado como completa una tarea que usted solicitó. ¿Se ha completado la solicitud: " & dtMantenimientosPendientes(a)(2) & " ingresada la fecha: " & dtMantenimientosPendientes(a)(3) & "?", MsgBoxStyle.YesNo)
                    If sds = MsgBoxResult.Yes Then
                        Dim x = dbs.SActualizaEv("Verificada", Sol, Today.Date, Today.Date)
                    Else
                        Try
                            Dim SMTP As String = "gator2024.hostgator.com"
                            Dim Usuario As String = "liquidaciones@sanrafaelhn.com"
                            Dim Contraseña As String = "liquidar100"

                            Dim Contenido As String = ""

                            Contenido = "El usuario " & lblUsuario.Text & " ha marcado que la tarea: " & dtMantenimientosPendientes(a)(2) & " no se ha completado. Ingrese al sistema, " & _
                                        "sección [Centro de Mantenimiento] para revisar la solicitud. " & vbNewLine & "Detalle: " & dtMantenimientosPendientes(a)(2) & " Fecha: " & dtMantenimientosPendientes(a)(3) & vbNewLine & vbNewLine & vbNewLine & vbNewLine & _
                                        " Solicitud reenviada desde Sistema de Reportes SAN RAFAEL - Solicitudes de Mantenimiento "


                            Dim Asunto As String = "Solicitud de Mantenimiento reenviada desde Sistema de Reportes SAN RAFAEL"

                            Dim Puerto As Integer = 26
                            Dim correo As New System.Net.Mail.MailMessage()
                            Dim Servidor As New System.Net.Mail.SmtpClient

                            correo.From = New System.Net.Mail.MailAddress(Usuario)
                            correo.Subject = Asunto

                            Dim clase As New ClsBitacoraEventos
                            Dim dtCorreosManteni As New DataTable
                            dtCorreosManteni = clase.sObtieneCorreosMantenimiento("Mantenimiento", Almacen)
                            For xs As Integer = 0 To dt.Rows.Count - 1
                                correo.To.Add(dtCorreosManteni(xs)(0))
                            Next

                            correo.Body = Contenido

                            Servidor.Host = SMTP
                            Servidor.Port = Puerto
                            Servidor.EnableSsl = False
                            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
                            Servidor.Send(correo)

                        Catch ex As Exception
                            'MessageBox.Show("No se logró enviar correo " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                Next



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Me.BackgroundImage = New Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Resources\SR.png")
        Catch ex As Exception
        End Try

       

    End Sub

    Sub activar(ByVal user As String)
        BarraMenu.Visible = True
        Dim conexion As New clsSeguridad
        Dim dt_accesos_reportes As New DataTable
        Dim dt_datos_usuario As New DataTable
    End Sub

    Sub activar_menu(ByVal nombre_item As String)
        'modulos de los reportes
        For Each opcion As ToolStripMenuItem In mdl_reportes.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_proveedores.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_sell_out.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_colgate.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_livsmart.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_sell_general.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_vendedores.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_efectividad.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_punto_reorden_dimosa.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_punto_reorden_opl.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_efectividad_sr_agro.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_distribuidora_san_rafael.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_resumen_anual.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_rentabilidad.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_agro.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_consultar_bitacora.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_detalle_contado_credito.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_comisiones.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mdl_logistica.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_reporte_devoluciones.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_combustible.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_descuentos_tacticos.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_devoluciones_nc.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_lista_descuentost.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mdl_contabilidad.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mdl_inventarios.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_margenes_productos.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mdl_almacen.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_productos_averiados.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_horas_trabajo.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_malas_cargas.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_recurrencias.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_sobrantes.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_compras_notas_debito.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_compras_disar.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_compras_agro.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_ingreso_devoluciones.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_ing_dev_disar.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_ing_dev_agro.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mdl_pdse.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_presupuestos_descuentos_tacticos.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mdl_bonificaciones.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_resumen_costos.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mdl_monitoreo.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mdl_Funciones.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_tasa_cambiaria.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_punto_reorden.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_punto_reorden_sr_agro.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next


        For Each opcion As ToolStripMenuItem In ComprasToolStripMenuItem.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_dev_nacionales_DIMOSA.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_ing_dev_agro_DIMOSA.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_lista_descuentost_dimosa.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next
        For Each opcion As ToolStripMenuItem In mnu_compras_dimosa.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        For Each opcion As ToolStripMenuItem In mnu_papeleria.DropDownItems
            If opcion.Name = nombre_item Then
                opcion.Visible = True
            End If
        Next

        If lbl_usuario_tipo.Text = "Administrador" Then
            mdl_configuracion.Visible = True

            For Each opcion As ToolStripMenuItem In mdl_configuracion.DropDownItems
                If opcion.Name = nombre_item Then
                    opcion.Visible = True
                End If
            Next
        End If
        Try
            Dim db As New clsSeguridad
            Dim dt As New DataTable
            dt = db.NumeroEntregador(lblUsuario.Text)
            NumEntregador = dt(0)(0)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lblCambiarPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCambiarPass.Click
        CambiarContraseña.MdiParent = Me
        CambiarContraseña.Visible = True
    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarContraseñaToolStripMenuItem.Click
        CambiarContraseña.MdiParent = Me
        CambiarContraseña.Visible = True
    End Sub

    Private Sub mnu_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_salir.Click
        Me.Close()
    End Sub

    Private Sub mnu_pivot_ventas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_pivot_ventas.Click
        Try
            Con.ContadorReporte("mnu_pivot_ventas", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_pivot_ventas.MdiParent = Me
        frm_pivot_ventas.Visible = True
    End Sub

    Private Sub mnu_detalle_descuentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_detalle_descuentos.Click
        Try
            Con.ContadorReporte("mnu_detalle_descuentos", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_detalle_descuentos.MdiParent = Me
        frm_detalle_descuentos.Visible = True
    End Sub

    'Private Sub mnu_productividad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_productividad.Click
    '    Try
    '        Con.ContadorReporte("mnu_productividad", lblUsuario.Text)
    '    Catch ex As Exception
    '    End Try
    '    Productividad.MdiParent = Me
    '    Productividad.Visible = True
    'End Sub

    Private Sub mnu_devoluciones_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_devoluciones_disar.Click
        Try
            Con.ContadorReporte("mnu_devoluciones_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Devoluciones.MdiParent = Me
        Devoluciones.Visible = True
    End Sub

    Private Sub mnu_devolucionesAgro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_devolucionesAgro.Click
        Try
            Con.ContadorReporte("mnu_devolucionesAgro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_devoluciones_sragro.MdiParent = Me
        frm_devoluciones_sragro.Visible = True
    End Sub

    Private Sub mnu_rendimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_rendimiento.Click
        Try
            Con.ContadorReporte("mnu_rendimiento", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Rendimiento.MdiParent = Me
        Rendimiento.Visible = True
    End Sub

    Private Sub mnu_consumo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_consumo.Click
        Try
            Con.ContadorReporte("mnu_consumo", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Combustible.MdiParent = Me
        Combustible.Visible = True
    End Sub

    Private Sub mnu_facturas_camposlibres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_facturas_camposlibres.Click
        Try
            Con.ContadorReporte("mnu_facturas_camposlibres", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Facturas_CampLib.MdiParent = Me
        Facturas_CampLib.Visible = True
    End Sub

    Private Sub mnu_comprobante_entrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_comprobante_entrega.Click
        Try
            Con.ContadorReporte("mnu_comprobante_entrega", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Comprobante_Entrega.MdiParent = Me
        Comprobante_Entrega.Visible = True
    End Sub

    Private Sub mnu_orden_rutas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_orden_rutas.Click
        Try
            Con.ContadorReporte("mnu_orden_rutas", lblUsuario.Text)
        Catch ex As Exception
        End Try
        OrdenRutas.MdiParent = Me
        OrdenRutas.Visible = True
    End Sub

    Private Sub mnu_facturacion_creditos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Con.ContadorReporte("mnu_facturacion_creditos", lblUsuario.Text)
        Catch ex As Exception
        End Try
        fmr_lista_facturas.MdiParent = Me
        fmr_lista_facturas.Visible = True
    End Sub

    Private Sub mnu_punto_reorden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_punto_reorden.Click
        
    End Sub

    Private Sub mnu_tabulacion_rutas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_tabulacion_rutas.Click
        Try
            Con.ContadorReporte("mnu_tabulacion_rutas", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_tab_rutas_principal.MdiParent = Me
        frm_tab_rutas_principal.Visible = True
    End Sub

    Private Sub mnu_devoluciones_nc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_devoluciones_nc.Click
        Try
            Con.ContadorReporte("mnu_devoluciones_nc", lblUsuario.Text)
        Catch ex As Exception
        End Try
        'Devoluciones_Notas_De_Credito.MdiParent = Me
        'Devoluciones_Notas_De_Credito.Visible = True
    End Sub

    Private Sub mnu_descuentost_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_descuentost_disar.Click
        Try
            Con.ContadorReporte("mnu_descuentost_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_menu_descuentos_tacticos.MdiParent = Me
        frm_menu_descuentos_tacticos.Visible = True
    End Sub

    Private Sub mnu_descuentost_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_descuentost_agro.Click
        Try
            Con.ContadorReporte("mnu_descuentost_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_menu_descuentos_tacticos_SRAGRO.MdiParent = Me
        frm_menu_descuentos_tacticos_SRAGRO.Visible = True
    End Sub

    Private Sub mnu_listadt_resumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_listadt_resumen.Click
        Try
            Con.ContadorReporte("mnu_listadt_resumen", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_descuentos_tacticos_admin.MdiParent = Me
        frm_descuentos_tacticos_admin.Visible = True
    End Sub

    Private Sub mnu_listadesct_detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_listadesct_detalle.Click
        Try
            Con.ContadorReporte("mnu_listadesct_detalle", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_resumen_descuentos_tacticos_admin_proveedor.MdiParent = Me
        frm_resumen_descuentos_tacticos_admin_proveedor.Visible = True
    End Sub

    Private Sub mnu_listadesct_resprod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_listadesct_resprod.Click
        Try
            Con.ContadorReporte("mnu_listadesct_resprod", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_resumen_des_tac.MdiParent = Me
        frm_resumen_des_tac.Visible = True
    End Sub

    Private Sub mnu_listadesct_resumen_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_listadesct_resumen_agro.Click
        Try
            Con.ContadorReporte("mnu_listadesct_resumen_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_descuentos_tacticos_admin_SRAGRO.MdiParent = Me
        frm_descuentos_tacticos_admin_SRAGRO.Visible = True
    End Sub

    Private Sub mnu_listadesct_detalle_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_listadesct_detalle_agro.Click
        Try
            Con.ContadorReporte("mnu_listadesct_detalle_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_descuentos_tacticos_admin_proveedor_SRAGRO.MdiParent = Me
        frm_descuentos_tacticos_admin_proveedor_SRAGRO.Visible = True
    End Sub

    Private Sub mnu_clientes_por_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_clientes_por_producto.Click
        Try
            Con.ContadorReporte("mnu_clientes_por_producto", lblUsuario.Text)
        Catch ex As Exception
        End Try
        clientesxarticulo.MdiParent = Me
        clientesxarticulo.Visible = True
    End Sub

    Private Sub mnu_pres_ejecucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_pres_ejecucion.Click
        Try
            Con.ContadorReporte("mnu_pres_ejecucion", lblUsuario.Text)
        Catch ex As Exception
        End Try
        EjecucionPresupuestos.MdiParent = Me
        EjecucionPresupuestos.Visible = True
    End Sub

    Private Sub mnu_pres_gestionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_pres_gestionar.Click
        Try
            Con.ContadorReporte("mnu_pres_gestionar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Presupuestos_Deptos.MdiParent = Me
        Presupuestos_Deptos.Visible = True
    End Sub

    Private Sub mnu_antiguedad_saldos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_antiguedad_saldos.Click
        Try
            Con.ContadorReporte("mnu_antiguedad_saldos", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Saldos.MdiParent = Me
        Saldos.Visible = True
    End Sub

    Private Sub mnu_antiguedad_saldos_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_antiguedad_saldos_det.Click
        Try
            Con.ContadorReporte("mnu_antiguedad_saldos_det", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Saldos_Detallados_Nuevo.MdiParent = Me
        Saldos_Detallados_Nuevo.Visible = True
    End Sub

    Private Sub mnu_ventas_promedio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ventas_promedio.Click
        Try
            Con.ContadorReporte("mnu_ventas_promedio", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_ventas_promedio.MdiParent = Me
        frm_ventas_promedio.Visible = True
    End Sub

    Private Sub mnu_detalle_facturas_vend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_detalle_facturas_vend.Click
        Try
            Con.ContadorReporte("mnu_detalle_facturas_vend", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_facturas_vendedor.MdiParent = Me
        frm_facturas_vendedor.Visible = True
    End Sub

    Private Sub mnu_libro_ventas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_libro_ventas.Click
        Try
            Con.ContadorReporte("mnu_libro_ventas", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_libro_ventas.MdiParent = Me
        frm_libro_ventas.Visible = True
    End Sub

    Private Sub mnu_productos_precios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_productos_precios.Click
        Try
            Con.ContadorReporte("mnu_productos_precios", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Inventarios.MdiParent = Me
        Inventarios.Visible = True
    End Sub

    Private Sub mnu_dias_inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_dias_inventario.Click
        Try
            Con.ContadorReporte("mnu_dias_inventario", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Dias_Inventario.MdiParent = Me
        Dias_Inventario.Visible = True
    End Sub

    Private Sub mnu_ingreso_incu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ingreso_incu.Click
        Try
            Con.ContadorReporte("mnu_ingreso_incu", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Ingreso.MdiParent = Me
        Ingreso.Visible = True
    End Sub

    'Private Sub mnu_reporte_incu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_reporte_incu.Click
    '    Try
    '        Con.ContadorReporte("mnu_reporte_incu", lblUsuario.Text)
    '    Catch ex As Exception
    '    End Try
    '    Reporte_Incumplimientos.MdiParent = Me
    '    Reporte_Incumplimientos.Visible = True
    'End Sub

    'Private Sub mnu_consolidado_incu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_consolidado_incu.Click
    '    Try
    '        Con.ContadorReporte("mnu_consolidado_incu", lblUsuario.Text)
    '    Catch ex As Exception
    '    End Try
    '    frmIncumplimientos_Consolidado.MdiParent = Me
    '    frmIncumplimientos_Consolidado.Visible = True
    'End Sub

    Private Sub mnu_pareto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_pareto.Click
        Try
            Con.ContadorReporte("mnu_pareto", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Pareto.MdiParent = Me
        Pareto.Visible = True
    End Sub

    Private Sub mnu_espacio_almacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_espacio_almacen.Click
        Try
            Con.ContadorReporte("mnu_espacio_almacen", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_espacio_bodega.MdiParent = Me
        frm_espacio_bodega.Visible = True
    End Sub

    Private Sub mnu_fecha_vencimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_fecha_vencimiento.Click
        Try
            Con.ContadorReporte("mnu_fecha_vencimiento", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_fechas_vencimiento.MdiParent = Me
        frm_fechas_vencimiento.Visible = True
    End Sub

    Private Sub mnu_ventas_oficina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ventas_oficina.Click
        Try
            Con.ContadorReporte("mnu_ventas_oficina", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_ventas_oficina.MdiParent = Me
        frm_ventas_oficina.Visible = True
    End Sub

    Private Sub mnu_multialmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_multialmacen.Click
        Try
            Con.ContadorReporte("mnu_multialmacen", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Multialmacen.MdiParent = Me
        Multialmacen.Visible = True
    End Sub

    Private Sub mnu_inventarios_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_inventarios_agro.Click
        Try
            Con.ContadorReporte("mnu_inventarios_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Inventarios_SR_AGRO.MdiParent = Me
        Inventarios_SR_AGRO.Visible = True
    End Sub

    Private Sub mnu_margen_reportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_margen_reportes.Click
        Try
            Con.ContadorReporte("mnu_margen_reportes", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_margenes_utilidad_producto.MdiParent = Me
        frm_margenes_utilidad_producto.Visible = True
    End Sub

    Private Sub mnu_margenes_autorizados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_margenes_autorizados.Click
        Try
            Con.ContadorReporte("mnu_margenes_autorizados", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_margenes_autorizados.MdiParent = Me
        frm_margenes_autorizados.Visible = True
    End Sub

    Private Sub mnu_ingreso_pa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ingreso_pa.Click
        Try
            Con.ContadorReporte("mnu_ingreso_pa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmProductosAveriados.MdiParent = Me
        frmProductosAveriados.Visible = True
    End Sub

    Private Sub mnu_reporte_pa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_reporte_pa.Click
        Try
            Con.ContadorReporte("mnu_reporte_pa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmReporte_Productos_Averiados.MdiParent = Me
        frmReporte_Productos_Averiados.Visible = True
    End Sub

    Private Sub mnu_ingreso_pa_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ingreso_pa_agro.Click
        Try
            Con.ContadorReporte("mnu_ingreso_pa_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmProductosAveriados_agro.MdiParent = Me
        frmProductosAveriados_agro.Visible = True
    End Sub

    Private Sub mnu_reporte_pa_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_reporte_pa_agro.Click
        Try
            Con.ContadorReporte("mnu_reporte_pa_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmReporte_Productos_Averiados_Agro.MdiParent = Me
        frmReporte_Productos_Averiados_Agro.Visible = True
    End Sub

    Private Sub mnu_ht_ingreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ht_ingreso.Click
        Try
            Con.ContadorReporte("mnu_ht_ingreso", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_horas_trabajo.MdiParent = Me
        frm_horas_trabajo.Visible = True
    End Sub

    Private Sub mnu_ht_reporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ht_reporte.Click
        Try
            Con.ContadorReporte("mnu_ht_reporte", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_reporte_horas_trabajo.MdiParent = Me
        frm_reporte_horas_trabajo.Visible = True
    End Sub

    Private Sub mnu_mc_ingreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_mc_ingreso.Click
        Try
            Con.ContadorReporte("mnu_mc_ingreso", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmMalas_cargas.MdiParent = Me
        frmMalas_cargas.Visible = True
    End Sub

    Private Sub mnu_mc_reporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_mc_reporte.Click
        Try
            Con.ContadorReporte("mnu_mc_reporte", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_reporte_malas_cargas_bodega.MdiParent = Me
        frm_reporte_malas_cargas_bodega.Visible = True
    End Sub

    Private Sub mnu_recu_ingreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_recu_ingreso.Click
        Try
            Con.ContadorReporte("mnu_recu_ingreso", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmRecurrencias.MdiParent = Me
        frmRecurrencias.Visible = True
    End Sub

    Private Sub mnu_recu_reporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_recu_reporte.Click
        Try
            Con.ContadorReporte("mnu_recu_reporte", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmReporte_Recurrencias.MdiParent = Me
        frmReporte_Recurrencias.Visible = True
    End Sub

    Private Sub mnu_sobrantes_ingreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_sobrantes_ingreso.Click
        Try
            Con.ContadorReporte("mnu_sobrantes_ingreso", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_sobrantes.MdiParent = Me
        frm_sobrantes.Visible = True
    End Sub

    Private Sub mnu_sobrantes_reporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_sobrantes_reporte.Click
        Try
            Con.ContadorReporte("mnu_sobrantes_reporte", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_reporte_sobrantes.MdiParent = Me
        frm_reporte_sobrantes.Visible = True
    End Sub

    Private Sub mnu_carga_camiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_carga_camiones.Click
        Try
            Con.ContadorReporte("mnu_carga_camiones", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_lista_carga_Camiones.MdiParent = Me
        frm_lista_carga_Camiones.Visible = True
    End Sub

    Private Sub mnu_remisiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_remisiones.Click
        Try
            Con.ContadorReporte("mnu_remisiones", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_ListaRemisiones.MdiParent = Me
        frm_ListaRemisiones.Visible = True
    End Sub

    Private Sub mnu_nacionales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_nacionales.Click
        Try
            Con.ContadorReporte("mnu_nacionales", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_nd_compras_nacionales.MdiParent = Me
        frm_nd_compras_nacionales.Visible = True
    End Sub

    Private Sub mnu_importaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_importaciones.Click
        Try
            Con.ContadorReporte("mnu_importaciones", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_lista_importaciones.MdiParent = Me
        frm_lista_importaciones.Visible = True
    End Sub

    Private Sub mnu_cargill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_cargill.Click
        Try
            Con.ContadorReporte("mnu_cargill", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_lista_compras_cargill.MdiParent = Me
        frm_lista_compras_cargill.Visible = True
    End Sub

    Private Sub mnu_orden_pedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_orden_pedido.Click
        Try
            Con.ContadorReporte("mnu_orden_pedido", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_ordenes_pedidos.MdiParent = Me
        frm_ordenes_pedidos.Visible = True
    End Sub

    Private Sub mnu_precios_neg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_precios_neg.Click
        Try
            Con.ContadorReporte("mnu_precios_neg", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_precios_negociados.usuario_id = lblId.Text
        frm_precios_negociados.usuario_name = lblUsuario.Text
        frm_precios_negociados.MdiParent = Me
        frm_precios_negociados.Visible = True
    End Sub

    Private Sub mnu_resumen_debitoscreditos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_resumen_debitoscreditos.Click
        Try
            Con.ContadorReporte("mnu_resumen_debitoscreditos", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_resumen_debitos_creditos.MdiParent = Me
        frm_resumen_debitos_creditos.Visible = True
    End Sub

    Private Sub mnu_nacionales_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_nacionales_agro.Click
        Try
            Con.ContadorReporte("mnu_nacionales_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_nd_compras_nacionales_sragro.MdiParent = Me
        frm_nd_compras_nacionales_sragro.Visible = True
    End Sub

    Private Sub mnu_importaciones_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_importaciones_agro.Click
        Try
            Con.ContadorReporte("mnu_importaciones_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_lista_importaciones_sragro.MdiParent = Me
        frm_lista_importaciones_sragro.Visible = True
    End Sub

    Private Sub mnu_cargill_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_cargill_agro.Click
        Try
            Con.ContadorReporte("mnu_cargill_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_lista_compras_cargill_sragro.MdiParent = Me
        frm_lista_compras_cargill_sragro.Visible = True
    End Sub

    Private Sub PreciosNegociadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_precios_neg_agro.Click
        Try
            Con.ContadorReporte("mnu_precios_neg_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_precios_negociados_sragro.usuario_id = lblId.Text
        frm_precios_negociados_sragro.usuario_name = lblUsuario.Text
        frm_precios_negociados_sragro.MdiParent = Me
        frm_precios_negociados_sragro.Visible = True
    End Sub

    Private Sub mnu_pdse_ventasproducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_pdse_ventasproducto.Click
        Try
            Con.ContadorReporte("mnu_pdse_ventasproducto", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Ventas_Totales_Producto.MdiParent = Me
        Ventas_Totales_Producto.Visible = True
    End Sub

    Private Sub mnu_pdse_ventascliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_pdse_ventascliente.Click
        Try
            Con.ContadorReporte("mnu_pdse_ventascliente", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Ventas_Totales_Cliente.MdiParent = Me
        Ventas_Totales_Cliente.Visible = True
    End Sub

    Private Sub mnu_pdsecxc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_pdsecxc.Click
        Try
            Con.ContadorReporte("mnu_pdsecxc", lblUsuario.Text)
        Catch ex As Exception
        End Try
        CuentasxCobrar.MdiParent = Me
        CuentasxCobrar.Visible = True
    End Sub

    Private Sub mnu_sc_linea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_sc_linea.Click
        Try
            Con.ContadorReporte("mnu_sc_linea", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Sell_in_Cargill_det.MdiParent = Me
        Sell_in_Cargill_det.Visible = True
    End Sub

    Private Sub mnu_sc_general_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_sc_general.Click
        Try
            Con.ContadorReporte("mnu_sc_general", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Sell_Incargill.MdiParent = Me
        Sell_Incargill.Visible = True
    End Sub

    Private Sub mnu_bonificaciones_ventas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_bonificaciones_ventas.Click
        Try
            Con.ContadorReporte("mnu_bonificaciones_ventas", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Frm_Bonificaciones_Nuevo.Close()
        Frm_Bonificaciones_Nuevo.Show()
        'FlushMemory()
    End Sub

    Private Sub mnu_usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_usuarios.Click
        Try
            Con.ContadorReporte("mnu_usuarios", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Usuarios.MdiParent = Me
        Usuarios.Visible = True
    End Sub

    Private Sub mnu_envios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_envios.Click
        Try
            Con.ContadorReporte("mnu_envios", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Envios.MdiParent = Me
        Envios.Visible = True
    End Sub

    Private Sub mnu_presupuestos_ventas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_presupuestos_ventas.Click
        Try
            Con.ContadorReporte("mnu_presupuestos_ventas", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Presupuesto.MdiParent = Me
        Presupuesto.Visible = True
    End Sub

    Private Sub mnu_pres_dest_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_pres_dest_disar.Click
        Try
            Con.ContadorReporte("mnu_pres_dest_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_presupuestos_des_tac.MdiParent = Me
        frm_presupuestos_des_tac.Visible = True
    End Sub

    Private Sub mnu_pres_destac_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_pres_destac_agro.Click
        Try
            Con.ContadorReporte("mnu_pres_destac_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_presupuestos_des_tac_sragro.MdiParent = Me
        frm_presupuestos_des_tac_sragro.Visible = True
    End Sub

    Private Sub mnu_comisiones_consolidado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_comisiones_consolidado.Click
        Try
            Con.ContadorReporte("mnu_comisiones_consolidado", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Comisiones.MdiParent = Me
        Comisiones.Visible = True
    End Sub

    Private Sub mnu_comisiones_detallado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_comisiones_detallado.Click
        Try
            Con.ContadorReporte("mnu_comisiones_detallado", lblUsuario.Text)
        Catch ex As Exception
        End Try
        comisiones_detallado.MdiParent = Me
        comisiones_detallado.Visible = True
    End Sub

    Private Sub mnu_ventas_diarias_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ventas_diarias_agro.Click
        Try
            Con.ContadorReporte("mnu_ventas_diarias_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        VentasDiariasAgro.MdiParent = Me
        VentasDiariasAgro.Visible = True
    End Sub

    Private Sub mnu_quintales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_quintales.Click
        Try
            Con.ContadorReporte("mnu_quintales", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Reporte_de_Quintales.MdiParent = Me
        Reporte_de_Quintales.Visible = True
    End Sub

    Private Sub mnu_quintales_mensuales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_quintales_mensuales.Click
        Try
            Con.ContadorReporte("mnu_quintales_mensuales", lblUsuario.Text)
        Catch ex As Exception
        End Try
        QuintalesMen.MdiParent = Me
        QuintalesMen.Visible = True
    End Sub

    Private Sub mnu_tecno_supplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_tecno_supplier.Click
        Try
            Con.ContadorReporte("mnu_tecno_supplier", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmTecnoSupplier.MdiParent = Me
        frmTecnoSupplier.Visible = True
    End Sub

    Private Sub mnu_ventas_proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ventas_proveedor.Click
        Try
            Con.ContadorReporte("mnu_ventas_proveedor", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmVentasProveedorAgro.MdiParent = Me
        frmVentasProveedorAgro.Visible = True
    End Sub

    Private Sub mnu_rg_general_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_rg_general.Click
        Try
            Con.ContadorReporte("mnu_rg_general", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Resumen.MdiParent = Me
        Resumen.Visible = True
    End Sub

    Private Sub mnu_rent_proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_rent_proveedor.Click
        Try
            Con.ContadorReporte("mnu_rent_proveedor", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Rentabilidad.MdiParent = Me
        Rentabilidad.Visible = True
    End Sub

    Private Sub mnu_renta_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_renta_producto.Click
        Try
            Con.ContadorReporte("mnu_renta_producto", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Rentabilidad_por_Producto.MdiParent = Me
        Rentabilidad_por_Producto.Visible = True
    End Sub

    Private Sub mnu_ventas_promedio_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ventas_promedio_disar.Click
        Try
            Con.ContadorReporte("mnu_ventas_promedio_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        VentasPromedio.MdiParent = Me
        VentasPromedio.Visible = True
    End Sub

    Private Sub mnu_reporte_8020_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_reporte_8020.Click
        Try
            Con.ContadorReporte("mnu_reporte_8020", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Reporte_80_20.MdiParent = Me
        Reporte_80_20.Visible = True
    End Sub



    Private Sub mnu_coberturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_coberturas.Click
        Try
            Con.ContadorReporte("mnu_coberturas", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Cobertura.Visible = True
    End Sub

    Private Sub mnu_ventas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ventas.Click
        Try
            Con.ContadorReporte("mnu_ventas", lblUsuario.Text)
        Catch ex As Exception
        End Try
        VentasporProveedor.MdiParent = Me
        VentasporProveedor.Visible = True
    End Sub

    Private Sub mnu_general_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_general.Click
        Try
            Con.ContadorReporte("mnu_general", lblUsuario.Text)
        Catch ex As Exception
        End Try
        General.MdiParent = Me
        General.Visible = True
    End Sub

    Private Sub mnu_archivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_archivos.Click
        Try
            Con.ContadorReporte("mnu_archivos", lblUsuario.Text)
        Catch ex As Exception
        End Try
        SellOut_Colgate_Archivos.Visible = True
    End Sub

    Private Sub mnu_alcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_alcon.Click
        Try
            Con.ContadorReporte("mnu_alcon", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmSellOutMascotas.MdiParent = Me
        frmSellOutMascotas.Visible = True
    End Sub

    Private Sub mnu_colombina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_colombina.Click
        Try
            Con.ContadorReporte("mnu_colombina", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_sell_out_colombina.MdiParent = Me
        frm_sell_out_colombina.Visible = True
    End Sub

    Private Sub mnu_cajas_livsmart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_cajas_livsmart.Click
        Try
            Con.ContadorReporte("mnu_cajas_livsmart", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Cajas.MdiParent = Me
        Cajas.Visible = True
    End Sub

    Private Sub mnu_quala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_quala.Click
        Try
            Con.ContadorReporte("mnu_quala", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Quala.MdiParent = Me
        Quala.Visible = True
    End Sub

    Private Sub mnu_sg_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_sg_disar.Click
        Try
            Con.ContadorReporte("mnu_sg_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_sell_out_general.MdiParent = Me
        frm_sell_out_general.Visible = True
    End Sub

    Private Sub mnu_sg_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_sg_agro.Click
        Try
            Con.ContadorReporte("mnu_sg_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_sell_out_general_sr_agro.MdiParent = Me
        frm_sell_out_general_sr_agro.Visible = True
    End Sub

    Private Sub mnu_diaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_diaria.Click
        Try
            Con.ContadorReporte("mnu_diaria", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Efectividad.Visible = True
    End Sub

    Private Sub mnu_rango_fechas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_rango_fechas.Click
        Try
            Con.ContadorReporte("mnu_rango_fechas", lblUsuario.Text)
        Catch ex As Exception
        End Try
        EfectividadRangoFechas.Visible = True
    End Sub

    Private Sub mnu_ventas_diarias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ventas_diarias.Click
        Try
            Con.ContadorReporte("mnu_ventas_diarias", lblUsuario.Text)
        Catch ex As Exception
        End Try
        VentasDiarias2.MdiParent = Me
        VentasDiarias2.Visible = True
    End Sub

    Private Sub mnu_contado_credito_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_contado_credito_disar.Click
        Try
            Con.ContadorReporte("mnu_contado_credito_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_reporte_contado_credito.MdiParent = Me
        frm_reporte_contado_credito.Visible = True
    End Sub

    Private Sub mnu_contado_credito_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_contado_credito_agro.Click
        Try
            Con.ContadorReporte("mnu_contado_credito_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_reporte_contado_credito_sragro.MdiParent = Me
        frm_reporte_contado_credito_sragro.Visible = True
    End Sub

    Private Sub mnu_resumen_debcred_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_resumen_debcred_agro.Click
        Try
            Con.ContadorReporte("mnu_resumen_debcred_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_resumen_debitos_creditos_sragro.MdiParent = Me
        frm_resumen_debitos_creditos_sragro.Visible = True
    End Sub

    Private Sub mnu_bitacora_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_bitacora_disar.Click
        Try
            Con.ContadorReporte("mnu_bitacora_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmConsulta_Bitacora.MdiParent = Me
        frmConsulta_Bitacora.Visible = True
    End Sub

    Private Sub mnu_bitacora_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_bitacora_agro.Click
        Try
            Con.ContadorReporte("mnu_bitacora_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_bitacora_sragro.MdiParent = Me
        frm_bitacora_sragro.Visible = True
    End Sub

    Private Sub mnu_ingreso_dev_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ingreso_dev_disar.Click
        Try
            Con.ContadorReporte("mnu_ingreso_dev_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_lista_devoluciones.MdiParent = Me
        frm_lista_devoluciones.Visible = True
    End Sub

    Private Sub mnu_recepcion_dev_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_recepcion_dev_disar.Click
        Try
            Con.ContadorReporte("mnu_recepcion_dev_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_panel_almacen_devoluciones.MdiParent = Me
        frm_panel_almacen_devoluciones.Visible = True
    End Sub

    Private Sub mnu_devoluciones_nc_Disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_devoluciones_nc_Disar.Click
        Try
            Con.ContadorReporte("mnu_devoluciones_nc_Disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Devoluciones_Notas_De_Credito.MdiParent = Me
        Devoluciones_Notas_De_Credito.Visible = True
    End Sub

    Private Sub mnu_devoluciones_nc_SRAGRO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_devoluciones_nc_SRAGRO.Click
        Try
            Con.ContadorReporte("mnu_devoluciones_nc_SRAGRO", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Devoluciones_Notas_De_Credito_SRAGRO.MdiParent = Me
        Devoluciones_Notas_De_Credito_SRAGRO.Visible = True
    End Sub

    Private Sub btn_bitacora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bitacora.Click
        Try
            Con.ContadorReporte("btn_bitacora", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_listar_bitacora.MdiParent = Me
        frm_listar_bitacora.Visible = True
    End Sub

    Private Sub mnu_sell_out_quintales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_sell_out_quintales.Click
        Try
            Con.ContadorReporte("mnu_sell_out_quintales", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_sell_out_quintales.MdiParent = Me
        frm_sell_out_quintales.Visible = True
    End Sub

    Private Sub mnu_plan_carga_monitoreo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_control_monitoreo.Click
        Try
            Con.ContadorReporte("mnu_control_monitoreo", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_control_monitoreo.MdiParent = Me
        frm_control_monitoreo.Visible = True
    End Sub

    Private Sub SRAGROToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_resumen_costos_disar.Click
        Try
            Con.ContadorReporte("mnu_resumen_costos_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_Resumen_Costos.MdiParent = Me
        frm_Resumen_Costos.Visible = True
    End Sub

    Private Sub mnu_resumen_costos_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_resumen_costos_agro.Click
        Try
            Con.ContadorReporte("mnu_resumen_costos_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_Resumen_Costos_Agro.MdiParent = Me
        frm_Resumen_Costos_Agro.Visible = True
    End Sub

    'Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, _
    '                            ByVal maximumWorkingSetSize As Integer) As Integer

    'Public Shared Sub FlushMemory()
    '    Try
    '        GC.Collect()
    '        GC.WaitForPendingFinalizers()
    '        If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
    '            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub mnu_resumen_devoluciones_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles mnu_resumen_devoluciones_disar.Click
        Try
            Con.ContadorReporte("mnu_resumen_devoluciones_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_reporte_devoluciones.MdiParent = Me
        frm_reporte_devoluciones.Visible = True
    End Sub

    Private Sub mnu_orden_compra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_orden_compra.Click
        Try
            Con.ContadorReporte("mnu_orden_compra", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_orden_pedidos_sragro.MdiParent = Me
        frm_orden_pedidos_sragro.Visible = True
    End Sub

    Private Sub mnu_tasa_cambiariaD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_tasa_cambiariaD.Click
        Try
            Con.ContadorReporte("mnu_tasa_cambiariaD", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_tasa_cambiaria.MdiParent = Me
        frm_tasa_cambiaria.Visible = True
    End Sub

    Private Sub mnu_tasa_cambiariaSR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_tasa_cambiariaSR.Click
        Try
            Con.ContadorReporte("mnu_tasa_cambiariaSR", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_tasa_cambiaria_sragro.MdiParent = Me
        frm_tasa_cambiaria_sragro.Visible = True
    End Sub

    Private Sub PerfilDeClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Perfil_De_Cliente.Click
        Try
            Con.ContadorReporte("mnu_Perfil_De_Cliente", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If Clientes_Agro.Visible = False Then
            Clientes_Agro.MdiParent = Me
            Clientes_Agro.Visible = True
        Else
            Clientes_Agro.BringToFront()
        End If

    End Sub

    Private Sub SrAgroToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_existenciascostosAgro.Click
        Try
            Con.ContadorReporte("mnu_existenciascostosAgro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Existencias_Costos_Agro.MdiParent = Me
        Existencias_Costos_Agro.Visible = True
    End Sub

    Private Sub DisarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_existenciascostosDisar.Click
        Try
            Con.ContadorReporte("mnu_existenciascostosDisar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Existencias_Costos_Consumo.MdiParent = Me
        Existencias_Costos_Consumo.Visible = True
    End Sub

    Private Sub mnu_dev_nacionales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_dev_nacionales.Click
        Try
            Con.ContadorReporte("mnu_dev_nacionales", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_dev_compras_devolucion.MdiParent = Me
        frm_dev_compras_devolucion.Visible = True
    End Sub

    Private Sub mnu_dev_importaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_dev_importaciones.Click
        Try
            Con.ContadorReporte("mnu_dev_importaciones", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_dev_compras_lista.MdiParent = Me
        frm_dev_compras_lista.Visible = True
    End Sub

    Private Sub mnu_dev_nac_sr_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_dev_nac_sr_agro.Click
        Try
            Con.ContadorReporte("mnu_dev_nac_sr_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_dev_compras_devolucion_sr_agro.MdiParent = Me
        frm_dev_compras_devolucion_sr_agro.Visible = True
    End Sub

    Private Sub mnu_dev_imp_sr_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_dev_imp_sr_agro.Click
        Try
            Con.ContadorReporte("mnu_dev_imp_sr_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_dev_compras_lista_sr_agro.MdiParent = Me
        frm_dev_compras_lista_sr_agro.Visible = True
    End Sub

    Private Sub TrasladoDePromocionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_promociones.Click
        Try
            Con.ContadorReporte("mnu_promociones", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If frmPromociones_Principal.Visible = True Then
            frmPromociones_Principal.BringToFront()
        Else
            frmPromociones_Principal.MdiParent = Me
            frmPromociones_Principal.Show()
        End If

    End Sub


    Private Sub ChequesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Cheques.Click
        Try
            Con.ContadorReporte("mnu_Cheques", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmChequesPrincipal.Visible = True Then
            FrmChequesPrincipal.BringToFront()
        Else
            FrmChequesPrincipal.MdiParent = Me
            FrmChequesPrincipal.Show()
        End If
    End Sub

    Private Sub mnu_Clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Clientes.Click
        Try
            Con.ContadorReporte("mnu_Clientes", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmClientesVenta.Visible = True Then
            FrmClientesVenta.BringToFront()
        Else
            FrmClientesVenta.MdiParent = Me
            FrmClientesVenta.Show()
        End If
    End Sub

    Private Sub mnu_Cumple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Cumple.Click
        Try
            Con.ContadorReporte("mnu_Cumple", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmClientesPareto.Visible = True Then
            FrmClientesPareto.BringToFront()
        Else
            FrmClientesPareto.MdiParent = Me
            FrmClientesPareto.Show()
        End If
    End Sub

    Private Sub mnu_reporte_carga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_reportecarga.Click
        Try
            Con.ContadorReporte("mnu_reportecarga", lblUsuario.Text)
        Catch ex As Exception
        End Try
        ReporteCarga_valorCero.MdiParent = Me
        ReporteCarga_valorCero.Visible = True
    End Sub

    Private Sub mnu_reportecarga_liq_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_reportecarga_liq.Click
        Try
            Con.ContadorReporte("mnu_reportecarga_liq", lblUsuario.Text)
        Catch ex As Exception
        End Try
        ReporteCarga.MdiParent = Me
        ReporteCarga.Visible = True
    End Sub

    Private Sub mnu_reportecarga_acum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_reportecarga_acum.Click
        Try
            Con.ContadorReporte("mnu_reportecarga_acum", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_reporte_carga_acumulado.MdiParent = Me
        frm_reporte_carga_acumulado.Visible = True
    End Sub

    Private Sub mnu_Bita_Eventos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Bita_Eventos.Click
        Try
            Con.ContadorReporte("mnu_Bita_Eventos", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmBitacoraEventos.Visible = True Then
            FrmBitacoraEventos.BringToFront()
        Else
            FrmBitacoraEventos.MdiParent = Me
            FrmBitacoraEventos.Show()
        End If
    End Sub

    Private Sub CentroDeMantenimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_CentroDeMantenimiento.Click
        Try
            Con.ContadorReporte("mnu_CentroDeMantenimiento", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmCentro_Mantenimiento.Visible = True Then
            FrmCentro_Mantenimiento.BringToFront()
        Else
            FrmCentro_Mantenimiento.MdiParent = Me
            FrmCentro_Mantenimiento.Show()
        End If
    End Sub

    Private Sub mnu_IngresoAgro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_IngresoAgro.Click
        Try
            Con.ContadorReporte("mnu_IngresoAgro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmRegistroAgro.Visible = True Then
            FrmRegistroAgro.BringToFront()
        Else
            FrmRegistroAgro.MdiParent = Me
            FrmRegistroAgro.Show()
        End If
    End Sub

    Private Sub mnu_SolicitudesMantenimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_SolicitudesMantenimiento.Click
        Try
            Con.ContadorReporte("mnu_SolicitudesMantenimiento", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If Frm_SolicitudesMantenimiento.Visible = True Then
            Frm_SolicitudesMantenimiento.BringToFront()
        Else
            Frm_SolicitudesMantenimiento.MdiParent = Me
            Frm_SolicitudesMantenimiento.Show()
        End If
    End Sub

    Private Sub mnu_RutaLogica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_RutaLogica.Click
        Try
            Con.ContadorReporte("mnu_RutaLogica", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If Frm_RutaLogica.Visible = True Then
            Frm_RutaLogica.BringToFront()
        Else
            Frm_RutaLogica.MdiParent = Me
            Frm_RutaLogica.Show()
        End If
    End Sub

    Private Sub RegistroDeUsoDeVehículoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_RegistroVehiculo.Click
        Try
            Con.ContadorReporte("mnu_RegistroVehiculo", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Try
            Frm_RegistroVehiculo.Genera = "U"
        Catch ex As Exception
        End Try
        If Frm_RegistroVehiculo.Visible = True Then
            Frm_RegistroVehiculo.BringToFront()
        Else
            Frm_RegistroVehiculo.MdiParent = Me
            Frm_RegistroVehiculo.Show()
        End If
    End Sub

    Private Sub ControlDeAccidentesLaboralesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_accidentesLaborales.Click
        Try
            Con.ContadorReporte("mnu_accidentesLaborales", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If Frm_AccidentesLaborales.Visible = True Then
            Frm_AccidentesLaborales.BringToFront()
        Else
            Frm_AccidentesLaborales.MdiParent = Me
            Frm_AccidentesLaborales.Show()
        End If
    End Sub

    Private Sub ReporteDumbar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDumbar.Click
        Try
            Con.ContadorReporte("ReporteDumbar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If ReporteCarga_Dumbar.Visible = True Then
            ReporteCarga_Dumbar.BringToFront()
        Else
            ReporteCarga_Dumbar.MdiParent = Me
            ReporteCarga_Dumbar.Show()
        End If
    End Sub

    Private Sub mnu_PedidosPorZona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_PedidosPorZona.Click
        Try
            Con.ContadorReporte("mnu_PedidosPorZona", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmArmadoRutas.Visible = True Then
            FrmArmadoRutas.BringToFront()
        Else
            FrmArmadoRutas.MdiParent = Me
            FrmArmadoRutas.Show()
        End If
    End Sub

    Private Sub InventarioITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_InventarioIT.Click
        Try
            Con.ContadorReporte("mnu_InventarioIT", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmInventarioIT.Visible = True Then
            FrmInventarioIT.BringToFront()
        Else
            FrmInventarioIT.MdiParent = Me
            FrmInventarioIT.Show()
        End If
    End Sub

    Private Sub mnu_CreaciónDeClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_CreaciónDeClientes.Click
        Try
            Con.ContadorReporte("mnu_CreaciónDeClientes", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If frm_CreacionDeClientes.Visible = True Then
            frm_CreacionDeClientes.BringToFront()
        Else
            frm_CreacionDeClientes.MdiParent = Me
            frm_CreacionDeClientes.Show()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.sanrafaelhn.com")
    End Sub

    Private Sub FacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasToolStripMenuItem.Click
        Try
            Con.ContadorReporte("FacturasToolStripMenuItem", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If Frm_Efectividad.Visible = False Then
            Frm_Efectividad.MdiParent = Me
            Frm_Efectividad.Show()
        Else
            Frm_Efectividad.BringToFront()
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolucionesMenuItem2.Click
        Try
            Con.ContadorReporte("DevolucionesMenuItem2", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmEfectividadDevol.Visible = False Then
            FrmEfectividadDevol.MdiParent = Me
            FrmEfectividadDevol.Show()
        Else
            FrmEfectividadDevol.BringToFront()
        End If
    End Sub

    Private Sub Consignaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Consignaciones.Click
        Try
            Con.ContadorReporte("Consignaciones", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If Frm_ListaConsignaciones.Visible = False Then
            Frm_ListaConsignaciones.MdiParent = Me
            Frm_ListaConsignaciones.Show()
        Else
            Frm_ListaConsignaciones.BringToFront()
        End If
    End Sub

    Private Sub mnu_ventas_por_categoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ventas_por_categoria.Click
        Try
            Con.ContadorReporte("mnu_ventas_por_categoria", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If frm_Ventas_Categoria.Visible = False Then
            frm_Ventas_Categoria.MdiParent = Me
            frm_Ventas_Categoria.Show()
        Else
            frm_Ventas_Categoria.BringToFront()
        End If
    End Sub

    Private Sub mnu_HorasTrabajadasComercial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_HorasTrabajadasComercial.Click
        Try
            Con.ContadorReporte("mnu_HorasTrabajadasComercial", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmHorasTrabajoComercial.Visible = False Then
            FrmHorasTrabajoComercial.MdiParent = Me
            FrmHorasTrabajoComercial.Show()
        Else
            FrmHorasTrabajoComercial.BringToFront()
        End If
    End Sub

    Private Sub mnuDocumentosFiscales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDocumentosFiscales.Click
        Try
            Con.ContadorReporte("mnuDocumentosFiscales", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmDocumentosFiscales.Visible = False Then
            FrmDocumentosFiscales.MdiParent = Me
            FrmDocumentosFiscales.Show()
        Else
            FrmDocumentosFiscales.BringToFront()
        End If
    End Sub

    Private Sub ControlDeReunionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_controlReuniones.Click
        Try
            Con.ContadorReporte("mnu_controlReuniones", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FormReunionesPrincipal.Visible = False Then
            FormReunionesPrincipal.MdiParent = Me
            FormReunionesPrincipal.Show()
        Else
            FormReunionesPrincipal.BringToFront()
        End If
    End Sub

    Private Sub BiométricoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBiometricos.Click
        Try
            Con.ContadorReporte("mnuBiometricos", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If frmSRC.Visible = True Then
            frmSRC.BringToFront()
        Else
            frmSRC.MdiParent = Me
            frmSRC.Show()
        End If
    End Sub

    Private Sub mnuReporteMatinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReporteMatinal.Click
        Try
            Con.ContadorReporte("mnuReporteMatinal", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmReporteMatinal.Visible = True Then
            FrmReporteMatinal.BringToFront()
        Else
            FrmReporteMatinal.MdiParent = Me
            FrmReporteMatinal.Show()
        End If
    End Sub

    Private Sub mnu_cobertura_sragro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cobertura_sr_agro.Visible = True
    End Sub

    Private Sub mnu_clientes_sr_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Con.ContadorReporte("mnuReporteMatinal", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmClientesVenta_sr_agro.Visible = True Then
            FrmClientesVenta_sr_agro.BringToFront()
        Else
            FrmClientesVenta_sr_agro.MdiParent = Me
            FrmClientesVenta_sr_agro.Show()
        End If
    End Sub

    Private Sub mnu_clientes_sr_agro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_clientes_sr_agro.Click
        Try
            Con.ContadorReporte("mnu_clientes_sr_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmClientesVenta_sr_agro.Visible = True Then
            FrmClientesVenta_sr_agro.BringToFront()
        Else
            FrmClientesVenta_sr_agro.MdiParent = Me
            FrmClientesVenta_sr_agro.Show()
        End If
    End Sub

    Private Sub mnu_cobertura_sragro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_cobertura_sragro.Click
        Try
            Con.ContadorReporte("mnu_cobertura_sragro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Cobertura_sr_agro.Visible = True
    End Sub

    Private Sub mnu_diaria_sr_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_diaria_sr_agro.Click
        Try
            Con.ContadorReporte("mnu_diaria_sr_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Efectividad_sr_agro.Visible = True
    End Sub

    Private Sub mnu_rango_fechas_sr_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_rango_fechas_sr_agro.Click
        Try
            Con.ContadorReporte("mnu_rango_fechas_sr_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        EfectividadRangoFechas_sr_agro.Visible = True
    End Sub

    Private Sub LiquidaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLiquidacion.Click
        Try
            Con.ContadorReporte("mnuLiquidacion", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If frmLiquidacion.Visible = True Then
            frmLiquidacion.BringToFront()
        Else
            frmLiquidacion.MdiParent = Me
            frmLiquidacion.Show()
        End If
    End Sub

    Private Sub UsuariosConectadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUsuariosConectados.Click
        Try
            Con.ContadorReporte("mnuUsuariosConectados", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If UsuariosConectados.Visible = True Then
            UsuariosConectados.BringToFront()
        Else
            UsuariosConectados.MdiParent = Me
            UsuariosConectados.Show()
        End If
    End Sub

    Private Sub ComisionesParaEntregadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuComisionesEntregador.Click
        Try
            Con.ContadorReporte("mnuComisionesEntregador", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If frmComisionesEntregadores.Visible = True Then
            frmComisionesEntregadores.BringToFront()
        Else
            frmComisionesEntregadores.MdiParent = Me
            frmComisionesEntregadores.Show()
        End If
    End Sub

    Private Sub mnuKardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuKardex.Click
        Try
            Con.ContadorReporte("mnuKardex", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FormKardex.Visible = True Then
            FormKardex.BringToFront()
        Else
            FormKardex.MdiParent = Me
            FormKardex.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Tiempo += 1
        Dim Activo As Boolean = True
        If Tiempo = 30 Then

            'Try
            '    Dim S As Boolean
            '    BindToRunningProcesses()
            '    S = Con.ActualizarContadores(lblUsuario.Text, SAE, COI, NOI, BAN, IP)
            'Catch ex As Exception
            'End Try

            Dim dt As New DataTable
            Try
                dt.Rows.Clear()
            Catch ex As Exception
            End Try
            dt = Con.Actualizando()
            If dt.Rows.Count > 0 Then
                Tiempo = 0
            Else
                Activo = False
                'MsgBox("Se está realizando una actualización de sistema. Favor re ingrese en unos minutos.", MsgBoxStyle.Information, "Atención")
                Shell("taskkill /F /IM Disar.exe /T", 0)
            End If
        End If
        'If Tiempo = 16 And Activo = False Then
        '    Shell("taskkill /F /IM Disar.exe /T", 0)
        'End If
    End Sub

    Private Sub IngresoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIngresoDevAgro.Click
        Try
            Con.ContadorReporte("mnuIngresoDevAgro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_lista_devoluciones_agro.MdiParent = Me
        frm_lista_devoluciones_agro.Visible = True
    End Sub

    Private Sub RecepciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRecepcionDevAgro.Click
        Try
            Con.ContadorReporte("MnuRecepcionDevAgro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_panel_almacen_devolucione_SrAgro.MdiParent = Me
        frm_panel_almacen_devolucione_SrAgro.Visible = True
    End Sub

    Private Sub ResumenDevolucionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResumenDevAgro.Click
        Try
            Con.ContadorReporte("mnuResumenDevAgro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_reporte_devoluciones_SRAgro.MdiParent = Me
        frm_reporte_devoluciones_SRAgro.Visible = True
    End Sub

    Private Sub ContadorDeReportesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContadorDeReportesToolStripMenuItem.Click
        Try
            Con.ContadorReporte("ContadorDeReportesToolStripMenuItem", lblUsuario.Text)
        Catch ex As Exception
        End Try
        ContadorAccesos.MdiParent = Me
        ContadorAccesos.Visible = True
    End Sub

    Private Sub mnu_CargaPresupuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_CargaPresupuestos.Click
        Try
            Con.ContadorReporte("mnu_CargaPresupuestos", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_CargaProductoMatinal.MdiParent = Me
        frm_CargaProductoMatinal.Visible = True
    End Sub

    Private Sub mnuMatinalAgro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMatinalAgro.Click
        Try
            Con.ContadorReporte("mnuMatinalAgro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        FrmMatinalAgro.Tipo = "Matinal"
        If FrmMatinalAgroNueva.Visible = True Then
            FrmMatinalAgro.BringToFront()
        Else
            FrmMatinalAgro.MdiParent = Me
            FrmMatinalAgro.Show()
        End If
    End Sub

    Private Sub mnuPresupuestosAgroMatinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPresupuestosAgroMatinal.Click
        Try
            Con.ContadorReporte("mnuPresupuestosAgroMatinal", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmPresupuestosAgroMatinal.Visible = True Then
            FrmPresupuestosAgroMatinal.BringToFront()
        Else
            FrmPresupuestosAgroMatinal.MdiParent = Me
            FrmPresupuestosAgroMatinal.Show()
        End If
    End Sub

    Private Sub mnu_liquidaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_liquidaciones.Click
        Try
            Con.ContadorReporte("mnu_liquidaciones", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmLiquidacionesGuardadas.Visible = True Then
            FrmLiquidacionesGuardadas.BringToFront()
        Else
            FrmLiquidacionesGuardadas.MdiParent = Me
            FrmLiquidacionesGuardadas.Show()
        End If
    End Sub

    Private Sub mnu_devoluciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_devoluciones.Click
        Try
            Con.ContadorReporte("mnu_devoluciones", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_devoluciones.MdiParent = Me
        frm_devoluciones.Show()
    End Sub

    Private Sub mnu_NC_por_descuento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_NC_por_descuento.Click
        Try
            Con.ContadorReporte("mnu_NC_por_descuento", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_nc_por_desc.MdiParent = Me
        frm_nc_por_desc.Show()
    End Sub

    Private Sub mnu_CierreVentasAgro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_CierreVentasAgro.Click
        Try
            Con.ContadorReporte("mnu_CierreVentasAgro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If FrmMatinalAgro.Visible = True Then
            FrmMatinalAgro.BringToFront()
        Else
            FrmMatinalAgro.MdiParent = Me
            FrmMatinalAgro.Show()
        End If
        FrmMatinalAgro.Tipo = "Diario"
    End Sub

    Private Sub DepósitosDeLiquidacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_depositos.Click
        Try
            Con.ContadorReporte("mnu_depositos", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If EnvioDepositos.Visible = True Then
            EnvioDepositos.BringToFront()
        Else
            EnvioDepositos.MdiParent = Me
            EnvioDepositos.Show()
        End If
    End Sub

    Private Sub mnu_sell_out_nestle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_sell_out_nestle.Click
        Try
            Con.ContadorReporte("mnu_sell_out_nestle", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_sell_out_nestle.MdiParent = Me
        frm_sell_out_nestle.Visible = True
    End Sub

    Private Sub mnu_punto_reorden_detalle_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_punto_reorden_detalle_disar.Click
        Try
            Con.ContadorReporte("mnu_punto_reorden", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_punto_reorden.Close()
        frm_punto_reorden.ShowDialog()
    End Sub

    Private Sub mnu_punto_reorden_detalle_sr_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_punto_reorden_detalle_sr_agro.Click
        Try
            Con.ContadorReporte("mnu_punto_reorden_sr_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_punto_reorden_sr_agro.Close()
        frm_punto_reorden_sr_agro.MdiParent = Me
        frm_punto_reorden_sr_agro.Show()
    End Sub

    Private Sub mnu_punto_reorden_resumen_disar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_punto_reorden_resumen_disar.Click
        Try
            Con.ContadorReporte("mnu_punto_reorden__resumen_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_punto_reorden_detalle.Close()
        frm_punto_reorden_detalle.ShowDialog()
    End Sub

    Private Sub mnu_resumen_punto_reorden_sr_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_resumen_punto_reorden_sr_agro.Click
        Try
            Con.ContadorReporte("mnu_punto_reorden_sr_agro_resumen", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_punto_reorden_sr_agro_detalle.Close()
        frm_punto_reorden_sr_agro_detalle.MdiParent = Me
        frm_punto_reorden_sr_agro_detalle.Show()
    End Sub

    Private Sub mnu_cobertura_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_cobertura_producto.Click
        Try
            Con.ContadorReporte("mnu_cobertura_producto", lblUsuario.Text)
        Catch ex As Exception
        End Try
        CoberturaProducto.Close()
        CoberturaProducto.MdiParent = Me
        CoberturaProducto.Show()
    End Sub

    Private Sub mnu_resumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_resumen.Click
        Try
            Con.ContadorReporte("mnu_resumen", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_ResumenDiario.Close()
        frm_ResumenDiario.MdiParent = Me
        frm_ResumenDiario.Show()
    End Sub
 
    
    Private Sub mnu_reporte_cobros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_reporte_cobros.Click
        Try
            Con.ContadorReporte("mnu_reporte_cobros", lblUsuario.Text)
        Catch ex As Exception
        End Try
        FormCobros.Close()
        FormCobros.MdiParent = Me
        FormCobros.Show()
    End Sub

 
    Private Sub mnu_auditar_promociones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_auditar_promociones.Click
        Try
            Con.ContadorReporte("mnu_auditar_promociones", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_auditoria_promos.Close()
        frm_auditoria_promos.MdiParent = Me
        frm_auditoria_promos.Show()
    End Sub

    Private Sub NuevoProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_nuevo_proveedor.Click
        Try
            Con.ContadorReporte("mnu_nuevo_proveedor", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_agregar_proveedores.Close()
        frm_agregar_proveedores.MdiParent = Me
        frm_agregar_proveedores.Show()
    End Sub

    Private Sub mnu_nuevo_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_nuevo_producto.Click
        Try
            Con.ContadorReporte("mnu_nuevo_producto", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_agregar_productos.Close()
        frm_agregar_productos.MdiParent = Me
        frm_agregar_productos.Show()
    End Sub

     
    Private Sub mnu_devoluciones_nc_DIMOSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_devoluciones_nc_DIMOSA.Click
        Try
            Con.ContadorReporte("mnu_devoluciones_nc_DIMOSA", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Devoluciones_Notas_De_Credito_DIMOSA.MdiParent = Me
        Devoluciones_Notas_De_Credito_DIMOSA.Visible = True
    End Sub

    
    Private Sub mnuIngresoDevDIMOSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIngresoDevDIMOSA.Click
        Try
            Con.ContadorReporte("mnuIngresoDevDIMOSA", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_lista_devoluciones_dimosa.MdiParent = Me
        frm_lista_devoluciones_dimosa.Visible = True
    End Sub

    Private Sub MnuRecepcionDevDIMOSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRecepcionDevDIMOSA.Click
        Try
            Con.ContadorReporte("MnuRecepcionDevDIMOSA", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_panel_almacen_devoluciones_dimosa.MdiParent = Me
        frm_panel_almacen_devoluciones_dimosa.Visible = True
    End Sub

    Private Sub mnuResumenDevDIMOSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResumenDevDIMOSA.Click
        Try
            Con.ContadorReporte("mnuResumenDevDIMOSA", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_reporte_devoluciones_dimosa.MdiParent = Me
        frm_reporte_devoluciones_dimosa.Visible = True
    End Sub

    Private Sub mnu_sg_dimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_sg_dimosa.Click
        Try
            Con.ContadorReporte("mnu_sg_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_sell_out_general_dimosa.MdiParent = Me
        frm_sell_out_general_dimosa.Visible = True
    End Sub

  
    Private Sub NacionalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_nacionales_DIMOSA.Click
        'Try
        Con.ContadorReporte("mnu_nacionales_DIMOSA", lblUsuario.Text)
        'Catch ex As Exception
        'End Try
        frm_nd_compras_nacionales_dimosa.MdiParent = Me
        frm_nd_compras_nacionales_dimosa.Visible = True
    End Sub

    Private Sub mnu_productos_precios_dimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_productos_precios_dimosa.Click
        Try
            Con.ContadorReporte("mnu_productos_precios", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_Inventarios_Dimosa.MdiParent = Me
        frm_Inventarios_Dimosa.Visible = True
    End Sub

    Private Sub mnu_importaciones_DIMOSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_importaciones_DIMOSA.Click
        Try
            Con.ContadorReporte("mnu_importaciones_DIMOSA", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_lista_importaciones_dimosa.MdiParent = Me
        frm_lista_importaciones_dimosa.Visible = True
    End Sub

    Private Sub mnu_orden_pedido_DIMOSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_orden_pedido_DIMOSA.Click
        Try
            Con.ContadorReporte("mnu_orden_pedido_DIMOSA", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_ordenes_pedidos_dimosa.MdiParent = Me
        frm_ordenes_pedidos_dimosa.Visible = True
    End Sub

    Private Sub mnu_precios_negociados_DIMOSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_precios_negociados_DIMOSA.Click
        Try
            Con.ContadorReporte("mnu_precios_negociados_DIMOSA", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_precios_negociados_dimosa.usuario_id = lblId.Text
        frm_precios_negociados_dimosa.usuario_name = lblUsuario.Text
        frm_precios_negociados_dimosa.MdiParent = Me
        frm_precios_negociados_dimosa.Visible = True
    End Sub

    Private Sub mnu_resumen_cred_deb_DIMOSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_resumen_cred_deb_DIMOSA.Click
        Try
            Con.ContadorReporte("mnu_resumen_cred_deb_DIMOSA", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_resumen_debitos_creditos_dimosa.MdiParent = Me
        frm_resumen_debitos_creditos_dimosa.Visible = True
    End Sub

   
    Private Sub NacionalesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NacionalesToolStripMenuItem1.Click
        Try
            Con.ContadorReporte("NacionalesToolStripMenuItem1", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_dev_compras_devolucion_dimosa.MdiParent = Me
        frm_dev_compras_devolucion_dimosa.Visible = True
    End Sub

    Private Sub mnu_import_DIMOSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_import_DIMOSA.Click
        Try
            Con.ContadorReporte("mnu_import_DIMOSA", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_dev_compras_lista_DIMOSA.MdiParent = Me
        frm_dev_compras_lista_DIMOSA.Visible = True
    End Sub

    Private Sub MultialmacénDIMOSAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_multialmacen_dimosa.Click
        Try
            Con.ContadorReporte("mnu_multialmacen_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Multialmacen_DIMOSA.MdiParent = Me
        Multialmacen_DIMOSA.Visible = True
    End Sub

    Private Sub DimosaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_descuentos_dimosa.Click
        Try
            Con.ContadorReporte("mnu_descuentos_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_menu_descuentos_tacticos_dimosa.MdiParent = Me
        frm_menu_descuentos_tacticos_dimosa.Visible = True
    End Sub

    Private Sub mnu_devoluciones_dimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_devoluciones_dimosa.Click
        Try
            Con.ContadorReporte("mnu_devoluciones_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Devoluciones_DIMOSA.MdiParent = Me
        Devoluciones_DIMOSA.Visible = True
    End Sub

    Private Sub mnu_listadt_resumen_dimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_listadt_resumen_dimosa.Click
        Try
            Con.ContadorReporte("mnu_listadt_resumen_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_descuentos_tacticos_admin_dimosa.MdiParent = Me
        frm_descuentos_tacticos_admin_dimosa.Visible = True
    End Sub

    Private Sub mnu_resumen_costos_dimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_resumen_costos_dimosa.Click
        Try
            Con.ContadorReporte("mnu_resumen_costos_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_Resumen_Costos_dimosa.MdiParent = Me
        frm_Resumen_Costos_dimosa.Visible = True
    End Sub

    Private Sub mnu_listadesct_detalle_dimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_listadesct_detalle_dimosa.Click
        Try
            Con.ContadorReporte("mnu_listadesct_detalle_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_resumen_descuentos_tacticos_admin_proveedor_dimosa.MdiParent = Me
        frm_resumen_descuentos_tacticos_admin_proveedor_dimosa.Visible = True
    End Sub

    Private Sub mnu_listadesct_resprod_dimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_listadesct_resprod_dimosa.Click
        Try
            Con.ContadorReporte("mnu_listadesct_resprod_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_resumen_des_tac_dimosa.MdiParent = Me
        frm_resumen_des_tac_dimosa.Visible = True
    End Sub

    Private Sub ConsignacionesDimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsignacionesDimosa.Click
        Try
            Con.ContadorReporte("ConsignacionesDimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If Frm_ListaConsignacionesDimosa.Visible = False Then
            Frm_ListaConsignacionesDimosa.MdiParent = Me
            Frm_ListaConsignacionesDimosa.Show()
        Else
            Frm_ListaConsignacionesDimosa.BringToFront()
        End If
    End Sub
 
    Private Sub mnu_ReportePromociones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ReportePromociones.Click
        Try
            Con.ContadorReporte("mnu_ReportePromociones", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_reporte_promociones.MdiParent = Me
        frm_reporte_promociones.Visible = True
    End Sub

    Private Sub mnu_Pedidos_Prov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Pedidos_Prov.Click
        Try
            Con.ContadorReporte("mnu_Pedidos_Prov", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_pedidos_proveedores.MdiParent = Me
        frm_pedidos_proveedores.Visible = True
    End Sub

    Private Sub DetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_pto_reorden_detalle_dimosa.Click
        Try
            Con.ContadorReporte("mnu_pto_reorden_detalle_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_punto_reorden_dimosa_detalle.Close()
        frm_punto_reorden_dimosa_detalle.MdiParent = Me
        frm_punto_reorden_dimosa_detalle.Show()
    End Sub

    Private Sub ResumenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_pto_reorden_resumen_dimosa.Click
        Try
            Con.ContadorReporte("mnu_pto_reorden_resumen_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_punto_reorden_dimosa.Close()
        frm_punto_reorden_dimosa.MdiParent = Me
        frm_punto_reorden_dimosa.Show()
    End Sub

    Private Sub ResumenDeFacturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenDeFacturas.Click
        Try
            Con.ContadorReporte("ResumenDeFacturas", lblUsuario.Text)
        Catch ex As Exception
        End Try
        FormReporteFacturas.MdiParent = Me
        FormReporteFacturas.Show()
    End Sub

    
    Private Sub mnu_consignaciones_flota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_consignaciones_flota.Click
        Try
            Con.ContadorReporte("mnu_consignaciones_flota", lblUsuario.Text)
        Catch ex As Exception
        End Try
        If Frm_ListaConsignaciones_Flota.Visible = False Then
            Frm_ListaConsignaciones_Flota.MdiParent = Me
            Frm_ListaConsignaciones_Flota.Show()
        Else
            Frm_ListaConsignaciones_Flota.BringToFront()
        End If
    End Sub

    Private Sub mnu_so_rentabilidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_so_rentabilidad.Click
        Try
            Con.ContadorReporte("mnu_so_rentabilidad", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_sell_out_rentabilidad.MdiParent = Me
        frm_sell_out_rentabilidad.Visible = True
    End Sub

    Private Sub mnu_existenciasCostosDimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_existenciasCostosDimosa.Click
        Try
            Con.ContadorReporte("mnu_existenciasCostosDimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Existencias_Costos_Dimosa.MdiParent = Me
        Existencias_Costos_Dimosa.Visible = True
    End Sub

    Private Sub IngresoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ingreso_errores_rec.Click
        Try
            Con.ContadorReporte("mnu_ingreso_errores_rec", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_error_recepcion.MdiParent = Me
        frm_error_recepcion.Show()
        frm_error_recepcion.BringToFront()
    End Sub

    Private Sub ReporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_reporte_errores_rec.Click
        Try
            Con.ContadorReporte("mnu_reporte_errores_rec", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmReporte_Errores_Recepcion.MdiParent = Me
        frmReporte_Errores_Recepcion.Show()
        frmReporte_Errores_Recepcion.BringToFront()
    End Sub

    Private Sub SellOutProveedorCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SellOutProveedorCosto.Click
        Try
            Con.ContadorReporte("SellOutProveedorCosto", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_sell_out_general_proveedor.MdiParent = Me
        frm_sell_out_general_proveedor.Visible = True
    End Sub
 
    Private Sub mnu_Pedidos_Prov_DIMOSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Pedidos_Prov_DIMOSA.Click
        Try
            Con.ContadorReporte("mnu_Pedidos_Prov_DIMOSA", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_pedidos_proveedores_dimosa.MdiParent = Me
        frm_pedidos_proveedores_dimosa.Visible = True
    End Sub

 
    Private Sub mnu_efectividad_diaria_dimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_efectividad_diaria_dimosa.Click
        Try
            Con.ContadorReporte("mnu_efectividad_diaria_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Efectividad_DIMOSA.Visible = True
    End Sub

    Private Sub mnu_efectividad_fechas_dimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_efectividad_fechas_dimosa.Click
        Try
            Con.ContadorReporte("mnu_efectividad_fechas_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        EfectividadRangoFechasDIMOSA.Visible = True
    End Sub

    Private Sub mnu_ventas_prov_dimosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ventas_prov_dimosa.Click
        Try
            Con.ContadorReporte("mnu_ventas_prov_dimosa", lblUsuario.Text)
        Catch ex As Exception
        End Try
        VentasporProveedorDimosa.MdiParent = Me
        VentasporProveedorDimosa.Visible = True
    End Sub

    Private Sub mnu_ventas_proveedor_agro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ventas_proveedor_agro.Click
        Try
            Con.ContadorReporte("mnu_ventas_proveedor_agro", lblUsuario.Text)
        Catch ex As Exception
        End Try
        VentasporProveedorAgro.MdiParent = Me
        VentasporProveedorAgro.Visible = True
    End Sub

    Private Sub mnu_resumen_dv_nc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_resumen_dv_nc.Click
        Try
            Con.ContadorReporte("mnu_resumen_dv_nc", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_resumen_nc_dv.MdiParent = Me
        frm_resumen_nc_dv.Show()
    End Sub

    Private Sub mnu_solicitudPapeleria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_solicitudPapeleria.Click
        Try
            Con.ContadorReporte("mnu_solicitudPapeleria", lblUsuario.Text)
        Catch ex As Exception
        End Try
        FormNuevaSolicitudPapeleria.MdiParent = Me
        FormNuevaSolicitudPapeleria.Show()
    End Sub

    Private Sub mnu_Carga_Presupuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Carga_Presupuestos.Click
        Try
            Con.ContadorReporte("mnu_Carga_Presupuestos", lblUsuario.Text)
        Catch ex As Exception
        End Try
        FrmPresupuestosSR.MdiParent = Me
        FrmPresupuestosSR.Show()
    End Sub

    Private Sub mnu_salida_papeleria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_salida_papeleria.Click
        Try
            Con.ContadorReporte("mnu_salida_papeleria", lblUsuario.Text)
        Catch ex As Exception
        End Try
        FormMovimientosPapeleria.MdiParent = Me
        FormMovimientosPapeleria.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            Con.ContadorReporte("mnu_ingreso_dev_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_lista_devoluciones_OPL.MdiParent = Me
        frm_lista_devoluciones_OPL.Visible = True
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            Con.ContadorReporte("mnu_recepcion_dev_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_panel_almacen_devoluciones_OPL.MdiParent = Me
        frm_panel_almacen_devoluciones_OPL.Visible = True
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Try
            Con.ContadorReporte("mnu_resumen_devoluciones_disar", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_reporte_devoluciones_OPL.MdiParent = Me
        frm_reporte_devoluciones_OPL.Visible = True
    End Sub

    Private Sub ProductosYPreciosJAREMARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu_InventarioOPL.Click
        Try
            Con.ContadorReporte("mnu_InventarioOPL", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Inventarios_OPL.MdiParent = Me
        Inventarios_OPL.Visible = True
    End Sub

    Private Sub OPLToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OPLToolStripMenuItem1.Click
        Try
            Con.ContadorReporte("mnu_descuentost_opl", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_menu_descuentos_tacticos_opl.MdiParent = Me
        frm_menu_descuentos_tacticos_opl.Visible = True
    End Sub

    Private Sub OPLToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles OPLToolStripMenuItem2.Click
        Try
            Con.ContadorReporte("mnu_devoluciones_nc_OPL", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Devoluciones_Notas_De_Credito_OPL.MdiParent = Me
        Devoluciones_Notas_De_Credito_OPL.Visible = True
    End Sub

    Private Sub CargaDeComprasOPLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargaDeComprasOPLToolStripMenuItem.Click
        'Try
        Con.ContadorReporte("mnu_nacionales_OPL", lblUsuario.Text)
        'Catch ex As Exception
        'End Try
        frm_nd_compras_nacionales_opl.MdiParent = Me
        frm_nd_compras_nacionales_opl.Visible = True
    End Sub

    Private Sub Mnu_pto_reorden_detalle_OPL_Click(sender As Object, e As EventArgs) Handles mnu_pto_reorden_detalle_OPL.Click
        Try
            Con.ContadorReporte("mnu_pto_reorden_detalle_OPL", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_punto_reorden_opl_detalle.Close()
        frm_punto_reorden_opl_detalle.MdiParent = Me
        frm_punto_reorden_opl_detalle.Show()
    End Sub

    Private Sub Mnu_pto_reorden_resumen_OPL_Click(sender As Object, e As EventArgs) Handles mnu_pto_reorden_resumen_OPL.Click
        Try
            Con.ContadorReporte("mnu_pto_reorden_resumen_OPL", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_punto_reorden_OPL.Close()
        frm_punto_reorden_OPL.MdiParent = Me
        frm_punto_reorden_OPL.Show()
    End Sub

    Private Sub OPLToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles OPLToolStripMenuItem3.Click
        Try
            Con.ContadorReporte("mnu_sg_opl", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_sell_out_general_opl.MdiParent = Me
        frm_sell_out_general_opl.Visible = True
    End Sub

    Private Sub OrdenDePedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenDePedidoToolStripMenuItem.Click
        Try
            Con.ContadorReporte("OrdenDePedidoToolStripMenuItem", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Devoluciones_OPL.MdiParent = Me
        Devoluciones_OPL.Visible = True
    End Sub

    Private Sub OPLToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles OPLToolStripMenuItem4.Click
        Try
            Con.ContadorReporte("mnu_devoluciones_OPL", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Devoluciones_OPL.MdiParent = Me
        Devoluciones_OPL.Visible = True
    End Sub

    Private Sub Mnu_plantillasOpL_Click(sender As Object, e As EventArgs) Handles mnu_plantillasOpL.Click
        Try
            Con.ContadorReporte("mnu_plantillasOpL", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frmPlantillas_ReportesOPL.MdiParent = Me
        frmPlantillas_ReportesOPL.Show()
    End Sub

    Private Sub OPLToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles OPLToolStripMenuItem6.Click
        Try
            Con.ContadorReporte("OPLToolStripMenuItem6", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_Resumen_Costos_opl.MdiParent = Me
        frm_Resumen_Costos_opl.Visible = True
    End Sub

    Private Sub ResumenToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ResumenToolStripMenuItem.Click
        Try
            Con.ContadorReporte("ResumenToolStripMenuItem", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_descuentos_tacticos_admin_OPL.MdiParent = Me
        frm_descuentos_tacticos_admin_OPL.Visible = True
    End Sub

    Private Sub DetalleToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DetalleToolStripMenuItem.Click
        Try
            Con.ContadorReporte("DetalleToolStripMenuItem", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_resumen_descuentos_tacticos_admin_proveedor_OPL.MdiParent = Me
        frm_resumen_descuentos_tacticos_admin_proveedor_OPL.Visible = True
    End Sub

    Private Sub ResumenPorProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenPorProductoToolStripMenuItem.Click
        Try
            Con.ContadorReporte("ResumenPorProductoToolStripMenuItem", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_resumen_des_tac_opl.MdiParent = Me
        frm_resumen_des_tac_opl.Visible = True
    End Sub

    Private Sub PreciosNegociadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreciosNegociadoToolStripMenuItem.Click
        Try
            Con.ContadorReporte("PreciosNegociadoToolStripMenuItem", lblUsuario.Text)
        Catch ex As Exception
        End Try
        frm_precios_negociados_opl.usuario_id = lblId.Text
        frm_precios_negociados_opl.usuario_name = lblUsuario.Text
        frm_precios_negociados_opl.MdiParent = Me
        frm_precios_negociados_opl.Visible = True
    End Sub



    Private Sub mnu_universo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_universo.Click
        Try
            Con.ContadorReporte("mnu_universo", lblUsuario.Text)
        Catch ex As Exception
        End Try
        FrmUniverso.MdiParent = Me
        FrmUniverso.Show()
    End Sub

    Private Sub CargarBonosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_cargaBonos.Click
        Try
            Con.ContadorReporte("CargarBonosToolStripMenuItem_Click", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Frm_CargaPresupuestoBonos.MdiParent = Me
        Frm_CargaPresupuestoBonos.Show()
        Frm_CargaPresupuestoBonos.BringToFront()
    End Sub

    Private Sub SellOutMondelezToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SellOutMondelezToolStripMenuItem.Click
        Try
            Con.ContadorReporte("SellOutMondelezToolStripMenuItem", lblUsuario.Text)
        Catch ex As Exception
        End Try
        Sellout_Mondelez.MdiParent = Me
        Sellout_Mondelez.Show()
        Sellout_Mondelez.BringToFront()
    End Sub
End Class