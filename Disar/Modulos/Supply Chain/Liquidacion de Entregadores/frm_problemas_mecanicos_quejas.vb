Imports System.Data
Imports Disar.data
Imports System.IO
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Public Class frm_problemas_mecanicos_quejas

    Public Entregador As String
    Public Entregadornombre As String
    Public Correos As String = ""

    Dim dtOriginales As New DataTable
    Dim dtCopias As New DataTable

    Dim dt As New DataTable

    Private Sub frm_problemas_mecanicos_quejas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadioProblema.Checked = True
        Vehiculo.Text = ""
        Queja.Text = ""
    End Sub

    Private Sub BtnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnviar.Click

        Dim db As New ClsBitacoraEventos


        If RadioProblema.Checked = True Then
            dt = db.sObtieneCorreosMantenimiento("Mantenimiento", _Inicio.Almacen)
        Else
            dt = db.sObtieneCorreosMantenimiento("Quejas", _Inicio.Almacen)
        End If
        'MsgBox(dt.Rows.Count)
        Try
            For a = 0 To dt.Rows.Count - 1
                Correos = Correos & " " & dt(a)(0)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Dim Memoria As New System.IO.MemoryStream
        PictureFotos.Image.Save(Memoria, System.Drawing.Imaging.ImageFormat.Jpeg)


        Try
            Dim s = ""


            If RadioProblema.Checked = True Then
                s = db.SNuevoEventoModuloLiquidaciones(Vehiculo.Text, Entregador, Today.Date, Queja.Text, Memoria.GetBuffer, _Inicio.lblUsuario.Text, Correos, "Mantenimiento")
            Else
                s = db.SNuevaQuejaModuloLiquidaciones(Vehiculo.Text, Entregador, Today.Date, Queja.Text, Memoria.GetBuffer, _Inicio.lblUsuario.Text, Correos, "Quejas")
            End If

            If s = "s" Then
                enviar()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                MsgBox("Se ha guardado el registro con éxito", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox(s)
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub RadioProblema_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioProblema.CheckedChanged

        If RadioProblema.Checked = True Then
            labelVehiculo.Visible = True
            Vehiculo.Visible = True
        Else
            labelVehiculo.Visible = False
            Vehiculo.Visible = False
        End If

    End Sub

    Sub enviar()
        Try
            Dim SMTP As String = "gator2024.hostgator.com"
            Dim Usuario As String = "liquidaciones@sanrafaelhn.com"
            Dim Contraseña As String = "liquidar100"

            Dim Contenido As String = ""
            If RadioProblema.Checked = True Then
                Contenido = "El usuario " & _Inicio.lblUsuario.Text & " - " & Entregadornombre & " acaba de realizar una solicitud " & _
                            "de mantenimiento para vehículo " & Vehiculo.Text & " desde el Sistema de Liquidaciones en Reporteador San Rafael. Ingrese al sistema, " & _
                            "sección [Centro de Mantenimiento] para revisar la solicitud. " & vbNewLine & "Detalle: " & Queja.Text & vbNewLine & vbNewLine & vbNewLine & vbNewLine & _
                            " Enviado desde Sistema de Reportes SAN RAFAEL - Solicitudes de Mantenimiento "
            Else
                Contenido = "El usuario " & _Inicio.lblUsuario.Text & " - " & Entregadornombre & " acaba de registrar una queja " & _
                            "desde el Sistema de Reportes San Rafael." & vbNewLine & "Detalle: " & Queja.Text
            End If

            Dim Asunto As String = "Nueva Solicitud de Mantenimiento enviada desde Sistema de Reportes SAN RAFAEL"

            If RadioProblema.Checked = False Then
                Asunto = "Sistema Reporteador - Nueva queja recibida de parte de: " & Entregadornombre
            End If

            Dim Puerto As Integer = 26
            Dim correo As New System.Net.Mail.MailMessage()
            Dim Servidor As New System.Net.Mail.SmtpClient

            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = Asunto

            For a As Integer = 0 To dt.Rows.Count - 1
                correo.To.Add(dt(a)(0))
            Next

            correo.Body = Contenido

            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = False
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
            Servidor.Send(correo)

            Me.Close()
        Catch ex As Exception
            MessageBox.Show("No se logró enviar correo " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class