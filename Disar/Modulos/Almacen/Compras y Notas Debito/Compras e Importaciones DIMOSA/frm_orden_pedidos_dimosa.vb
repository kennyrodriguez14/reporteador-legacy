Imports Disar.data
Public Class frm_orden_pedidos_dimosa
    Dim conexion As New cls_notas_debito
    Dim folio As String = ""
    Dim ult_docto As Integer = 0
    Public modo As String
    Private Sub frm_orden_pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_uni.SelectedItem = "cj"
        get_almacen()


        If modo = "upd" Then
            Dim dt As New DataTable
            dt = conexion.detalles_ordenpedido_DIMOSA(txt_num_registro.Text)
            For index As Integer = 0 To dt.Rows.Count - 1
                grd_ingreso.Rows.Add(dt.Rows(index)(0), dt.Rows(index)(1), dt.Rows(index)(2), dt.Rows(index)(3), dt.Rows(index)(4), _
                                     dt.Rows(index)(5), dt.Rows(index)(6), dt.Rows(index)(7), dt.Rows(index)(8), dt.Rows(index)(9), _
                                     dt.Rows(index)(10), dt.Rows(index)(11))
            Next
        End If

    End Sub

    Private Sub btn_new_client_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_prov.Click
        frm_lista_proveedores.Close()
        If frm_lista_proveedores_dimosa.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_codigo_proveedor.Text = frm_lista_proveedores_dimosa.codigo
            txt_nombre_proveedor.Text = frm_lista_proveedores_dimosa.nombre
            txt_rfc.Text = frm_lista_proveedores.rfc
        End If
    End Sub


    Sub get_almacen()
        Try
            cmb_sucursal.DataSource = conexion.ListarAlmacenesDIMOSA
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_agregar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_producto.Click
        frm_productos_precios_neg_dimosa.Close()
        frm_productos_precios_neg_dimosa.proveedor = txt_codigo_proveedor.Text
        If frm_productos_precios_neg_dimosa.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_codigo_producto.Text = frm_productos_precios_neg_dimosa.codigo
            txt_nombre_producto.Text = frm_productos_precios_neg_dimosa.producto
            txt_factor_conversion.Text = frm_productos_precios_neg_dimosa.fac_conv
            txt_isv_por.Text = frm_productos_precios_neg_dimosa.isv_por
            txt_precio_neg.Text = frm_productos_precios_neg_dimosa.precio_neg

            btn_new_prov.Enabled = False
        End If
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        Try

            If txt_codigo_producto.Text = "" Or Val(txt_cantidad.Text) <= 0 Then
                MessageBox.Show("Ingrese todos los datos del producto")
            Else
                Dim subtotal As Double = 0
                Dim descuento As Double = 0
                Dim isv As Double = 0
                Dim total As Double = 0
                If cmb_uni.SelectedItem = "cj" Then
                    subtotal = Val(txt_factor_conversion.Text) * Val(txt_precio_neg.Text) * Val(txt_cantidad.Text)
                    descuento = subtotal * (Val(txt_descuento_por.Text) / 100)
                    isv = (subtotal - descuento) * (Val(txt_isv_por.Text) / 100)
                    total = subtotal - descuento + isv
                ElseIf cmb_uni.SelectedItem = "pz" Then
                    subtotal = Val(txt_precio_neg.Text) * Val(txt_cantidad.Text)
                    descuento = subtotal * (Val(txt_descuento_por.Text) / 100)
                    isv = (subtotal - descuento) * (Val(txt_isv_por.Text) / 100)
                    total = subtotal - descuento + isv
                End If

                grd_ingreso.Rows.Add(cmb_uni.SelectedItem, txt_codigo_producto.Text, txt_nombre_producto.Text, txt_factor_conversion.Text, _
                                     Val(txt_cantidad.Text), Val(txt_precio_neg.Text), Val(txt_descuento_por.Text), Val(txt_isv_por.Text), subtotal, descuento, _
                                     isv, total)
                limpiar()
                sumar_totales()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub limpiar()
        txt_codigo_producto.Text = ""
        txt_nombre_producto.Text = ""
        txt_factor_conversion.Text = ""
        txt_precio_neg.Text = ""
        txt_cantidad.Text = ""
        txt_descuento_por.Text = ""
        txt_isv_por.Text = ""
        txt_precio_neg.Text = ""
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        limpiar()
    End Sub

    Private Sub btn_quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar.Click
        Try
            grd_ingreso.Rows.RemoveAt(grd_ingreso.CurrentRow.Index)
            sumar_totales()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub sumar_totales()
        Dim subtotal As Double = 0, total As Double = 0, descuento As Double = 0, isv As Double = 0
        For index As Integer = 0 To grd_ingreso.RowCount - 1
            subtotal += grd_ingreso.Rows(index).Cells(8).Value
            descuento += grd_ingreso.Rows(index).Cells(9).Value
            isv += grd_ingreso.Rows(index).Cells(10).Value
            total += grd_ingreso.Rows(index).Cells(11).Value
        Next
        txt_subtotal_final.Text = subtotal.ToString("N2")
        txt_descuento_final.Text = descuento.ToString("N2")
        txt_isv_final.Text = isv.ToString("N2")
        txt_total_final.Text = total.ToString("N2")
    End Sub

    Private Sub grd_ingreso_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_ingreso.SelectionChanged
        If grd_ingreso.RowCount > 0 Then
            txt_mostrador_producto.Text = grd_ingreso.CurrentRow.Cells(2).Value
        End If
    End Sub

    Private Sub grd_ingreso_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grd_ingreso.RowsAdded
        If grd_ingreso.RowCount - 1 > 0 Then
            txt_mostrador_producto.Text = grd_ingreso.CurrentRow.Cells(2).Value
        Else
            txt_mostrador_producto.Text = ""
        End If
    End Sub

    Private Sub grd_ingreso_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles grd_ingreso.RowsRemoved
        If grd_ingreso.RowCount - 1 > 0 Then
            txt_mostrador_producto.Text = grd_ingreso.CurrentRow.Cells(2).Value
        Else
            txt_mostrador_producto.Text = ""
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Try
            If grd_ingreso.RowCount > 0 Or txt_num_registro.Text = "" Or txt_codigo_proveedor.Text = "" Then
                Dim dt As New DataTable
                dt.Columns.Add("uni")
                dt.Columns.Add("codigo")
                dt.Columns.Add("producto")
                dt.Columns.Add("factor_conversion")
                dt.Columns.Add("cantidad")
                dt.Columns.Add("precio_negociado")
                dt.Columns.Add("descuento_por")
                dt.Columns.Add("isv_por")
                dt.Columns.Add("sub_total")
                dt.Columns.Add("descuento")
                dt.Columns.Add("isv")
                dt.Columns.Add("total")

                For index As Integer = 0 To grd_ingreso.Rows.Count - 1
                    dt.Rows.Add(grd_ingreso.Rows(index).Cells(0).Value, grd_ingreso.Rows(index).Cells(1).Value, _
                grd_ingreso.Rows(index).Cells(2).Value, grd_ingreso.Rows(index).Cells(3).Value, grd_ingreso.Rows(index).Cells(4).Value _
                , grd_ingreso.Rows(index).Cells(5).Value, grd_ingreso.Rows(index).Cells(6).Value, grd_ingreso.Rows(index).Cells(7).Value _
                , grd_ingreso.Rows(index).Cells(8).Value, grd_ingreso.Rows(index).Cells(9).Value, grd_ingreso.Rows(index).Cells(10).Value, _
                grd_ingreso.Rows(index).Cells(11).Value)
                Next

                If modo = "upd" Then
                    Dim correcto As String = ""
                    correcto = conexion.update_orden_pedido_DIMOSA(txt_num_registro.Text, cmb_fecha_documento.Value, Convert.ToDouble(txt_subtotal_final.Text), Convert.ToDouble(txt_descuento_final.Text), _
                                                  Convert.ToDouble(txt_isv_final.Text), Convert.ToDouble(txt_total_final.Text), dt)
                    If correcto = "correcto" Then
                        MessageBox.Show("Orden de pedido actualizada", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.Close()
                    Else
                        MessageBox.Show(correcto)
                    End If
                Else
                    If conexion.valida_numreg_DIMOSA(txt_num_registro.Text) = True Then
                        MessageBox.Show("El numero de documento se actualizara a " & folio & (ult_docto + 1), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        txt_num_registro.Text = folio & (ult_docto + 1)
                        conexion.actualiza_num_reg_DIMOSA(folio)
                    End If

                    Dim correcto As String = ""
                    correcto = conexion.guardar_orden_pedido_DIMOSA(txt_num_registro.Text, txt_codigo_proveedor.Text, txt_nombre_proveedor.Text, txt_rfc.Text, _
                                                  cmb_sucursal.SelectedValue, txt_referencia_proveedor.Text, Val(txt_descuento_general.Text), _
                                                  cmb_fecha_documento.Value, "PENDIENTE", Convert.ToDouble(txt_subtotal_final.Text), Convert.ToDouble(txt_descuento_final.Text), _
                                                  Convert.ToDouble(txt_isv_final.Text), Convert.ToDouble(txt_total_final.Text), dt, folio)
                    If correcto = "correcto" Then
                        MessageBox.Show("Informacion guardada", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.Close()
                    Else
                        MessageBox.Show(correcto)
                    End If
                End If
            Else
                MessageBox.Show("No se permiten campos en blanco")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_get_folio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_get_folio.Click
        frm_nd_folios_dimosa.Close()
        If frm_nd_folios_dimosa.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_num_registro.Text = frm_nd_folios_dimosa.folio & frm_nd_folios_dimosa.ult_doc
            cmb_sucursal.SelectedValue = frm_nd_folios_dimosa.almacen
            folio = frm_nd_folios_dimosa.folio
            ult_docto = frm_nd_folios_dimosa.ult_doc
        End If
    End Sub
End Class