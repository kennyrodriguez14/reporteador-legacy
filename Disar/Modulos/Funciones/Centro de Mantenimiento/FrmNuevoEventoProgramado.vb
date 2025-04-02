Imports Disar.data

Public Class FrmNuevoEventoProgramado

    Private Sub ComboEvento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEvento.SelectedIndexChanged
        If ComboEvento.Text = "OTRO" Then
            TextNuevoEvento.Visible = True
        Else
            TextNuevoEvento.Visible = False
        End If
    End Sub

    Private Sub BtnGuardar_CK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        If CheckFecha.CheckState = CheckState.Checked Then
            If DateTimePicker1.Value <= Today.Date Then
                MsgBox("La fecha de un registro programado no puede inferior o igual a la fecha actual", MsgBoxStyle.Information, "Error")
            Else
                If ComboEvento.Text <> "" And ComboVehiculo.Text <> "" And TextDuracion.Text <> "" Then
                    Dim db As New ClsBitacoraEventos
                    Dim s As String = db.NuevoEventoProgramado(_Inicio.lblUsuario.Text, ComboEvento.Text, TextNuevoEvento.Text, ComboVehiculo.SelectedValue, "", DateTimePicker1.Value, TextDuracion.Text)
                    MsgBox(s)
                    Me.Close()
                Else
                    MsgBox("Complete todos los campos para poder continuar", MsgBoxStyle.Information, "Error")
                End If
            End If
        Else
            If DateTimePicker1.Value <= Today.Date Then
                MsgBox("La fecha de un registro programado no puede inferior o igual a la fecha actual", MsgBoxStyle.Information, "Error")
            Else
                If ComboEvento.Text <> "" And ComboVehiculo.Text <> "" And TextDuracion.Text <> "" Then
                    Dim db As New ClsBitacoraEventos
                    Dim s As String = db.NuevoEventoProgramadoKilometraje(_Inicio.lblUsuario.Text, ComboEvento.Text, TextNuevoEvento.Text, ComboVehiculo.SelectedValue, "", Val(TextKilometraje.Text), TextDuracion.Text)
                    MsgBox(s)
                    Me.Close()
                Else
                    MsgBox("Complete todos los campos para poder continuar", MsgBoxStyle.Information, "Error")
                End If
            End If
        End If

    End Sub

    Private Sub FrmNuevoEventoProgramado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenaEventos()
        LlenaVehiculos()
    End Sub

    Sub LlenaVehiculos()
        Dim db As New ClsBitacoraEventos
        ComboVehiculo.DataSource = db.VehiculosRep
        ComboVehiculo.ValueMember = "Nº"
        ComboVehiculo.DisplayMember = "DESCRIPCIÓN"
    End Sub

    Sub LlenaEventos()
        Dim db As New ClsBitacoraEventos
        ComboEvento.DataSource = db.Eventos
        ComboEvento.ValueMember = "VehiculoProgramacion"
        ComboEvento.DisplayMember = "VehiculoProgramacion"
    End Sub

    Private Sub CheckFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFecha.CheckedChanged
        If CheckFecha.CheckState = CheckState.Checked Then
            DateTimePicker1.Enabled = True
        Else
            DateTimePicker1.Enabled = False
        End If
    End Sub
End Class