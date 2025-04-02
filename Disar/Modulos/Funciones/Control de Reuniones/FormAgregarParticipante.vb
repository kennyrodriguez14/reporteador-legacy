Imports Disar.data

Public Class FormAgregarParticipante

    Public Numero As Integer

    Private Sub FormAgregarParticipante_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New clsReuniones
        Try
            DataGridView1.DataSource = db.Usuarios
            DataGridView1.Columns(0).Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim db As New clsReuniones
        Try
            DataGridView1.DataSource = db.UsuariosFiltro(TextBox1.Text)
            DataGridView1.Columns(0).Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim db As New clsReuniones
        Try
            Dim respuesta = MsgBox("¿Desea agregar a " & DataGridView1.CurrentRow.Cells(1).Value & " a los participantes?", MsgBoxStyle.YesNo)

            If respuesta = MsgBoxResult.Yes Then
                Dim s = db.INSERTARParticipante(DataGridView1.CurrentRow.Cells(0).Value, "A", Numero)
                Try
                    FrmLlenadoReunion.DataParticipantes.DataSource = Nothing
                    FrmLlenadoReunion.DataParticipantes.Columns.Clear()
                Catch ex As Exception
                End Try

                FrmLlenadoReunion.DataParticipantes.DataSource = db.ParticipantesReunion(FrmLlenadoReunion.ReunionID.Text)

                Dim column0 As New DataGridViewCheckBoxColumn
                column0.Name = "Asistencia"
                column0.HeaderText = "Asistencia"

                Dim column As New DataGridViewComboBoxColumn
                column.Items.Clear()
                column.Items.Add("Presencial")
                column.Items.Add("Remoto")

                column.Name = "Medio Asistencia"
                column.HeaderText = "Medio Asistencia"

                Dim column1 As New DataGridViewTextBoxColumn
                column1.Name = "HoraAsistencia"
                column1.HeaderText = "Hora de Entrada"

                FrmLlenadoReunion.DataParticipantes.Columns.Add(column0)
                FrmLlenadoReunion.DataParticipantes.Columns.Add(column)
                FrmLlenadoReunion.DataParticipantes.Columns.Add(column1)
                Me.Close()
            End If
             
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class