Imports Disar.data

Public Class FrmNuevoEventoNoProgramado

    Private Sub FrmNuevoEventoNoProgramado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenaVehiculos()
        LlenaEventos()
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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If ComboEvento.Text <> "" And ComboVehiculo.Text <> "" And TextDuracion.Text <> "" Then
            Dim db As New ClsBitacoraEventos
            Dim s As String = db.NuevoEventoNoProgramado(_Inicio.lblUsuario.Text, ComboEvento.Text, TextNuevoEvento.Text, ComboVehiculo.SelectedValue, "", DateTimePicker1.Value, TextDuracion.Text)
            MsgBox(s)
            Me.Close()
        Else
            MsgBox("Complete todos los campos para poder continuar", MsgBoxStyle.Information, "Error")
        End If
    End Sub

    Private Sub ComboEvento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEvento.SelectedIndexChanged
        If ComboEvento.Text = "OTRO" Then
            TextNuevoEvento.Visible = True
        Else
            TextNuevoEvento.Visible = False
        End If
    End Sub

End Class