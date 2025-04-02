Imports Disar.data

Public Class frm_carga_devos_dimosa
    Dim conexion As New cls_devoluciones
    Private Sub frm_carga_devos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_almacen()
        cargar_entregador()
    End Sub

    Sub cargar_almacen()
        Try
            cmb_sucursal.DataSource = conexion.ListarAlmacenes2()
            cmb_sucursal.ValueMember = "ID"
            cmb_sucursal.DisplayMember = "ALMACEN"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_entregador()
        Dim db As New ClsEfectividad
        Try
            ComboEntregador.DataSource = db.Entregadores(cmb_sucursal.SelectedValue, "DIMOSA")
            ComboEntregador.ValueMember = "EntregadorCodigo"
            ComboEntregador.DisplayMember = "EntregadorNombre"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmb_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_sucursal.SelectedIndexChanged
        cargar_entregador()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar()
        filtros.Enabled = False
    End Sub

    Sub cargar()
        Try
            grd_devos.DataSource = conexion.cargar_devos_entrega(cmb_fecha_ini.Value, "ENCABEZADO", ComboEntregador.SelectedValue, "DIMOSA", "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If grd_devos.RowCount <= 0 Then
                MsgBox("No hay devoluciones pendientes para cargar")
            Else

                Dim conteo As Integer = 0
                Dim error_acum = ""
                For index As Integer = 0 To grd_devos.Rows.Count - 1

                    Dim dt_encabezado As New DataTable
                    Dim dt_partidas As New DataTable

                    dt_encabezado.Columns.Add("cliente") '0
                    dt_encabezado.Columns.Add("tipo_pago") '1
                    dt_encabezado.Columns.Add("codigo_vendedor") '2
                    dt_encabezado.Columns.Add("almacen") '3
                    dt_encabezado.Columns.Add("n_factura") '4
                    dt_encabezado.Columns.Add("fecha_sae") '5
                    dt_encabezado.Columns.Add("fecha_elaboracion") '6
                    dt_encabezado.Columns.Add("concepto") '7
                    dt_encabezado.Columns.Add("cod_entregador") '8
                    dt_encabezado.Columns.Add("vehiculo") '9
                    dt_encabezado.Columns.Add("tipo_parcial") '10
                    dt_encabezado.Columns.Add("fecha_entrega") '11
                    dt_encabezado.Columns.Add("fecha_vencimiento") '12
                    dt_encabezado.Columns.Add("condicion") '13
                    dt_encabezado.Columns.Add("rfc") '14
                    dt_encabezado.Columns.Add("autoriza") '15
                    dt_encabezado.Columns.Add("folio") '16
                    dt_encabezado.Columns.Add("autoanio") '17

                    dt_encabezado.Rows.Add(grd_devos.Rows(index).Cells(0).Value, grd_devos.Rows(index).Cells(1).Value, grd_devos.Rows(index).Cells(2).Value, _
                                           grd_devos.Rows(index).Cells(3).Value, grd_devos.Rows(index).Cells(4).Value, grd_devos.Rows(index).Cells(5).Value, _
                                           grd_devos.Rows(index).Cells(6).Value, grd_devos.Rows(index).Cells(7).Value, grd_devos.Rows(index).Cells(8).Value, _
                                           grd_devos.Rows(index).Cells(9).Value, grd_devos.Rows(index).Cells(10).Value, grd_devos.Rows(index).Cells(11).Value, _
                                           grd_devos.Rows(index).Cells(12).Value, grd_devos.Rows(index).Cells(13).Value, grd_devos.Rows(index).Cells(14).Value, _
                                           grd_devos.Rows(index).Cells(15).Value, grd_devos.Rows(index).Cells(16).Value, grd_devos.Rows(index).Cells(17).Value)

                    dt_partidas = conexion.cargar_devos_entrega(cmb_fecha_ini.Value, "PARTIDAS", ComboEntregador.SelectedValue, "DIMOSA", grd_devos.Rows(index).Cells(4).Value)

                    Dim variable_error As String = ""
                    variable_error = conexion.guardar_datos_local_aplicacion_android_DIMOSA(dt_encabezado, dt_partidas, "DIMOSA")

                    If variable_error = "correcto" Then
                        conteo += 1
                    Else
                        error_acum = " " + variable_error
                    End If
                Next

                If conteo < grd_devos.RowCount Then
                    MsgBox("Ocurrió un error: " + error_acum)
                Else
                    MsgBox("Devoluciones cargadas correctamente" + error_acum)
                End If

                cargar()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        filtros.Enabled = True
        grd_devos.DataSource = Nothing
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click

    End Sub
End Class