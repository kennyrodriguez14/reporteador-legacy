Imports Disar.data
Public Class frm_orden_pedidos_sragro
    Dim conexion As New cls_notas_debito_SRAGRO
    Dim folio As String = ""
    Dim ult_docto As Integer = 0
    Public modo As String
    Public dias_autorizados As Integer = 0
    Public stri
    Private Sub frm_orden_pedidos_sragro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cmb_vehiculo.SelectedItem = "Camion 250"

        get_almacen()

        If modo = "upd" Then
            Dim dt As New DataTable
            dt = conexion.detalles_ordenpedido(txt_num_registro.Text)
            For index As Integer = 0 To dt.Rows.Count - 1
                grd_ingreso.Rows.Add(dt.Rows(index)(0), dt.Rows(index)(1), dt.Rows(index)(2), dt.Rows(index)(3), dt.Rows(index)(4), dt.Rows(index)(5), _
                        dt.Rows(index)(6), dt.Rows(index)(7), dt.Rows(index)(8), dt.Rows(index)(9), dt.Rows(index)(10), dt.Rows(index)(11))
            Next
        End If
    End Sub

    Private Sub btn_new_client_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_prov.Click
        frm_lista_proveedores_sragro.Close()
        If frm_lista_proveedores_sragro.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_codigo_proveedor.Text = frm_lista_proveedores_sragro.codigo
            txt_nombre_proveedor.Text = frm_lista_proveedores_sragro.nombre
            txt_rfc.Text = frm_lista_proveedores_sragro.rfc
            dias_autorizados = frm_lista_proveedores_sragro.dias_aut
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

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_agregar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cargar_producto()
    End Sub

    Sub cargar_producto()
        frm_historico_producto.Close()
        frm_historico_producto.fecha = cmb_fecha_documento.Value
        frm_historico_producto.proveedor = txt_codigo_proveedor.Text
        If frm_historico_producto.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'txt_codigo_producto.Text = frm_historico_producto.codigo
            'txt_nombre_producto.Text = frm_historico_producto.producto
            'txt_factor_conversion.Text = frm_historico_producto.fac_conv
            'txt_isv_por.Text = frm_historico_producto.isv_por
            'txt_precio_neg.Text = frm_historico_producto.precio_neg
            'txt_cantidad.Text = frm_historico_producto.cantidad
            'btn_new_prov.Enabled = False
            'txt_descuento_por.Text = txt_descuento_general.Text
            'txt_peso.Text = frm_historico_producto.peso
        End If
    End Sub

    'Sub limpiar()
    '    txt_codigo_producto.Text = ""
    '    txt_nombre_producto.Text = ""
    '    txt_factor_conversion.Text = ""
    '    txt_precio_neg.Text = ""
    '    txt_cantidad.Text = ""
    '    txt_descuento_por.Text = ""
    '    txt_isv_por.Text = ""
    '    txt_precio_neg.Text = ""
    'End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'limpiar()
    End Sub

    Private Sub btn_quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar.Click
        Try
            grd_ingreso.Rows.RemoveAt(grd_ingreso.CurrentRow.Index)
            sumar_totales()

            If grd_ingreso.Rows.Count > 0 Then
            Else
                btn_new_prov.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub sumar_totales()
        Dim subtotal As Double = 0, total As Double = 0, descuento As Double = 0, isv As Double = 0, peso As Double = 0
        For index As Integer = 0 To grd_ingreso.RowCount - 1
            subtotal += grd_ingreso.Rows(index).Cells(8).Value
            descuento += grd_ingreso.Rows(index).Cells(9).Value
            isv += grd_ingreso.Rows(index).Cells(10).Value
            total += grd_ingreso.Rows(index).Cells(11).Value
            peso += grd_ingreso.Rows(index).Cells(12).Value
        Next
        txt_subtotal_final.Text = subtotal.ToString("N2")
        txt_descuento_final.Text = descuento.ToString("N2")
        txt_isv_final.Text = isv.ToString("N2")
        txt_total_final.Text = total.ToString("N2")
        txt_peso_cargado.Text = peso / 100

        If peso / 100 > ProgressBar1.Maximum Then
            ProgressBar1.Value = 100
        Else
            ProgressBar1.Value = peso / 100
        End If
    End Sub

    Private Sub grd_ingreso_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_ingreso.SelectionChanged
        If grd_ingreso.RowCount > 0 Then
            txt_mostrador_producto.Text = grd_ingreso.CurrentRow.Cells(2).Value
        End If
    End Sub

    Private Sub grd_ingreso_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) _
                                        Handles grd_ingreso.RowsAdded
        If grd_ingreso.RowCount - 1 > 0 Then
            txt_mostrador_producto.Text = grd_ingreso.CurrentRow.Cells(2).Value
        Else
            txt_mostrador_producto.Text = ""
        End If
    End Sub

    Private Sub grd_ingreso_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) _
                            Handles grd_ingreso.RowsRemoved
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
                dt.Columns.Add("peso")

                For index As Integer = 0 To grd_ingreso.Rows.Count - 1
                    dt.Rows.Add(grd_ingreso.Rows(index).Cells(0).Value, grd_ingreso.Rows(index).Cells(1).Value, grd_ingreso.Rows(index).Cells(2).Value, _
                    grd_ingreso.Rows(index).Cells(3).Value, grd_ingreso.Rows(index).Cells(4).Value, grd_ingreso.Rows(index).Cells(5).Value, _
                    grd_ingreso.Rows(index).Cells(6).Value, grd_ingreso.Rows(index).Cells(7).Value, grd_ingreso.Rows(index).Cells(8).Value, _
                    grd_ingreso.Rows(index).Cells(9).Value, grd_ingreso.Rows(index).Cells(10).Value, grd_ingreso.Rows(index).Cells(11).Value _
                    , grd_ingreso.Rows(index).Cells(12).Value)
                Next

                If modo = "upd" Then
                    Dim correcto As String = ""
                    correcto = conexion.update_orden_pedido(txt_num_registro.Text, cmb_fecha_documento.Value, Convert.ToDouble(txt_subtotal_final.Text), _
                                                            Convert.ToDouble(txt_descuento_final.Text), Convert.ToDouble(txt_isv_final.Text), _
                                                            Convert.ToDouble(txt_total_final.Text), dt)
                    If correcto = "correcto" Then
                        MessageBox.Show("Orden de pedido actualizada", "Operacion exitosa", MessageBoxButtons.OK, _
                                                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.Close()
                    Else
                        MessageBox.Show(correcto)
                    End If
                Else
                    If conexion.valida_numreg(txt_num_registro.Text) = True Then
                        MessageBox.Show("El numero de documento se actualizara a " & folio & (ult_docto + 1), "Informacion", _
                                                            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        txt_num_registro.Text = folio & (ult_docto + 1)
                        conexion.actualiza_num_reg(folio)
                    End If

                    Dim correcto As String = ""
                    correcto = conexion.guardar_orden_pedido(txt_num_registro.Text, txt_codigo_proveedor.Text, txt_nombre_proveedor.Text, txt_rfc.Text, _
                                                  cmb_sucursal.SelectedValue, txt_referencia_proveedor.Text, Val(txt_descuento_general.Text), _
                                                  cmb_fecha_documento.Value, "PENDIENTE", Convert.ToDouble(txt_subtotal_final.Text), _
                                                  Convert.ToDouble(txt_descuento_final.Text), Convert.ToDouble(txt_isv_final.Text), _
                                                  Convert.ToDouble(txt_total_final.Text), dt, folio, cmb_vehiculo.SelectedItem)
                    If correcto = "correcto" Then
                        MessageBox.Show("Informacion guardada", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information, _
                                                  MessageBoxDefaultButton.Button1)
                        If txt_codigo_proveedor.Text = "        23" Then
                            excel_balanceados()
                        Else
                            Exportar()
                        End If

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
        get_folio()
    End Sub

    Sub get_folio()
        frm_nd_folios_sragro.Close()
        If frm_nd_folios_sragro.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_num_registro.Text = frm_nd_folios_sragro.folio & frm_nd_folios_sragro.ult_doc
            cmb_sucursal.SelectedValue = frm_nd_folios_sragro.almacen
            folio = frm_nd_folios_sragro.folio
            ult_docto = frm_nd_folios_sragro.ult_doc
        End If
    End Sub

    Private Sub frm_orden_pedidos_sragro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F9 Then
            get_folio()
        End If
    End Sub

    Private Sub txt_descuento_general_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_descuento_general.TextChanged
        For index As Integer = 0 To grd_ingreso.RowCount - 1
            Dim subtotal As Double = 0
            Dim descuento As Double = 0
            Dim isv As Double = 0
            Dim total As Double = 0

            grd_ingreso.Rows(index).Cells(6).Value = txt_descuento_general.Text
            If grd_ingreso.Rows(index).Cells(0).Value = "cj" Then
                subtotal = grd_ingreso.Rows(index).Cells(3).Value * grd_ingreso.Rows(index).Cells(5).Value * grd_ingreso.Rows(index).Cells(4).Value
                descuento = subtotal * (Val(txt_descuento_general.Text) / 100)
                Isv = (subtotal - descuento) * (grd_ingreso.Rows(index).Cells(7).Value / 100)
                total = subtotal - descuento + Isv
            ElseIf grd_ingreso.Rows(index).Cells(0).Value = "pz" Then
                subtotal = grd_ingreso.Rows(index).Cells(5).Value * grd_ingreso.Rows(index).Cells(4).Value
                descuento = subtotal * (Val(txt_descuento_general.Text) / 100)
                Isv = (subtotal - descuento) * (grd_ingreso.Rows(index).Cells(7).Value / 100)
                total = subtotal - descuento + Isv
            End If
            grd_ingreso.Rows(index).Cells(8).Value = subtotal
            grd_ingreso.Rows(index).Cells(9).Value = descuento
            grd_ingreso.Rows(index).Cells(10).Value = isv
            grd_ingreso.Rows(index).Cells(11).Value = total
        Next
        sumar_totales()
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        If txt_codigo_proveedor.Text = "        23" Then
            excel_balanceados()
        Else
            Exportar()
        End If
    End Sub

    Sub Exportar()
        Try
            Dim estilo2 As Microsoft.Office.Interop.Excel.Style
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            estilo2 = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo2")
            estilo2.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            estilo2.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            estilo2.Font.Bold = True

            wSheet.Cells.Range("A2:C2").Merge()
            wSheet.Cells.Range("A2:C2").Value = "Orden de Compra"
            wSheet.Cells.Range("A2:C2").Font.Size = 16
            wSheet.Cells.Range("A2:C2").Font.Bold = True

            wSheet.Cells.Range("A3:C3").Merge()
            wSheet.Cells.Range("A3:C3").Value = "SR AGRO"
            wSheet.Cells.Range("A3:C3").Font.Size = 22
            wSheet.Cells.Range("A3:C3").Font.Bold = True

            wSheet.Cells.Range("A4:F4").Merge()
            wSheet.Cells.Range("A4:F4").Value = "PROVEEDOR: " + txt_nombre_proveedor.Text
            wSheet.Cells.Range("A4:F4").Font.Size = 8
            wSheet.Cells.Range("A4:F4").Font.Bold = True

            wSheet.Cells.Range("A5:C5").Merge()
            wSheet.Cells.Range("A5:C5").Value = "FECHA: " + cmb_fecha_documento.Value.Date
            wSheet.Cells.Range("A5:C5").Font.Size = 8
            wSheet.Cells.Range("A5:C5").Font.Bold = True

            For c As Integer = 0 To grd_ingreso.Columns.Count - 1
                wSheet.Cells(7, c + 1).value = grd_ingreso.Columns(c).HeaderText
                wSheet.Cells(7, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(7, c + 1).Style = "Estilo2"
            Next
            Dim filas As Integer
            For r As Integer = 0 To grd_ingreso.RowCount - 1
                For c As Integer = 0 To grd_ingreso.Columns.Count - 1
                    wSheet.Cells(r + 8, c + 1).value = grd_ingreso.Item(c, r).Value
                    wSheet.Cells(r + 8, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
                filas = filas + 1
            Next

            filas = filas + 9

            wSheet.Cells.Range("L" & filas & ":L" & filas).Merge()
            wSheet.Cells.Range("L" & filas & ":L" & filas).Value = "SUB TOTAL::::::"
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Size = 8
            wSheet.Cells.Range("L" & filas & ":L" & filas).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Bold = True

            wSheet.Cells.Range("M" & filas & ":M" & filas).Merge()
            wSheet.Cells.Range("M" & filas & ":M" & filas).Value = "L. " & txt_subtotal_final.Text
            wSheet.Cells.Range("M" & filas & ":M" & filas).Font.Size = 8
            wSheet.Cells.Range("M" & filas & ":M" & filas).Font.Bold = True

            filas += 1
            wSheet.Cells.Range("L" & filas & ":L" & filas).Merge()
            wSheet.Cells.Range("L" & filas & ":L" & filas).Value = "DESCUENTO::::::"
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Size = 8
            wSheet.Cells.Range("L" & filas & ":L" & filas).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Bold = True

            wSheet.Cells.Range("M" & filas & ":M" & filas).Merge()
            wSheet.Cells.Range("M" & filas & ":M" & filas).Value = "L. " & txt_descuento_general.Text
            wSheet.Cells.Range("M" & filas & ":M" & filas).Font.Size = 8
            wSheet.Cells.Range("M" & filas & ":M" & filas).Font.Bold = True
            filas += 1
            wSheet.Cells.Range("L" & filas & ":L" & filas).Merge()
            wSheet.Cells.Range("L" & filas & ":L" & filas).Value = "I.S.V::::::::::"
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Size = 8
            wSheet.Cells.Range("L" & filas & ":L" & filas).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Bold = True

            wSheet.Cells.Range("M" & filas & ":M" & filas).Merge()
            wSheet.Cells.Range("M" & filas & ":M" & filas).Value = "L. " & txt_isv_final.Text
            wSheet.Cells.Range("M" & filas & ":M" & filas).Font.Size = 8
            wSheet.Cells.Range("M" & filas & ":M" & filas).Font.Bold = True
            filas += 1
            wSheet.Cells.Range("L" & filas & ":L" & filas).Merge()
            wSheet.Cells.Range("L" & filas & ":L" & filas).Value = "TOTAL::::::::::"
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Size = 8
            wSheet.Cells.Range("L" & filas & ":L" & filas).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            wSheet.Cells.Range("L" & filas & ":L" & filas).Font.Bold = True

            wSheet.Cells.Range("M" & filas & ":M" & filas).Merge()
            wSheet.Cells.Range("M" & filas & ":M" & filas).Value = "L. " & txt_total_final.Text
            wSheet.Cells.Range("M" & filas & ":M" & filas).Font.Size = 8
            wSheet.Cells.Range("M" & filas & ":M" & filas).Font.Bold = True
            'End If

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmb_vehiculo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_vehiculo.SelectedIndexChanged
        If cmb_vehiculo.SelectedItem = "Camion 250" Then
            txt_capacidad.Text = "250"
            ProgressBar1.Maximum = 250
        ElseIf cmb_vehiculo.SelectedItem = "Camion 350" Then
            ProgressBar1.Maximum = 350
            txt_capacidad.Text = "350"
        ElseIf cmb_vehiculo.SelectedItem = "Camion 450" Then
            ProgressBar1.Maximum = 450
            txt_capacidad.Text = "450"
        Else
            ProgressBar1.Maximum = 500
            txt_capacidad.Text = "500"
        End If
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        frm_historico_producto.Close()
        frm_historico_producto.fecha = cmb_fecha_documento.Value
        frm_historico_producto.proveedor = txt_codigo_proveedor.Text
        frm_historico_producto.dias_autorizados = dias_autorizados
        frm_historico_producto.almacen = cmb_sucursal.SelectedValue
        frm_historico_producto.ShowDialog()
    End Sub

    Sub excel_balanceados()
        Try
            Dim estilo2 As Microsoft.Office.Interop.Excel.Style
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            estilo2 = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo2")
            estilo2.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            estilo2.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            estilo2.Font.Bold = True
            wSheet.Cells.Range("B1:K1").Merge()
            wSheet.Cells.Range("B1:K1").Value = "PROGRAMACION DE PEDIDOS"
            wSheet.Cells.Range("B1:K1").Font.Size = 22
            wSheet.Cells.Range("B1:K1").Font.Bold = True
            wSheet.Cells.Range("B1:K1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("B1:K1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("B1:K1").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.OliveDrab)
            wSheet.Cells.Range("B1:K1").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            wSheet.Cells.Range("B2:K2").Merge()
            wSheet.Cells.Range("B2:K2").Value = "CLIENTE:                     CODIGO:                      FECHA DE ENTREGA:                     "
            wSheet.Cells.Range("B2:K2").Font.Size = 12
            wSheet.Cells.Range("B2:K2").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
            wSheet.Cells.Range("B2:K2").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("B3:K3").Merge()
            wSheet.Cells.Range("B3:K3").Value = ""
            wSheet.Cells.Range("B3:K3").Font.Size = 12
            wSheet.Cells.Range("B3:K3").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("B3:K3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("B4:B4").Merge()
            wSheet.Cells.Range("B4:B4").Value = ""
            wSheet.Cells.Range("B4:B4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("B4:B4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("C4:C4").Merge()
            wSheet.Cells.Range("C4:C4").Value = "PRESENT."
            wSheet.Cells.Range("C4:C4").Font.Size = 12
            wSheet.Cells.Range("C4:C4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("C4:C4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("D4:D4").Merge()
            wSheet.Cells.Range("D4:D4").Value = "PESO"
            wSheet.Cells.Range("D4:D4").Font.Size = 12
            wSheet.Cells.Range("D4:D4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("D4:D4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("E4:E4").Merge()
            wSheet.Cells.Range("E4:E4").Value = "PRODUCTO"
            wSheet.Cells.Range("E4:E4").Font.Size = 12
            wSheet.Cells.Range("E4:E4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("E4:E4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("F4:F4").Merge()
            wSheet.Cells.Range("F4:F4").Value = "LUNES"
            wSheet.Cells.Range("F4:F4").Font.Size = 12
            wSheet.Cells.Range("F4:F4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("F4:F4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("G4:G4").Merge()
            wSheet.Cells.Range("G4:G4").Value = "MARTES"
            wSheet.Cells.Range("G4:G4").Font.Size = 12
            wSheet.Cells.Range("G4:G4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("G4:G4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("H4:H4").Merge()
            wSheet.Cells.Range("H4:H4").Value = "MIERCOLES"
            wSheet.Cells.Range("H4:H4").Font.Size = 12
            wSheet.Cells.Range("H4:H4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("H4:H4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("I4:I4").Merge()
            wSheet.Cells.Range("I4:I4").Value = "JUEVES"
            wSheet.Cells.Range("I4:I4").Font.Size = 12
            wSheet.Cells.Range("I4:I4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("H4:H4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("J4:J4").Merge()
            wSheet.Cells.Range("J4:J4").Value = "VIERNES"
            wSheet.Cells.Range("J4:J4").Font.Size = 12
            wSheet.Cells.Range("J4:J4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("J4:J4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("K4:K4").Merge()
            wSheet.Cells.Range("K4:K4").Value = "SABADO"
            wSheet.Cells.Range("K4:K4").Font.Size = 12
            wSheet.Cells.Range("K4:K4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("K4:K4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            Dim codigos_no_mostrar As String = ""

            If grd_ingreso.Rows.Count > 0 Then
                codigos_no_mostrar = ""
            Else
                codigos_no_mostrar = "''"
            End If

            For index As Integer = 0 To grd_ingreso.Rows.Count - 1
                codigos_no_mostrar += "'"
                codigos_no_mostrar += grd_ingreso.Rows(index).Cells(1).Value
                If index = grd_ingreso.Rows.Count - 1 Then
                    codigos_no_mostrar += "'"
                Else
                    codigos_no_mostrar += "',"
                End If
            Next
            Dim conexion As New cls_notas_debito_SRAGRO
            Dim tabla As New DataTable
            tabla = conexion.lista_formato_balanceados(codigos_no_mostrar)
            DataGridView1.DataSource = tabla

            For index As Integer = 0 To DataGridView1.Rows.Count - 1
                Try
                    DataGridView1.Rows(index).Cells(4).Value = (grd_ingreso.Rows(index).Cells(4).Value * DataGridView1.Rows(index).Cells(2).Value) / 100
                    DataGridView1.Rows(index).Cells(2).Value = Math.Round((DataGridView1.Rows(index).Cells(2).Value / 2.2), 2)
                Catch ex As Exception
                End Try
            Next
            DataGridView1.Sort(DataGridView1.Columns(5), System.ComponentModel.ListSortDirection.Ascending)

            Dim tabla2 As New DataTable
            tabla2.Columns.Add("clave")
            tabla2.Columns.Add("blanco")
            tabla2.Columns.Add("peso")
            tabla2.Columns.Add("descr")
            tabla2.Columns.Add("cantidad")
            tabla2.Columns.Add("linea")

            Dim totales As Double = 0
            Dim total_general As Double = 0
            For index As Integer = 0 To DataGridView1.Rows.Count - 1

                If index = 0 Then
                    tabla2.Rows.Add(DataGridView1.Rows(index).Cells(5).Value, "", "", "", "", "")
                Else
                    If DataGridView1.Rows(index).Cells(5).Value <> DataGridView1.Rows(index - 1).Cells(5).Value Then
                        tabla2.Rows.Add("", "", "", "Total " + DataGridView1.Rows(index - 1).Cells(5).Value, totales)
                        totales = 0
                        tabla2.Rows.Add(DataGridView1.Rows(index).Cells(5).Value, "", "", "", "", "")
                    End If
                End If


                tabla2.Rows.Add(DataGridView1.Rows(index).Cells(0).Value, DataGridView1.Rows(index).Cells(1).Value, _
                               DataGridView1.Rows(index).Cells(2).Value, DataGridView1.Rows(index).Cells(3).Value, _
                               DataGridView1.Rows(index).Cells(4).Value, DataGridView1.Rows(index).Cells(5).Value)

                totales += DataGridView1.Rows(index).Cells(4).Value
                total_general += DataGridView1.Rows(index).Cells(4).Value
                If index = (DataGridView1.Rows.Count - 1) Then
                    tabla2.Rows.Add("", "", "", "Total " + DataGridView1.Rows(index).Cells(5).Value, totales)
                    totales = 0
                End If
            Next
            tabla2.Rows.Add("", "", "", "Total General ", total_general)

            DataGridView1.DataSource = tabla2

            Dim nueva_col As Integer = 5
            Dim style As Microsoft.Office.Interop.Excel.Style
            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True

            For r As Integer = 0 To DataGridView1.RowCount - 1

                If DataGridView1.Rows(r).Cells(3).Value = "" Then
                    wSheet.Cells(r + nueva_col, 2).Style = "Reportes"
                End If

                If DataGridView1.Rows(r).Cells(2).Value = "" Then
                    wSheet.Cells(r + nueva_col, 5).Style = "Reportes"
                End If

                wSheet.Cells(r + nueva_col, 2).value = DataGridView1.Item(0, r).Value
                wSheet.Cells(r + nueva_col, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 3).value = DataGridView1.Item(1, r).Value
                wSheet.Cells(r + nueva_col, 3).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 4).value = DataGridView1.Item(2, r).Value
                wSheet.Cells(r + nueva_col, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 5).value = DataGridView1.Item(3, r).Value
                wSheet.Cells(r + nueva_col, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                If cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Monday Then
                    wSheet.Cells(r + nueva_col, 6).value = DataGridView1.Item(4, r).Value
                ElseIf cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Tuesday Then
                    wSheet.Cells(r + nueva_col, 7).value = DataGridView1.Item(4, r).Value
                ElseIf cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Wednesday Then
                    wSheet.Cells(r + nueva_col, 8).value = DataGridView1.Item(4, r).Value
                ElseIf cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Thursday Then
                    wSheet.Cells(r + nueva_col, 9).value = DataGridView1.Item(4, r).Value
                ElseIf cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Friday Then
                    wSheet.Cells(r + nueva_col, 10).value = DataGridView1.Item(4, r).Value
                ElseIf cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Saturday Then
                    wSheet.Cells(r + nueva_col, 11).value = DataGridView1.Item(4, r).Value
                End If

                wSheet.Cells(r + nueva_col, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 8).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 9).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 10).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 11).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                'For c As Integer = 0 To DataGridView1.Columns.Count - 1
                '    wSheet.Cells(r + nueva_col, c + 2).value = DataGridView1.Item(c, r).Value
                '    wSheet.Cells(r + nueva_col, c + 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                'Next
                'filas = filas + 1
            Next

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub excel_petfood()
        Try
            Dim estilo2 As Microsoft.Office.Interop.Excel.Style
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            estilo2 = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo2")
            estilo2.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            estilo2.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            estilo2.Font.Bold = True

            wSheet.Cells.Range("B1:K1").Merge()
            wSheet.Cells.Range("B1:K1").Value = "PROGRAMACION DE PEDIDOS"
            wSheet.Cells.Range("B1:K1").Font.Size = 22
            wSheet.Cells.Range("B1:K1").Font.Bold = True
            wSheet.Cells.Range("B1:K1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("B1:K1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("B1:K1").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.OliveDrab)
            wSheet.Cells.Range("B1:K1").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("B2:K2").Merge()
            wSheet.Cells.Range("B2:K2").Value = "CLIENTE:                     CODIGO:                      FECHA DE ENTREGA:                     "
            wSheet.Cells.Range("B2:K2").Font.Size = 12
            wSheet.Cells.Range("B2:K2").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.SteelBlue)
            wSheet.Cells.Range("B2:K2").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("B3:K3").Merge()
            wSheet.Cells.Range("B3:K3").Value = ""
            wSheet.Cells.Range("B3:K3").Font.Size = 12
            wSheet.Cells.Range("B3:K3").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("B3:K3").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("B4:B4").Merge()
            wSheet.Cells.Range("B4:B4").Value = ""
            wSheet.Cells.Range("B4:B4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("B4:B4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("C4:C4").Merge()
            wSheet.Cells.Range("C4:C4").Value = "PRESENT."
            wSheet.Cells.Range("C4:C4").Font.Size = 12
            wSheet.Cells.Range("C4:C4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("C4:C4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("D4:D4").Merge()
            wSheet.Cells.Range("D4:D4").Value = "PESO"
            wSheet.Cells.Range("D4:D4").Font.Size = 12
            wSheet.Cells.Range("D4:D4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("D4:D4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("E4:E4").Merge()
            wSheet.Cells.Range("E4:E4").Value = "PRODUCTO"
            wSheet.Cells.Range("E4:E4").Font.Size = 12
            wSheet.Cells.Range("E4:E4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("E4:E4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("F4:F4").Merge()
            wSheet.Cells.Range("F4:F4").Value = "LUNES"
            wSheet.Cells.Range("F4:F4").Font.Size = 12
            wSheet.Cells.Range("F4:F4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("F4:F4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("G4:G4").Merge()
            wSheet.Cells.Range("G4:G4").Value = "MARTES"
            wSheet.Cells.Range("G4:G4").Font.Size = 12
            wSheet.Cells.Range("G4:G4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("G4:G4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("H4:H4").Merge()
            wSheet.Cells.Range("H4:H4").Value = "MIERCOLES"
            wSheet.Cells.Range("H4:H4").Font.Size = 12
            wSheet.Cells.Range("H4:H4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("H4:H4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("I4:I4").Merge()
            wSheet.Cells.Range("I4:I4").Value = "JUEVES"
            wSheet.Cells.Range("I4:I4").Font.Size = 12
            wSheet.Cells.Range("I4:I4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("H4:H4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("J4:J4").Merge()
            wSheet.Cells.Range("J4:J4").Value = "VIERNES"
            wSheet.Cells.Range("J4:J4").Font.Size = 12
            wSheet.Cells.Range("J4:J4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("J4:J4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            wSheet.Cells.Range("K4:K4").Merge()
            wSheet.Cells.Range("K4:K4").Value = "SABADO"
            wSheet.Cells.Range("K4:K4").Font.Size = 12
            wSheet.Cells.Range("K4:K4").Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightSteelBlue)
            wSheet.Cells.Range("K4:K4").BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

            Dim codigos_no_mostrar As String = ""

            If grd_ingreso.Rows.Count > 0 Then
                codigos_no_mostrar = ""
            Else
                codigos_no_mostrar = "''"
            End If

            For index As Integer = 0 To grd_ingreso.Rows.Count - 1
                codigos_no_mostrar += "'"
                codigos_no_mostrar += grd_ingreso.Rows(index).Cells(1).Value
                If index = grd_ingreso.Rows.Count - 1 Then
                    codigos_no_mostrar += "'"
                Else
                    codigos_no_mostrar += "',"
                End If
            Next
            Dim conexion As New cls_notas_debito_SRAGRO
            Dim tabla As New DataTable
            tabla = conexion.lista_formato_balanceados(codigos_no_mostrar)
            DataGridView1.DataSource = tabla

            For index As Integer = 0 To DataGridView1.Rows.Count - 1
                Try
                    DataGridView1.Rows(index).Cells(4).Value = (grd_ingreso.Rows(index).Cells(4).Value * DataGridView1.Rows(index).Cells(2).Value) / 100
                    DataGridView1.Rows(index).Cells(2).Value = Math.Round((DataGridView1.Rows(index).Cells(2).Value / 2.2), 2)
                Catch ex As Exception

                End Try
            Next


            Dim tabla2 As New DataTable
            tabla2.Columns.Add("clave")
            tabla2.Columns.Add("blanco")
            tabla2.Columns.Add("peso")
            tabla2.Columns.Add("descr")
            tabla2.Columns.Add("cantidad")
            tabla2.Columns.Add("linea")

            Dim totales As Double = 0
            Dim total_general As Double = 0
            For index As Integer = 0 To DataGridView1.Rows.Count - 1

                If index = 0 Then
                    tabla2.Rows.Add(DataGridView1.Rows(index).Cells(5).Value, "", "", "", "", "")
                Else
                    If DataGridView1.Rows(index).Cells(5).Value <> DataGridView1.Rows(index - 1).Cells(5).Value Then
                        tabla2.Rows.Add("", "", "", "Total " + DataGridView1.Rows(index - 1).Cells(5).Value, totales)
                        totales = 0
                        tabla2.Rows.Add(DataGridView1.Rows(index).Cells(5).Value, "", "", "", "", "")
                    End If
                End If


                tabla2.Rows.Add(DataGridView1.Rows(index).Cells(0).Value, DataGridView1.Rows(index).Cells(1).Value, _
                               DataGridView1.Rows(index).Cells(2).Value, DataGridView1.Rows(index).Cells(3).Value, _
                               DataGridView1.Rows(index).Cells(4).Value, DataGridView1.Rows(index).Cells(5).Value)

                totales += DataGridView1.Rows(index).Cells(4).Value
                total_general += DataGridView1.Rows(index).Cells(4).Value
                If index = (DataGridView1.Rows.Count - 1) Then
                    tabla2.Rows.Add("", "", "", "Total " + DataGridView1.Rows(index).Cells(5).Value, totales)
                    totales = 0
                End If
            Next
            tabla2.Rows.Add("", "", "", "Total General ", total_general)

            DataGridView1.DataSource = tabla2

            Dim nueva_col As Integer = 5
            Dim style As Microsoft.Office.Interop.Excel.Style
            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True

            For r As Integer = 0 To DataGridView1.RowCount - 1

                If DataGridView1.Rows(r).Cells(3).Value = "" Then
                    wSheet.Cells(r + nueva_col, 2).Style = "Reportes"
                End If

                If DataGridView1.Rows(r).Cells(2).Value = "" Then
                    wSheet.Cells(r + nueva_col, 5).Style = "Reportes"
                End If

                wSheet.Cells(r + nueva_col, 2).value = DataGridView1.Item(0, r).Value
                wSheet.Cells(r + nueva_col, 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 3).value = DataGridView1.Item(1, r).Value
                wSheet.Cells(r + nueva_col, 3).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 4).value = DataGridView1.Item(2, r).Value
                wSheet.Cells(r + nueva_col, 4).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 5).value = DataGridView1.Item(3, r).Value
                wSheet.Cells(r + nueva_col, 5).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)

                If cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Monday Then
                    wSheet.Cells(r + nueva_col, 6).value = DataGridView1.Item(4, r).Value
                ElseIf cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Tuesday Then
                    wSheet.Cells(r + nueva_col, 7).value = DataGridView1.Item(4, r).Value
                ElseIf cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Wednesday Then
                    wSheet.Cells(r + nueva_col, 8).value = DataGridView1.Item(4, r).Value
                ElseIf cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Thursday Then
                    wSheet.Cells(r + nueva_col, 9).value = DataGridView1.Item(4, r).Value
                ElseIf cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Friday Then
                    wSheet.Cells(r + nueva_col, 10).value = DataGridView1.Item(4, r).Value
                ElseIf cmb_fecha_documento.Value.DayOfWeek = DayOfWeek.Saturday Then
                    wSheet.Cells(r + nueva_col, 11).value = DataGridView1.Item(4, r).Value
                End If

                wSheet.Cells(r + nueva_col, 6).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 7).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 8).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 9).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 10).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(r + nueva_col, 11).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                'For c As Integer = 0 To DataGridView1.Columns.Count - 1
                '    wSheet.Cells(r + nueva_col, c + 2).value = DataGridView1.Item(c, r).Value
                '    wSheet.Cells(r + nueva_col, c + 2).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                'Next
                'filas = filas + 1
            Next

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class