Imports Disar.data

Public Class Frm_CambioDeEncargado

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guardar.Click
        Dim db As New ClsBitacoraEventos

        Try
            Dim a = db.ActualizaDatosVeh(LVehiculo.Text, TextSerie.Text, TextChasis.Text, TextEncargado.Text, _Inicio.lblUsuario.Text)
            FrmEstadoVehiculo.NChasis.Text = TextChasis.Text
            FrmEstadoVehiculo.NMotor.Text = TextSerie.Text
            FrmEstadoVehiculo.NEncargado.Text = TextEncargado.Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
        End Try

    End Sub

End Class