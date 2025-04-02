Imports Disar.data
Public Class frm_nueva_devolucion_dimosa

    Dim conexion As New cls_devoluciones
    Dim tipo_parcial As String
    Public modo As String
    Public num_reg As String
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub frm_nuevo_descuento_tactico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If modo = "visualice" Then
            btn_guardar.Enabled = False
            btn_agregar.Enabled = False
            btn_facturas.Enabled = False
            txt_num_registro.Text = num_reg
            Try
                grd_productos.DataSource = conexion.Detalle_DevolucionesDIMOSA(txt_num_registro.Text)
            Catch ex As Exception
            End Try
        Else
            cargar_sucursal()
            cargar_conceptos()
            cargar_factura()
        End If
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

    Sub cargar_conceptos()
        Try
            cmb_concepto.DataSource = conexion.listar_conceptosDIMOSA
            cmb_concepto.DisplayMember = "DESCRIPCION"
            cmb_concepto.ValueMember = "ID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_facturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_facturas.Click
        cargar_factura()
    End Sub

    Sub cargar_factura()
        Try
            frm_facturas_dimosa.Close()
            frm_facturas_dimosa.con_credito = "devolucion"
            frm_facturas_dimosa.ShowDialog()
            frm_facturas_dimosa.txt_numero_factura.Focus()
            If frm_facturas_dimosa.DialogResult = DialogResult.OK Then
                txt_numero_factura.Text = frm_facturas_dimosa.factura
                txt_tipo.Text = frm_facturas_dimosa.tipo
                cmb_fecha_documento.Value = frm_facturas_dimosa.fecha
                cmb_fecha_entrega.Value = frm_facturas_dimosa.fecha_entrega
                grd_productos.DataSource = conexion.productos_factura_dimosa(txt_numero_factura.Text)

                grd_productos.Columns(4).Visible = False
                grd_productos.Columns(5).Visible = False
                grd_productos.Columns(6).Visible = False
                grd_productos.Columns(7).Visible = False
                grd_productos.Columns(8).Visible = False
                grd_productos.Columns(9).Visible = False
                grd_productos.Columns(10).Visible = False
                grd_productos.Columns(11).Visible = False
                grd_productos.Columns(12).Visible = False
                grd_productos.Columns(13).Visible = False
                grd_productos.Columns(14).Visible = False
                cmb_sucursal.SelectedValue = frm_facturas_dimosa.almacen
                txt_codigo_entregador.Text = frm_facturas_dimosa.cod_entregador
                txt_entregador.Text = frm_facturas_dimosa.entregador
                txt_vehiculo.Text = frm_facturas_dimosa.vehiculo
                txt_codigo_cliente.Text = frm_facturas_dimosa.cod_cliente
                txt_nombre_cliente.Text = frm_facturas_dimosa.cliente
                txt_codigo_vendedor.Text = frm_facturas_dimosa.cod_vendedor
                txt_nombre_vendedor.Text = frm_facturas_dimosa.vendedor
                cmb_fecha_vencimiento.Value = frm_facturas_dimosa.fecha_ven
                txt_condicion.Text = frm_facturas_dimosa.condicion
                txt_rfc.Text = frm_facturas_dimosa.rfc
                txt_autoriza.Text = frm_facturas_dimosa.autoriza
                txt_folio.Text = frm_facturas_dimosa.folio
                txt_autoanio.Text = frm_facturas_dimosa.autoanio
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_productos_dt_DIMOSA.Close()
        frm_productos_dt_DIMOSA.ShowDialog()
        If frm_productos_dt_DIMOSA.DialogResult = Windows.Forms.DialogResult.OK Then
            txt_codigo_producto.Text = frm_productos_dt_DIMOSA.cve_art
            txt_nombre_producto.Text = frm_productos_dt_DIMOSA.producto
        End If
    End Sub

    Sub limpiar()
        txt_numero_partida.Text = ""
        txt_codigo_producto.Text = ""
        txt_nombre_producto.Text = ""
        txt_cantidad.Text = ""
        txt_prec_prod.Text = ""
        txt_cost_prod.Text = ""
        txt_impu_prod.Text = ""
        txt_desc1_prod.Text = ""
        txt_num_alm_prod.Text = ""
        txt_poli_apli_prod.Text = ""
        txt_uni_venta_prod.Text = ""
        txt_e_ltpd_prod.Text = ""
        txt_autoriza_prod.Text = ""
        txt_folio_prod.Text = ""
        txt_autoanio_prod.Text = ""
        txt_num_mov.Text = ""
        txt_fact_conv.Text = ""
        txt_con_lote.Text = ""
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        Try
            If txt_codigo_producto.Text = "" Or txt_nombre_producto.Text = "" Or txt_cantidad.Text = "" Or Val(txt_cantidad.Text) <= 0 Then
                MessageBox.Show("Valores vacios", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                Dim validador As Integer = 0
                validador = validar_producto(txt_numero_partida.Text)

                If validador = 0 Then
                    If Val(txt_cantidad.Text) > Val(txt_cantidad_real.Text) Then
                        MessageBox.Show("Cantidad mayor a Factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        grd_ingreso.Rows.Add(txt_numero_partida.Text, txt_codigo_producto.Text, txt_nombre_producto.Text, _
                                             txt_cantidad.Text, txt_cantidad_real.Text, txt_prec_prod.Text, txt_cost_prod.Text, _
                                             txt_impu_prod.Text, txt_desc1_prod.Text, txt_num_alm_prod.Text, txt_poli_apli_prod.Text, _
                                             txt_uni_venta_prod.Text, txt_e_ltpd_prod.Text, txt_num_mov.Text, txt_fact_conv.Text, _
                                             txt_con_lote.Text)
                        limpiar()
                        btn_facturas.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function validar_producto(ByVal partida As String) As Integer
        For index As Integer = 0 To grd_ingreso.RowCount - 1
            If grd_ingreso.Rows(index).Cells(0).Value = partida Then
                MessageBox.Show("El producto ya esta agregado", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 1
            End If
        Next
    End Function

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            grd_ingreso.Rows.RemoveAt(grd_ingreso.CurrentRow.Index)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Try
            Dim fech_limite As Date
            fech_limite = conexion.get_fecha_limite()
            If cmb_fecha_documento.Value.Date <= fech_limite Then
                MessageBox.Show("la fecha no esta en el rango autorizado")
            Else
                If txt_codigo_cliente.Text = "" Or txt_numero_factura.Text = "" Or grd_ingreso.Rows.Count <= 0 Then
                    MessageBox.Show("Debe seleccionar un cliente, una factura y producto", "Validacion", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Else
                    Dim dt_encabezado As New DataTable
                    Dim dt_partidas As New DataTable

                    dt_partidas.Columns.Add("num_part")
                    dt_partidas.Columns.Add("cve_art")
                    dt_partidas.Columns.Add("cantidad")
                    dt_partidas.Columns.Add("pxrs")
                    dt_partidas.Columns.Add("prec")
                    dt_partidas.Columns.Add("cost")
                    dt_partidas.Columns.Add("impu4")
                    dt_partidas.Columns.Add("desc1")
                    dt_partidas.Columns.Add("num_alm")
                    dt_partidas.Columns.Add("polit_apli")
                    dt_partidas.Columns.Add("uni_venta")
                    dt_partidas.Columns.Add("e_ltpd")
                    dt_partidas.Columns.Add("num_mov")
                    dt_partidas.Columns.Add("fact_conv")
                    dt_partidas.Columns.Add("con_lote")

                    For index As Integer = 0 To grd_ingreso.Rows.Count - 1
                        dt_partidas.Rows.Add(grd_ingreso.Rows(index).Cells(0).Value, grd_ingreso.Rows(index).Cells(1).Value, _
                                             grd_ingreso.Rows(index).Cells(3).Value, grd_ingreso.Rows(index).Cells(4).Value, _
                                             grd_ingreso.Rows(index).Cells(5).Value, grd_ingreso.Rows(index).Cells(6).Value, _
                                             grd_ingreso.Rows(index).Cells(7).Value, grd_ingreso.Rows(index).Cells(8).Value, _
                                             grd_ingreso.Rows(index).Cells(9).Value, grd_ingreso.Rows(index).Cells(10).Value, _
                                             grd_ingreso.Rows(index).Cells(11).Value, grd_ingreso.Rows(index).Cells(12).Value, _
                                             grd_ingreso.Rows(index).Cells(13).Value, grd_ingreso.Rows(index).Cells(14).Value, _
                                             grd_ingreso.Rows(index).Cells(15).Value)
                    Next

                    dt_encabezado.Columns.Add("cliente")
                    dt_encabezado.Columns.Add("tipo_pago")
                    dt_encabezado.Columns.Add("codigo_vendedor")
                    dt_encabezado.Columns.Add("almacen")
                    dt_encabezado.Columns.Add("n_factura")
                    dt_encabezado.Columns.Add("fecha_sae")
                    dt_encabezado.Columns.Add("fecha_elaboracion")
                    dt_encabezado.Columns.Add("concepto")
                    dt_encabezado.Columns.Add("cod_entregador")
                    dt_encabezado.Columns.Add("vehiculo")
                    dt_encabezado.Columns.Add("tipo_parcial")
                    dt_encabezado.Columns.Add("fecha_entrega")
                    dt_encabezado.Columns.Add("fecha_vencimiento")
                    dt_encabezado.Columns.Add("condicion")
                    dt_encabezado.Columns.Add("rfc")
                    dt_encabezado.Columns.Add("autoriza")
                    dt_encabezado.Columns.Add("folio")
                    dt_encabezado.Columns.Add("autoanio")

                    dt_encabezado.Rows.Add(txt_codigo_cliente.Text, txt_tipo.Text, txt_codigo_vendedor.Text, cmb_sucursal.SelectedValue, _
                                           txt_numero_factura.Text, cmb_fecha_documento.Value, cmb_fecha_descuento_tactico.Value, _
                                           cmb_concepto.SelectedValue, txt_codigo_entregador.Text, txt_vehiculo.Text, tipo_parcial, _
                                           cmb_fecha_entrega.Value, cmb_fecha_vencimiento.Value, txt_condicion.Text, txt_rfc.Text, _
                                           txt_autoriza.Text, txt_folio.Text, txt_autoanio.Text)

                    Dim variable_error As String = ""
                    If MessageBox.Show("¿Estan correctos los datos?", "Confirmacion", MessageBoxButtons.YesNo, _
                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        If modo = "upd" Then
                        ElseIf modo = "ins" Then
                            variable_error = conexion.guardar_datos_local_dimosa(dt_encabezado, dt_partidas)
                        End If

                        If variable_error = "correcto" Then
                            Dim conexion_bita As New cls_bitacora_reporteador
                            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Ingreso Nueva Devolucion DIMOSA", "Almacen - Devoluciones - DIMOSA", _
                                                      "Fecha: " + cmb_fecha_descuento_tactico.Value + _
                                                      " Factura: " + txt_numero_factura.Text)
                            Me.Close()
                        Else
                            MessageBox.Show(variable_error, "Advertencia", MessageBoxButtons.OK, _
                                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            MessageBox.Show(ex.Message + " --> " + linea_error)
        End Try
    End Sub

    Private Sub grd_productos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_productos.DoubleClick
        Try
            txt_numero_partida.Text = grd_productos.CurrentRow.Cells(0).Value
            txt_codigo_producto.Text = grd_productos.CurrentRow.Cells(1).Value
            txt_nombre_producto.Text = grd_productos.CurrentRow.Cells(2).Value
            txt_cantidad.Text = grd_productos.CurrentRow.Cells(3).Value
            txt_cantidad_real.Text = grd_productos.CurrentRow.Cells(3).Value
            txt_prec_prod.Text = grd_productos.CurrentRow.Cells(4).Value
            txt_cost_prod.Text = grd_productos.CurrentRow.Cells(5).Value
            txt_impu_prod.Text = grd_productos.CurrentRow.Cells(6).Value
            txt_desc1_prod.Text = grd_productos.CurrentRow.Cells(7).Value
            txt_num_alm_prod.Text = grd_productos.CurrentRow.Cells(8).Value
            txt_poli_apli_prod.Text = grd_productos.CurrentRow.Cells(9).Value
            txt_uni_venta_prod.Text = grd_productos.CurrentRow.Cells(10).Value
            txt_e_ltpd_prod.Text = grd_productos.CurrentRow.Cells(11).Value
            txt_num_mov.Text = grd_productos.CurrentRow.Cells(12).Value
            txt_fact_conv.Text = grd_productos.CurrentRow.Cells(13).Value
            txt_con_lote.Text = grd_productos.CurrentRow.Cells(14).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_devolucion_parcial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_devolucion_parcial.Click
        tipo_parcial = "P"
        grd_ingreso.Rows.Clear()
        grp_productos_factura.Enabled = True
        grp_ingreso.Enabled = True
        grd_ingreso.Enabled = True
    End Sub

    Private Sub btn_devolucion_completa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_devolucion_completa.Click
        tipo_parcial = "T"
        If grd_ingreso.RowCount > 0 Then
            If MessageBox.Show("Se quitaran los productos agregados parcialmente, ¿Desea Continuar?", "Validacion", _
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                grd_ingreso.Rows.Clear()
                limpiar()
                cargar_devolucion_completa()
            End If
        Else
            cargar_devolucion_completa()
        End If
    End Sub

    Sub cargar_devolucion_completa()
        For index As Integer = 0 To grd_productos.RowCount - 1
            grd_ingreso.Rows.Add(grd_productos.Rows(index).Cells(0).Value, grd_productos.Rows(index).Cells(1).Value, _
                                 grd_productos.Rows(index).Cells(2).Value, grd_productos.Rows(index).Cells(3).Value, _
                                 grd_productos.Rows(index).Cells(3).Value, grd_productos.Rows(index).Cells(4).Value, _
                                 grd_productos.Rows(index).Cells(5).Value, grd_productos.Rows(index).Cells(6).Value, _
                                 grd_productos.Rows(index).Cells(7).Value, grd_productos.Rows(index).Cells(8).Value, _
                                 grd_productos.Rows(index).Cells(9).Value, grd_productos.Rows(index).Cells(10).Value, _
                                 grd_productos.Rows(index).Cells(11).Value, grd_productos.Rows(index).Cells(12).Value, _
                                 grd_productos.Rows(index).Cells(13).Value, grd_productos.Rows(index).Cells(14).Value)
        Next
        grp_productos_factura.Enabled = False
        grp_ingreso.Enabled = False
        grd_ingreso.Enabled = True
    End Sub
End Class