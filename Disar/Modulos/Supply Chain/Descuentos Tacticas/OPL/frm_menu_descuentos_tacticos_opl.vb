﻿Imports Disar.data
Public Class frm_menu_descuentos_tacticos_opl

    Dim conexion As New cls_descuentos_tacticos
    Private Sub frm_menu_descuentos_tacticos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            cmb_almacen.DataSource = conexion.ListarAlmacenesOPL
            cmb_almacen.DisplayMember = "ALMACEN"
            cmb_almacen.ValueMember = "ID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_datos()
        Try
            grd_lista.DataSource = conexion.ListarDescuentos_encabezados_OPL(cmb_fecha.Value, cmb_almacen.SelectedValue)
            grd_lista.Columns(4).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar_datos()
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        frm_nuevo_descuento_tactico_opl.Close()
        frm_nuevo_descuento_tactico_opl.ShowDialog()
        cargar_datos()
    End Sub

    Private Sub btn_detalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_detalles.Click
        Try
            frm_detalle_OPL.Close()
            frm_detalle_OPL.txt_num_registro.Text = grd_lista.CurrentRow.Cells(0).Value
            frm_detalle_OPL.txt_codigo_cliente.Text = grd_lista.CurrentRow.Cells(1).Value
            frm_detalle_OPL.txt_nombre_cliente.Text = grd_lista.CurrentRow.Cells(2).Value
            frm_detalle_OPL.txt_numero_factura.Text = grd_lista.CurrentRow.Cells(3).Value
            frm_detalle_OPL.txt_sucursal.Text = grd_lista.CurrentRow.Cells(5).Value
            frm_detalle_OPL.txt_tipo.Text = grd_lista.CurrentRow.Cells(6).Value
            frm_detalle_OPL.txt_total.Text = grd_lista.CurrentRow.Cells(7).Value
            frm_detalle_OPL.txt_fecha.Text = grd_lista.CurrentRow.Cells(9).Value

            frm_detalle_dimosa.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cargar_datos()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            frm_resumen_des_tac_OPL.Close()
            frm_resumen_des_tac_opl.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_presupuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_presupuestos.Click
        Try
            frm_visualizar_presupuestos_des_tac_opl.Close()
            frm_visualizar_presupuestos_des_tac_opl.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Try
            frm_cancelar_nc_opl.Close()
            frm_cancelar_nc_opl.txt_nc.Text = grd_lista.CurrentRow.Cells(10).Value
            frm_cancelar_nc_opl.txt_cliente.Text = grd_lista.CurrentRow.Cells(2).Value
            frm_cancelar_nc_opl.txt_cod_cliente.Text = grd_lista.CurrentRow.Cells(1).Value
            frm_cancelar_nc_opl.txt_monto.Text = grd_lista.CurrentRow.Cells(7).Value
            frm_cancelar_nc_opl.txt_codigo_local.Text = grd_lista.CurrentRow.Cells(0).Value
            frm_cancelar_nc_opl.txt_tipo.Text = grd_lista.CurrentRow.Cells(6).Value
            frm_cancelar_nc_opl.txt_cargo_por_dev.Text = "NC" & Convert.ToInt32(grd_lista.CurrentRow.Cells(10).Value.ToString().Substring(10, 8))
            frm_cancelar_nc_opl.txt_factura.Text = grd_lista.CurrentRow.Cells(3).Value
            'frm_cancelar_nc_opl.txt_ctlpol.Text = grd_lista.CurrentRow.Cells(12).Value
            frm_cancelar_nc_opl.ShowDialog()
            cargar_datos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class