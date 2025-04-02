Imports Disar.data
Public Class frm_detalle_productos
    Dim conexion As New cls_devoluciones
    Private Sub frm_detalle_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_detalle_productos.DataSource = conexion.lista_encabezados_devoluciones(cmb_fecha.Value, txt_num_alma.Text, _
                                                    "DETALLE_PRODUCTOS", txt_factura_inicial.Text, txt_factura_final.Text, txt_cve_art.Text)

            grd_detalle_productos.Columns(0).ReadOnly = True
            grd_detalle_productos.Columns(1).ReadOnly = True
            grd_detalle_productos.Columns(2).ReadOnly = True
            grd_detalle_productos.Columns(3).ReadOnly = True
            grd_detalle_productos.Columns(5).ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Try
            Dim validador As Integer = 0
            For index As Integer = 0 To grd_detalle_productos.RowCount - 1
                If grd_detalle_productos.Rows(index).Cells(4).Value > grd_detalle_productos.Rows(index).Cells(5).Value Then
                    validador += 1
                End If
            Next


            If validador > 0 Then
                MessageBox.Show("No Puede Ingresar cantidad mayor que la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else

                Dim variable_error As String = ""
                Dim tabla_modificar As New DataTable
                tabla_modificar = CType(grd_detalle_productos.DataSource, DataTable)


                variable_error = conexion.modificar_detalle_productos(tabla_modificar, txt_cve_art.Text)

                If variable_error = "correcto" Then
                    MessageBox.Show("Informacion actualizada correctamente", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frm_devoluciones_ingresadas.cargar()

                    Dim conexion_bita As New cls_bitacora_reporteador
                    conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Modificacion Devoluciones desde Recepcion", "Almacen - Devoluciones", _
                                              "Fecha: " + cmb_fecha.Value + _
                                              " Facturas: " + txt_factura_inicial.Text + "-" + txt_factura_final.Text)

                    Me.Close()
                Else
                    MessageBox.Show(variable_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class