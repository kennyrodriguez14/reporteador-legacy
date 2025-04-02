Imports Disar.data
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Public Class FrmLlenadoReunion
    Public NumeroReunion As Integer
    Public Responsable, NombreUsuario As String

    Private Sub FrmLlenadoReunion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New clsReuniones

        Try
            Dim column0 As New DataGridViewCheckBoxColumn
            column0.Name = "Tema Revisado"
            column0.HeaderText = "Tema Revisado"

            Dim column As New DataGridViewButtonColumn
            column.Name = "Agregar Pendiente"
            column.HeaderText = "Nuevo Pendiente"

            DataDetalles.Columns.Add(column0)
            DataDetalles.Columns.Add(column)

            DataDetalles.Columns(0).Visible = False
        Catch ex As Exception
        End Try

        Try
            Dim column0 As New DataGridViewCheckBoxColumn
            column0.Name = "Asistencia"
            column0.HeaderText = "Asistencia"

            Dim column As New DataGridViewComboBoxColumn
            column.Items.Clear()
            column.Items.Add("Presencial")
            column.Items.Add("Remoto")

            column.Name = "Medio Asistencia"
            column.HeaderText = "Medio Asistencia"

            Dim column1 As New DataGridViewTextBoxColumn
            column1.Name = "HoraAsistencia"
            column1.HeaderText = "Hora de Entrada"

            DataParticipantes.Columns.Add(column0)
            DataParticipantes.Columns.Add(column)
            DataParticipantes.Columns.Add(column1)

            DataParticipantes.Columns("ID").Visible = False
        Catch ex As Exception
        End Try

        Try
            For Each row As DataGridViewRow In DataParticipantes.Rows
                row.Cells(5).Value = Now.TimeOfDay.ToString
            Next
        Catch ex As Exception
        End Try

        Try
            Dim s = db.NuevaReunionRegistro(Val(ReunionID.Text), Reunion.Text, FechaHora.Text, _Inicio.lblUsuario.Text)
            If IsNumeric(s) Then
                NumeroReunion = s
            Else
                MsgBox(s, MsgBoxStyle.Critical, "No se puede almacenar el dato de la reunión actual")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        LlenaPendientes()

        For Each row As DataGridViewRow In DataParticipantes.Rows
            row.Cells("Asistencia").Value = True
            row.Cells("Medio Asistencia").Value = "Presencial"
        Next

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim db As New clsReuniones
        Try
            Dim s = db.CancelarReunion(ReunionID.Text, NumeroReunion)
            If s = "s" Then
            Else
                MsgBox("No se pudo cancelar la reunión " & s)
            End If
        Catch ex As Exception
        End Try
        Me.Dispose()
    End Sub

    Private Sub DataParticipantes_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataParticipantes.CellClick

        Dim validClick As Boolean = (e.RowIndex <> -1 AndAlso e.ColumnIndex <> -1)
        Dim datagridview = TryCast(sender, DataGridView)

        If TypeOf datagridview.Columns(e.ColumnIndex) Is DataGridViewComboBoxColumn AndAlso validClick Then
            datagridview.BeginEdit(True)
            DirectCast(datagridview.EditingControl, ComboBox).DroppedDown = True
        End If
        If TypeOf datagridview.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso validClick Then
            If FormAsignarPendiente.ShowDialog = Windows.Forms.DialogResult.OK Then
                LlenaPendientes()
            End If
        End If
    End Sub

    Private Sub DataDetalles_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDetalles.CellClick
        Dim validClick As Boolean = (e.RowIndex <> -1 AndAlso e.ColumnIndex <> -1)
        Dim datagridview = TryCast(sender, DataGridView)

        If TypeOf datagridview.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso validClick Then
            Try
                FormAsignarPendiente.TareaID.Text = Me.DataDetalles.CurrentRow.Cells(0).Value
                FormAsignarPendiente.Tarea.Text = Me.DataDetalles.CurrentRow.Cells(1).Value
                FormAsignarPendiente.Reunion.Text = Me.ReunionID.Text
                FormAsignarPendiente.CodigoReunion.Text = Me.NumeroReunion
            Catch ex As Exception
            End Try

            Dim Db As New clsReuniones
            FormAsignarPendiente.ComboAsignacion.DataSource = Db.ParticipantesReunion(ReunionID.Text)
            FormAsignarPendiente.ComboAsignacion.ValueMember = "ID"
            FormAsignarPendiente.ComboAsignacion.DisplayMember = "Participante"

            Try
                FormAsignarPendiente.DataDatos.Columns.Clear()
            Catch ex As Exception
            End Try
            FormAsignarPendiente.DataDatos.DataSource = Db.ParticipantesReunion(ReunionID.Text)
            Dim column0 As New DataGridViewCheckBoxColumn
            column0.Name = "Asignar"
            column0.HeaderText = "Asignar"
            FormAsignarPendiente.DataDatos.Columns.Add(column0)
            FormAsignarPendiente.DataDatos.Columns(0).Visible = False
            FormAsignarPendiente.DataDatos.Columns(2).Visible = False
            FormAsignarPendiente.ShowDialog()
        End If
    End Sub

    Sub LlenaPendientes()
        DataPendientes.Columns.Clear()
        DataPendientes.DataSource = Nothing
        Dim db As New clsReuniones
        If ReunionID.Text = 1 Then
            Try
                DataPendientes.DataSource = db.MuestraTodosPendientesReunion()
                DataPendientes.Columns("ID").Visible = False
                DataPendientes.Columns("Asignado").Visible = False
                DataPendientes.Columns("Reunion").Visible = False
                DataPendientes.Columns("Registro").Visible = False
                DataPendientes.Columns("Nom").Visible = False
                DataPendientes.Columns("Tema").Visible = False
            Catch ex As Exception
            End Try
        Else
            Try
                DataPendientes.DataSource = db.MuestraPendientesReunion(ReunionID.Text)
                DataPendientes.Columns("ID").Visible = False
                DataPendientes.Columns("Asignado").Visible = False
                DataPendientes.Columns("Reunion").Visible = False
                DataPendientes.Columns("Registro").Visible = False
                DataPendientes.Columns("Nom").Visible = False
                DataPendientes.Columns("Tema").Visible = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        DataPendientes.Columns(1).Frozen = True
        DataPendientes.Columns(1).DividerWidth = 3
        UsuariosXPendiente()
    End Sub

    Private Sub DataPendientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataPendientes.CellDoubleClick
        Dim Db As New clsReuniones
 
        Try
            FormCambioEstado.DataDatos.Columns.Clear()
        Catch ex As Exception
        End Try
        FormCambioEstado.DataDatos.DataSource = Db.ParticipantesPendiente(DataPendientes.CurrentRow.Cells(0).Value)
        Dim column0 As New DataGridViewCheckBoxColumn
        column0.Name = "Asignar"
        column0.HeaderText = "Cambiar estado"
        FormCambioEstado.DataDatos.Columns.Add(column0)
        FormCambioEstado.DataDatos.Columns(0).Visible = False
 
        FormCambioEstado.ID = DataPendientes.CurrentRow.Cells(0).Value
        If FormCambioEstado.ShowDialog = Windows.Forms.DialogResult.OK Then
            LlenaPendientes()
        End If
        'Else
        'MsgBox("Solo el responsable de la reunión puede cambiar el estado de una tarea", MsgBoxStyle.Information, "Aviso")
        'End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim db As New clsReuniones
        Dim dtParticipantes As New DataTable
        Dim dtTemas As New DataTable
        Try
            dtParticipantes.Columns.Clear()
        Catch ex As Exception
        End Try
        Try
            dtTemas.Columns.Clear()
        Catch ex As Exception
        End Try

        dtParticipantes.Columns.Add("ID")
        dtParticipantes.Columns.Add("ReunionReg")
        dtParticipantes.Columns.Add("Nick")
        dtParticipantes.Columns.Add("Medio")
        dtParticipantes.Columns.Add("Asistencia")
        dtParticipantes.Columns.Add("Tiempo")

        dtTemas.Columns.Add("Tarea")
        dtTemas.Columns.Add("ReunionReg")
        dtTemas.Columns.Add("Reunion")
        dtTemas.Columns.Add("TareaID")
        dtTemas.Columns.Add("Estado")

        For Each row As DataGridViewRow In DataDetalles.Rows
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Tema Revisado"), DataGridViewCheckBoxCell)
            Dim Estado As String = ""

            If Convert.ToBoolean(cellSelecion.Value) Then
                Estado = "Revisado"
            Else
                Estado = "No revisado"
            End If
            dtTemas.Rows.Add(row.Cells(0).Value, NumeroReunion, Reunion.Text, row.Cells(0).Value, Estado)
        Next
        For Each row As DataGridViewRow In DataParticipantes.Rows
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Asistencia"), DataGridViewCheckBoxCell)
            Dim Estado As String = ""

            If Convert.ToBoolean(cellSelecion.Value) Then
                Estado = "Si"
            Else
                Estado = "No"
            End If
            Dim Medio As String = "Presencial"
            If Estado = "Si" Then
                Medio = row.Cells("Medio Asistencia").Value
            Else
                Medio = ""
            End If
            dtParticipantes.Rows.Add(row.Cells(0).Value, NumeroReunion, row.Cells("ID").Value, Medio, Estado, row.Cells(5).Value)
        Next

        Dim Fecha As DateTime
        Dim dtFecha As New DataTable
        dtFecha = db.FechaHora
        Fecha = dtFecha(0)(0)

        Dim s = db.TerminarReunion(dtParticipantes, dtTemas, Fecha, TextObservaciones.Text, _Inicio.lblUsuario.Text, NumeroReunion)

        If s = "s" Then
            Dim Enviar = MsgBox("Se completó la reunión exitosamente, ¿Desea enviar información a los participantes?", MsgBoxStyle.YesNo)
            If Enviar = MsgBoxResult.Yes Then
                enviarCorreo()
            End If
            Me.Dispose()
        Else
            MsgBox(s)
        End If

    End Sub

    Sub enviarCorreo()
        Try
            Dim SMTP As String = "gator2024.hostgator.com"
            Dim db As New clsReuniones
            Dim dt As New DataTable
            dt = db.Correo(_Inicio.lblUsuario.Text)
            Dim Usuario As String = "reuniones@sanrafaelhn.com"
            'Usuario = dt(0)(0)
            Dim Contraseña As String = "Reuniones100"

            Dim Puerto As Integer = 25
            Dim correo As New System.Net.Mail.MailMessage()
            Dim Servidor As New System.Net.Mail.SmtpClient
            Dim Acceso As New System.Net.Mail.SmtpAccess

            Dim Contenido As String = ""


            Contenido = "<h4> Bitácora de Reunión: " & Reunion.Text & " " & FechaHora.Text & vbNewLine & "</h4>"

            Contenido = Contenido & "<h5>" & vbNewLine & "Temas: " & vbNewLine & "</h5>"

            Contenido &= "<TABLE border=1>"
            Contenido &= "<TH bgcolor='#CCD1D1'>"

            Contenido &= "<TD bgcolor='#CCD1D1'>Tema</TD>"
            Contenido &= "<TD bgcolor='#CCD1D1'>Estado</TD>"

            Contenido &= "</TH>"

            For Each row As DataGridViewRow In DataDetalles.Rows

                Contenido &= "<TR>"
                Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Tema Revisado"), DataGridViewCheckBoxCell)
                Dim Estado As String = ""
                'Contenido = Contenido & "- " & row.Cells(1).Value
                If Convert.ToBoolean(cellSelecion.Value) Then
                    Estado = "Revisado"
                Else
                    Estado = "No Revisado"
                End If
                Contenido &= "<TD>" & (row.Index + 1).ToString & "</TD>"
                Contenido &= "<TD>" & row.Cells(1).Value & "</TD>"
                Contenido &= "<TD>" & Estado & "</TD>"
                'Contenido = Contenido & ": Tema " & Estado & vbNewLine
                Contenido &= "</TR>"
            Next
            Contenido &= "</TABLE>"

            Contenido = Contenido & "<h5>" & vbNewLine & "Asistencia: " & vbNewLine & "</h5>"

            Contenido &= "<TABLE border=1>"
            Contenido &= "<TH bgcolor='#CCD1D1'>"

            Contenido &= "<TD bgcolor='#CCD1D1'>Nombre</TD>"
            Contenido &= "<TD bgcolor='#CCD1D1'>Asistencia</TD>"
            Contenido &= "<TD bgcolor='#CCD1D1'>Medio</TD>"
            Contenido &= "<TD bgcolor='#CCD1D1'>Hora</TD>"

            Contenido &= "</TH>"

            For Each row As DataGridViewRow In DataParticipantes.Rows
                Contenido &= "<TR>"
                Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Asistencia"), DataGridViewCheckBoxCell)
                Dim Estado As String = ""
                'Contenido = Contenido & "- " & row.Cells(1).Value

                If Convert.ToBoolean(cellSelecion.Value) Then
                    Estado = "Si"
                Else
                    Estado = "No"
                End If
                'Contenido = Contenido & ": " & Estado
                Contenido &= "<TD>" & (row.Index + 1).ToString & "</TD>"
                Contenido &= "<TD>" & row.Cells(1).Value & "</TD>"
                Contenido &= "<TD>" & Estado & "</TD>"

                If Estado = "Si" Then
                    'Contenido = Contenido & " - " & row.Cells("Medio Asistencia").Value & vbNewLine & "   Hora: " & row.Cells("HoraAsistencia").Value
                    Contenido &= "<TD>" & row.Cells("Medio Asistencia").Value & "</TD>"

                    Dim hora As String
                    hora = (row.Cells("HoraAsistencia").Value)

                    Try
                        hora = (row.Cells("HoraAsistencia").Value).ToString.Substring(0, 8)
                    Catch ex As Exception
                    End Try

                    Contenido &= "<TD>" & hora & "</TD>"

                Else

                    Contenido &= "<TD>" & "-" & "</TD>"
                    Contenido &= "<TD>" & "-" & "</TD>"

                End If

                'Contenido = Contenido & vbNewLine
                Contenido &= "</TR>"

            Next

            Contenido &= "</TABLE>"

            'Contenido = Contenido & vbNewLine & vbNewLine & vbNewLine & "Pendientes: " & vbNewLine & vbNewLine

            Contenido = Contenido & "<h5>" & vbNewLine & "Pendientes: " & vbNewLine & "</h5>"

            Contenido &= "<TABLE border=1>"
            Contenido &= "<TH bgcolor='#CCD1D1'>"


            Contenido &= "<TD bgcolor='#CCD1D1'>Solicitud</TD>"
            Contenido &= "<TD bgcolor='#CCD1D1'>Descripción</TD>"
            Contenido &= "<TD bgcolor='#CCD1D1'>Asignado a</TD>"
            Contenido &= "<TD bgcolor='#CCD1D1'>Fecha de Solicitud</TD>"
            Contenido &= "<TD bgcolor='#CCD1D1'>Entrega Prevista</TD>"
            Contenido &= "<TD bgcolor='#CCD1D1'>Solicitante</TD>"
            Contenido &= "<TD bgcolor='#CCD1D1'>Vencimiento</TD>"

            For Each row As DataGridViewRow In DataPendientes.Rows
                Contenido &= "<TR>"

                'Contenido = Contenido & (row.Index + 1).ToString & " -> " & row.Cells(1).Value & ": " & row.Cells(2).Value & vbNewLine & "        Asignado a: " & row.Cells("Asignado a").Value & vbNewLine & vbNewLine
                Contenido &= "<TD>" & (row.Index + 1).ToString & "</TD>"
                Contenido &= "<TD>" & row.Cells(1).Value & "</TD>"
                Contenido &= "<TD>" & row.Cells(2).Value & "</TD>"

                Dim Asignado As String
                Asignado = row.Cells("Asignado a").Value

                Try
                    Asignado = Replace(row.Cells("Asignado a").Value, "•", "<br>•", 2)
                    Asignado = "•" & Asignado
                Catch ex As Exception
                End Try

                Contenido &= "<TD>" & Asignado & "</TD>"
                Contenido &= "<TD>" & row.Cells("Fecha").Value & "</TD>"
                Contenido &= "<TD>" & row.Cells("EntregaPrevista").Value & "</TD>"
                Contenido &= "<TD>" & row.Cells("Solicitante").Value & "</TD>"
                Contenido &= "<TD>" & row.Cells("VENCIDA DESDE").Value & "</TD>"

                Contenido &= "</TR>"
            Next

            Contenido &= "</TABLE>"

            Contenido = Contenido & "<h5>" & vbNewLine & "Observaciones: " & vbNewLine & "</h5>"
            'Contenido = Contenido & vbNewLine & vbNewLine & "Observaciones: " & vbNewLine & vbNewLine
            'Contenido = Contenido & TextObservaciones.Text & vbNewLine & vbNewLine

            Contenido = Contenido & "<p>" & TextObservaciones.Text & vbNewLine & "</p>"

            Contenido = Contenido & "<p>Enviado desde Sistema de Reportes San Rafael - Control de Reuniones</p>"

            Dim Asunto As String = "Bitácora de Reunión " & Reunion.Text & " Fecha: " & FechaHora.Text

            correo.From = New System.Net.Mail.MailAddress(Usuario)
            correo.Subject = Asunto

            correo.IsBodyHtml = True

            For Each row As DataGridViewRow In DataParticipantes.Rows

                Dim mail As String = ""
                Dim dtCorreo As New DataTable
                Try
                    dtCorreo.Rows.Clear()
                Catch ex As Exception
                End Try

                dtCorreo = db.Correo(row.Cells(0).Value)
                Try
                    mail = dtCorreo(0)(0)
                Catch ex As Exception
                End Try

                If mail <> "" Then
                    correo.To.Add(mail)
                End If

            Next

            'correo.To.Add("aron.castillo@sanrafaelhn.com")
            'correo.To.Add("jose.cardenas@sanrafaelhn.com")
            'correo.To.Add("hector.fajardo@sanrafaelhn.com")
            'correo.To.Add("kenny.rodriguez@sanrafaelhn.com")
            correo.Body = Contenido
            Servidor.Host = SMTP
            Servidor.Port = Puerto

            Servidor.EnableSsl = False

            Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)

            Servidor.Send(correo)
            MessageBox.Show("El correo se envió exitosamente.", "Envío: " & Reunion.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("El correo se envió exitosamente. " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub BtnQuitarParticipante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitarParticipante.Click
        Dim s = MsgBox("¿Está seguro que desea quitar de la reunión al usuario " & DataParticipantes.CurrentRow.Cells(1).Value & "?", MsgBoxStyle.YesNo)
        If s = MsgBoxResult.Yes Then

            Dim db As New clsReuniones
            Try
                Dim x = db.ModificarParticipante(DataParticipantes.CurrentRow.Cells("ID").Value, "X", ReunionID.Text)
                If x = "s" Then
                    Try
                        DataParticipantes.DataSource = Nothing
                        DataParticipantes.Columns.Clear()
                    Catch ex As Exception
                    End Try
                    Try
                        DataParticipantes.DataSource = db.ParticipantesReunion(ReunionID.Text)

                        Dim column0 As New DataGridViewCheckBoxColumn
                        column0.Name = "Asistencia"
                        column0.HeaderText = "Asistencia"

                        Dim column As New DataGridViewComboBoxColumn
                        column.Items.Clear()
                        column.Items.Add("Presencial")
                        column.Items.Add("Remoto")

                        column.Name = "Medio Asistencia"
                        column.HeaderText = "Medio Asistencia"

                        Dim column1 As New DataGridViewTextBoxColumn
                        column1.Name = "HoraAsistencia"
                        column1.HeaderText = "Hora de Entrada"

                        DataParticipantes.Columns.Add(column0)
                        DataParticipantes.Columns.Add(column)
                        DataParticipantes.Columns.Add(column1)
                    Catch ex As Exception
                        MsgBox("Error" & ex.Message)
                    End Try
                Else
                    MsgBox(s)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub BtnAgregarParticipante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarParticipante.Click
        FormAgregarParticipante.Numero = ReunionID.Text
        FormAgregarParticipante.ShowDialog()
    End Sub

    Sub UsuariosXPendiente()
        Dim db As New clsReuniones
        Dim dt As New DataTable
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        Try
            For Each row As DataGridViewRow In DataPendientes.Rows
                dt = db.UsuariosXPendiente(row.Cells(0).Value)
                row.Cells("Asignado a").Value = ""
                If dt.Rows.Count = 1 Then
                    row.Cells("Asignado a").Value = "•" & dt(0)(0)
                Else
                    row.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    For Sabu As Integer = 0 To dt.Rows.Count - 1
                        If Sabu = dt.Rows.Count - 1 Then
                            row.Cells("Asignado a").Value = row.Cells("Asignado a").Value & "•" & dt(Sabu)(0) & vbTab
                        Else
                            row.Cells("Asignado a").Value = row.Cells("Asignado a").Value & "•" & dt(Sabu)(0) & vbNewLine
                        End If

                    Next
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ActualizaPendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizaPendientes.Click
        LlenaPendientes()
    End Sub
End Class