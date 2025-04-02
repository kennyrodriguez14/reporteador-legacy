Imports Disar.data
Public Class frm_visualizar_presupuestos_des_tac_OPL
    Dim conexion As New cls_descuentos_tacticos
    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        listar()
    End Sub

    Sub listar()
        Try
            grd_presupuestos.DataSource = conexion.listar_presupuestosOPL(cmb_fecha.Value.Year, cmb_fecha.Value.Month,
                                                                       DateAdd(DateInterval.Month, -1, cmb_fecha.Value).Year,
                                                                       DateAdd(DateInterval.Month, -1, cmb_fecha.Value).Month)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class