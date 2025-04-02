Imports Disar.data

Public Class UsuariosConectados
    Private Sub UsuariosConectados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New clsSeguridad
        DataGridView1.DataSource = db.En_Linea
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim db As New clsSeguridad
        DataGridView1.DataSource = db.En_Linea
    End Sub
End Class