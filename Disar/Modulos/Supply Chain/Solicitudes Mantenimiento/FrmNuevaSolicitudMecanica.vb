Imports System.Data
Imports Disar.data
Imports System.IO
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Public Class FrmNuevaSolicitudMecanica

    Dim A As Integer

    Private Sub btnBuscaFotografías_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaFotografías.Click

        PictureFotos.Image = Nothing
        Dim Resultado As New DialogResult()
        Resultado = Dialog.ShowDialog

        Dim Resu As String


        For Each Resu In Dialog.FileNames
            Dim loadedImage As Image = Image.FromFile(Resu)
            PictureFotos.Image = loadedImage

            Dim esperaTmp As Long = My.Computer.Clock.TickCount + (1 * 1000)

            While esperaTmp > My.Computer.Clock.TickCount
                System.Windows.Forms.Application.DoEvents()
            End While
        Next Resu
 
    End Sub

    Private Sub FrmNuevaSolicitudMecanica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ObtieneCorreo()
        LlenaEntregadores()
        LlenaVehiculos()
    End Sub

    Sub LlenaVehiculos()
        Dim db As New ClsBitacoraEventos
        Try
            ComboVehiculo.DataSource = db.Vehiculos()
            ComboVehiculo.DisplayMember = "VehiculoDescripcion"
            ComboVehiculo.ValueMember = "VehiculoID"
            ComboVehiculo.SelectedItem = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Sub LlenaEntregadores()
        Try
            Dim db As New ClsBitacoraEventos
            ComboEnregador.DataSource = db.Entregadores
            ComboEnregador.ValueMember = "Codigo"
            ComboEnregador.DisplayMember = "Nombre"
        Catch ex As Exception

        End Try
    End Sub

    Sub ObtieneCorreo()

        Dim db As New ClsBitacoraEventos
        Dim dt As New DataTable
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        dt = db.sObtieneCorreo(_Inicio.lblUsuario.Text)
        Try
            _txtEmisor.Text = dt(0)(0)
        Catch ex As Exception
            _txtEmisor.Text = ""
        End Try

    End Sub

    Private Sub BtnGuarda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuarda.Click
        If ComboBox1.Text = "Vehicular" Then


            If ComboVehiculo.Text = "" Or ComboEnregador.Text = "" Or (PictureFotos.Image Is Nothing) Then
                MsgBox("Complete todos los datos y cargue una imagen para poder continuar.", MsgBoxStyle.Critical, "Error")
            Else
                Dim Resu As String

                For Each Resu In Dialog.FileNames
                    Dim loadedImage As Image = Image.FromFile(Resu)
                    PictureFotos.Image = loadedImage
                Next

                Dim Memoria As New System.IO.MemoryStream
                PictureFotos.Image.Save(Memoria, System.Drawing.Imaging.ImageFormat.Jpeg)

                Dim db As New ClsBitacoraEventos
                Try
                    Dim s = db.SNuevoEvento(ComboVehiculo.SelectedValue, ComboEnregador.SelectedValue, Today.Date, TextSolicitud.Text, Memoria.GetBuffer, _Inicio.lblUsuario.Text, TextEnvio.Text)
                    If s = "s" Then
                        enviar()
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        MsgBox("Se ha guardado el registro con éxito", MsgBoxStyle.Information, "Aviso")
                    Else
                        MsgBox(s)
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Else
            If TextSolicitud.Text = "" Then
                MsgBox("Complete los datos de la solicitud para poder continuar.")
            Else
                Dim Resu As String

                For Each Resu In Dialog.FileNames
                    Dim loadedImage As Image = Image.FromFile(Resu)
                    PictureFotos.Image = loadedImage
                Next

                Dim Memoria As New System.IO.MemoryStream
                PictureFotos.Image.Save(Memoria, System.Drawing.Imaging.ImageFormat.Jpeg)

                Dim db As New ClsBitacoraEventos
                Try
                    Dim s = db.SNuevoEvento(1000, 1000, Today.Date, TextSolicitud.Text, Memoria.GetBuffer, _Inicio.lblUsuario.Text, TextEnvio.Text)
                    If s = "s" Then
                        enviar()
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        MsgBox("Se ha guardado el registro con éxito", MsgBoxStyle.Information, "Aviso")
                    Else
                        MsgBox(s)
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End If
    End Sub

    Private Sub FrmNuevaSolicitudMecanica_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Sub enviar()
        Try
            Dim SMTP As String = _txtServer.Text
            Dim Usuario As String = _txtEmisor.Text
            Dim Contraseña As String = _txtPass.Text

            Dim Contenido As String = ""
            If ComboBox1.Text = "Vehicular" Then
                Contenido = "El usuario " & _Inicio.lblUsuario.Text & " acaba de realizar una solicitud " & _
                            "de mantenimiento para " & ComboVehiculo.Text & " desde el Sistema de Reportes Disar. Ingrese al sistema, módulo " & _
                            " Funciones Adicionales, sección de [Centro de Mantenimiento] para revisar la solicitud. " & vbNewLine & vbNewLine & vbNewLine & vbNewLine & _
                            " Enviado desde Sistema de Reportes DISAR - Solicitudes de Mantenimiento "
            Else
                Contenido = "El usuario " & _Inicio.lblUsuario.Text & " acaba de realizar una solicitud " & _
                            "de mantenimiento desde el Sistema de Reportes Disar. Ingrese al sistema, módulo " & _
                            " Funciones Adicionales, sección de [Centro de Mantenimiento] para revisar la solicitud. " & vbNewLine & vbNewLine & vbNewLine & vbNewLine & _
                            " Enviado desde Sistema de Reportes DISAR - Solicitudes de Mantenimiento "
            End If

            Dim Asunto As String = "Nueva Solicitud de Mantenimiento enviada desde Sistema de Reportes DISAR"
            Dim Puerto As Integer = Integer.Parse(_txtPort.Text)
            Dim correo As New System.Net.Mail.MailMessage()
            Dim Servidor As New System.Net.Mail.SmtpClient

            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = Asunto


            correo.To.Add("henry.martinez@disarhn.com")
            correo.To.Add("erick.banegas@disarhn.com")

            correo.Body = Contenido

            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = False
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
            Servidor.Send(correo)
            'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("No se logró enviar correo " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Vehicular" Then
            GroupVehiculo.Visible = True
        Else
            GroupVehiculo.Visible = False
        End If
    End Sub

End Class