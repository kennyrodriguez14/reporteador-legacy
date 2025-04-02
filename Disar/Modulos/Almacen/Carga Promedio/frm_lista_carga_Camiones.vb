Imports Disar.data

Public Class frm_lista_carga_Camiones
    Dim conexion As New cls_carga_camiones_formatofactura
    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        frm_carga_camiones.Close()
        frm_carga_camiones.ShowDialog()

    End Sub

    Private Sub frm_lista_carga_Camiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cargar_almacen()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_almacen()
        cmb_almacen.DataSource = conexion.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
        cmb_almacen.ValueMember = "ID"
        cmb_almacen.DisplayMember = "ALMACEN"
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Try
            grd_listado.DataSource = conexion.get_encabezado(cmb_fecha_ini.Value.Date, cmb_fecha_ini.Value.Date, cmb_almacen.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_listado_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_listado.CellDoubleClick
        frm_carga_camiones.Close()

        frm_carga_camiones.btn_guardar.Enabled = False
        'frm_carga_camiones.grd_ingreso.Enabled = False
        frm_carga_camiones.id.Visible = True
        frm_carga_camiones.label_id.Visible = True

        frm_carga_camiones.id.Text = grd_listado.CurrentRow.Cells(0).Value
        frm_carga_camiones.cmb_sucursal.SelectedValue = grd_listado.CurrentRow.Cells(1).Value
        frm_carga_camiones.cmb_fecha.Value = grd_listado.CurrentRow.Cells(2).Value
        frm_carga_camiones.cmb_turno.SelectedValue = grd_listado.CurrentRow.Cells(3).Value
        'frm_carga_camiones.btn_cambiar_sucursal.Enabled = False
        frm_carga_camiones.cmb_sucursal.Enabled = False
        frm_carga_camiones.cmb_fecha.Enabled = False
        frm_carga_camiones.cmb_turno.Enabled = False
        frm_carga_camiones.grd_ingreso.Visible = False

        frm_carga_camiones.cargar_partidas()

        frm_carga_camiones.ShowDialog()
    End Sub

    Private Sub mnu_reporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_reporte.Click
        frm_reporte_carga_camiones.Close()
        frm_reporte_carga_camiones.ShowDialog()
    End Sub
End Class