Imports Disar.data
Public Class ContadorAccesos

    Private Sub ContadorAccesos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Actualizar.PerformClick()
    End Sub

    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualizar.Click
        Dim db As New clsSeguridad
        DataGridView1.DataSource = db.Contador
    End Sub

 
End Class