Imports Disar.data
Public Class frm_ordenes_pedidos_sragro
    Dim conexion As New cls_notas_debito_SRAGRO
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_lista_remisiones.DataSource = conexion.lista_ordenes_pedidos(cmb_fecha_ini.Value.Date, cmb_fecha_fin.Value.Date)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        frm_orden_pedidos_sragro.Close()
        frm_orden_pedidos_sragro.ShowDialog()
        frm_orden_pedidos_sragro.modo = "ins"
        cargar()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click

        If grd_lista_remisiones.CurrentRow.Cells(6).Value = "PENDIENTE" Then
            If MessageBox.Show("Desea eliminar la orden de pedido " + grd_lista_remisiones.CurrentRow.Cells(0).Value, "Confirmacion" _
                           , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim variable As String = ""
                variable = conexion.eliminar_orden(grd_lista_remisiones.CurrentRow.Cells(0).Value)
                If variable = "correcto" Then
                    MessageBox.Show("Orden eliminada")
                Else
                    MessageBox.Show(variable)
                End If
            End If
        Else
            MessageBox.Show("No puede eliminar la Orden de pedido")
        End If

        cargar()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
        frm_orden_pedidos_sragro.Close()
        frm_orden_pedidos_sragro.modo = "upd"
        frm_orden_pedidos_sragro.btn_new_prov.Enabled = False
        frm_orden_pedidos_sragro.btn_get_folio.Enabled = False
        frm_orden_pedidos_sragro.txt_num_registro.Text = grd_lista_remisiones.CurrentRow.Cells(0).Value
        frm_orden_pedidos_sragro.txt_codigo_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(1).Value
        frm_orden_pedidos_sragro.txt_nombre_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
        frm_orden_pedidos_sragro.txt_rfc.Text = grd_lista_remisiones.CurrentRow.Cells(3).Value
        frm_orden_pedidos_sragro.cmb_sucursal.SelectedValue = grd_lista_remisiones.CurrentRow.Cells(4).Value
        frm_orden_pedidos_sragro.cmb_fecha_documento.Value = grd_lista_remisiones.CurrentRow.Cells(5).Value
        frm_orden_pedidos_sragro.txt_subtotal_final.Text = grd_lista_remisiones.CurrentRow.Cells(7).Value
        frm_orden_pedidos_sragro.txt_descuento_final.Text = grd_lista_remisiones.CurrentRow.Cells(8).Value
        frm_orden_pedidos_sragro.txt_isv_final.Text = grd_lista_remisiones.CurrentRow.Cells(9).Value
        frm_orden_pedidos_sragro.txt_total_final.Text = grd_lista_remisiones.CurrentRow.Cells(10).Value

        frm_orden_pedidos_sragro.ShowDialog()
        cargar()
    End Sub

    Private Sub frm_ordenes_pedidos_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Private Sub grd_lista_remisiones_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_lista_remisiones.CellDoubleClick
        Try
            frm_orden_pedidos_sragro.Close()
            frm_orden_pedidos_sragro.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class