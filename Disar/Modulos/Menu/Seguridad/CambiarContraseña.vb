Imports Disar.data
Public Class CambiarContraseña
    Dim con As New clsSeguridad
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtPasAnt.Text = _Inicio.lblPass.Text Then
            If txtPass1.Text = "" Or txtPass2.Text = "" Then
                MsgBox("La Contraseña no puede estar en blanco", MsgBoxStyle.Information, "Confirmar Contraseña")
            Else
                If txtPass1.Text = txtPass2.Text Then
                    con.CambiarPass(_Inicio.lblId.Text, txtPass2.Text)
                    MsgBox("Se ha Cambiado la Contraseña", MsgBoxStyle.Information, "Datos Correctos")
                    Me.Close()
                Else
                    MsgBox("La Contraseña Nueva no Coincide", MsgBoxStyle.Information, "Confirmar Contraseña")
                End If
            End If
        Else
            MsgBox("La Contraseña Anterior no es la Correcta", MsgBoxStyle.Information, "Contraseña Erronea")
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class