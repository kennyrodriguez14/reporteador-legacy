Imports Disar.data
Public Class frm_orden_nacional_sragro
    Dim conexion As New cls_notas_debito_SRAGRO
    Public modo As String
    Public codigo_compra As String


    'Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" ( _
    ' ByVal process As IntPtr, _
    ' ByVal minimumWorkingSetSize As Integer, _
    ' ByVal maximumWorkingSetSize As Integer) As Integer

    'Public Shared Sub FlushMemory()
    '    Try
    '        GC.Collect()
    '        GC.WaitForPendingFinalizers()
    '        If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
    '            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub


    Private Sub btn_new_prov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_prov.Click
        frm_lista_proveedores_sragro.Close()
        If frm_lista_proveedores_sragro.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_codigo_proveedor.Text = frm_lista_proveedores_sragro.codigo
            txt_nombre_proveedor.Text = frm_lista_proveedores_sragro.nombre
            txt_rfc.Text = frm_lista_proveedores_sragro.rfc
            cmb_sucursal.Focus()
        End If
    End Sub

    Private Sub frm_orden_nacional_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            cmb_sucursal.DataSource = conexion.ListarAlmacenes
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
        frm_productos_precios_neg_sragro.Close()
        frm_productos_precios_neg_sragro.proveedor = txt_codigo_proveedor.Text
        frm_productos_precios_neg_sragro.almacen = cmb_sucursal.SelectedValue
        If frm_productos_precios_neg_sragro.ShowDialog = Windows.Forms.DialogResult.OK Then
            'txt_codigo_producto.Text = frm_productos_precios_neg_sragro.codigo
            'txt_nombre_producto.Text = frm_productos_precios_neg_sragro.producto
            'txt_factor_conversion.Text = frm_productos_precios_neg_sragro.fac_conv
            'txt_isv_por.Text = frm_productos_precios_neg_sragro.isv_por
            'txt_precio_neg.Text = Math.Round(frm_productos_precios_neg_sragro.precio_neg, 6)
            'txt_descuento_por.Text = Val(txt_descuento_general.Text)
            'txt_uni_entrada.Text = frm_productos_precios_neg_sragro.uni_entrada
            'txt_con_lote.Text = frm_productos_precios_neg_sragro.con_lote
            'btn_new_prov.Enabled = False
            'calcular_totales_boton()
            'txt_precio_final.Focus()
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
                                     Math.Round(descuento_mostrador), Math.Round(isv_mostrador), txt_con_lote.Text)
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

    Private Sub grd_ingreso_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) _
                Handles grd_ingreso.RowsAdded
        calcular_total()
    End Sub

    Sub calcular_total()
        Try
            If grd_ingreso.RowCount - 1 > 0 Then
                txt_mostrador_producto.Text = grd_ingreso.CurrentRow.Cells(2).Value
            Else
                txt_mostrador_producto.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_ingreso_RowsRemoved(ByVal sender As System.Object, ByVal e As  _
                                        System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles grd_ingreso.RowsRemoved
        calcular_total()
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
        Try
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
            dt_e.Columns.Add("SUBTOTAL_MOST")
            dt_e.Columns.Add("DESC_MOST")
            dt_e.Columns.Add("ISV_MOST")
            dt_e.Columns.Add("TOTAL_MOST")

            dt_e.Rows.Add(txt_codigo_proveedor.Text, txt_nombre_proveedor.Text, cmb_sucursal.SelectedValue, txt_referencia_proveedor.Text, _
                          txt_rfc.Text, cmb_fecha_documento.Value.Date, txt_descuento_general.Text, Convert.ToDouble(txt_subtotal_final.Text), _
                          Convert.ToDouble(txt_descuento_final.Text), Convert.ToDouble(txt_isv_final.Text), Convert.ToDouble(txt_total_final.Text), _
                          "PENDIENTE", Convert.ToDouble((txt_subtotalmostrador.Text)), Convert.ToDouble((txt_descuento_mostrador.Text)) _
                          , Convert.ToDouble((txt_isvmostrador.Text)), Convert.ToDouble((txt_totalmostrador.Text)))

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

            If modo = "nuevo" Then

                If MessageBox.Show("¿Desea enviar la compra a SAE?", "Confirmacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    resultado = conexion.guardar_compras_local_envio_SAE(dt_e, dt_p, conlote, lote, _Inicio.lblUsuario.Text)
                Else
                    resultado = conexion.guardar_compras_local(dt_e, dt_p)
                End If

            ElseIf modo = "modificar" Then
                resultado = conexion.modificar_compras_local(dt_e, dt_p, codigo_compra)
                If resultado = "correcto" Then
                    If MessageBox.Show("¿Desea enviar la compra a SAE?", "Confirmacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        resultado = conexion.envio_individual_compras_SAE(dt_e, dt_p, codigo_compra, conlote, lote, _Inicio.lblUsuario.Text)
                    End If
                End If
            End If

            If resultado = "correcto" Then
                MessageBox.Show("Informacion Almacenada correctamente", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.Close()
            Else
                MessageBox.Show(resultado)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
            frm_calculadora_totales_sragro.Close()
            If frm_calculadora_totales_sragro.ShowDialog() = Windows.Forms.DialogResult.OK Then


                If cmb_valores_base.SelectedItem = "Sub Total" Then
                    Dim precio As Double = 0, descuento As Double = 0, isv As Double = 0
                    If cmb_uni.SelectedItem = "cj" Then
                        precio = Math.Round(Val(frm_calculadora_totales_sragro.txt_totales.Text) / Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
                    ElseIf cmb_uni.SelectedItem = "pz" Then
                        precio = Math.Round(Val(frm_calculadora_totales_sragro.txt_totales.Text) / Val(txt_cantidad.Text), 6)
                    Else
                        precio = Math.Round(Val(frm_calculadora_totales_sragro.txt_totales.Text) / Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
                    End If

                    descuento = precio * (Val(txt_descuento_por.Text) / 100)
                    precio = Math.Round(precio - descuento, 6)
                    txt_precio_final.Text = precio
                ElseIf cmb_valores_base.SelectedItem = "Impuesto" Then

                    Dim precio As Double = 0, descuento As Double = 0, isv As Double = 0
                    If cmb_uni.SelectedItem = "cj" Then
                        precio = Math.Round(Val(frm_calculadora_totales_sragro.txt_totales.Text) / Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
                    ElseIf cmb_uni.SelectedItem = "pz" Then
                        precio = Math.Round(Val(frm_calculadora_totales_sragro.txt_totales.Text) / Val(txt_cantidad.Text), 6)
                    Else
                        precio = Math.Round(Val(frm_calculadora_totales_sragro.txt_totales.Text) / Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
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
        cargar_partidas()
    End Sub

    Sub cargar_partidas()
        Try
            Dim dt As New DataTable
            dt = conexion.listar_partidas_compras(codigo_compra)
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

    Private Sub txt_cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cantidad.TextChanged

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
End Class