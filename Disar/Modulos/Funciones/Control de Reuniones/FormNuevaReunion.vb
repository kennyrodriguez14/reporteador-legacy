Imports Disar.data

Public Class FormNuevaReunion
    Public Dia As Integer
    Public Responsable As String

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim dtParticipantes As New DataTable
        Dim dtTareas As New DataTable

        Try
            dtParticipantes.Rows.Clear()
        Catch ex As Exception
        End Try
        Try
            dtTareas.Rows.Clear()
        Catch ex As Exception
        End Try

        Dia = ComboDia.SelectedIndex + 1
        dtParticipantes.Columns.Add("Nick")
        dtParticipantes.Columns.Add("Nombre")

        dtTareas.Columns.Add("Tema")

        For Each row As DataGridViewRow In DataParticipantes.Rows
            dtParticipantes.Rows.Add(row.Cells(0).Value, row.Cells(1).Value)
        Next

        For Each row As DataGridViewRow In DataTemas.Rows
            If row.Cells("Tema").Value <> "" Then
                dtTareas.Rows.Add(row.Cells("Tema").Value)
            End If
        Next

        Dim db As New clsReuniones
        Try
            Dim s = db.AgregarDetalleNuevaReunion(0, TextNombre.Text, DateTimePicker1.Text, DateTimePicker2.Text, Responsable, _Inicio.lblUsuario.Text, dtParticipantes, dtTareas, TextExtra.Text, TextPeriodo.Text, Dia)
            If s = "s" Then
                MsgBox("Se ha guardado la reunión con éxito", MsgBoxStyle.Information)
                FormReunionesPrincipal.CargaReuniones()
                Me.Dispose()
            Else
                MsgBox(s)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FrmAdicionUsuarios.ShowDialog = Windows.Forms.DialogResult.OK Then
            Responsable = FrmAdicionUsuarios.Nick
            TextResponsable.Text = FrmAdicionUsuarios.Nombre
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If FrmAdicionUsuarios.ShowDialog = Windows.Forms.DialogResult.OK Then
            DataParticipantes.Rows.Add(FrmAdicionUsuarios.Nick, FrmAdicionUsuarios.Nombre)
        End If
    End Sub

    Private Sub BtnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitar.Click
        DataParticipantes.Rows.Remove(DataParticipantes.CurrentRow)
    End Sub
End Class