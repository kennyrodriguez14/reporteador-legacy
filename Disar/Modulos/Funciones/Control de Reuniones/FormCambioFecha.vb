Imports Disar.data

Public Class FormCambioFecha

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim db As New clsReuniones
        Try
            Dim s = db.ModificaPendiente(Numero.Text, DateTimePicker1.Value)
            If s = "s" Then
                MsgBox("Cambio realizado")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class