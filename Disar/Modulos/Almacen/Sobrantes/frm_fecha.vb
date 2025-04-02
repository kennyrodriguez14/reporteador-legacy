Public Class frm_fecha
    Public FECHA As Date

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        FECHA = cmb_fecha.Value.Date
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub
End Class



