Imports Disar.data

Public Class FrmGestionPendientes

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim db As New clsReuniones
        If RadioTodas.Checked = True Then
            If ComboColaborador.Text = "Todos" Then
                Try
                    DataDatos.DataSource = db.ControlPendientes(DateTimePicker1.Value, DateTimePicker2.Value, _Inicio.lblUsuario.Text)
                    DataDatos.Columns("Respon").Visible = False
                    DataDatos.Columns("Registro").Visible = False
                    DataDatos.Columns("Reunion").Visible = False
                    DataDatos.Columns("Nom").Visible = False
                    DataDatos.Columns("Asignado").Visible = False
                    UsuariosXPendiente()
                Catch ex As Exception
                End Try
            Else
                Try
                    DataDatos.DataSource = db.ControlPendientes(DateTimePicker1.Value, DateTimePicker2.Value, _Inicio.lblUsuario.Text)
                    DataDatos.Columns("Respon").Visible = False
                    DataDatos.Columns("Registro").Visible = False
                    DataDatos.Columns("Reunion").Visible = False
                    DataDatos.Columns("Nom").Visible = False
                    DataDatos.Columns("Asignado").Visible = False
                    UsuariosXPendiente()
                Catch ex As Exception
                End Try
            End If

        Else
            Try
                DataDatos.DataSource = db.ControlPendientesFiltrados(DateTimePicker1.Value, DateTimePicker2.Value, _Inicio.lblUsuario.Text)
                DataDatos.Columns("Respon").Visible = False
                DataDatos.Columns("Registro").Visible = False
                DataDatos.Columns("Reunion").Visible = False
                DataDatos.Columns("Nom").Visible = False
                DataDatos.Columns("Asignado").Visible = False
                UsuariosXPendiente()
            Catch ex As Exception
            End Try
        End If
        Try
            DataDatos.Columns(1).DividerWidth = 3
            DataDatos.Columns(1).Frozen = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmGestionPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BtnBuscar.PerformClick()
    End Sub

    Sub LlenaUsuarios()
        Dim db As New clsReuniones
        Try
            ComboColaborador.DataSource = db.UsuariosConPendientes
            ComboColaborador.ValueMember = "Asignado"
            ComboColaborador.DisplayMember = "UsuarioNombre"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellDoubleClick
        Dim db As New clsReuniones
        Dim dt As New DataTable

        Dim Responsable As String = DataDatos.CurrentRow.Cells("Respon").Value
        Dim Solicitante As String = DataDatos.CurrentRow.Cells("Solicitante").Value
        If Responsable = _Inicio.lblUsuario.Text Or Solicitante = _Inicio.lblUsuario.Text Then
            FormCambioEstado.ID = DataDatos.CurrentRow.Cells(0).Value
            If FormCambioEstado.ShowDialog = Windows.Forms.DialogResult.OK Then
                BtnBuscar.PerformClick()
            End If
        Else
            MsgBox("Sólo el responsable de la reunión o el solicitante de la asignación puede cambiar el estado de una tarea", MsgBoxStyle.Information, "Bitácora")
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
            For Each row As DataGridViewRow In DataDatos.Rows
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
