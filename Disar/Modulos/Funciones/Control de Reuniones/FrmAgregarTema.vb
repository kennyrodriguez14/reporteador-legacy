Imports Disar.data

Public Class FrmAgregarTema

    Public REU As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim db As New clsReuniones
        Try
            Dim s = db.INSERTARTema(TextBox1.Text, REU)
            If s = "s" Then
                MsgBox("Se ha guardado la tarea con éxito", MsgBoxStyle.Information)
                FormReunionesPrincipal.DataDetalles.DataSource = db.TemasReunion(FormReunionesPrincipal.DataReuniones.CurrentRow.Cells(0).Value)
                FormReunionesPrincipal.DataDetalles.Columns(0).Visible = False
                Me.Dispose()
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class