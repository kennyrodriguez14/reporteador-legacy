Imports Disar.data

Public Class FormCambioEstado

    Public ID As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MsgBox("No puede guardar un pendiente sin estado", MsgBoxStyle.Critical, "Error")
        Else
            Dim db As New clsReuniones
            Dim Fecha As DateTime = Today.Date

            Try
                Dim dt As New DataTable
                dt = db.FechaHora
                Fecha = dt(0)(0)
            Catch ex As Exception
            End Try

            Dim dtx As New DataTable
            Try
                dtx.Columns.Clear()
                dtx.Rows.Clear()
            Catch ex As Exception
            End Try
            dtx.Columns.Add("Usuario")

            For Each row As DataGridViewRow In DataDatos.Rows
                Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Asignar"), DataGridViewCheckBoxCell)
                If Convert.ToBoolean(cellSelecion.Value) Then
                    dtx.Rows.Add(row.Cells("ID").Value)
                End If
            Next

            Try
                'MsgBox("Fuera de  Función " & dtx.Rows.Count)
                Dim S = db.ModificaEstadoPendiente(ID, ComboBox1.Text, Fecha, dtx)

                MsgBox("Se cambió el estado de la tarea a " & ComboBox1.Text)
                Me.DialogResult = Windows.Forms.DialogResult.OK

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            For Each row As DataGridViewRow In DataDatos.Rows
                row.Cells("Asignar").Value = True
            Next
        Else
            For Each row As DataGridViewRow In DataDatos.Rows
                row.Cells("Asignar").Value = False
            Next
        End If
    End Sub

End Class