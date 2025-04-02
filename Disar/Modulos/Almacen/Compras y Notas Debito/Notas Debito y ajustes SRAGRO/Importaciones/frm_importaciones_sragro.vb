Imports Disar.data
Public Class frm_importaciones_sragro
    Dim conexion As New cls_notas_debito_SRAGRO
    Public codigo_compra As String
    Public modo As String
    Public subtotal_recibido As Double, descuento_recibido As Double, isv_recibido As Double, total_recibido As Double
    Dim conexion_otro_prov As New cls_notas_debito
    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        Try
            If txt_codigo_producto.Text = "" Or Val(txt_cantidad.Text) <= 0 Then
                MessageBox.Show("Ingrese todos los datos del producto")
            Else
                Dim subtotal As Double = 0
                Dim descuento As Double = 0
                Dim isv As Double = 0
                Dim total As Double = 0
                Dim precio_multiplicador As Double = 0
                Dim cadena_ajuste As String = ""

                If Val(txt_precio_neg.Text) = Val(txt_precio_final.Text) Then
                    precio_multiplicador = Math.Round(Val(txt_precio_neg.Text), 6)
                    cadena_ajuste = "N"
                ElseIf Val(txt_precio_neg.Text) > Val(txt_precio_final.Text) Then
                    precio_multiplicador = Math.Round(Val(txt_precio_neg.Text), 6) 'Val(txt_precio_final.Text)
                    cadena_ajuste = "D"
                ElseIf Val(txt_precio_neg.Text) < Val(txt_precio_final.Text) Then
                    precio_multiplicador = Math.Round(Val(txt_precio_neg.Text), 6)
                    cadena_ajuste = "S"
                End If

                grd_ingreso.Rows.Add(cmb_uni.SelectedItem, txt_codigo_producto.Text, txt_nombre_producto.Text, txt_factor_conversion.Text, _
                                     Val(txt_cantidad.Text), Math.Round(Val(txt_precio_neg.Text), 6), Math.Round(Val(txt_precio_final.Text), 6), 0, Val(txt_descuento_por.Text), Val(txt_isv_por.Text), 0, 0, _
                                     0, 0, Math.Round(precio_multiplicador, 6), cadena_ajuste, 0, 0, 0, 0, txt_con_lote.Text)
                calcular_nuevo_costo_final()
                limpiar()
                sumar_totales()
            End If
            txt_cantidad.Focus()
            grd_ingreso.ClearSelection()
            grd_ingreso.Rows(grd_ingreso.RowCount - 1).Selected = True
            grd_ingreso.Refresh()
            cmb_sucursal.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_new_prov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_prov.Click
        frm_lista_proveedores_sragro.Close()
        If frm_lista_proveedores_sragro.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_codigo_proveedor.Text = frm_lista_proveedores_sragro.codigo
            txt_nombre_proveedor.Text = frm_lista_proveedores_sragro.nombre
            txt_rfc.Text = frm_lista_proveedores_sragro.rfc
        End If
        cmb_sucursal.Focus()
    End Sub

    Private Sub frm_importaciones_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_uni.SelectedItem = "cj"
        If modo = "vista" Then
            modo_vista()
        ElseIf modo = "modificar" Then
            modo_modificar()
        ElseIf modo = "nuevo" Then
            tasa_cambio()
            get_almacen()
        End If
    End Sub

    Sub get_almacen()
        Try
            cmb_sucursal.DataSource = conexion.ListarAlmacenes
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub tasa_cambio()
        Try
            Dim dt As New DataTable
            dt = conexion.listar_tasa_cambio
            txt_tasa_pactada.Text = dt.Rows(0)(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_agregar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_producto.Click
        productos_carga()
    End Sub

    Sub productos_carga()
        frm_productos_precios_neg_sragro.Close()
        frm_productos_precios_neg_sragro.proveedor = txt_codigo_proveedor.Text
        frm_productos_precios_neg_sragro.almacen = cmb_sucursal.SelectedValue
        If frm_productos_precios_neg_sragro.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_codigo_producto.Text = frm_productos_precios_neg_sragro.codigo
            txt_nombre_producto.Text = frm_productos_precios_neg_sragro.producto
            txt_factor_conversion.Text = frm_productos_precios_neg_sragro.fac_conv
            txt_isv_por.Text = frm_productos_precios_neg_sragro.isv_por
            txt_precio_neg.Text = frm_productos_precios_neg_sragro.precio_neg
            txt_descuento_por.Text = Val(txt_descuento_general.Text)
            txt_uni_entrada.Text = frm_productos_precios_neg_sragro.uni_entrada
            txt_con_lote.Text = frm_productos_precios_neg_sragro.con_lote
            btn_new_prov.Enabled = False
            cargar_totales()
        End If
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
        Dim subtotal_fisico As Double = 0, total_fisico As Double = 0, descuento_fisico As Double = 0
        For index As Integer = 0 To grd_ingreso.RowCount - 1
            subtotal += grd_ingreso.Rows(index).Cells(10).Value
            descuento += grd_ingreso.Rows(index).Cells(11).Value
            isv += grd_ingreso.Rows(index).Cells(12).Value
            total += grd_ingreso.Rows(index).Cells(13).Value

            subtotal_fisico += grd_ingreso.Rows(index).Cells(6).Value * grd_ingreso.Rows(index).Cells(3).Value * grd_ingreso.Rows(index).Cells(4).Value
        Next
        txt_subtotal_final.Text = subtotal.ToString("N2")
        txt_descuento_final.Text = descuento.ToString("N2")
        'txt_isv_final.Text = isv.ToString("N2")
        txt_total_final.Text = total.ToString("N2")
        txt_subtotal_fisico.Text = subtotal_fisico
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Try
            Dim conex_validador As New cls_notas_debito
            Dim fecha_limite As New Date
            fecha_limite = conex_validador.validar_periodo_sr_agro()

            If cmb_fecha_documento.Value <= fecha_limite Then
                MessageBox.Show("El periodo se encuentra cerrado", "Periodo Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Else
                If grd_ingreso.Rows.Count > 0 Then
                    Dim dt_e As New DataTable
                    Dim dt_p As New DataTable
                    dt_e.Columns.Add("CVE_PROVEEDOR")
                    dt_e.Columns.Add("PROVEEDOR")
                    dt_e.Columns.Add("ALMACEN")
                    dt_e.Columns.Add("REF_PROV")
                    dt_e.Columns.Add("RFC")
                    dt_e.Columns.Add("FECHA")
                    dt_e.Columns.Add("DESCUENTO_POR")
                    dt_e.Columns.Add("SUB_TOTAL")
                    dt_e.Columns.Add("DESCUENTO_VAL")
                    dt_e.Columns.Add("ISV_VAL")
                    dt_e.Columns.Add("TOTAL")
                    dt_e.Columns.Add("ESTADO")
                    dt_e.Columns.Add("TASA_CAMBIO")
                    dt_e.Columns.Add("N_FACTURA_SAE")
                    dt_e.Columns.Add("FLETE")
                    dt_e.Columns.Add("SEGURO")
                    dt_e.Columns.Add("PYC")
                    dt_e.Columns.Add("HONORARIOS")
                    dt_e.Columns.Add("FECHA_FACTURA")

                    dt_e.Rows.Add(txt_codigo_proveedor.Text, txt_nombre_proveedor.Text, cmb_sucursal.SelectedValue, txt_referencia_proveedor.Text, _
                                  txt_rfc.Text, cmb_fecha_documento.Value.Date, txt_descuento_general.Text, Convert.ToDouble(txt_subtotal_final.Text), _
                                  Convert.ToDouble(txt_descuento_final.Text), Convert.ToDouble(txt_isv_final.Text), _
                                  Convert.ToDouble(txt_total_final.Text), "PENDIENTE", Val(txt_tasa_pactada.Text), "", _
                                  Convert.ToDouble(Val(txt_flete.Text.Replace(",", ""))), Convert.ToDouble(Val(txt_seguro.Text.Replace(",", ""))), _
                                  Convert.ToDouble(Val(txt_pyc.Text.Replace(",", ""))), Convert.ToDouble(Val(txt_honorarios.Text.Replace(",", ""))), cmb_fecha_factura.Value)

                    dt_p.Columns.Add("UNI")
                    dt_p.Columns.Add("CVE_ART")
                    dt_p.Columns.Add("PRODUCTO")
                    dt_p.Columns.Add("FACT_CONV")
                    dt_p.Columns.Add("CANTIDAD")
                    dt_p.Columns.Add("PRECIO_NEG")
                    dt_p.Columns.Add("PRECIO_FINAL")
                    dt_p.Columns.Add("PRECIO_NETO")
                    dt_p.Columns.Add("DESC_PROD")
                    dt_p.Columns.Add("ISV_PROD")
                    dt_p.Columns.Add("SUB_TOTAL")
                    dt_p.Columns.Add("DESCUENTO")
                    dt_p.Columns.Add("ISV")
                    dt_p.Columns.Add("TOTAL_PARTIDA")
                    dt_p.Columns.Add("PRECIO_INSERTAR")
                    dt_p.Columns.Add("AJUSTE")
                    dt_p.Columns.Add("HONORARIOS")
                    dt_p.Columns.Add("FLETE")
                    dt_p.Columns.Add("SEGURO")
                    dt_p.Columns.Add("PYC")
                    dt_p.Columns.Add("CON_LOTE")

                    For index As Integer = 0 To grd_ingreso.Rows.Count - 1
                        dt_p.Rows.Add(grd_ingreso.Rows(index).Cells(0).Value, grd_ingreso.Rows(index).Cells(1).Value, _
                                      grd_ingreso.Rows(index).Cells(2).Value, grd_ingreso.Rows(index).Cells(3).Value, _
                                      grd_ingreso.Rows(index).Cells(4).Value, grd_ingreso.Rows(index).Cells(5).Value, _
                                      grd_ingreso.Rows(index).Cells(6).Value, grd_ingreso.Rows(index).Cells(7).Value, _
                                      grd_ingreso.Rows(index).Cells(8).Value, grd_ingreso.Rows(index).Cells(9).Value, _
                                      grd_ingreso.Rows(index).Cells(10).Value, grd_ingreso.Rows(index).Cells(11).Value, _
                                      grd_ingreso.Rows(index).Cells(12).Value, grd_ingreso.Rows(index).Cells(13).Value, _
                                      grd_ingreso.Rows(index).Cells(14).Value, grd_ingreso.Rows(index).Cells(15).Value, _
                                      grd_ingreso.Rows(index).Cells(16).Value, grd_ingreso.Rows(index).Cells(17).Value, _
                                      grd_ingreso.Rows(index).Cells(18).Value, grd_ingreso.Rows(index).Cells(19).Value, _
                                      grd_ingreso.Rows(index).Cells(20).Value)
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

                    If modo = "nuevo" Then
                        If MessageBox.Show("¿Desea enviar la compra a SAE?", "Confirmacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            resultado = conexion.guardar_importacion_local_SAE(dt_e, dt_p, conlote, lote, _Inicio.lblUsuario.Text, cmb_otro_proveedores.SelectedValue)
                        Else
                            resultado = conexion.guardar_importacion_local(dt_e, dt_p, cmb_otro_proveedores.SelectedValue)
                        End If
                    ElseIf modo = "modificar" Then
                        resultado = conexion.modificar_importacion_local(dt_e, dt_p, codigo_compra, cmb_otro_proveedores.SelectedValue)
                        If resultado = "correcto" Then
                            If MessageBox.Show("¿Desea enviar la compra a SAE?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                                MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                resultado = conexion.envio_individual_importacion_local(dt_e, dt_p, codigo_compra, conlote, lote, _Inicio.lblUsuario.Text, cmb_otro_proveedores.SelectedValue)
                            End If
                        End If
                    End If

                    If resultado = "correcto" Then
                        MessageBox.Show("Informacion Almacenada correctamente", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information, _
                                        MessageBoxDefaultButton.Button1)
                        Me.Close()
                    Else
                        MessageBox.Show(resultado)
                    End If
                Else
                    MessageBox.Show("Debe seleccionar un producto", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, _
                                    MessageBoxDefaultButton.Button1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar.Click
        Try
            grd_ingreso.Rows.RemoveAt(grd_ingreso.CurrentRow.Index)
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
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

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        limpiar()
    End Sub

    Sub calcular_nuevo_costo_final()
        Try
            Dim total_california As Double = 0
            Dim unidades As Double = 0

            For index As Integer = 0 To grd_ingreso.RowCount - 1
                If grd_ingreso.Rows(index).Cells(1).Value = "16-0501" Or grd_ingreso.Rows(index).Cells(1).Value = "16-0502" _
                                    Or grd_ingreso.Rows(index).Cells(1).Value = "16-0505" Or grd_ingreso.Rows(index).Cells(1).Value = "16-0507" Then
                    total_california += grd_ingreso.Rows(index).Cells(10).Value
                End If
                unidades += grd_ingreso.Rows(index).Cells(10).Value
            Next

            For index As Integer = 0 To grd_ingreso.RowCount - 1
                Dim precio_neto As Double = 0, sub_total As Double = 0, descuento As Double = 0, isv As Double = 0, total As Double = 0
                Dim flete As Double = 0, seguro As Double = 0, pyc As Double = 0, honorarios As Double = 0

                If unidades > 0 Then
                    flete = (grd_ingreso.Rows(index).Cells(10).Value / unidades * Convert.ToDouble(Val(txt_flete.Text.Replace(",", "")))) / _
                    grd_ingreso.Rows(index).Cells(4).Value

                    seguro = (grd_ingreso.Rows(index).Cells(10).Value / unidades * Convert.ToDouble(Val(txt_seguro.Text))) / grd_ingreso.Rows(index).Cells(4).Value
                    honorarios = (grd_ingreso.Rows(index).Cells(10).Value / unidades * Convert.ToDouble(Val(txt_honorarios.Text))) / grd_ingreso.Rows(index).Cells(4).Value
                Else
                    flete = 0
                    seguro = 0
                    honorarios = 0
                End If

                If total_california > 0 Then
                    pyc = (grd_ingreso.Rows(index).Cells(10).Value / total_california * Convert.ToDouble(Val(txt_pyc.Text))) / grd_ingreso.Rows(index).Cells(4).Value
                Else
                    pyc = 0
                End If

                honorarios = honorarios / grd_ingreso.Rows(index).Cells(3).Value
                flete = flete / grd_ingreso.Rows(index).Cells(3).Value
                seguro = seguro / grd_ingreso.Rows(index).Cells(3).Value

                pyc = pyc / grd_ingreso.Rows(index).Cells(3).Value

                If grd_ingreso.Rows(index).Cells(1).Value = "16-0501" Or grd_ingreso.Rows(index).Cells(1).Value = "16-0502" _
                    Or grd_ingreso.Rows(index).Cells(1).Value = "16-0505" Or grd_ingreso.Rows(index).Cells(1).Value = "16-0507" Then
                    precio_neto = grd_ingreso.Rows(index).Cells(5).Value + flete + seguro + pyc + honorarios

                    grd_ingreso.Rows(index).Cells(19).Value = pyc
                Else
                    precio_neto = grd_ingreso.Rows(index).Cells(5).Value + flete + seguro + honorarios
                    grd_ingreso.Rows(index).Cells(19).Value = 0
                End If

                grd_ingreso.Rows(index).Cells(16).Value = honorarios
                grd_ingreso.Rows(index).Cells(17).Value = flete
                grd_ingreso.Rows(index).Cells(18).Value = seguro


                If cmb_uni.SelectedItem = "cj" Then
                    'sub_total = precio_neto * grd_ingreso.Rows(index).Cells(3).Value * grd_ingreso.Rows(index).Cells(4).Value
                    sub_total = grd_ingreso.Rows(index).Cells(5).Value * grd_ingreso.Rows(index).Cells(3).Value * grd_ingreso.Rows(index).Cells(4).Value
                ElseIf cmb_uni.SelectedItem = "pz" Then
                    'sub_total = precio_neto * grd_ingreso.Rows(index).Cells(4).Value
                    sub_total = grd_ingreso.Rows(index).Cells(5).Value * grd_ingreso.Rows(index).Cells(4).Value
                Else
                    'sub_total = precio_neto * grd_ingreso.Rows(index).Cells(3).Value * grd_ingreso.Rows(index).Cells(4).Value
                    sub_total = grd_ingreso.Rows(index).Cells(5).Value * grd_ingreso.Rows(index).Cells(3).Value * grd_ingreso.Rows(index).Cells(4).Value
                End If

                descuento = sub_total * grd_ingreso.Rows(index).Cells(8).Value
                'isv = (sub_total - descuento) * (grd_ingreso.Rows(index).Cells(9).Value / 100)
                total = (sub_total - descuento) + isv
                grd_ingreso.Rows(index).Cells(13).Value = Math.Round(total, 6)
                grd_ingreso.Rows(index).Cells(12).Value = Math.Round(isv, 6)
                grd_ingreso.Rows(index).Cells(11).Value = Math.Round(descuento, 6)
                grd_ingreso.Rows(index).Cells(10).Value = Math.Round(sub_total, 6)
                grd_ingreso.Rows(index).Cells(7).Value = Math.Round(precio_neto, 6)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calcular.Click
        cargar_totales()
    End Sub

    Sub cargar_totales()
        frm_calculadora_totales_sragro.Close()
        If frm_calculadora_totales_sragro.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If cmb_uni.SelectedItem = "cj" Then
                txt_precio_final.Text = Math.Round(Val(frm_calculadora_totales_sragro.txt_totales.Text) / Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
            ElseIf cmb_uni.SelectedItem = "pz" Then
                txt_precio_final.Text = Math.Round(Val(frm_calculadora_totales_sragro.txt_totales.Text) * Val(txt_cantidad.Text), 6)
            Else
                txt_precio_final.Text = Math.Round(Val(frm_calculadora_totales_sragro.txt_totales.Text) / Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
            End If
            btn_agregar.Focus()
        End If
    End Sub

    Private Sub txt_flete_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_flete.TextChanged
        Try
            txt_flete_l.Text = (Convert.ToDouble(Val(txt_flete.Text.Replace(",", ""))) * Val(txt_tasa_pactada.Text)).ToString("N2")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_seguro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_seguro.TextChanged
        Try
            txt_seguro_l.Text = (Val(txt_seguro.Text) * Val(txt_tasa_pactada.Text)).ToString("N2")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_pyc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pyc.TextChanged
        Try
            txt_pyc_l.Text = (Val(txt_pyc.Text) * Val(txt_tasa_pactada.Text)).ToString("N2")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_honorarios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_honorarios.TextChanged
        Try
            txt_honorarios_l.Text = (Val(txt_honorarios.Text) * Val(txt_tasa_pactada.Text)).ToString("N2")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_subtotal_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_subtotal_final.TextChanged
        Try
            txt_subtotal_l.Text = (Val(Convert.ToDouble(txt_subtotal_final.Text)) * Val(txt_tasa_pactada.Text)).ToString("N2")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_descuento_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descuento_final.TextChanged
        Try
            txt_descuento_l.Text = Val(Convert.ToDouble(txt_descuento_final.Text)) * Val(txt_tasa_pactada.Text).ToString("N2")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_isv_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_isv_final.TextChanged
        Try
            'txt_isv_l.Text = Val(txt_isv_final.Text) * Val(txt_tasa_pactada.Text)
        Catch ex As Exception
            txt_isv_fisico_l.Text = 0
        End Try
    End Sub

    Private Sub txt_total_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_final.TextChanged
        Try
            txt_total_l.Text = (Val(Convert.ToDouble(txt_total_final.Text)) * Val(txt_tasa_pactada.Text)).ToString("N2")
        Catch ex As Exception

        End Try
    End Sub

    Sub modo_vista()
        grp_ingreso_datos.Enabled = False
        grp_ingreso_producto.Enabled = False
        btn_guardar.Enabled = False
        cargar_partidas()
        txt_subtotal_final.Text = subtotal_recibido
        txt_descuento_final.Text = descuento_recibido
        txt_isv_final.Text = isv_recibido
        txt_total_final.Text = total_recibido
        txt_isv_l.ReadOnly = True

        txt_total_fisico.Text = Convert.ToDouble(Val(txt_flete.Text)) + Convert.ToDouble(Val(txt_seguro.Text)) + _
        Convert.ToDouble(Val(txt_pyc.Text)) + Convert.ToDouble(Val(txt_honorarios.Text)) + Convert.ToDouble(Val(txt_subtotal_fisico.Text)) + _
        Convert.ToDouble(Val(txt_isv_fisico.Text))

        txt_isv_l.Text = Val(txt_isv_final.Text) * Val(txt_tasa_pactada.Text)
    End Sub

    Sub cargar_partidas()
        Try
            Dim dt As New DataTable
            dt = conexion.listar_partidas_importaciones(codigo_compra)
            For index As Integer = 0 To dt.Rows.Count - 1
                grd_ingreso.Rows.Add(dt.Rows(index)(0), dt.Rows(index)(1), dt.Rows(index)(2), dt.Rows(index)(3), _
                                     dt.Rows(index)(4), dt.Rows(index)(5), dt.Rows(index)(6), dt.Rows(index)(7), _
                                     dt.Rows(index)(8), dt.Rows(index)(9), dt.Rows(index)(10), dt.Rows(index)(11), _
                                     dt.Rows(index)(12), dt.Rows(index)(13), dt.Rows(index)(14), dt.Rows(index)(15), _
                                     dt.Rows(index)(16), dt.Rows(index)(17), dt.Rows(index)(18), dt.Rows(index)(19), dt.Rows(index)(20))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Sub modo_modificar()
        btn_new_prov.Enabled = False
        cargar_partidas()
        txt_subtotal_final.Text = subtotal_recibido
        txt_descuento_final.Text = descuento_recibido
        txt_isv_final.Text = isv_recibido
        txt_total_final.Text = total_recibido
    End Sub

    Private Sub txt_subtotal_fisico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_subtotal_fisico.TextChanged
        Try
            txt_subtotal_fisico_l.Text = (Val(Convert.ToDouble(txt_subtotal_fisico.Text)) * Val(txt_tasa_pactada.Text)).ToString("N2")
            txt_total_fisico.Text = Convert.ToDouble(Val(txt_subtotal_fisico.Text)) + Convert.ToDouble(Val(txt_isv_fisico.Text)) + _
            Convert.ToDouble(Val(txt_flete.Text.Replace(",", ""))) + Convert.ToDouble(Val(txt_seguro.Text)) + Convert.ToDouble(Val(txt_pyc.Text)) + _
            Convert.ToDouble(Val(txt_honorarios.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_isv_fisico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_isv_fisico.TextChanged
        Try
            txt_isv_fisico_l.Text = (Val(Convert.ToDouble(txt_isv_fisico.Text)) * Val(txt_tasa_pactada.Text)).ToString("N2")
            txt_total_fisico.Text = Convert.ToDouble(Val(txt_subtotal_fisico.Text)) + Convert.ToDouble(Val(txt_isv_fisico.Text)) + _
           Convert.ToDouble(Val(txt_flete.Text.Replace(",", ""))) + Convert.ToDouble(Val(txt_seguro.Text)) + Convert.ToDouble(Val(txt_pyc.Text)) + _
            Convert.ToDouble(Val(txt_honorarios.Text))
        Catch ex As Exception
            txt_isv_fisico_l.Text = 0
            txt_isv_fisico.Text = 0
        End Try
    End Sub

    Private Sub txt_total_fisico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_fisico.TextChanged
        Try
            txt_total_fisico_l.Text = (Val(Convert.ToDouble(txt_total_fisico.Text)) * Val(txt_tasa_pactada.Text)).ToString("N2")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_isv_l_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_isv_l.TextChanged
        Try
            txt_isv_final.Text = (Val(Convert.ToDouble(txt_isv_l.Text)) / Val(txt_tasa_pactada.Text)).ToString("N2")
            txt_isv_fisico.Text = (Val(Convert.ToDouble(txt_isv_final.Text))).ToString("N2")
            calcular_nuevo_costo_final()
            sumar_totales()
            txt_total_final.Text = Convert.ToDouble(txt_total_final.Text) + Convert.ToDouble(Val(txt_isv_final.Text))
        Catch ex As Exception
            txt_isv_final.Text = 0
        End Try
    End Sub

    Private Sub cmb_lote_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_lote.CheckedChanged
        If cmb_lote.Checked = True Then
            txt_lote.Enabled = True
            txt_lote.Focus()
        Else
            txt_lote.Enabled = False
            txt_lote.Text = ""
        End If
    End Sub

    Private Sub cmb_sucursal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_sucursal.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_referencia_proveedor.Focus()
        End If
    End Sub

    Private Sub txt_referencia_proveedor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_referencia_proveedor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cmb_fecha_documento.Focus()
        End If
    End Sub

    Private Sub cmb_fecha_documento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_fecha_documento.KeyPress, cmb_fecha_factura.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_descuento_general.Focus()
        End If
    End Sub

    Private Sub txt_descuento_general_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento_general.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_flete.Focus()
        End If
    End Sub

    Private Sub txt_seguro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_seguro.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_pyc.Focus()
        End If
    End Sub

    Private Sub txt_flete_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_flete.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_seguro.Focus()
        End If
    End Sub

    Private Sub txt_pyc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pyc.KeyPress
        txt_honorarios.Focus()
    End Sub

    Private Sub txt_honorarios_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_honorarios.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_cantidad.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            productos_carga()
        End If
    End Sub

    Private Sub cmb_otro_prov_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_otro_prov.CheckedChanged
        If cmb_otro_prov.Checked = True Then
            cmb_otro_proveedores.Enabled = True
            cmb_otro_proveedores.DataSource = conexion_otro_prov.mostrar_proveedores_SRAGRO("")
            cmb_otro_proveedores.ValueMember = "CLAVE"
            cmb_otro_proveedores.DisplayMember = "NOMBRE"
        Else
            cmb_otro_proveedores.Enabled = False
            cmb_otro_proveedores.DataSource = conexion_otro_prov.mostrar_proveedores_SRAGRO("       565")
            cmb_otro_proveedores.ValueMember = "CLAVE"
            cmb_otro_proveedores.DisplayMember = "NOMBRE"
        End If
    End Sub
End Class