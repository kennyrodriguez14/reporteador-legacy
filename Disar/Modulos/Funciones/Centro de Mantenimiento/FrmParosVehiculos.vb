Imports Disar.data

Public Class FrmParosVehiculos

    Private Sub BtnCompletarRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCompletarRemision.Click
        Dim db As New ClsBitacoraEventos
        Dim s As String
        If CheckPendiente.CheckState = CheckState.Checked Then
            s = "S"
        Else
            s = "N"
        End If
        If DataGridView1.RowCount > 0 Then
            Dim a = db.ModificaEnvioTaller(DateTimePicker2.Value, DataGridView1.Rows(0).Cells(0).Value)
            MsgBox(a)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            Dim a = db.NuevoEnvioTaller(ComboVehiculo.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value, s, TextCausa.Text)
            MsgBox(a)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub FrmParosVehiculos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenaVehiculo()
    End Sub

    Sub LlenaVehiculo()
        Try
            Dim DB As New ClsBitacoraEventos
            ComboVehiculo.DataSource = DB.Vehiculos
            ComboVehiculo.ValueMember = "VehiculoID"
            ComboVehiculo.DisplayMember = "VehiculoDescripcion"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmParosVehiculos_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub ComboVehiculo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboVehiculo.SelectedIndexChanged
        Try
            Dim db As New ClsBitacoraEventos
            DataGridView1.DataSource = db.VerTallerRegistrado(ComboVehiculo.SelectedValue)
        Catch ex As Exception
        End Try
        Try
            If DataGridView1.RowCount > 0 Then
                DateTimePicker1.Value = DataGridView1.Rows(0).Cells(2).Value
                DateTimePicker1.Enabled = False
                TextCausa.Text = DataGridView1.Rows(0).Cells(5).Value
                TextCausa.Enabled = False
                CheckPendiente.Enabled = True
                MsgBox("El vehículo seleccionado tiene un trabajo en estado de pendiente, seleccione la fecha de finalización")
            Else
                DateTimePicker1.Value = Now.Date
                DateTimePicker2.Value = Now.Date
                DateTimePicker1.Enabled = True
                TextCausa.Enabled = True
                TextCausa.Text = ""
                CheckPendiente.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class