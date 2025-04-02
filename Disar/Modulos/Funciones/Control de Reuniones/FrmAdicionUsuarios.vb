Imports Disar.data

Public Class FrmAdicionUsuarios

    Public Nombre As String
    Public Nick As String

    Private Sub FrmAdicionUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Nick = DataGridView1.CurrentRow.Cells(0).Value
        Nombre = DataGridView1.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
End Class