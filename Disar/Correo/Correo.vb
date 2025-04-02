Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Public Class Correo
    Public DocAdjunto As String
    Private Sub Correo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = _Inicio
    End Sub

    Private Sub _btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnCancelar.Click
        Me.Close()
    End Sub

    Sub enviar()
        Try
            Dim SMTP As String = _txtServer.Text
            Dim Usuario As String = _txtEmisor.Text
            Dim Contraseña As String = _txtPass.Text
            Dim A As String = _txtReceptor.Text
            Dim Contenido As String = _txtmsj.Text
            Dim Asunto As String = _txtAsunto.Text
            Dim Puerto As Integer = Integer.Parse(_txtPort.Text)
            Dim correo As New System.Net.Mail.MailMessage()
            Dim Servidor As New System.Net.Mail.SmtpClient

            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = Asunto
            correo.To.Add(A)
            correo.Body = Contenido
            Dim att As New System.Net.Mail.Attachment(DocAdjunto)
            correo.Attachments.Add(att)
            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = False
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
            Servidor.Send(correo)
            MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("No se logro enviar correo " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub _btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnEnviar.Click
        enviar()
    End Sub
End Class