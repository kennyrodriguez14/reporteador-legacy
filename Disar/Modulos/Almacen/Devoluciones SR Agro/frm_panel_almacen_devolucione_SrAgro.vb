﻿Imports Disar.data

Public Class frm_panel_almacen_devolucione_SrAgro

    Dim conexion As New cls_devolucionesAgro
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        frm_devoluciones_ingresadasSrAgro.Close()
        frm_devoluciones_ingresadasSrAgro.ShowDialog()
        cargar()
    End Sub

    Private Sub frm_panel_almacen_devoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_almacen()
        cargar()
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

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        cargar()
    End Sub

    Sub cargar()
        Try
            grd_recepciones.DataSource = conexion.lista_encabezados_devoluciones(cmb_fecha_ini.Value, cmb_sucursal.SelectedValue, _
                                                    "ENCABEZADO_RECEPCION", "", "", "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

End Class