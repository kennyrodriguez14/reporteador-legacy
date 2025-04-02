Imports Disar.data

Public Class FrmAgregaPantalla

    Public Vendedor As Integer

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim db As New ClsMatinalAgro
        Dim s = db.NuevaPantalla(ComboBox1.Text, Vendedor)
        If s = "s" Then
            MsgBox("Pantala agregada al vendedor", MsgBoxStyle.Information)
            FrmPresupuestosAgroMatinal.ActualizaPantallas(Vendedor.ToString)
            Me.Close()
        Else
            MsgBox(s)
        End If
    End Sub
 
End Class