Imports Disar.data

Public Class frm_cancelar_nc
    Dim conexion As New cls_descuentos_tacticos
    Dim dt_tabla_poliza_coi As DataTable
    Dim num_poliza As String = ""
    Dim tipo_poliza As String = ""

    Dim num_poliza_C31 As String = ""
    Dim tipo_poliza_C31 As String = ""
    Dim dt_tabla_poliza_coi_C31 As DataTable

    Private Sub btn_cancelar_nc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_nc.Click
        Try
            cargar_datos()
            Dim dt_estado As New DataTable
            dt_estado = conexion.get_estado_nc(txt_nc.Text)

            Dim resultado As String = ""
            If dt_estado.Rows(0)(0) <> "C" Then
                If MessageBox.Show("¿Desea Cancelar la NC del Cliente " + txt_cliente.Text + " ?", "Confirmacion", MessageBoxButtons.YesNoCancel, _
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    resultado = conexion.eliminar_nc_sae(txt_nc.Text, txt_cod_cliente.Text, txt_monto.Text, txt_codigo_local.Text, _
                                                         txt_tipo.Text, txt_cargo_por_dev.Text, txt_ctlpol.Text, num_poliza, _
                                                         txt_year.Text, txt_mes.Text, tipo_poliza, dt_tabla_poliza_coi, _
                                                         txt_interface.Text, txt_contabilizado.Text, txt_factura.Text, _
                                                         _Inicio.lblUsuario.Text, txt_interface_C31.Text, txt_ctlpol_C31.Text, _
                                                         txt_year_C31.Text, txt_mes_c31.Text, txt_contabilizado_C31.Text, tipo_poliza_C31, _
                                                         dt_tabla_poliza_coi_C31, num_poliza_C31)

                    If resultado = "correcto" Then
                        MessageBox.Show("NC Cancelada Exitosamente")
                        Me.Close()
                    Else
                        MessageBox.Show(resultado)
                    End If
                Else
                End If
            Else
                MessageBox.Show("La nota de credito esta cancelada")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_datos()
        Try
            Dim ctlpol As Integer = 0
            ctlpol = conexion.listar_ctlpol(txt_nc.Text)
            txt_ctlpol.Text = ctlpol
            If txt_ctlpol.Text = "0" Then
                txt_interface.Text = "No"
            Else
                txt_interface.Text = "Si"
                grd_facturas.DataSource = conexion.Listardoctos_pol(txt_ctlpol.Text)
            End If

            grd_ctlpol.DataSource = conexion.Listarctlpol(txt_ctlpol.Text)

            If grd_ctlpol.Rows.Count > 0 Then
                If grd_ctlpol.Rows(0).Cells(0).Value = "" Then
                    txt_contabilizado.Text = "No"
                Else
                    txt_contabilizado.Text = "Si"
                End If

                If txt_contabilizado.Text = "Si" Then
                    Dim fecha_coi As Date = grd_ctlpol.Rows(0).Cells(2).Value
                    txt_mes.Text = fecha_coi.Month
                    txt_year.Text = fecha_coi.Year
                    num_poliza = grd_ctlpol.Rows(0).Cells(1).Value
                    tipo_poliza = grd_ctlpol.Rows(0).Cells(0).Value
                    dt_tabla_poliza_coi = conexion.seleccionar_poliza_coi(num_poliza, txt_year.Text, txt_mes.Text, tipo_poliza)
                    grd_poliza.DataSource = dt_tabla_poliza_coi
                Else
                    txt_mes.Text = "0"
                    txt_year.Text = "0"
                End If
            Else
                txt_contabilizado.Text = "No"
                txt_mes.Text = "0"
                txt_year.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'cargar datos de Concepto31
        Try
            Dim ctlpol_concepto31 As Integer = 0
            ctlpol_concepto31 = conexion.listar_ctlpol_concepto31(txt_nc.Text, txt_cargo_por_dev.Text)
            txt_ctlpol_C31.Text = ctlpol_concepto31
            If txt_ctlpol_C31.Text = "0" Then
                txt_interface_C31.Text = "No"
            Else
                txt_interface_C31.Text = "Si"
                grd_facturas_C31.DataSource = conexion.Listardoctos_pol_C31(txt_ctlpol_C31.Text)
            End If

            grd_ctlpol_C31.DataSource = conexion.Listarctlpol(txt_ctlpol_C31.Text)

            If grd_ctlpol_C31.Rows.Count > 0 Then
                If grd_ctlpol_C31.Rows(0).Cells(0).Value = "" Then
                    txt_contabilizado_C31.Text = "No"
                Else
                    txt_contabilizado_C31.Text = "Si"
                End If

                If txt_contabilizado_C31.Text = "Si" Then
                    Dim fecha_coi_C31 As Date = grd_ctlpol_C31.Rows(0).Cells(2).Value
                    txt_mes_c31.Text = fecha_coi_C31.Month
                    txt_year_C31.Text = fecha_coi_C31.Year
                    num_poliza_C31 = grd_ctlpol_C31.Rows(0).Cells(1).Value
                    tipo_poliza_C31 = grd_ctlpol_C31.Rows(0).Cells(0).Value
                    dt_tabla_poliza_coi_C31 = conexion.seleccionar_poliza_coi(num_poliza_C31, txt_year_C31.Text, txt_mes_c31.Text, tipo_poliza_C31)
                    grd_poliza_C31.DataSource = dt_tabla_poliza_coi_C31
                Else
                    txt_mes_c31.Text = "0"
                    txt_year_C31.Text = "0"
                End If
            Else
                txt_contabilizado_C31.Text = "No"
                txt_mes_c31.Text = "0"
                txt_year_C31.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_cancelar_nc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_datos()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class