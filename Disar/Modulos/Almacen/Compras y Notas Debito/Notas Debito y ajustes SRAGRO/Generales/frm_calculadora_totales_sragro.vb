Public Class frm_calculadora_totales_sragro

    Private Sub frm_calculadora_totales_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txt_totales_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_totales.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

End Class