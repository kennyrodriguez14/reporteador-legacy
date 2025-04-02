Imports Disar.data
Public Class frm_importaciones
    Dim conexion As New cls_notas_debito
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
                                     Val(txt_cantidad.Text), Math.Round(Val(txt_precio_neg.Text), 6), Math.Round(Val(txt_precio_final.Text), 6), _
                                     0, Val(txt_descuento_por.Text), Val(txt_isv_por.Text), 0, 0, 0, 0, Math.Round(precio_multiplicador, 6), _
                                     cadena_ajuste, 0, 0, 0, 0, 0, 0, 0, 0, txt_con_lote.Text, 0, 0, 0, 0, 0, 0)
                calcular_nuevo_costo_final()
                limpiar()
                sumar_totales()
            End If
            txt_cantidad.Focus()
            grd_ingreso.ClearSelection()
            grd_ingreso.Rows(grd_ingreso.RowCount - 1).Selected = True
            grd_ingreso.Refresh()
            cmb_sucursal.Enabled = False
            habilitar_pyc()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Sub habilitar_pyc()
        Dim conex As New cls_notas_debito
        Dim dt_pyc As New DataTable
        dt_pyc = conex.select_pyc()
        Dim habilitar_pyc As Integer = 0
        For indice_general As Integer = 0 To grd_ingreso.Rows.Count - 1
            For indice_pyc As Integer = 0 To dt_pyc.Rows.Count - 1
                If grd_ingreso.Rows(indice_general).Cells(1).Value = dt_pyc.Rows(indice_pyc)(0) Then
                    habilitar_pyc += 1
                End If
            Next
        Next

        If habilitar_pyc > 0 Then
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_pyc_l.Enabled = True
            ElseIf cmb_moneda.SelectedItem = "Dolar" Then
                txt_pyc.Enabled = True
            End If
        Else
            txt_pyc.Text = 0
            txt_pyc_l.Text = 0
            txt_pyc.Enabled = False
            txt_pyc_l.Enabled = False
        End If
    End Sub

    Private Sub btn_new_prov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_prov.Click
        frm_lista_proveedores.Close()
        If frm_lista_proveedores.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_codigo_proveedor.Text = frm_lista_proveedores.codigo
            txt_nombre_proveedor.Text = frm_lista_proveedores.nombre
            txt_rfc.Text = frm_lista_proveedores.rfc
        End If
        cmb_sucursal.Focus()
        cargar_otros_prov("       565")
    End Sub

    Sub cargar_otros_prov(ByVal buscar As String)
        cmb_otro_proveedores.DataSource = conexion_otro_prov.mostrar_proveedores(buscar)
        cmb_otro_proveedores.ValueMember = "CLAVE"
        cmb_otro_proveedores.DisplayMember = "NOMBRE"
    End Sub

    Private Sub frm_importaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_uni.SelectedItem = "cj"
        If modo = "vista" Then
            modo_vista()
            habilitar_pyc()
        ElseIf modo = "modificar" Then
            modo_modificar()
            habilitar_pyc()
        ElseIf modo = "nuevo" Then
            tasa_cambio()
            get_almacen()
        End If
        habilitar()
        cmb_moneda.SelectedItem = "Lempira"
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
        frm_productos_precios_neg.Close()
        frm_productos_precios_neg.proveedor = txt_codigo_proveedor.Text
        frm_productos_precios_neg.almacen = cmb_sucursal.SelectedValue
        If frm_productos_precios_neg.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_codigo_producto.Text = frm_productos_precios_neg.codigo
            txt_nombre_producto.Text = frm_productos_precios_neg.producto
            txt_factor_conversion.Text = frm_productos_precios_neg.fac_conv
            txt_isv_por.Text = frm_productos_precios_neg.isv_por
            txt_precio_neg.Text = frm_productos_precios_neg.precio_neg
            txt_descuento_por.Text = Val(txt_descuento_general.Text)
            txt_uni_entrada.Text = frm_productos_precios_neg.uni_entrada
            txt_con_lote.Text = frm_productos_precios_neg.con_lote
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
        txt_subtotal_final.Text = subtotal.ToString("N6")
        txt_descuento_final.Text = descuento.ToString("N6")
        'txt_isv_final.Text = isv.ToString("N6")
        txt_total_final.Text = total.ToString("N6")
        txt_subtotal_fisico.Text = subtotal_fisico '.ToString("N6")
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Try
            Dim conex_validador As New cls_notas_debito
            Dim fecha_limite As New Date
            fecha_limite = conex_validador.validar_periodo()

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
                    dt_e.Columns.Add("SEGURO") 'CUADRILLA O REVISION
                    dt_e.Columns.Add("PYC")
                    dt_e.Columns.Add("HONORARIOS")
                    dt_e.Columns.Add("PARQUEO")
                    dt_e.Columns.Add("REV_DES_CARG")
                    dt_e.Columns.Add("EMISION_G_REMISION")
                    dt_e.Columns.Add("ENCOMIENDAS")
                    dt_e.Columns.Add("GASTOS_VARIABLES")
                    dt_e.Columns.Add("n_boletin")
                    dt_e.Columns.Add("agencia")
                    dt_e.Columns.Add("TDATOS")
                    dt_e.Columns.Add("otro_prov")
                    dt_e.Columns.Add("SP")
                    dt_e.Columns.Add("EF")
                    dt_e.Columns.Add("DAI")
                    dt_e.Columns.Add("IVZ")
                    dt_e.Columns.Add("CARGO_LIVSMART")
                    dt_e.Columns.Add("SEL")
                    dt_e.Columns.Add("FECHA_FACTURA")
                    dt_e.Columns.Add("FLETE_LOCAL")

                    dt_e.Rows.Add(txt_codigo_proveedor.Text, txt_nombre_proveedor.Text, cmb_sucursal.SelectedValue, txt_referencia_proveedor.Text, _
                                  txt_rfc.Text, cmb_fecha_documento.Value.Date, txt_descuento_general.Text, Convert.ToDouble(txt_subtotal_final.Text), _
                                  Convert.ToDouble(txt_descuento_final.Text), Convert.ToDouble(txt_isv.Text), Convert.ToDouble(txt_total_final.Text), _
                                  "PENDIENTE", Val(txt_tasa_pactada.Text), "", Convert.ToDouble(Val(txt_flete.Text)), Convert.ToDouble(Val(txt_seguro.Text)), _
                                  Convert.ToDouble(Val(txt_pyc.Text)), Convert.ToDouble(Val(txt_honorarios.Text)), Convert.ToDouble(Val(txt_parqueo_D.Text)), _
                                  Convert.ToDouble(Val(txt_rev_des_carg_D.Text)), Convert.ToDouble(Val(txt_emision_gr_D.Text)), _
                                  Convert.ToDouble(Val(txt_encomiendas_D.Text)), Convert.ToDouble(Val(txt_gastos_variables_d.Text)), _
                                  txt_numero_boletin.Text, cmb_otro_proveedores.SelectedValue, Convert.ToDouble(Val(txt_servicio_tranporte_datos.Text)), _
                                  cmb_otro_proveedores.SelectedValue, Convert.ToDouble(Val(txt_servicio_portuario.Text)) _
                                  , Convert.ToDouble(Val(txt_especies_fiscales.Text)), Convert.ToDouble(Val(txt_dai.Text)), _
                                  Convert.ToDouble(Val(txt_ivz.Text)), Convert.ToDouble(Val(txt_cargo_livsmart.Text)), Convert.ToDouble(Val(txt_sel_d.Text)), _
                                  cmb_fecha_factura.Value, Convert.ToDouble(Val(txt_flete_local_d.Text)))

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
                    dt_p.Columns.Add("PARQUEO")
                    dt_p.Columns.Add("REV_DES_CARG")
                    dt_p.Columns.Add("EMISION_G_REMISION")
                    dt_p.Columns.Add("ENCOMIENDAS")
                    dt_p.Columns.Add("CON_LOTE")
                    dt_p.Columns.Add("GASTOS_VARIABLES")

                    dt_p.Columns.Add("SP")
                    dt_p.Columns.Add("EF")
                    dt_p.Columns.Add("DAI")
                    dt_p.Columns.Add("IVZ")
                    dt_p.Columns.Add("SEL")
                    dt_p.Columns.Add("FL")

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
                                      grd_ingreso.Rows(index).Cells(20).Value, grd_ingreso.Rows(index).Cells(21).Value, _
                                      grd_ingreso.Rows(index).Cells(22).Value, grd_ingreso.Rows(index).Cells(23).Value, _
                                      grd_ingreso.Rows(index).Cells(24).Value, grd_ingreso.Rows(index).Cells(25).Value, _
                                      grd_ingreso.Rows(index).Cells(27).Value, grd_ingreso.Rows(index).Cells(28).Value, _
                                      grd_ingreso.Rows(index).Cells(29).Value, grd_ingreso.Rows(index).Cells(30).Value, grd_ingreso.Rows(index).Cells(31).Value)
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

                    Dim inventario As Double
                    Dim isv As Double
                    Dim cxp_sae As Double
                    Dim acreedores_serv As Double
                    Dim isv_haber As Double

                    Dim acredores_serv_asiento2 As Double
                    Dim anticipo_isv As Double

                    inventario = Val(txt_subtotal_final.Text.Replace(",", "")) + Val(txt_honorarios.Text.Replace(",", "")) _
                                + Val(txt_servicio_tranporte_datos.Text.Replace(",", ""))

                    isv = Val(txt_isv.Text.Replace(",", ""))
                    cxp_sae = Val(txt_subtotal_final.Text.Replace(",", ""))
                    acreedores_serv = Val(txt_honorarios.Text.Replace(",", ""))
                    isv_haber = Val(txt_isv.Text.Replace(",", "")) + Val(txt_servicio_tranporte_datos.Text.Replace(",", ""))

                    acredores_serv_asiento2 = isv_haber
                    anticipo_isv = isv_haber

                    If modo = "nuevo" Then
                        If MessageBox.Show("¿Desea enviar la compra a SAE?", "Confirmacion", MessageBoxButtons.YesNoCancel, _
                                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            resultado = conexion.guardar_importacion_local_SAE(dt_e, dt_p, conlote, lote, cmb_fecha_vencimiento.Value.Date, _
                                                _Inicio.lblUsuario.Text, txt_cliente_rastra.Text, txt_nombre_rastra.Text)
                        Else
                            resultado = conexion.guardar_importacion_local(dt_e, dt_p, lote, cmb_fecha_vencimiento.Value.Date, _
                                                                           _Inicio.lblUsuario.Text, txt_cliente_rastra.Text, txt_nombre_rastra.Text)
                        End If
                    ElseIf modo = "modificar" Then
                        resultado = conexion.modificar_importacion_local(dt_e, dt_p, codigo_compra, lote, cmb_fecha_vencimiento.Value.Date, _
                                                                         txt_cliente_rastra.Text, txt_nombre_rastra.Text)
                        If resultado = "correcto" Then
                            If MessageBox.Show("¿Desea enviar la compra a SAE?", "Confirmacion", MessageBoxButtons.YesNo, _
                                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                resultado = conexion.envio_individual_importacion_local(dt_e, dt_p, codigo_compra, _
                                            conlote, lote, cmb_fecha_vencimiento.Value.Date, _Inicio.lblUsuario.Text, _
                                            txt_cliente_rastra.Text, txt_nombre_rastra.Text)
                                'envio_coi(inventario, isv, cxp_sae, acreedores_serv, isv_haber, acredores_serv_asiento2, anticipo_isv, _
                                '      txt_referencia_proveedor.Text, txt_referencia_proveedor.Text)
                            End If
                        End If
                    End If

                    If resultado = "correcto" Then
                        'envio_coi(inventario, isv, cxp_sae, acreedores_serv, isv_haber, acredores_serv_asiento2, anticipo_isv, _
                        '              txt_referencia_proveedor.Text, txt_referencia_proveedor.Text)
                        MessageBox.Show("Informacion Almacenada correctamente", "Operacion Exitosa", MessageBoxButtons.OK, _
                                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
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
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            MessageBox.Show(ex.Message + " --> " + linea_error + " " + ex.ToString())
        End Try
    End Sub

    Sub envio_coi(ByVal inventario As Double, ByVal isv As Double, ByVal cxp_sae As Double, ByVal acreedores_serv As Double, ByVal isv_haber As Double, _
                  ByVal acreedores_serv_asiento2 As Double, ByVal anticipo_isv As Double, ByVal cve_doc As String, ByVal cve_reporteador As String)

        'concepto Compra Livsmart Fact Nº 1
        Dim dt_contabilizacion As New DataTable
        dt_contabilizacion = New DataTable()
        dt_contabilizacion.Columns.Add("Cuenta")
        dt_contabilizacion.Columns.Add("Valor")
        dt_contabilizacion.Columns.Add("Tipo")

        Dim fila_contabilizacion As DataRow
        fila_contabilizacion = dt_contabilizacion.NewRow
        fila_contabilizacion("Cuenta") = "110900100000000000004"
        fila_contabilizacion("Valor") = inventario * Val(txt_tasa_pactada.Text)
        fila_contabilizacion("Tipo") = "D"
        dt_contabilizacion.Rows.Add(fila_contabilizacion)

        fila_contabilizacion = dt_contabilizacion.NewRow
        fila_contabilizacion("Cuenta") = "210700100000000000004"
        fila_contabilizacion("Valor") = isv * Val(txt_tasa_pactada.Text)
        fila_contabilizacion("Tipo") = "D"
        dt_contabilizacion.Rows.Add(fila_contabilizacion)

        fila_contabilizacion = dt_contabilizacion.NewRow
        fila_contabilizacion("Cuenta") = "210100100000000000004"
        fila_contabilizacion("Valor") = cxp_sae * Val(txt_tasa_pactada.Text)
        fila_contabilizacion("Tipo") = "H"
        dt_contabilizacion.Rows.Add(fila_contabilizacion)

        fila_contabilizacion = dt_contabilizacion.NewRow
        fila_contabilizacion("Cuenta") = "210202900000000000004"
        fila_contabilizacion("Valor") = acreedores_serv * Val(txt_tasa_pactada.Text)
        fila_contabilizacion("Tipo") = "H"
        dt_contabilizacion.Rows.Add(fila_contabilizacion)

        fila_contabilizacion = dt_contabilizacion.NewRow
        fila_contabilizacion("Cuenta") = "210700100000000000004"
        fila_contabilizacion("Valor") = isv_haber * Val(txt_tasa_pactada.Text)
        fila_contabilizacion("Tipo") = "H"
        dt_contabilizacion.Rows.Add(fila_contabilizacion)

        'concepto Compra Livsmart Boletin Nº 1
        Dim dt_contabilizacion2 As New DataTable
        dt_contabilizacion2 = New DataTable()
        dt_contabilizacion2.Columns.Add("Cuenta")
        dt_contabilizacion2.Columns.Add("Valor")
        dt_contabilizacion2.Columns.Add("Tipo")

        Dim fila_contabilizacion2 As DataRow
        fila_contabilizacion2 = dt_contabilizacion2.NewRow
        fila_contabilizacion2("Cuenta") = "210202900000000000004"
        fila_contabilizacion2("Valor") = acreedores_serv_asiento2 * Val(txt_tasa_pactada.Text)
        fila_contabilizacion2("Tipo") = "D"
        dt_contabilizacion2.Rows.Add(fila_contabilizacion2)

        fila_contabilizacion2 = dt_contabilizacion2.NewRow
        fila_contabilizacion2("Cuenta") = "210700100000000000004"
        fila_contabilizacion2("Valor") = anticipo_isv * Val(txt_tasa_pactada.Text)
        fila_contabilizacion2("Tipo") = "H"
        dt_contabilizacion2.Rows.Add(fila_contabilizacion2)

        Dim envio_coi As New cls_envio_coi
        Dim resultado_coi As String
        resultado_coi = envio_coi.enviar_coi(dt_contabilizacion, cmb_fecha_documento.Value.Year, cmb_fecha_documento.Value.Month, _
                                             cmb_fecha_documento.Value, "Co", cmb_fecha_documento.Value, cmb_fecha_documento.Value, _
                                             "Compra: " + cve_doc + " ", "05", txt_nombre_proveedor.Text, cve_reporteador)
        Dim resultado_coi2 As String
        resultado_coi2 = envio_coi.enviar_coi(dt_contabilizacion2, cmb_fecha_documento.Value.Year, cmb_fecha_documento.Value.Month, _
                                             cmb_fecha_documento.Value, "Co", cmb_fecha_documento.Value, cmb_fecha_documento.Value, _
                                              "Boletin: " + txt_numero_boletin.Text + " Compra:" + cve_doc + " ", "05", txt_nombre_proveedor.Text, _
                                                    cve_reporteador)
        Dim resultado_general As Integer = 0
        If resultado_coi <> "correcto" Then
            MessageBox.Show("No se pudo guardar la poliza de la importacion")
        End If

        If resultado_coi2 <> "correcto" Then
            MessageBox.Show("No se pudo guardar el boletin de la importacion")
        End If
    End Sub

    Private Sub btn_quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar.Click
        Try
            grd_ingreso.Rows.RemoveAt(grd_ingreso.CurrentRow.Index)
            habilitar_pyc()
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub grd_ingreso_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) _
    Handles grd_ingreso.RowsAdded
        Try
            If grd_ingreso.RowCount - 1 > 0 Then
                txt_mostrador_producto.Text = grd_ingreso.CurrentRow.Cells(2).Value
            Else
                txt_mostrador_producto.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grd_ingreso_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) _
    Handles grd_ingreso.RowsRemoved
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
                Dim conex As New cls_notas_debito
                Dim dt_pyc As New DataTable
                dt_pyc = conex.select_pyc()
                Dim habilitar_pyc As Integer = 0

                For indice_pyc As Integer = 0 To dt_pyc.Rows.Count - 1
                    If grd_ingreso.Rows(index).Cells(1).Value = dt_pyc.Rows(indice_pyc)(0) Then
                        total_california += grd_ingreso.Rows(index).Cells(10).Value
                    End If
                Next

                'If grd_ingreso.Rows(index).Cells(1).Value = "16-0501" Or grd_ingreso.Rows(index).Cells(1).Value = "16-0502" _
                '                    Or grd_ingreso.Rows(index).Cells(1).Value = "16-0505" Or grd_ingreso.Rows(index).Cells(1).Value = "16-0507" _
                '                    Or grd_ingreso.Rows(index).Cells(1).Value = "22-IT03620" Or grd_ingreso.Rows(index).Cells(1).Value = "22-IT00008" _
                '                    Or grd_ingreso.Rows(index).Cells(1).Value = "22-IT00014" Or grd_ingreso.Rows(index).Cells(1).Value = "22-IT02836" _
                '                    Or grd_ingreso.Rows(index).Cells(1).Value = "22-IT02861" Then
                '    total_california += grd_ingreso.Rows(index).Cells(10).Value
                'End If

                unidades += grd_ingreso.Rows(index).Cells(10).Value
            Next

            For index As Integer = 0 To grd_ingreso.RowCount - 1
                Dim precio_neto As Double = 0, sub_total As Double = 0, descuento As Double = 0, isv As Double = 0, total As Double = 0
                Dim flete As Double = 0, seguro As Double = 0, pyc As Double = 0, honorarios As Double = 0, flete_local As Double = 0
                Dim parqueo As Double = 0, revision_car_des As Double = 0, emision_guia_remision As Double = 0, encomiendas As Double = 0
                Dim gastos_variables As Double = 0, std As Double = 0, sp As Double = 0, ef As Double = 0, dai As Double = 0, sel As Double = 0

                If unidades > 0 Then
                    flete = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                             Convert.ToDouble(Val(txt_flete.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    seguro = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                              Convert.ToDouble(Val(txt_seguro.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    honorarios = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                              Convert.ToDouble(Val(txt_honorarios.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    parqueo = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                              Convert.ToDouble(Val(txt_parqueo_D.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    revision_car_des = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                              Convert.ToDouble(Val(txt_rev_des_carg_D.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    emision_guia_remision = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                              Convert.ToDouble(Val(txt_emision_gr_D.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    encomiendas = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                              Convert.ToDouble(Val(txt_encomiendas_D.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    gastos_variables = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                              Convert.ToDouble(Val(txt_gastos_variables_d.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    std = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                             Convert.ToDouble(Val(txt_servicio_tranporte_datos.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    sp = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                             Convert.ToDouble(Val(txt_servicio_portuario.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    ef = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                             Convert.ToDouble(Val(txt_especies_fiscales.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    dai = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                                                 Convert.ToDouble(Val(txt_dai.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    sel = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                                                 Convert.ToDouble(Val(txt_sel_d.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                    flete_local = (grd_ingreso.Rows(index).Cells(10).Value / unidades * _
                                                 Convert.ToDouble(Val(txt_flete_local.Text))) / grd_ingreso.Rows(index).Cells(4).Value

                Else
                    flete = 0
                    seguro = 0
                    honorarios = 0
                End If

                If total_california > 0 Then
                    pyc = (grd_ingreso.Rows(index).Cells(10).Value / total_california * _
                           Convert.ToDouble(Val(txt_pyc.Text))) / grd_ingreso.Rows(index).Cells(4).Value
                Else
                    pyc = 0
                End If

                honorarios = honorarios / grd_ingreso.Rows(index).Cells(3).Value
                flete = flete / grd_ingreso.Rows(index).Cells(3).Value
                seguro = seguro / grd_ingreso.Rows(index).Cells(3).Value

                parqueo = parqueo / grd_ingreso.Rows(index).Cells(3).Value
                revision_car_des = revision_car_des / grd_ingreso.Rows(index).Cells(3).Value
                emision_guia_remision = emision_guia_remision / grd_ingreso.Rows(index).Cells(3).Value
                encomiendas = encomiendas / grd_ingreso.Rows(index).Cells(3).Value
                gastos_variables = gastos_variables / grd_ingreso.Rows(index).Cells(3).Value

                std = std / grd_ingreso.Rows(index).Cells(3).Value
                sp = sp / grd_ingreso.Rows(index).Cells(3).Value
                ef = ef / grd_ingreso.Rows(index).Cells(3).Value
                dai = dai / grd_ingreso.Rows(index).Cells(3).Value
                sel = sel / grd_ingreso.Rows(index).Cells(3).Value
                flete_local = flete_local / grd_ingreso.Rows(index).Cells(3).Value

                pyc = pyc / grd_ingreso.Rows(index).Cells(3).Value

                'If grd_ingreso.Rows(index).Cells(1).Value = "16-0501" Or grd_ingreso.Rows(index).Cells(1).Value = "16-0502" _
                '    Or grd_ingreso.Rows(index).Cells(1).Value = "16-0505" Or grd_ingreso.Rows(index).Cells(1).Value = "16-0507" _
                '    Or grd_ingreso.Rows(index).Cells(1).Value = "22-IT03620" Or grd_ingreso.Rows(index).Cells(1).Value = "22-IT00008" _
                '    Or grd_ingreso.Rows(index).Cells(1).Value = "22-IT00014" Or grd_ingreso.Rows(index).Cells(1).Value = "22-IT02836" _
                '    Or grd_ingreso.Rows(index).Cells(1).Value = "22-IT02861" Then

                '    precio_neto = grd_ingreso.Rows(index).Cells(5).Value + flete + seguro + pyc + honorarios + parqueo _
                '                                                + revision_car_des + emision_guia_remision + encomiendas + gastos_variables + std + sp + ef + dai + sel

                '    grd_ingreso.Rows(index).Cells(19).Value = pyc
                'Else
                '    precio_neto = grd_ingreso.Rows(index).Cells(5).Value + flete + seguro + honorarios + parqueo + revision_car_des _
                '                                                 + emision_guia_remision + encomiendas + gastos_variables + std + sp + ef + dai + sel
                '    grd_ingreso.Rows(index).Cells(19).Value = 0
                'End If

                Dim conex As New cls_notas_debito
                Dim dt_pyc As New DataTable
                dt_pyc = conex.select_pyc()
                Dim habilitar_pyc As Integer = 0

                For indice_pyc As Integer = 0 To dt_pyc.Rows.Count - 1
                    If grd_ingreso.Rows(index).Cells(1).Value = dt_pyc.Rows(indice_pyc)(0) Then
                        habilitar_pyc += 1
                    End If
                Next


                If habilitar_pyc > 0 Then
                    precio_neto = grd_ingreso.Rows(index).Cells(5).Value + flete + seguro + pyc + honorarios + parqueo _
                                            + revision_car_des + emision_guia_remision + encomiendas + gastos_variables + std + sp + ef + dai + sel

                    grd_ingreso.Rows(index).Cells(19).Value = pyc
                Else
                    precio_neto = grd_ingreso.Rows(index).Cells(5).Value + flete + seguro + honorarios + parqueo + revision_car_des _
                                                                 + emision_guia_remision + encomiendas + gastos_variables + std + sp + ef + dai + sel
                    grd_ingreso.Rows(index).Cells(19).Value = 0
                End If


                grd_ingreso.Rows(index).Cells(16).Value = honorarios
                grd_ingreso.Rows(index).Cells(17).Value = flete
                grd_ingreso.Rows(index).Cells(18).Value = seguro

                grd_ingreso.Rows(index).Cells(20).Value = parqueo
                grd_ingreso.Rows(index).Cells(21).Value = revision_car_des
                grd_ingreso.Rows(index).Cells(22).Value = emision_guia_remision
                grd_ingreso.Rows(index).Cells(23).Value = encomiendas
                grd_ingreso.Rows(index).Cells(25).Value = gastos_variables

                grd_ingreso.Rows(index).Cells(26).Value = std
                grd_ingreso.Rows(index).Cells(27).Value = sp
                grd_ingreso.Rows(index).Cells(28).Value = ef
                grd_ingreso.Rows(index).Cells(29).Value = dai
                grd_ingreso.Rows(index).Cells(30).Value = sel
                grd_ingreso.Rows(index).Cells(31).Value = flete_local

                If cmb_uni.SelectedItem = "cj" Then
                    sub_total = grd_ingreso.Rows(index).Cells(5).Value * grd_ingreso.Rows(index).Cells(3).Value * grd_ingreso.Rows(index).Cells(4).Value
                ElseIf cmb_uni.SelectedItem = "pz" Then
                    sub_total = grd_ingreso.Rows(index).Cells(5).Value * grd_ingreso.Rows(index).Cells(4).Value
                Else
                    sub_total = grd_ingreso.Rows(index).Cells(5).Value * grd_ingreso.Rows(index).Cells(3).Value * grd_ingreso.Rows(index).Cells(4).Value
                End If

                descuento = 0
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
        frm_calculadora_totales.Close()
        If frm_calculadora_totales.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If cmb_uni.SelectedItem = "cj" Then
                txt_precio_final.Text = Math.Round(Val(frm_calculadora_totales.txt_totales.Text) _
                                                   / Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
            ElseIf cmb_uni.SelectedItem = "pz" Then
                txt_precio_final.Text = Math.Round(Val(frm_calculadora_totales.txt_totales.Text) * Val(txt_cantidad.Text), 6)
            Else
                txt_precio_final.Text = Math.Round(Val(frm_calculadora_totales.txt_totales.Text) / _
                                                   Val(txt_cantidad.Text) / Val(txt_factor_conversion.Text), 6)
            End If
            btn_agregar.Focus()
        End If
    End Sub

    Private Sub txt_flete_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_flete.TextChanged, txt_numero_boletin.TextChanged, txt_cargo_livsmart.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_flete_l.Text = (Val(txt_flete.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_seguro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txt_seguro.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_seguro_l.Text = (Val(txt_seguro.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_pyc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pyc.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_pyc_l.Text = (Val(txt_pyc.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_honorarios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txt_honorarios.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_honorarios_l.Text = (Val(txt_honorarios.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_subtotal_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_subtotal_final.TextChanged
        Try
            txt_subtotal_l.Text = (Val(Convert.ToDouble(txt_subtotal_final.Text)) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_descuento_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descuento_final.TextChanged
        Try
            txt_descuento_l.Text = Val(Convert.ToDouble(txt_descuento_final.Text)) * Val(txt_tasa_pactada.Text).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_total_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_final.TextChanged
        Try
            txt_total_l.Text = (Val(txt_total_final.Text.Replace(",", "")) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
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
        txt_isv.Text = isv_recibido
        txt_total_final.Text = total_recibido
        'txt_isv_l.ReadOnly = True
        totalizar_cajas()
    End Sub

    Sub totalizar_cajas()
        Try
            txt_flete_l.Text = (Val(txt_flete.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_seguro_l.Text = (Val(txt_seguro.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_pyc_l.Text = (Val(txt_pyc.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")

            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_honorarios_l.Text = (Val(txt_honorarios.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_parqueo_L.Text = (Val(txt_parqueo_D.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_rev_des_carg_L.Text = (Val(txt_rev_des_carg_D.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_emision_gr_L.Text = (Val(txt_emision_gr_D.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_encomiendas_L.Text = (Val(txt_encomiendas_D.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_gastos_variables_l.Text = (Val(txt_gastos_variables_d.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_servicio_transporte_datos_L.Text = (Val(txt_servicio_tranporte_datos.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            If Val(Convert.ToDouble(txt_isv.Text)) = 0 Then
                'txt_isv_l.Text = 0
            Else
                'txt_isv_l.Text = (Val(Convert.ToDouble(txt_isv_final.Text)) * Val(txt_tasa_pactada.Text)).ToString("N6")
            End If

            txt_isv_fisico.Text = (Val(Convert.ToDouble(txt_isv.Text))).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
            txt_total_final.Text = Convert.ToDouble(txt_total_final.Text) + Convert.ToDouble(Val(txt_isv.Text))
        Catch ex As Exception

        End Try

        Try
            txt_servicio_portuarioL.Text = (Val(txt_servicio_portuario.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_especies_fiscalesL.Text = (Val(txt_especies_fiscales.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_daiL.Text = (Val(txt_dai.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try

        Try
            txt_ivzL.Text = (Val(txt_ivz.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
            calcular_nuevo_costo_final()
            sumar_totales()
        Catch ex As Exception

        End Try
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
                                     dt.Rows(index)(16), dt.Rows(index)(17), dt.Rows(index)(18), dt.Rows(index)(19), _
                                     dt.Rows(index)(20), dt.Rows(index)(21), dt.Rows(index)(22), dt.Rows(index)(23), _
                                     dt.Rows(index)(24), dt.Rows(index)(25), dt.Rows(index)(26), dt.Rows(index)(27), _
                                     dt.Rows(index)(28))
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
        txt_isv.Text = isv_recibido
        txt_total_final.Text = total_recibido
    End Sub

    Private Sub txt_subtotal_fisico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_subtotal_fisico.TextChanged
        Try
            txt_subtotal_fisico_l.Text = (Convert.ToDouble(Val(txt_subtotal_fisico.Text)) * Val(txt_tasa_pactada.Text))
            txt_total_fisico.Text = Convert.ToDouble(Val(txt_subtotal_fisico.Text)) + Convert.ToDouble(Val(txt_isv_fisico.Text)) _
            + Convert.ToDouble(Val(txt_flete.Text)) + Convert.ToDouble(Val(txt_seguro.Text)) + Convert.ToDouble(Val(txt_pyc.Text)) _
            + Convert.ToDouble(Val(txt_honorarios.Text)) + Convert.ToDouble(Val(txt_parqueo_D.Text)) + Convert.ToDouble(Val(txt_rev_des_carg_D.Text)) _
            + Convert.ToDouble(Val(txt_emision_gr_D.Text)) + Convert.ToDouble(Val(txt_encomiendas_D.Text))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txt_isv_fisico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_isv_fisico.TextChanged
        Try
            txt_isv_fisico_l.Text = (Val(Convert.ToDouble(txt_isv_fisico.Text)) * Val(txt_tasa_pactada.Text)).ToString("N6")
            txt_total_fisico.Text = Convert.ToDouble(Val(txt_subtotal_fisico.Text)) + Convert.ToDouble(Val(txt_isv_fisico.Text)) _
                + Convert.ToDouble(Val(txt_flete.Text)) + Convert.ToDouble(Val(txt_seguro.Text)) + Convert.ToDouble(Val(txt_pyc.Text)) _
                + Convert.ToDouble(Val(txt_honorarios.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_total_fisico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_total_fisico.TextChanged, txt_isv_l.TextChanged, txt_isv_final.TextChanged
        Try
            txt_total_fisico_l.Text = (Convert.ToDouble(Val(txt_total_fisico.Text)) * Val(txt_tasa_pactada.Text)).ToString("N6")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_isv_l_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                If Val(Convert.ToDouble(txt_isv_l.Text)) = 0 Then
                    txt_isv.Text = 0
                Else
                    txt_isv_final.Text = (Val(Convert.ToDouble(txt_isv_l.Text)) / Val(txt_tasa_pactada.Text)).ToString("N6")
                End If

                txt_isv_fisico.Text = (Val(Convert.ToDouble(txt_isv.Text))).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
                txt_total_final.Text = Convert.ToDouble(txt_total_final.Text) + Convert.ToDouble(Val(txt_isv.Text))
            End If
        Catch ex As Exception
        End Try
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

    Private Sub cmb_sucursal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_sucursal.KeyPress, cmb_moneda.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_referencia_proveedor.Focus()
        End If
    End Sub

    Private Sub txt_referencia_proveedor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_referencia_proveedor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cmb_fecha_documento.Focus()
        End If
    End Sub

    Private Sub cmb_fecha_documento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_fecha_documento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_descuento_general.Focus()
        End If
    End Sub

    Private Sub txt_descuento_general_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_descuento_general.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_flete.Focus()
        End If
    End Sub

    Private Sub txt_seguro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txt_seguro.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_pyc.Focus()
        End If
    End Sub

    Private Sub txt_flete_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txt_flete.KeyPress, txt_numero_boletin.KeyPress, txt_cargo_livsmart.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_seguro.Focus()
        End If
    End Sub

    Private Sub txt_pyc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txt_pyc.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_honorarios.Focus()
        End If
    End Sub

    Private Sub txt_honorarios_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txt_honorarios.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_parqueo_D.Focus()
        End If
    End Sub

    Private Sub txt_cantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cantidad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            productos_carga()
        End If
    End Sub

    Private Sub txt_parqueo_D_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_parqueo_D.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_parqueo_L.Text = (Val(txt_parqueo_D.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_parqueo_D_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_parqueo_D.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_rev_des_carg_D.Focus()
        End If
    End Sub

    Private Sub txt_rev_des_carg_D_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txt_rev_des_carg_D.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_emision_gr_D.Focus()
        End If
    End Sub

    Private Sub txt_emision_gr_D_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_emision_gr_D.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_emision_gr_L.Text = (Val(txt_emision_gr_D.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_emision_gr_D_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txt_emision_gr_D.KeyPress, txt_sel_d.KeyPress, txt_flete_local.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_encomiendas_D.Focus()
        End If
    End Sub

    Private Sub txt_encomiendas_D_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_encomiendas_D.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_encomiendas_L.Text = (Val(txt_encomiendas_D.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txt_encomiendas_D_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txt_encomiendas_D.KeyPress, txt_gastos_variables_d.KeyPress, txt_servicio_tranporte_datos.KeyPress, txt_servicio_portuario.KeyPress, txt_ivz.KeyPress, txt_especies_fiscales.KeyPress, txt_dai.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_cantidad.Focus()
        End If
    End Sub

    Private Sub txt_rev_des_carg_D_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rev_des_carg_D.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_rev_des_carg_L.Text = (Val(txt_rev_des_carg_D.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_gastos_variables_d_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_gastos_variables_d.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_gastos_variables_l.Text = (Val(txt_gastos_variables_d.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmb_otro_prov_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_otro_prov.CheckedChanged

        If cmb_otro_prov.Checked = True Then
            cmb_otro_proveedores.Enabled = True
            cmb_otro_proveedores.DataSource = conexion_otro_prov.mostrar_proveedores("")
            cmb_otro_proveedores.ValueMember = "CLAVE"
            cmb_otro_proveedores.DisplayMember = "NOMBRE"
        Else
            cmb_otro_proveedores.Enabled = False
            cmb_otro_proveedores.DataSource = conexion_otro_prov.mostrar_proveedores("       565")
            cmb_otro_proveedores.ValueMember = "CLAVE"
            cmb_otro_proveedores.DisplayMember = "NOMBRE"
        End If

    End Sub

    Private Sub txt_servicio_tranporte_datos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_servicio_tranporte_datos.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_servicio_transporte_datos_L.Text = (Val(txt_servicio_tranporte_datos.Text) * Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_rastra_directa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rastra_directa.Click

        If frm_clie_rastra_SANRAFAEL.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_cliente_rastra.Text = frm_clie_rastra_SANRAFAEL.codigo
            txt_nombre_rastra.Text = frm_clie_rastra_SANRAFAEL.cliente
        End If

    End Sub

    Sub habilitar()
        habilitar_pyc()
        If cmb_moneda.SelectedItem = "Lempira" Then
            txt_flete_l.Enabled = True
            txt_seguro_l.Enabled = True
            'txt_pyc_l.Enabled = True
            txt_honorarios_l.Enabled = True
            txt_parqueo_L.Enabled = True
            txt_rev_des_carg_L.Enabled = True
            txt_emision_gr_L.Enabled = True
            txt_encomiendas_L.Enabled = True
            txt_gastos_variables_l.Enabled = True
            txt_servicio_transporte_datos_L.Enabled = True
            txt_isv_l.Enabled = True
            txt_sel_l.Enabled = True

            txt_servicio_portuarioL.Enabled = True
            txt_especies_fiscalesL.Enabled = True
            txt_daiL.Enabled = True
            txt_ivzL.Enabled = True

            txt_flete.Enabled = False
            txt_seguro.Enabled = False
            'txt_pyc.Enabled = False
            txt_honorarios.Enabled = False
            txt_parqueo_D.Enabled = False
            txt_rev_des_carg_D.Enabled = False
            txt_emision_gr_D.Enabled = False
            txt_encomiendas_D.Enabled = False
            txt_gastos_variables_d.Enabled = False
            txt_servicio_tranporte_datos.Enabled = False
            txt_isv.Enabled = False
            txt_servicio_portuario.Enabled = False
            txt_especies_fiscales.Enabled = False
            txt_dai.Enabled = False
            txt_ivz.Enabled = False

            txt_sel_l.Enabled = True
            txt_sel_d.Enabled = False

            txt_isv.Enabled = False
            txt_isv_fisico_l.Enabled = True

            txt_flete_local.Enabled = False
            txt_flete_local_d.Enabled = True
        ElseIf cmb_moneda.SelectedItem = "Dolar" Then
            txt_flete.Enabled = True
            txt_seguro.Enabled = True
            'txt_pyc.Enabled = True
            txt_honorarios.Enabled = True
            txt_parqueo_D.Enabled = True
            txt_rev_des_carg_D.Enabled = True
            txt_emision_gr_D.Enabled = True
            txt_encomiendas_D.Enabled = True
            txt_gastos_variables_d.Enabled = True
            txt_servicio_tranporte_datos.Enabled = True
            txt_isv.Enabled = True
            txt_servicio_portuario.Enabled = True
            txt_especies_fiscales.Enabled = True
            txt_dai.Enabled = True
            txt_ivz.Enabled = True
            txt_sel_d.Enabled = True

            txt_flete_l.Enabled = False
            txt_seguro_l.Enabled = False
            'txt_pyc_l.Enabled = False
            txt_honorarios_l.Enabled = False
            txt_parqueo_L.Enabled = False
            txt_rev_des_carg_L.Enabled = False
            txt_emision_gr_L.Enabled = False
            txt_encomiendas_L.Enabled = False
            txt_gastos_variables_l.Enabled = False
            txt_servicio_transporte_datos_L.Enabled = False
            txt_isv_l.Enabled = False

            txt_servicio_portuarioL.Enabled = False
            txt_especies_fiscalesL.Enabled = False
            txt_daiL.Enabled = False
            txt_ivzL.Enabled = False

            txt_isv.Enabled = True
            txt_isv_fisico_l.Enabled = False

            txt_sel_l.Enabled = False
            txt_sel_d.Enabled = True

            txt_flete_local.Enabled = True
            txt_flete_local_d.Enabled = False
        End If
    End Sub

    Private Sub cmb_moneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_moneda.SelectedIndexChanged
        habilitar()
    End Sub

    Private Sub txt_flete_l_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_flete_l.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_flete.Text = (Val(txt_flete_l.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_seguro_l_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_seguro_l.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_seguro.Text = (Val(txt_seguro_l.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_pyc_l_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pyc_l.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_pyc.Text = (Val(txt_pyc_l.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_honorarios_l_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_honorarios_l.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_honorarios.Text = (Val(txt_honorarios_l.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_parqueo_L_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_parqueo_L.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_parqueo_D.Text = (Val(txt_parqueo_L.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_rev_des_carg_L_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rev_des_carg_L.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_rev_des_carg_D.Text = (Val(txt_rev_des_carg_L.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_emision_gr_L_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_emision_gr_L.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_emision_gr_D.Text = (Val(txt_emision_gr_L.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_encomiendas_L_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_encomiendas_L.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_encomiendas_D.Text = (Val(txt_encomiendas_L.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_gastos_variables_l_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_gastos_variables_l.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_gastos_variables_d.Text = (Val(txt_gastos_variables_l.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_servicio_transporte_datos_L_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_servicio_transporte_datos_L.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_servicio_tranporte_datos.Text = (Val(txt_servicio_transporte_datos_L.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_isv_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                If Val(Convert.ToDouble(txt_isv.Text)) = 0 Then
                    txt_isv_l.Text = 0
                Else
                    txt_isv_l.Text = (Val(Convert.ToDouble(txt_isv_final.Text)) * Val(txt_tasa_pactada.Text))
                End If

                txt_isv_fisico.Text = (Val(Convert.ToDouble(txt_isv.Text)))
                calcular_nuevo_costo_final()
                sumar_totales()
                txt_total_final.Text = Convert.ToDouble(txt_total_final.Text) + Convert.ToDouble(Val(txt_isv.Text))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_servicio_portuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_servicio_portuario.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_servicio_portuarioL.Text = (Val(txt_servicio_portuario.Text) * Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_especies_fiscales_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_especies_fiscales.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_especies_fiscalesL.Text = (Val(txt_especies_fiscales.Text) * Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_dai_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_dai.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_daiL.Text = (Val(txt_dai.Text) * Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_ivz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ivz.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_ivzL.Text = (Val(txt_ivz.Text) * Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_servicio_portuarioL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_servicio_portuarioL.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_servicio_portuario.Text = (Val(txt_servicio_portuarioL.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_especies_fiscalesL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_especies_fiscalesL.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_especies_fiscales.Text = (Val(txt_especies_fiscalesL.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_daiL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_daiL.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_dai.Text = (Val(txt_daiL.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_ivzL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ivzL.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_ivz.Text = (Val(txt_ivzL.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_importaciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F4 Then
            frm_totalizador.txt_flete.Text = txt_flete.Text
            frm_totalizador.txt_seguro.Text = txt_seguro.Text
            frm_totalizador.txt_pyc.Text = txt_pyc.Text
            frm_totalizador.txt_honorarios.Text = txt_honorarios.Text
            frm_totalizador.txt_parqueo_D.Text = txt_parqueo_D.Text
            frm_totalizador.txt_rev_des_carg_D.Text = txt_rev_des_carg_D.Text
            frm_totalizador.txt_emision_gr_D.Text = txt_emision_gr_D.Text
            frm_totalizador.txt_encomiendas_D.Text = txt_encomiendas_D.Text
            frm_totalizador.txt_gastos_variables_d.Text = txt_gastos_variables_d.Text
            frm_totalizador.txt_servicio_tranporte_datos.Text = txt_servicio_tranporte_datos.Text
            frm_totalizador.txt_servicio_portuario.Text = txt_servicio_portuario.Text
            frm_totalizador.txt_especies_fiscales.Text = txt_especies_fiscales.Text
            frm_totalizador.txt_dai.Text = txt_dai.Text
            frm_totalizador.txt_ivz.Text = txt_ivz.Text
            frm_totalizador.txt_fob.Text = txt_total_final.Text
            frm_totalizador.txt_isv.Text = txt_isv.Text
            frm_totalizador.tasa_cambio = txt_tasa_pactada.Text
            frm_totalizador.ShowDialog()
        End If
    End Sub

    Private Sub btn_validar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validar.Click
        frm_validacion_sae.Close()
        frm_validacion_sae.CLAVE = txt_id.Text
        frm_validacion_sae.ShowDialog()
    End Sub

    Private Sub txt_isv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_isv.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_isv_fisico_l.Text = (Val(txt_isv.Text.Replace(",", "")) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_isv_fisico_l_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_isv_fisico_l.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_isv.Text = (Val(txt_isv_fisico_l.Text.Replace(",", "")) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_sel_d_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_sel_d.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_sel_l.Text = (Val(txt_sel_d.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_sel_l_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_sel_l.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_sel_d.Text = (Val(txt_sel_l.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_flete_local_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_flete_local.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Dolar" Then
                txt_flete_local_d.Text = (Val(txt_flete_local.Text) * Val(txt_tasa_pactada.Text)).ToString("N6")
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_flete_local_d_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_flete_local_d.TextChanged
        Try
            If cmb_moneda.SelectedItem = "Lempira" Then
                txt_flete_local.Text = (Val(txt_flete_local_d.Text) / Val(txt_tasa_pactada.Text))
                calcular_nuevo_costo_final()
                sumar_totales()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class