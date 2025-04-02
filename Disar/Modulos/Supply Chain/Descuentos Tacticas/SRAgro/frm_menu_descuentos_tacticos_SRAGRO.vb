Imports Disar.data
Public Class frm_menu_descuentos_tacticos_SRAGRO
    Dim conexion As New cls_descuentos_tacticos_sragro
    Private Sub frm_menu_descuentos_tacticos_SRAGRO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _Inicio.permiso_cancelador = "1" Then
            btn_cancelar.Enabled = True
        Else
            btn_cancelar.Enabled = False
        End If
        cargar_almacen()
        cargar_datos()
    End Sub

    Sub cargar_almacen()
        Try
            cmb_almacen.DataSource = conexion.ListarAlmacenes
            cmb_almacen.DisplayMember = "ALMACEN"
            cmb_almacen.ValueMember = "ID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_datos()
        Try
            grd_lista.DataSource = conexion.ListarDescuentos_encabezados(cmb_fecha.Value, cmb_almacen.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar_datos()
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        frm_nuevo_descuento_tactico_SRAGRO.Close()
        frm_nuevo_descuento_tactico_SRAGRO.ShowDialog()
        cargar_datos()
    End Sub

    Private Sub btn_detalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_detalles.Click
        Try
            frm_detalle_SRAGRO.Close()
            frm_detalle_SRAGRO.txt_num_registro.Text = grd_lista.CurrentRow.Cells(0).Value
            frm_detalle_SRAGRO.txt_codigo_cliente.Text = grd_lista.CurrentRow.Cells(1).Value
            frm_detalle_SRAGRO.txt_nombre_cliente.Text = grd_lista.CurrentRow.Cells(2).Value
            frm_detalle_SRAGRO.txt_numero_factura.Text = grd_lista.CurrentRow.Cells(3).Value
            frm_detalle_SRAGRO.txt_sucursal.Text = grd_lista.CurrentRow.Cells(5).Value
            frm_detalle_SRAGRO.txt_tipo.Text = grd_lista.CurrentRow.Cells(6).Value
            frm_detalle_SRAGRO.txt_total.Text = grd_lista.CurrentRow.Cells(7).Value
            frm_detalle_SRAGRO.txt_fecha.Text = grd_lista.CurrentRow.Cells(9).Value

            frm_detalle_SRAGRO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cargar_datos()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            frm_resumen_des_tac_SRAGRO.Close()
            frm_resumen_des_tac_SRAGRO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_presupuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_presupuestos.Click
        Try
            frm_visualizar_presupuestos_des_tac_SRAGRO.Close()
            frm_visualizar_presupuestos_des_tac_SRAGRO.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Try
            frm_cancelar_nc_sr_agro.Close()
            frm_cancelar_nc_sr_agro.txt_nc.Text = grd_lista.CurrentRow.Cells(10).Value
            frm_cancelar_nc_sr_agro.txt_cliente.Text = grd_lista.CurrentRow.Cells(2).Value
            frm_cancelar_nc_sr_agro.txt_cod_cliente.Text = grd_lista.CurrentRow.Cells(1).Value
            frm_cancelar_nc_sr_agro.txt_monto.Text = grd_lista.CurrentRow.Cells(7).Value
            frm_cancelar_nc_sr_agro.txt_codigo_local.Text = grd_lista.CurrentRow.Cells(0).Value
            frm_cancelar_nc_sr_agro.txt_tipo.Text = grd_lista.CurrentRow.Cells(6).Value
            frm_cancelar_nc_sr_agro.txt_cargo_por_dev.Text = "NC" & Convert.ToInt32(grd_lista.CurrentRow.Cells(10).Value.ToString().Substring(10, 8))
            frm_cancelar_nc_sr_agro.txt_factura.Text = grd_lista.CurrentRow.Cells(3).Value
            'frm_cancelar_nc.txt_ctlpol.Text = grd_lista.CurrentRow.Cells(12).Value
            frm_cancelar_nc_sr_agro.ShowDialog()
            cargar_datos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class