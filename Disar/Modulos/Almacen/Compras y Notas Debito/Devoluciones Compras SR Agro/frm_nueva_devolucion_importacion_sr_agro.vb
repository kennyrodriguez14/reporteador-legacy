Imports Disar.data

Public Class frm_nueva_devolucion_importacion_sr_agro
    Dim conexion As New cls_notas_debito_SRAGRO
    Public modo As String
    Public cve_compra As String
    Private Sub btn_cargar_compra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cargar_compra.Click
        lista_compras()
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

    Sub lista_compras()
        Try
            frm_lista_compras_dev.Close()
            frm_lista_compras_dev.tipo_compra = "imp"
            If frm_lista_compras_dev.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txt_cve_compra.Text = frm_lista_compras_dev.cve_compra
                txt_codigo_proveedor.Text = frm_lista_compras_dev.cve_prov
                txt_nombre_proveedor.Text = frm_lista_compras_dev.prov
                txt_referencia_proveedor.Text = frm_lista_compras_dev.fact
                cmb_sucursal.SelectedValue = frm_lista_compras_dev.almacen
                txt_rfc.Text = frm_lista_compras_dev.rfc
                cmb_fecha_documento.Value = frm_lista_compras_dev.fecha
                txt_descuento_general.Text = frm_lista_compras_dev.desc_por
                txt_subtotal_final.Text = frm_lista_compras_dev.subtotal
                txt_descuento_final.Text = frm_lista_compras_dev.desc_val
                txt_isv_final.Text = frm_lista_compras_dev.isv_val
                txt_total_final.Text = frm_lista_compras_dev.total
                txtn_fact_sae.Text = frm_lista_compras_dev.n_fact_sae
                txt_subtotalmostrador.Text = frm_lista_compras_dev.sub_most
                txt_descuento_mostrador.Text = frm_lista_compras_dev.des_most
                txt_isvmostrador.Text = frm_lista_compras_dev.isv_most
                txt_totalmostrador.Text = frm_lista_compras_dev.total_most
                txt_flete.Text = frm_lista_compras_dev.flete
                txt_lote.Text = frm_lista_compras_dev.lote
                cmb_fecha_vencimiento.Value = frm_lista_compras_dev.f_vencimiento
                txt_tasa_cambio.Text = frm_lista_compras_dev.tasa_cambio
                txt_refer_vesta.Text = frm_lista_compras_dev.refer_vesta
                txt_otroprov.Text = frm_lista_compras_dev.otro_prov
                partidas()
                btn_cargar_compra.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub partidas()
        Try
            grd_ingreso.DataSource = conexion.lista_partidas_devolver_importacion(txt_cve_compra.Text)
            grd_ingreso.Columns(0).ReadOnly = True
            grd_ingreso.Columns(1).ReadOnly = True
            grd_ingreso.Columns(2).ReadOnly = True
            grd_ingreso.Columns(3).ReadOnly = True
            grd_ingreso.Columns(3).ReadOnly = True
            grd_ingreso.Columns(4).ReadOnly = True
            grd_ingreso.Columns(5).ReadOnly = True
            grd_ingreso.Columns(6).ReadOnly = False
            grd_ingreso.Columns(7).ReadOnly = True
            grd_ingreso.Columns(8).ReadOnly = True
            grd_ingreso.Columns(9).ReadOnly = True
            grd_ingreso.Columns(10).ReadOnly = True
            grd_ingreso.Columns(11).ReadOnly = True
            grd_ingreso.Columns(12).ReadOnly = True
            grd_ingreso.Columns(13).ReadOnly = True
            grd_ingreso.Columns(14).ReadOnly = True
            grd_ingreso.Columns(15).ReadOnly = True
            grd_ingreso.Columns(16).ReadOnly = True
            grd_ingreso.Columns(17).ReadOnly = True
            grd_ingreso.Columns(18).ReadOnly = True
            grd_ingreso.Columns(19).ReadOnly = True
            grd_ingreso.Columns(20).ReadOnly = True
            grd_ingreso.Columns(21).ReadOnly = True
            grd_ingreso.Columns(22).ReadOnly = True
            grd_ingreso.Columns(23).ReadOnly = True

            grd_ingreso.Columns(0).Visible = False
            grd_ingreso.Columns(1).Visible = False
            grd_ingreso.Columns(7).Visible = False
            grd_ingreso.Columns(16).Visible = False
            grd_ingreso.Columns(17).Visible = False
            grd_ingreso.Columns(18).Visible = False
            grd_ingreso.Columns(19).Visible = False
            grd_ingreso.Columns(20).Visible = False
            grd_ingreso.Columns(21).Visible = False
            grd_ingreso.Columns(22).Visible = False
            grd_ingreso.Columns(23).Visible = False
            grd_ingreso.Columns(24).Visible = False
            grd_ingreso.Columns(25).Visible = False
            grd_ingreso.Columns(26).Visible = False

            calcular()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub calcular()
        Dim subtotal_g As Double = 0, descuento_g As Double = 0, isv_g As Double = 0, total_g As Double = 0
        Dim subtotal_g_most As Double = 0, descuento_g_most As Double = 0, isv_g_most As Double = 0, total_g_most As Double = 0

        For index As Integer = 0 To grd_ingreso.RowCount - 1
            subtotal_g += grd_ingreso.Rows(index).Cells(12).Value
            descuento_g += grd_ingreso.Rows(index).Cells(13).Value
            isv_g += grd_ingreso.Rows(index).Cells(14).Value
            total_g += grd_ingreso.Rows(index).Cells(15).Value
        Next

        txt_subtotal_final.Text = subtotal_g
        txt_descuento_final.Text = descuento_g
        txt_isv_final.Text = isv_g
        txt_total_final.Text = total_g

        txt_subtotalmostrador.Text = subtotal_g * Val(txt_tasa_cambio.Text)
        txt_descuento_mostrador.Text = descuento_g * Val(txt_tasa_cambio.Text)
        txt_isvmostrador.Text = isv_g * Val(txt_tasa_cambio.Text)
        txt_totalmostrador.Text = total_g * Val(txt_tasa_cambio.Text)
    End Sub

    Private Sub frm_nueva_devolucion_importacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If modo = "upd" Then
            cargar_partidas_devo()
            btn_guardar.Enabled = False
            btn_cargar_compra.Enabled = False
            cmb_tipo_devolucion.Enabled = False
            btn_guardar.Enabled = False
            btn_cargar_compra.Enabled = False
            cmb_tipo_devolucion.Enabled = False
            txt_subtotal_final.Visible = False
            txt_isv_final.Visible = False
            txt_descuento_final.Visible = False
            txt_subtotalmostrador.Visible = False
            txt_isvmostrador.Visible = False
            txt_descuento_mostrador.Visible = False
        Else
            get_almacen()
            cmb_tipo_devolucion.SelectedItem = "Total"
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Sub cargar_partidas_devo()
        Dim conexion As New cls_notas_debito
        grd_ingreso.DataSource = conexion.lista_partidas_devolucion_importacion(cve_compra)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim conex_validador As New cls_notas_debito
        Dim fecha_limite As New Date
        fecha_limite = conex_validador.validar_periodo()

        If cmb_fecha_documento.Value <= fecha_limite Then
            MessageBox.Show("El periodo se encuentra cerrado", "Periodo Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        Else
            If txt_codigo_proveedor.Text = "" Then
                MessageBox.Show("El Proveedor esta en blanco")
            Else
                Dim dt_e As New DataTable
                Dim dt_p As New DataTable
                dt_e.Columns.Add("CVE_PROV")
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
                dt_e.Columns.Add("TasaCambio")
                dt_e.Columns.Add("NfactSAE")
                dt_e.Columns.Add("Flete")
                dt_e.Columns.Add("Seguro")
                dt_e.Columns.Add("PYC")
                dt_e.Columns.Add("Honorarios")
                dt_e.Columns.Add("lote")
                dt_e.Columns.Add("vencimiento")
                dt_e.Columns.Add("parqueo")
                dt_e.Columns.Add("revdescarg")
                dt_e.Columns.Add("emisiongremision")
                dt_e.Columns.Add("encomiendas")
                dt_e.Columns.Add("gastosvariables")
                dt_e.Columns.Add("boletin")
                dt_e.Columns.Add("agencia")
                dt_e.Columns.Add("tdatos")
                dt_e.Columns.Add("otroprov")
                dt_e.Columns.Add("ncomprarep")
                dt_e.Columns.Add("refer_vesta")

                dt_e.Rows.Add(txt_codigo_proveedor.Text, txt_nombre_proveedor.Text, cmb_sucursal.SelectedValue, txt_referencia_proveedor.Text, _
                              txt_rfc.Text, cmb_fecha_documento.Value.Date, txt_descuento_general.Text, Convert.ToDouble(txt_subtotal_final.Text), _
                              Convert.ToDouble(txt_descuento_final.Text), Convert.ToDouble(txt_isv_final.Text), Convert.ToDouble(txt_total_final.Text), _
                              Convert.ToDouble((txt_tasa_cambio.Text)), txtn_fact_sae.Text, txt_flete.Text, txt_seguro.Text, txt_pyc.Text, txt_honorarios.Text, _
                              txt_lote.Text, cmb_fecha_vencimiento.Value, txt_parqueo.Text, txt_revdescarg.Text, txt_emision_gremision.Text, _
                              txt_encomiendas.Text, txt_gastosvariables.Text, txt_boletin.Text, txt_agencia.Text, txt_tdatos.Text, txt_otroprov.Text, _
                              txt_cve_compra.Text, txt_refer_vesta.Text)

                dt_p.Columns.Add("NUM_PART")
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
                dt_p.Columns.Add("E_LTPD")
                dt_p.Columns.Add("NUM_MOV")
                dt_p.Columns.Add("CANT2")

                For index As Integer = 0 To grd_ingreso.Rows.Count - 1

                    dt_p.Rows.Add(grd_ingreso.Rows(index).Cells(0).Value, grd_ingreso.Rows(index).Cells(1).Value, _
                                    grd_ingreso.Rows(index).Cells(2).Value, grd_ingreso.Rows(index).Cells(3).Value, _
                                    grd_ingreso.Rows(index).Cells(4).Value, grd_ingreso.Rows(index).Cells(6).Value, _
                                    grd_ingreso.Rows(index).Cells(7).Value, grd_ingreso.Rows(index).Cells(8).Value, _
                                    grd_ingreso.Rows(index).Cells(9).Value, grd_ingreso.Rows(index).Cells(10).Value, _
                                    grd_ingreso.Rows(index).Cells(11).Value, grd_ingreso.Rows(index).Cells(12).Value, _
                                    grd_ingreso.Rows(index).Cells(13).Value, grd_ingreso.Rows(index).Cells(14).Value, _
                                    grd_ingreso.Rows(index).Cells(15).Value, grd_ingreso.Rows(index).Cells(16).Value, _
                                    grd_ingreso.Rows(index).Cells(17).Value, 0, 0, 0, 0, 0, 0, 0, 0, _
                                    grd_ingreso.Rows(index).Cells(24).Value, 0, grd_ingreso.Rows(index).Cells(26).Value, _
                                    grd_ingreso.Rows(index).Cells(27).Value, grd_ingreso.Rows(index).Cells(5).Value)
                Next
                Dim resultado As String = ""
                If MessageBox.Show("¿Estan correctos los datos?", "Confirmacion", MessageBoxButtons.YesNoCancel, _
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim tipo As String
                    If cmb_tipo_devolucion.SelectedItem = "Total" Then
                        tipo = "T"
                    Else
                        tipo = "P"
                    End If
                    resultado = conexion.guardar_devolucion_simportacion(dt_e, dt_p, _Inicio.lblUsuario.Text, tipo)
                    If resultado = "correcto" Then
                        MessageBox.Show("Informacion Almacenada Correctamente", "Operacion Exitosa", MessageBoxButtons.OK, _
                                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.Close()
                    Else
                        MessageBox.Show(resultado)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmb_tipo_devolucion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipo_devolucion.SelectedIndexChanged
        If cmb_tipo_devolucion.SelectedItem = "Total" Then
            grd_ingreso.Enabled = False
        Else
            grd_ingreso.Enabled = True
        End If
        partidas()
    End Sub

    Private Sub grd_ingreso_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_ingreso.CellEndEdit
        If grd_ingreso.CurrentRow.Cells(6).Value > grd_ingreso.CurrentRow.Cells(5).Value Then
            MessageBox.Show("No puede ingresar una cantidad mayor a la de la factura")
            grd_ingreso.CurrentRow.Cells(6).Value = grd_ingreso.CurrentRow.Cells(5).Value
        Else
            Dim subt As Double = 0, desc As Double = 0, isv As Double = 0
            subt = grd_ingreso.CurrentRow.Cells(6).Value * grd_ingreso.CurrentRow.Cells(4).Value _
                                                 * grd_ingreso.CurrentRow.Cells(7).Value
            desc = subt * (grd_ingreso.CurrentRow.Cells(9).Value / 100)
            isv = (subt - desc) * (grd_ingreso.CurrentRow.Cells(10).Value / 100)
            grd_ingreso.CurrentRow.Cells(11).Value = subt
            grd_ingreso.CurrentRow.Cells(12).Value = desc
            grd_ingreso.CurrentRow.Cells(13).Value = isv
            grd_ingreso.CurrentRow.Cells(14).Value = subt - desc + isv

            Dim subt_m As Double = 0, desc_m As Double = 0, isv_m As Double = 0
            subt_m = grd_ingreso.CurrentRow.Cells(6).Value * grd_ingreso.CurrentRow.Cells(4).Value _
                                                * grd_ingreso.CurrentRow.Cells(8).Value
            desc_m = subt_m * (grd_ingreso.CurrentRow.Cells(9).Value / 100)
            isv_m = (subt_m - desc_m) * (grd_ingreso.CurrentRow.Cells(10).Value / 100)

            grd_ingreso.CurrentRow.Cells(17).Value = subt_m
            grd_ingreso.CurrentRow.Cells(18).Value = desc_m
            grd_ingreso.CurrentRow.Cells(19).Value = isv_m
            grd_ingreso.CurrentRow.Cells(20).Value = subt_m - desc_m + isv_m
        End If
        calcular()
    End Sub

    Private Sub grd_ingreso_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles grd_ingreso.RowsRemoved
        calcular()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub grd_ingreso_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_ingreso.SelectionChanged
        Try
            If grd_ingreso.RowCount > 0 Then
                txt_mostrador_producto.Text = grd_ingreso.CurrentRow.Cells(3).Value
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class