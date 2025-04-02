Imports Disar.data
Public Class frm_detalle_dimosa
    Dim conexion As New cls_descuentos_tacticos
    Dim dt_adic As New DataTable
    Private Sub frm_detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dt2 As New DataTable
            dt2 = conexion.listar_partida_dimosa(txt_num_registro.Text)
            dt_adic = conexion.listar_datos_adicionales_dimosa(txt_num_registro.Text)
            grd_lista.DataSource = dt2

            txt_cve_vend.Text = dt_adic.Rows(0)(6)
            txt_num_alma.Text = dt_adic.Rows(0)(4)
            txt_estado.Text = dt_adic.Rows(0)(5)

            If txt_estado.Text = "SIN ENVIAR" Then
                btn_enviar.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_enviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar.Click
        Try

            If MessageBox.Show("Esta seguro de hacer el envio a SAE?", "Confirmacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
             = Windows.Forms.DialogResult.Yes Then

                Dim dt_encabezado As New DataTable
                Dim dt_partidas As New DataTable
                Dim dt_parfactd As New DataTable

                Dim subtotal_isv As Double = 0, subtotal_sinisv As Double = 0
                Dim val_isv As Double = 0
                Dim isv_total As Double = 0, subtotal_general As Double

                dt_partidas.Columns.Add("num_part")
                dt_partidas.Columns.Add("cve_art")
                dt_partidas.Columns.Add("cantidad")
                dt_partidas.Columns.Add("monto")
                dt_partidas.Columns.Add("proveedor")
                dt_partidas.Columns.Add("concepto")
                dt_partidas.Columns.Add("isv")
                dt_partidas.Columns.Add("subtotal")

                For index As Integer = 0 To grd_lista.Rows.Count - 1
                    dt_partidas.Rows.Add(index + 1, grd_lista.Rows(index).Cells(0).Value, grd_lista.Rows(index).Cells(1).Value, _
                grd_lista.Rows(index).Cells(2).Value, grd_lista.Rows(index).Cells(3).Value, grd_lista.Rows(index).Cells(4).Value _
                , grd_lista.Rows(index).Cells(5).Value, grd_lista.Rows(index).Cells(6).Value)
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

                dt_encabezado.Rows.Add(txt_cve_vend.Text, txt_numero_factura.Text, txt_codigo_cliente.Text, Val(txt_num_alma.Text), _
                                       txt_tipo.Text, Val(txt_total.Text), "", txt_fecha.Text, subtotal_general, isv_total)

                dt_parfactd.Columns.Add("CVE_ART")
                dt_parfactd.Columns.Add("CANT")
                dt_parfactd.Columns.Add("PXS")
                dt_parfactd.Columns.Add("PREC")
                dt_parfactd.Columns.Add("IMPU4")
                dt_parfactd.Columns.Add("TOT_IMP4")
                dt_parfactd.Columns.Add("UNI_VENTA")
                dt_parfactd.Columns.Add("TOT_PARTIDA")

                If subtotal_isv > 0 And subtotal_sinisv > 0 Then
                    dt_parfactd.Rows.Add("ZDEV01", "1", "1", subtotal_isv, val_isv, 0, "cj", subtotal_isv)
                    dt_parfactd.Rows.Add("ZDEV01", "1", "1", subtotal_sinisv, 0, 0, "cj", subtotal_sinisv)
                Else
                    If subtotal_isv > 0 Then
                        dt_parfactd.Rows.Add("ZDEV01", "1", "1", subtotal_isv, val_isv, (subtotal_isv * val_isv / 100), "cj", subtotal_isv)
                    ElseIf subtotal_sinisv > 0 Then
                        dt_parfactd.Rows.Add("ZDEV01", "1", "1", subtotal_sinisv, 0, 0, "cj", subtotal_sinisv)
                    End If
                End If

                Dim variable_error As String = ""
                variable_error = conexion.hacer_envio_sae_dimosa(dt_encabezado, dt_partidas, dt_adic.Rows(0)(1), dt_parfactd, subtotal_general, isv_total, dt_adic.Rows(0)(2), dt_adic.Rows(0)(0), txt_num_registro.Text)

                Dim conexion_bita As New cls_bitacora_reporteador
                conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Genero Nota de Credito DIMOSA", "Almacen - Devoluciones", _
                                          "Fecha: " + txt_fecha.Text + _
                                          " Facturas: " + txt_numero_factura.Text)

                If variable_error = "correcto" Then
                    MessageBox.Show("Informacion almacenada correctamente", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.Close()
                Else
                    MessageBox.Show(variable_error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            If txt_estado.Text = "SIN ENVIAR" Then
                If MessageBox.Show("Desea Eliminar el descuento tactico con codigo " + _
                               txt_num_registro.Text + " ?", _
                              "Confirmacion", MessageBoxButtons.YesNoCancel, _
                              MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Dim var_error As String = ""
                    var_error = conexion.delete_descuento_tactico_dimosa(txt_num_registro.Text, txt_fecha.Text)

                    If var_error = "correcto" Then
                        MessageBox.Show("Registro eliminado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        MessageBox.Show("No se elimino el registro..." + var_error, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
                Me.Close()
            Else
                MessageBox.Show("No se puede eliminar el registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_modifcar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modifcar.Click
        frm_modificar_descuento_tactico_dimosa.Close()
        frm_modificar_descuento_tactico_dimosa.ShowDialog()
    End Sub
End Class