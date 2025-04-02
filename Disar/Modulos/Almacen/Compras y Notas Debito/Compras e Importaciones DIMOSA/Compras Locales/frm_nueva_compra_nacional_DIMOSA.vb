Imports Disar.data

Public Class frm_orden_compra_nacional_DIMOSA
    Dim conexion As New cls_notas_debito
    Public modo As String
    Public codigo_compra As String
    Dim Valdesc As Decimal
    Dim Clc As Decimal

    Private Sub btn_new_prov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_prov.Click
        frm_lista_proveedores.Close()
        If frm_lista_proveedores_dimosa.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_codigo_proveedor.Text = frm_lista_proveedores_dimosa.codigo
            txt_nombre_proveedor.Text = frm_lista_proveedores_dimosa.nombre
            txt_rfc.Text = frm_lista_proveedores_dimosa.rfc
            cmb_sucursal.Focus()
        End If
    End Sub

    Private Sub frm_nueva_compra_nacional_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_valores_base.SelectedItem = "Sub Total"
        cmb_uni.SelectedItem = "cj"
        If modo = "vista" Then
            modo_vista()
        ElseIf modo = "modificar" Then
            modo_modificar()
        ElseIf modo = "nuevo" Then
            get_almacen()
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

    Private Sub btn_agregar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_producto.Click
        cargar_producto_rutina()
    End Sub

    Sub cargar_producto_rutina()
        frm_productos_precios_neg_dimosa.Close()
        frm_productos_precios_neg_dimosa.proveedor = txt_codigo_proveedor.Text
        frm_productos_precios_neg_dimosa.almacen = cmb_sucursal.SelectedValue
        If frm_productos_precios_neg_dimosa.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_codigo_producto.Text = frm_productos_precios_neg_dimosa.codigo
            txt_nombre_producto.Text = frm_productos_precios_neg_dimosa.producto
            txt_factor_conversion.Text = frm_productos_precios_neg_dimosa.fac_conv
            txt_isv_por.Text = frm_productos_precios_neg_dimosa.isv_por
            txt_precio_neg.Text = Math.Round(frm_productos_precios_neg_dimosa.precio_neg, 6)
            txt_descuento_por.Text = Val(txt_descuento_general.Text)
            txt_uni_entrada.Text = frm_productos_precios_neg_dimosa.uni_entrada
            txt_con_lote.Text = frm_productos_precios_neg_dimosa.con_lote
            btn_new_prov.Enabled = False
            calcular_totales_boton()
            txt_precio_final.Focus()
        End If
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        Try

            If txt_codigo_producto.Text = "" Or Val(txt_cantidad.Text) <= 0 Then
                MessageBox.Show("Ingrese todos los datos del producto")
            Else
                Dim subtotal As Double = 0, descuento As Double = 0, isv As Double = 0
                Dim total As Double = 0, precio_multiplicador As Double = 0
                Dim cadena_ajuste As String = ""
                Dim subtotal_mostrador As Double = 0, total_mostrador As Double = 0, descuento_mostrador As Double = 0, isv_mostrador As Double = 0

                If Math.Round(Val(txt_precio_neg.Text), 6) = Math.Round(Val(txt_precio_final.Text), 6) Then
                    precio_multiplicador = Math.Round(Val(txt_precio_neg.Text), 6)
                    cadena_ajuste = "N"
                ElseIf Math.Round(Val(txt_precio_neg.Text), 6) > Math.Round(Val(txt_precio_final.Text), 6) Then
                    precio_multiplicador = Math.Round(Val(txt_precio_neg.Text), 6) 'Math.Round(Val(txt_precio_final.Text), 6)
                    cadena_ajuste = "D"
                ElseIf Math.Round(Val(txt_precio_neg.Text), 6) < Math.Round(Val(txt_precio_final.Text), 6) Then
                    precio_multiplicador = Math.Round(Val(txt_precio_neg.Text), 6)
                    cadena_ajuste = "S"
                End If

                If cmb_uni.SelectedItem = "cj" Then
                    subtotal = Val(txt_factor_conversion.Text) * precio_multiplicador * Val(txt_cantidad.Text)

                    descuento_mostrador = ((Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) / (1 - Val(txt_descuento_por.Text) / 100)) - ((Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)))
                    isv_mostrador = ((Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) * (Val(txt_isv_por.Text) / 100))
                    subtotal_mostrador = ((Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) / (1 - Val(txt_descuento_por.Text) / 100))
                    total_mostrador = (Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) + ((Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) * (Val(txt_isv_por.Text) / 100))

                ElseIf cmb_uni.SelectedItem = "pz" Then
                    subtotal = precio_multiplicador * Val(txt_cantidad.Text)

                    descuento_mostrador = ((Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) / (1 - Val(txt_descuento_por.Text) / 100)) - (Val(txt_precio_final.Text) * Val(txt_cantidad.Text))
                    isv_mostrador = ((Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) * (Val(txt_isv_por.Text) / 100))
                    subtotal_mostrador = ((Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) / (1 - Val(txt_descuento_por.Text) / 100))
                    total_mostrador = (Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) + ((Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) * (Val(txt_isv_por.Text) / 100))
                Else
                    subtotal = Val(txt_factor_conversion.Text) * precio_multiplicador * Val(txt_cantidad.Text)

                    descuento_mostrador = ((Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) / (1 - Val(txt_descuento_por.Text) / 100)) - ((Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)))
                    isv_mostrador = ((Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) * (Val(txt_isv_por.Text) / 100))
                    subtotal_mostrador = ((Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) / (1 - Val(txt_descuento_por.Text) / 100))
                    total_mostrador = (Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) + ((Val(txt_factor_conversion.Text) * Val(txt_precio_final.Text) * Val(txt_cantidad.Text)) * (Val(txt_isv_por.Text) / 100))

                End If

                descuento = 0 'subtotal * (Val(txt_descuento_por.Text) / 100)
                isv = (subtotal - descuento) * (Val(txt_isv_por.Text) / 100)
                total = subtotal - descuento + isv

                grd_ingreso.Rows.Add(Val(txt_cantidad.Text), txt_codigo_producto.Text, txt_nombre_producto.Text, txt_factor_conversion.Text, _
                                     cmb_uni.SelectedItem, Math.Round(Val(txt_precio_neg.Text), 6), Math.Round(Val(txt_precio_final.Text), 6), _
                                     Math.Round(Val(txt_descuento_por.Text), 6), Val(txt_isv_por.Text), Math.Round(subtotal, 6), _
                                     Math.Round(descuento, 6), Math.Round(isv, 6), Math.Round(total, 6), Math.Round(precio_multiplicador, 6), _
                                     cadena_ajuste, txt_uni_entrada.Text, Math.Round(subtotal_mostrador, 6), Math.Round(total_mostrador, 6), _
                                     Math.Round(descuento_mostrador), Math.Round(isv_mostrador), txt_con_lote.Text, Clc)
                limpiar()
                sumar_totales()
                txt_cantidad.Focus()
                grd_ingreso.ClearSelection()
                grd_ingreso.Rows(grd_ingreso.RowCount - 1).Selected = True
                grd_ingreso.Refresh()
                cmb_sucursal.Enabled = False
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
        txt_precio_final.Text = ""
        txt_uni_entrada.Text = ""
        txt_con_lote.Text = ""
    End Sub

    Sub sumar_totales()
        Dim subtotal As Double = 0, total As Double = 0, descuento As Double = 0, isv As Double = 0
        Dim total_mostrador As Double = 0, subtotal_mostrador As Double = 0, isv_mostrador As Double = 0, desc_mostrador As Double = 0
        For index As Integer = 0 To grd_ingreso.RowCount - 1
            subtotal += grd_ingreso.Rows(index).Cells(9).Value
            descuento += grd_ingreso.Rows(index).Cells(10).Value
            isv += grd_ingreso.Rows(index).Cells(11).Value
            total += grd_ingreso.Rows(index).Cells(12).Value

            total_mostrador += grd_ingreso.Rows(index).Cells(17).Value
            subtotal_mostrador += grd_ingreso.Rows(index).Cells(16).Value
            isv_mostrador += grd_ingreso.Rows(index).Cells(19).Value
            desc_mostrador += grd_ingreso.Rows(index).Cells(18).Value
        Next
        txt_subtotal_final.Text = subtotal.ToString("N2")
        txt_descuento_final.Text = descuento.ToString("N2")
        txt_isv_final.Text = isv.ToString("N2")
        txt_total_final.Text = total.ToString("N2")

        txt_subtotalmostrador.Text = subtotal_mostrador.ToString("N2")
        txt_descuento_mostrador.Text = desc_mostrador.ToString("N2")
        txt_isvmostrador.Text = isv_mostrador.ToString("N2")
        txt_totalmostrador.Text = total_mostrador.ToString("N2")
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        limpiar()
    End Sub

    Private Sub grd_ingreso_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grd_ingreso.RowsAdded
        Try
            If grd_ingreso.RowCount - 1 > 0 Then
                txt_mostrador_producto.Text = grd_ingreso.CurrentRow.Cells(2).Value
            Else
                txt_mostrador_producto.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grd_ingreso_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles grd_ingreso.RowsRemoved
        Try
            If grd_ingreso.RowCount - 1 > 0 Then
                txt_mostrador_producto.Text = grd_ingreso.CurrentRow.Cells(2).Value
            Else
                txt_mostrador_producto.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grd_ingreso_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_ingreso.SelectionChanged
        Try
            If grd_ingreso.RowCount > 0 Then
                txt_mostrador_producto.Text = grd_ingreso.CurrentRow.Cells(2).Value
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        'Try
        Dim conex_validador As New cls_notas_debito
        Dim fecha_limite As New Date
        fecha_limite = conex_validador.validar_periodo_DIMOSA()

        If cmb_fecha_documento.Value <= fecha_limite Then
            MessageBox.Show("El periodo se encuentra cerrado", "Periodo Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        Else
            If txt_codigo_proveedor.Text = "" Then
                MessageBox.Show("El Proveedor esta en blanco")
            Else
                Dim dt_e As New DataTable
                Dim dt_p As New DataTable

                dt_e.Columns.Add("CVE_PROVEEDOR") '0
                dt_e.Columns.Add("PROVEEDOR") '1
                dt_e.Columns.Add("ALMACEN") '2
                dt_e.Columns.Add("REF_PROV") '3
                dt_e.Columns.Add("RFC") '4
                dt_e.Columns.Add("FECHA") '5
                dt_e.Columns.Add("DESCUENTO_POR") '6
                dt_e.Columns.Add("SUB_TOTAL") '7
                dt_e.Columns.Add("DESCUENTO_VAL") '8
                dt_e.Columns.Add("ISV_VAL") '9
                dt_e.Columns.Add("TOTAL") '10
                dt_e.Columns.Add("ESTADO") '11
                dt_e.Columns.Add("SUBTOTAL_MOST") '12
                dt_e.Columns.Add("DESC_MOST") '13
                dt_e.Columns.Add("ISV_MOST") '14
                dt_e.Columns.Add("TOTAL_MOST") '15
                dt_e.Columns.Add("FECHA_FACTURA") '16

                dt_e.Rows.Add(txt_codigo_proveedor.Text, txt_nombre_proveedor.Text, cmb_sucursal.SelectedValue, txt_referencia_proveedor.Text, _
                              txt_rfc.Text, cmb_fecha_documento.Value.Date, txt_descuento_general.Text, Convert.ToDouble(txt_subtotal_final.Text), _
                              Convert.ToDouble(txt_descuento_final.Text), Convert.ToDouble(txt_isv_final.Text), Convert.ToDouble(txt_total_final.Text), _
                              "PENDIENTE", Convert.ToDouble((txt_subtotalmostrador.Text)), Convert.ToDouble((txt_descuento_mostrador.Text)) _
                              , Convert.ToDouble((txt_isvmostrador.Text)), Convert.ToDouble((txt_totalmostrador.Text)), cmb_fecha_factura.Value)

                dt_p.Columns.Add("UNI")
                dt_p.Columns.Add("CVE_ART")
                dt_p.Columns.Add("PRODUCTO")
                dt_p.Columns.Add("FACT_CONV")
                dt_p.Columns.Add("CANTIDAD")
                dt_p.Columns.Add("PRECIO_NEG")
                dt_p.Columns.Add("PRECIO_FINAL")
                dt_p.Columns.Add("DESC_PROD")
                dt_p.Columns.Add("ISV_PROD")
                dt_p.Columns.Add("SUB_TOTAL")
                dt_p.Columns.Add("DESCUENTO")
                dt_p.Columns.Add("ISV")
                dt_p.Columns.Add("TOTAL_PARTIDA")
                dt_p.Columns.Add("PRECIO_INSERTAR")
                dt_p.Columns.Add("AJUSTE")
                dt_p.Columns.Add("ENTRADA")
                dt_p.Columns.Add("SUBTOTAL_MOST")
                dt_p.Columns.Add("DESC_MOST")
                dt_p.Columns.Add("ISV_MOST")
                dt_p.Columns.Add("TOTAL_MOST")
                dt_p.Columns.Add("CON_LOTE")

                For index As Integer = 0 To grd_ingreso.Rows.Count - 1
                    dt_p.Rows.Add(grd_ingreso.Rows(index).Cells(4).Value, grd_ingreso.Rows(index).Cells(1).Value, grd_ingreso.Rows(index).Cells(2).Value, _
                                  grd_ingreso.Rows(index).Cells(3).Value, grd_ingreso.Rows(index).Cells(0).Value, grd_ingreso.Rows(index).Cells(5).Value, _
                                  grd_ingreso.Rows(index).Cells(6).Value, grd_ingreso.Rows(index).Cells(7).Value, grd_ingreso.Rows(index).Cells(8).Value, _
                                  grd_ingreso.Rows(index).Cells(9).Value, grd_ingreso.Rows(index).Cells(10).Value, grd_ingreso.Rows(index).Cells(11).Value, _
                                  grd_ingreso.Rows(index).Cells(12).Value, grd_ingreso.Rows(index).Cells(13).Value, grd_ingreso.Rows(index).Cells(14).Value _
                                 , grd_ingreso.Rows(index).Cells(15).Value, grd_ingreso.Rows(index).Cells(16).Value, grd_ingreso.Rows(index).Cells(18).Value _
                                  , grd_ingreso.Rows(index).Cells(19).Value, grd_ingreso.Rows(index).Cells(17).Value, grd_ingreso.Rows(index).Cells(20).Value)
                Next

                Dim resultado As String = ""
                Dim conlote As String, lote As String
                If cmb_lote.Checked = True Then
                    conlote = "S"
                    lote = txt_lote.Text
                Else
                    conlote = "N"
                    lote = ""
                End If

                ValidaEnvio()

                If modo = "nuevo" Then

                    If MessageBox.Show("¿Desea enviar la compra a SAE?", "Confirmacion", MessageBoxButtons.YesNoCancel, _
                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        resultado = conexion.guardar_compras_local_envio_SAE_DIMOSA(dt_e, dt_p, conlote, lote, cmb_fecha_vencimiento.Value, _Inicio.lblUsuario.Text, TextPedido.Text)
                    Else
                        resultado = conexion.guardar_compras_local_DIMOSA(dt_e, dt_p, lote, cmb_fecha_vencimiento.Value, TextPedido.Text)
                    End If

                ElseIf modo = "modificar" Then
                    resultado = conexion.modificar_compras_local_DIMOSA(dt_e, dt_p, codigo_compra, lote, cmb_fecha_vencimiento.Value)
                    If resultado = "correcto" Then
                        If MessageBox.Show("¿Desea enviar la compra a SAE?", "Confirmacion", MessageBoxButtons.YesNoCancel, _
                                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                            resultado = conexion.guardar_compras_local_envio_SAE_DIMOSA(dt_e, dt_p, conlote, lote, cmb_fecha_vencimiento.Value, _Inicio.lblUsuario.Text, TextPedido.Text)

                            'resultado = conexion.envio_individual_compras_SAE(dt_e, dt_p, codigo_compra, conlote, lote, cmb_fecha_vencimiento.Value, _Inicio.lblUsuario.Text)
                        End If
                    End If
                End If

                If resultado = "correcto" Then
                    MessageBox.Show("Informacion Almacenada correctamente", "Operacion Exitosa", MessageBoxButtons.OK, _
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.Close()
                Else
                    MessageBox.Show(resultado)
                End If
            End If
        End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub btn_quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar.Click
        Try
            grd_ingreso.Rows.RemoveAt(grd_ingreso.CurrentRow.Index)
            sumar_totales()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calcular.Click
        calcular_totales_boton()
    End Sub

    Sub calcular_totales_boton()
        If Val(txt_cantidad.Text) > 0 Then
            frm_calculadora_totales_dimosa.Close()
            If frm_calculadora_totales_dimosa.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Clc = (Val(frm_calculadora_totales_dimosa.txt_totales.Text))
                If cmb_valores_base.SelectedItem = "Sub Total" Then
                    Dim precio As Double = 0, descuento As Double = 0, isv As Double = 0
                    If cmb_uni.SelectedItem = "cj" Then
                        precio = Math.Round(Val(frm_calculadora_totales_dimosa.txt_totales.Text) / Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
                    ElseIf cmb_uni.SelectedItem = "pz" Then
                        precio = Math.Round(Val(frm_calculadora_totales_dimosa.txt_totales.Text) / Val(txt_cantidad.Text), 6)
                    Else
                        precio = Math.Round(Val(frm_calculadora_totales_dimosa.txt_totales.Text) / Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
                    End If

                    descuento = precio * (Val(txt_descuento_por.Text) / 100)
                    precio = Math.Round(precio - descuento, 6)
                    txt_precio_final.Text = precio
                ElseIf cmb_valores_base.SelectedItem = "Impuesto" Then

                    Dim precio As Double = 0, descuento As Double = 0, isv As Double = 0
                    If cmb_uni.SelectedItem = "cj" Then
                        precio = Math.Round(Val(frm_calculadora_totales_dimosa.txt_totales.Text) / Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
                    ElseIf cmb_uni.SelectedItem = "pz" Then
                        precio = Math.Round(Val(frm_calculadora_totales_dimosa.txt_totales.Text) / Val(txt_cantidad.Text), 6)
                    Else
                        precio = Math.Round(Val(frm_calculadora_totales_dimosa.txt_totales.Text) / Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
                    End If

                    descuento = precio * (Val(txt_descuento_por.Text) / 100)
                    precio = precio - descuento

                    precio = precio / (1 + (Val(txt_isv_por.Text) / 100))

                    isv = Math.Round(precio + (precio * (Val(txt_isv_por.Text) / 100)), 6)
                    txt_precio_final.Text = precio
                    'btn_agregar.Focus()
                End If
            End If
        Else
            MessageBox.Show("debe ingresar una cantidad valida", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            txt_cantidad.Focus()
        End If
    End Sub

    Sub modo_vista()
        grp_ingreso_datos.Enabled = False
        grp_ingreso_producto.Enabled = False
        btn_guardar.Enabled = False
        'VerNotas.Enabled = False
        cargar_partidas()
    End Sub

    Sub cargar_partidas()
        Try
            Dim dt As New DataTable
            dt = conexion.listar_partidas_compras_DIMOSA(codigo_compra)
            For index As Integer = 0 To dt.Rows.Count - 1
                grd_ingreso.Rows.Add(dt.Rows(index)(4), dt.Rows(index)(1), dt.Rows(index)(2), dt.Rows(index)(3), _
                                     dt.Rows(index)(0), dt.Rows(index)(5), dt.Rows(index)(6), dt.Rows(index)(7), _
                                     dt.Rows(index)(8), dt.Rows(index)(9), dt.Rows(index)(10), dt.Rows(index)(11), _
                                     dt.Rows(index)(12), dt.Rows(index)(13), dt.Rows(index)(14), "cj", dt.Rows(index)(15), _
                                     dt.Rows(index)(18), dt.Rows(index)(16), dt.Rows(index)(17), dt.Rows(index)(21))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub modo_modificar()
        btn_new_prov.Enabled = False
        cargar_partidas()
    End Sub

    Private Sub cmb_fecha_documento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_fecha_documento.ValueChanged
        txt_descuento_final.Focus()
    End Sub

    'sucursal
    Private Sub cmb_sucursal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_sucursal.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_referencia_proveedor.Focus()
        End If
    End Sub

    Private Sub cmb_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_sucursal.SelectedIndexChanged
        txt_referencia_proveedor.Focus()
    End Sub
    'ref prov
    Private Sub txt_referencia_proveedor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_referencia_proveedor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cmb_fecha_documento.Focus()
        End If
    End Sub
    'fecah doc
    Private Sub cmb_fecha_documento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_fecha_documento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_descuento_general.Focus()
        End If
    End Sub

    Private Sub cmb_valores_base_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_valores_base.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_cantidad.Focus()
        End If
    End Sub

    Private Sub txt_descuento_general_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento_general.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cmb_valores_base.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cargar_producto_rutina()
        End If
    End Sub

    Private Sub txt_precio_final_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_precio_final.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            btn_agregar.Focus()
        End If
    End Sub

    Private Sub cmb_lote_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_lote.CheckedChanged
        If cmb_lote.Checked = True Then
            txt_lote.Enabled = True
            txt_lote.Focus()
            cmb_fecha_vencimiento.Enabled = True
        Else
            txt_lote.Enabled = False
            cmb_fecha_vencimiento.Enabled = False
            txt_lote.Text = ""
        End If
    End Sub

    Private Sub txt_descuento_general_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descuento_general.TextChanged
        'Modify()
    End Sub

    Private Sub txt_descuento_general_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descuento_general.Enter
        'If txt_descuento_general.Text <> "" Then
        '    Valdesc = Val(txt_descuento_general.Text)
        'Else
        '    Valdesc = 0.0
        'End If
    End Sub

    Private Sub cmb_valores_base_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_valores_base.SelectedIndexChanged
        'If txt_descuento_general.Text <> "" Then
        '    Valdesc = Val(txt_descuento_general.Text)
        'Else
        '    Valdesc = 0.0
        'End If
        'Modify()
    End Sub

    Sub Modify()
        'If grd_ingreso.RowCount > 0 Then
        '    For Each row As DataGridViewRow In grd_ingreso.Rows
        '        'If Math.Round(row.Cells("descuento_por").Value, 2) = Math.Round(Valdesc, 2) Then
        '        row.Cells("descuento_por").Value = Val(txt_descuento_general.Text)
        '        If cmb_valores_base.SelectedItem = "Sub Total" Then

        '            Dim precio As Double = 0, descuento As Double = 0, isv As Double = 0
        '            If row.Cells("uni").Value = "cj" Then
        '                precio = Math.Round(Val(row.Cells("Precio_Calc").Value) / Val((row.Cells("Cantidad").Value)) / Val((row.Cells("fconversion").Value)), 6)
        '            ElseIf row.Cells("uni").Value = "pz" Then
        '                precio = Math.Round(Val(row.Cells("Precio_Calc").Value) / Val((row.Cells("Cantidad").Value)), 6)
        '            Else
        '                precio = Math.Round(Val(row.Cells("Precio_Calc").Value) / Val((row.Cells("Cantidad").Value)) / Val((row.Cells("fconversion").Value)), 6)
        '            End If

        '            descuento = precio * (Val(row.Cells("descuento_por").Value) / 100)
        '            precio = Math.Round(precio - descuento, 6)
        '            row.Cells("Precio_final").Value = precio

        '        ElseIf cmb_valores_base.SelectedItem = "Impuesto" Then

        '            Dim precio As Double = 0, descuento As Double = 0, isv As Double = 0
        '            If row.Cells("uni").Value = "cj" Then
        '                precio = Math.Round(Val(row.Cells("Precio_Calc").Value) / Val(row.Cells("Cantidad").Value) / Val(row.Cells("fconversion").Value), 6)
        '            ElseIf row.Cells("uni").Value = "pz" Then
        '                precio = Math.Round(Val(row.Cells("Precio_Calc").Value) / Val(row.Cells("Cantidad").Value), 6)
        '            Else
        '                precio = Math.Round(Val(row.Cells("Precio_Calc").Value) / Val(row.Cells("Cantidad").Value) / Val(row.Cells("fconversion").Value), 6)
        '            End If

        '            descuento = precio * (Val(row.Cells("descuento_por").Value) / 100)
        '            precio = precio - descuento

        '            precio = Math.Round(precio / (1 + (Val(row.Cells("isv_por").Value) / 100)), 6)

        '            row.Cells("isv_mostrador").Value = Math.Round(precio + (precio * (Val(row.Cells("isv_por").Value) / 100)), 6)
        '            row.Cells("precio_final").Value = precio
        '            'btn_agregar.Focus()
        '        End If

        '        If cmb_valores_base.SelectedItem = "Sub Total" Then

        '            row.Cells("descuento_mostrador").Value = Math.Round((row.Cells("Precio_Calc").Value) * (row.Cells("descuento_por").Value / 100), 2)
        '            row.Cells("isv_mostrador").Value = Math.Round(((row.Cells("Precio_Calc").Value) - row.Cells("descuento_mostrador").Value) * (row.Cells("isv_por").Value / 100), 2)
        '            row.Cells("SubTotal_Mostrador").Value = Math.Round(row.Cells("Precio_Calc").Value, 2)
        '            row.Cells("totalmostrador").Value = Math.Round(row.Cells("SubTotal_Mostrador").Value + row.Cells("isv_mostrador").Value - row.Cells("descuento_mostrador").Value, 2)

        '        ElseIf cmb_valores_base.SelectedItem = "Impuesto" Then

        '            If row.Cells("uni").Value = "cj" Then

        '                row.Cells("descuento_mostrador").Value = Math.Round(((Val(row.Cells("fconversion").Value) * Val(row.Cells("precio_final").Value) * Val(Val(row.Cells("Cantidad").Value)) / (1 - Val(row.Cells("descuento_por").Value) / 100)) - ((Val(row.Cells("fconversion").Value) * Val(row.Cells("precio_final").Value) * Val(row.Cells("Cantidad").Value)))), 2)
        '                row.Cells("isv_mostrador").Value = Math.Round(((Val(row.Cells("fconversion").Value) * Val(row.Cells("precio_final").Value) * Val(row.Cells("Cantidad").Value)) * (Val(row.Cells("isv_por").Value) / 100)), 2)
        '                row.Cells("SubTotal_Mostrador").Value = Math.Round(((Val(row.Cells("fconversion").Value) * Val(row.Cells("precio_final").Value) * Val(row.Cells("Cantidad").Value)) / (1 - Val(row.Cells("descuento_por").Value) / 100)), 2)
        '                row.Cells("totalmostrador").Value = Math.Round((Val(row.Cells("fconversion").Value) * Val(row.Cells("precio_final").Value) * Val(row.Cells("Cantidad").Value)) + ((Val(row.Cells("fconversion").Value) * Val(row.Cells("precio_final").Value) * Val(row.Cells("Cantidad").Value)) * (Val(row.Cells("isv_por").Value) / 100)), 2)

        '            ElseIf row.Cells("uni").Value = "pz" Then

        '                row.Cells("descuento_mostrador").Value = Math.Round(((Val(row.Cells("precio_final").Value) * Val(row.Cells("Cantidad").Value)) / (1 - Val(row.Cells("descuento_por").Value) / 100)) - (Val(row.Cells("precio_final").Value) * Val(row.Cells("Cantidad").Value)), 2)
        '                row.Cells("isv_mostrador").Value = Math.Round(((Val(row.Cells("precio_final").Value) * Val(row.Cells("Cantidad").Value)) * (Val(row.Cells("isv_por").Value) / 100)), 2)
        '                row.Cells("SubTotal_Mostrador").Value = Math.Round(((Val(row.Cells("precio_final").Value) * Val(row.Cells("Cantidad").Value)) / (1 - Val(row.Cells("descuento_por").Value) / 100)), 2)
        '                row.Cells("totalmostrador").Value = Math.Round((Val(row.Cells("precio_final").Value) * Val(row.Cells("Cantidad").Value)) + ((Val(row.Cells("precio_final").Value) * Val(row.Cells("Cantidad").Value)) * (Val(row.Cells("isv_por").Value) / 100)), 2)

        '            End If

        '        End If

        '        'MsgBox(row.Cells("total").Value & " = " & ((row.Cells("precio_final").Value & " * " & row.Cells("Cantidad").Value) & " + " & (row.Cells("precio_final").Value & " * " & row.Cells("isv_por").Value)))

        '        'END
        '        sumar_totales()
        '        Valdesc = Val(txt_descuento_general.Text)
        '        'End If
        '    Next
        'End If
    End Sub

    Private Sub VerNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerNotas.Click

        frmNotasCreDeb_DIMOSA.DataCredito.Rows.Clear()
        frmNotasCreDeb_DIMOSA.DataDebito1.Rows.Clear()
        For i As Integer = 0 To grd_ingreso.RowCount - 1
            Dim PrecioNeg As Decimal = 0
            Dim dta As New DataTable

            Try
                dta.Rows.Clear()
            Catch ex As Exception
            End Try

            Try
                Dim db As New cls_notas_debito
                dta = db.listar_productos_DIMOSA(grd_ingreso.Rows(i).Cells(1).Value, txt_codigo_proveedor.Text)
                PrecioNeg = dta(0)(3)
            Catch ex As Exception
                'MsgBox("Error al generar la información solicitada")
            End Try
            Dim ValorNota As Decimal = 0
            If (grd_ingreso.Rows(i).Cells("precio_final").Value < grd_ingreso.Rows(i).Cells("Precio_Negociado").Value) Then
                ValorNota = Math.Round((grd_ingreso.Rows(i).Cells("precio_negociado").Value * grd_ingreso.Rows(i).Cells("fconversion").Value * grd_ingreso.Rows(i).Cells("cantidad").Value) - (grd_ingreso.Rows(i).Cells("precio_final").Value * grd_ingreso.Rows(i).Cells("fconversion").Value * grd_ingreso.Rows(i).Cells("cantidad").Value), 2)
                frmNotasCreDeb_DIMOSA.DataCredito.Rows.Add(grd_ingreso.Rows(i).Cells("cve_art").Value, grd_ingreso.Rows(i).Cells("producto").Value, ValorNota)
            End If

            If (grd_ingreso.Rows(i).Cells("Precio_final").Value > grd_ingreso.Rows(i).Cells("precio_negociado").Value) Then
                ValorNota = Math.Round((grd_ingreso.Rows(i).Cells("precio_negociado").Value * grd_ingreso.Rows(i).Cells("fconversion").Value * grd_ingreso.Rows(i).Cells("cantidad").Value) - (grd_ingreso.Rows(i).Cells("precio_final").Value * grd_ingreso.Rows(i).Cells("fconversion").Value * grd_ingreso.Rows(i).Cells("cantidad").Value), 2)
                frmNotasCreDeb_DIMOSA.DataDebito1.Rows.Add(grd_ingreso.Rows(i).Cells("cve_art").Value, grd_ingreso.Rows(i).Cells("producto").Value, ValorNota)
            End If
        Next
        frmNotasCreDeb_DIMOSA.ShowDialog()

    End Sub

    Private Sub TextPedido_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextPedido.KeyDown
        If e.KeyCode = Keys.Enter Then
            'CargaIndividual()
            CargaCompleta()
        End If
    End Sub

    Sub CargaCompleta()
        Dim dtx As New DataTable
        Dim db As New cls_compras_pedidos
        Dim Conexion As New cls_notas_debito
        Dim proveedor As String = ""
        dtx = db.CargaInfoPedido(Val(TextPedido.Text), "DIMOSA")
        If dtx.Rows.Count > 0 Then
            txt_codigo_proveedor.Text = dtx(0)(2)
            txt_nombre_proveedor.Text = dtx(0)(3)
            cmb_sucursal.SelectedValue = dtx(0)(4)
            proveedor = dtx(0)(2)
            'FLAG
            FormCargaTodasPartidasCompraNacionalDimosa.DataDatos.Rows.Clear()
            FormCargaTodasPartidasCompraNacionalDimosa.Pedido = Val(TextPedido.Text)
            For a As Integer = 0 To dtx.Rows.Count - 1
                Dim dt As New DataTable
                dt = Conexion.valida_productos_DIMOSA(dtx(a)(5), dtx(a)(4))
                Dim validar As Integer = 0
                validar = dt.Rows(0)(0)
                Dim grd_lista As New DataTable
                grd_lista = Conexion.listar_productos_DIMOSA(dtx(a)(5), dtx(0)(2))
                If grd_lista.Rows(0)(8) <> proveedor Then
                    MessageBox.Show("El producto que esta ingresando no pertenece al proveedor seleccionado")
                End If
                Try
                    If validar < 1 Then
                        MessageBox.Show("El producto " & grd_lista.Rows(0)(0) & " - " & grd_lista.Rows(0)(1) & " no esta asignado al Almacen " & dtx(0)(4), "Producto no Asignado", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    Else
                        Dim codigo = grd_lista.Rows(0)(0)
                        Dim producto = grd_lista.Rows(0)(1)
                        Dim fac_conv = grd_lista.Rows(0)(2)
                        Dim precio_neg = grd_lista.Rows(0)(3)
                        Dim isv_por = grd_lista.Rows(0)(4)
                        Dim uni_entrada = grd_lista.Rows(0)(5)
                        Dim peso = grd_lista.Rows(0)(6)
                        Dim con_lote = grd_lista.Rows(0)(7)
                        Dim CODPROV = grd_lista.Rows(0)(9)
                        FormCargaTodasPartidasCompraNacionalDimosa.DataDatos.Rows.Add(Val(dtx(a)(7)) - Val(dtx(a)(8)), "cj", codigo, producto, fac_conv, uni_entrada, "...", "", precio_neg, Val(txt_descuento_general.Text), isv_por, con_lote, CODPROV, "✔", Val(dtx(a)(7)) - Val(dtx(a)(8)))
                        btn_new_prov.Enabled = False
                        TextPedido.Enabled = False
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrió un error al cargar una de las partidas del pedido: " & grd_lista.Rows(0)(1), MsgBoxStyle.Critical, "Error al cargar producto " & grd_lista.Rows(0)(0))
                End Try
            Next
            FormCargaTodasPartidasCompraNacionalDimosa.ShowDialog()
        Else
            MsgBox("La orden del pedido ingresado no se puede cargar", MsgBoxStyle.Information)
        End If
    End Sub


    Sub ValidaEnvio()
        Dim Contador As Integer = 0

        Dim ASD As String = "<h4>Los siguientes productos presentan diferencias de precios en compra DIMOSA a " & txt_nombre_proveedor.Text & ":</h4></hr></hr>"

        ASD += "<table border = '1'>"
        ASD += "<tr>"
        ASD += "<td><center> CLAVE </center></td> <td><center> DESCRIPCION </center></td> <td><center> PRECIO NEGOCIADO </center></td> <td><center> PRECIO FINAL:  </center></td> <td><center> CANTIDAD COMPRA </center></td>"
        ASD += "</tr>"

        For Each row As DataGridViewRow In grd_ingreso.Rows
            If row.Cells("precio_negociado").Value <> row.Cells("precio_final").Value Then
                Contador += 1
                ASD += "<tr>"
                ASD += "<td><h5>" & row.Cells(1).Value & " </h5></td> " & _
                       "<td><h5>" & row.Cells(2).Value & " </h5></td> " & _
                       "<td><h5>" & row.Cells("precio_negociado").Value & " </h5></td> " & _
                       "<td><h5>" & row.Cells("precio_final").Value & " </h5> </td>" & _
                       "<td><h5>" & row.Cells(0).Value & " </h5> </td>"
                ASD += ""
            End If
        Next
        ASD += "</table>"
        If Contador > 0 Then
            'MsgBox(ASD)
            Try
                Dim SMTP As String = "gator2024.hostgator.com"
                Dim Usuario As String = "compras@sanrafaelhn.com"
                Dim Contraseña As String = "Compras100"

                Dim Contenido As String = ""


                Dim Asunto As String = "Diferencias de Precios en Compra " & txt_nombre_proveedor.Text

                Dim Puerto As Integer = 26
                Dim correo As New System.Net.Mail.MailMessage()
                Dim Servidor As New System.Net.Mail.SmtpClient

                correo.From = New System.Net.Mail.MailAddress(Usuario)
                correo.Subject = Asunto

                correo.IsBodyHtml = True
                Contenido = ASD

                correo.To.Add("jose.padilla@sanrafaelhn.com")
                correo.To.Add("leonel.cruz@sanrafaelhn.com")
                correo.To.Add("alejandra.fuentes@sanrafaelhn.com")
                correo.To.Add("yesica.canales@sanrafaelhn.com")
                'correo.CC.Add("aron.castillo@sanrafaelhn.com")

                correo.IsBodyHtml = True
                correo.Body = Contenido

                Servidor.Host = SMTP
                Servidor.Port = Puerto
                Servidor.EnableSsl = False

                Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
                Servidor.Send(correo)

            Catch ex As Exception
                MessageBox.Show("No se logró enviar correo " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub
End Class