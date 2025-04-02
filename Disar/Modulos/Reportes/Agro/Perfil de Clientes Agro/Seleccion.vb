Imports System.Data.SqlClient

Public Class Seleccion

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Ver Información" Then
            Vista.Close()

            Vista.Show()
        Else
            Edicion.Close()

            Edicion.Show()
        End If
        Me.Close()
    End Sub

    Private Sub Key(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress, Me.KeyPress
        If e.KeyChar = " " Then
            If Vista.Visible = True Then
                Vista.Close()
            End If
            Vista.Show()
        End If
        If e.KeyChar = Chr(13) Then
            If Edicion.Visible = True Then
                Edicion.Close()
            End If
            Edicion.Show()
        End If
        Me.Close()
    End Sub
 
End Class