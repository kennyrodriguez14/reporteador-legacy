Imports Disar.data

Public Class FrmCambioEstado

    Public ID As Integer

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If ComboEstado.Text <> "" Then
            Dim db As New ClsBitacoraEventos
            Dim S = db.ActualizaEvento(ID, ComboEstado.Text)
            If S = "S" Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                FrmCentro_Mantenimiento.BtnFiltra.PerformClick()
            End If
        Else
            MsgBox("Seleccione un estado para poder continuar", MsgBoxStyle.Critical, "Error")
        End If

    End Sub


End Class