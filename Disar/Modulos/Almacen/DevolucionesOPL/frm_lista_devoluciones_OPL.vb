Imports Disar.data
Public Class frm_lista_devoluciones_OPL
    Dim conexion As New cls_devoluciones
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        frm_nueva_devolucion_OPL.Close()
        frm_nueva_devolucion_OPL.modo = "ins"
        frm_nueva_devolucion_OPL.ShowDialog()
        cargar()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        'MessageBox.Show("Funcion no disponible por el momento")
        'Try
        '    If grd_lista_devoluciones.CurrentRow.Cells(2).Value <> "PENDIENTE" Then
        '        MessageBox.Show("La devolucion ya fue enviada a SAE, no se puede Modificar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Else
        '        frm_nueva_devolucion.Close()
        '        frm_nueva_devolucion.modo = "upd"
        '        frm_nueva_devolucion.ShowDialog()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        If grd_lista_devoluciones.RowCount > 0 Then
            frm_nueva_devolucion_OPL.Close()
            frm_nueva_devolucion_OPL.modo = "visualice"
            frm_nueva_devolucion_OPL.num_reg = grd_lista_devoluciones.CurrentRow.Cells(0).Value
            frm_nueva_devolucion_OPL.txt_codigo_cliente.Text = grd_lista_devoluciones.CurrentRow.Cells(3).Value
            frm_nueva_devolucion_OPL.txt_nombre_cliente.Text = grd_lista_devoluciones.CurrentRow.Cells(4).Value
            frm_nueva_devolucion_OPL.txt_tipo.Text = grd_lista_devoluciones.CurrentRow.Cells(5).Value
            frm_nueva_devolucion_OPL.txt_codigo_vendedor.Text = grd_lista_devoluciones.CurrentRow.Cells(6).Value
            frm_nueva_devolucion_OPL.txt_numero_factura.Text = grd_lista_devoluciones.CurrentRow.Cells(1).Value
            frm_nueva_devolucion_OPL.cmb_concepto.SelectedValue = grd_lista_devoluciones.CurrentRow.Cells(10).Value
            frm_nueva_devolucion_OPL.txt_codigo_entregador.Text = grd_lista_devoluciones.CurrentRow.Cells(11).Value
            frm_nueva_devolucion_OPL.txt_entregador.Text = grd_lista_devoluciones.CurrentRow.Cells(12).Value
            frm_nueva_devolucion_OPL.txt_vehiculo.Text = grd_lista_devoluciones.CurrentRow.Cells(13).Value

            frm_nueva_devolucion_OPL.grp_ingreso_datos.Enabled = False
            frm_nueva_devolucion_OPL.ShowDialog()
        End If

    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            If grd_lista_devoluciones.CurrentRow.Cells(2).Value <> "PENDIENTE" Then
                MessageBox.Show("La devolucion ya fue enviada a SAE, no se puede eliminar", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If MessageBox.Show("¿Desea Eliminar la Devolucion " + grd_lista_devoluciones.CurrentRow.Cells(0).Value, "Confirmacion", _
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim variable_error As String = ""
                    variable_error = conexion.eliminar_devolucionOPL(grd_lista_devoluciones.CurrentRow.Cells(0).Value)

                    If variable_error = "correcto" Then
                        MessageBox.Show("Registro Eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim conexion_bita As New cls_bitacora_reporteador
                        conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Elimino Devolucion OPL ", "Almacen - Devoluciones - OPL ",
                                                  "Fecha: " + cmb_fecha_ini.Value +
                                                  " Factura: " + grd_lista_devoluciones.CurrentRow.Cells(1).Value)

                        cargar()
                    Else
                        MessageBox.Show(variable_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_lista_devoluciones.DataSource = conexion.lista_encabezados_devolucionesOPL(cmb_fecha_ini.Value,
                                                    cmb_sucursal.SelectedValue, "ENCABEZADO", "", "", "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_lista_devoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        carga_almacen()

    End Sub

    Sub carga_almacen()
        Try
            cmb_sucursal.DataSource = conexion.ListarAlmacenesOPL()
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"
            cmb_sucursal.SelectedValue = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripSeparator5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSeparator5.Click

    End Sub

    Private Sub mnu_carga_entregadores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_carga_entregadores.Click
        frm_carga_devos_OPL.Close()
        frm_carga_devos_OPL.ShowDialog()
    End Sub
End Class