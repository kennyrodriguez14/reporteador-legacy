Imports Disar.data

Public Class FormBitacoraReuniones

    Private Sub FormBitacoraReuniones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaCombo()
    End Sub

    Sub CargaCombo()
        Dim db As New clsReuniones
        Try
            ComboReuniones.DataSource = db.ReunionesCombo(NICK.Text)
            ComboReuniones.ValueMember = "Nº"
            ComboReuniones.DisplayMember = "Reunion"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buscar.Click
        Dim db As New clsReuniones
        If ComboReuniones.Text = "Todas" Then
            Try
                DataDatos.DataSource = db.HistorialReuniones(_Inicio.lblUsuario.Text, DateTimePicker1.Value, DateTimePicker2.Value)
                DataDatos.Columns("Responsable").Visible = False
            Catch ex As Exception
            End Try
        End If
        Try
            DataTemas.DataSource = db.HistorialTemas(DataDatos.CurrentRow.Cells(0).Value)
            DataParticipantes.DataSource = db.HistorialAsistencias(DataDatos.CurrentRow.Cells(0).Value)
            DataTareas.DataSource = db.HistorialAsignaciones(DataDatos.CurrentRow.Cells(0).Value)
            UsuariosXPendiente()
            TextBox1.Text = DataDatos.CurrentRow.Cells("Observaciones").Value
        Catch ex As Exception
        End Try
        Try
            DataTareas.Columns(1).Frozen = True
            DataTareas.Columns(1).DividerWidth = 3
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellClick
        Dim db As New clsReuniones

        Try
            DataTemas.DataSource = db.HistorialTemas(DataDatos.CurrentRow.Cells(0).Value)
            DataParticipantes.DataSource = db.HistorialAsistencias(DataDatos.CurrentRow.Cells(0).Value)
            DataTareas.DataSource = db.HistorialAsignaciones(DataDatos.CurrentRow.Cells(0).Value)
            TextBox1.Text = DataDatos.CurrentRow.Cells("Observaciones").Value
            UsuariosXPendiente()
        Catch ex As Exception
        End Try
        Try
            DataTareas.Columns(1).Frozen = True
            DataTareas.Columns(1).DividerWidth = 3
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataTareas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataTareas.CellDoubleClick
        If DataDatos.CurrentRow.Cells("Responsable").Value = _Inicio.lblUsuario.Text Or DataTareas.CurrentRow.Cells("Solicitante").Value = _Inicio.lblUsuario.Text Then
            FormCambioEstado.ID = DataTareas.CurrentRow.Cells(0).Value

            If FormCambioEstado.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim db As New clsReuniones
                    DataTareas.DataSource = db.HistorialAsignaciones(DataDatos.CurrentRow.Cells(0).Value)
                    UsuariosXPendiente()
                Catch ex As Exception
                End Try
            End If
        Else
            MsgBox("Solo el responsable de la reunión o el solicitante la asignación puede cambiar el estado de la misma", MsgBoxStyle.Information, "Bitácora")
        End If
    End Sub
 
    Private Sub DataTareas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataTareas.CellClick
        If e.ColumnIndex = DataTareas.Columns("Entrega Prevista").Index Then
            If DataTareas.CurrentRow.Cells(e.ColumnIndex).Value = "Agregar Fecha" Then
                FormCambioFecha.Numero.Text = DataTareas.CurrentRow.Cells(0).Value
                FormCambioFecha.Pendiente.Text = DataTareas.CurrentRow.Cells(1).Value
                If FormCambioFecha.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        Dim db As New clsReuniones
                        DataTareas.DataSource = db.HistorialAsignaciones(DataDatos.CurrentRow.Cells(0).Value)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
    End Sub

    Sub UsuariosXPendiente()
        Dim db As New clsReuniones
        Dim dt As New DataTable
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        Try
            For Each row As DataGridViewRow In DataTareas.Rows
                dt = db.UsuariosXPendiente(row.Cells(0).Value)
                row.Cells("Asignado a").Value = ""
                If dt.Rows.Count = 1 Then
                    row.Cells("Asignado a").Value = dt(0)(0)
                Else
                    row.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    For Sabu As Integer = 0 To dt.Rows.Count - 1
                        If Sabu = dt.Rows.Count - 1 Then
                            row.Cells("Asignado a").Value = row.Cells("Asignado a").Value & dt(Sabu)(0)
                        Else
                            row.Cells("Asignado a").Value = row.Cells("Asignado a").Value & dt(Sabu)(0) & vbNewLine
                        End If

                    Next
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class