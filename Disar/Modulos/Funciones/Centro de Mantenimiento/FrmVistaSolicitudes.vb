Imports Disar.data
Imports System.IO

Public Class FrmVistaSolicitudes

    Private Sub BtnDescargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDescargar.Click
        GuardaImagen.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
        GuardaImagen.ShowDialog()

        If GuardaImagen.FileName <> "" Then

            On Error Resume Next
            Dim ImagenAGuardar As System.IO.FileStream = CType(GuardaImagen.OpenFile(), System.IO.FileStream)

            Select Case GuardaImagen.FilterIndex
                Case 1
                    Imagen.Image.Save(ImagenAGuardar, System.Drawing.Imaging.ImageFormat.Jpeg)
                Case 2
                    Imagen.Image.Save(ImagenAGuardar, System.Drawing.Imaging.ImageFormat.Bmp)
                Case 3
                    Imagen.Image.Save(ImagenAGuardar, System.Drawing.Imaging.ImageFormat.Gif)
            End Select

        End If
    End Sub

    Private Sub BtnCompletar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCompletar.Click
        If TextEstado.Text = "Pendiente" Then
            Dim s = MsgBox("¿Está seguro que desea marcar esta tarea como completa?", MsgBoxStyle.YesNo, "Confirmar acción")
            If s = MsgBoxResult.Yes Then

                Dim db As New ClsBitacoraEventos
                Dim da As New ClsRegistroAgro
                Dim dt As New DataTable
                dt.Rows.Clear()
                Dim Fecha As Date

                dt = da.get_Fecha()
                Fecha = dt(0)(0)

                Dim a = db.SActualizaEv("Completa", Num.Text, Fecha, Fecha)

                If a = "S" Then
                    enviar()
                    MsgBox("El estado de la tarea se cambió exitosamente")
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MsgBox(a)
                End If
            End If
        End If
        
    End Sub

    Private Sub FrmVistaSolicitudes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Sub enviar()

        Dim Emisor As String = ""
        Dim Pass As String = "1234"
        Dim Receptor As String = ""
        Dim db As New ClsBitacoraEventos
        Dim dt As New DataTable
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try

        Try
            dt = db.sObtieneCorreo(TextSolicitante.Text)
            Receptor = dt(0)(0)

        Catch ex As Exception
        End Try
        
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        Try
            dt = db.sObtieneCorreo(_Inicio.lblUsuario.Text)
            Emisor = dt(0)(0)
        Catch ex As Exception

        End Try
        
        Try
            Dim SMTP As String = "mail.disarhn.com"
            Dim Usuario As String = Emisor
            Dim Contraseña As String = Pass

            Dim Contenido As String = "Se ha completado la solicitud [" & TextDescripcion.Text & "] de mantenimiento " & TextVehiculo.Text & ". Ingrese al sistema para revisar y validar la tarea completa." & vbNewLine & vbNewLine & vbNewLine & vbNewLine & _
            " Enviado desde Sistema de Reportes DISAR - Solicitudes de Mantenimiento "
            Dim Asunto As String = "Solicitud de Mantenimiento completada desde Sistema de Reportes DISAR"
            Dim Puerto As Integer = Integer.Parse("26")
            Dim correo As New System.Net.Mail.MailMessage()
            Dim Servidor As New System.Net.Mail.SmtpClient

            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = Asunto

            correo.To.Add(Receptor)

            correo.Body = Contenido

            Servidor.Host = SMTP
            Servidor.Port = Puerto
            Servidor.EnableSsl = False
            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
            Servidor.Send(correo)
            'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("No se logro enviar correo " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

 
End Class