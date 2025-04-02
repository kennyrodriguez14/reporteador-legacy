Imports Disar.data

Public Class fmr_lista_facturas
    Dim conexion As New cls_facturacion_creditos
    Private Sub fmr_lista_facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmb_almacen.DataSource = conexion.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "ALMACEN"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Try
            grd_lista.DataSource = conexion.Encabezados(cmb_fecha.Value, cmb_almacen.SelectedValue)

            grd_lista.Columns(7).Visible = False
            grd_lista.Columns(8).Visible = False
            grd_lista.Columns(9).Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_lista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grd_lista.KeyDown
        If e.KeyCode = Keys.Enter Then

            'frm_detalle_factura.tx()
            frm_detalle_factura.txt_num_factura.Text = grd_lista.CurrentRow.Cells(0).Value
            frm_detalle_factura.lbl_codigo.Text = grd_lista.CurrentRow.Cells(1).Value
            frm_detalle_factura.lbl_clientes.Text = grd_lista.CurrentRow.Cells(2).Value
            frm_detalle_factura.txt_cve_vend.Text = grd_lista.CurrentRow.Cells(3).Value
            frm_detalle_factura.txtfecha.Text = grd_lista.CurrentRow.Cells(4).Value
            frm_detalle_factura.txtalmacen.Text = grd_lista.CurrentRow.Cells(5).Value

            frm_detalle_factura.txttotal.Text = grd_lista.CurrentRow.Cells(6).Value
            frm_detalle_factura.txtdescuento.Text = grd_lista.CurrentRow.Cells(7).Value
            frm_detalle_factura.txtsubtotal.Text = grd_lista.CurrentRow.Cells(8).Value
            frm_detalle_factura.txtisv.Text = grd_lista.CurrentRow.Cells(9).Value

            frm_detalle_factura.ShowDialog()


        End If
    End Sub

    Private Sub grd_lista_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_lista.CellMouseDoubleClick
        frm_detalle_factura.txt_num_factura.Text = grd_lista.CurrentRow.Cells(0).Value
        frm_detalle_factura.lbl_codigo.Text = grd_lista.CurrentRow.Cells(1).Value
        frm_detalle_factura.lbl_clientes.Text = grd_lista.CurrentRow.Cells(2).Value
        frm_detalle_factura.txt_cve_vend.Text = grd_lista.CurrentRow.Cells(3).Value
        frm_detalle_factura.txtfecha.Text = grd_lista.CurrentRow.Cells(4).Value
        frm_detalle_factura.txtalmacen.Text = grd_lista.CurrentRow.Cells(5).Value

        frm_detalle_factura.txttotal.Text = grd_lista.CurrentRow.Cells(6).Value
        frm_detalle_factura.txtdescuento.Text = grd_lista.CurrentRow.Cells(7).Value
        frm_detalle_factura.txtsubtotal.Text = grd_lista.CurrentRow.Cells(8).Value
        frm_detalle_factura.txtisv.Text = grd_lista.CurrentRow.Cells(9).Value

        frm_detalle_factura.ShowDialog()
    End Sub

    Private Sub NuevaFacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaFacturaToolStripMenuItem.Click
        frm_facturas_credito.ShowDialog()
    End Sub


End Class