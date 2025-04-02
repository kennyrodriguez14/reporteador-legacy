Public Class frm_calculadora_totales

    Private Sub txt_totales_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_totales.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
End Class