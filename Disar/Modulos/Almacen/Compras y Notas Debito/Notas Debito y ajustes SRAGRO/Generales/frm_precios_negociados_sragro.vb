Imports Disar.data
Public Class frm_precios_negociados_sragro
    Dim conexion_notas_debito As New cls_notas_debito_SRAGRO

    Public usuario_id As Integer
    Public usuario_name As String
    Dim precio_anterior As String = 0

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        grp_ingreso.Visible = False
        grp_filtros.Visible = True
        grp_precios_productos.Visible = True
        Try
            If txt_validador.Text = "ins" Then
                Dim var_error As String = ""
                var_error = conexion_notas_debito.insertar_precio(txt_codigo.Text, Val(txt_precio_negociado.Text), usuario_id, usuario_name, Now, precio_anterior)
                If var_error = "correcto" Then
                    MessageBox.Show("Precio actualizado")
                Else
                    MessageBox.Show("Error al actualizar precio" + var_error)
                End If
            Else
                Dim var_error As String = ""
                var_error = conexion_notas_debito.actualizar_precio(txt_codigo.Text, Val(txt_precio_negociado.Text), usuario_id, usuario_name, Now, precio_anterior)
                If var_error = "correcto" Then
                    MessageBox.Show("Precio actualizado")
                Else
                    MessageBox.Show("Error al actualizar precio" + var_error)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cargar()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        grp_ingreso.Visible = False
        grp_filtros.Visible = True
        grp_precios_productos.Visible = True
    End Sub

    Private Sub grd_precios_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_precios.DoubleClick
        Try
            grp_ingreso.Visible = True
            grp_filtros.Visible = False
            grp_precios_productos.Visible = False

            txt_codigo.Text = grd_precios.CurrentRow.Cells(0).Value
            txt_descripcion.Text = grd_precios.CurrentRow.Cells(1).Value
            txt_precio_negociado.Text = grd_precios.CurrentRow.Cells(2).Value

            precio_anterior = grd_precios.CurrentRow.Cells(2).Value

            If grd_precios.CurrentRow.Cells(2).Value = "No asignado" Then
                txt_validador.Text = "ins"
            Else
                txt_validador.Text = "upd"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_precios_negociados_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_proveedores()
        cargar()
    End Sub

    Sub cargar_proveedores()
        Try
            cmb_proveedor.DataSource = conexion_notas_debito.cargar_proveedores()
            cmb_proveedor.ValueMember = "CLAVE"
            cmb_proveedor.DisplayMember = "NOMBRE"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_buqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_buqueda.TextChanged
        Try
            cargar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Try
            cargar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar()
        Try
            grd_precios.DataSource = conexion_notas_debito.filtros(txt_buqueda.Text, cmb_proveedor.SelectedValue, "''")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class