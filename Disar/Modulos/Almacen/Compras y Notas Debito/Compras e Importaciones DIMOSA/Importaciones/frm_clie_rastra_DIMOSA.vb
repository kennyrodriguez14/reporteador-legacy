﻿Imports Disar.data
Public Class frm_clie_rastra_DIMOSA
    Dim conexion As New cls_descuentos_tacticos
    Public codigo, cliente, cve_vend, vendedor, rfc, pago As String
    Private Sub txt_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_busqueda.TextChanged
        Try
            grd_lista.DataSource = conexion.Listar_ClientesDIMOSA(txt_busqueda.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub grd_lista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grd_lista.DoubleClick
        Try
            codigo = grd_lista.CurrentRow.Cells(0).Value
            cliente = grd_lista.CurrentRow.Cells(1).Value
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class