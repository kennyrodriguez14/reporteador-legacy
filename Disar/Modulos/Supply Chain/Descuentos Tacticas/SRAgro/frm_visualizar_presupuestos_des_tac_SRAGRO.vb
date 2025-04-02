Imports Disar.data
Public Class frm_visualizar_presupuestos_des_tac_SRAGRO
    Dim conexion As New cls_descuentos_tacticos_sragro
    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        listar()
    End Sub

    Sub listar()
        Try
            grd_presupuestos.DataSource = conexion.listar_presupuestos(cmb_fecha.Value.Year, cmb_fecha.Value.Month, _
                                                                       DateAdd(DateInterval.Month, -1, cmb_fecha.Value).Year, _
                                                                       DateAdd(DateInterval.Month, -1, cmb_fecha.Value).Month)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_visualizar_presupuestos_des_tac_SRAGRO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class