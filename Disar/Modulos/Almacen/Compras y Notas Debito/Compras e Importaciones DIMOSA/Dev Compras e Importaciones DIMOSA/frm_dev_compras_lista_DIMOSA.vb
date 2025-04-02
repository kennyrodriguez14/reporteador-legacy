Imports Disar.data

Public Class frm_dev_compras_lista_DIMOSA
    Dim conexion As New cls_notas_debito
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        'frm_nueva_devolucion_importacion_dimosa.MdiParent = _Inicio
        'frm_nueva_devolucion_importacion_dimosa.Visible = True
        cargar()
    End Sub

    Private Sub frm_dev_compras_lista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_lista_remisiones.DataSource = conexion.lista_devoluciones_importaciones(cmb_fecha_ini.Value.Date, cmb_fecha_fin.Value.Date)
            'grd_lista_remisiones.Columns(6).Visible = False
            'grd_lista_remisiones.Columns(10).Visible = False
            'grd_lista_remisiones.Columns(7).Visible = False
            'grd_lista_remisiones.Columns(12).Visible = False
            'grd_lista_remisiones.Columns(13).Visible = False
            'grd_lista_remisiones.Columns(14).Visible = False
            'grd_lista_remisiones.Columns(15).Visible = False
            'grd_lista_remisiones.Columns(16).Visible = False
            'grd_lista_remisiones.Columns(17).Visible = False
            'grd_lista_remisiones.Columns(18).Visible = False
            'grd_lista_remisiones.Columns(19).Visible = False
            'grd_lista_remisiones.Columns(20).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_lista_remisiones_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista_remisiones.DoubleClick
        'Try
        '    frm_nueva_devolucion_importacion_dimosa.Close()
        '    frm_nueva_devolucion_importacion_dimosa.MdiParent = _Inicio
        '    frm_nueva_devolucion_importacion_dimosa.modo = "upd"
        '    frm_nueva_devolucion_importacion_dimosa.cve_compra = grd_lista_remisiones.CurrentRow.Cells(0).Value
        '    frm_nueva_devolucion_importacion_dimosa.txt_codigo_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(1).Value
        '    frm_nueva_devolucion_importacion_dimosa.txt_nombre_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(2).Value
        '    frm_nueva_devolucion_importacion_dimosa.txt_rfc.Text = grd_lista_remisiones.CurrentRow.Cells(5).Value
        '    frm_nueva_devolucion_importacion_dimosa.txt_referencia_proveedor.Text = grd_lista_remisiones.CurrentRow.Cells(4).Value
        '    frm_nueva_devolucion_importacion_dimosa.cmb_fecha_documento.Value = grd_lista_remisiones.CurrentRow.Cells(6).Value
        '    frm_nueva_devolucion_importacion_dimosa.txt_total_final.Text = grd_lista_remisiones.CurrentRow.Cells(11).Value
        '    frm_nueva_devolucion_importacion_dimosa.get_almacen()
        '    frm_nueva_devolucion_importacion_dimosa.cmb_sucursal.SelectedValue = grd_lista_remisiones.CurrentRow.Cells(3).Value
        '    frm_nueva_devolucion_importacion_dimosa.Visible = True
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
End Class