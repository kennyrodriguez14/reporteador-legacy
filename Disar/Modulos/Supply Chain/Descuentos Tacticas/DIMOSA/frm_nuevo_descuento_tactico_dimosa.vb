Imports Disar.data
Public Class frm_nuevo_descuento_tactico_dimosa
    Dim conexion As New cls_descuentos_tacticos
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub frm_nuevo_descuento_tactico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_sucursal()
        cargar_conceptos()
        cargar_conceptos_proveedores()
    End Sub

    Sub cargar_sucursal()
        Try
            cmb_sucursal.DataSource = conexion.ListarAlmacenesDimosa
            cmb_sucursal.DisplayMember = "ALMACEN"
            cmb_sucursal.ValueMember = "ID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_conceptos_proveedores()
        Try
            cmb_concepto_prov.DataSource = conexion.listar_conceptos_proveedor_dimosa()
            cmb_concepto_prov.DisplayMember = "CON"
            cmb_concepto_prov.ValueMember = "ID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_conceptos()
        Try
            cmb_concepto.DataSource = conexion.listar_conceptos_dimosa
            cmb_concepto.DisplayMember = "DESCRIPCION"
            cmb_concepto.ValueMember = "ID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_new_client_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_client.Click
        Try
            frm_clientes_dimosa.Close()
            frm_clientes_dimosa.ShowDialog()

            If frm_clientes_dimosa.DialogResult = Windows.Forms.DialogResult.OK Then
                txt_codigo_cliente.Text = frm_clientes_dimosa.codigo
                txt_nombre_cliente.Text = frm_clientes_dimosa.cliente
                txt_codigo_vendedor.Text = frm_clientes_dimosa.cve_vend
                txt_nombre_vendedor.Text = frm_clientes_dimosa.vendedor
                txt_rfc.Text = frm_clientes_dimosa.rfc
                txt_con_credito.Text = frm_clientes_dimosa.pago
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_facturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_facturas.Click
        Try
            If txt_codigo_cliente.Text = "" Then
                MessageBox.Show("Seleccione un cliente", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                frm_facturas_dimosa2.Close()
                frm_facturas_dimosa2.codigo = txt_codigo_cliente.Text
                frm_facturas_dimosa2.con_credito = txt_con_credito.Text
                frm_facturas_dimosa2.ShowDialog()
                If frm_facturas_dimosa2.DialogResult = DialogResult.OK Then
                    txt_numero_factura.Text = frm_facturas_dimosa2.factura
                    txt_tipo.Text = frm_facturas_dimosa2.tipo
                    cmb_fecha_documento.Value = frm_facturas_dimosa2.fecha
                    txt_fecha_entrega.Text = frm_facturas_dimosa2.fecha_entrega
                    grd_productos.DataSource = conexion.productos_factura_dimosa(txt_numero_factura.Text)
                    cmb_sucursal.SelectedValue = frm_facturas_dimosa2.almacen
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_productos_dt.Close()
        frm_productos_dt.ShowDialog()

        If frm_productos_dt_DIMOSA.DialogResult = Windows.Forms.DialogResult.OK Then
            txt_codigo_producto.Text = frm_productos_dt_DIMOSA.cve_art
            txt_nombre_producto.Text = frm_productos_dt_DIMOSA.producto
            txt_codigo_proveedor.Text = frm_productos_dt_DIMOSA.cve_prov
            txt_proveedor.Text = frm_productos_dt_DIMOSA.proveedor
        End If
    End Sub

    Sub limpiar()
        txt_codigo_producto.Text = ""
        txt_nombre_producto.Text = ""
        txt_cantidad.Text = ""
        txt_importe_sisv.Text = ""
        txt_codigo_proveedor.Text = ""
        txt_proveedor.Text = ""
        txt_isv.Text = ""
        txt_subtotal_noisv.Text = ""
    End Sub


    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        Try
            If txt_codigo_producto.Text = "" Or txt_nombre_producto.Text = "" Or txt_cantidad.Text = "" _
            Or txt_importe_sisv.Text = "" Or Val(txt_importe_sisv.Text) = 0 Then
                MessageBox.Show("No se permiten campos vacios", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                Dim presupuesto_restante As Double = 0
                Dim cargado As Double = 0

                If grd_ingreso.Rows.Count > 0 Then
                    For i As Integer = 0 To grd_ingreso.Rows.Count - 1
                        If grd_ingreso.Rows(i).Cells(4).Value = txt_codigo_proveedor.Text Then
                            cargado += grd_ingreso.Rows(i).Cells(3).Value
                        End If
                    Next
                End If

                presupuesto_restante += conexion.Valor_Restante_dimosa(txt_codigo_proveedor.Text, cmb_fecha_descuento_tactico.Value.Year, cmb_fecha_descuento_tactico.Value.Month)

                grd_ingreso.Rows.Add(txt_codigo_producto.Text, txt_nombre_producto.Text, txt_cantidad.Text, _
                                 txt_importe_sisv.Text, txt_codigo_proveedor.Text, txt_proveedor.Text, _
                                 cmb_concepto.SelectedValue, cmb_concepto.Text, txt_isv.Text, txt_subtotal_noisv.Text, _
                                 cmb_concepto_prov.SelectedValue, cmb_concepto_prov.Text)
                limpiar()
                btn_facturas.Enabled = False

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        calcular_total()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            grd_ingreso.Rows.RemoveAt(grd_ingreso.CurrentRow.Index)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        calcular_total()
    End Sub

    Sub calcular_total()
        Try
            Dim tot As Double = 0
            For i As Integer = 0 To grd_ingreso.Rows.Count - 1
                tot += grd_ingreso.Rows(i).Cells(3).Value
            Next
            txt_total.Text = tot
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Try
            Dim fech_limite As Date
            fech_limite = conexion.get_fecha_limite()

            If cmb_fecha_documento.Value.Date <= fech_limite Then
                MessageBox.Show("La fecha no esta en el rango autorizado")
            Else
                If txt_codigo_cliente.Text = "" Or txt_numero_factura.Text = "" Or grd_ingreso.Rows.Count <= 0 Then
                    MessageBox.Show("Debe seleccionar un cliente, una factura y producto", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Else

                 

                    Dim dt_encabezado As New DataTable
                    Dim dt_partidas As New DataTable
                    Dim dt_parfactd As New DataTable

                    Dim subtotal_isv As Double = 0, subtotal_sinisv As Double = 0
                    Dim val_isv As Double = 0

                    dt_partidas.Columns.Add("num_part")
                    dt_partidas.Columns.Add("cve_art")
                    dt_partidas.Columns.Add("cantidad")
                    dt_partidas.Columns.Add("monto")
                    dt_partidas.Columns.Add("proveedor")
                    dt_partidas.Columns.Add("concepto")
                    dt_partidas.Columns.Add("isv")
                    dt_partidas.Columns.Add("subtotal")
                    dt_partidas.Columns.Add("concepto_proveedor")

                    Dim subtotal_general As Double = 0, isv_total As Double = 0

                    For index As Integer = 0 To grd_ingreso.Rows.Count - 1
                        dt_partidas.Rows.Add(index + 1, grd_ingreso.Rows(index).Cells(0).Value, grd_ingreso.Rows(index).Cells(2).Value, _
                    grd_ingreso.Rows(index).Cells(3).Value, grd_ingreso.Rows(index).Cells(4).Value, grd_ingreso.Rows(index).Cells(6).Value _
                    , grd_ingreso.Rows(index).Cells(8).Value, grd_ingreso.Rows(index).Cells(9).Value, grd_ingreso.Rows(index).Cells(10).Value)
                    Next

                    For index As Integer = 0 To dt_partidas.Rows.Count - 1
                        If dt_partidas.Rows(index)(6) > 0 Then
                            subtotal_isv += dt_partidas.Rows(index)(7)
                            val_isv = dt_partidas.Rows(index)(6)
                            isv_total += dt_partidas.Rows(index)(7) * val_isv / 100
                        Else
                            subtotal_sinisv += dt_partidas.Rows(index)(7)
                        End If
                        subtotal_general += dt_partidas.Rows(index)(7)
                    Next

                    dt_encabezado.Columns.Add("vendedor")
                    dt_encabezado.Columns.Add("factura")
                    dt_encabezado.Columns.Add("cliente")
                    dt_encabezado.Columns.Add("almacen")
                    dt_encabezado.Columns.Add("tipo")
                    dt_encabezado.Columns.Add("importe")
                    dt_encabezado.Columns.Add("estado")
                    dt_encabezado.Columns.Add("fecha")
                    dt_encabezado.Columns.Add("subtotal")
                    dt_encabezado.Columns.Add("isv_total")

                    dt_encabezado.Rows.Add(txt_codigo_vendedor.Text, txt_numero_factura.Text, txt_codigo_cliente.Text, cmb_sucursal.SelectedValue, _
                                           txt_tipo.Text, Val(txt_total.Text), "", cmb_fecha_descuento_tactico.Value, subtotal_general, isv_total)

                    dt_parfactd.Columns.Add("CVE_ART")
                    dt_parfactd.Columns.Add("CANT")
                    dt_parfactd.Columns.Add("PXS")
                    dt_parfactd.Columns.Add("PREC")
                    dt_parfactd.Columns.Add("IMPU4")
                    dt_parfactd.Columns.Add("TOT_IMP4")
                    dt_parfactd.Columns.Add("UNI_VENTA")
                    dt_parfactd.Columns.Add("TOT_PARTIDA")

                    If subtotal_isv > 0 And subtotal_sinisv > 0 Then
                        dt_parfactd.Rows.Add("ZDEV01", "1", "1", subtotal_isv, val_isv, (subtotal_isv * val_isv / 100), "cj", subtotal_isv)
                        dt_parfactd.Rows.Add("ZDEV01", "1", "1", subtotal_sinisv, 0, 0, "cj", subtotal_sinisv)
                    Else
                        If subtotal_isv > 0 Then
                            dt_parfactd.Rows.Add("ZDEV01", "1", "1", subtotal_isv, val_isv, (subtotal_isv * val_isv / 100), "cj", subtotal_isv)
                        ElseIf subtotal_sinisv > 0 Then
                            dt_parfactd.Rows.Add("ZDEV01", "1", "1", subtotal_sinisv, 0, 0, "cj", subtotal_sinisv)
                        End If
                    End If


                    Dim variable_error As String = ""
                    If MessageBox.Show("Desea enviar el registro a SAE", "Confirmacion", MessageBoxButtons.YesNoCancel, _
                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        variable_error = conexion.guardar_datos_envio_sae_dimosa(dt_encabezado, dt_partidas, txt_rfc.Text, dt_parfactd, subtotal_general, isv_total, txt_fecha_entrega.Text, cmb_fecha_documento.Value)
                        Dim conexion_bita As New cls_bitacora_reporteador
                        conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Genero Nota de Credito DIMOSA", "Supply Chain - Notas de Credito", _
                                                  "Fecha: " + cmb_fecha_descuento_tactico.Value + _
                                                  " Facturas: " + txt_numero_factura.Text)
                    Else
                        variable_error = conexion.guardar_datos_local_dimosa(dt_encabezado, dt_partidas, txt_rfc.Text, dt_parfactd, subtotal_general, isv_total, txt_fecha_entrega.Text, cmb_fecha_documento.Value)
                    End If

                    If variable_error = "correcto" Then
                        MessageBox.Show("Informacion almacenada correctamente", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.Close()
                    Else
                        MessageBox.Show(variable_error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
 
    Private Sub grd_productos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_productos.DoubleClick
        Try
            txt_subtotal_noisv.Text = ""
            txt_importe_sisv.Text = ""

            txt_codigo_producto.Text = grd_productos.CurrentRow.Cells(0).Value
            txt_nombre_producto.Text = grd_productos.CurrentRow.Cells(1).Value
            txt_cantidad.Text = grd_productos.CurrentRow.Cells(2).Value
            txt_codigo_proveedor.Text = grd_productos.CurrentRow.Cells(3).Value
            txt_proveedor.Text = grd_productos.CurrentRow.Cells(4).Value
            txt_isv.Text = grd_productos.CurrentRow.Cells(5).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_importe_sisv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_importe_sisv.TextChanged
        Try
            'If txt_codigo_producto.Text = "" Then
            '    MessageBox.Show("Primero se debe seleccionar un producto")
            'Else
            txt_subtotal_noisv.Text = Val(txt_importe_sisv.Text) / ((Val(txt_isv.Text) + 100) / 100)
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_carga_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_carga_producto.Click
        frm_productos_individual_dimosa.ShowDialog()
        txt_codigo_producto.Text = frm_productos_individual_dimosa.cve_art
        txt_nombre_producto.Text = frm_productos_individual_dimosa.producto
        txt_codigo_proveedor.Text = frm_productos_individual_dimosa.cve_prov
        txt_proveedor.Text = frm_productos_individual_dimosa.proveedor
        txt_isv.Text = frm_productos_individual_dimosa.isv
    End Sub
End Class