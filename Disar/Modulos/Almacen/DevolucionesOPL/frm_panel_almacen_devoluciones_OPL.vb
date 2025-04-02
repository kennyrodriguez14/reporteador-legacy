Imports Disar.data
Public Class frm_panel_almacen_devoluciones_OPL
    Dim conexion As New cls_devoluciones
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        frm_devoluciones_ingresadas_OPL.Close()
        frm_devoluciones_ingresadas_OPL.ShowDialog()
        cargar()
    End Sub

    Private Sub frm_panel_almacen_devoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_almacen()
        cargar_almacen()
        cargar()
    End Sub

    Sub cargar_almacen()
        Try
            cmb_sucursal.DataSource = conexion.ListarAlmacenes2OPL()
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_recepciones.DataSource = conexion.lista_encabezados_devolucionesOPL(cmb_fecha_ini.Value, cmb_sucursal.SelectedValue,
                                                    "ENCABEZADO_RECEPCION", "", "", "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class