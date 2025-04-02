Public Class frm_totalizador_dimosa
    Public tasa_cambio As Double = 0

    Private Sub frm_totalizador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim total_compra As Double = 0, total_operacion As Double = 0
        total_compra = Val(txt_flete.Text.Replace(",", "")) + Val(txt_seguro.Text.Replace(",", "")) + Val(txt_pyc.Text.Replace(",", "")) _
        + Val(txt_honorarios.Text.Replace(",", "")) + Val(txt_parqueo_D.Text.Replace(",", "")) + Val(txt_rev_des_carg_D.Text.Replace(",", "")) _
        + Val(txt_emision_gr_D.Text.Replace(",", "")) + Val(txt_encomiendas_D.Text.Replace(",", "")) + Val(txt_gastos_variables_d.Text.Replace(",", "")) _
        + Val(txt_servicio_tranporte_datos.Text.Replace(",", "")) + Val(txt_servicio_portuario.Text.Replace(",", "")) + _
        Val(txt_especies_fiscales.Text.Replace(",", "")) + Val(txt_dai.Text.Replace(",", "")) + Val(txt_ivz.Text.Replace(",", "")) + Val(txt_fob.Text.Replace(",", ""))

        txt_total_compra.Text = total_compra.ToString("N2")
        total_operacion = total_compra + Val(txt_isv.Text.Replace(",", ""))
        txt_total_operacion.Text = total_operacion.ToString("N2")


        txt_flete_l.Text = (Val(txt_flete.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_seguro_l.Text = (Val(txt_seguro.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_pyc_l.Text = (Val(txt_pyc.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_honorarios_l.Text = (Val(txt_honorarios.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_parqueo_L.Text = (Val(txt_parqueo_D.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_rev_des_carg_L.Text = (Val(txt_rev_des_carg_D.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_emision_gr_L.Text = (Val(txt_emision_gr_D.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_encomiendas_L.Text = (Val(txt_encomiendas_D.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_gastos_variables_l.Text = (Val(txt_gastos_variables_d.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_servicio_transporte_datos_L.Text = (Val(txt_servicio_tranporte_datos.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_servicio_portuarioL.Text = (Val(txt_servicio_portuario.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_especies_fiscalesL.Text = (Val(txt_especies_fiscales.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_daiL.Text = (Val(txt_dai.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_ivzL.Text = (Val(txt_ivz.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_fobl.Text = (Val(txt_fob.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_total_compral.Text = (Val(txt_total_compra.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_isv_l.Text = (Val(txt_isv.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
        txt_total_operacionl.Text = (Val(txt_total_operacion.Text.Replace(",", "")) * tasa_cambio).ToString("N2")
    End Sub

    Private Sub frm_totalizador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class